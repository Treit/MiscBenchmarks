# Getting two tokens from a delimited string.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| TokenizeWithStringSplit              | 100   |  3.913 μs | 0.0621 μs | 0.0581 μs |  2.17 |    0.03 | 0.8545 |      - |  14.06 KB |        1.38 |
| TokenizeWithSubstring                | 100   |  1.805 μs | 0.0135 μs | 0.0120 μs |  1.00 |    0.01 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRangeOperator            | 100   |  1.819 μs | 0.0184 μs | 0.0163 μs |  1.01 |    0.01 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRegexMatchDotResult      | 100   | 46.732 μs | 0.3406 μs | 0.2844 μs | 25.90 |    0.22 | 4.6387 |      - |  76.56 KB |        7.54 |
| TokenizeWithRegexGroupsDotValue      | 100   | 15.797 μs | 0.1937 μs | 0.1812 μs |  8.75 |    0.11 | 3.6316 |      - |  59.38 KB |        5.85 |
| TokenizeWithCommunityToolkitTokenize | 100   |  2.594 μs | 0.0268 μs | 0.0250 μs |  1.44 |    0.02 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithSpanSlicing              | 100   |  2.121 μs | 0.0373 μs | 0.0331 μs |  1.18 |    0.02 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
