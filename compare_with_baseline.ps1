#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Compares new benchmark results against the baseline to show performance improvements/regressions.

.DESCRIPTION
    This script compares current benchmark results (from .NET 10) against the baseline results
    extracted previously. It generates a comparison report showing which benchmarks got faster,
    slower, or had allocation changes.

.PARAMETER BaselinePath
    Path to the baseline JSON file. Defaults to "baseline_results.json" in the script directory.

.PARAMETER NewResultsPath
    Path to the new results JSON file. If not provided, the script will attempt to extract
    results from current README.md files.

.PARAMETER OutputPath
    Path where comparison reports will be saved. Defaults to current directory.

.PARAMETER MinimumChangePercent
    Minimum percentage change to highlight. Defaults to 5%.

.EXAMPLE
    .\compare_with_baseline.ps1
    .\compare_with_baseline.ps1 -MinimumChangePercent 10
    .\compare_with_baseline.ps1 -BaselinePath ".\baseline_results.json" -OutputPath ".\comparison"
#>

param(
    [string]$BaselinePath = ".\baseline_results.json",
    [string]$NewResultsPath = "",
    [string]$OutputPath = ".",
    [double]$MinimumChangePercent = 5.0
)

function Parse-TimeValue {
    param([string]$value)

    if ([string]::IsNullOrWhiteSpace($value)) {
        return $null
    }

    # Remove commas
    $value = $value -replace ',', ''

    # Parse based on unit
    if ($value -match '([\d.]+)\s*ns') {
        return [double]$matches[1]
    }
    elseif ($value -match '([\d.]+)\s*(?:μs|us)') {
        return [double]$matches[1] * 1000
    }
    elseif ($value -match '([\d.]+)\s*ms') {
        return [double]$matches[1] * 1000000
    }
    elseif ($value -match '([\d.]+)\s*s') {
        return [double]$matches[1] * 1000000000
    }

    return $null
}

function Parse-MemoryValue {
    param([string]$value)

    if ([string]::IsNullOrWhiteSpace($value)) {
        return $null
    }

    # Remove commas and dashes
    $value = $value -replace '[,\-]', ''

    # Parse based on unit
    if ($value -match '([\d.]+)\s*B') {
        return [double]$matches[1]
    }
    elseif ($value -match '([\d.]+)\s*KB') {
        return [double]$matches[1] * 1024
    }
    elseif ($value -match '([\d.]+)\s*MB') {
        return [double]$matches[1] * 1024 * 1024
    }
    elseif ($value -match '([\d.]+)\s*GB') {
        return [double]$matches[1] * 1024 * 1024 * 1024
    }

    return $null
}

function Format-PercentChange {
    param([double]$change)

    if ($change -gt 0) {
        return "+$($change.ToString('F2'))%"
    }
    else {
        return "$($change.ToString('F2'))%"
    }
}

function Get-ChangeIndicator {
    param(
        [double]$change,
        [bool]$isMemory = $false
    )

    $absChange = [Math]::Abs($change)

    if ($absChange -lt $MinimumChangePercent) {
        return "≈"  # No significant change
    }

    # For time and memory, lower is better (negative change is good)
    if ($change -lt -$MinimumChangePercent) {
        return "✓"  # Improvement
    }
    elseif ($change -gt $MinimumChangePercent) {
        return "✗"  # Regression
    }

    return "≈"
}

# Main script
Write-Host "Comparing benchmark results..." -ForegroundColor Cyan
Write-Host ""

# Load baseline results
if (-not (Test-Path $BaselinePath)) {
    Write-Host "Error: Baseline file not found at $BaselinePath" -ForegroundColor Red
    Write-Host "Please run extract_baseline_results.ps1 first to create the baseline." -ForegroundColor Yellow
    exit 1
}

Write-Host "Loading baseline results from: $BaselinePath" -ForegroundColor Gray
$baseline = Get-Content $BaselinePath -Raw | ConvertFrom-Json

