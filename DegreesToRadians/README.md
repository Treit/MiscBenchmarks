# Degrees to radians.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | IterationCount | Mean          | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |--------------- |--------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **DegreesToRadiansMultiplyFirst** | **.NET 10.0** | **.NET 10.0** | **10**             |     **12.352 ns** |  **0.0264 ns** |  **0.0247 ns** |  **3.80** |    **0.03** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | .NET 10.0 | .NET 10.0 | 10             |      3.249 ns |  0.0339 ns |  0.0301 ns |  1.00 |    0.01 |         - |          NA |
|                               |           |           |                |               |            |            |       |         |           |             |
| DegreesToRadiansMultiplyFirst | .NET 9.0  | .NET 9.0  | 10             |     12.343 ns |  0.0347 ns |  0.0325 ns |  3.77 |    0.04 |         - |          NA |
| DegreesToRadiansDivideFirst   | .NET 9.0  | .NET 9.0  | 10             |      3.274 ns |  0.0402 ns |  0.0356 ns |  1.00 |    0.01 |         - |          NA |
|                               |           |           |                |               |            |            |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **.NET 10.0** | **.NET 10.0** | **100**            |    **138.006 ns** |  **0.8862 ns** |  **0.8290 ns** |  **2.16** |    **0.02** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | .NET 10.0 | .NET 10.0 | 100            |     63.798 ns |  0.4729 ns |  0.4424 ns |  1.00 |    0.01 |         - |          NA |
|                               |           |           |                |               |            |            |       |         |           |             |
| DegreesToRadiansMultiplyFirst | .NET 9.0  | .NET 9.0  | 100            |    137.885 ns |  0.8520 ns |  0.7970 ns |  2.16 |    0.02 |         - |          NA |
| DegreesToRadiansDivideFirst   | .NET 9.0  | .NET 9.0  | 100            |     63.827 ns |  0.4691 ns |  0.4388 ns |  1.00 |    0.01 |         - |          NA |
|                               |           |           |                |               |            |            |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **.NET 10.0** | **.NET 10.0** | **10000**          | **14,017.706 ns** | **28.8092 ns** | **25.5386 ns** |  **1.50** |    **0.01** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | .NET 10.0 | .NET 10.0 | 10000          |  9,330.911 ns | 50.4885 ns | 47.2270 ns |  1.00 |    0.01 |         - |          NA |
|                               |           |           |                |               |            |            |       |         |           |             |
| DegreesToRadiansMultiplyFirst | .NET 9.0  | .NET 9.0  | 10000          | 14,015.226 ns | 36.8257 ns | 34.4468 ns |  1.50 |    0.01 |         - |          NA |
| DegreesToRadiansDivideFirst   | .NET 9.0  | .NET 9.0  | 10000          |  9,329.761 ns | 49.6674 ns | 46.4589 ns |  1.00 |    0.01 |         - |          NA |
