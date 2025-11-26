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
| TokenizeWithStringSplit              | 100   |  3.977 μs | 0.0653 μs | 0.0611 μs |  2.19 |    0.04 | 0.8545 |      - |  14.06 KB |        1.38 |
| TokenizeWithSubstring                | 100   |  1.815 μs | 0.0177 μs | 0.0157 μs |  1.00 |    0.01 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRangeOperator            | 100   |  1.830 μs | 0.0125 μs | 0.0117 μs |  1.01 |    0.01 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRegexMatchDotResult      | 100   | 47.075 μs | 0.4260 μs | 0.3985 μs | 25.94 |    0.30 | 4.6387 |      - |  76.56 KB |        7.54 |
| TokenizeWithRegexGroupsDotValue      | 100   | 16.664 μs | 0.2138 μs | 0.1895 μs |  9.18 |    0.13 | 3.6316 |      - |  59.38 KB |        5.85 |
| TokenizeWithCommunityToolkitTokenize | 100   |  2.453 μs | 0.0218 μs | 0.0182 μs |  1.35 |    0.01 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithSpanSlicing              | 100   |  2.199 μs | 0.0398 μs | 0.0372 μs |  1.21 |    0.02 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
