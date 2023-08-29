# Reading files with ParallelForEachAsync, explicit async tasks, and synchronously within a Parallel.ForEach.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25941.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                                 Method | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 |   Allocated | Alloc Ratio |
|--------------------------------------- |------ |------------:|------------:|------------:|------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
|           **ReadFilesAsyncWithTakWhenAll** |    **10** |    **712.9 μs** |    **14.03 μs** |    **36.47 μs** |    **700.1 μs** |  **1.00** |    **0.00** |   **25.3906** |    **4.8828** |        **-** |   **107.79 KB** |        **1.00** |
|     ReadFilesAsyncWithTakWhenAllTebeco |    10 |    715.5 μs |    13.96 μs |    34.51 μs |    713.1 μs |  1.00 |    0.07 |   25.3906 |    4.8828 |        - |    107.8 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync |    10 |    372.2 μs |     6.85 μs |     6.40 μs |    369.9 μs |  0.52 |    0.04 |   42.4805 |    0.4883 |        - |   109.49 KB |        1.02 |
|       ReadFilesSyncWithParallelForEach |    10 |    286.5 μs |     4.80 μs |     4.49 μs |    285.5 μs |  0.40 |    0.03 |   42.4805 |    0.9766 |        - |   105.18 KB |        0.98 |
|                                        |       |             |             |             |             |       |         |           |           |          |             |             |
|           **ReadFilesAsyncWithTakWhenAll** |  **1000** | **67,534.7 μs** | **1,341.20 μs** | **2,277.46 μs** | **67,734.9 μs** |  **1.00** |    **0.00** | **1750.0000** |  **750.0000** | **125.0000** |  **10727.5 KB** |        **1.00** |
|     ReadFilesAsyncWithTakWhenAllTebeco |  1000 | 69,107.0 μs | 1,259.30 μs | 1,177.95 μs | 69,051.2 μs |  1.00 |    0.03 | 1750.0000 |  750.0000 | 125.0000 | 10728.55 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync |  1000 | 25,223.4 μs |   288.92 μs |   241.26 μs | 25,200.9 μs |  0.36 |    0.01 | 4312.5000 | 1062.5000 |        - | 10804.29 KB |        1.01 |
|       ReadFilesSyncWithParallelForEach |  1000 | 20,418.2 μs |   378.15 μs |   530.11 μs | 20,469.5 μs |  0.30 |    0.02 | 4250.0000 |  156.2500 |        - | 10193.54 KB |        0.95 |
