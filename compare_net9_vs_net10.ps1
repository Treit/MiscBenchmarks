#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Compares .NET 9 vs .NET 10 benchmark results and generates comparison data.

.DESCRIPTION
    Analyzes baseline_results.json to extract .NET 9 and .NET 10 results,
    computes performance and memory differences, and outputs comparison data.

.PARAMETER ResultsPath
    Path to the results JSON file. Defaults to "baseline_results.json".

.PARAMETER OutputPath
    Path where the comparison JSON will be saved. Defaults to "net9_vs_net10_comparison.json".

.PARAMETER Net9Pattern
    Regex pattern to match .NET 9 versions. Defaults to "^9\.".

.PARAMETER Net10Pattern
    Regex pattern to match .NET 10 versions. Defaults to "^10\.".

.EXAMPLE
    .\compare_net9_vs_net10.ps1
    .\compare_net9_vs_net10.ps1 -ResultsPath "baseline_results.json" -OutputPath "comparison.json"
#>

param(
    [string]$ResultsPath = ".\readme_results.json",
    [string]$OutputPath = ".\net9_vs_net10_comparison.json",
    [string]$Net9Pattern = "\.NET 9",
    [string]$Net10Pattern = "\.NET 10"
)

if (-not (Test-Path $ResultsPath)) {
    Write-Host "Error: Results file not found at $ResultsPath" -ForegroundColor Red
    exit 1
}

function Parse-TimeValue {
    param([string]$value)

    if (-not $value -or $value -eq "-") { return $null }

    # Remove commas and extract number and unit
    $value = $value -replace ',', ''
    if ($value -match '([0-9.]+)\s*(ns|μs|ms|s)') {
        $number = [double]$matches[1]
        $unit = $matches[2]

        # Convert to nanoseconds for comparison
        switch ($unit) {
            'ns' { return $number }
            'μs' { return $number * 1000 }
            'ms' { return $number * 1000000 }
            's'  { return $number * 1000000000 }
        }
    }

    return $null
}

function Parse-MemoryValue {
    param([string]$value)

    if (-not $value -or $value -eq "-") { return $null }

    # Remove commas and extract number and unit
    $value = $value -replace ',', ''
    if ($value -match '([0-9.]+)\s*(B|KB|MB|GB)') {
        $number = [double]$matches[1]
        $unit = $matches[2]

        # Convert to bytes for comparison
        switch ($unit) {
            'B'  { return $number }
            'KB' { return $number * 1024 }
            'MB' { return $number * 1048576 }
            'GB' { return $number * 1073741824 }
        }
    }

    return $null
}

Write-Host "Loading benchmark results..." -ForegroundColor Cyan
$allResults = Get-Content $ResultsPath -Raw | ConvertFrom-Json

# Group by benchmark name and method and all parameter columns
Write-Host "Grouping results by benchmark and method..." -ForegroundColor Cyan

# Get all unique property names that might be parameters (excluding known standard columns)
$standardColumns = @('BenchmarkName', 'Method', 'Job', 'Runtime', 'Mean', 'Error', 'StdDev', 'Median', 'Ratio', 'RatioSD', 'Allocated', 'AllocRatio', 'Gen0', 'Gen1', 'Gen2')
$firstResult = $allResults | Select-Object -First 1
$paramColumns = $firstResult.PSObject.Properties.Name | Where-Object { $standardColumns -notcontains $_ }

# Build grouping key including all parameter columns
$grouped = $allResults | Group-Object -Property @{Expression = {
    $params = @($_.BenchmarkName, $_.Method)
    foreach ($col in $paramColumns) {
        $params += $_.$col
    }
    $params -join "|"
}}

$comparisons = @()
$net9Count = 0
$net10Count = 0
$matchedCount = 0

Write-Host "Processing comparisons..." -ForegroundColor Cyan

