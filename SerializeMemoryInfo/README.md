# Serializing the data from GC.GetGCMemoryInfo


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                     Method |   Count |            Mean |         Error |        StdDev | Ratio |        Gen0 |     Allocated | Alloc Ratio |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|------:|------------:|--------------:|------------:|
|                      **SerializeGCMemoryInfo** |      **10** |        **23.34 μs** |      **0.077 μs** |      **0.072 μs** |  **1.00** |      **1.7090** |      **27.94 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect |      10 |        25.21 μs |      0.179 μs |      0.167 μs |  1.08 |      1.7700 |      29.34 KB |        1.05 |
|                                            |         |                 |               |               |       |             |               |             |
|                      **SerializeGCMemoryInfo** |    **1000** |     **2,378.39 μs** |     **17.966 μs** |     **16.806 μs** |  **1.00** |    **167.9688** |    **2773.72 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect |    1000 |     2,498.99 μs |      5.223 μs |      4.630 μs |  1.05 |    175.7813 |    2914.35 KB |        1.05 |
|                                            |         |                 |               |               |       |             |               |             |
|                      **SerializeGCMemoryInfo** | **1000000** | **2,373,307.63 μs** |  **8,669.854 μs** |  **8,109.787 μs** |  **1.00** | **169000.0000** |    **2765626 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 1000000 | 2,444,296.24 μs | 14,361.100 μs | 12,730.741 μs |  1.03 | 177000.0000 | 2906250.34 KB |        1.05 |
