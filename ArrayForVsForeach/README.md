# Counting strings using a for loop vs. a foreach loop.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22463
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|           Method |   Count |             Mean |            Error |         StdDev | Ratio | RatioSD |
|----------------- |-------- |-----------------:|-----------------:|---------------:|------:|--------:|
|     **ForLoopCount** |      **10** |         **9.216 ns** |         **3.149 ns** |      **0.1726 ns** |  **1.43** |    **0.02** |
| ForEachLoopCount |      10 |         6.440 ns |         3.835 ns |      0.2102 ns |  1.00 |    0.00 |
|                  |         |                  |                  |                |       |         |
|     **ForLoopCount** |     **100** |       **106.678 ns** |        **15.022 ns** |      **0.8234 ns** |  **1.02** |    **0.01** |
| ForEachLoopCount |     100 |       104.190 ns |        13.311 ns |      0.7296 ns |  1.00 |    0.00 |
|                  |         |                  |                  |                |       |         |
|     **ForLoopCount** |    **1000** |     **1,106.320 ns** |     **1,007.886 ns** |     **55.2457 ns** |  **1.33** |    **0.05** |
| ForEachLoopCount |    1000 |       829.843 ns |       252.790 ns |     13.8563 ns |  1.00 |    0.00 |
|                  |         |                  |                  |                |       |         |
|     **ForLoopCount** |  **100000** |   **192,177.832 ns** |   **222,857.131 ns** | **12,215.5514 ns** |  **1.05** |    **0.08** |
| ForEachLoopCount |  100000 |   183,559.176 ns |   131,218.253 ns |  7,192.5152 ns |  1.00 |    0.00 |
|                  |         |                  |                  |                |       |         |
|     **ForLoopCount** | **1000000** | **3,306,030.273 ns** |   **631,316.482 ns** | **34,604.5867 ns** |  **1.01** |    **0.03** |
| ForEachLoopCount | 1000000 | 3,280,932.292 ns | 1,388,650.049 ns | 76,116.5950 ns |  1.00 |    0.00 |
