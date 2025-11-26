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
| **IndexOfMaxForLoop**                | **10**    |      **6.078 ns** |  **0.1102 ns** |  **0.1031 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 10    |     11.720 ns |  0.0689 ns |  0.0645 ns |  1.93 |    0.03 |         - |          NA |
|                                  |       |               |            |            |       |         |           |             |
| **IndexOfMaxForLoop**                | **100**   |     **63.349 ns** |  **0.5640 ns** |  **0.5275 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 100   |    115.019 ns |  0.8246 ns |  0.7714 ns |  1.82 |    0.02 |         - |          NA |
|                                  |       |               |            |            |       |         |           |             |
| **IndexOfMaxForLoop**                | **10000** |  **6,263.245 ns** | **23.9807 ns** | **21.2583 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| IndexOfMaxForLoopWithCancelCheck | 10000 | 11,354.030 ns | 56.2959 ns | 47.0096 ns |  1.81 |    0.01 |         - |          NA |
