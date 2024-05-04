# Given a large list, take the first n elements and throw away the rest.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26207.5001)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method              | ListSize | N   | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD |
|-------------------- |--------- |---- |------------:|----------:|----------:|------------:|------:|--------:|
| **LinqTake**            | **1000**     | **10**  |    **54.01 ns** |  **1.140 ns** |  **1.671 ns** |    **54.09 ns** |  **2.23** |    **0.13** |
| RangeWithMathDotMin | 1000     | 10  |    23.81 ns |  0.543 ns |  1.302 ns |    23.83 ns |  1.00 |    0.00 |
| HandWrittenLoop     | 1000     | 10  |    33.03 ns |  0.731 ns |  1.588 ns |    33.21 ns |  1.39 |    0.10 |
|                     |          |     |             |           |           |             |       |         |
| **LinqTake**            | **1000**     | **500** |   **759.79 ns** | **15.268 ns** | **33.832 ns** |   **750.81 ns** |  **4.89** |    **0.23** |
| RangeWithMathDotMin | 1000     | 500 |   156.61 ns |  3.041 ns |  4.458 ns |   155.25 ns |  1.00 |    0.00 |
| HandWrittenLoop     | 1000     | 500 | 1,058.00 ns | 21.137 ns | 30.314 ns | 1,052.81 ns |  6.75 |    0.22 |
|                     |          |     |             |           |           |             |       |         |
| **LinqTake**            | **1000000**  | **10**  |    **51.05 ns** |  **0.794 ns** |  **0.704 ns** |    **50.88 ns** |  **2.18** |    **0.12** |
| RangeWithMathDotMin | 1000000  | 10  |    23.28 ns |  0.530 ns |  1.175 ns |    22.82 ns |  1.00 |    0.00 |
| HandWrittenLoop     | 1000000  | 10  |    31.65 ns |  0.375 ns |  0.313 ns |    31.64 ns |  1.36 |    0.08 |
|                     |          |     |             |           |           |             |       |         |
| **LinqTake**            | **1000000**  | **500** |   **713.36 ns** | **13.699 ns** | **13.454 ns** |   **710.26 ns** |  **4.70** |    **0.08** |
| RangeWithMathDotMin | 1000000  | 500 |   151.99 ns |  1.727 ns |  1.531 ns |   151.88 ns |  1.00 |    0.00 |
| HandWrittenLoop     | 1000000  | 500 | 1,063.84 ns | 19.034 ns | 24.071 ns | 1,059.41 ns |  6.97 |    0.18 |
