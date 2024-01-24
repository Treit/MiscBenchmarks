# Loops



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26038.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                     Method |   Count |            Mean |         Error |        StdDev | Ratio | RatioSD |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|------:|--------:|
|                             **ClassicForLoop** |     **100** |        **72.84 ns** |      **1.455 ns** |      **2.221 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck |     100 |        74.42 ns |      1.165 ns |      1.341 ns |  1.02 |    0.03 |
|                              LoopUsingGoto |     100 |        83.90 ns |      1.720 ns |      2.113 ns |  1.15 |    0.05 |
|                   LoopUsingEnumerableRange |     100 |       291.95 ns |      5.857 ns |     10.411 ns |  4.02 |    0.20 |
|                   LoopUsingRangeEnumerator |     100 |        75.23 ns |      1.517 ns |      1.919 ns |  1.03 |    0.04 |
|                                            |         |                 |               |               |       |         |
|                             **ClassicForLoop** | **1000000** |   **680,768.45 ns** | **13,564.649 ns** | **25,142.946 ns** |  **1.00** |    **0.00** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 |   684,638.51 ns | 13,518.242 ns | 34,652.421 ns |  1.01 |    0.06 |
|                              LoopUsingGoto | 1000000 |   814,745.83 ns | 16,134.865 ns | 27,831.849 ns |  1.20 |    0.06 |
|                   LoopUsingEnumerableRange | 1000000 | 2,710,741.86 ns | 50,812.685 ns | 77,596.337 ns |  3.98 |    0.16 |
|                   LoopUsingRangeEnumerator | 1000000 |   697,435.27 ns | 13,879.618 ns | 24,309.031 ns |  1.02 |    0.06 |
