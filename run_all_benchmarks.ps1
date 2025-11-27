<#
.SYNOPSIS
    Runs all benchmarks and updates their README files

.DESCRIPTION
    This script runs all benchmarks in the repository and updates their README.md files
    with the latest results. Useful for regenerating all results on new hardware.

    When projects target multiple frameworks (e.g., net9.0;net10.0), BenchmarkDotNet
    will automatically run against all frameworks and compare the results.

    The script maintains a skip list (benchmark_skiplist.txt) that tracks completed benchmarks.
    As each benchmark completes successfully, it's added to the skip list. If the script is
    interrupted, you can restart it and it will skip already-completed benchmarks, resuming
    from where it left off.

.PARAMETER DryRun
    If specified, shows what would be run without actually executing benchmarks.

.PARAMETER Framework
    Optionally specify a framework to run (e.g., 'net10.0'). If not specified and the
    project targets multiple frameworks, BenchmarkDotNet will run against all of them.

.PARAMETER Skip
    Comma-separated list of additional benchmark names to skip (beyond those in the skip list file).

.EXAMPLE
    .\run_all_benchmarks.ps1
    Runs all benchmarks and updates README files, skipping any already-completed benchmarks

.EXAMPLE
    .\run_all_benchmarks.ps1 -Framework net10.0
    Runs all benchmarks specifically on .NET 10

.EXAMPLE
    .\run_all_benchmarks.ps1 -Skip "BubbleSort,SlowBenchmark"
    Runs all benchmarks except the specified ones (and those in the skip list)

.NOTES
    To start fresh and re-run all benchmarks, delete the benchmark_skiplist.txt file.
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

# Skip list file for tracking completed benchmarks
$skipListFile = Join-Path $PSScriptRoot "benchmark_skiplist.txt"

# Helper function to write progress with retry on file lock
function Write-ProgressFile {
    param(
        [string]$Path,
        [hashtable]$Data,
        [int]$MaxRetries = 5,
        [int]$DelayMs = 100
    )

    $attempt = 0
    while ($attempt -lt $MaxRetries) {
        try {
            $Data | ConvertTo-Json | Set-Content $Path -ErrorAction Stop
            return
        }
        catch {
            $attempt++
            if ($attempt -ge $MaxRetries) {
                Write-Warning "Failed to write progress file after $MaxRetries attempts: $_"
                return
            }
            Start-Sleep -Milliseconds $DelayMs
        }
    }
}

# Helper function to add a benchmark to the skip list with retry on file lock
function Add-ToSkipList {
    param(
        [string]$Path,
        [string]$BenchmarkName,
        [int]$MaxRetries = 5,
        [int]$DelayMs = 100
    )

    $attempt = 0
    while ($attempt -lt $MaxRetries) {
        try {
            # Read existing content, add new entry if not present, sort, and write back
            $existing = @()
            if (Test-Path $Path) {
                $existing = Get-Content $Path | Where-Object { $_.Trim() -ne '' }
            }
            
            if ($BenchmarkName -notin $existing) {
                $existing += $BenchmarkName
                $existing | Sort-Object | Out-File $Path -Encoding utf8 -ErrorAction Stop
            }
            return
        }
        catch {
            $attempt++
            if ($attempt -ge $MaxRetries) {
                Write-Warning "Failed to update skip list after $MaxRetries attempts: $_"
                return
            }
            Start-Sleep -Milliseconds $DelayMs
        }
    }
}

# Load skip list from file (benchmarks already completed)
$fileSkipList = @()
if (Test-Path $skipListFile) {
    $fileSkipList = Get-Content $skipListFile | Where-Object { $_.Trim() -ne '' } | ForEach-Object { $_.Trim() }
    Write-Host "Loaded skip list with $($fileSkipList.Count) already-completed benchmarks" -ForegroundColor Cyan
}

# Parse skip list from command line parameter
$skipList = @()
if ($Skip) {
    $skipList = $Skip -split ',' | ForEach-Object { $_.Trim() }
}

# Combine both skip lists
$combinedSkipList = @($fileSkipList) + @($skipList) | Select-Object -Unique

# Get all benchmark directories (directories with .csproj files, excluding tools)
$benchmarkDirs = Get-ChildItem -Path $PSScriptRoot -Directory |
    Where-Object {
        $_.Name -ne 'tools' -and
        (Test-Path (Join-Path $_.FullName "*.csproj"))
    }

