# Counting strings containing certain text.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| CountUsingOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 10    |     46.43 ns |   0.545 ns |   0.510 ns |  0.39 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | .NET 10.0 | .NET 10.0 | 10    |    118.20 ns |   0.906 ns |   0.847 ns |  1.00 |    0.01 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 10    |    291.26 ns |   2.041 ns |   1.909 ns |  2.46 |    0.02 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 10    |    306.26 ns |   5.980 ns |   7.776 ns |  2.59 |    0.07 |         - |          NA |
| CountKuinox                          | .NET 10.0 | .NET 10.0 | 10    |    347.78 ns |   2.637 ns |   2.466 ns |  2.94 |    0.03 |         - |          NA |
| CountKuinoxSecondVersion             | .NET 10.0 | .NET 10.0 | 10    |    502.11 ns |   4.031 ns |   3.770 ns |  4.25 |    0.04 |         - |          NA |
|                                      |           |           |       |              |            |            |       |         |           |             |
| CountUsingOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 10    |     46.24 ns |   0.181 ns |   0.169 ns |  0.39 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | .NET 9.0  | .NET 9.0  | 10    |    118.33 ns |   1.137 ns |   1.064 ns |  1.00 |    0.01 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 10    |    302.67 ns |   3.307 ns |   3.094 ns |  2.56 |    0.03 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 10    |    318.63 ns |   6.053 ns |   5.945 ns |  2.69 |    0.05 |         - |          NA |
| CountKuinox                          | .NET 9.0  | .NET 9.0  | 10    |    341.77 ns |   1.921 ns |   1.797 ns |  2.89 |    0.03 |         - |          NA |
| CountKuinoxSecondVersion             | .NET 9.0  | .NET 9.0  | 10    |    505.39 ns |   5.992 ns |   5.311 ns |  4.27 |    0.06 |         - |          NA |
|                                      |           |           |       |              |            |            |       |         |           |             |
| CountUsingOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 1000  |  4,732.45 ns |  63.264 ns |  59.177 ns |  0.37 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | .NET 10.0 | .NET 10.0 | 1000  | 12,865.61 ns |  48.454 ns |  42.953 ns |  1.00 |    0.00 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 1000  | 32,792.03 ns | 355.475 ns | 332.512 ns |  2.55 |    0.03 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 1000  | 36,326.68 ns | 469.601 ns | 439.265 ns |  2.82 |    0.03 |         - |          NA |
| CountKuinox                          | .NET 10.0 | .NET 10.0 | 1000  | 36,465.67 ns | 489.469 ns | 457.850 ns |  2.83 |    0.04 |         - |          NA |
| CountKuinoxSecondVersion             | .NET 10.0 | .NET 10.0 | 1000  | 53,318.35 ns | 220.385 ns | 206.148 ns |  4.14 |    0.02 |         - |          NA |
|                                      |           |           |       |              |            |            |       |         |           |             |
| CountUsingOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 1000  |  4,700.72 ns |  35.492 ns |  31.463 ns |  0.37 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | .NET 9.0  | .NET 9.0  | 1000  | 12,634.25 ns |  70.257 ns |  65.718 ns |  1.00 |    0.01 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 1000  | 32,734.61 ns | 265.518 ns | 248.366 ns |  2.59 |    0.02 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 1000  | 36,082.63 ns | 519.830 ns | 486.249 ns |  2.86 |    0.04 |         - |          NA |
| CountKuinox                          | .NET 9.0  | .NET 9.0  | 1000  | 37,566.99 ns | 533.119 ns | 498.680 ns |  2.97 |    0.04 |         - |          NA |
| CountKuinoxSecondVersion             | .NET 9.0  | .NET 9.0  | 1000  | 53,355.55 ns | 183.126 ns | 171.297 ns |  4.22 |    0.03 |         - |          NA |
