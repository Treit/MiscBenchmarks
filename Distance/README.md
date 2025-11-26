# Distance calculation for two vectors of double





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Iterations | VectorLength | Mean          | Error      | StdDev     | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |----------- |------------- |--------------:|-----------:|-----------:|------:|--------:|--------:|----------:|------------:|
| **ComputeDistanceLINQ**             | **1000**       | **2**            |     **88.253 μs** |  **0.6447 μs** |  **0.5715 μs** | **10.86** |    **0.11** | **15.2588** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 2            |      7.860 μs |  0.1073 μs |  0.1004 μs |  0.97 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 2            |     14.993 μs |  0.1952 μs |  0.1826 μs |  1.85 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 2            |     10.103 μs |  0.0880 μs |  0.0824 μs |  1.24 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 2            |      8.126 μs |  0.0740 μs |  0.0692 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 2            |      7.021 μs |  0.0265 μs |  0.0248 μs |  0.86 |    0.01 |       - |         - |          NA |
|                                 |            |              |               |            |            |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **8**            |    **142.084 μs** |  **1.7506 μs** |  **1.6375 μs** | **17.43** |    **0.23** | **15.1367** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 8            |     14.581 μs |  0.0302 μs |  0.0252 μs |  1.79 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 8            |     17.474 μs |  0.2927 μs |  0.2738 μs |  2.14 |    0.04 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 8            |     10.691 μs |  0.0533 μs |  0.0498 μs |  1.31 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 8            |      8.152 μs |  0.0651 μs |  0.0609 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 8            |     17.871 μs |  0.1282 μs |  0.1200 μs |  2.19 |    0.02 |       - |         - |          NA |
|                                 |            |              |               |            |            |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **100**          |    **997.559 μs** | **12.6834 μs** | **11.8640 μs** | **29.14** |    **0.39** | **14.6484** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 100          |    226.989 μs |  0.8481 μs |  0.7518 μs |  6.63 |    0.05 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 100          |     92.739 μs |  0.4723 μs |  0.4418 μs |  2.71 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 100          |     59.422 μs |  0.1933 μs |  0.1713 μs |  1.74 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 100          |     34.234 μs |  0.2638 μs |  0.2468 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 100          |     57.749 μs |  0.2016 μs |  0.1886 μs |  1.69 |    0.01 |       - |         - |          NA |
|                                 |            |              |               |            |            |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **1024**         | **10,861.972 μs** | **39.4925 μs** | **35.0091 μs** | **43.12** |    **0.34** |       **-** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 1024         |  2,826.136 μs | 12.7415 μs | 11.9185 μs | 11.22 |    0.09 |       - |      48 B |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 1024         |    894.042 μs |  3.1913 μs |  2.6649 μs |  3.55 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 1024         |    681.581 μs |  2.9051 μs |  2.7174 μs |  2.71 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 1024         |    251.897 μs |  1.9830 μs |  1.8549 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 1024         |    649.117 μs |  2.9758 μs |  2.7836 μs |  2.58 |    0.02 |       - |         - |          NA |