# Load or extract new results
$newResults = @()
if ($NewResultsPath -and (Test-Path $NewResultsPath)) {
    Write-Host "Loading new results from: $NewResultsPath" -ForegroundColor Gray
    $newResults = Get-Content $NewResultsPath -Raw | ConvertFrom-Json
}
else {
    Write-Host "Extracting current results from README.md files..." -ForegroundColor Gray
    # Run the extraction script and capture results
    $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) "BenchmarkComparison_$(Get-Random)"
    New-Item -Path $tempDir -ItemType Directory -Force | Out-Null

    try {
        & "$PSScriptRoot\extract_baseline_results.ps1" -OutputPath $tempDir | Out-Null
        $extractedJson = Join-Path $tempDir "baseline_results.json"
        if (Test-Path $extractedJson) {
            $newResults = Get-Content $extractedJson -Raw | ConvertFrom-Json
        }
    }
    finally {
        if (Test-Path $tempDir) {
            Remove-Item $tempDir -Recurse -Force -ErrorAction SilentlyContinue
        }
    }
}

if ($newResults.Count -eq 0) {
    Write-Host "Error: No new results found to compare." -ForegroundColor Red
    exit 1
}

Write-Host "Baseline: $($baseline.Count) results" -ForegroundColor White
Write-Host "New: $($newResults.Count) results" -ForegroundColor White
Write-Host ""

# Group baseline by benchmark and method
$baselineIndex = @{}
foreach ($result in $baseline) {
    $key = "$($result.BenchmarkName)|$($result.Method)"
    if (-not $baselineIndex.ContainsKey($key)) {
        $baselineIndex[$key] = @()
    }
    $baselineIndex[$key] += $result
}

# Compare results
$comparisons = @()
$improvements = 0
$regressions = 0
$noChange = 0

foreach ($newResult in $newResults) {
    $key = "$($newResult.BenchmarkName)|$($newResult.Method)"

    if ($baselineIndex.ContainsKey($key)) {
        # Find matching baseline - require exact match on ALL parameters
        $matchingBaseline = $null
        $baselineCandidates = $baselineIndex[$key]

        # Get all parameter properties (excluding standard result columns)
        $standardProps = @('BenchmarkName', 'DotNetVersion', 'Method', 'Mean', 'Error',
                          'StdDev', 'Median', 'Ratio', 'Gen0', 'Gen1', 'Gen2',
                          'Allocated', 'AllocRatio', 'CodeSize', 'RatioSD')
        $newParams = $newResult.PSObject.Properties |
            Where-Object { $_.Name -notin $standardProps } |
            ForEach-Object { $_.Name }

        # Try to find exact match by all parameters
        foreach ($baselineResult in $baselineCandidates) {
            $allMatch = $true

            foreach ($paramName in $newParams) {
                $newValue = $newResult.$paramName
                $baselineValue = $baselineResult.$paramName

                # Parameters must match exactly (or both be null/empty)
                $paramMatch = ($newValue -eq $baselineValue) -or
                             ([string]::IsNullOrWhiteSpace($newValue) -and [string]::IsNullOrWhiteSpace($baselineValue))

                if (-not $paramMatch) {
                    $allMatch = $false
                    break
                }
            }

            if ($allMatch) {
                $matchingBaseline = $baselineResult
                break
            }
        }

        # Skip this comparison if no exact parameter match found
        if (-not $matchingBaseline) {
            continue
        }

        # Parse time values
        $baselineTime = Parse-TimeValue $matchingBaseline.Mean
        $newTime = Parse-TimeValue $newResult.Mean

        $timeChange = $null
        $timeChangePercent = $null
        if ($baselineTime -and $newTime -and $baselineTime -gt 0) {
            $timeChange = $newTime - $baselineTime
            $timeChangePercent = (($newTime - $baselineTime) / $baselineTime) * 100
        }

        # Parse memory values
        $baselineMemory = Parse-MemoryValue $matchingBaseline.Allocated
        $newMemory = Parse-MemoryValue $newResult.Allocated

        $memoryChange = $null
        $memoryChangePercent = $null
        if ($baselineMemory -and $newMemory -and $baselineMemory -gt 0) {
            $memoryChange = $newMemory - $baselineMemory
            $memoryChangePercent = (($newMemory - $baselineMemory) / $baselineMemory) * 100
        }

        $comparison = [PSCustomObject]@{
            BenchmarkName = $newResult.BenchmarkName
            Method = $newResult.Method
            BaselineVersion = $matchingBaseline.DotNetVersion
            NewVersion = $newResult.DotNetVersion
            BaselineTime = $matchingBaseline.Mean
            NewTime = $newResult.Mean
            TimeChangePercent = if ($timeChangePercent) { $timeChangePercent } else { $null }
            TimeIndicator = if ($timeChangePercent) { Get-ChangeIndicator $timeChangePercent } else { "" }
            BaselineMemory = $matchingBaseline.Allocated
            NewMemory = $newResult.Allocated
            MemoryChangePercent = if ($memoryChangePercent) { $memoryChangePercent } else { $null }
            MemoryIndicator = if ($memoryChangePercent) { Get-ChangeIndicator $memoryChangePercent $true } else { "" }
        }

        $comparisons += $comparison

        # Count improvements/regressions
        if ($timeChangePercent) {
            if ($timeChangePercent -lt -$MinimumChangePercent) { $improvements++ }
            elseif ($timeChangePercent -gt $MinimumChangePercent) { $regressions++ }
            else { $noChange++ }
        }
    }
}

