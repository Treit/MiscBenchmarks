# Indexing strings


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                    Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------------------ |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
|                       **FindIndexesInString** |    **10** |     **32.27 ns** |   **0.211 ns** |   **0.197 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|                     FindIndexesInIntArray |    10 |     34.91 ns |   0.729 ns |   1.717 ns |  1.08 |    0.06 |         - |          NA |
|                    FindIndexesInCharArray |    10 |     32.98 ns |   0.646 ns |   0.604 ns |  1.02 |    0.02 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray |    10 |     39.80 ns |   0.193 ns |   0.171 ns |  1.23 |    0.01 |         - |          NA |
|                   FindIndexesBytePointers |    10 |     25.38 ns |   0.122 ns |   0.108 ns |  0.79 |    0.00 |         - |          NA |
|                                           |       |              |            |            |       |         |           |             |
|                       **FindIndexesInString** |   **100** |    **319.06 ns** |   **2.241 ns** |   **2.096 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|                     FindIndexesInIntArray |   100 |    341.83 ns |   3.207 ns |   2.843 ns |  1.07 |    0.01 |         - |          NA |
|                    FindIndexesInCharArray |   100 |    361.87 ns |   4.281 ns |   3.795 ns |  1.13 |    0.02 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray |   100 |    404.03 ns |   1.444 ns |   1.280 ns |  1.27 |    0.01 |         - |          NA |
|                   FindIndexesBytePointers |   100 |    260.03 ns |   2.336 ns |   2.185 ns |  0.82 |    0.01 |         - |          NA |
|                                           |       |              |            |            |       |         |           |             |
|                       **FindIndexesInString** | **10000** | **60,785.11 ns** | **597.890 ns** | **559.267 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|                     FindIndexesInIntArray | 10000 | 65,035.05 ns | 269.062 ns | 224.679 ns |  1.07 |    0.01 |         - |          NA |
|                    FindIndexesInCharArray | 10000 | 61,021.64 ns | 274.325 ns | 229.074 ns |  1.00 |    0.01 |         - |          NA |
| FindIndexesPointerArithmeticIntoCharArray | 10000 | 72,440.09 ns | 818.820 ns | 765.925 ns |  1.19 |    0.01 |         - |          NA |
|                   FindIndexesBytePointers | 10000 | 59,058.07 ns | 219.220 ns | 205.059 ns |  0.97 |    0.01 |         - |          NA |
