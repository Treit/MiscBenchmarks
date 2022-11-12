# Sequential vs. different parallel techniques.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25241
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|          Method | ArraySize | NumberOfArrays |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |---------- |--------------- |----------:|----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|      **Sequential** |     **10000** |              **4** |  **3.494 ms** | **0.0661 ms** | **0.1610 ms** |  **3.425 ms** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |       **4 B** |
|   ParallelTasks |     10000 |              4 |  1.353 ms | 0.0212 ms | 0.0188 ms |  1.353 ms |  0.37 |    0.02 |     - |     - |     - |     818 B |
| ParallelThreads |     10000 |              4 |  1.935 ms | 0.0538 ms | 0.1554 ms |  1.918 ms |  0.55 |    0.04 |     - |     - |     - |     954 B |
| ParallelForEach |     10000 |              4 |  1.340 ms | 0.0509 ms | 0.1499 ms |  1.294 ms |  0.37 |    0.04 |     - |     - |     - |    2461 B |
|     ParallelFor |     10000 |              4 |  1.339 ms | 0.0396 ms | 0.1168 ms |  1.327 ms |  0.39 |    0.03 |     - |     - |     - |    2404 B |
|                 |           |                |           |           |           |           |       |         |       |       |       |           |
|      **Sequential** |     **10000** |              **8** |  **7.135 ms** | **0.1329 ms** | **0.1178 ms** |  **7.093 ms** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |       **4 B** |
|   ParallelTasks |     10000 |              8 |  1.708 ms | 0.0332 ms | 0.0454 ms |  1.696 ms |  0.24 |    0.01 |     - |     - |     - |    1481 B |
| ParallelThreads |     10000 |              8 |  3.828 ms | 0.2783 ms | 0.7711 ms |  3.627 ms |  0.52 |    0.03 |     - |     - |     - |    1882 B |
| ParallelForEach |     10000 |              8 |  1.823 ms | 0.0362 ms | 0.0653 ms |  1.818 ms |  0.25 |    0.01 |     - |     - |     - |    2962 B |
|     ParallelFor |     10000 |              8 |  2.312 ms | 0.0698 ms | 0.2047 ms |  2.328 ms |  0.28 |    0.03 |     - |     - |     - |    2957 B |
|                 |           |                |           |           |           |           |       |         |       |       |       |           |
|      **Sequential** |     **10000** |             **64** | **59.302 ms** | **1.1729 ms** | **2.1448 ms** | **58.942 ms** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |      **53 B** |
|   ParallelTasks |     10000 |             64 | 12.152 ms | 0.0745 ms | 0.0622 ms | 12.150 ms |  0.20 |    0.01 |     - |     - |     - |   10912 B |
| ParallelThreads |     10000 |             64 | 23.174 ms | 0.9250 ms | 2.6541 ms | 22.947 ms |  0.40 |    0.04 |     - |     - |     - |   14887 B |
| ParallelForEach |     10000 |             64 | 12.628 ms | 0.2498 ms | 0.2337 ms | 12.542 ms |  0.21 |    0.01 |     - |     - |     - |    3154 B |
|     ParallelFor |     10000 |             64 | 12.167 ms | 0.1267 ms | 0.1692 ms | 12.134 ms |  0.20 |    0.01 |     - |     - |     - |    3085 B |
