<#
.SYNOPSIS
    Displays a live progress bar for running benchmarks

.DESCRIPTION
    This script reads the benchmark_progress.json file and displays a nice progress bar
    showing the current status of benchmark execution. Run this in a separate terminal
    while run_all_benchmarks.ps1 is running.

.EXAMPLE
    .\show_benchmark_progress.ps1
    Shows live progress bar

.EXAMPLE
    .\show_benchmark_progress.ps1 -RefreshInterval 0.5
    Updates progress twice per second
#>

[CmdletBinding()]
param(
    [Parameter()]
    [double]$RefreshInterval = 0.25  # Refresh 4 times per second
)

$progressFile = Join-Path $PSScriptRoot "benchmark_progress.json"

function Get-ProgressBar {
    param(
        [int]$Current,
        [int]$Total,
        [int]$Width = 50
    )

    $percent = if ($Total -gt 0) { [Math]::Min(100, ($Current / $Total) * 100) } else { 0 }
    $filled = [Math]::Floor(($percent / 100) * $Width)
    $empty = $Width - $filled

    $filledBar = "█" * $filled
    $emptyBar = "░" * $empty
    $percentStr = $percent.ToString("0.0").PadLeft(5)

    return @{
        Filled = $filledBar
        Empty = $emptyBar
        Percent = $percentStr
    }
}

function Format-Duration {
    param([TimeSpan]$Duration)

    if ($Duration.TotalHours -ge 1) {
        return $Duration.ToString("hh\:mm\:ss")
    }
    elseif ($Duration.TotalMinutes -ge 1) {
        return $Duration.ToString("mm\:ss")
    }
    else {
        return $Duration.ToString("ss\.fff") + "s"
    }
}

# Check if progress file exists
if (-not (Test-Path $progressFile)) {
    Write-Host "Progress file not found. Is run_all_benchmarks.ps1 running?" -ForegroundColor Yellow
    Write-Host "Waiting for progress file to appear..." -ForegroundColor Cyan

    # Wait for file to appear
    while (-not (Test-Path $progressFile)) {
        Start-Sleep -Milliseconds 500
    }

    Start-Sleep -Milliseconds 500  # Give it a moment to be written
}

Clear-Host
Write-Host "Benchmark Progress Monitor" -ForegroundColor Cyan
Write-Host ("=" * 80) -ForegroundColor Cyan
Write-Host ""

$lastCurrent = -1
$lastUpdate = [DateTime]::MinValue
$timeUpdateInterval = 10  # Update time every 1 second

# Hide cursor
[Console]::CursorVisible = $false

try {
    while ($true) {
        if (Test-Path $progressFile) {
            try {
                $progress = Get-Content $progressFile -Raw | ConvertFrom-Json

                # Calculate elapsed time
                $startTime = [DateTime]::Parse($progress.StartTime)
                $elapsed = (Get-Date) - $startTime

                # Estimate remaining time
                if ($progress.Current -gt 0 -and $progress.Current -lt $progress.Total) {
                    $avgTimePerBenchmark = $elapsed.TotalSeconds / $progress.Current
                    $remaining = [TimeSpan]::FromSeconds($avgTimePerBenchmark * ($progress.Total - $progress.Current))
                    $eta = "ETA: " + (Format-Duration $remaining)
                }
                elseif ($progress.IsComplete) {
                    $eta = "Complete!"
                }
                else {
                    $eta = "Calculating..."
                }

                # Update display if progress changed OR time update interval elapsed
                $now = Get-Date
                $shouldUpdate = $progress.Current -ne $lastCurrent -or ($now - $lastUpdate).TotalSeconds -ge $timeUpdateInterval

                if ($shouldUpdate) {
                    $lastCurrent = $progress.Current
                    $lastUpdate = $now

                    # Clear screen and redraw
                    Clear-Host
                    Write-Host "Benchmark Progress Monitor" -ForegroundColor Cyan
                    Write-Host ("=" * 80) -ForegroundColor Cyan
                    Write-Host ""

                    # Display progress
                    $progressBar = Get-ProgressBar -Current $progress.Current -Total $progress.Total -Width 60
                    Write-Host "Progress: [" -NoNewline
                    Write-Host $progressBar.Filled -NoNewline -ForegroundColor Green
                    Write-Host $progressBar.Empty -NoNewline
                    Write-Host "] $($progressBar.Percent)%"

                    Write-Host ""
                    Write-Host "Status   : $($progress.Status.PadRight(20))" -ForegroundColor $(
                        switch ($progress.Status) {
                            "Running" { "Yellow" }
                            "Complete" { "Green" }
                            default { "White" }
                        }
                    )

                    Write-Host "Current  : $($progress.CurrentBenchmark.PadRight(50))" -ForegroundColor Cyan

                    Write-Host ""
                    Write-Host "Count    : $($progress.Current) / $($progress.Total)"

                    Write-Host "Succeeded: " -NoNewline
                    Write-Host $progress.Succeeded.ToString().PadRight(10) -NoNewline -ForegroundColor Green
                    Write-Host "Failed (runtime): " -NoNewline
                    Write-Host $progress.Failed.ToString().PadRight(5) -NoNewline -ForegroundColor $(if ($progress.Failed -gt 0) { "Red" } else { "White" })
                    Write-Host "Failed (build): " -NoNewline
                    $buildFailed = if ($progress.BuildFailed) { $progress.BuildFailed } else { 0 }
                    Write-Host $buildFailed.ToString() -ForegroundColor $(if ($buildFailed -gt 0) { "Red" } else { "White" })

                    Write-Host ""
                    Write-Host "Elapsed  : $(Format-Duration $elapsed)"

                    Write-Host "$eta" -ForegroundColor $(if ($progress.IsComplete) { "Green" } else { "Yellow" })

                    # Show failed benchmarks if any
                    $buildFailed = if ($progress.BuildFailed) { $progress.BuildFailed } else { 0 }
                    if ($buildFailed -gt 0 -and $progress.BuildFailedBenchmarks) {
                        Write-Host ""
                        Write-Host "Build failures:" -ForegroundColor Red
                        foreach ($failed in $progress.BuildFailedBenchmarks) {
                            Write-Host "  • $failed" -ForegroundColor Red
                        }
                    }

                    if ($progress.Failed -gt 0 -and $progress.FailedBenchmarks) {
                        Write-Host ""
                        Write-Host "Runtime failures:" -ForegroundColor Red
                        foreach ($failed in $progress.FailedBenchmarks) {
                            Write-Host "  • $failed" -ForegroundColor Red
                        }
                    }

                    # Exit if complete
                    if ($progress.IsComplete) {
                        Write-Host ""
                        Write-Host ""
                        Write-Host "All benchmarks completed!" -ForegroundColor Green
                        Write-Host ""
                        break
                    }
                }
            }
            catch {
                # File might be locked during write, just skip this iteration
            }
        }

        Start-Sleep -Seconds $RefreshInterval
    }
}
finally {
    # Clean up - show cursor
    [Console]::CursorVisible = $true
}
