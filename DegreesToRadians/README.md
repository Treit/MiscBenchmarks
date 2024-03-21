# Degrees to radians.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method            | IterationCount | Mean          | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------ |--------------- |--------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **DegreesToRadiansA** | **10**             |      **9.071 ns** |  **0.1668 ns** |  **0.1478 ns** |  **2.31** |    **0.11** |         **-** |          **NA** |
| DegreesToRadiansB | 10             |      4.053 ns |  0.1167 ns |  0.2013 ns |  1.00 |    0.00 |         - |          NA |
|                   |                |               |            |            |       |         |           |             |
| **DegreesToRadiansA** | **100**            |    **107.533 ns** |  **1.8495 ns** |  **1.6396 ns** |  **1.29** |    **0.02** |         **-** |          **NA** |
| DegreesToRadiansB | 100            |     83.292 ns |  1.6140 ns |  1.4307 ns |  1.00 |    0.00 |         - |          NA |
|                   |                |               |            |            |       |         |           |             |
| **DegreesToRadiansA** | **10000**          | **10,918.536 ns** | **78.9357 ns** | **73.8365 ns** |  **1.02** |    **0.01** |         **-** |          **NA** |
| DegreesToRadiansB | 10000          | 10,746.561 ns | 92.8909 ns | 82.3454 ns |  1.00 |    0.00 |         - |          NA |
