#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Generates an HTML comparison report with charts showing .NET 10 performance changes.

.DESCRIPTION
    Creates an interactive HTML report comparing baseline benchmark results with .NET 10 results.
    Includes charts showing improvements, regressions, and distribution of changes.

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

# Categorize changes
$improvements = $comparisons | Where-Object { $_.TimeChangePercent -and $_.TimeChangePercent -lt -5 }
$regressions = $comparisons | Where-Object { $_.TimeChangePercent -and $_.TimeChangePercent -gt 5 }
$noChange = $comparisons | Where-Object { $_.TimeChangePercent -and [Math]::Abs($_.TimeChangePercent) -le 5 }

# Prepare data for charts
$improvementsTop = $improvements | Sort-Object TimeChangePercent | Select-Object -First 20
$regressionsTop = $regressions | Sort-Object TimeChangePercent -Descending | Select-Object -First 20

$improvementsJson = $improvementsTop | ConvertTo-Json -Compress
$regressionsJson = $regressionsTop | ConvertTo-Json -Compress

$html = @"
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>.NET 10 Benchmark Comparison Report</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js@4.4.0/dist/chart.umd.min.js"></script>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
            min-height: 100vh;
        }

        .container {
            max-width: 1400px;
            margin: 0 auto;
            background: white;
            border-radius: 12px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            padding: 40px;
        }

        h1 {
            color: #333;
            margin-bottom: 10px;
            font-size: 2.5em;
        }

        .subtitle {
            color: #666;
            margin-bottom: 30px;
            font-size: 1.1em;
        }

        .summary {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            margin-bottom: 40px;
        }

        .stat-card {
            background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
            padding: 25px;
            border-radius: 8px;
            text-align: center;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        }

        .stat-card.improvement {
            background: linear-gradient(135deg, #a8edea 0%, #fed6e3 100%);
        }

        .stat-card.regression {
            background: linear-gradient(135deg, #ffecd2 0%, #fcb69f 100%);
        }

        .stat-number {
            font-size: 3em;
            font-weight: bold;
            color: #333;
            margin: 10px 0;
        }

        .stat-label {
            font-size: 0.9em;
            color: #666;
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        .chart-container {
            margin: 40px 0;
            background: #f8f9fa;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }

        h2 {
            color: #333;
            margin-bottom: 20px;
            padding-bottom: 10px;
            border-bottom: 3px solid #667eea;
        }

        canvas {
            max-height: 500px;
        }

        .footer {
            margin-top: 40px;
            padding-top: 20px;
            border-top: 2px solid #eee;
            text-align: center;
            color: #999;
            font-size: 0.9em;
        }

        .legend {
            margin: 20px 0;
            padding: 15px;
            background: #f0f0f0;
            border-radius: 6px;
        }

        .legend-item {
            display: inline-block;
            margin-right: 20px;
            font-size: 0.95em;
        }

        .legend-icon {
            display: inline-block;
            width: 12px;
            height: 12px;
            margin-right: 5px;
            border-radius: 2px;
        }

        .improvement-icon { background: #4CAF50; }
        .regression-icon { background: #f44336; }
        .nochange-icon { background: #9E9E9E; }
    </style>
</head>
<body>
    <div class="container">
        <h1>🚀 .NET 10 Benchmark Comparison</h1>
        <p class="subtitle">Performance analysis of benchmark results upgrading to .NET 10</p>

        <div class="summary">
            <div class="stat-card improvement">
                <div class="stat-label">Improvements</div>
                <div class="stat-number">$($improvements.Count)</div>
                <div class="stat-label">Faster</div>
            </div>
            <div class="stat-card regression">
                <div class="stat-label">Regressions</div>
                <div class="stat-number">$($regressions.Count)</div>
                <div class="stat-label">Slower</div>
            </div>
            <div class="stat-card">
                <div class="stat-label">No Change</div>
                <div class="stat-number">$($noChange.Count)</div>
                <div class="stat-label">Similar</div>
            </div>
            <div class="stat-card">
                <div class="stat-label">Total Compared</div>
                <div class="stat-number">$($comparisons.Count)</div>
                <div class="stat-label">Benchmarks</div>
            </div>
        </div>

        <div class="legend">
            <div class="legend-item">
                <span class="legend-icon improvement-icon"></span>
                <span>Improvement (faster/less memory)</span>
            </div>
            <div class="legend-item">
                <span class="legend-icon regression-icon"></span>
                <span>Regression (slower/more memory)</span>
            </div>
            <div class="legend-item">
                <span class="legend-icon nochange-icon"></span>
                <span>No significant change (±5%)</span>
            </div>
        </div>

        <div class="chart-container">
            <h2>📈 Top 20 Performance Improvements</h2>
            <canvas id="improvementsChart"></canvas>
        </div>

        <div class="chart-container">
            <h2>📉 Top 20 Performance Regressions</h2>
            <canvas id="regressionsChart"></canvas>
        </div>

        <div class="chart-container">
            <h2>📊 Change Distribution</h2>
            <canvas id="distributionChart"></canvas>
        </div>

        <div class="footer">
            <p>Generated on $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')</p>
            <p>Report created from $($comparisons.Count) benchmark comparisons</p>
        </div>
    </div>

    <script>
        const improvements = $improvementsJson;
        const regressions = $regressionsJson;

        // Improvements Chart
        new Chart(document.getElementById('improvementsChart'), {
            type: 'bar',
            data: {
                labels: improvements.map(x => x.BenchmarkName + '/' + x.Method).map(x => x.length > 50 ? x.substring(0, 47) + '...' : x),
                datasets: [{
                    label: 'Performance Improvement (%)',
                    data: improvements.map(x => Math.abs(x.TimeChangePercent)),
                    backgroundColor: 'rgba(76, 175, 80, 0.7)',
                    borderColor: 'rgba(76, 175, 80, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                indexAxis: 'y',
                responsive: true,
                maintainAspectRatio: true,
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        callbacks: {
                            label: function(context) {
                                return context.parsed.x.toFixed(2) + '% faster';
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Performance Improvement (%)'
                        }
                    }
                }
            }
        });

        // Regressions Chart
        new Chart(document.getElementById('regressionsChart'), {
            type: 'bar',
            data: {
                labels: regressions.map(x => x.BenchmarkName + '/' + x.Method).map(x => x.length > 50 ? x.substring(0, 47) + '...' : x),
                datasets: [{
                    label: 'Performance Regression (%)',
                    data: regressions.map(x => x.TimeChangePercent),
                    backgroundColor: 'rgba(244, 67, 54, 0.7)',
                    borderColor: 'rgba(244, 67, 54, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                indexAxis: 'y',
                responsive: true,
                maintainAspectRatio: true,
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        callbacks: {
                            label: function(context) {
                                return context.parsed.x.toFixed(2) + '% slower';
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Performance Regression (%)'
                        }
                    }
                }
            }
        });

        // Distribution Chart
        new Chart(document.getElementById('distributionChart'), {
            type: 'pie',
            data: {
                labels: ['Improvements', 'Regressions', 'No Change'],
                datasets: [{
                    data: [$($improvements.Count), $($regressions.Count), $($noChange.Count)],
                    backgroundColor: [
                        'rgba(76, 175, 80, 0.7)',
                        'rgba(244, 67, 54, 0.7)',
                        'rgba(158, 158, 158, 0.7)'
                    ],
                    borderColor: [
                        'rgba(76, 175, 80, 1)',
                        'rgba(244, 67, 54, 1)',
                        'rgba(158, 158, 158, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: true,
                plugins: {
                    legend: {
                        position: 'bottom'
                    },
                    tooltip: {
                        callbacks: {
                            label: function(context) {
                                const total = context.dataset.data.reduce((a, b) => a + b, 0);
                                const percentage = ((context.parsed / total) * 100).toFixed(1);
                                return context.label + ': ' + context.parsed + ' (' + percentage + '%)';
                            }
                        }
                    }
                }
            }
        });
    </script>
</body>
</html>
"@

$html | Out-File $OutputPath -Encoding UTF8

Write-Host "✓ HTML report generated: $OutputPath" -ForegroundColor Green
Write-Host ""
Write-Host "Opening report in browser..." -ForegroundColor Cyan
Start-Process $OutputPath
