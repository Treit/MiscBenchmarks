<#
.SYNOPSIS
    Updates all benchmark projects to target only .NET 10.

.DESCRIPTION
    This script updates all *.csproj files to use TargetFramework (singular) with net10.0.
    It also removes [SimpleJob] attributes referencing older runtimes from .cs files,
    keeping only the Net10_0 job.

.PARAMETER DryRun
    If specified, shows what would be changed without making any modifications.

.EXAMPLE
    .\update_to_net10_only.ps1

.EXAMPLE
    .\update_to_net10_only.ps1 -DryRun
#>

[CmdletBinding()]
param(
    [Parameter()]
    [switch]$DryRun
)

$ErrorActionPreference = 'Stop'

$csprojUpdated = 0
$csUpdated = 0
$csprojSkipped = 0

$projects = Get-ChildItem -Path $PSScriptRoot -Filter "*.csproj" -Recurse |
    Where-Object { $_.FullName -notmatch '\\bin\\|\\obj\\' }

Write-Host "Found $($projects.Count) csproj files" -ForegroundColor Cyan
Write-Host ""

foreach ($project in $projects) {
    $content = Get-Content $project.FullName -Raw
    $newContent = $content
    $changed = $false

    if ($content -match '<TargetFrameworks>[^<]+</TargetFrameworks>') {
        $newContent = $newContent -replace '<TargetFrameworks>[^<]+</TargetFrameworks>', '<TargetFramework>net10.0</TargetFramework>'
        $changed = $true
    }
    elseif ($content -match '<TargetFramework>([^<]+)</TargetFramework>') {
        $current = $matches[1]
        if ($current -ne 'net10.0') {
            $newContent = $newContent -replace '<TargetFramework>[^<]+</TargetFramework>', '<TargetFramework>net10.0</TargetFramework>'
            $changed = $true
        }
    }

    if ($changed) {
        $rel = $project.FullName.Substring($PSScriptRoot.Length + 1)
        if ($DryRun) {
            Write-Host "  [csproj] Would update: $rel" -ForegroundColor Magenta
        }
        else {
            Set-Content $project.FullName -Value $newContent -NoNewline
            Write-Host "  [csproj] Updated: $rel" -ForegroundColor Green
        }
        $csprojUpdated++
    }
    else {
        $csprojSkipped++
    }
}

$csFiles = Get-ChildItem -Path $PSScriptRoot -Filter "*.cs" -Recurse |
    Where-Object { $_.FullName -notmatch '\\bin\\|\\obj\\' }

Write-Host ""
Write-Host "Scanning $($csFiles.Count) .cs files for old SimpleJob attributes..." -ForegroundColor Cyan
Write-Host ""

$oldMonikers = @(
    'RuntimeMoniker\.Net60',
    'RuntimeMoniker\.Net70',
    'RuntimeMoniker\.Net80',
    'RuntimeMoniker\.Net90'
)

$pattern = '(?m)^\s*\[SimpleJob\((' + ($oldMonikers -join '|') + ')[^)]*\)\]\r?\n'

foreach ($csFile in $csFiles) {
    $content = Get-Content $csFile.FullName -Raw
    if ($content -match ($oldMonikers -join '|')) {
        $newContent = $content -replace $pattern, ''

        if ($newContent -ne $content) {
            $rel = $csFile.FullName.Substring($PSScriptRoot.Length + 1)
            if ($DryRun) {
                Write-Host "  [cs] Would update: $rel" -ForegroundColor Magenta
            }
            else {
                Set-Content $csFile.FullName -Value $newContent -NoNewline
                Write-Host "  [cs] Updated: $rel" -ForegroundColor Green
            }
            $csUpdated++
        }
    }
}

Write-Host ""
Write-Host "Summary:" -ForegroundColor Cyan
Write-Host "  csproj updated: $csprojUpdated"
Write-Host "  csproj skipped (already net10.0): $csprojSkipped"
Write-Host "  .cs files updated (removed old SimpleJob): $csUpdated"

if ($DryRun) {
    Write-Host ""
    Write-Host "This was a dry run. Run without -DryRun to apply changes." -ForegroundColor Yellow
}
