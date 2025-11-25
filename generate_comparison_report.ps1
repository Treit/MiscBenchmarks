#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Generates an HTML table report showing all .NET 10 benchmark comparisons.

.DESCRIPTION
    Creates a sortable HTML table with all benchmark results showing performance and memory changes.

.PARAMETER ComparisonPath
    Path to the comparison JSON file. Defaults to "comparison_results.json".

.PARAMETER OutputPath
    Path where the HTML report will be saved. Defaults to "comparison_report.html".

.EXAMPLE
    .\generate_comparison_report.ps1
    .\generate_comparison_report.ps1 -ComparisonPath ".\comparison_results.json" -OutputPath ".\report.html"
#>

param(
    [string]$ComparisonPath = ".\comparison_results.json",
    [string]$OutputPath = ".\comparison_report.html"
)

if (-not (Test-Path $ComparisonPath)) {
    Write-Host "Error: Comparison file not found at $ComparisonPath" -ForegroundColor Red
    Write-Host "Please run compare_with_baseline.ps1 first." -ForegroundColor Yellow
    exit 1
}

Write-Host "Loading comparison data..." -ForegroundColor Cyan
$comparisons = Get-Content $ComparisonPath -Raw | ConvertFrom-Json

# Prepare table rows
$tableRows = ""
foreach ($comp in $comparisons) {
    $perfChange = if ($comp.TimeChangePercent) { 
        $formatted = "{0:F2}" -f $comp.TimeChangePercent
        if ($comp.TimeChangePercent -gt 0) { "+$formatted%" } else { "$formatted%" }
    } else { "-" }
    
    $memChange = if ($comp.MemoryChangePercent) { 
        $formatted = "{0:F2}" -f $comp.MemoryChangePercent
        if ($comp.MemoryChangePercent -gt 0) { "+$formatted%" } else { "$formatted%" }
    } else { "-" }    $perfClass = if ($comp.TimeChangePercent -lt -5) { "improvement" }
                 elseif ($comp.TimeChangePercent -gt 5) { "regression" }
                 else { "" }

    $memClass = if ($comp.MemoryChangePercent -lt -5) { "improvement" }
                elseif ($comp.MemoryChangePercent -gt 5) { "regression" }
                else { "" }

    $githubUrl = "https://github.com/Treit/MiscBenchmarks/tree/main/$($comp.BenchmarkName)"

    $tableRows += @"
        <tr>
            <td><a href="$githubUrl" target="_blank">$($comp.BenchmarkName)</a></td>
            <td>$($comp.Method)</td>
            <td>$($comp.BaselineVersion)</td>
            <td>$($comp.NewVersion)</td>
            <td>$($comp.BaselineTime)</td>
            <td>$($comp.NewTime)</td>
            <td class="$perfClass">$perfChange</td>
            <td>$($comp.BaselineMemory)</td>
            <td>$($comp.NewMemory)</td>
            <td class="$memClass">$memChange</td>
        </tr>

"@
}

