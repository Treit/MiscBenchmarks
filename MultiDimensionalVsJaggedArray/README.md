# Multidimensional vs. Jagged arrays.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22509
Unknown processor
.NET Core SDK=6.0.100
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.52210, CoreFX 6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.52210, CoreFX 6.0.21.52210), X64 RyuJIT


```
|                                 Method | Size |             Mean |          Error |         StdDev | Ratio | RatioSD |
|--------------------------------------- |----- |-----------------:|---------------:|---------------:|------:|--------:|
|                              **SumJagged** |    **4** |        **14.086 ns** |      **0.3162 ns** |      **0.5782 ns** |  **0.65** |    **0.04** |
|                    SumMultiDimensional |    4 |        22.088 ns |      0.4707 ns |      0.6283 ns |  1.00 |    0.00 |
|     SumMultiDimensionalReversedIndexes |    4 |        21.998 ns |      0.4730 ns |      0.7638 ns |  1.00 |    0.05 |
|               SumJaggedReversedIndexes |    4 |        14.282 ns |      0.3194 ns |      0.7467 ns |  0.65 |    0.04 |
|                          SumJaggedKozi |    4 |         9.212 ns |      0.2134 ns |      0.4639 ns |  0.41 |    0.02 |
|               SumMultiDimensionalGoose |    4 |        21.464 ns |      0.4596 ns |      1.1945 ns |  0.99 |    0.07 |
|                         SumJaggedGoose |    4 |        13.734 ns |      0.3113 ns |      0.7215 ns |  0.63 |    0.03 |
| SumKoziSupperOptimizedWithReadOnlySpan |    4 |         7.851 ns |      0.1916 ns |      0.5048 ns |  0.36 |    0.03 |
|                                        |      |                  |                |                |       |         |
|                              **SumJagged** |   **10** |        **77.723 ns** |      **1.5904 ns** |      **3.5243 ns** |  **0.67** |    **0.04** |
|                    SumMultiDimensional |   10 |       116.340 ns |      2.3632 ns |      5.4298 ns |  1.00 |    0.00 |
|     SumMultiDimensionalReversedIndexes |   10 |       115.646 ns |      2.3546 ns |      4.3056 ns |  1.00 |    0.05 |
|               SumJaggedReversedIndexes |   10 |        76.537 ns |      1.5570 ns |      3.8485 ns |  0.66 |    0.04 |
|                          SumJaggedKozi |   10 |        45.995 ns |      0.9516 ns |      2.1086 ns |  0.40 |    0.03 |
|               SumMultiDimensionalGoose |   10 |       124.161 ns |      2.4976 ns |      5.9841 ns |  1.07 |    0.08 |
|                         SumJaggedGoose |   10 |        67.621 ns |      1.3866 ns |      3.3223 ns |  0.58 |    0.04 |
| SumKoziSupperOptimizedWithReadOnlySpan |   10 |        52.843 ns |      1.0843 ns |      2.0366 ns |  0.45 |    0.03 |
|                                        |      |                  |                |                |       |         |
|                              **SumJagged** |  **100** |     **7,396.521 ns** |    **144.2413 ns** |    **236.9925 ns** |  **0.66** |    **0.02** |
|                    SumMultiDimensional |  100 |    11,273.073 ns |    220.4851 ns |    301.8024 ns |  1.00 |    0.00 |
|     SumMultiDimensionalReversedIndexes |  100 |    11,229.417 ns |    219.2404 ns |    307.3444 ns |  1.00 |    0.03 |
|               SumJaggedReversedIndexes |  100 |     7,546.276 ns |    149.6485 ns |    312.3722 ns |  0.68 |    0.03 |
|                          SumJaggedKozi |  100 |     5,180.408 ns |    103.3158 ns |    160.8503 ns |  0.46 |    0.02 |
|               SumMultiDimensionalGoose |  100 |    12,745.712 ns |    253.1449 ns |    550.3162 ns |  1.11 |    0.05 |
|                         SumJaggedGoose |  100 |     7,102.950 ns |    148.0318 ns |    431.8157 ns |  0.63 |    0.04 |
| SumKoziSupperOptimizedWithReadOnlySpan |  100 |     4,468.564 ns |     87.3561 ns |    145.9524 ns |  0.40 |    0.02 |
|                                        |      |                  |                |                |       |         |
|                              **SumJagged** | **1024** |   **739,746.989 ns** | **14,707.8503 ns** | **28,686.5325 ns** |  **0.65** |    **0.04** |
|                    SumMultiDimensional | 1024 | 1,133,884.866 ns | 22,135.5315 ns | 51,302.4602 ns |  1.00 |    0.00 |
|     SumMultiDimensionalReversedIndexes | 1024 | 2,157,825.919 ns | 41,457.3125 ns | 96,905.1316 ns |  1.91 |    0.12 |
|               SumJaggedReversedIndexes | 1024 | 1,322,129.385 ns | 26,355.6400 ns | 60,025.1293 ns |  1.17 |    0.07 |
|                          SumJaggedKozi | 1024 |   475,998.460 ns |  9,473.8118 ns | 14,179.9554 ns |  0.42 |    0.03 |
|               SumMultiDimensionalGoose | 1024 | 1,291,975.114 ns | 25,560.4598 ns | 65,521.2301 ns |  1.15 |    0.08 |
|                         SumJaggedGoose | 1024 |   664,117.901 ns | 13,156.1688 ns | 25,347.4708 ns |  0.59 |    0.03 |
| SumKoziSupperOptimizedWithReadOnlySpan | 1024 |   477,127.665 ns |  9,461.7305 ns | 20,367.3730 ns |  0.42 |    0.02 |
