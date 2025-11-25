# Reading files with ParallelForEachAsync, explicit async tasks, and synchronously within a Parallel.ForEach.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Count | Mean        | Error       | StdDev      | Ratio | RatioSD | Gen0      | Gen1     | Allocated   | Alloc Ratio |
|--------------------------------------- |------ |------------:|------------:|------------:|------:|--------:|----------:|---------:|------------:|------------:|
| **ReadFilesAsyncWithTakWhenAll**           | **10**    |    **731.2 μs** |    **10.70 μs** |    **10.01 μs** |  **1.00** |    **0.02** |    **5.8594** |   **0.9766** |   **106.32 KB** |        **1.00** |
| ReadFilesAsyncWithTakWhenAllTebeco     | 10    |    742.1 μs |    12.10 μs |    11.32 μs |  1.02 |    0.02 |    5.8594 |   0.9766 |   106.34 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | 10    |    316.6 μs |     6.10 μs |     7.02 μs |  0.43 |    0.01 |   10.7422 |   0.9766 |   108.41 KB |        1.02 |
| ReadFilesSyncWithParallelForEach       | 10    |    231.1 μs |     3.44 μs |     2.87 μs |  0.32 |    0.01 |   10.7422 |        - |   104.24 KB |        0.98 |
|                                        |       |             |             |             |       |         |           |          |             |             |
| **ReadFilesAsyncWithTakWhenAll**           | **1000**  | **72,605.8 μs** | **1,391.13 μs** | **1,546.24 μs** |  **1.00** |    **0.03** |  **571.4286** | **428.5714** | **10586.97 KB** |        **1.00** |
| ReadFilesAsyncWithTakWhenAllTebeco     | 1000  | 72,520.8 μs | 1,030.00 μs |   963.46 μs |  1.00 |    0.02 |  571.4286 | 428.5714 | 10586.95 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | 1000  | 13,345.6 μs |   148.08 μs |   131.27 μs |  0.18 |    0.00 | 1109.3750 | 500.0000 | 10669.64 KB |        1.01 |
| ReadFilesSyncWithParallelForEach       | 1000  |  8,584.9 μs |   168.07 μs |   172.60 μs |  0.12 |    0.00 | 1093.7500 | 171.8750 | 10101.93 KB |        0.95 |
