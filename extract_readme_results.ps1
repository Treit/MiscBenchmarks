#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Extracts benchmark results from README.md files and converts to JSON.

.DESCRIPTION
    Scans all benchmark directories for README.md files, parses the markdown tables
    containing benchmark results, and outputs structured JSON data.

.PARAMETER OutputPath
    Path where the JSON results will be saved. Defaults to "readme_results.json".

.EXAMPLE
    .\extract_readme_results.ps1
    .\extract_readme_results.ps1 -OutputPath "results.json"
#>

param(
    [string]$OutputPath = ".\readme_results.json"
)

Write-Host "Scanning for README.md files in benchmark directories..." -ForegroundColor Cyan

# Find all README.md files in subdirectories (excluding root)
$readmeFiles = Get-ChildItem -Path . -Filter "README.md" -Recurse -File |
    Where-Object { $_.DirectoryName -ne $PWD.Path }

Write-Host "Found $($readmeFiles.Count) README files" -ForegroundColor Green

$allResults = @()
$processedCount = 0
$skippedCount = 0

foreach ($readme in $readmeFiles) {
    $benchmarkName = $readme.Directory.Name
    Write-Host "Processing: $benchmarkName" -ForegroundColor Gray

    $content = Get-Content $readme.FullName -Raw

    # Find the markdown table in the README
    # Tables start with | Method and have multiple rows
    if ($content -match '(?ms)\| Method.*?\|.*?\n\|[-:\| ]+\n(.*?)(?:\n\n|\n```|\z)') {
        $tableContent = $matches[0]
        $lines = $tableContent -split '\n' | Where-Object { $_ -match '^\|' -and $_ -notmatch '^[\|\- :]+$' }

        if ($lines.Count -lt 2) {
            Write-Host "  ⚠ No valid table data found" -ForegroundColor Yellow
            $skippedCount++
            continue
        }

        # Parse header
        $headerLine = $lines[0]
        $headers = $headerLine -split '\|' | ForEach-Object { $_.Trim() } | Where-Object { $_ -ne '' }

        # Parse data rows (skip header and separator)
        $dataLines = $lines | Select-Object -Skip 2

        foreach ($line in $dataLines) {
            # Skip empty or separator lines
            if ($line -match '^[\|\- :]+$' -or $line -notmatch '\w') {
                continue
            }

            $cells = $line -split '\|' | ForEach-Object { $_.Trim() }
            # Remove first and last empty cells (from leading/trailing |)
            if ($cells.Count -gt 0 -and $cells[0] -eq '') {
                $cells = $cells[1..($cells.Count-1)]
            }
            if ($cells.Count -gt 0 -and $cells[-1] -eq '') {
                $cells = $cells[0..($cells.Count-2)]
            }

            # Skip lines that don't have enough data
            if ($cells.Count -lt 2) {
                continue
            }

            # Create object from row
            $result = [PSCustomObject]@{
                BenchmarkName = $benchmarkName
            }

            for ($i = 0; $i -lt [Math]::Min($headers.Count, $cells.Count); $i++) {
                $headerName = $headers[$i]
                $cellValue = $cells[$i]

                # Map common variations
                switch ($headerName) {
                    'Job' { $result | Add-Member -NotePropertyName 'Job' -NotePropertyValue $cellValue }
                    'Runtime' { $result | Add-Member -NotePropertyName 'Runtime' -NotePropertyValue $cellValue }
                    'Method' { $result | Add-Member -NotePropertyName 'Method' -NotePropertyValue $cellValue }
                    'Mean' { $result | Add-Member -NotePropertyName 'Mean' -NotePropertyValue $cellValue }
                    'Error' { $result | Add-Member -NotePropertyName 'Error' -NotePropertyValue $cellValue }
                    'StdDev' { $result | Add-Member -NotePropertyName 'StdDev' -NotePropertyValue $cellValue }
                    'Median' { $result | Add-Member -NotePropertyName 'Median' -NotePropertyValue $cellValue }
                    'Ratio' { $result | Add-Member -NotePropertyName 'Ratio' -NotePropertyValue $cellValue }
                    'RatioSD' { $result | Add-Member -NotePropertyName 'RatioSD' -NotePropertyValue $cellValue }
                    'Allocated' { $result | Add-Member -NotePropertyName 'Allocated' -NotePropertyValue $cellValue }
                    'Alloc Ratio' { $result | Add-Member -NotePropertyName 'AllocRatio' -NotePropertyValue $cellValue }
                    'Gen0' { $result | Add-Member -NotePropertyName 'Gen0' -NotePropertyValue $cellValue }
                    'Gen1' { $result | Add-Member -NotePropertyName 'Gen1' -NotePropertyValue $cellValue }
                    'Gen2' { $result | Add-Member -NotePropertyName 'Gen2' -NotePropertyValue $cellValue }
                    default {
                        # Handle dynamic columns like Count, Iterations, Size, etc.
                        $result | Add-Member -NotePropertyName $headerName -NotePropertyValue $cellValue -ErrorAction SilentlyContinue
                    }
                }
            }

            # Only add if we have essential data
            if ($result.Method -and $result.Mean) {
                $allResults += $result
            }
        }

        $processedCount++
    }
    else {
        Write-Host "  ⚠ No table found" -ForegroundColor Yellow
        $skippedCount++
    }
}

Write-Host "`n=== Summary ===" -ForegroundColor Yellow
Write-Host "Successfully processed: $processedCount benchmarks" -ForegroundColor Green
Write-Host "Skipped (no table): $skippedCount benchmarks" -ForegroundColor Gray
Write-Host "Total results extracted: $($allResults.Count)" -ForegroundColor Cyan

# Save to JSON
Write-Host "`nSaving results to: $OutputPath" -ForegroundColor Cyan
$allResults | ConvertTo-Json -Depth 10 | Out-File $OutputPath -Encoding UTF8

Write-Host "✓ Results saved successfully!" -ForegroundColor Green
