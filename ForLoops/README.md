# Loops


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26038.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                     Method |   Count |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|
|                             **ClassicForLoop** |     **100** |        **79.26 ns** |      **2.014 ns** |      **5.812 ns** |        **79.23 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck |     100 |        75.70 ns |      1.481 ns |      3.432 ns |        75.85 ns |  0.95 |    0.08 |
|                              LoopUsingGoto |     100 |        81.58 ns |      1.533 ns |      3.847 ns |        80.06 ns |  1.02 |    0.09 |
|                   LoopUsingEnumerableRange |     100 |       238.34 ns |      4.698 ns |      7.849 ns |       238.73 ns |  3.03 |    0.22 |
|                                            |         |                 |               |               |                 |       |         |
|                             **ClassicForLoop** | **1000000** |   **666,023.61 ns** | **12,100.522 ns** | **13,934.979 ns** |   **663,840.53 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 |   669,570.51 ns | 13,011.928 ns | 25,684.277 ns |   662,953.76 ns |  1.02 |    0.05 |
|                              LoopUsingGoto | 1000000 |   789,703.43 ns | 17,005.078 ns | 49,063.538 ns |   776,664.79 ns |  1.23 |    0.08 |
|                   LoopUsingEnumerableRange | 1000000 | 2,151,068.81 ns | 42,634.815 ns | 86,124.429 ns | 2,131,388.67 ns |  3.28 |    0.14 |
