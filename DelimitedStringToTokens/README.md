# Getting two tokens from a delimited string.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|-------------------------------- |------ |--------------:|--------------:|--------------:|--------------:|------:|--------:|---------:|----------:|------------:|
| **TokenizeWithStringSplit**         | **1**     |      **66.68 ns** |      **0.580 ns** |      **0.484 ns** |      **66.58 ns** |  **1.99** |    **0.23** |   **0.0334** |     **144 B** |        **1.38** |
| TokenizeWithSubstring           | 1     |      35.44 ns |      1.456 ns |      4.034 ns |      34.89 ns |  1.00 |    0.00 |   0.0241 |     104 B |        1.00 |
| TokenizeWithRangeOperator       | 1     |      30.94 ns |      0.379 ns |      0.316 ns |      30.85 ns |  0.92 |    0.11 |   0.0241 |     104 B |        1.00 |
| TokenizeWithRegexMatchDotResult | 1     |     803.32 ns |     16.076 ns |     17.868 ns |     797.94 ns | 23.54 |    2.88 |   0.1812 |     784 B |        7.54 |
| TokenizeWithRegexGroupsDotValue | 1     |     237.34 ns |      4.814 ns |     13.579 ns |     232.96 ns |  6.78 |    0.88 |   0.1407 |     608 B |        5.85 |
|                                 |       |               |               |               |               |       |         |          |           |             |
| **TokenizeWithStringSplit**         | **1000**  |  **69,698.41 ns** |  **1,388.774 ns** |  **2,741.305 ns** |  **69,937.91 ns** |  **2.63** |    **0.11** |  **33.3252** |  **144001 B** |        **1.38** |
| TokenizeWithSubstring           | 1000  |  26,327.80 ns |    506.204 ns |    621.664 ns |  26,174.50 ns |  1.00 |    0.00 |  24.1089 |  104000 B |        1.00 |
| TokenizeWithRangeOperator       | 1000  |  27,083.97 ns |    282.737 ns |    220.742 ns |  27,088.72 ns |  1.03 |    0.03 |  24.1089 |  104000 B |        1.00 |
| TokenizeWithRegexMatchDotResult | 1000  | 844,134.83 ns | 16,464.471 ns | 22,536.753 ns | 839,052.39 ns | 32.11 |    0.90 | 181.6406 |  784006 B |        7.54 |
| TokenizeWithRegexGroupsDotValue | 1000  | 256,066.83 ns | 10,153.729 ns | 28,304.539 ns | 249,915.17 ns |  9.59 |    1.02 | 140.8691 |  608002 B |        5.85 |
