# Case insensitive string comparisons.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------- |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| StringComparisonOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 1000  |  15.52 μs | 0.184 μs | 0.154 μs |  1.00 |    0.01 |      - |         - |          NA |
| ToLower                                    | .NET 10.0 | .NET 10.0 | 1000  |  46.49 μs | 0.901 μs | 0.964 μs |  3.00 |    0.07 | 8.6060 |  144936 B |          NA |
| ToUpper                                    | .NET 10.0 | .NET 10.0 | 1000  |  45.91 μs | 0.587 μs | 0.521 μs |  2.96 |    0.04 | 6.4697 |  108736 B |          NA |
| ToLowerInvariant                           | .NET 10.0 | .NET 10.0 | 1000  |  41.95 μs | 0.596 μs | 0.528 μs |  2.70 |    0.04 | 8.6060 |  144936 B |          NA |
| ToUpperInvariant                           | .NET 10.0 | .NET 10.0 | 1000  |  43.36 μs | 0.414 μs | 0.367 μs |  2.79 |    0.04 | 6.4697 |  108736 B |          NA |
| StringComparisonIgnoreCaseFlag             | .NET 10.0 | .NET 10.0 | 1000  | 154.62 μs | 1.409 μs | 1.318 μs |  9.96 |    0.13 |      - |         - |          NA |
| StringComparisonInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 1000  | 153.94 μs | 2.767 μs | 2.589 μs |  9.92 |    0.19 |      - |       3 B |          NA |
| StringComparisonCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 1000  | 155.01 μs | 2.385 μs | 2.231 μs |  9.99 |    0.17 |      - |         - |          NA |
|                                            |           |           |       |           |          |          |       |         |        |           |             |
| StringComparisonOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 1000  |  15.42 μs | 0.151 μs | 0.141 μs |  1.00 |    0.01 |      - |         - |          NA |
| ToLower                                    | .NET 9.0  | .NET 9.0  | 1000  |  47.85 μs | 0.550 μs | 0.514 μs |  3.10 |    0.04 | 8.6060 |  144936 B |          NA |
| ToUpper                                    | .NET 9.0  | .NET 9.0  | 1000  |  46.79 μs | 0.746 μs | 0.698 μs |  3.03 |    0.05 | 6.4697 |  108736 B |          NA |
| ToLowerInvariant                           | .NET 9.0  | .NET 9.0  | 1000  |  42.52 μs | 0.534 μs | 0.500 μs |  2.76 |    0.04 | 8.6060 |  144936 B |          NA |
| ToUpperInvariant                           | .NET 9.0  | .NET 9.0  | 1000  |  43.88 μs | 0.650 μs | 0.608 μs |  2.85 |    0.05 | 6.4697 |  108736 B |          NA |
| StringComparisonIgnoreCaseFlag             | .NET 9.0  | .NET 9.0  | 1000  | 154.66 μs | 1.735 μs | 1.623 μs | 10.03 |    0.14 |      - |         - |          NA |
| StringComparisonInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 1000  | 153.60 μs | 2.247 μs | 1.876 μs |  9.96 |    0.15 |      - |         - |          NA |
| StringComparisonCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 1000  | 153.99 μs | 2.641 μs | 2.470 μs |  9.98 |    0.18 |      - |         - |          NA |