$html = @"
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>.NET 10 Benchmark Comparison Report</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Consolas', 'Monaco', 'Courier New', monospace;
            background: #0d1117;
            color: #c9d1d9;
            padding: 20px;
        }

        .container {
            max-width: 100%;
            margin: 0 auto;
            background: #161b22;
            border: 1px solid #30363d;
            border-radius: 6px;
            box-shadow: 0 8px 24px rgba(0,0,0,0.4);
            padding: 30px;
        }

        h1 {
            color: #58a6ff;
            margin-bottom: 10px;
            font-size: 2em;
            font-weight: 600;
            border-bottom: 1px solid #21262d;
            padding-bottom: 10px;
        }

        .subtitle {
            color: #8b949e;
            margin-bottom: 20px;
            font-size: 1em;
        }

        .controls {
            margin: 20px 0;
            padding: 15px;
            background: #0d1117;
            border: 1px solid #30363d;
            border-radius: 6px;
        }

        .search-box {
            width: 100%;
            max-width: 500px;
            padding: 10px;
            font-size: 14px;
            background: #0d1117;
            color: #c9d1d9;
            border: 1px solid #30363d;
            border-radius: 4px;
            margin-bottom: 10px;
        }

        .search-box:focus {
            outline: none;
            border-color: #58a6ff;
            box-shadow: 0 0 0 3px rgba(88, 166, 255, 0.1);
        }

        table {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
        }

        th {
            background: #21262d;
            color: #58a6ff;
            padding: 12px 8px;
            text-align: left;
            font-weight: 600;
            position: sticky;
            top: 0;
            cursor: pointer;
            user-select: none;
            border-bottom: 2px solid #30363d;
        }

        th:hover {
            background: #30363d;
        }

        th::after {
            content: ' ⇅';
            opacity: 0.5;
        }

        td {
            padding: 10px 8px;
            border-bottom: 1px solid #21262d;
        }

        tr:hover {
            background: #0d1117;
        }

        a {
            color: #58a6ff;
            text-decoration: none;
        }

        a:hover {
            text-decoration: underline;
        }

        .improvement {
            color: #3fb950;
            font-weight: 600;
        }

        .regression {
            color: #f85149;
            font-weight: 600;
        }

        .footer {
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #21262d;
            text-align: center;
            color: #8b949e;
            font-size: 0.9em;
        }

        .stats {
            display: inline-block;
            margin: 10px 20px;
            font-size: 0.95em;
            color: #8b949e;
        }

        .stats strong {
            color: #c9d1d9;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>.NET 10 Benchmark Comparison</h1>
        <p class="subtitle">All benchmark results comparing baseline vs .NET 10 performance</p>

        <div class="controls">
            <input type="text" id="searchBox" class="search-box" placeholder="Search benchmarks..." onkeyup="filterTable()">
            <div>
                <span class="stats">Total: <strong>$($comparisons.Count)</strong> benchmarks</span>
                <span class="stats">🟢 Improvements: <strong>$(($comparisons | Where-Object { $_.TimeChangePercent -lt -5 }).Count)</strong></span>
                <span class="stats">🔴 Regressions: <strong>$(($comparisons | Where-Object { $_.TimeChangePercent -gt 5 }).Count)</strong></span>
            </div>
        </div>

        <table id="resultsTable">
            <thead>
                <tr>
                    <th onclick="sortTable(0)">Benchmark</th>
                    <th onclick="sortTable(1)">Method</th>
                    <th onclick="sortTable(2)">Baseline Ver</th>
                    <th onclick="sortTable(3)">New Ver</th>
                    <th onclick="sortTable(4)">Baseline Time</th>
                    <th onclick="sortTable(5)">New Time</th>
                    <th onclick="sortTable(6)">Perf Change</th>
                    <th onclick="sortTable(7)">Baseline Memory</th>
                    <th onclick="sortTable(8)">New Memory</th>
                    <th onclick="sortTable(9)">Memory Change</th>
                </tr>
            </thead>
            <tbody>
$tableRows
            </tbody>
        </table>

        <div class="footer">
            <p>Generated on $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')</p>
            <p>Click column headers to sort • Use search box to filter results</p>
        </div>
    </div>

    <script>
        let sortDirection = {};

        function sortTable(columnIndex) {
            const table = document.getElementById('resultsTable');
            const tbody = table.querySelector('tbody');
            const rows = Array.from(tbody.querySelectorAll('tr'));

            sortDirection[columnIndex] = !sortDirection[columnIndex];
            const ascending = sortDirection[columnIndex];

            rows.sort((a, b) => {
                let aVal = a.cells[columnIndex].textContent.trim();
                let bVal = b.cells[columnIndex].textContent.trim();

                // Try to parse as number (for percentage columns)
                const aNum = parseFloat(aVal.replace(/[+%,]/g, ''));
                const bNum = parseFloat(bVal.replace(/[+%,]/g, ''));

                if (!isNaN(aNum) && !isNaN(bNum)) {
                    return ascending ? aNum - bNum : bNum - aNum;
                }

                return ascending ? aVal.localeCompare(bVal) : bVal.localeCompare(aVal);
            });

            rows.forEach(row => tbody.appendChild(row));
        }

        function filterTable() {
            const input = document.getElementById('searchBox');
            const filter = input.value.toLowerCase();
            const table = document.getElementById('resultsTable');
            const rows = table.querySelectorAll('tbody tr');

            rows.forEach(row => {
                const text = row.textContent.toLowerCase();
                row.style.display = text.includes(filter) ? '' : 'none';
            });
        }
    </script>
</body>
</html>
"@

$html | Out-File $OutputPath -Encoding UTF8

Write-Host "✓ HTML report generated: $OutputPath" -ForegroundColor Green
Write-Host ""
Write-Host "Opening report in browser..." -ForegroundColor Cyan
Start-Process $OutputPath
