Going from string to enum in a case-insensitive way.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27943.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                 | Count | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|--------:|----------:|------------:|
| **ToLowerApproach**        | **100**   |   **2,036.0 ns** |     **80.35 ns** |    **225.31 ns** |   **1,971.0 ns** |  **4.07** |    **0.46** |  **0.5608** |    **2432 B** |          **NA** |
| SpanApproach           | 100   |     500.7 ns |      9.20 ns |     11.30 ns |     501.2 ns |  1.00 |    0.03 |       - |         - |          NA |
| SpanApproachWithSwitch | 100   |     533.6 ns |     10.21 ns |     15.28 ns |     529.4 ns |  1.07 |    0.04 |       - |         - |          NA |
| TryParseApproach       | 100   |   2,971.7 ns |     58.85 ns |    104.61 ns |   2,946.6 ns |  5.94 |    0.24 |  0.1602 |     704 B |          NA |
| TryParseSpanApproach   | 100   |   1,926.8 ns |     31.21 ns |     49.50 ns |   1,919.9 ns |  3.85 |    0.13 |       - |         - |          NA |
|                        |       |              |              |              |              |       |         |         |           |             |
| **ToLowerApproach**        | **10000** | **183,786.4 ns** |  **3,623.42 ns** |  **4,449.88 ns** | **184,084.1 ns** |  **3.86** |    **0.10** | **54.1992** |  **233824 B** |          **NA** |
| SpanApproach           | 10000 |  47,611.2 ns |    732.68 ns |    611.82 ns |  47,445.0 ns |  1.00 |    0.02 |       - |         - |          NA |
| SpanApproachWithSwitch | 10000 |  53,501.3 ns |  1,068.02 ns |  2,579.38 ns |  53,151.5 ns |  1.12 |    0.06 |       - |         - |          NA |
| TryParseApproach       | 10000 | 298,501.3 ns |  5,461.64 ns | 11,756.75 ns | 298,232.7 ns |  6.27 |    0.26 | 15.6250 |   67678 B |          NA |
| TryParseSpanApproach   | 10000 | 241,778.5 ns | 15,898.21 ns | 46,876.24 ns | 219,954.5 ns |  5.08 |    0.98 |       - |         - |          NA |
