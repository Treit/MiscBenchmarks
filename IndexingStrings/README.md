# Indexing strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.48005, CoreFX 6.0.21.48005), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.48005, CoreFX 6.0.21.48005), X64 RyuJIT


```
|                                    Method | Count |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------ |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|                       **FindIndexesInString** |    **10** |     **32.36 ns** |     **0.601 ns** |     **0.590 ns** |     **32.37 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|                     FindIndexesInIntArray |    10 |     33.60 ns |     0.674 ns |     1.788 ns |     32.97 ns |  1.06 |    0.06 |     - |     - |     - |         - |
|                    FindIndexesInCharArray |    10 |     32.23 ns |     0.574 ns |     0.480 ns |     32.10 ns |  0.99 |    0.02 |     - |     - |     - |         - |
| FindIndexesPointerArithmeticIntoCharArray |    10 |     38.52 ns |     0.769 ns |     1.027 ns |     38.59 ns |  1.19 |    0.04 |     - |     - |     - |         - |
|                   FindIndexesBytePointers |    10 |     29.95 ns |     0.626 ns |     1.220 ns |     29.82 ns |  0.92 |    0.04 |     - |     - |     - |         - |
|                                           |       |              |              |              |              |       |         |       |       |       |           |
|                       **FindIndexesInString** |   **100** |    **349.35 ns** |     **5.953 ns** |     **5.569 ns** |    **348.97 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|                     FindIndexesInIntArray |   100 |    383.10 ns |     7.208 ns |     8.852 ns |    384.53 ns |  1.09 |    0.04 |     - |     - |     - |         - |
|                    FindIndexesInCharArray |   100 |    345.36 ns |     6.789 ns |     6.350 ns |    344.06 ns |  0.99 |    0.03 |     - |     - |     - |         - |
| FindIndexesPointerArithmeticIntoCharArray |   100 |    411.16 ns |     7.690 ns |     7.193 ns |    410.74 ns |  1.18 |    0.03 |     - |     - |     - |         - |
|                   FindIndexesBytePointers |   100 |    291.26 ns |     5.832 ns |    10.214 ns |    289.16 ns |  0.84 |    0.02 |     - |     - |     - |         - |
|                                           |       |              |              |              |              |       |         |       |       |       |           |
|                       **FindIndexesInString** | **10000** | **56,826.43 ns** |   **411.120 ns** |   **384.562 ns** | **56,872.17 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|                     FindIndexesInIntArray | 10000 | 61,534.24 ns | 1,205.392 ns | 1,183.856 ns | 61,435.51 ns |  1.08 |    0.02 |     - |     - |     - |         - |
|                    FindIndexesInCharArray | 10000 | 58,579.34 ns |   438.887 ns |   410.535 ns | 58,570.03 ns |  1.03 |    0.01 |     - |     - |     - |         - |
| FindIndexesPointerArithmeticIntoCharArray | 10000 | 64,593.30 ns |   867.503 ns |   811.463 ns | 64,624.18 ns |  1.14 |    0.02 |     - |     - |     - |         - |
|                   FindIndexesBytePointers | 10000 | 58,198.35 ns |   629.108 ns |   588.468 ns | 58,194.25 ns |  1.02 |    0.01 |     - |     - |     - |         - |
