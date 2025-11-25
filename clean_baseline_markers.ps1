<#
.SYNOPSIS
    Cleans markdown bold markers (**) from baseline data files in-place.

.DESCRIPTION
    This script removes ** markdown markers from the baseline JSON and CSV files
    without regenerating the actual benchmark data, preserving the original baseline values.
#>

param(
    [string]$JsonPath = ".\baseline_results.json",
    [string]$CsvPath = ".\baseline_results.csv"
)

Write-Host "Cleaning baseline data files..." -ForegroundColor Cyan

# Clean JSON file
if (Test-Path $JsonPath) {
    Write-Host "Cleaning $JsonPath..." -ForegroundColor Gray
    $json = Get-Content $JsonPath -Raw
    $cleanedJson = $json -replace '\*\*', ''
    $cleanedJson | Set-Content $JsonPath -NoNewline
    Write-Host "  ✓ JSON file cleaned" -ForegroundColor Green
}

# Clean CSV file
if (Test-Path $CsvPath) {
    Write-Host "Cleaning $CsvPath..." -ForegroundColor Gray
    $csv = Get-Content $CsvPath -Raw
    $cleanedCsv = $csv -replace '\*\*', ''
    $cleanedCsv | Set-Content $CsvPath -NoNewline
    Write-Host "  ✓ CSV file cleaned" -ForegroundColor Green
}

Write-Host ""
Write-Host "Baseline files cleaned successfully!" -ForegroundColor Green
Write-Host "Markdown bold markers (**) have been removed without changing the actual data."
