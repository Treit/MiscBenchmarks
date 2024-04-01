# Getting two tokens from a delimited string.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                    | Count | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
| **TokenizeWithStringSplit**   | **1**     |     **66.59 ns** |     **1.394 ns** |     **3.419 ns** |     **65.76 ns** |  **2.22** |    **0.15** |  **0.0334** |     **144 B** |        **1.38** |
| TokenizeWithSubstring     | 1     |     30.13 ns |     0.667 ns |     1.560 ns |     29.52 ns |  1.00 |    0.00 |  0.0241 |     104 B |        1.00 |
| TokenizeWithRangeOperator | 1     |     29.85 ns |     0.667 ns |     0.977 ns |     29.61 ns |  0.99 |    0.06 |  0.0241 |     104 B |        1.00 |
|                           |       |              |              |              |              |       |         |         |           |             |
| **TokenizeWithStringSplit**   | **1000**  | **65,434.30 ns** | **1,302.496 ns** | **3,095.519 ns** | **64,547.55 ns** |  **2.62** |    **0.11** | **33.3252** |  **144001 B** |        **1.38** |
| TokenizeWithSubstring     | 1000  | 25,030.42 ns |   384.004 ns |   499.314 ns | 24,910.23 ns |  1.00 |    0.00 | 24.1089 |  104000 B |        1.00 |
| TokenizeWithRangeOperator | 1000  | 27,306.40 ns |   729.354 ns | 2,115.987 ns | 27,221.95 ns |  1.04 |    0.05 | 24.1089 |  104000 B |        1.00 |
