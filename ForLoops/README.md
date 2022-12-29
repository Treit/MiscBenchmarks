# Loops

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25272.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]   : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|                                     Method |      Job |  Runtime |   Count |          Mean |         Error |         StdDev |        Median | Ratio | RatioSD |
|------------------------------------------- |--------- |--------- |-------- |--------------:|--------------:|---------------:|--------------:|------:|--------:|
|                             **ClassicForLoop** | **.NET 6.0** | **.NET 6.0** |     **100** |      **93.46 ns** |      **1.911 ns** |       **3.903 ns** |      **92.72 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 6.0 | .NET 6.0 |     100 |      96.98 ns |      1.981 ns |       5.652 ns |      96.24 ns |  1.02 |    0.06 |
|                              LoopUsingGoto | .NET 6.0 | .NET 6.0 |     100 |      93.59 ns |      1.877 ns |       2.631 ns |      93.50 ns |  0.99 |    0.04 |
|                                            |          |          |         |               |               |                |               |       |         |
|                             ClassicForLoop | .NET 7.0 | .NET 7.0 |     100 |      95.48 ns |      1.966 ns |       4.634 ns |      94.04 ns |  1.00 |    0.00 |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 7.0 | .NET 7.0 |     100 |      91.07 ns |      1.855 ns |       4.187 ns |      90.35 ns |  0.95 |    0.06 |
|                              LoopUsingGoto | .NET 7.0 | .NET 7.0 |     100 |      94.31 ns |      1.902 ns |       3.331 ns |      93.57 ns |  0.98 |    0.06 |
|                                            |          |          |         |               |               |                |               |       |         |
|                             **ClassicForLoop** | **.NET 6.0** | **.NET 6.0** | **1000000** | **864,507.38 ns** | **17,111.439 ns** |  **43,863.160 ns** | **854,139.75 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 6.0 | .NET 6.0 | 1000000 | 911,054.52 ns | 26,250.679 ns |  76,574.463 ns | 885,452.69 ns |  1.05 |    0.11 |
|                              LoopUsingGoto | .NET 6.0 | .NET 6.0 | 1000000 | 924,977.89 ns | 23,195.019 ns |  67,660.958 ns | 916,079.20 ns |  1.07 |    0.09 |
|                                            |          |          |         |               |               |                |               |       |         |
|                             ClassicForLoop | .NET 7.0 | .NET 7.0 | 1000000 | 901,347.00 ns | 20,750.088 ns |  60,528.982 ns | 887,212.89 ns |  1.00 |    0.00 |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 7.0 | .NET 7.0 | 1000000 | 957,755.91 ns | 36,742.448 ns | 108,335.937 ns | 910,054.69 ns |  1.07 |    0.11 |
|                              LoopUsingGoto | .NET 7.0 | .NET 7.0 | 1000000 | 944,581.98 ns | 31,200.600 ns |  91,995.674 ns | 930,898.39 ns |  1.05 |    0.12 |
