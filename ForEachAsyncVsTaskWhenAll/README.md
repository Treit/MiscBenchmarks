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
| **ReadFilesAsyncWithTakWhenAll**           | **10**    |    **739.1 μs** |    **13.40 μs** |    **13.16 μs** |  **1.00** |    **0.02** |    **5.8594** |   **0.9766** |   **106.33 KB** |        **1.00** |
| ReadFilesAsyncWithTakWhenAllTebeco     | 10    |    743.8 μs |    12.55 μs |    11.74 μs |  1.01 |    0.02 |    5.8594 |   0.9766 |   106.34 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | 10    |    312.5 μs |     3.86 μs |     3.42 μs |  0.42 |    0.01 |   10.7422 |   0.9766 |   108.41 KB |        1.02 |
| ReadFilesSyncWithParallelForEach       | 10    |    233.1 μs |     4.52 μs |     4.23 μs |  0.32 |    0.01 |   10.7422 |   0.4883 |   104.23 KB |        0.98 |
|                                        |       |             |             |             |       |         |           |          |             |             |
| **ReadFilesAsyncWithTakWhenAll**           | **1000**  | **72,624.8 μs** | **1,407.41 μs** | **1,728.43 μs** |  **1.00** |    **0.03** |  **571.4286** | **428.5714** | **10586.95 KB** |        **1.00** |
| ReadFilesAsyncWithTakWhenAllTebeco     | 1000  | 73,006.6 μs | 1,417.40 μs | 1,325.83 μs |  1.01 |    0.03 |  571.4286 | 428.5714 | 10586.89 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | 1000  | 13,247.7 μs |   188.65 μs |   176.46 μs |  0.18 |    0.00 | 1109.3750 | 531.2500 | 10662.37 KB |        1.01 |
| ReadFilesSyncWithParallelForEach       | 1000  |  8,588.3 μs |   157.90 μs |   139.97 μs |  0.12 |    0.00 | 1093.7500 | 187.5000 | 10101.47 KB |        0.95 |