foreach ($group in $grouped) {
    # Match based on Runtime or Job column
    $net9Results = $group.Group | Where-Object { $_.Runtime -match $Net9Pattern -or $_.Job -match $Net9Pattern }
    $net10Results = $group.Group | Where-Object { $_.Runtime -match $Net10Pattern -or $_.Job -match $Net10Pattern }

    if ($net9Results) { $net9Count++ }
    if ($net10Results) { $net10Count++ }

    if ($net9Results -and $net10Results) {
        # Take the first match for each (in case there are multiple versions)
        $net9 = $net9Results | Select-Object -First 1
        $net10 = $net10Results | Select-Object -First 1

        $matchedCount++

        # Parse time values
        $net9Time = $null
        $net10Time = $null
        $timeChangePercent = $null

        if ($net9.Mean -and $net10.Mean) {
            $net9Time = Parse-TimeValue $net9.Mean
            $net10Time = Parse-TimeValue $net10.Mean

            if ($net9Time -and $net10Time -and $net9Time -gt 0) {
                $timeChangePercent = (($net10Time - $net9Time) / $net9Time) * 100
            }
        }

        # Parse memory values
        $net9Memory = $null
        $net10Memory = $null
        $memoryChangePercent = $null

        if ($net9.Allocated -and $net10.Allocated -and
            $net9.Allocated -ne "-" -and $net10.Allocated -ne "-") {
            $net9Memory = Parse-MemoryValue $net9.Allocated
            $net10Memory = Parse-MemoryValue $net10.Allocated

            if ($net9Memory -and $net10Memory -and $net9Memory -gt 0) {
                $memoryChangePercent = (($net10Memory - $net9Memory) / $net9Memory) * 100
            }
        }

        # Build comparison object with dynamic parameters
        $comparison = [PSCustomObject]@{
            BenchmarkName = $net9.BenchmarkName
            Method = $net9.Method
            Net9Version = if ($net9.Runtime) { $net9.Runtime } else { $net9.Job }
            Net10Version = if ($net10.Runtime) { $net10.Runtime } else { $net10.Job }
            Net9Time = $net9.Mean
            Net10Time = $net10.Mean
            TimeChangePercent = $timeChangePercent
            Net9Memory = if ($net9.Allocated) { $net9.Allocated } else { "-" }
            Net10Memory = if ($net10.Allocated) { $net10.Allocated } else { "-" }
            MemoryChangePercent = $memoryChangePercent
        }

        # Add parameter columns dynamically
        foreach ($col in $paramColumns) {
            if ($net9.$col) {
                $comparison | Add-Member -NotePropertyName $col -NotePropertyValue $net9.$col
            }
        }

        $comparisons += $comparison
    }
}

# Save results
Write-Host "`nSaving comparison results..." -ForegroundColor Cyan
$comparisons | ConvertTo-Json -Depth 10 | Out-File $OutputPath -Encoding UTF8

Write-Host "`n=== Summary ===" -ForegroundColor Yellow
Write-Host "Total unique .NET 9 benchmarks: $net9Count" -ForegroundColor White
Write-Host "Total unique .NET 10 benchmarks: $net10Count" -ForegroundColor White
Write-Host "Matched comparisons: $matchedCount" -ForegroundColor Green

$improvements = ($comparisons | Where-Object { $_.TimeChangePercent -lt -5 }).Count
$regressions = ($comparisons | Where-Object { $_.TimeChangePercent -gt 5 }).Count
$neutral = $matchedCount - $improvements - $regressions

Write-Host "`nPerformance Changes:" -ForegroundColor Yellow
Write-Host "  🟢 Improvements (>5% faster): $improvements" -ForegroundColor Green
Write-Host "  🔴 Regressions (>5% slower): $regressions" -ForegroundColor Red
Write-Host "  ⚪ Neutral (±5%): $neutral" -ForegroundColor Gray

Write-Host "`n✓ Comparison data saved to: $OutputPath" -ForegroundColor Green
