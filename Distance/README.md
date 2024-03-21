# Distance calculation for two vectors of double



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Iterations | VectorLength | Mean          | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |----------- |------------- |--------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **ComputeDistanceLINQ**             | **1000**       | **2**            |    **151.384 μs** |   **1.0352 μs** |   **0.8082 μs** | **23.49** |    **0.19** | **59.3262** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 2            |      6.535 μs |   0.0863 μs |   0.0721 μs |  1.01 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 2            |     11.599 μs |   0.0936 μs |   0.0782 μs |  1.80 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 2            |     12.312 μs |   0.0796 μs |   0.0664 μs |  1.91 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 2            |      6.445 μs |   0.0441 μs |   0.0412 μs |  1.00 |    0.00 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 2            |     11.385 μs |   0.1410 μs |   0.1177 μs |  1.77 |    0.02 |       - |         - |          NA |
|                                 |            |              |               |             |             |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **8**            |    **255.860 μs** |   **2.5685 μs** |   **2.2769 μs** | **33.49** |    **0.35** | **59.0820** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 8            |     17.040 μs |   0.3196 μs |   0.3282 μs |  2.23 |    0.05 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 8            |     16.058 μs |   0.1915 μs |   0.1495 μs |  2.10 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 8            |     15.747 μs |   0.0963 μs |   0.0752 μs |  2.06 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 8            |      7.639 μs |   0.0306 μs |   0.0271 μs |  1.00 |    0.00 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 8            |     26.801 μs |   0.4040 μs |   0.3779 μs |  3.51 |    0.05 |       - |         - |          NA |
|                                 |            |              |               |             |             |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **100**          |  **2,306.091 μs** |  **15.8801 μs** |  **14.0773 μs** | **58.73** |    **0.43** | **58.5938** |  **256002 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 100          |    266.105 μs |   1.7804 μs |   1.6654 μs |  6.78 |    0.04 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 100          |    130.307 μs |   0.7230 μs |   0.6763 μs |  3.31 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 100          |     67.523 μs |   0.2515 μs |   0.2100 μs |  1.72 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 100          |     39.296 μs |   0.1748 μs |   0.1365 μs |  1.00 |    0.00 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 100          |     77.615 μs |   0.1636 μs |   0.1366 μs |  1.98 |    0.01 |       - |         - |          NA |
|                                 |            |              |               |             |             |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **1024**         | **23,369.189 μs** | **196.8609 μs** | **184.1438 μs** | **75.14** |    **0.67** | **31.2500** |  **256012 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 1024         |  3,202.645 μs |  12.3067 μs |   9.6083 μs | 10.30 |    0.05 |       - |       2 B |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 1024         |  1,339.689 μs |  10.8448 μs |  10.1442 μs |  4.31 |    0.03 |       - |       1 B |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 1024         |    843.936 μs |   1.8083 μs |   1.5100 μs |  2.71 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 1024         |    311.013 μs |   0.9196 μs |   0.8602 μs |  1.00 |    0.00 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 1024         |    849.511 μs |   6.8389 μs |   6.3971 μs |  2.73 |    0.02 |       - |         - |          NA |
