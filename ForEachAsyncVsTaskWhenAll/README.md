# Reading files with ParallelForEachAsync, explicit async tasks, and synchronously within a Parallel.ForEach.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                 Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |      Gen0 |     Gen1 |   Allocated | Alloc Ratio |
|--------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|----------:|---------:|------------:|------------:|
|           **ReadFilesAsyncWithTakWhenAll** |    **10** |    **593.2 μs** |   **9.73 μs** |   **9.55 μs** |  **1.00** |    **0.00** |    **5.8594** |   **0.9766** |   **106.32 KB** |        **1.00** |
|     ReadFilesAsyncWithTakWhenAllTebeco |    10 |    588.0 μs |   2.45 μs |   2.17 μs |  0.99 |    0.01 |    5.8594 |   0.9766 |   106.34 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync |    10 |    276.0 μs |   1.26 μs |   1.05 μs |  0.46 |    0.01 |   10.7422 |   1.4648 |   108.45 KB |        1.02 |
|       ReadFilesSyncWithParallelForEach |    10 |    182.5 μs |   1.70 μs |   1.59 μs |  0.31 |    0.01 |   10.9863 |   0.4883 |   104.17 KB |        0.98 |
|                                        |       |             |           |           |       |         |           |          |             |             |
|           **ReadFilesAsyncWithTakWhenAll** |  **1000** | **57,750.1 μs** | **949.60 μs** | **888.25 μs** |  **1.00** |    **0.00** |  **555.5556** | **444.4444** | **10586.92 KB** |        **1.00** |
|     ReadFilesAsyncWithTakWhenAllTebeco |  1000 | 57,773.9 μs | 851.11 μs | 796.13 μs |  1.00 |    0.02 |  555.5556 | 444.4444 | 10586.93 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync |  1000 | 13,904.3 μs | 180.61 μs | 150.82 μs |  0.24 |    0.00 | 1109.3750 | 609.3750 | 10669.15 KB |        1.01 |
|       ReadFilesSyncWithParallelForEach |  1000 | 12,925.5 μs | 253.53 μs | 476.20 μs |  0.22 |    0.01 | 1093.7500 | 109.3750 | 10105.77 KB |        0.95 |
