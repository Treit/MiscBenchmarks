# ForEach vs. directly using the enumerator.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count  | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD |
|----------------------- |------- |------------:|----------:|----------:|------------:|------:|--------:|
| **SumWithForEachUnsorted** | **1000**   |    **321.0 ns** |   **1.76 ns** |   **1.65 ns** |    **321.5 ns** |  **0.61** |    **0.10** |
| SumWithForEachSorted   | 1000   |    321.0 ns |   1.79 ns |   1.67 ns |    321.2 ns |  0.61 |    0.10 |
| MaxWithForEachUnsorted | 1000   |    326.1 ns |   4.10 ns |   3.84 ns |    326.9 ns |  0.62 |    0.10 |
| MaxWithForEachSorted   | 1000   |    535.5 ns |  24.70 ns |  72.82 ns |    547.2 ns |  1.02 |    0.21 |
| KoziMax                | 1000   |    298.8 ns |   1.43 ns |   1.33 ns |    299.6 ns |  0.57 |    0.09 |
| KoziMaxSorted          | 1000   |    298.7 ns |   1.46 ns |   1.37 ns |    299.5 ns |  0.57 |    0.09 |
|                        |        |             |           |           |             |       |         |
| **SumWithForEachUnsorted** | **100000** | **31,443.8 ns** | **254.15 ns** | **237.73 ns** | **31,534.7 ns** |  **0.50** |    **0.01** |
| SumWithForEachSorted   | 100000 | 31,474.0 ns | 302.38 ns | 282.84 ns | 31,623.4 ns |  0.50 |    0.01 |
| MaxWithForEachUnsorted | 100000 | 31,524.9 ns | 291.22 ns | 272.41 ns | 31,629.2 ns |  0.50 |    0.01 |
| MaxWithForEachSorted   | 100000 | 62,992.5 ns | 631.80 ns | 590.98 ns | 63,067.8 ns |  1.00 |    0.01 |
| KoziMax                | 100000 | 31,282.9 ns | 202.16 ns | 189.10 ns | 31,431.9 ns |  0.50 |    0.01 |
| KoziMaxSorted          | 100000 | 31,295.4 ns | 213.87 ns | 200.05 ns | 31,133.1 ns |  0.50 |    0.01 |
