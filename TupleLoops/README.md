# Looping over sets of tuples

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22593
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                       Method | Count |              Mean |           Error |          StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------------------:|----------------:|----------------:|------:|-------:|------:|------:|----------:|
|   **ForEachOfIListOfValueTuple** |     **3** |        **213.659 ns** |       **4.3194 ns** |       **8.4246 ns** |  **1.00** | **0.0334** |     **-** |     **-** |     **144 B** |
| ForEachOfArrayOfKeyValuePair |     3 |         10.397 ns |       0.2450 ns |       0.4837 ns |  0.05 |      - |     - |     - |         - |
|   ForEachOfArrayOfValueTuple |     3 |          8.048 ns |       0.1961 ns |       0.4006 ns |  0.04 |      - |     - |     - |         - |
|                              |       |                   |                 |                 |       |        |       |       |           |
|   **ForEachOfIListOfValueTuple** |    **50** |     **36,617.348 ns** |     **723.9519 ns** |     **990.9535 ns** |  **1.00** | **0.5493** |     **-** |     **-** |    **2400 B** |
| ForEachOfArrayOfKeyValuePair |    50 |      2,270.111 ns |      45.2573 ns |      96.4470 ns |  0.06 |      - |     - |     - |         - |
|   ForEachOfArrayOfValueTuple |    50 |      1,586.733 ns |      30.7854 ns |      54.7210 ns |  0.04 |      - |     - |     - |         - |
|                              |       |                   |                 |                 |       |        |       |       |           |
|   **ForEachOfIListOfValueTuple** |  **1000** | **14,236,891.243 ns** | **281,939.6407 ns** | **556,521.3445 ns** |  **1.00** |      **-** |     **-** |     **-** |   **48008 B** |
| ForEachOfArrayOfKeyValuePair |  1000 |    906,001.972 ns |  17,767.4265 ns |  30,170.4385 ns |  0.06 |      - |     - |     - |         - |
|   ForEachOfArrayOfValueTuple |  1000 |    628,220.018 ns |  12,560.3781 ns |  25,657.5240 ns |  0.04 |      - |     - |     - |         - |
