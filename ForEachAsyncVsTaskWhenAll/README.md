# Reading files with ParallelForEachAsync, explicit async tasks, and synchronously within a Parallel.ForEach.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25941.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                                 Method | Count |        Mean |       Error |      StdDev | Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 |   Allocated | Alloc Ratio |
|--------------------------------------- |------ |------------:|------------:|------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
|           **ReadFilesAsyncWithTakWhenAll** |    **10** |    **727.9 μs** |    **14.49 μs** |    **34.15 μs** |  **1.00** |    **0.00** |   **25.3906** |    **4.8828** |        **-** |   **107.79 KB** |        **1.00** |
| ReadFilesAsyncWithParallelForEachAsync |    10 |    370.0 μs |     5.47 μs |     5.12 μs |  0.51 |    0.02 |   42.4805 |    1.9531 |        - |    109.5 KB |        1.02 |
|       ReadFilesSyncWithParallelForEach |    10 |    282.5 μs |     2.21 μs |     1.72 μs |  0.39 |    0.01 |   42.4805 |    1.9531 |        - |   105.18 KB |        0.98 |
|                                        |       |             |             |             |       |         |           |           |          |             |             |
|           **ReadFilesAsyncWithTakWhenAll** |  **1000** | **69,722.1 μs** | **1,392.35 μs** | **2,649.09 μs** |  **1.00** |    **0.00** | **1714.2857** |  **857.1429** | **142.8571** | **10727.56 KB** |        **1.00** |
| ReadFilesAsyncWithParallelForEachAsync |  1000 | 25,095.8 μs |   493.73 μs |   507.03 μs |  0.36 |    0.02 | 4312.5000 | 1062.5000 |        - | 10804.42 KB |        1.01 |
|       ReadFilesSyncWithParallelForEach |  1000 | 19,687.5 μs |   384.71 μs |   411.63 μs |  0.28 |    0.02 | 4250.0000 |   62.5000 |        - | 10191.75 KB |        0.95 |
