Going from string to enum in a case-insensitive way.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **ToLowerApproach**        | **100**   |   **1,378.2 ns** |    **10.84 ns** |     **9.05 ns** |  **4.41** |    **0.04** |  **0.1450** |    **2432 B** |          **NA** |
| SpanApproach           | 100   |     312.2 ns |     1.93 ns |     1.71 ns |  1.00 |    0.01 |       - |         - |          NA |
| SpanApproachWithSwitch | 100   |     342.3 ns |     2.71 ns |     2.41 ns |  1.10 |    0.01 |       - |         - |          NA |
| TryParseApproach       | 100   |   2,883.5 ns |    14.55 ns |    12.15 ns |  9.24 |    0.06 |  0.0420 |     704 B |          NA |
| TryParseSpanApproach   | 100   |   1,888.6 ns |     5.27 ns |     4.68 ns |  6.05 |    0.04 |       - |         - |          NA |
|                        |       |              |             |             |       |         |         |           |             |
| **ToLowerApproach**        | **10000** | **134,843.2 ns** | **1,667.47 ns** | **1,478.16 ns** |  **4.57** |    **0.05** | **13.9160** |  **233824 B** |          **NA** |
| SpanApproach           | 10000 |  29,490.7 ns |   105.05 ns |    87.72 ns |  1.00 |    0.00 |       - |         - |          NA |
| SpanApproachWithSwitch | 10000 |  34,475.7 ns |   505.23 ns |   421.89 ns |  1.17 |    0.01 |       - |         - |          NA |
| TryParseApproach       | 10000 | 286,524.9 ns | 3,925.39 ns | 3,671.81 ns |  9.72 |    0.12 |  3.9063 |   67674 B |          NA |
| TryParseSpanApproach   | 10000 | 183,646.2 ns | 1,551.71 ns | 1,375.55 ns |  6.23 |    0.05 |       - |         - |          NA |
