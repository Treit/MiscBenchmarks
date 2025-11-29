#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Generate .NET 9 vs .NET 10 comparison report in one step.

.DESCRIPTION
    Extracts results from README files, runs the comparison analysis, and generates the HTML report.

.EXAMPLE
    .\generate_net9_vs_net10_full_report.ps1
#>

param()

Write-Host "=== .NET 9 vs .NET 10 Benchmark Comparison Report Generator ===" -ForegroundColor Cyan
Write-Host ""

# Step 1: Extract results from README files
Write-Host "[Step 1/3] Extracting results from README files..." -ForegroundColor Yellow
& "$PSScriptRoot\extract_readme_results.ps1"

if ($LASTEXITCODE -ne 0) {
    Write-Host "`nExtraction failed. Exiting." -ForegroundColor Red
    exit 1
}

Write-Host ""

# Step 2: Run comparison
Write-Host "[Step 2/3] Running comparison analysis..." -ForegroundColor Yellow
& "$PSScriptRoot\compare_net9_vs_net10.ps1"

if ($LASTEXITCODE -ne 0) {
    Write-Host "`nComparison failed. Exiting." -ForegroundColor Red
    exit 1
}

Write-Host ""

# Step 3: Generate HTML report
Write-Host "[Step 3/3] Generating HTML report..." -ForegroundColor Yellow
& "$PSScriptRoot\generate_net9_vs_net10_report.ps1"

if ($LASTEXITCODE -ne 0) {
    Write-Host "`nReport generation failed. Exiting." -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "=== Done! ===" -ForegroundColor Green
