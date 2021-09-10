## Parse vs TryParse for weeding out bad input.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22455
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                    Method |  Count |           Mean |          Error |         StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 |  Allocated |
|-------------------------- |------- |---------------:|---------------:|---------------:|------:|----------:|------:|------:|-----------:|
|    **FindValidIntsWithParse** |    **100** |     **477.513 μs** |     **427.548 μs** |     **23.4353 μs** | **1.000** |    **4.3945** |     **-** |     **-** |    **20480 B** |
| FindValidIntsWithTryParse |    100 |       1.993 μs |       1.714 μs |      0.0940 μs | 0.004 |         - |     - |     - |          - |
|                           |        |                |                |                |       |           |       |       |            |
|    **FindValidIntsWithParse** |   **1000** |   **5,169.975 μs** |   **4,917.758 μs** |    **269.5589 μs** | **1.000** |   **46.8750** |     **-** |     **-** |   **218240 B** |
| FindValidIntsWithTryParse |   1000 |      22.337 μs |       2.161 μs |      0.1185 μs | 0.004 |         - |     - |     - |          - |
|                           |        |                |                |                |       |           |       |       |            |
|    **FindValidIntsWithParse** |  **10000** |  **52,295.250 μs** |  **61,626.346 μs** |  **3,377.9480 μs** | **1.000** |  **500.0000** |     **-** |     **-** |  **2246798 B** |
| FindValidIntsWithTryParse |  10000 |     222.347 μs |      70.454 μs |      3.8618 μs | 0.004 |         - |     - |     - |        7 B |
|                           |        |                |                |                |       |           |       |       |            |
|    **FindValidIntsWithParse** | **100000** | **564,400.400 μs** | **305,180.888 μs** | **16,727.9943 μs** | **1.000** | **5000.0000** |     **-** |     **-** | **22431760 B** |
| FindValidIntsWithTryParse | 100000 |   2,478.003 μs |   2,189.518 μs |    120.0149 μs | 0.004 |         - |     - |     - |          - |
