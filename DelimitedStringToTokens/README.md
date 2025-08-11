# Getting two tokens from a delimited string.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27924.1000)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| TokenizeWithStringSplit              | 100   |   6.934 μs | 0.2242 μs | 0.6506 μs |  1.48 |    0.15 |  3.3340 |  14.06 KB |        1.38 |
| TokenizeWithSubstring                | 100   |   4.704 μs | 0.0891 μs | 0.1026 μs |  1.00 |    0.00 |  2.4109 |  10.16 KB |        1.00 |
| TokenizeWithRangeOperator            | 100   |   4.780 μs | 0.0706 μs | 0.0626 μs |  1.01 |    0.02 |  2.4109 |  10.16 KB |        1.00 |
| TokenizeWithRegexMatchDotResult      | 100   | 119.545 μs | 2.2931 μs | 2.5487 μs | 25.42 |    0.77 | 18.0664 |  76.56 KB |        7.54 |
| TokenizeWithRegexGroupsDotValue      | 100   |  40.231 μs | 0.3973 μs | 0.3318 μs |  8.51 |    0.21 | 14.0381 |  59.38 KB |        5.85 |
| TokenizeWithCommunityToolkitTokenize | 100   |   6.735 μs | 0.1268 μs | 0.1059 μs |  1.42 |    0.03 |  2.4109 |  10.16 KB |        1.00 |
| TokenizeWithSpanSlicing              | 100   |   5.779 μs | 0.0679 μs | 0.0567 μs |  1.22 |    0.02 |  2.4109 |  10.16 KB |        1.00 |
