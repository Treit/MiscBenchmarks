# Indexing strings




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------ |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **FindIndexesInString**                       | **10**    |     **28.49 ns** |   **0.257 ns** |   **0.240 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | 10    |     30.29 ns |   0.321 ns |   0.284 ns |  1.06 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | 10    |     29.54 ns |   0.341 ns |   0.319 ns |  1.04 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 10    |     37.19 ns |   0.412 ns |   0.365 ns |  1.31 |    0.02 |         - |          NA |
| FindIndexesBytePointers                   | 10    |     38.09 ns |   0.801 ns |   2.109 ns |  1.34 |    0.07 |         - |          NA |
|                                           |       |              |            |            |       |         |           |             |
| **FindIndexesInString**                       | **100**   |    **296.62 ns** |   **2.904 ns** |   **2.425 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | 100   |    338.66 ns |   3.938 ns |   3.491 ns |  1.14 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | 100   |    332.30 ns |   3.272 ns |   2.900 ns |  1.12 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 100   |    389.57 ns |   2.804 ns |   2.486 ns |  1.31 |    0.01 |         - |          NA |
| FindIndexesBytePointers                   | 100   |    292.98 ns |   2.052 ns |   1.919 ns |  0.99 |    0.01 |         - |          NA |
|                                           |       |              |            |            |       |         |           |             |
| **FindIndexesInString**                       | **10000** | **64,575.00 ns** | **722.114 ns** | **602.998 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| FindIndexesInIntArray                     | 10000 | 67,746.33 ns | 660.816 ns | 618.128 ns |  1.05 |    0.01 |         - |          NA |
| FindIndexesInCharArray                    | 10000 | 66,074.43 ns | 600.264 ns | 561.488 ns |  1.02 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 10000 | 65,136.63 ns | 802.182 ns | 750.361 ns |  1.01 |    0.01 |         - |          NA |
| FindIndexesBytePointers                   | 10000 | 63,900.58 ns | 588.786 ns | 550.751 ns |  0.99 |    0.01 |         - |          NA |
