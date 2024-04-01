# Getting a token from the end of a URL path


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                       | Count | Mean      | Error    | StdDev   | Median    | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|------------------------------------------------------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|---------:|----------:|------------:|
| GetTokenFromUrlToStringSplitWithLinqAndUnnecessaryNullChecks | 1000  | 262.59 μs | 4.681 μs | 9.771 μs | 262.40 μs | 10.07 |    0.52 | 116.2109 | 491.49 KB |       10.13 |
| GetTokenFromUrlToStringSplitWithLinq                         | 1000  | 262.49 μs | 5.173 μs | 9.967 μs | 258.48 μs | 10.10 |    0.36 | 116.2109 | 491.48 KB |       10.13 |
| GetTokenFromUrlToStringWithIndexOfAndSubstring               | 1000  |  26.08 μs | 0.508 μs | 0.712 μs |  25.94 μs |  1.00 |    0.00 |  11.5051 |  48.52 KB |        1.00 |
| GetTokenFromUrlAbsolutePathWithIndexOfAndSubstring           | 1000  |  27.24 μs | 0.542 μs | 0.742 μs |  27.08 μs |  1.04 |    0.04 |  11.5051 |  48.52 KB |        1.00 |
