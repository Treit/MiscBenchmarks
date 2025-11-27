# Filtering dictionary entries




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Job       | Runtime   | Count | Mean             | Error           | StdDev          | Ratio    | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|------------------------------------ |---------- |---------- |------ |-----------------:|----------------:|----------------:|---------:|--------:|----------:|------------:|------------:|
| **FilterUsingConvolutedLinq**           | **.NET 10.0** | **.NET 10.0** | **100**   |      **29,194.0 ns** |       **187.74 ns** |       **175.61 ns** |    **39.97** |    **0.30** |    **1.6785** |     **28352 B** |       **80.55** |
| FilterUsingCleanedUpPatternMatching | .NET 10.0 | .NET 10.0 | 100   |         730.4 ns |         4.20 ns |         3.51 ns |     1.00 |    0.01 |    0.0210 |       352 B |        1.00 |
|                                     |           |           |       |                  |                 |                 |          |         |           |             |             |
| FilterUsingConvolutedLinq           | .NET 9.0  | .NET 9.0  | 100   |      30,793.4 ns |       527.55 ns |       493.47 ns |    42.04 |    0.70 |    1.6479 |     28352 B |       80.55 |
| FilterUsingCleanedUpPatternMatching | .NET 9.0  | .NET 9.0  | 100   |         732.6 ns |         5.31 ns |         4.71 ns |     1.00 |    0.01 |    0.0210 |       352 B |        1.00 |
|                                     |           |           |       |                  |                 |                 |          |         |           |             |             |
| **FilterUsingConvolutedLinq**           | **.NET 10.0** | **.NET 10.0** | **10000** | **262,611,943.3 ns** | **2,508,830.97 ns** | **2,346,762.04 ns** | **2,942.35** |   **76.22** | **6500.0000** | **110021784 B** |    **5,050.58** |
| FilterUsingCleanedUpPatternMatching | .NET 10.0 | .NET 10.0 | 10000 |      89,305.1 ns |     1,742.52 ns |     2,203.72 ns |     1.00 |    0.03 |    1.2207 |     21784 B |        1.00 |
|                                     |           |           |       |                  |                 |                 |          |         |           |             |             |
| FilterUsingConvolutedLinq           | .NET 9.0  | .NET 9.0  | 10000 | 266,078,513.3 ns | 3,254,071.42 ns | 3,043,860.43 ns | 3,034.82 |   72.63 | 6500.0000 | 110021784 B |    5,050.58 |
| FilterUsingCleanedUpPatternMatching | .NET 9.0  | .NET 9.0  | 10000 |      87,715.0 ns |     1,731.64 ns |     1,924.71 ns |     1.00 |    0.03 |    1.2207 |     21784 B |        1.00 |
