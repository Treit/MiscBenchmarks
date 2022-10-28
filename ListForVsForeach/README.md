# Counting strings in a list using different types of loops.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25231
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|                      Method |   Count |            Mean |         Error |         StdDev |          Median | Ratio | RatioSD |
|---------------------------- |-------- |----------------:|--------------:|---------------:|----------------:|------:|--------:|
|                **ForLoopCount** |      **10** |        **15.54 ns** |      **0.369 ns** |       **1.064 ns** |        **15.23 ns** |  **0.67** |    **0.09** |
|            ForEachLoopCount |      10 |        23.46 ns |      0.874 ns |       2.507 ns |        22.72 ns |  1.00 |    0.00 |
|     ListDotForEachLoopCount |      10 |        47.76 ns |      1.133 ns |       3.252 ns |        47.58 ns |  2.05 |    0.21 |
| ListExplicitEnumeratorCount |      10 |        22.97 ns |      0.566 ns |       1.624 ns |        22.58 ns |  0.99 |    0.13 |
|                             |         |                 |               |                |                 |       |         |
|                **ForLoopCount** |    **1000** |     **1,613.81 ns** |     **32.276 ns** |      **89.438 ns** |     **1,585.90 ns** |  **0.68** |    **0.04** |
|            ForEachLoopCount |    1000 |     2,380.59 ns |     43.431 ns |      74.916 ns |     2,372.33 ns |  1.00 |    0.00 |
|     ListDotForEachLoopCount |    1000 |     3,046.30 ns |     68.195 ns |     200.003 ns |     3,003.53 ns |  1.30 |    0.10 |
| ListExplicitEnumeratorCount |    1000 |     2,241.16 ns |     41.658 ns |      86.957 ns |     2,231.99 ns |  0.95 |    0.04 |
|                             |         |                 |               |                |                 |       |         |
|                **ForLoopCount** | **1000000** | **3,896,368.32 ns** | **72,418.841 ns** | **136,020.138 ns** | **3,910,994.53 ns** |  **0.94** |    **0.05** |
|            ForEachLoopCount | 1000000 | 4,154,164.29 ns | 83,055.761 ns | 155,998.851 ns | 4,108,892.58 ns |  1.00 |    0.00 |
|     ListDotForEachLoopCount | 1000000 | 4,562,872.83 ns | 99,150.281 ns | 279,655.128 ns | 4,495,239.45 ns |  1.12 |    0.09 |
| ListExplicitEnumeratorCount | 1000000 | 4,224,669.68 ns | 83,255.181 ns | 152,236.806 ns | 4,205,684.38 ns |  1.02 |    0.06 |
