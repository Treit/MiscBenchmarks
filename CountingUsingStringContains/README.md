# Counting strings containing certain text.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| CountUsingOrdinalIgnoreCase          | 10    |     45.90 ns |   0.224 ns |   0.199 ns |  0.39 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | 10    |    117.83 ns |   0.333 ns |   0.311 ns |  1.00 |    0.00 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | 10    |    288.78 ns |   3.727 ns |   3.486 ns |  2.45 |    0.03 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | 10    |    313.40 ns |   3.483 ns |   3.258 ns |  2.66 |    0.03 |         - |          NA |
| CountKuinox                          | 10    |    337.15 ns |   1.698 ns |   1.588 ns |  2.86 |    0.01 |         - |          NA |
| CountKuinoxSecondVersion             | 10    |    502.92 ns |   3.140 ns |   2.937 ns |  4.27 |    0.03 |         - |          NA |
|                                      |       |              |            |            |       |         |           |             |
| CountUsingOrdinalIgnoreCase          | 1000  |  4,680.35 ns |  44.453 ns |  41.582 ns |  0.39 |    0.00 |         - |          NA |
| CountUsingTwoChecks                  | 1000  | 12,057.10 ns |  41.750 ns |  39.053 ns |  1.00 |    0.00 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase | 1000  | 32,863.60 ns | 269.087 ns | 251.704 ns |  2.73 |    0.02 |         - |          NA |
| CountKuinox                          | 1000  | 35,324.02 ns | 630.143 ns | 589.436 ns |  2.93 |    0.05 |         - |          NA |
| CountUsingCurrentCultureIgnoreCase   | 1000  | 36,013.57 ns | 492.159 ns | 460.366 ns |  2.99 |    0.04 |         - |          NA |
| CountKuinoxSecondVersion             | 1000  | 53,042.03 ns | 163.509 ns | 144.946 ns |  4.40 |    0.02 |         - |          NA |
