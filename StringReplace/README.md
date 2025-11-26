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
| ReplaceNoStringComparison                     | 10000 | 818.1 μs | 4.61 μs | 4.31 μs |  1.00 |
| ReplaceNoStringComparisonUnnecessaryNullCheck | 10000 | 820.6 μs | 4.26 μs | 3.56 μs |  1.00 |
| ReplaceStringComparisonOrdinal                | 10000 | 829.7 μs | 4.03 μs | 3.36 μs |  1.01 |
| ReplaceStringComparisonOrdinalIgnoreCase      | 10000 | 832.7 μs | 3.73 μs | 3.31 μs |  1.02 |
