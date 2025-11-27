# Finding max value of a series of floats






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Count | Mean          | Error       | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |------ |--------------:|------------:|------------:|------:|--------:|----------:|------------:|
| **IndexOfMaxForLoop**                | **.NET 10.0** | **.NET 10.0** | **10**    |      **6.390 ns** |   **0.0831 ns** |   **0.0777 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | .NET 10.0 | .NET 10.0 | 10    |     11.740 ns |   0.0843 ns |   0.0788 ns |  1.84 |    0.02 |         - |          NA |
|                                  |           |           |       |               |             |             |       |         |           |             |
| IndexOfMaxForLoop                | .NET 9.0  | .NET 9.0  | 10    |      6.503 ns |   0.1605 ns |   0.1576 ns |  1.00 |    0.03 |         - |          NA |
| IndexOfMaxForLoopWithCancelCheck | .NET 9.0  | .NET 9.0  | 10    |     11.691 ns |   0.1021 ns |   0.0905 ns |  1.80 |    0.04 |         - |          NA |
|                                  |           |           |       |               |             |             |       |         |           |             |
| **IndexOfMaxForLoop**                | **.NET 10.0** | **.NET 10.0** | **100**   |     **63.499 ns** |   **0.4568 ns** |   **0.4273 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | .NET 10.0 | .NET 10.0 | 100   |    114.644 ns |   0.5359 ns |   0.4751 ns |  1.81 |    0.01 |         - |          NA |
|                                  |           |           |       |               |             |             |       |         |           |             |
| IndexOfMaxForLoop                | .NET 9.0  | .NET 9.0  | 100   |     63.493 ns |   0.5940 ns |   0.5556 ns |  1.00 |    0.01 |         - |          NA |
| IndexOfMaxForLoopWithCancelCheck | .NET 9.0  | .NET 9.0  | 100   |    115.062 ns |   1.3769 ns |   1.2880 ns |  1.81 |    0.02 |         - |          NA |
|                                  |           |           |       |               |             |             |       |         |           |             |
| **IndexOfMaxForLoop**                | **.NET 10.0** | **.NET 10.0** | **10000** |  **6,272.356 ns** |  **25.8848 ns** |  **20.2092 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | .NET 10.0 | .NET 10.0 | 10000 | 11,540.371 ns | 121.9778 ns | 114.0981 ns |  1.84 |    0.02 |         - |          NA |
|                                  |           |           |       |               |             |             |       |         |           |             |
| IndexOfMaxForLoop                | .NET 9.0  | .NET 9.0  | 10000 |  6,275.003 ns |  21.6994 ns |  18.1200 ns |  1.00 |    0.00 |         - |          NA |
| IndexOfMaxForLoopWithCancelCheck | .NET 9.0  | .NET 9.0  | 10000 | 11,391.945 ns |  68.1343 ns |  63.7329 ns |  1.82 |    0.01 |         - |          NA |
