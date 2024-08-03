# Degrees to radians.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | IterationCount | Mean          | Error       | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |--------------- |--------------:|------------:|------------:|------:|--------:|----------:|------------:|
| **DegreesToRadiansMultiplyFirst** | **10**             |      **9.227 ns** |   **0.1701 ns** |   **0.1591 ns** |  **2.31** |    **0.09** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 10             |      3.998 ns |   0.1093 ns |   0.1122 ns |  1.00 |    0.00 |         - |          NA |
|                               |                |               |             |             |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **100**            |    **106.975 ns** |   **1.5011 ns** |   **1.2535 ns** |  **1.28** |    **0.02** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 100            |     83.349 ns |   0.9745 ns |   0.8138 ns |  1.00 |    0.00 |         - |          NA |
|                               |                |               |             |             |       |         |           |             |
| **DegreesToRadiansMultiplyFirst** | **10000**          | **10,932.278 ns** | **152.9529 ns** | **143.0722 ns** |  **0.99** |    **0.02** |         **-** |          **NA** |
| DegreesToRadiansDivideFirst   | 10000          | 11,013.774 ns |  91.1520 ns |  80.8038 ns |  1.00 |    0.00 |         - |          NA |
