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
| **SumWithForEachUnsorted** | **1000**   |    **321.2 ns** |   **1.74 ns** |   **1.63 ns** |    **321.7 ns** |  **0.60** |    **0.12** |
| SumWithForEachSorted   | 1000   |    321.1 ns |   2.03 ns |   1.90 ns |    321.6 ns |  0.60 |    0.12 |
| MaxWithForEachUnsorted | 1000   |    348.9 ns |   6.29 ns |   5.88 ns |    348.4 ns |  0.65 |    0.13 |
| MaxWithForEachSorted   | 1000   |    554.3 ns |  28.68 ns |  84.56 ns |    575.4 ns |  1.03 |    0.26 |
| KoziMax                | 1000   |    299.0 ns |   1.99 ns |   1.76 ns |    299.7 ns |  0.56 |    0.11 |
| KoziMaxSorted          | 1000   |    298.6 ns |   1.77 ns |   1.66 ns |    299.4 ns |  0.56 |    0.11 |
|                        |        |             |           |           |             |       |         |
| **SumWithForEachUnsorted** | **100000** | **31,615.5 ns** | **329.42 ns** | **308.14 ns** | **31,648.6 ns** |  **1.00** |    **0.02** |
| SumWithForEachSorted   | 100000 | 31,457.0 ns | 350.74 ns | 328.09 ns | 31,377.3 ns |  1.00 |    0.02 |
| MaxWithForEachUnsorted | 100000 | 31,507.4 ns | 255.13 ns | 238.65 ns | 31,316.6 ns |  1.00 |    0.01 |
| MaxWithForEachSorted   | 100000 | 31,581.7 ns | 416.18 ns | 389.30 ns | 31,622.3 ns |  1.00 |    0.02 |
| KoziMax                | 100000 | 31,221.4 ns | 189.07 ns | 176.85 ns | 31,093.4 ns |  0.99 |    0.01 |
| KoziMaxSorted          | 100000 | 31,236.1 ns | 214.55 ns | 200.69 ns | 31,127.5 ns |  0.99 |    0.01 |
