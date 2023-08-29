# Reading files with ParallelForEachAsync, explicit async tasks, and synchronously within a Parallel.ForEach.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25941.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                                 Method | Count |        Mean |       Error |      StdDev | Ratio | RatioSD |
|--------------------------------------- |------ |------------:|------------:|------------:|------:|--------:|
|           **ReadFilesAsyncWithTakWhenAll** |    **10** |    **699.6 μs** |    **13.95 μs** |    **24.07 μs** |  **1.00** |    **0.00** |
| ReadFilesAsyncWithParallelForEachAsync |    10 |    369.0 μs |     7.07 μs |     6.61 μs |  0.52 |    0.02 |
|       ReadFilesSyncWithParallelForEach |    10 |    285.5 μs |     5.67 μs |     5.02 μs |  0.40 |    0.02 |
|                                        |       |             |             |             |       |         |
|           **ReadFilesAsyncWithTakWhenAll** |  **1000** | **68,386.1 μs** | **1,199.65 μs** | **2,395.83 μs** |  **1.00** |    **0.00** |
| ReadFilesAsyncWithParallelForEachAsync |  1000 | 25,999.4 μs |   518.55 μs |   851.99 μs |  0.38 |    0.02 |
|       ReadFilesSyncWithParallelForEach |  1000 | 20,710.1 μs |   379.42 μs |   800.33 μs |  0.30 |    0.01 |
