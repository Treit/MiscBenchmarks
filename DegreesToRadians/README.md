# Degrees to radians.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | IterationCount | Mean          | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |--------------- |--------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **DegreesToRadiansMultiplyFirst** | **10**             |     **12.320 ns** |  **0.0260 ns** |  **0.0217 ns** |  **3.80** |    **0.04** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 10             |      3.239 ns |  0.0344 ns |  0.0321 ns |  1.00 |    0.01 |         - |          NA |
|                               |                |               |            |            |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **100**            |    **137.389 ns** |  **0.7260 ns** |  **0.6791 ns** |  **2.14** |    **0.02** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 100            |     64.233 ns |  0.4721 ns |  0.4185 ns |  1.00 |    0.01 |         - |          NA |
|                               |                |               |            |            |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **10000**          | **13,983.212 ns** | **29.2223 ns** | **27.3345 ns** |  **1.50** |    **0.01** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 10000          |  9,321.035 ns | 46.5170 ns | 43.5120 ns |  1.00 |    0.01 |         - |          NA |
