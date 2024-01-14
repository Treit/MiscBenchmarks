# Counting strings containing certain text.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                               Method | Count |        Mean |       Error |      StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------- |------ |------------:|------------:|------------:|------:|--------:|----------:|------------:|
|          CountUsingOrdinalIgnoreCase |    10 |    100.4 ns |     0.24 ns |     0.19 ns |  0.78 |    0.00 |         - |          NA |
|                  CountUsingTwoChecks |    10 |    128.8 ns |     0.23 ns |     0.18 ns |  1.00 |    0.00 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase |    10 |    337.2 ns |     2.29 ns |     2.14 ns |  2.62 |    0.02 |         - |          NA |
|   CountUsingCurrentCultureIgnoreCase |    10 |    349.2 ns |     2.88 ns |     2.55 ns |  2.71 |    0.02 |         - |          NA |
|                          CountKuinox |    10 |    445.2 ns |     2.25 ns |     1.88 ns |  3.46 |    0.02 |         - |          NA |
|             CountKuinoxSecondVersion |    10 |    648.3 ns |     1.59 ns |     1.33 ns |  5.03 |    0.01 |         - |          NA |
|                                      |       |             |             |             |       |         |           |             |
|          CountUsingOrdinalIgnoreCase |  1000 | 10,332.7 ns |    98.37 ns |    92.02 ns |  0.81 |    0.01 |         - |          NA |
|                  CountUsingTwoChecks |  1000 | 12,703.2 ns |    66.89 ns |    59.30 ns |  1.00 |    0.00 |         - |          NA |
| CountUsingInvariantCultureIgnoreCase |  1000 | 37,816.0 ns |   272.73 ns |   227.74 ns |  2.98 |    0.03 |         - |          NA |
|   CountUsingCurrentCultureIgnoreCase |  1000 | 39,036.6 ns |   132.13 ns |   103.16 ns |  3.07 |    0.02 |         - |          NA |
|                          CountKuinox |  1000 | 47,997.3 ns |   596.86 ns |   498.40 ns |  3.78 |    0.04 |         - |          NA |
|             CountKuinoxSecondVersion |  1000 | 67,077.8 ns | 1,317.20 ns | 1,758.42 ns |  5.36 |    0.14 |         - |          NA |
