# Given a large list, take the first n elements and throw away the rest.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | ListSize | N   | Mean      | Error    | StdDev   | Median    | Ratio | RatioSD |
|-------------------- |---------- |---------- |--------- |---- |----------:|---------:|---------:|----------:|------:|--------:|
| **LinqTake**            | **.NET 10.0** | **.NET 10.0** | **1000**     | **10**  |  **20.31 ns** | **0.164 ns** | **0.153 ns** |  **20.35 ns** |  **1.86** |    **0.03** |
| RangeWithMathDotMin | .NET 10.0 | .NET 10.0 | 1000     | 10  |  10.94 ns | 0.139 ns | 0.130 ns |  10.95 ns |  1.00 |    0.02 |
| HandWrittenLoop     | .NET 10.0 | .NET 10.0 | 1000     | 10  |  24.12 ns | 0.327 ns | 0.306 ns |  23.99 ns |  2.21 |    0.04 |
|                     |           |           |          |     |           |          |          |           |       |         |
| LinqTake            | .NET 9.0  | .NET 9.0  | 1000     | 10  |  20.38 ns | 0.174 ns | 0.145 ns |  20.41 ns |  1.85 |    0.03 |
| RangeWithMathDotMin | .NET 9.0  | .NET 9.0  | 1000     | 10  |  11.00 ns | 0.181 ns | 0.169 ns |  10.96 ns |  1.00 |    0.02 |
| HandWrittenLoop     | .NET 9.0  | .NET 9.0  | 1000     | 10  |  24.06 ns | 0.215 ns | 0.202 ns |  24.01 ns |  2.19 |    0.04 |
|                     |           |           |          |     |           |          |          |           |       |         |
| **LinqTake**            | **.NET 10.0** | **.NET 10.0** | **1000**     | **500** |  **97.94 ns** | **1.938 ns** | **2.232 ns** |  **96.43 ns** |  **1.16** |    **0.03** |
| RangeWithMathDotMin | .NET 10.0 | .NET 10.0 | 1000     | 500 |  84.68 ns | 1.690 ns | 1.498 ns |  84.93 ns |  1.00 |    0.02 |
| HandWrittenLoop     | .NET 10.0 | .NET 10.0 | 1000     | 500 | 794.87 ns | 4.740 ns | 4.433 ns | 795.73 ns |  9.39 |    0.17 |
|                     |           |           |          |     |           |          |          |           |       |         |
| LinqTake            | .NET 9.0  | .NET 9.0  | 1000     | 500 |  97.97 ns | 2.008 ns | 3.409 ns |  97.94 ns |  1.15 |    0.05 |
| RangeWithMathDotMin | .NET 9.0  | .NET 9.0  | 1000     | 500 |  84.97 ns | 1.731 ns | 1.619 ns |  85.49 ns |  1.00 |    0.03 |
| HandWrittenLoop     | .NET 9.0  | .NET 9.0  | 1000     | 500 | 799.24 ns | 6.305 ns | 5.898 ns | 802.35 ns |  9.41 |    0.19 |
|                     |           |           |          |     |           |          |          |           |       |         |
| **LinqTake**            | **.NET 10.0** | **.NET 10.0** | **1000000**  | **10**  |  **20.60 ns** | **0.182 ns** | **0.170 ns** |  **20.63 ns** |  **1.90** |    **0.02** |
| RangeWithMathDotMin | .NET 10.0 | .NET 10.0 | 1000000  | 10  |  10.86 ns | 0.102 ns | 0.090 ns |  10.85 ns |  1.00 |    0.01 |
| HandWrittenLoop     | .NET 10.0 | .NET 10.0 | 1000000  | 10  |  23.89 ns | 0.237 ns | 0.222 ns |  23.85 ns |  2.20 |    0.03 |
|                     |           |           |          |     |           |          |          |           |       |         |
| LinqTake            | .NET 9.0  | .NET 9.0  | 1000000  | 10  |  20.56 ns | 0.191 ns | 0.178 ns |  20.58 ns |  1.89 |    0.02 |
| RangeWithMathDotMin | .NET 9.0  | .NET 9.0  | 1000000  | 10  |  10.88 ns | 0.071 ns | 0.067 ns |  10.88 ns |  1.00 |    0.01 |
| HandWrittenLoop     | .NET 9.0  | .NET 9.0  | 1000000  | 10  |  23.99 ns | 0.161 ns | 0.150 ns |  23.97 ns |  2.20 |    0.02 |
|                     |           |           |          |     |           |          |          |           |       |         |
| **LinqTake**            | **.NET 10.0** | **.NET 10.0** | **1000000**  | **500** |  **96.63 ns** | **1.525 ns** | **1.427 ns** |  **97.20 ns** |  **1.19** |    **0.02** |
| RangeWithMathDotMin | .NET 10.0 | .NET 10.0 | 1000000  | 500 |  81.47 ns | 0.875 ns | 0.776 ns |  81.28 ns |  1.00 |    0.01 |
| HandWrittenLoop     | .NET 10.0 | .NET 10.0 | 1000000  | 500 | 785.05 ns | 4.027 ns | 3.570 ns | 784.38 ns |  9.64 |    0.10 |
|                     |           |           |          |     |           |          |          |           |       |         |
| LinqTake            | .NET 9.0  | .NET 9.0  | 1000000  | 500 |  97.36 ns | 1.899 ns | 1.776 ns |  97.39 ns |  1.15 |    0.04 |
| RangeWithMathDotMin | .NET 9.0  | .NET 9.0  | 1000000  | 500 |  84.44 ns | 1.702 ns | 2.495 ns |  85.02 ns |  1.00 |    0.04 |
| HandWrittenLoop     | .NET 9.0  | .NET 9.0  | 1000000  | 500 | 786.67 ns | 4.035 ns | 3.774 ns | 787.35 ns |  9.32 |    0.27 |
