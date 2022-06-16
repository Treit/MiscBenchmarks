# Summing integer arrays

``` ini

BenchmarkDotNet=v0.13.1.20220615-develop, OS=Windows 11 (10.0.25140.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET 7.0.0 (7.0.22.30112), X64 RyuJIT
  DefaultJob : .NET 7.0.0 (7.0.22.30112), X64 RyuJIT


```
|                                  Method | Count |              Mean |            Error |            StdDev |            Median |     Ratio |  RatioSD |      Gen 0 |    Gen 1 |   Allocated | Alloc Ratio |
|---------------------------------------- |------ |------------------:|-----------------:|------------------:|------------------:|----------:|---------:|-----------:|---------:|------------:|------------:|
|                         **SumUsingForLoop** |    **10** |          **16.90 ns** |         **0.586 ns** |          **1.701 ns** |          **16.41 ns** |      **1.00** |     **0.00** |     **0.0148** |        **-** |        **64 B** |        **1.00** |
|                     SumUsingForLoopSpan |    10 |          24.33 ns |         0.526 ns |          1.456 ns |          24.09 ns |      1.46 |     0.16 |     0.0148 |        - |        64 B |        1.00 |
|                         SumUsingLinqSum |    10 |          21.20 ns |         0.693 ns |          1.943 ns |          20.86 ns |      1.27 |     0.16 |     0.0148 |        - |        64 B |        1.00 |
|         SumUsingRangeAndRecursionElalev |    10 |         202.51 ns |         4.421 ns |         12.614 ns |         199.26 ns |     12.10 |     1.44 |     0.1111 |        - |       480 B |        7.50 |
| SumUsingRangeAndRecursionElalevWithSpan |    10 |          45.39 ns |         1.768 ns |          5.044 ns |          43.67 ns |      2.71 |     0.40 |     0.0148 |        - |        64 B |        1.00 |
|                                         |       |                   |                  |                   |                   |           |          |            |          |             |             |
|                         **SumUsingForLoop** | **10000** |      **12,308.17 ns** |       **420.055 ns** |      **1,198.440 ns** |      **11,939.03 ns** |      **1.00** |     **0.00** |     **9.1705** |        **-** |     **40024 B** |        **1.00** |
|                     SumUsingForLoopSpan | 10000 |      19,598.98 ns |       625.301 ns |      1,814.112 ns |      19,121.23 ns |      1.61 |     0.19 |     9.1553 |        - |     40024 B |        1.00 |
|                         SumUsingLinqSum | 10000 |      12,650.81 ns |       251.550 ns |        621.770 ns |      12,601.73 ns |      1.06 |     0.09 |     9.1705 |        - |     40024 B |        1.00 |
|         SumUsingRangeAndRecursionElalev | 10000 | 140,356,609.60 ns | 5,717,267.914 ns | 16,767,757.095 ns | 141,681,500.00 ns | 11,598.15 | 1,773.47 | 46000.0000 | 250.0000 | 200280120 B |    5,004.00 |
| SumUsingRangeAndRecursionElalevWithSpan | 10000 |      48,614.78 ns |     1,197.353 ns |      3,492.736 ns |      47,454.25 ns |      3.97 |     0.47 |     9.1553 |        - |     40024 B |        1.00 |
