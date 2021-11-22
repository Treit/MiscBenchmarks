# ForEach vs. directly using the enumerator.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22504
Unknown processor
.NET Core SDK=6.0.100
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.52210, CoreFX 6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.52210, CoreFX 6.0.21.52210), X64 RyuJIT


```
|                 Method |  Count |         Mean |       Error |      StdDev | Ratio | RatioSD |
|----------------------- |------- |-------------:|------------:|------------:|------:|--------:|
| **SumWithForEachUnsorted** |   **1000** |     **639.5 ns** |    **16.12 ns** |    **47.53 ns** |  **1.14** |    **0.12** |
|   SumWithForEachSorted |   1000 |     667.2 ns |    13.92 ns |    41.04 ns |  1.19 |    0.11 |
| MaxWithForEachUnsorted |   1000 |   1,259.6 ns |    23.53 ns |    60.32 ns |  2.22 |    0.19 |
|   MaxWithForEachSorted |   1000 |     565.2 ns |    14.61 ns |    43.07 ns |  1.00 |    0.00 |
|                        |        |              |             |             |       |         |
| **SumWithForEachUnsorted** | **100000** |  **63,024.6 ns** | **1,649.82 ns** | **4,838.62 ns** |  **1.17** |    **0.12** |
|   SumWithForEachSorted | 100000 |  64,656.0 ns | 1,397.74 ns | 4,121.26 ns |  1.20 |    0.12 |
| MaxWithForEachUnsorted | 100000 | 119,881.9 ns | 2,488.12 ns | 7,336.28 ns |  2.23 |    0.23 |
|   MaxWithForEachSorted | 100000 |  54,187.3 ns | 1,429.39 ns | 4,124.12 ns |  1.00 |    0.00 |
