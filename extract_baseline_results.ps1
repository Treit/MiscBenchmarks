#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Extracts existing benchmark results from all README.md files to create a baseline for .NET 10 comparison.

.DESCRIPTION
    This script parses all README.md files in the benchmark directories, extracts BenchmarkDotNet results,
    and creates both JSON and CSV files containing the baseline data. This allows for easy comparison
    when upgrading to .NET 10.

.PARAMETER OutputPath
    Path where the output files will be saved. Defaults to current directory.

.EXAMPLE
    .\extract_baseline_results.ps1
    .\extract_baseline_results.ps1 -OutputPath ".\baseline"
#>

param(
    [string]$OutputPath = "."
)

# Function to extract .NET version from the BenchmarkDotNet header
function Get-DotNetVersion {
    param([string[]]$lines)

    foreach ($line in $lines) {
        # Look for patterns like ".NET 8.0.5", ".NET 9.0.10", etc.
        if ($line -match '\.NET (\d+\.\d+\.\d+)') {
            return $matches[1]
        }
        if ($line -match '\.NET SDK (\d+\.\d+\.\d+)') {
            $sdkVersion = $matches[1]
        }
    }

    # If we found SDK version but not runtime, try to infer
    if ($sdkVersion) {
        if ($sdkVersion -match '^8\.') { return "8.0" }
        if ($sdkVersion -match '^9\.') { return "9.0" }
        if ($sdkVersion -match '^10\.') { return "10.0" }
    }

    return "Unknown"
}

# Function to parse markdown table and extract data
function Parse-BenchmarkTable {
    param(
        [string[]]$lines,
        [int]$startIndex
    )

    $results = @()
    $headers = @()
    $i = $startIndex

    # Find the table header (line starting with |)
    while ($i -lt $lines.Count -and $lines[$i] -notmatch '^\|.*Method') {
        $i++
    }

    if ($i -ge $lines.Count) {
        return $results
    }

    # Parse header
    $headerLine = $lines[$i]
    $headers = $headerLine -split '\|' | ForEach-Object { $_.Trim() } | Where-Object { $_ }
    $i++

    # Skip separator line (|-------|)
    if ($i -lt $lines.Count -and $lines[$i] -match '^\|[\s\-\:]+\|') {
        $i++
    }

    # Parse data rows
    while ($i -lt $lines.Count -and $lines[$i] -match '^\|' -and $lines[$i] -notmatch '^```') {
        $row = $lines[$i] -split '\|' | ForEach-Object { $_.Trim() } | Where-Object { $_ -ne '' }

        if ($row.Count -ge 2) {
            $rowData = @{}
            for ($j = 0; $j -lt [Math]::Min($headers.Count, $row.Count); $j++) {
                $rowData[$headers[$j]] = $row[$j]
            }
            $results += $rowData
        }

        $i++
    }

    return $results
}

# Main script
Write-Host "Extracting baseline benchmark results..." -ForegroundColor Cyan
Write-Host ""

$scriptRoot = $PSScriptRoot
$allResults = @()
$benchmarkCount = 0
$errorCount = 0

# Find all benchmark directories (those containing a README.md and not being the root)
$readmeFiles = Get-ChildItem -Path $scriptRoot -Filter "README.md" -Recurse -File |
    Where-Object { $_.DirectoryName -ne $scriptRoot -and $_.Directory.Name -ne "tools" }

Write-Host "Found $($readmeFiles.Count) README.md files to process" -ForegroundColor Yellow
Write-Host ""

foreach ($readme in $readmeFiles) {
    $benchmarkName = $readme.Directory.Name
    Write-Host "Processing: $benchmarkName" -ForegroundColor Gray

    try {
        $content = Get-Content $readme.FullName -Raw
        $lines = Get-Content $readme.FullName

        # Extract .NET version
        $dotnetVersion = Get-DotNetVersion -lines $lines

        # Find and parse all tables in the README
        $tableResults = Parse-BenchmarkTable -lines $lines -startIndex 0

        if ($tableResults.Count -gt 0) {
            foreach ($result in $tableResults) {
                $entry = [PSCustomObject]@{
                    BenchmarkName = $benchmarkName
                    DotNetVersion = $dotnetVersion
                    Method = $result['Method']
                    Mean = $result['Mean']
                    Error = $result['Error']
                    StdDev = $result['StdDev']
                    Median = $result['Median']
                    Ratio = $result['Ratio']
                    Gen0 = $result['Gen0']
                    Gen1 = $result['Gen1']
                    Gen2 = $result['Gen2']
                    Allocated = $result['Allocated']
                    AllocRatio = $result['Alloc Ratio']
                    Count = $result['Count']
                    Iterations = $result['Iterations']
                    CodeSize = $result['Code Size']
                }

                $allResults += $entry
                $benchmarkCount++
            }
            Write-Host "  ✓ Extracted $($tableResults.Count) results (.NET $dotnetVersion)" -ForegroundColor Green
        }
        else {
            Write-Host "  ⚠ No benchmark table found" -ForegroundColor Yellow
        }
    }
    catch {
        Write-Host "  ✗ Error processing: $_" -ForegroundColor Red
        $errorCount++
    }
}

Write-Host ""
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  Total benchmarks processed: $($readmeFiles.Count)" -ForegroundColor White
Write-Host "  Total results extracted: $benchmarkCount" -ForegroundColor White
Write-Host "  Errors: $errorCount" -ForegroundColor White
Write-Host ""

# Ensure output directory exists
$outputDir = Join-Path $scriptRoot $OutputPath
if (-not (Test-Path $outputDir)) {
    New-Item -Path $outputDir -ItemType Directory -Force | Out-Null
}

# Export to JSON
$jsonPath = Join-Path $outputDir "baseline_results.json"
$allResults | ConvertTo-Json -Depth 10 | Out-File $jsonPath -Encoding UTF8
Write-Host "✓ JSON file created: $jsonPath" -ForegroundColor Green

# Export to CSV
$csvPath = Join-Path $outputDir "baseline_results.csv"
$allResults | Export-Csv $csvPath -NoTypeInformation -Encoding UTF8
Write-Host "✓ CSV file created: $csvPath" -ForegroundColor Green

Write-Host ""
Write-Host "Baseline extraction complete!" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "  1. Upgrade your benchmarks to .NET 10" -ForegroundColor White
Write-Host "  2. Run the benchmarks on .NET 10" -ForegroundColor White
Write-Host "  3. Use the baseline files to compare performance changes" -ForegroundColor White
Write-Host ""

# Display summary by .NET version
Write-Host "Results by .NET version:" -ForegroundColor Cyan
$allResults | Group-Object DotNetVersion |
    Sort-Object Name |
    ForEach-Object {
        Write-Host "  .NET $($_.Name): $($_.Count) results" -ForegroundColor White
    }
