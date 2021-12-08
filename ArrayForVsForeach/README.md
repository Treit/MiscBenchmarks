# Counting strings using a for loop vs. a foreach loop.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22509
Unknown processor
.NET Core SDK=6.0.100
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|           Method |   Count |             Mean |          Error |         StdDev | Ratio | RatioSD |
|----------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
|     **ForLoopCount** |      **10** |         **9.564 ns** |      **0.2278 ns** |      **0.4166 ns** |  **1.11** |    **0.06** |
| ForEachLoopCount |      10 |         8.631 ns |      0.2063 ns |      0.3447 ns |  1.00 |    0.00 |
|                  |         |                  |                |                |       |         |
|     **ForLoopCount** |     **100** |       **112.951 ns** |      **2.2398 ns** |      **2.3002 ns** |  **1.05** |    **0.03** |
| ForEachLoopCount |     100 |       107.996 ns |      2.1683 ns |      3.1097 ns |  1.00 |    0.00 |
|                  |         |                  |                |                |       |         |
|     **ForLoopCount** |    **1000** |     **1,166.957 ns** |     **23.2702 ns** |     **49.5907 ns** |  **1.29** |    **0.08** |
| ForEachLoopCount |    1000 |       900.396 ns |     17.6818 ns |     34.0668 ns |  1.00 |    0.00 |
|                  |         |                  |                |                |       |         |
|     **ForLoopCount** |  **100000** |   **135,403.537 ns** |  **2,852.9746 ns** |  **8,412.0600 ns** |  **1.05** |    **0.09** |
| ForEachLoopCount |  100000 |   129,754.957 ns |  2,868.5587 ns |  8,458.0101 ns |  1.00 |    0.00 |
|                  |         |                  |                |                |       |         |
|     **ForLoopCount** | **1000000** | **3,548,903.004 ns** | **68,850.6008 ns** | **81,961.7426 ns** |  **1.04** |    **0.04** |
| ForEachLoopCount | 1000000 | 3,404,728.776 ns | 65,763.5041 ns | 92,191.2481 ns |  1.00 |    0.00 |
