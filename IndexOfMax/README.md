# Finding max value of a series of floats




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Count | Mean          | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **IndexOfMaxForLoop**                | **10**    |      **6.327 ns** |  **0.0890 ns** |  **0.0832 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 10    |     11.659 ns |  0.0525 ns |  0.0491 ns |  1.84 |    0.02 |         - |          NA |
|                                  |       |               |            |            |       |         |           |             |
| **IndexOfMaxForLoop**                | **100**   |     **63.281 ns** |  **0.4463 ns** |  **0.4175 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 100   |    113.953 ns |  0.5836 ns |  0.5173 ns |  1.80 |    0.01 |         - |          NA |
|                                  |       |               |            |            |       |         |           |             |
| **IndexOfMaxForLoop**                | **10000** |  **6,252.737 ns** | **28.0063 ns** | **23.3865 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 10000 | 11,360.701 ns | 63.8962 ns | 59.7686 ns |  1.82 |    0.01 |         - |          NA |
