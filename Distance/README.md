# Distance calculation for two vectors of double






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Iterations | VectorLength | Mean          | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|-------------------------------- |---------- |---------- |----------- |------------- |--------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **ComputeDistanceLINQ**             | **.NET 10.0** | **.NET 10.0** | **1000**       | **2**            |     **99.881 μs** |   **1.3126 μs** |   **1.2278 μs** | **12.27** |    **0.18** | **15.2588** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | .NET 10.0 | .NET 10.0 | 1000       | 2            |      7.848 μs |   0.0866 μs |   0.0810 μs |  0.96 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 10.0 | .NET 10.0 | 1000       | 2            |     14.743 μs |   0.1686 μs |   0.1577 μs |  1.81 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 10.0 | .NET 10.0 | 1000       | 2            |      9.803 μs |   0.0626 μs |   0.0585 μs |  1.20 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 10.0 | .NET 10.0 | 1000       | 2            |      8.141 μs |   0.0791 μs |   0.0740 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 10.0 | .NET 10.0 | 1000       | 2            |      7.024 μs |   0.0236 μs |   0.0210 μs |  0.86 |    0.01 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| ComputeDistanceLINQ             | .NET 9.0  | .NET 9.0  | 1000       | 2            |     98.850 μs |   1.5086 μs |   1.4111 μs | 12.09 |    0.20 | 15.2588 |  256000 B |          NA |
| ComputeDistanceNonVectorized    | .NET 9.0  | .NET 9.0  | 1000       | 2            |      7.705 μs |   0.0625 μs |   0.0554 μs |  0.94 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 9.0  | .NET 9.0  | 1000       | 2            |     12.305 μs |   0.1334 μs |   0.1248 μs |  1.51 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 9.0  | .NET 9.0  | 1000       | 2            |      9.875 μs |   0.1327 μs |   0.1241 μs |  1.21 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 9.0  | .NET 9.0  | 1000       | 2            |      8.175 μs |   0.0883 μs |   0.0826 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 9.0  | .NET 9.0  | 1000       | 2            |      7.032 μs |   0.0092 μs |   0.0081 μs |  0.86 |    0.01 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **.NET 10.0** | **.NET 10.0** | **1000**       | **8**            |    **160.009 μs** |   **3.0132 μs** |   **2.8185 μs** | **20.15** |    **0.38** | **15.1367** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | .NET 10.0 | .NET 10.0 | 1000       | 8            |     14.656 μs |   0.0313 μs |   0.0278 μs |  1.85 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 10.0 | .NET 10.0 | 1000       | 8            |     20.810 μs |   0.3909 μs |   0.4015 μs |  2.62 |    0.05 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 10.0 | .NET 10.0 | 1000       | 8            |     10.704 μs |   0.0722 μs |   0.0676 μs |  1.35 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 10.0 | .NET 10.0 | 1000       | 8            |      7.940 μs |   0.0735 μs |   0.0688 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 10.0 | .NET 10.0 | 1000       | 8            |     18.259 μs |   0.1961 μs |   0.1834 μs |  2.30 |    0.03 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| ComputeDistanceLINQ             | .NET 9.0  | .NET 9.0  | 1000       | 8            |    167.807 μs |   2.2694 μs |   2.1228 μs | 21.21 |    0.30 | 15.1367 |  256000 B |          NA |
| ComputeDistanceNonVectorized    | .NET 9.0  | .NET 9.0  | 1000       | 8            |     14.658 μs |   0.0803 μs |   0.0712 μs |  1.85 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 9.0  | .NET 9.0  | 1000       | 8            |     16.779 μs |   0.1867 μs |   0.1747 μs |  2.12 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 9.0  | .NET 9.0  | 1000       | 8            |     10.623 μs |   0.1065 μs |   0.0996 μs |  1.34 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 9.0  | .NET 9.0  | 1000       | 8            |      7.913 μs |   0.0644 μs |   0.0602 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 9.0  | .NET 9.0  | 1000       | 8            |     18.175 μs |   0.1455 μs |   0.1361 μs |  2.30 |    0.02 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **.NET 10.0** | **.NET 10.0** | **1000**       | **100**          |  **1,041.056 μs** |  **15.3827 μs** |  **14.3890 μs** | **29.53** |    **0.44** | **13.6719** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | .NET 10.0 | .NET 10.0 | 1000       | 100          |    227.505 μs |   0.5498 μs |   0.4873 μs |  6.45 |    0.05 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 10.0 | .NET 10.0 | 1000       | 100          |     93.212 μs |   0.9598 μs |   0.8978 μs |  2.64 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 10.0 | .NET 10.0 | 1000       | 100          |     52.109 μs |   0.2325 μs |   0.1941 μs |  1.48 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 10.0 | .NET 10.0 | 1000       | 100          |     35.258 μs |   0.2708 μs |   0.2533 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 10.0 | .NET 10.0 | 1000       | 100          |     57.912 μs |   0.2305 μs |   0.2043 μs |  1.64 |    0.01 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| ComputeDistanceLINQ             | .NET 9.0  | .NET 9.0  | 1000       | 100          |  1,153.081 μs |  16.9878 μs |  15.8904 μs | 32.58 |    0.51 | 13.6719 |  256000 B |          NA |
| ComputeDistanceNonVectorized    | .NET 9.0  | .NET 9.0  | 1000       | 100          |    227.408 μs |   0.5367 μs |   0.4757 μs |  6.42 |    0.05 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 9.0  | .NET 9.0  | 1000       | 100          |     93.014 μs |   0.5949 μs |   0.5274 μs |  2.63 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 9.0  | .NET 9.0  | 1000       | 100          |     51.457 μs |   0.2385 μs |   0.1992 μs |  1.45 |    0.01 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 9.0  | .NET 9.0  | 1000       | 100          |     35.398 μs |   0.3313 μs |   0.2937 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 9.0  | .NET 9.0  | 1000       | 100          |     57.860 μs |   0.1572 μs |   0.1312 μs |  1.63 |    0.01 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| **ComputeDistanceLINQ**             | **.NET 10.0** | **.NET 10.0** | **1000**       | **1024**         | **12,201.583 μs** |  **61.7433 μs** |  **51.5585 μs** | **48.46** |    **0.39** |       **-** |  **256000 B** |          **NA** |
| ComputeDistanceNonVectorized    | .NET 10.0 | .NET 10.0 | 1000       | 1024         |  2,827.987 μs |  11.5648 μs |  10.2519 μs | 11.23 |    0.09 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 10.0 | .NET 10.0 | 1000       | 1024         |    897.240 μs |   3.5788 μs |   3.1725 μs |  3.56 |    0.03 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 10.0 | .NET 10.0 | 1000       | 1024         |    682.757 μs |   3.6723 μs |   3.4351 μs |  2.71 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 10.0 | .NET 10.0 | 1000       | 1024         |    251.814 μs |   1.9386 μs |   1.8134 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 10.0 | .NET 10.0 | 1000       | 1024         |    649.952 μs |   4.0908 μs |   3.8266 μs |  2.58 |    0.02 |       - |         - |          NA |
|                                 |           |           |            |              |               |             |             |       |         |         |           |             |
| ComputeDistanceLINQ             | .NET 9.0  | .NET 9.0  | 1000       | 1024         | 16,465.260 μs | 231.1638 μs | 216.2308 μs | 65.18 |    0.93 |       - |  256000 B |          NA |
| ComputeDistanceNonVectorized    | .NET 9.0  | .NET 9.0  | 1000       | 1024         |  2,828.813 μs |  13.3118 μs |  12.4519 μs | 11.20 |    0.09 |       - |         - |          NA |
| ComputeDistanceVectorizedMTreit | .NET 9.0  | .NET 9.0  | 1000       | 1024         |    896.745 μs |   2.4947 μs |   2.2115 μs |  3.55 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron  | .NET 9.0  | .NET 9.0  | 1000       | 1024         |    682.816 μs |   3.6497 μs |   3.4139 μs |  2.70 |    0.02 |       - |         - |          NA |
| ComputeDistanceVectorizedAaron2 | .NET 9.0  | .NET 9.0  | 1000       | 1024         |    252.604 μs |   1.7630 μs |   1.6491 μs |  1.00 |    0.01 |       - |         - |          NA |
| ComputeDistanceTensorPrimitives | .NET 9.0  | .NET 9.0  | 1000       | 1024         |    649.872 μs |   3.9879 μs |   3.7303 μs |  2.57 |    0.02 |       - |         - |          NA |
