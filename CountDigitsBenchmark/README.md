## Counting digits








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Job       | Runtime   | Count  | Mean           | Error        | StdDev       | Median         | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|----------------------------------------------------- |---------- |---------- |------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|---------:|----------:|------------:|
| **CountDigitsUsingMath**                                 | **.NET 10.0** | **.NET 10.0** | **100**    |       **744.7 ns** |      **4.65 ns** |      **4.12 ns** |       **744.9 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | .NET 10.0 | .NET 10.0 | 100    |       768.4 ns |      5.43 ns |      4.82 ns |       768.4 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | .NET 10.0 | .NET 10.0 | 100    |     1,027.2 ns |     19.48 ns |     21.66 ns |     1,018.8 ns |  1.38 |    0.03 |   0.2632 |    4424 B |          NA |
| CountDigitsUsingMaxMahem                             | .NET 10.0 | .NET 10.0 | 100    |       650.5 ns |      3.62 ns |      3.21 ns |       651.1 ns |  0.87 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | .NET 10.0 | .NET 10.0 | 100    |       247.2 ns |      4.64 ns |     10.93 ns |       249.2 ns |  0.33 |    0.01 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | .NET 10.0 | .NET 10.0 | 100    |       172.9 ns |      1.51 ns |      1.34 ns |       173.3 ns |  0.23 |    0.00 |        - |         - |          NA |
|                                                      |           |           |        |                |              |              |                |       |         |          |           |             |
| CountDigitsUsingMath                                 | .NET 9.0  | .NET 9.0  | 100    |       743.7 ns |      4.05 ns |      3.78 ns |       745.2 ns |  1.00 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMathIncludingFloor                   | .NET 9.0  | .NET 9.0  | 100    |       768.4 ns |      5.85 ns |      5.47 ns |       768.0 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | .NET 9.0  | .NET 9.0  | 100    |     1,032.3 ns |     20.34 ns |     19.03 ns |     1,038.6 ns |  1.39 |    0.03 |   0.2632 |    4424 B |          NA |
| CountDigitsUsingMaxMahem                             | .NET 9.0  | .NET 9.0  | 100    |       667.0 ns |      7.41 ns |      5.78 ns |       668.4 ns |  0.90 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | .NET 9.0  | .NET 9.0  | 100    |       249.6 ns |      4.90 ns |      7.03 ns |       249.5 ns |  0.34 |    0.01 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | .NET 9.0  | .NET 9.0  | 100    |       173.0 ns |      1.41 ns |      1.32 ns |       173.4 ns |  0.23 |    0.00 |        - |         - |          NA |
|                                                      |           |           |        |                |              |              |                |       |         |          |           |             |
| **CountDigitsUsingMath**                                 | **.NET 10.0** | **.NET 10.0** | **1000**   |     **7,377.4 ns** |     **56.33 ns** |     **52.69 ns** |     **7,378.7 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | .NET 10.0 | .NET 10.0 | 1000   |     7,595.6 ns |     44.58 ns |     41.70 ns |     7,583.4 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | .NET 10.0 | .NET 10.0 | 1000   |    10,292.5 ns |    125.29 ns |    111.06 ns |    10,264.2 ns |  1.40 |    0.02 |   2.6398 |   44376 B |          NA |
| CountDigitsUsingMaxMahem                             | .NET 10.0 | .NET 10.0 | 1000   |     8,532.8 ns |    170.12 ns |    376.98 ns |     8,379.3 ns |  1.16 |    0.05 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | .NET 10.0 | .NET 10.0 | 1000   |     2,286.1 ns |     45.53 ns |    112.54 ns |     2,225.8 ns |  0.31 |    0.02 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | .NET 10.0 | .NET 10.0 | 1000   |     1,640.2 ns |      7.17 ns |      5.99 ns |     1,640.8 ns |  0.22 |    0.00 |        - |         - |          NA |
|                                                      |           |           |        |                |              |              |                |       |         |          |           |             |
| CountDigitsUsingMath                                 | .NET 9.0  | .NET 9.0  | 1000   |     7,380.3 ns |     57.18 ns |     53.48 ns |     7,375.6 ns |  1.00 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMathIncludingFloor                   | .NET 9.0  | .NET 9.0  | 1000   |     7,566.6 ns |     17.37 ns |     14.50 ns |     7,565.7 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | .NET 9.0  | .NET 9.0  | 1000   |    10,261.1 ns |    105.23 ns |     93.28 ns |    10,252.1 ns |  1.39 |    0.02 |   2.6398 |   44376 B |          NA |
| CountDigitsUsingMaxMahem                             | .NET 9.0  | .NET 9.0  | 1000   |     8,797.6 ns |    175.76 ns |    393.11 ns |     8,780.1 ns |  1.19 |    0.05 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | .NET 9.0  | .NET 9.0  | 1000   |     2,244.4 ns |     42.71 ns |     55.54 ns |     2,227.4 ns |  0.30 |    0.01 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | .NET 9.0  | .NET 9.0  | 1000   |     1,637.8 ns |      5.97 ns |      5.59 ns |     1,638.6 ns |  0.22 |    0.00 |        - |         - |          NA |
|                                                      |           |           |        |                |              |              |                |       |         |          |           |             |
| **CountDigitsUsingMath**                                 | **.NET 10.0** | **.NET 10.0** | **100000** |   **735,086.2 ns** |  **5,089.16 ns** |  **4,511.41 ns** |   **736,262.3 ns** |  **1.00** |    **0.01** |        **-** |         **-** |          **NA** |
| CountDigitsUsingMathIncludingFloor                   | .NET 10.0 | .NET 10.0 | 100000 |   760,117.3 ns |  4,382.05 ns |  4,098.98 ns |   761,012.1 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | .NET 10.0 | .NET 10.0 | 100000 | 1,671,618.0 ns | 15,598.57 ns | 14,590.91 ns | 1,672,497.3 ns |  2.27 |    0.02 | 263.6719 | 4426136 B |          NA |
| CountDigitsUsingMaxMahem                             | .NET 10.0 | .NET 10.0 | 100000 | 1,316,176.3 ns | 10,151.56 ns |  9,495.78 ns | 1,318,516.7 ns |  1.79 |    0.02 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | .NET 10.0 | .NET 10.0 | 100000 |   220,601.7 ns |    783.08 ns |    653.91 ns |   220,963.8 ns |  0.30 |    0.00 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | .NET 10.0 | .NET 10.0 | 100000 |   163,789.2 ns |  1,614.51 ns |  1,510.21 ns |   163,798.6 ns |  0.22 |    0.00 |        - |         - |          NA |
|                                                      |           |           |        |                |              |              |                |       |         |          |           |             |
| CountDigitsUsingMath                                 | .NET 9.0  | .NET 9.0  | 100000 |   733,742.6 ns |  4,873.90 ns |  4,559.05 ns |   735,356.8 ns |  1.00 |    0.01 |        - |         - |          NA |
| CountDigitsUsingMathIncludingFloor                   | .NET 9.0  | .NET 9.0  | 100000 |   759,174.0 ns |  4,150.48 ns |  3,465.84 ns |   759,938.6 ns |  1.03 |    0.01 |        - |         - |          NA |
| CountDigitsUsingString                               | .NET 9.0  | .NET 9.0  | 100000 | 1,690,018.5 ns | 22,658.95 ns | 21,195.20 ns | 1,690,245.1 ns |  2.30 |    0.03 | 263.6719 | 4426136 B |          NA |
| CountDigitsUsingMaxMahem                             | .NET 9.0  | .NET 9.0  | 100000 | 1,276,374.4 ns |  9,495.36 ns |  8,881.97 ns | 1,280,561.9 ns |  1.74 |    0.02 |        - |         - |          NA |
| CountDigitsUsingMaxMahemDigitsLengthConditonalLookup | .NET 9.0  | .NET 9.0  | 100000 |   251,837.5 ns |  2,267.72 ns |  2,010.27 ns |   252,624.8 ns |  0.34 |    0.00 |        - |         - |          NA |
| CountDigitsUsingLookupTable                          | .NET 9.0  | .NET 9.0  | 100000 |   164,275.4 ns |  1,691.39 ns |  1,582.13 ns |   164,219.0 ns |  0.22 |    0.00 |        - |         - |          NA |