if ($combinedSkipList.Count -gt 0) {
    $skippedCount = ($benchmarkDirs | Where-Object { $_.Name -in $combinedSkipList }).Count
    Write-Host "Skipping $skippedCount already-completed benchmarks" -ForegroundColor Yellow
    if ($skipList.Count -gt 0) {
        Write-Host "Additional command-line skips: $($skipList -join ', ')" -ForegroundColor Yellow
    }
    $benchmarkDirs = $benchmarkDirs | Where-Object { $_.Name -notin $combinedSkipList }
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
    BuildFailed = 0
    BuildFailedBenchmarks = @()
    StartTime = (Get-Date).ToString("o")
    Status = "Starting"
    IsComplete = $false
}
Write-ProgressFile -Path $progressFile -Data $progressData

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
$buildFailed = 0
$buildFailedBenchmarks = @()

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
    $progressData.BuildFailed = $buildFailed
    Write-ProgressFile -Path $progressFile -Data $progressData

    Push-Location $dir.FullName
    try {
        # Build the dotnet run command
        $runArgs = @('run', '-c', 'Release')

        # If no framework specified, default to net10.0 (BenchmarkDotNet will run all target frameworks)
        if ($Framework) {
            $runArgs += '--framework'
            $runArgs += $Framework
        } else {
            $runArgs += '--framework'
            $runArgs += 'net10.0'
        }

        # Run benchmark (show output to console and capture it)
        $capturedOutput = New-Object System.Collections.ArrayList
        $output = & dotnet @runArgs 2>&1 | ForEach-Object {
            [void]$capturedOutput.Add($_)
            Write-Host $_
        }
        $exitCode = $LASTEXITCODE

        if ($exitCode -ne 0) {
            # Check if it's a build failure
            $outputText = $capturedOutput -join "`n"
            $isBuildFailure = $outputText -match "Build FAILED" -or $outputText -match "error CS\d+" -or $outputText -match "error MSB\d+"

            if ($isBuildFailure) {
                throw "Build failed"
            } else {
                throw "Benchmark failed with exit code $exitCode"
            }
        }        # Update README
        & "$PSScriptRoot\update_results.ps1" .

        Write-Host "  ✓ Completed and README updated" -ForegroundColor Green
        $succeeded++

        # Add to skip list so we can resume from here if interrupted
        Add-ToSkipList -Path $skipListFile -BenchmarkName $benchmarkName

        # Update progress file
        $progressData.Succeeded = $succeeded
        $progressData.Failed = $failed
        $progressData.BuildFailed = $buildFailed
        Write-ProgressFile -Path $progressFile -Data $progressData
    }
    catch {
        $errorMessage = $_.Exception.Message

        if ($errorMessage -like "*Build failed*") {
            Write-Host "  ✗ BUILD FAILED" -ForegroundColor Red
            $buildFailed++
            $buildFailedBenchmarks += $benchmarkName
        } else {
            Write-Host "  ✗ ERROR: $errorMessage" -ForegroundColor Red
            $failed++
            $failedBenchmarks += $benchmarkName
        }

        # Update progress file
        $progressData.Failed = $failed
        $progressData.FailedBenchmarks = $failedBenchmarks
        $progressData.BuildFailed = $buildFailed
        $progressData.BuildFailedBenchmarks = $buildFailedBenchmarks
        Write-ProgressFile -Path $progressFile -Data $progressData
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
Write-ProgressFile -Path $progressFile -Data $progressData

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  Total: $total"
Write-Host "  Succeeded: $succeeded" -ForegroundColor Green
Write-Host "  Failed (runtime): $failed" -ForegroundColor $(if ($failed -gt 0) { "Red" } else { "Green" })
Write-Host "  Failed (build): $buildFailed" -ForegroundColor $(if ($buildFailed -gt 0) { "Red" } else { "Green" })
Write-Host "  Duration: $($duration.ToString('hh\:mm\:ss'))"

if ($buildFailed -gt 0) {
    Write-Host ""
    Write-Host "Build failures:" -ForegroundColor Red
    foreach ($name in $buildFailedBenchmarks) {
        Write-Host "  - $name" -ForegroundColor Red
    }
}

if ($failed -gt 0) {
    Write-Host ""
    Write-Host "Runtime failures:" -ForegroundColor Red
    foreach ($name in $failedBenchmarks) {
        Write-Host "  - $name" -ForegroundColor Red
    }
}

$totalFailed = $failed + $buildFailed
Write-Host ""
Write-Host "All benchmarks completed!" -ForegroundColor $(if ($totalFailed -eq 0) { "Green" } else { "Yellow" })
