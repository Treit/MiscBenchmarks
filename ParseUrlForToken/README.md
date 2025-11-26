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
| GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks | 1000  | 136.40 μs | 2.083 μs | 1.949 μs |  6.40 |    0.15 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringSplitWithLinq                         | 1000  | 130.91 μs | 2.519 μs | 2.356 μs |  6.15 |    0.16 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringWithIndexOfAndSubstring               | 1000  |  21.30 μs | 0.414 μs | 0.425 μs |  1.00 |    0.03 |  2.9602 |  48.52 KB |        1.00 |
| GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring           | 1000  |  22.67 μs | 0.181 μs | 0.151 μs |  1.06 |    0.02 |  2.9602 |  48.52 KB |        1.00 |
