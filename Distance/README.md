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
| **ComputeDistanceLINQ**             | **1000**       | **2**            |     **91.651 μs** |  **0.7640 μs** |  **0.6772 μs** | **11.31** |    **0.10** | **15.2588** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 2            |      7.539 μs |  0.0254 μs |  0.0225 μs |  0.93 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 2            |     12.123 μs |  0.0470 μs |  0.0440 μs |  1.50 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 2            |      9.971 μs |  0.0660 μs |  0.0617 μs |  1.23 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 2            |      8.107 μs |  0.0438 μs |  0.0388 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 2            |      7.010 μs |  0.0177 μs |  0.0156 μs |  0.86 |    0.00 |       - |         - |          NA |
|                                 |            |              |               |            |            |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **8**            |    **161.149 μs** |  **1.4330 μs** |  **1.2703 μs** | **20.57** |    **0.20** | **15.1367** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 8            |     14.574 μs |  0.0409 μs |  0.0363 μs |  1.86 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 8            |     16.460 μs |  0.1254 μs |  0.1173 μs |  2.10 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 8            |     10.578 μs |  0.0787 μs |  0.0697 μs |  1.35 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 8            |      7.836 μs |  0.0530 μs |  0.0496 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 8            |     17.866 μs |  0.1359 μs |  0.1271 μs |  2.28 |    0.02 |       - |         - |          NA |
|                                 |            |              |               |            |            |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **100**          |    **996.664 μs** | **10.2148 μs** |  **9.5549 μs** | **30.46** |    **0.39** | **13.6719** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 100          |    226.575 μs |  0.5153 μs |  0.4568 μs |  6.93 |    0.06 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 100          |     92.149 μs |  0.4733 μs |  0.4427 μs |  2.82 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 100          |     58.130 μs |  0.2436 μs |  0.2279 μs |  1.78 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 100          |     32.718 μs |  0.3249 μs |  0.3039 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 100          |     57.421 μs |  0.2281 μs |  0.2133 μs |  1.76 |    0.02 |       - |         - |          NA |
|                                 |            |              |               |            |            |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **1000**       | **1024**         | **11,134.022 μs** | **66.9225 μs** | **62.5993 μs** | **44.34** |    **0.35** |       **-** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | 1000       | 1024         |  2,817.957 μs | 11.2835 μs | 10.5546 μs | 11.22 |    0.08 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | 1000       | 1024         |    892.228 μs |  2.0095 μs |  1.7814 μs |  3.55 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | 1000       | 1024         |    680.187 μs |  2.9675 μs |  2.7758 μs |  2.71 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | 1000       | 1024         |    251.135 μs |  1.6011 μs |  1.4977 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | 1000       | 1024         |    647.889 μs |  3.2348 μs |  3.0259 μs |  2.58 |    0.02 |       - |         - |          NA |
