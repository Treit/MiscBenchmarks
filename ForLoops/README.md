# Loops








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                     | Job       | Runtime   | Count   | Mean            | Error          | StdDev         | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|------------------------------------------- |---------- |---------- |-------- |----------------:|---------------:|---------------:|------:|--------:|----------:|-----------:|------------:|
| **ClassicForLoop**                             | **.NET 10.0** | **.NET 10.0** | **100**     |        **81.95 ns** |       **0.864 ns** |       **0.808 ns** |  **1.00** |    **0.01** |         **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 10.0 | .NET 10.0 | 100     |        85.50 ns |       0.827 ns |       0.774 ns |  1.04 |    0.01 |         - |          - |          NA |
| LoopUsingGoto                              | .NET 10.0 | .NET 10.0 | 100     |        69.83 ns |       0.900 ns |       0.842 ns |  0.85 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | .NET 10.0 | .NET 10.0 | 100     |       153.90 ns |       1.006 ns |       0.840 ns |  1.88 |    0.02 |    0.0024 |       40 B |          NA |
| LoopUsingRangeEnumerator                   | .NET 10.0 | .NET 10.0 | 100     |        70.08 ns |       1.427 ns |       1.465 ns |  0.86 |    0.02 |         - |          - |          NA |
| LoopUsingSkipAny                           | .NET 10.0 | .NET 10.0 | 100     |       782.17 ns |      15.595 ns |      14.587 ns |  9.55 |    0.19 |    0.2890 |     4848 B |          NA |
|                                            |           |           |         |                 |                |                |       |         |           |            |             |
| ClassicForLoop                             | .NET 9.0  | .NET 9.0  | 100     |        82.86 ns |       0.945 ns |       0.884 ns |  1.00 |    0.01 |         - |          - |          NA |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 9.0  | .NET 9.0  | 100     |        85.71 ns |       0.511 ns |       0.478 ns |  1.03 |    0.01 |         - |          - |          NA |
| LoopUsingGoto                              | .NET 9.0  | .NET 9.0  | 100     |        69.44 ns |       0.512 ns |       0.454 ns |  0.84 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | .NET 9.0  | .NET 9.0  | 100     |       153.30 ns |       1.328 ns |       1.177 ns |  1.85 |    0.02 |    0.0024 |       40 B |          NA |
| LoopUsingRangeEnumerator                   | .NET 9.0  | .NET 9.0  | 100     |        71.05 ns |       1.278 ns |       1.196 ns |  0.86 |    0.02 |         - |          - |          NA |
| LoopUsingSkipAny                           | .NET 9.0  | .NET 9.0  | 100     |       814.04 ns |      14.923 ns |      13.229 ns |  9.83 |    0.18 |    0.2890 |     4848 B |          NA |
|                                            |           |           |         |                 |                |                |       |         |           |            |             |
| **ClassicForLoop**                             | **.NET 10.0** | **.NET 10.0** | **1000000** |   **789,454.89 ns** |   **7,303.382 ns** |   **6,831.588 ns** |  **1.00** |    **0.01** |         **-** |          **-** |          **NA** |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 10.0 | .NET 10.0 | 1000000 |   806,199.34 ns |   5,301.926 ns |   4,700.019 ns |  1.02 |    0.01 |         - |          - |          NA |
| LoopUsingGoto                              | .NET 10.0 | .NET 10.0 | 1000000 |   632,852.63 ns |   3,971.915 ns |   3,715.332 ns |  0.80 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | .NET 10.0 | .NET 10.0 | 1000000 | 1,409,901.94 ns |   6,982.577 ns |   6,531.507 ns |  1.79 |    0.02 |         - |       40 B |          NA |
| LoopUsingRangeEnumerator                   | .NET 10.0 | .NET 10.0 | 1000000 |   635,549.25 ns |   4,331.962 ns |   3,840.171 ns |  0.81 |    0.01 |         - |          - |          NA |
| LoopUsingSkipAny                           | .NET 10.0 | .NET 10.0 | 1000000 | 8,002,987.71 ns | 111,534.284 ns | 104,329.239 ns | 10.14 |    0.15 | 2867.1875 | 48000048 B |          NA |
|                                            |           |           |         |                 |                |                |       |         |           |            |             |
| ClassicForLoop                             | .NET 9.0  | .NET 9.0  | 1000000 |   792,855.41 ns |  11,212.846 ns |   9,939.896 ns |  1.00 |    0.02 |         - |          - |          NA |
| ForLoopPrefixIncrementInsideConditionCheck | .NET 9.0  | .NET 9.0  | 1000000 |   803,166.98 ns |   3,482.306 ns |   3,086.974 ns |  1.01 |    0.01 |         - |          - |          NA |
| LoopUsingGoto                              | .NET 9.0  | .NET 9.0  | 1000000 |   629,509.64 ns |   4,601.437 ns |   4,304.187 ns |  0.79 |    0.01 |         - |          - |          NA |
| LoopUsingEnumerableRange                   | .NET 9.0  | .NET 9.0  | 1000000 | 1,412,547.32 ns |   9,351.660 ns |   8,747.548 ns |  1.78 |    0.02 |         - |       40 B |          NA |
| LoopUsingRangeEnumerator                   | .NET 9.0  | .NET 9.0  | 1000000 |   636,240.04 ns |   4,672.062 ns |   4,370.250 ns |  0.80 |    0.01 |         - |          - |          NA |
| LoopUsingSkipAny                           | .NET 9.0  | .NET 9.0  | 1000000 | 8,149,185.25 ns | 157,964.637 ns | 210,878.271 ns | 10.28 |    0.29 | 2859.3750 | 48000048 B |          NA |
