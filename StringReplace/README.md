# String replace - does the StringComparison parameter matter?






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                        | Job       | Runtime   | Count | Mean     | Error    | StdDev  | Ratio | RatioSD |
|---------------------------------------------- |---------- |---------- |------ |---------:|---------:|--------:|------:|--------:|
| ReplaceNoStringComparison                     | .NET 10.0 | .NET 10.0 | 10000 | 820.6 μs | 10.21 μs | 9.55 μs |  1.00 |    0.02 |
| ReplaceNoStringComparisonUnnecessaryNullCheck | .NET 10.0 | .NET 10.0 | 10000 | 819.7 μs | 11.36 μs | 9.49 μs |  1.00 |    0.02 |
| ReplaceStringComparisonOrdinal                | .NET 10.0 | .NET 10.0 | 10000 | 807.9 μs |  1.79 μs | 1.50 μs |  0.98 |    0.01 |
| ReplaceStringComparisonOrdinalIgnoreCase      | .NET 10.0 | .NET 10.0 | 10000 | 811.9 μs |  4.55 μs | 4.26 μs |  0.99 |    0.01 |
|                                               |           |           |       |          |          |         |       |         |
| ReplaceNoStringComparison                     | .NET 9.0  | .NET 9.0  | 10000 | 828.7 μs |  6.56 μs | 5.82 μs |  1.00 |    0.01 |
| ReplaceNoStringComparisonUnnecessaryNullCheck | .NET 9.0  | .NET 9.0  | 10000 | 815.6 μs |  5.61 μs | 4.97 μs |  0.98 |    0.01 |
| ReplaceStringComparisonOrdinal                | .NET 9.0  | .NET 9.0  | 10000 | 805.7 μs |  4.28 μs | 4.00 μs |  0.97 |    0.01 |
| ReplaceStringComparisonOrdinalIgnoreCase      | .NET 9.0  | .NET 9.0  | 10000 | 825.4 μs |  5.80 μs | 5.42 μs |  1.00 |    0.01 |
