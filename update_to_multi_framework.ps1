<#
.SYNOPSIS
    Updates all benchmark projects to run against both .NET 9 and .NET 10

.DESCRIPTION
    This script updates all *.csproj files to use TargetFrameworks (plural) with both net9.0 and net10.0.
    This allows BenchmarkDotNet to run the same benchmarks against both frameworks and compare results.

    Optionally runs all benchmarks and updates README files with the new results.

.PARAMETER RunBenchmarks
    If specified, runs all benchmarks after updating the project files.

.PARAMETER DryRun
    If specified, shows what would be changed without making any modifications.

.EXAMPLE
    .\update_to_multi_framework.ps1
    Updates all project files to target both net9.0 and net10.0

.EXAMPLE
    .\update_to_multi_framework.ps1 -RunBenchmarks
    Updates project files and runs all benchmarks

.EXAMPLE
    .\update_to_multi_framework.ps1 -DryRun
    Shows what would be changed without modifying files
#>

[CmdletBinding()]
param(
    [Parameter()]
    [switch]$RunBenchmarks,

    [Parameter()]
    [switch]$DryRun
)

$ErrorActionPreference = 'Stop'

function Update-ProjectFile {
    param(
        [string]$ProjectPath,
        [bool]$DryRun
    )

    $content = Get-Content $ProjectPath -Raw

    # Check if already using TargetFrameworks (plural)
    if ($content -match '<TargetFrameworks>') {
        Write-Host "  Already uses TargetFrameworks (plural), checking values..." -ForegroundColor Yellow

        if ($content -match '<TargetFrameworks>net9\.0;net10\.0</TargetFrameworks>') {
            Write-Host "  Already configured for net9.0;net10.0" -ForegroundColor Green
            return $false
        } else {
            # Update existing TargetFrameworks
            $newContent = $content -replace '<TargetFrameworks>[^<]+</TargetFrameworks>', '<TargetFrameworks>net9.0;net10.0</TargetFrameworks>'
        }
    }
    # Check for single TargetFramework
    elseif ($content -match '<TargetFramework>([^<]+)</TargetFramework>') {
        $currentFramework = $matches[1]
        Write-Host "  Current: $currentFramework -> net9.0;net10.0" -ForegroundColor Cyan

        # Replace TargetFramework (singular) with TargetFrameworks (plural)
        $newContent = $content -replace '<TargetFramework>[^<]+</TargetFramework>', '<TargetFrameworks>net9.0;net10.0</TargetFrameworks>'
    }
    else {
        Write-Host "  No TargetFramework found, skipping" -ForegroundColor Yellow
        return $false
    }

    if (-not $DryRun) {
        Set-Content $ProjectPath -Value $newContent -NoNewline
        Write-Host "  Updated!" -ForegroundColor Green
    } else {
        Write-Host "  Would update (dry run)" -ForegroundColor Magenta
    }

    return $true
}

# Get all benchmark projects
$projects = Get-ChildItem -Path $PSScriptRoot -Filter "*.csproj" -Recurse |
    Where-Object { $_.DirectoryName -ne "$PSScriptRoot\tools" }

Write-Host "Found $($projects.Count) benchmark projects" -ForegroundColor Cyan
Write-Host ""

$updatedCount = 0

foreach ($project in $projects) {
    $benchmarkName = Split-Path $project.DirectoryName -Leaf
    Write-Host "[$benchmarkName]" -ForegroundColor White

    $wasUpdated = Update-ProjectFile -ProjectPath $project.FullName -DryRun $DryRun

    if ($wasUpdated) {
        $updatedCount++
    }

    Write-Host ""
}

Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  Total projects: $($projects.Count)"
Write-Host "  Updated: $updatedCount"

if ($DryRun) {
    Write-Host ""
    Write-Host "This was a dry run. Run without -DryRun to apply changes." -ForegroundColor Yellow
    exit 0
}

if ($updatedCount -eq 0) {
    Write-Host ""
    Write-Host "No projects needed updating." -ForegroundColor Green
    exit 0
}

# Optionally run benchmarks
if ($RunBenchmarks) {
    Write-Host ""
    Write-Host "Running all benchmarks..." -ForegroundColor Cyan
    Write-Host ""

    $benchmarkDirs = Get-ChildItem -Path $PSScriptRoot -Directory |
        Where-Object {
            $_.Name -ne 'tools' -and
            (Test-Path (Join-Path $_.FullName "*.csproj"))
        }

    $total = $benchmarkDirs.Count
    $current = 0

    foreach ($dir in $benchmarkDirs) {
        $current++
        $benchmarkName = $dir.Name

        Write-Host "[$current/$total] Running $benchmarkName..." -ForegroundColor White

        Push-Location $dir.FullName
        try {
            # Run benchmark
            dotnet run -c Release --framework net10.0 2>&1 | Out-Null

            # Update README
            & "$PSScriptRoot\update_results.ps1" .

            Write-Host "  Completed and README updated" -ForegroundColor Green
        }
        catch {
            Write-Host "  ERROR: $_" -ForegroundColor Red
        }
        finally {
            Pop-Location
        }

        Write-Host ""
    }

    Write-Host "All benchmarks completed!" -ForegroundColor Green
}
else {
    Write-Host ""
    Write-Host "Project files updated. Run with -RunBenchmarks to execute all benchmarks." -ForegroundColor Yellow
}
