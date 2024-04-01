# Getting two tokens from a delimited string.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                    | Count | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|-------------------------- |------ |--------------:|--------------:|--------------:|--------------:|------:|--------:|---------:|----------:|------------:|
| **TokenizeWithStringSplit**   | **1**     |      **71.01 ns** |      **1.640 ns** |      **4.704 ns** |      **69.85 ns** |  **2.32** |    **0.20** |   **0.0334** |     **144 B** |        **1.38** |
| TokenizeWithSubstring     | 1     |      30.67 ns |      0.679 ns |      1.776 ns |      29.85 ns |  1.00 |    0.00 |   0.0241 |     104 B |        1.00 |
| TokenizeWithRangeOperator | 1     |      31.33 ns |      0.662 ns |      1.440 ns |      30.84 ns |  1.02 |    0.07 |   0.0241 |     104 B |        1.00 |
| TokenizeWithRegex         | 1     |     787.74 ns |     14.839 ns |     13.880 ns |     782.51 ns | 24.65 |    1.75 |   0.1812 |     784 B |        7.54 |
|                           |       |               |               |               |               |       |         |          |           |             |
| **TokenizeWithStringSplit**   | **1000**  |  **61,696.99 ns** |  **1,216.975 ns** |  **1,138.359 ns** |  **62,030.91 ns** |  **2.32** |    **0.10** |  **33.3252** |  **144000 B** |        **1.38** |
| TokenizeWithSubstring     | 1000  |  26,742.62 ns |    530.164 ns |  1,034.044 ns |  26,477.61 ns |  1.00 |    0.00 |  24.1089 |  104000 B |        1.00 |
| TokenizeWithRangeOperator | 1000  |  25,904.76 ns |    502.411 ns |    419.536 ns |  25,940.28 ns |  0.97 |    0.05 |  24.1089 |  104000 B |        1.00 |
| TokenizeWithRegex         | 1000  | 802,811.99 ns | 15,720.496 ns | 17,473.290 ns | 795,476.27 ns | 30.24 |    1.19 | 181.6406 |  784006 B |        7.54 |
