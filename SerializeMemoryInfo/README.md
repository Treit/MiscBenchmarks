# Serializing the data from GC.GetGCMemoryInfo




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Count   | Mean            | Error         | StdDev        | Ratio | RatioSD | Gen0        | Allocated     | Alloc Ratio |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|------:|--------:|------------:|--------------:|------------:|
| **SerializeGCMemoryInfo**                      | **10**      |        **20.27 μs** |      **0.160 μs** |      **0.142 μs** |  **1.00** |    **0.01** |      **1.6785** |      **27.86 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 10      |        20.85 μs |      0.223 μs |      0.198 μs |  1.03 |    0.01 |      1.7700 |      29.27 KB |        1.05 |
|                                            |         |                 |               |               |       |         |             |               |             |
| **SerializeGCMemoryInfo**                      | **1000**    |     **1,990.58 μs** |     **23.473 μs** |     **21.956 μs** |  **1.00** |    **0.02** |    **167.9688** |    **2765.91 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 1000    |     2,075.83 μs |     20.573 μs |     19.244 μs |  1.04 |    0.01 |    175.7813 |    2906.53 KB |        1.05 |
|                                            |         |                 |               |               |       |         |             |               |             |
| **SerializeGCMemoryInfo**                      | **1000000** | **2,047,268.43 μs** | **12,588.282 μs** | **11,775.087 μs** |  **1.00** |    **0.01** | **169000.0000** | **2765625.28 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 1000000 | 2,140,653.22 μs | 11,701.735 μs | 10,945.810 μs |  1.05 |    0.01 | 177000.0000 | 2906250.28 KB |        1.05 |
