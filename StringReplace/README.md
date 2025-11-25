# String replace - does the StringComparison parameter matter?




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Count | Mean     | Error   | StdDev  | Ratio |
|---------------------------------------------- |------ |---------:|--------:|--------:|------:|
| ReplaceNoStringComparison                     | 10000 | 816.3 μs | 5.15 μs | 4.57 μs |  1.00 |
| ReplaceNoStringComparisonUnnecessaryNullCheck | 10000 | 824.6 μs | 6.53 μs | 5.79 μs |  1.01 |
| ReplaceStringComparisonOrdinal                | 10000 | 822.3 μs | 6.90 μs | 6.46 μs |  1.01 |
| ReplaceStringComparisonOrdinalIgnoreCase      | 10000 | 844.2 μs | 5.19 μs | 4.85 μs |  1.03 |
