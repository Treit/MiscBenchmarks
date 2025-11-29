# Reading files with ParallelForEachAsync, explicit async tasks, and synchronously within a Parallel.ForEach.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Job       | Runtime   | Count | Mean        | Error       | StdDev      | Ratio | RatioSD | Gen0      | Gen1     | Allocated   | Alloc Ratio |
|--------------------------------------- |---------- |---------- |------ |------------:|------------:|------------:|------:|--------:|----------:|---------:|------------:|------------:|
| **ReadFilesAsyncWithTakWhenAll**           | **.NET 10.0** | **.NET 10.0** | **10**    |    **711.4 μs** |    **10.33 μs** |     **9.16 μs** |  **1.00** |    **0.02** |    **5.8594** |   **0.9766** |   **106.33 KB** |        **1.00** |
| ReadFilesAsyncWithTakWhenAllTebeco     | .NET 10.0 | .NET 10.0 | 10    |    710.3 μs |     8.63 μs |     8.07 μs |  1.00 |    0.02 |    5.8594 |   0.9766 |   106.34 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | .NET 10.0 | .NET 10.0 | 10    |    330.0 μs |     5.44 μs |     4.82 μs |  0.46 |    0.01 |   10.7422 |   0.9766 |   108.37 KB |        1.02 |
| ReadFilesSyncWithParallelForEach       | .NET 10.0 | .NET 10.0 | 10    |    239.7 μs |     4.65 μs |     5.53 μs |  0.34 |    0.01 |   10.7422 |   0.4883 |   104.21 KB |        0.98 |
|                                        |           |           |       |             |             |             |       |         |           |          |             |             |
| ReadFilesAsyncWithTakWhenAll           | .NET 9.0  | .NET 9.0  | 10    |    711.3 μs |    10.75 μs |     9.53 μs |  1.00 |    0.02 |    5.8594 |   0.9766 |   106.33 KB |        1.00 |
| ReadFilesAsyncWithTakWhenAllTebeco     | .NET 9.0  | .NET 9.0  | 10    |    710.7 μs |     9.79 μs |     8.68 μs |  1.00 |    0.02 |    5.8594 |   0.9766 |   106.34 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | .NET 9.0  | .NET 9.0  | 10    |    335.6 μs |     5.86 μs |     5.48 μs |  0.47 |    0.01 |   10.7422 |   0.9766 |   108.33 KB |        1.02 |
| ReadFilesSyncWithParallelForEach       | .NET 9.0  | .NET 9.0  | 10    |    241.9 μs |     4.50 μs |     6.87 μs |  0.34 |    0.01 |   10.7422 |   0.4883 |   104.21 KB |        0.98 |
|                                        |           |           |       |             |             |             |       |         |           |          |             |             |
| **ReadFilesAsyncWithTakWhenAll**           | **.NET 10.0** | **.NET 10.0** | **1000**  | **67,284.7 μs** | **1,180.23 μs** | **1,103.99 μs** |  **1.00** |    **0.02** |  **625.0000** | **500.0000** | **10586.97 KB** |        **1.00** |
| ReadFilesAsyncWithTakWhenAllTebeco     | .NET 10.0 | .NET 10.0 | 1000  | 67,773.5 μs | 1,063.68 μs |   994.96 μs |  1.01 |    0.02 |  625.0000 | 500.0000 | 10586.97 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | .NET 10.0 | .NET 10.0 | 1000  | 13,483.1 μs |   166.42 μs |   155.67 μs |  0.20 |    0.00 | 1109.3750 | 531.2500 | 10659.78 KB |        1.01 |
| ReadFilesSyncWithParallelForEach       | .NET 10.0 | .NET 10.0 | 1000  |  8,395.9 μs |   139.89 μs |   143.65 μs |  0.12 |    0.00 | 1093.7500 | 187.5000 | 10101.97 KB |        0.95 |
|                                        |           |           |       |             |             |             |       |         |           |          |             |             |
| ReadFilesAsyncWithTakWhenAll           | .NET 9.0  | .NET 9.0  | 1000  | 68,667.8 μs | 1,303.84 μs | 1,155.82 μs |  1.00 |    0.02 |  625.0000 | 500.0000 | 10586.93 KB |        1.00 |
| ReadFilesAsyncWithTakWhenAllTebeco     | .NET 9.0  | .NET 9.0  | 1000  | 67,877.0 μs | 1,281.19 μs | 1,424.04 μs |  0.99 |    0.03 |  625.0000 | 500.0000 | 10586.97 KB |        1.00 |
| ReadFilesAsyncWithParallelForEachAsync | .NET 9.0  | .NET 9.0  | 1000  | 13,532.1 μs |   184.35 μs |   163.42 μs |  0.20 |    0.00 | 1109.3750 | 500.0000 | 10669.12 KB |        1.01 |
| ReadFilesSyncWithParallelForEach       | .NET 9.0  | .NET 9.0  | 1000  |  8,461.4 μs |   164.78 μs |   219.98 μs |  0.12 |    0.00 | 1093.7500 | 187.5000 | 10102.99 KB |        0.95 |
