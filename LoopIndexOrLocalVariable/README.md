# Loop using a variable vs index.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22499
Unknown processor
.NET Core SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET Core 5.0.11 (CoreCLR 5.0.1121.47308, CoreFX 5.0.1121.47308), X64 RyuJIT
  DefaultJob : .NET Core 5.0.11 (CoreCLR 5.0.1121.47308, CoreFX 5.0.1121.47308), X64 RyuJIT


```
|            Method |   Count |            Mean |         Error |         StdDev | Ratio | RatioSD |
|------------------ |-------- |----------------:|--------------:|---------------:|------:|--------:|
|    **LoopUsingIndex** |      **10** |        **16.33 ns** |      **0.419 ns** |       **1.215 ns** |  **0.95** |    **0.10** |
| LoopUsingVariable |      10 |        17.17 ns |      0.436 ns |       1.244 ns |  1.00 |    0.00 |
|                   |         |                 |               |                |       |         |
|    **LoopUsingIndex** |     **100** |       **174.71 ns** |      **3.537 ns** |       **9.623 ns** |  **0.99** |    **0.08** |
| LoopUsingVariable |     100 |       177.67 ns |      3.943 ns |      11.439 ns |  1.00 |    0.00 |
|                   |         |                 |               |                |       |         |
|    **LoopUsingIndex** |    **1000** |     **1,665.54 ns** |     **33.144 ns** |      **81.924 ns** |  **0.97** |    **0.07** |
| LoopUsingVariable |    1000 |     1,719.89 ns |     33.882 ns |      77.167 ns |  1.00 |    0.00 |
|                   |         |                 |               |                |       |         |
|    **LoopUsingIndex** |  **100000** |   **158,693.38 ns** |  **3,147.884 ns** |   **6,639.956 ns** |  **0.93** |    **0.08** |
| LoopUsingVariable |  100000 |   168,490.10 ns |  3,737.448 ns |  10,843.014 ns |  1.00 |    0.00 |
|                   |         |                 |               |                |       |         |
|    **LoopUsingIndex** | **1000000** | **1,601,894.90 ns** | **31,484.228 ns** |  **67,095.457 ns** |  **0.95** |    **0.08** |
| LoopUsingVariable | 1000000 | 1,771,824.97 ns | 64,444.732 ns | 184,904.016 ns |  1.00 |    0.00 |