Write-Host "Comparison Results:" -ForegroundColor Cyan
Write-Host "  Improvements: $improvements" -ForegroundColor Green
Write-Host "  Regressions: $regressions" -ForegroundColor Red
Write-Host "  No significant change: $noChange" -ForegroundColor Gray
Write-Host ""

# Ensure output directory exists
if ([System.IO.Path]::IsPathRooted($OutputPath)) {
    $outputDir = $OutputPath
} else {
    $outputDir = Join-Path $PSScriptRoot $OutputPath
}

if (-not (Test-Path $outputDir)) {
    New-Item -Path $outputDir -ItemType Directory -Force | Out-Null
}

# Export full comparison
$comparisonJsonPath = Join-Path $outputDir "comparison_results.json"
$comparisons | ConvertTo-Json -Depth 10 | Out-File $comparisonJsonPath -Encoding UTF8
Write-Host "✓ Full comparison saved: $comparisonJsonPath" -ForegroundColor Green

$comparisonCsvPath = Join-Path $outputDir "comparison_results.csv"
$comparisons | Export-Csv $comparisonCsvPath -NoTypeInformation -Encoding UTF8
Write-Host "✓ Full comparison CSV: $comparisonCsvPath" -ForegroundColor Green

# Export notable changes
$notableChanges = $comparisons | Where-Object {
    ($_.TimeChangePercent -and [Math]::Abs($_.TimeChangePercent) -ge $MinimumChangePercent) -or
    ($_.MemoryChangePercent -and [Math]::Abs($_.MemoryChangePercent) -ge $MinimumChangePercent)
} | Sort-Object TimeChangePercent

$notableChangesPath = Join-Path $outputDir "notable_changes.csv"
$notableChanges | Export-Csv $notableChangesPath -NoTypeInformation -Encoding UTF8
Write-Host "✓ Notable changes (≥$MinimumChangePercent%): $notableChangesPath" -ForegroundColor Green

# Show top improvements
Write-Host ""
Write-Host "Top 10 Performance Improvements:" -ForegroundColor Green
$topImprovements = $comparisons |
    Where-Object { $_.TimeChangePercent -lt 0 } |
    Sort-Object TimeChangePercent |
    Select-Object -First 10

foreach ($item in $topImprovements) {
    $changeStr = Format-PercentChange $item.TimeChangePercent
    Write-Host "  $($item.TimeIndicator) $($item.BenchmarkName)/$($item.Method): $changeStr" -ForegroundColor White
}

# Show top regressions
Write-Host ""
Write-Host "Top 10 Performance Regressions:" -ForegroundColor Red
$topRegressions = $comparisons |
    Where-Object { $_.TimeChangePercent -gt 0 } |
    Sort-Object TimeChangePercent -Descending |
    Select-Object -First 10

foreach ($item in $topRegressions) {
    $changeStr = Format-PercentChange $item.TimeChangePercent
    Write-Host "  $($item.TimeIndicator) $($item.BenchmarkName)/$($item.Method): $changeStr" -ForegroundColor White
}

Write-Host ""
Write-Host "Comparison complete!" -ForegroundColor Cyan
