# Counting strings using a for loop vs. a foreach loop against as list.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25125
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.300
  [Host]     : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT


```
|           Method |   Count |            Mean |         Error |        StdDev | Ratio | RatioSD |
|----------------- |-------- |----------------:|--------------:|--------------:|------:|--------:|
|     **ForLoopCount** |      **10** |        **15.81 ns** |      **0.348 ns** |      **0.628 ns** |  **0.71** |    **0.04** |
| ForEachLoopCount |      10 |        22.52 ns |      0.486 ns |      0.742 ns |  1.00 |    0.00 |
|                  |         |                 |               |               |       |         |
|     **ForLoopCount** |    **1000** |     **1,561.74 ns** |     **31.019 ns** |     **46.427 ns** |  **0.66** |    **0.03** |
| ForEachLoopCount |    1000 |     2,357.77 ns |     46.985 ns |     73.151 ns |  1.00 |    0.00 |
|                  |         |                 |               |               |       |         |
|     **ForLoopCount** | **1000000** | **3,624,095.46 ns** | **66,447.584 ns** | **62,155.111 ns** |  **0.93** |    **0.03** |
| ForEachLoopCount | 1000000 | 3,924,058.56 ns | 75,169.467 ns | 92,314.856 ns |  1.00 |    0.00 |
