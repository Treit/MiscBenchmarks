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
| **DegreesToRadiansMultiplyFirst** | **10**             |     **12.329 ns** |  **0.0257 ns** |  **0.0215 ns** |  **4.20** |    **0.05** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 10             |      2.935 ns |  0.0406 ns |  0.0379 ns |  1.00 |    0.02 |         - |          NA |
|                               |                |               |            |            |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **100**            |    **137.387 ns** |  **0.7453 ns** |  **0.6971 ns** |  **2.16** |    **0.02** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 100            |     63.657 ns |  0.5664 ns |  0.5298 ns |  1.00 |    0.01 |         - |          NA |
|                               |                |               |            |            |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **10000**          | **13,997.214 ns** | **28.6256 ns** | **26.7764 ns** |  **1.50** |    **0.01** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 10000          |  9,319.954 ns | 50.2127 ns | 46.9690 ns |  1.00 |    0.01 |         - |          NA |
