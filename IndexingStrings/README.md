# Indexing strings



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Count | Mean         | Error        | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------ |------ |-------------:|-------------:|-----------:|------:|--------:|----------:|------------:|
| **FindIndexesInString**                       | **10**    |     **29.71 ns** |     **0.270 ns** |   **0.253 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | 10    |     31.55 ns |     0.335 ns |   0.297 ns |  1.06 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | 10    |     28.74 ns |     0.216 ns |   0.202 ns |  0.97 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 10    |     37.09 ns |     0.396 ns |   0.370 ns |  1.25 |    0.02 |         - |          NA |
| FindIndexesBytePointers                   | 10    |     28.57 ns |     0.325 ns |   0.304 ns |  0.96 |    0.01 |         - |          NA |
|                                           |       |              |              |            |       |         |           |             |
| **FindIndexesInString**                       | **100**   |    **307.68 ns** |     **2.696 ns** |   **2.521 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | 100   |    323.61 ns |     3.453 ns |   3.061 ns |  1.05 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | 100   |    343.32 ns |     2.403 ns |   2.130 ns |  1.12 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 100   |    379.10 ns |     3.621 ns |   3.387 ns |  1.23 |    0.01 |         - |          NA |
| FindIndexesBytePointers                   | 100   |    327.74 ns |     4.708 ns |   4.404 ns |  1.07 |    0.02 |         - |          NA |
|                                           |       |              |              |            |       |         |           |             |
| **FindIndexesInString**                       | **10000** | **64,374.20 ns** |   **338.947 ns** | **317.051 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | 10000 | 66,964.16 ns |   839.168 ns | 784.959 ns |  1.04 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | 10000 | 66,166.51 ns |   382.206 ns | 357.516 ns |  1.03 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 10000 | 67,615.66 ns | 1,067.720 ns | 998.746 ns |  1.05 |    0.02 |         - |          NA |
| FindIndexesBytePointers                   | 10000 | 64,995.01 ns |   448.963 ns | 419.960 ns |  1.01 |    0.01 |         - |          NA |
