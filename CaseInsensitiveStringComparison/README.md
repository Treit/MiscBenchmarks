# Case insensitive string comparisons.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| StringComparisonOrdinalIgnoreCase          | 1000  |  15.87 μs | 0.222 μs | 0.197 μs |  1.00 |    0.02 |      - |         - |          NA |
| ToLower                                    | 1000  |  45.96 μs | 0.892 μs | 0.916 μs |  2.90 |    0.07 | 8.6060 |  144936 B |          NA |
| ToUpper                                    | 1000  |  45.79 μs | 0.828 μs | 0.774 μs |  2.89 |    0.06 | 6.4697 |  108736 B |          NA |
| ToLowerInvariant                           | 1000  |  42.22 μs | 0.686 μs | 0.642 μs |  2.66 |    0.05 | 8.6060 |  144936 B |          NA |
| ToUpperInvariant                           | 1000  |  42.23 μs | 0.795 μs | 0.781 μs |  2.66 |    0.06 | 6.4697 |  108736 B |          NA |
| StringComparisonIgnoreCaseFlag             | 1000  | 157.57 μs | 1.212 μs | 1.133 μs |  9.93 |    0.14 |      - |         - |          NA |
| StringComparisonInvariantCultureIgnoreCase | 1000  | 153.42 μs | 1.847 μs | 1.728 μs |  9.67 |    0.16 |      - |         - |          NA |
| StringComparisonCurrentCultureIgnoreCase   | 1000  | 155.38 μs | 1.586 μs | 1.406 μs |  9.79 |    0.14 |      - |         - |          NA |
