Going from string to enum in a case-insensitive way.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------- |---------- |---------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **ToLowerApproach**        | **.NET 10.0** | **.NET 10.0** | **100**   |   **1,346.6 ns** |     **4.99 ns** |     **4.17 ns** |  **4.33** |    **0.03** |  **0.1450** |    **2432 B** |          **NA** |
| SpanApproach           | .NET 10.0 | .NET 10.0 | 100   |     310.9 ns |     1.96 ns |     1.83 ns |  1.00 |    0.01 |       - |         - |          NA |
| SpanApproachWithSwitch | .NET 10.0 | .NET 10.0 | 100   |     330.4 ns |     1.88 ns |     1.57 ns |  1.06 |    0.01 |       - |         - |          NA |
| TryParseApproach       | .NET 10.0 | .NET 10.0 | 100   |   2,845.5 ns |     7.47 ns |     6.62 ns |  9.15 |    0.06 |  0.0420 |     704 B |          NA |
| TryParseSpanApproach   | .NET 10.0 | .NET 10.0 | 100   |   1,849.4 ns |     3.81 ns |     3.38 ns |  5.95 |    0.04 |       - |         - |          NA |
|                        |           |           |       |              |             |             |       |         |         |           |             |
| ToLowerApproach        | .NET 9.0  | .NET 9.0  | 100   |   1,356.8 ns |    16.65 ns |    15.58 ns |  4.36 |    0.05 |  0.1450 |    2432 B |          NA |
| SpanApproach           | .NET 9.0  | .NET 9.0  | 100   |     311.1 ns |     0.89 ns |     0.74 ns |  1.00 |    0.00 |       - |         - |          NA |
| SpanApproachWithSwitch | .NET 9.0  | .NET 9.0  | 100   |     348.6 ns |     1.18 ns |     0.98 ns |  1.12 |    0.00 |       - |         - |          NA |
| TryParseApproach       | .NET 9.0  | .NET 9.0  | 100   |   2,957.5 ns |    21.17 ns |    17.68 ns |  9.51 |    0.06 |  0.0420 |     704 B |          NA |
| TryParseSpanApproach   | .NET 9.0  | .NET 9.0  | 100   |   1,881.2 ns |     6.39 ns |     5.66 ns |  6.05 |    0.02 |       - |         - |          NA |
|                        |           |           |       |              |             |             |       |         |         |           |             |
| **ToLowerApproach**        | **.NET 10.0** | **.NET 10.0** | **10000** | **132,708.0 ns** | **1,620.29 ns** | **1,515.62 ns** |  **4.54** |    **0.05** | **13.9160** |  **233824 B** |          **NA** |
| SpanApproach           | .NET 10.0 | .NET 10.0 | 10000 |  29,238.3 ns |    43.97 ns |    38.98 ns |  1.00 |    0.00 |       - |         - |          NA |
| SpanApproachWithSwitch | .NET 10.0 | .NET 10.0 | 10000 |  33,469.2 ns |    46.61 ns |    36.39 ns |  1.14 |    0.00 |       - |         - |          NA |
| TryParseApproach       | .NET 10.0 | .NET 10.0 | 10000 | 279,342.7 ns | 1,407.88 ns | 1,316.94 ns |  9.55 |    0.05 |  3.9063 |   67674 B |          NA |
| TryParseSpanApproach   | .NET 10.0 | .NET 10.0 | 10000 | 184,646.6 ns |   422.95 ns |   374.93 ns |  6.32 |    0.01 |       - |         - |          NA |
|                        |           |           |       |              |             |             |       |         |         |           |             |
| ToLowerApproach        | .NET 9.0  | .NET 9.0  | 10000 | 139,522.7 ns | 1,249.19 ns | 1,107.37 ns |  4.77 |    0.04 | 13.9160 |  233824 B |          NA |
| SpanApproach           | .NET 9.0  | .NET 9.0  | 10000 |  29,249.2 ns |    35.05 ns |    27.36 ns |  1.00 |    0.00 |       - |         - |          NA |
| SpanApproachWithSwitch | .NET 9.0  | .NET 9.0  | 10000 |  33,488.4 ns |    52.56 ns |    43.89 ns |  1.14 |    0.00 |       - |       1 B |          NA |
| TryParseApproach       | .NET 9.0  | .NET 9.0  | 10000 | 285,399.9 ns | 1,912.26 ns | 1,788.73 ns |  9.76 |    0.06 |  3.9063 |   67674 B |          NA |
| TryParseSpanApproach   | .NET 9.0  | .NET 9.0  | 10000 | 184,331.2 ns |   631.38 ns |   590.59 ns |  6.30 |    0.02 |       - |         - |          NA |
