# Loops





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26254.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                     | Count   | Mean             | Error          | StdDev         | Median           | Ratio | RatioSD | Gen0       | Allocated  | Alloc Ratio |
|------------------------------------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|-----------:|-----------:|------------:|
| **ClassicForLoop**                             | **100**     |         **68.68 ns** |       **1.392 ns** |       **1.710 ns** |         **68.14 ns** |  **1.00** |    **0.00** |          **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | 100     |         69.11 ns |       0.797 ns |       0.745 ns |         68.93 ns |  1.00 |    0.03 |          - |          - |          NA |
| LoopUsingGoto                              | 100     |         79.13 ns |       1.629 ns |       3.100 ns |         77.87 ns |  1.17 |    0.05 |          - |          - |          NA |
| LoopUsingEnumerableRange                   | 100     |        265.66 ns |       2.154 ns |       2.015 ns |        265.29 ns |  3.86 |    0.11 |     0.0091 |       40 B |          NA |
| LoopUsingRangeEnumerator                   | 100     |         71.29 ns |       1.461 ns |       1.624 ns |         70.68 ns |  1.04 |    0.04 |          - |          - |          NA |
| LoopUsingSkipAny                           | 100     |      2,117.01 ns |      38.128 ns |      52.191 ns |      2,100.20 ns | 30.94 |    1.08 |     1.1215 |     4848 B |          NA |
|                                            |         |                  |                |                |                  |       |         |            |            |             |
| **ClassicForLoop**                             | **1000000** |    **621,601.79 ns** |   **4,292.268 ns** |   **3,804.984 ns** |    **621,258.54 ns** |  **1.00** |    **0.00** |          **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 |    634,262.15 ns |  11,845.962 ns |  13,641.827 ns |    628,994.82 ns |  1.02 |    0.02 |          - |          - |          NA |
| LoopUsingGoto                              | 1000000 |    736,970.26 ns |  14,663.823 ns |  40,876.879 ns |    720,258.35 ns |  1.28 |    0.07 |          - |          - |          NA |
| LoopUsingEnumerableRange                   | 1000000 |  2,446,004.27 ns |  11,932.605 ns |  11,161.766 ns |  2,444,328.12 ns |  3.93 |    0.03 |          - |       42 B |          NA |
| LoopUsingRangeEnumerator                   | 1000000 |    661,470.06 ns |  15,670.585 ns |  44,454.843 ns |    645,006.93 ns |  1.04 |    0.04 |          - |          - |          NA |
| LoopUsingSkipAny                           | 1000000 | 21,023,507.14 ns | 407,560.965 ns | 485,172.337 ns | 20,955,762.50 ns | 33.86 |    0.92 | 11125.0000 | 48000060 B |          NA |
