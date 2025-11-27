# Getting two tokens from a delimited string.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------- |---------- |---------- |------ |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| TokenizeWithStringSplit              | .NET 10.0 | .NET 10.0 | 100   |  3.960 μs | 0.0762 μs | 0.0963 μs |  2.16 |    0.07 | 0.8545 |      - |  14.06 KB |        1.38 |
| TokenizeWithSubstring                | .NET 10.0 | .NET 10.0 | 100   |  1.833 μs | 0.0355 μs | 0.0348 μs |  1.00 |    0.03 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRangeOperator            | .NET 10.0 | .NET 10.0 | 100   |  1.853 μs | 0.0267 μs | 0.0250 μs |  1.01 |    0.02 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRegexMatchDotResult      | .NET 10.0 | .NET 10.0 | 100   | 47.587 μs | 0.4291 μs | 0.3583 μs | 25.98 |    0.51 | 4.6387 |      - |  76.56 KB |        7.54 |
| TokenizeWithRegexGroupsDotValue      | .NET 10.0 | .NET 10.0 | 100   | 16.020 μs | 0.3181 μs | 0.3787 μs |  8.74 |    0.26 | 3.6316 |      - |  59.38 KB |        5.85 |
| TokenizeWithCommunityToolkitTokenize | .NET 10.0 | .NET 10.0 | 100   |  2.470 μs | 0.0440 μs | 0.0390 μs |  1.35 |    0.03 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithSpanSlicing              | .NET 10.0 | .NET 10.0 | 100   |  2.183 μs | 0.0290 μs | 0.0257 μs |  1.19 |    0.03 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
|                                      |           |           |       |           |           |           |       |         |        |        |           |             |
| TokenizeWithStringSplit              | .NET 9.0  | .NET 9.0  | 100   |  3.968 μs | 0.0682 μs | 0.0638 μs |  2.16 |    0.04 | 0.8545 |      - |  14.06 KB |        1.38 |
| TokenizeWithSubstring                | .NET 9.0  | .NET 9.0  | 100   |  1.840 μs | 0.0205 μs | 0.0192 μs |  1.00 |    0.01 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRangeOperator            | .NET 9.0  | .NET 9.0  | 100   |  1.836 μs | 0.0291 μs | 0.0272 μs |  1.00 |    0.02 | 0.6199 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithRegexMatchDotResult      | .NET 9.0  | .NET 9.0  | 100   | 48.583 μs | 0.5520 μs | 0.5163 μs | 26.41 |    0.38 | 4.6387 |      - |  76.56 KB |        7.54 |
| TokenizeWithRegexGroupsDotValue      | .NET 9.0  | .NET 9.0  | 100   | 15.296 μs | 0.2233 μs | 0.2088 μs |  8.31 |    0.14 | 3.6316 |      - |  59.38 KB |        5.85 |
| TokenizeWithCommunityToolkitTokenize | .NET 9.0  | .NET 9.0  | 100   |  2.471 μs | 0.0387 μs | 0.0362 μs |  1.34 |    0.02 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
| TokenizeWithSpanSlicing              | .NET 9.0  | .NET 9.0  | 100   |  2.202 μs | 0.0419 μs | 0.0412 μs |  1.20 |    0.02 | 0.6180 | 0.0038 |  10.16 KB |        1.00 |
