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
| StringComparisonOrdinalIgnoreCase          | 1000  |  17.05 μs | 0.170 μs | 0.159 μs |  1.00 |    0.01 |      - |         - |          NA |
| ToLower                                    | 1000  |  45.69 μs | 0.543 μs | 0.453 μs |  2.68 |    0.04 | 8.6060 |  144936 B |          NA |
| ToUpper                                    | 1000  |  46.08 μs | 0.742 μs | 0.694 μs |  2.70 |    0.05 | 6.4697 |  108736 B |          NA |
| ToLowerInvariant                           | 1000  |  41.45 μs | 0.795 μs | 0.744 μs |  2.43 |    0.05 | 8.6060 |  144936 B |          NA |
| ToUpperInvariant                           | 1000  |  43.02 μs | 0.771 μs | 0.721 μs |  2.52 |    0.05 | 6.4697 |  108736 B |          NA |
| StringComparisonIgnoreCaseFlag             | 1000  | 154.02 μs | 2.171 μs | 2.031 μs |  9.04 |    0.14 |      - |         - |          NA |
| StringComparisonInvariantCultureIgnoreCase | 1000  | 152.60 μs | 1.625 μs | 1.520 μs |  8.95 |    0.12 |      - |         - |          NA |
| StringComparisonCurrentCultureIgnoreCase   | 1000  | 153.69 μs | 1.701 μs | 1.591 μs |  9.02 |    0.12 |      - |         - |          NA |
