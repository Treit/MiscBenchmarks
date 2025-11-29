# Serializing the data from GC.GetGCMemoryInfo





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Job       | Runtime   | Count   | Mean            | Error         | StdDev        | Ratio | Gen0        | Allocated     | Alloc Ratio |
|------------------------------------------- |---------- |---------- |-------- |----------------:|--------------:|--------------:|------:|------------:|--------------:|------------:|
| **SerializeGCMemoryInfo**                      | **.NET 10.0** | **.NET 10.0** | **10**      |        **19.89 μs** |      **0.227 μs** |      **0.212 μs** |  **1.00** |      **1.6785** |      **27.86 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | .NET 10.0 | .NET 10.0 | 10      |        20.57 μs |      0.110 μs |      0.097 μs |  1.03 |      1.7700 |      29.27 KB |        1.05 |
|                                            |           |           |         |                 |               |               |       |             |               |             |
| SerializeGCMemoryInfo                      | .NET 9.0  | .NET 9.0  | 10      |        19.68 μs |      0.171 μs |      0.160 μs |  1.00 |      1.6785 |      27.86 KB |        1.00 |
| SerializeGCMemoryInfoWithUnnecessarySelect | .NET 9.0  | .NET 9.0  | 10      |        20.64 μs |      0.124 μs |      0.116 μs |  1.05 |      1.7700 |      29.27 KB |        1.05 |
|                                            |           |           |         |                 |               |               |       |             |               |             |
| **SerializeGCMemoryInfo**                      | **.NET 10.0** | **.NET 10.0** | **1000**    |     **1,958.87 μs** |     **10.829 μs** |     **10.130 μs** |  **1.00** |    **167.9688** |    **2765.91 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | .NET 10.0 | .NET 10.0 | 1000    |     2,031.03 μs |     17.316 μs |     16.197 μs |  1.04 |    175.7813 |    2906.53 KB |        1.05 |
|                                            |           |           |         |                 |               |               |       |             |               |             |
| SerializeGCMemoryInfo                      | .NET 9.0  | .NET 9.0  | 1000    |     1,942.93 μs |     15.445 μs |     12.897 μs |  1.00 |    167.9688 |    2765.91 KB |        1.00 |
| SerializeGCMemoryInfoWithUnnecessarySelect | .NET 9.0  | .NET 9.0  | 1000    |     2,045.86 μs |      9.721 μs |      9.093 μs |  1.05 |    175.7813 |    2906.53 KB |        1.05 |
|                                            |           |           |         |                 |               |               |       |             |               |             |
| **SerializeGCMemoryInfo**                      | **.NET 10.0** | **.NET 10.0** | **1000000** | **1,993,811.45 μs** |  **7,947.609 μs** |  **7,434.198 μs** |  **1.00** | **169000.0000** | **2765625.28 KB** |        **1.00** |
| SerializeGCMemoryInfoWithUnnecessarySelect | .NET 10.0 | .NET 10.0 | 1000000 | 2,032,554.55 μs |  5,462.167 μs |  4,842.069 μs |  1.02 | 177000.0000 | 2906250.28 KB |        1.05 |
|                                            |           |           |         |                 |               |               |       |             |               |             |
| SerializeGCMemoryInfo                      | .NET 9.0  | .NET 9.0  | 1000000 | 2,031,624.91 μs | 12,669.094 μs | 11,230.822 μs |  1.00 | 169000.0000 | 2765625.28 KB |        1.00 |
| SerializeGCMemoryInfoWithUnnecessarySelect | .NET 9.0  | .NET 9.0  | 1000000 | 2,117,314.69 μs | 18,587.896 μs | 15,521.735 μs |  1.04 | 177000.0000 | 2906250.28 KB |        1.05 |
