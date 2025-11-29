#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Generates an HTML table report showing .NET 9 vs .NET 10 benchmark comparisons.

.DESCRIPTION
    Creates a sortable HTML table with all benchmark results showing performance and memory changes
    between .NET 9 and .NET 10.

.PARAMETER ComparisonPath
    Path to the comparison JSON file. Defaults to "net9_vs_net10_comparison.json".

.PARAMETER OutputPath
    Path where the HTML report will be saved. Defaults to "net9_vs_net10_report.html".

.EXAMPLE
    .\generate_net9_vs_net10_report.ps1
    .\generate_net9_vs_net10_report.ps1 -ComparisonPath ".\comparison.json" -OutputPath ".\report.html"
#>

param(
    [string]$ComparisonPath = ".\net9_vs_net10_comparison.json",
    [string]$OutputPath = ".\net9_vs_net10_report.html"
)

if (-not (Test-Path $ComparisonPath)) {
    Write-Host "Error: Comparison file not found at $ComparisonPath" -ForegroundColor Red
    Write-Host "Please run compare_net9_vs_net10.ps1 first." -ForegroundColor Yellow
    exit 1
}

Write-Host "Loading comparison data..." -ForegroundColor Cyan
$comparisons = Get-Content $ComparisonPath -Raw | ConvertFrom-Json

# Prepare table rows
$tableRows = ""
foreach ($comp in $comparisons) {
    $perfChange = if ($null -ne $comp.TimeChangePercent) {
        $formatted = "{0:F2}" -f $comp.TimeChangePercent
        if ($comp.TimeChangePercent -gt 0) { "+$formatted%" } else { "$formatted%" }
    } else { "-" }

    $memChange = if ($null -ne $comp.MemoryChangePercent) {
        $formatted = "{0:F2}" -f $comp.MemoryChangePercent
        if ($comp.MemoryChangePercent -gt 0) { "+$formatted%" } else { "$formatted%" }
    } else { "-" }

    $perfClass = if ($null -ne $comp.TimeChangePercent) {
        if ($comp.TimeChangePercent -lt -5) { "improvement" }
        elseif ($comp.TimeChangePercent -gt 5) { "regression" }
        else { "" }
    } else { "" }

    $memClass = if ($null -ne $comp.MemoryChangePercent) {
        if ($comp.MemoryChangePercent -lt -5) { "improvement" }
        elseif ($comp.MemoryChangePercent -gt 5) { "regression" }
        else { "" }
    } else { "" }

    $githubUrl = "https://github.com/Treit/MiscBenchmarks/tree/main/$($comp.BenchmarkName)"

    # Build additional parameters string
    $params = @()
    if ($comp.Count) { $params += "Count=$($comp.Count)" }
    if ($comp.Iterations) { $params += "Iterations=$($comp.Iterations)" }
    $paramsStr = if ($params) { $params -join ", " } else { "-" }

    $tableRows += @"
        <tr>
            <td><a href="$githubUrl" target="_blank">$($comp.BenchmarkName)</a></td>
            <td>$($comp.Method)</td>
            <td>$paramsStr</td>
            <td>$($comp.Net9Version)</td>
            <td>$($comp.Net10Version)</td>
            <td>$($comp.Net9Time)</td>
            <td>$($comp.Net10Time)</td>
            <td class="$perfClass">$perfChange</td>
            <td>$($comp.Net9Memory)</td>
            <td>$($comp.Net10Memory)</td>
            <td class="$memClass">$memChange</td>
        </tr>

"@
}

$improvementCount = ($comparisons | Where-Object { $_.TimeChangePercent -lt -5 }).Count
$regressionCount = ($comparisons | Where-Object { $_.TimeChangePercent -gt 5 }).Count
$neutralCount = $comparisons.Count - $improvementCount - $regressionCount

