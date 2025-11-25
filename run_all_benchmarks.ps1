<#
.SYNOPSIS
    Runs all benchmarks and updates their README files

.DESCRIPTION
    This script runs all benchmarks in the repository and updates their README.md files
    with the latest results. Useful for regenerating all results on new hardware.

    When projects target multiple frameworks (e.g., net9.0;net10.0), BenchmarkDotNet
    will automatically run against all frameworks and compare the results.

.PARAMETER DryRun
    If specified, shows what would be run without actually executing benchmarks.

.PARAMETER Framework
    Optionally specify a framework to run (e.g., 'net10.0'). If not specified and the
    project targets multiple frameworks, BenchmarkDotNet will run against all of them.

.PARAMETER Skip
    Comma-separated list of benchmark names to skip.

.EXAMPLE
    .\run_all_benchmarks.ps1
    Runs all benchmarks and updates README files

.EXAMPLE
    .\run_all_benchmarks.ps1 -Framework net10.0
    Runs all benchmarks specifically on .NET 10

.EXAMPLE
    .\run_all_benchmarks.ps1 -Skip "BubbleSort,SlowBenchmark"
    Runs all benchmarks except the specified ones
#>

[CmdletBinding()]
param(
    [Parameter()]
    [switch]$DryRun,

    [Parameter()]
    [string]$Framework,

    [Parameter()]
    [string]$Skip
)

$ErrorActionPreference = 'Stop'

# Progress file for tracking
$progressFile = Join-Path $PSScriptRoot "benchmark_progress.json"

# Parse skip list
$skipList = @()
if ($Skip) {
    $skipList = $Skip -split ',' | ForEach-Object { $_.Trim() }
}

# Get all benchmark directories (directories with .csproj files, excluding tools)
$benchmarkDirs = Get-ChildItem -Path $PSScriptRoot -Directory |
    Where-Object {
        $_.Name -ne 'tools' -and
        (Test-Path (Join-Path $_.FullName "*.csproj"))
    }

if ($skipList.Count -gt 0) {
    Write-Host "Skipping: $($skipList -join ', ')" -ForegroundColor Yellow
    $benchmarkDirs = $benchmarkDirs | Where-Object { $_.Name -notin $skipList }
}

$total = $benchmarkDirs.Count
Write-Host "Found $total benchmarks to run" -ForegroundColor Cyan

# Initialize progress file
$progressData = @{
    Total = $total
    Current = 0
    CurrentBenchmark = ""
    Succeeded = 0
    Failed = 0
    FailedBenchmarks = @()
    StartTime = (Get-Date).ToString("o")
    Status = "Starting"
    IsComplete = $false
}
$progressData | ConvertTo-Json | Set-Content $progressFile

if ($DryRun) {
    Write-Host ""
    Write-Host "Dry run - would run the following benchmarks:" -ForegroundColor Yellow
    foreach ($dir in $benchmarkDirs) {
        Write-Host "  - $($dir.Name)"
    }
    Write-Host ""
    Write-Host "Run without -DryRun to execute." -ForegroundColor Yellow
    exit 0
}

Write-Host ""

$current = 0
$succeeded = 0
$failed = 0
$failedBenchmarks = @()

$startTime = Get-Date

foreach ($dir in $benchmarkDirs) {
    $current++
    $benchmarkName = $dir.Name

    Write-Host "[$current/$total] Running $benchmarkName..." -ForegroundColor White

    # Update progress file
    $progressData.Current = $current
    $progressData.CurrentBenchmark = $benchmarkName
    $progressData.Status = "Running"
    $progressData.Succeeded = $succeeded
    $progressData.Failed = $failed
    $progressData | ConvertTo-Json | Set-Content $progressFile

    Push-Location $dir.FullName
    try {
        # Build the dotnet run command
        $runArgs = @('run', '-c', 'Release')

        if ($Framework) {
            $runArgs += '--framework'
            $runArgs += $Framework
        }

        # Run benchmark
        $output = & dotnet @runArgs 2>&1
        $exitCode = $LASTEXITCODE

        if ($exitCode -ne 0) {
            throw "Benchmark failed with exit code $exitCode"
        }

        # Update README
        & "$PSScriptRoot\update_results.ps1" .

        Write-Host "  ✓ Completed and README updated" -ForegroundColor Green
        $succeeded++

        # Update progress file
        $progressData.Succeeded = $succeeded
        $progressData | ConvertTo-Json | Set-Content $progressFile
    }
    catch {
        Write-Host "  ✗ ERROR: $_" -ForegroundColor Red
        $failed++
        $failedBenchmarks += $benchmarkName

        # Update progress file
        $progressData.Failed = $failed
        $progressData.FailedBenchmarks = $failedBenchmarks
        $progressData | ConvertTo-Json | Set-Content $progressFile
    }
    finally {
        Pop-Location
    }

    Write-Host ""
}

$endTime = Get-Date
$duration = $endTime - $startTime

# Mark progress as complete
$progressData.Current = $total
$progressData.CurrentBenchmark = "Complete"
$progressData.Status = "Complete"
$progressData.IsComplete = $true
$progressData.EndTime = $endTime.ToString("o")
$progressData.Duration = $duration.ToString()
$progressData | ConvertTo-Json | Set-Content $progressFile

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  Total: $total"
Write-Host "  Succeeded: $succeeded" -ForegroundColor Green
Write-Host "  Failed: $failed" -ForegroundColor $(if ($failed -gt 0) { "Red" } else { "Green" })
Write-Host "  Duration: $($duration.ToString('hh\:mm\:ss'))"

if ($failed -gt 0) {
    Write-Host ""
    Write-Host "Failed benchmarks:" -ForegroundColor Red
    foreach ($name in $failedBenchmarks) {
        Write-Host "  - $name" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "All benchmarks completed!" -ForegroundColor $(if ($failed -eq 0) { "Green" } else { "Yellow" })
