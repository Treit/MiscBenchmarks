# ForEach vs. directly using the enumerator.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count  | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD |
|----------------------- |---------- |---------- |------- |------------:|----------:|----------:|------------:|------:|--------:|
| **SumWithForEachUnsorted** | **.NET 10.0** | **.NET 10.0** | **1000**   |    **318.9 ns** |   **0.47 ns** |   **0.44 ns** |    **319.0 ns** |  **0.60** |    **0.12** |
| SumWithForEachSorted   | .NET 10.0 | .NET 10.0 | 1000   |    320.4 ns |   2.36 ns |   2.20 ns |    319.6 ns |  0.61 |    0.12 |
| MaxWithForEachUnsorted | .NET 10.0 | .NET 10.0 | 1000   |    376.1 ns |   5.56 ns |   4.93 ns |    376.5 ns |  0.71 |    0.14 |
| MaxWithForEachSorted   | .NET 10.0 | .NET 10.0 | 1000   |    544.2 ns |  28.41 ns |  83.75 ns |    572.5 ns |  1.03 |    0.26 |
| KoziMax                | .NET 10.0 | .NET 10.0 | 1000   |    297.4 ns |   0.22 ns |   0.19 ns |    297.3 ns |  0.56 |    0.11 |
| KoziMaxSorted          | .NET 10.0 | .NET 10.0 | 1000   |    297.5 ns |   0.30 ns |   0.27 ns |    297.5 ns |  0.56 |    0.11 |
|                        |           |           |        |             |           |           |             |       |         |
| SumWithForEachUnsorted | .NET 9.0  | .NET 9.0  | 1000   |    318.6 ns |   0.73 ns |   0.65 ns |    318.4 ns |  0.63 |    0.12 |
| SumWithForEachSorted   | .NET 9.0  | .NET 9.0  | 1000   |    318.5 ns |   0.52 ns |   0.46 ns |    318.3 ns |  0.63 |    0.12 |
| MaxWithForEachUnsorted | .NET 9.0  | .NET 9.0  | 1000   |    337.7 ns |   3.21 ns |   3.00 ns |    337.6 ns |  0.67 |    0.13 |
| MaxWithForEachSorted   | .NET 9.0  | .NET 9.0  | 1000   |    523.3 ns |  29.28 ns |  86.33 ns |    550.4 ns |  1.03 |    0.27 |
| KoziMax                | .NET 9.0  | .NET 9.0  | 1000   |    297.5 ns |   0.33 ns |   0.29 ns |    297.5 ns |  0.59 |    0.12 |
| KoziMaxSorted          | .NET 9.0  | .NET 9.0  | 1000   |    297.6 ns |   0.33 ns |   0.29 ns |    297.5 ns |  0.59 |    0.12 |
|                        |           |           |        |             |           |           |             |       |         |
| **SumWithForEachUnsorted** | **.NET 10.0** | **.NET 10.0** | **100000** | **31,250.9 ns** |  **82.84 ns** |  **73.44 ns** | **31,236.3 ns** |  **0.50** |    **0.00** |
| SumWithForEachSorted   | .NET 10.0 | .NET 10.0 | 100000 | 31,316.9 ns |  23.02 ns |  17.97 ns | 31,311.3 ns |  0.50 |    0.00 |
| MaxWithForEachUnsorted | .NET 10.0 | .NET 10.0 | 100000 | 31,508.0 ns | 183.79 ns | 162.93 ns | 31,461.9 ns |  0.50 |    0.00 |
| MaxWithForEachSorted   | .NET 10.0 | .NET 10.0 | 100000 | 62,414.0 ns | 131.39 ns | 109.72 ns | 62,369.6 ns |  1.00 |    0.00 |
| KoziMax                | .NET 10.0 | .NET 10.0 | 100000 | 31,074.6 ns |  18.51 ns |  17.32 ns | 31,075.2 ns |  0.50 |    0.00 |
| KoziMaxSorted          | .NET 10.0 | .NET 10.0 | 100000 | 31,084.9 ns |  17.26 ns |  16.15 ns | 31,084.1 ns |  0.50 |    0.00 |
|                        |           |           |        |             |           |           |             |       |         |
| SumWithForEachUnsorted | .NET 9.0  | .NET 9.0  | 100000 | 31,263.6 ns |  91.57 ns |  81.18 ns | 31,251.7 ns |  0.50 |    0.00 |
| SumWithForEachSorted   | .NET 9.0  | .NET 9.0  | 100000 | 31,335.6 ns |  41.35 ns |  32.28 ns | 31,342.5 ns |  0.50 |    0.00 |
| MaxWithForEachUnsorted | .NET 9.0  | .NET 9.0  | 100000 | 31,556.6 ns | 264.79 ns | 234.73 ns | 31,509.1 ns |  0.50 |    0.00 |
| MaxWithForEachSorted   | .NET 9.0  | .NET 9.0  | 100000 | 62,629.8 ns | 415.95 ns | 368.73 ns | 62,476.1 ns |  1.00 |    0.01 |
| KoziMax                | .NET 9.0  | .NET 9.0  | 100000 | 31,105.6 ns |  40.49 ns |  37.87 ns | 31,109.4 ns |  0.50 |    0.00 |
| KoziMaxSorted          | .NET 9.0  | .NET 9.0  | 100000 | 31,131.2 ns |  34.31 ns |  30.41 ns | 31,137.1 ns |  0.50 |    0.00 |
