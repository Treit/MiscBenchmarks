# Serializing the data from GC.GetGCMemoryInfo



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Count   | Mean            | Error         | StdDev        | Ratio | Gen0        | Allocated     | Alloc Ratio |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|------:|------------:|--------------:|------------:|
| **SerializeGCMemoryInfo**                      | **10**      |        **19.70 μs** |      **0.158 μs** |      **0.147 μs** |  **1.00** |      **1.6785** |      **27.86 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 10      |        20.82 μs |      0.187 μs |      0.175 μs |  1.06 |      1.7700 |      29.27 KB |        1.05 |
|                                            |         |                 |               |               |       |             |               |             |
| **SerializeGCMemoryInfo**                      | **1000**    |     **1,993.98 μs** |     **16.656 μs** |     **15.580 μs** |  **1.00** |    **167.9688** |    **2765.91 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 1000    |     2,076.29 μs |     24.118 μs |     22.560 μs |  1.04 |    175.7813 |    2906.53 KB |        1.05 |
|                                            |         |                 |               |               |       |             |               |             |
| **SerializeGCMemoryInfo**                      | **1000000** | **1,963,559.26 μs** |  **8,821.827 μs** |  **7,366.625 μs** |  **1.00** | **169000.0000** | **2765625.28 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 1000000 | 2,070,502.33 μs | 13,318.454 μs | 12,458.090 μs |  1.05 | 177000.0000 | 2906250.28 KB |        1.05 |
