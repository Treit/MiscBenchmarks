# Loops

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22572
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.200
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                                     Method |   Count |             Mean |          Error |         StdDev | Ratio | RatioSD |
|------------------------------------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
|                             **ClassicForLoop** |      **10** |         **8.731 ns** |      **0.2054 ns** |      **0.2671 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck |      10 |        10.785 ns |      0.2516 ns |      0.4663 ns |  1.23 |    0.07 |
|                              LoopUsingGoto |      10 |         9.616 ns |      0.2255 ns |      0.4008 ns |  1.10 |    0.06 |
|                                            |         |                  |                |                |       |         |
|                             **ClassicForLoop** |     **100** |        **86.830 ns** |      **1.7383 ns** |      **2.6018 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck |     100 |       107.310 ns |      1.8257 ns |      1.8748 ns |  1.24 |    0.04 |
|                              LoopUsingGoto |     100 |       157.247 ns |      2.7163 ns |      2.4079 ns |  1.81 |    0.07 |
|                                            |         |                  |                |                |       |         |
|                             **ClassicForLoop** |    **1000** |       **786.161 ns** |     **15.3237 ns** |     **15.0499 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck |    1000 |       978.473 ns |     19.4778 ns |     23.9205 ns |  1.24 |    0.04 |
|                              LoopUsingGoto |    1000 |       801.580 ns |     15.4080 ns |     20.0348 ns |  1.02 |    0.04 |
|                                            |         |                  |                |                |       |         |
|                             **ClassicForLoop** |  **100000** |    **79,702.335 ns** |  **1,587.7649 ns** |  **3,243.3829 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck |  100000 |   178,610.748 ns |  3,474.3452 ns |  3,567.8967 ns |  2.26 |    0.09 |
|                              LoopUsingGoto |  100000 |   151,367.787 ns |  2,978.5330 ns |  4,458.1279 ns |  1.91 |    0.10 |
|                                            |         |                  |                |                |       |         |
|                             **ClassicForLoop** | **1000000** |   **817,357.767 ns** | **15,843.6136 ns** | **42,015.0157 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 | 1,805,332.227 ns | 34,141.1744 ns | 35,060.4725 ns |  2.16 |    0.14 |
|                              LoopUsingGoto | 1000000 | 1,503,236.119 ns | 26,897.5687 ns | 23,843.9940 ns |  1.78 |    0.10 |
