# Sequential vs. different parallel techniques.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | ArraySize | NumberOfArrays | Mean        | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|---------------- |---------- |--------------- |------------:|----------:|----------:|------:|----------:|------------:|
| **Sequential**      | **10000**     | **4**              |  **2,171.8 μs** |  **15.11 μs** |  **14.13 μs** |  **1.00** |         **-** |          **NA** |
| ParallelTasks   | 10000     | 4              |    685.6 μs |  12.45 μs |  15.29 μs |  0.32 |     904 B |          NA |
| ParallelThreads | 10000     | 4              |  1,097.8 μs |  21.04 μs |  20.67 μs |  0.51 |     952 B |          NA |
| ParallelForEach | 10000     | 4              |    644.5 μs |   6.57 μs |   5.49 μs |  0.30 |    2503 B |          NA |
| ParallelFor     | 10000     | 4              |    658.9 μs |  11.78 μs |  11.02 μs |  0.30 |    2414 B |          NA |
|                 |           |                |             |           |           |       |           |             |
| **Sequential**      | **10000**     | **8**              |  **4,279.8 μs** |  **39.78 μs** |  **37.21 μs** |  **1.00** |         **-** |          **NA** |
| ParallelTasks   | 10000     | 8              |  1,029.4 μs |  19.81 μs |  18.53 μs |  0.24 |    1544 B |          NA |
| ParallelThreads | 10000     | 8              |  1,652.0 μs |  32.18 μs |  35.77 μs |  0.39 |    1880 B |          NA |
| ParallelForEach | 10000     | 8              |    791.8 μs |  15.37 μs |  22.04 μs |  0.19 |    3460 B |          NA |
| ParallelFor     | 10000     | 8              |    811.1 μs |  15.51 μs |  15.93 μs |  0.19 |    3388 B |          NA |
|                 |           |                |             |           |           |       |           |             |
| **Sequential**      | **10000**     | **64**             | **34,510.5 μs** | **302.79 μs** | **283.23 μs** |  **1.00** |         **-** |          **NA** |
| ParallelTasks   | 10000     | 64             |  4,052.3 μs |  76.87 μs |  82.26 μs |  0.12 |   10504 B |          NA |
| ParallelThreads | 10000     | 64             |  9,885.2 μs | 196.27 μs | 382.80 μs |  0.29 |   14872 B |          NA |
| ParallelForEach | 10000     | 64             |  4,328.1 μs |  85.94 μs | 200.88 μs |  0.13 |    5052 B |          NA |
| ParallelFor     | 10000     | 64             |  4,307.8 μs |  85.95 μs | 181.30 μs |  0.12 |    4967 B |          NA |