$html = @"
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>.NET 9 vs .NET 10 Benchmark Comparison Report</title>
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

        .filter-buttons {
            margin-top: 10px;
        }

        .filter-btn {
            padding: 8px 16px;
            margin-right: 10px;
            margin-bottom: 5px;
            background: #21262d;
            color: #c9d1d9;
            border: 1px solid #30363d;
            border-radius: 4px;
            cursor: pointer;
            font-size: 13px;
            transition: all 0.2s;
        }

        .filter-btn:hover {
            background: #30363d;
        }

        .filter-btn.active {
            background: #58a6ff;
            color: #0d1117;
            border-color: #58a6ff;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
            margin-top: 10px;
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
            white-space: nowrap;
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

        .version-badge {
            display: inline-block;
            padding: 2px 8px;
            border-radius: 3px;
            font-size: 0.85em;
            font-weight: 600;
            background: #1f6feb;
            color: #ffffff;
        }

        .hidden {
            display: none;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>.NET 9 vs .NET 10 Benchmark Comparison</h1>
        <p class="subtitle">Comprehensive performance comparison between <span class="version-badge">.NET 9</span> and <span class="version-badge">.NET 10</span></p>

        <div class="controls">
            <input type="text" id="searchBox" class="search-box" placeholder="Search benchmarks, methods, or parameters..." onkeyup="filterTable()">
            <div class="filter-buttons">
                <button class="filter-btn active" onclick="filterResults('all')">All ($($comparisons.Count))</button>
                <button class="filter-btn" onclick="filterResults('improvements')">🟢 Improvements ($improvementCount)</button>
                <button class="filter-btn" onclick="filterResults('regressions')">🔴 Regressions ($regressionCount)</button>
                <button class="filter-btn" onclick="filterResults('neutral')">⚪ Neutral ($neutralCount)</button>
            </div>
            <div style="margin-top: 10px;">
                <span class="stats">Total: <strong>$($comparisons.Count)</strong> benchmarks</span>
                <span class="stats">🟢 Improvements: <strong>$improvementCount</strong></span>
                <span class="stats">🔴 Regressions: <strong>$regressionCount</strong></span>
                <span class="stats">⚪ Neutral: <strong>$neutralCount</strong></span>
            </div>
        </div>

        <table id="resultsTable">
            <thead>
                <tr>
                    <th onclick="sortTable(0)">Benchmark</th>
                    <th onclick="sortTable(1)">Method</th>
                    <th onclick="sortTable(2)">Parameters</th>
                    <th onclick="sortTable(3)">.NET 9 Ver</th>
                    <th onclick="sortTable(4)">.NET 10 Ver</th>
                    <th onclick="sortTable(5)">.NET 9 Time</th>
                    <th onclick="sortTable(6)">.NET 10 Time</th>
                    <th onclick="sortTable(7)">Perf Change</th>
                    <th onclick="sortTable(8)">.NET 9 Memory</th>
                    <th onclick="sortTable(9)">.NET 10 Memory</th>
                    <th onclick="sortTable(10)">Memory Change</th>
                </tr>
            </thead>
            <tbody>
$tableRows
            </tbody>
        </table>

        <div class="footer">
            <p>Generated on $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')</p>
            <p>Click column headers to sort • Use search box to filter results • Use filter buttons to show specific categories</p>
        </div>
    </div>

    <script>
        let sortDirection = {};
        let currentFilter = 'all';

        function sortTable(columnIndex) {
            const table = document.getElementById('resultsTable');
            const tbody = table.querySelector('tbody');
            const rows = Array.from(tbody.querySelectorAll('tr')).filter(row => !row.classList.contains('hidden'));

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

            // Reorder all rows (including hidden ones)
            const allRows = Array.from(tbody.querySelectorAll('tr'));
            const sortedAllRows = [];

            rows.forEach(row => sortedAllRows.push(row));
            allRows.forEach(row => {
                if (!rows.includes(row)) {
                    sortedAllRows.push(row);
                }
            });

            sortedAllRows.forEach(row => tbody.appendChild(row));
        }

        function filterTable() {
            const input = document.getElementById('searchBox');
            const filter = input.value.toLowerCase();
            const table = document.getElementById('resultsTable');
            const rows = table.querySelectorAll('tbody tr');

            rows.forEach(row => {
                const text = row.textContent.toLowerCase();
                const matchesSearch = text.includes(filter);
                const matchesFilter = checkFilterMatch(row);

                row.style.display = (matchesSearch && matchesFilter) ? '' : 'none';
            });
        }

        function checkFilterMatch(row) {
            if (currentFilter === 'all') return true;

            const perfChangeCell = row.cells[7];
            const perfChangeText = perfChangeCell.textContent.trim();

            if (perfChangeText === '-') return false;

            const perfValue = parseFloat(perfChangeText.replace(/[+%]/g, ''));

            if (currentFilter === 'improvements') {
                return perfValue < -5;
            } else if (currentFilter === 'regressions') {
                return perfValue > 5;
            } else if (currentFilter === 'neutral') {
                return perfValue >= -5 && perfValue <= 5;
            }

            return true;
        }

        function filterResults(type) {
            currentFilter = type;

            // Update button states
            document.querySelectorAll('.filter-btn').forEach(btn => {
                btn.classList.remove('active');
            });
            event.target.classList.add('active');

            // Apply filter
            filterTable();
        }

        // Initialize - apply default filter
        window.onload = function() {
            filterTable();
        };
    </script>
</body>
</html>
"@

$html | Out-File $OutputPath -Encoding UTF8

Write-Host "✓ HTML report generated: $OutputPath" -ForegroundColor Green
Write-Host ""
Write-Host "Opening report in browser..." -ForegroundColor Cyan
Start-Process $OutputPath
