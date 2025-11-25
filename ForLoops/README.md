# Loops






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Count   | Mean            | Error          | StdDev         | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|------------------------------------------- |-------- |----------------:|---------------:|---------------:|------:|--------:|----------:|-----------:|------------:|
| **ClassicForLoop**                             | **100**     |        **80.68 ns** |       **0.444 ns** |       **0.347 ns** |  **1.00** |    **0.01** |         **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | 100     |        84.81 ns |       0.399 ns |       0.354 ns |  1.05 |    0.01 |         - |          - |          NA |
| LoopUsingGoto                              | 100     |        70.43 ns |       1.142 ns |       1.013 ns |  0.87 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | 100     |       157.54 ns |       0.801 ns |       0.710 ns |  1.95 |    0.01 |    0.0024 |       40 B |          NA |
| LoopUsingRangeEnumerator                   | 100     |        70.54 ns |       1.409 ns |       1.832 ns |  0.87 |    0.02 |         - |          - |          NA |
| LoopUsingSkipAny                           | 100     |       800.76 ns |       6.153 ns |       5.756 ns |  9.93 |    0.08 |    0.2890 |     4848 B |          NA |
|                                            |         |                 |                |                |       |         |           |            |             |
| **ClassicForLoop**                             | **1000000** |   **768,115.10 ns** |   **4,926.387 ns** |   **4,367.114 ns** |  **1.00** |    **0.01** |         **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 |   800,977.08 ns |   3,153.213 ns |   2,949.517 ns |  1.04 |    0.01 |         - |       12 B |          NA |
| LoopUsingGoto                              | 1000000 |   643,781.28 ns |   4,383.143 ns |   4,099.995 ns |  0.84 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | 1000000 | 1,403,283.80 ns |   7,078.090 ns |   6,274.542 ns |  1.83 |    0.01 |         - |       40 B |          NA |
| LoopUsingRangeEnumerator                   | 1000000 |   634,272.74 ns |   3,782.908 ns |   3,538.535 ns |  0.83 |    0.01 |         - |          - |          NA |
| LoopUsingSkipAny                           | 1000000 | 8,060,531.67 ns | 128,705.404 ns | 120,391.115 ns | 10.49 |    0.16 | 2859.3750 | 48000048 B |          NA |
