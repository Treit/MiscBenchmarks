# Getting a token from the end of a URL path



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                       | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------------------------------------------- |------ |----------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
| GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks | 1000  | 137.26 μs | 1.547 μs | 1.447 μs |  6.50 |    0.08 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringSplitWithLinq                         | 1000  | 131.53 μs | 1.960 μs | 1.833 μs |  6.23 |    0.10 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringWithIndexOfAndSubstring               | 1000  |  21.13 μs | 0.190 μs | 0.178 μs |  1.00 |    0.01 |  2.9602 |  48.52 KB |        1.00 |
| GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring           | 1000  |  22.96 μs | 0.206 μs | 0.183 μs |  1.09 |    0.01 |  2.9602 |  48.52 KB |        1.00 |
