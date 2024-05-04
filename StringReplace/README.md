# String replace - does the StringComparison parameter matter?



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2


```
| Method                                        | Count | Mean     | Error    | StdDev   | Ratio | RatioSD |
|---------------------------------------------- |------ |---------:|---------:|---------:|------:|--------:|
| ReplaceNoStringComparison                     | 10000 | 540.4 μs | 10.76 μs | 11.05 μs |  1.00 |    0.00 |
| ReplaceNoStringComparisonUnnecessaryNullCheck | 10000 | 552.4 μs |  7.32 μs |  6.84 μs |  1.02 |    0.02 |
| ReplaceStringComparisonOrdinal                | 10000 | 552.2 μs | 10.94 μs | 20.01 μs |  1.00 |    0.04 |
| ReplaceStringComparisonOrdinalIgnoreCase      | 10000 | 742.4 μs | 11.84 μs | 11.07 μs |  1.37 |    0.04 |
