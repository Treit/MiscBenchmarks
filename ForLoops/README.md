# Loops




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26254.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                     | Count   | Mean             | Error          | StdDev         | Median           | Ratio | RatioSD |
|------------------------------------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
| **ClassicForLoop**                             | **100**     |         **69.92 ns** |       **1.330 ns** |       **1.179 ns** |         **69.47 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | 100     |         73.15 ns |       1.471 ns |       3.290 ns |         71.98 ns |  1.04 |    0.04 |
| LoopUsingGoto                              | 100     |         78.36 ns |       1.349 ns |       1.196 ns |         78.00 ns |  1.12 |    0.03 |
| LoopUsingEnumerableRange                   | 100     |        280.46 ns |       5.231 ns |       4.893 ns |        281.44 ns |  4.02 |    0.09 |
| LoopUsingRangeEnumerator                   | 100     |         76.71 ns |       1.639 ns |       4.729 ns |         75.86 ns |  1.16 |    0.07 |
| LoopUsingSkipAny                           | 100     |      2,421.20 ns |      66.377 ns |     191.513 ns |      2,399.12 ns | 33.22 |    2.31 |
|                                            |         |                  |                |                |                  |       |         |
| **ClassicForLoop**                             | **1000000** |    **653,696.34 ns** |  **12,174.939 ns** |  **20,673.970 ns** |    **650,860.79 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 |    663,523.77 ns |  13,018.490 ns |  33,136.214 ns |    654,743.95 ns |  1.03 |    0.06 |
| LoopUsingGoto                              | 1000000 |    735,450.62 ns |  12,494.472 ns |  10,433.450 ns |    735,412.60 ns |  1.11 |    0.04 |
| LoopUsingEnumerableRange                   | 1000000 |  2,546,854.69 ns |  32,810.804 ns |  43,801.481 ns |  2,541,549.22 ns |  3.89 |    0.16 |
| LoopUsingRangeEnumerator                   | 1000000 |    650,641.05 ns |  12,834.649 ns |  13,732.930 ns |    649,753.71 ns |  0.99 |    0.04 |
| LoopUsingSkipAny                           | 1000000 | 21,412,228.94 ns | 424,269.928 ns | 594,767.184 ns | 21,204,153.12 ns | 32.71 |    0.92 |
