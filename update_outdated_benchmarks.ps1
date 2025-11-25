<#
.SYNOPSIS
    Re-runs benchmarks that are not currently on .NET 10.0.0

.DESCRIPTION
    This script identifies benchmarks that haven't been run on .NET 10 yet
    and re-runs them, updating their README.md files with the new results.
#>

param(
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

Write-Host "Checking for benchmarks not on .NET 10.0.0..." -ForegroundColor Cyan
Write-Host ""

# Extract current results to find non-.NET 10 benchmarks
$tempPath = Join-Path $env:TEMP "BenchmarkCheck_$(Get-Random)"
New-Item -ItemType Directory -Path $tempPath -Force | Out-Null

& "$PSScriptRoot\extract_baseline_results.ps1" -OutputPath $tempPath | Out-Null

$data = Import-Csv (Join-Path $tempPath "baseline_results.csv")
$outdatedBenchmarks = $data |
    Where-Object { $_.DotNetVersion -ne '10.0.0' } |
    Select-Object -Property BenchmarkName -Unique |
    Sort-Object BenchmarkName

Remove-Item -Path $tempPath -Recurse -Force

if ($outdatedBenchmarks.Count -eq 0) {
    Write-Host "✓ All benchmarks are already on .NET 10.0.0!" -ForegroundColor Green
    exit 0
}

Write-Host "Found $($outdatedBenchmarks.Count) benchmarks not on .NET 10.0.0:" -ForegroundColor Yellow
Write-Host ""

$outdatedBenchmarks | ForEach-Object { Write-Host "  - $($_.BenchmarkName)" -ForegroundColor Gray }

Write-Host ""

if ($DryRun) {
    Write-Host "Dry run complete. Use without -DryRun to update these benchmarks." -ForegroundColor Cyan
    exit 0
}

# Confirm with user
Write-Host "This will run $($outdatedBenchmarks.Count) benchmarks. Continue? (Y/N): " -ForegroundColor Yellow -NoNewline
$response = Read-Host
if ($response -ne 'Y' -and $response -ne 'y') {
    Write-Host "Cancelled." -ForegroundColor Red
    exit 0
}

Write-Host ""
Write-Host "Running outdated benchmarks..." -ForegroundColor Cyan
Write-Host ""

$successCount = 0
$failCount = 0
$skippedCount = 0

foreach ($benchmark in $outdatedBenchmarks) {
    $name = $benchmark.BenchmarkName
    $benchmarkPath = Join-Path $PSScriptRoot $name

    if (-not (Test-Path $benchmarkPath)) {
        Write-Host "⚠ Skipping $name (directory not found)" -ForegroundColor Yellow
        $skippedCount++
        continue
    }

    Write-Host "Running: $name" -ForegroundColor Cyan

    try {
        Push-Location $benchmarkPath

        # Run the benchmark and update README
        dotnet run -c Release

        if ($LASTEXITCODE -eq 0) {
            # Update the README with the results
            & "$PSScriptRoot\update_results.ps1" .

            if ($LASTEXITCODE -eq 0) {
                Write-Host "  ✓ $name completed and README updated" -ForegroundColor Green
                $successCount++
            } else {
                Write-Host "  ⚠ $name completed but README update failed" -ForegroundColor Yellow
                $successCount++
            }
        } else {
            Write-Host "  ✗ $name failed (exit code: $LASTEXITCODE)" -ForegroundColor Red
            $failCount++
        }
    }
    catch {
        Write-Host "  ✗ $name error: $_" -ForegroundColor Red
        $failCount++
    }
    finally {
        Pop-Location
    }

    Write-Host ""
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  ✓ Success: $successCount" -ForegroundColor Green
Write-Host "  ✗ Failed: $failCount" -ForegroundColor Red
Write-Host "  ⚠ Skipped: $skippedCount" -ForegroundColor Yellow
Write-Host "========================================" -ForegroundColor Cyan

if ($successCount -gt 0) {
    Write-Host ""
    Write-Host "Benchmarks updated successfully!" -ForegroundColor Green
    Write-Host "Run .\compare_with_baseline.ps1 to see the changes." -ForegroundColor Cyan
}
