# Getting a token from the end of a URL path





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                       | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------------------------------------------- |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
| GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks | .NET 10.0 | .NET 10.0 | 1000  | 135.00 μs | 1.293 μs | 1.210 μs |  6.43 |    0.06 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringSplitWithLinq                         | .NET 10.0 | .NET 10.0 | 1000  | 126.80 μs | 1.178 μs | 1.044 μs |  6.04 |    0.06 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringWithIndexOfAndSubstring               | .NET 10.0 | .NET 10.0 | 1000  |  21.01 μs | 0.115 μs | 0.102 μs |  1.00 |    0.01 |  2.9602 |  48.52 KB |        1.00 |
| GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring           | .NET 10.0 | .NET 10.0 | 1000  |  21.95 μs | 0.103 μs | 0.097 μs |  1.04 |    0.01 |  2.9602 |  48.52 KB |        1.00 |
|                                                              |           |           |       |           |          |          |       |         |         |           |             |
| GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks | .NET 9.0  | .NET 9.0  | 1000  | 134.84 μs | 1.002 μs | 0.888 μs |  6.29 |    0.07 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringSplitWithLinq                         | .NET 9.0  | .NET 9.0  | 1000  | 128.41 μs | 1.506 μs | 1.409 μs |  5.99 |    0.08 | 30.0293 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringWithIndexOfAndSubstring               | .NET 9.0  | .NET 9.0  | 1000  |  21.43 μs | 0.221 μs | 0.184 μs |  1.00 |    0.01 |  2.9602 |  48.52 KB |        1.00 |
| GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring           | .NET 9.0  | .NET 9.0  | 1000  |  21.71 μs | 0.117 μs | 0.104 μs |  1.01 |    0.01 |  2.9602 |  48.52 KB |        1.00 |
