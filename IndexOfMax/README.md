# Finding max value of a series of floats



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                           | Count | Mean          | Error       | StdDev      | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |------ |--------------:|------------:|------------:|--------------:|------:|--------:|----------:|------------:|
| **IndexOfMaxForLoop**                | **10**    |      **8.588 ns** |   **0.0741 ns** |   **0.0619 ns** |      **8.585 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 10    |     12.510 ns |   0.2718 ns |   0.5172 ns |     12.533 ns |  1.43 |    0.10 |         - |          NA |
|                                  |       |               |             |             |               |       |         |           |             |
| **IndexOfMaxForLoop**                | **100**   |     **65.131 ns** |   **0.7274 ns** |   **0.6449 ns** |     **64.832 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 100   |    177.027 ns |   3.5269 ns |   4.4605 ns |    177.646 ns |  2.72 |    0.07 |         - |          NA |
|                                  |       |               |             |             |               |       |         |           |             |
| **IndexOfMaxForLoop**                | **10000** |  **6,467.341 ns** | **123.5600 ns** | **147.0894 ns** |  **6,454.681 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 10000 | 17,346.768 ns | 339.0486 ns | 758.3308 ns | 16,975.746 ns |  2.70 |    0.13 |         - |          NA |
