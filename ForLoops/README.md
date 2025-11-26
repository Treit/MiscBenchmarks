# Loops







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Count   | Mean            | Error         | StdDev        | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|------:|--------:|----------:|-----------:|------------:|
| **ClassicForLoop**                             | **100**     |        **80.84 ns** |      **0.444 ns** |      **0.394 ns** |  **1.00** |    **0.01** |         **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | 100     |        85.02 ns |      0.791 ns |      0.701 ns |  1.05 |    0.01 |         - |          - |          NA |
| LoopUsingGoto                              | 100     |        69.86 ns |      0.587 ns |      0.549 ns |  0.86 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | 100     |       152.39 ns |      1.046 ns |      0.873 ns |  1.89 |    0.01 |    0.0024 |       40 B |          NA |
| LoopUsingRangeEnumerator                   | 100     |        70.26 ns |      1.411 ns |      1.320 ns |  0.87 |    0.02 |         - |          - |          NA |
| LoopUsingSkipAny                           | 100     |       781.52 ns |     10.512 ns |      9.833 ns |  9.67 |    0.13 |    0.2890 |     4848 B |          NA |
|                                            |         |                 |               |               |       |         |           |            |             |
| **ClassicForLoop**                             | **1000000** |   **769,897.33 ns** |  **3,622.987 ns** |  **3,025.358 ns** |  **1.00** |    **0.01** |         **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | 1000000 |   800,641.50 ns |  2,406.495 ns |  2,251.037 ns |  1.04 |    0.00 |         - |          - |          NA |
| LoopUsingGoto                              | 1000000 |   645,390.92 ns |  5,666.344 ns |  5,300.302 ns |  0.84 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | 1000000 | 1,406,945.70 ns |  8,480.236 ns |  7,932.418 ns |  1.83 |    0.01 |         - |       40 B |          NA |
| LoopUsingRangeEnumerator                   | 1000000 |   633,196.50 ns |  3,972.101 ns |  3,715.505 ns |  0.82 |    0.01 |         - |          - |          NA |
| LoopUsingSkipAny                           | 1000000 | 7,797,943.02 ns | 77,569.050 ns | 72,558.137 ns | 10.13 |    0.10 | 2867.1875 | 48000048 B |          NA |
