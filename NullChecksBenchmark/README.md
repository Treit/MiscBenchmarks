# Checking if any one of a series of values is null





```

BenchmarkDotNet v0.15.1, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Job       | Runtime   | Scenario   | Iterations | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------- |---------- |---------- |----------- |----------- |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **ExplicitNullChecks**    | **.NET 10.0** | **.NET 10.0** | **AllNonNull** | **1000**       |   **1,864.4 ns** |     **2.39 ns** |     **2.11 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | .NET 10.0 | .NET 10.0 | AllNonNull | 1000       |  22,142.6 ns |   145.90 ns |   136.47 ns | 11.88 |    0.07 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | .NET 10.0 | .NET 10.0 | AllNonNull | 1000       |   2,486.8 ns |     3.02 ns |     2.53 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| ExplicitNullChecks    | .NET 9.0  | .NET 9.0  | AllNonNull | 1000       |   1,865.1 ns |     4.37 ns |     3.65 ns |  1.00 |    0.00 |       - |         - |          NA |
| LinqAnyWithArray      | .NET 9.0  | .NET 9.0  | AllNonNull | 1000       |  22,165.7 ns |   217.66 ns |   203.60 ns | 11.88 |    0.11 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | .NET 9.0  | .NET 9.0  | AllNonNull | 1000       |   2,486.5 ns |     3.14 ns |     2.78 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **.NET 10.0** | **.NET 10.0** | **AllNonNull** | **10000**      |  **18,611.3 ns** |    **19.87 ns** |    **16.59 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | .NET 10.0 | .NET 10.0 | AllNonNull | 10000      | 220,660.5 ns | 2,688.56 ns | 2,383.34 ns | 11.86 |    0.12 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | .NET 10.0 | .NET 10.0 | AllNonNull | 10000      |  24,840.3 ns |    76.91 ns |    64.22 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| ExplicitNullChecks    | .NET 9.0  | .NET 9.0  | AllNonNull | 10000      |  18,640.8 ns |    57.07 ns |    50.59 ns |  1.00 |    0.00 |       - |         - |          NA |
| LinqAnyWithArray      | .NET 9.0  | .NET 9.0  | AllNonNull | 10000      | 219,304.9 ns | 1,446.19 ns | 1,129.09 ns | 11.76 |    0.07 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | .NET 9.0  | .NET 9.0  | AllNonNull | 10000      |  24,821.9 ns |    32.18 ns |    28.53 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **.NET 10.0** | **.NET 10.0** | **LastNull**   | **1000**       |   **1,870.3 ns** |     **9.54 ns** |     **8.92 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | .NET 10.0 | .NET 10.0 | LastNull   | 1000       |  22,086.3 ns |   240.02 ns |   212.77 ns | 11.81 |    0.12 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | .NET 10.0 | .NET 10.0 | LastNull   | 1000       |   2,489.1 ns |     4.93 ns |     4.12 ns |  1.33 |    0.01 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| ExplicitNullChecks    | .NET 9.0  | .NET 9.0  | LastNull   | 1000       |   1,867.4 ns |     5.46 ns |     5.10 ns |  1.00 |    0.00 |       - |         - |          NA |
| LinqAnyWithArray      | .NET 9.0  | .NET 9.0  | LastNull   | 1000       |  21,522.8 ns |   177.71 ns |   166.23 ns | 11.53 |    0.09 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | .NET 9.0  | .NET 9.0  | LastNull   | 1000       |   2,486.9 ns |     2.82 ns |     2.20 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **.NET 10.0** | **.NET 10.0** | **LastNull**   | **10000**      |  **18,624.4 ns** |    **42.81 ns** |    **37.95 ns** |  **1.00** |    **0.00** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | .NET 10.0 | .NET 10.0 | LastNull   | 10000      | 219,438.2 ns | 1,873.75 ns | 1,752.70 ns | 11.78 |    0.09 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | .NET 10.0 | .NET 10.0 | LastNull   | 10000      |  24,833.5 ns |    52.39 ns |    43.75 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| ExplicitNullChecks    | .NET 9.0  | .NET 9.0  | LastNull   | 10000      |  18,625.2 ns |    36.64 ns |    30.60 ns |  1.00 |    0.00 |       - |         - |          NA |
| LinqAnyWithArray      | .NET 9.0  | .NET 9.0  | LastNull   | 10000      | 213,744.3 ns | 1,625.23 ns | 1,440.73 ns | 11.48 |    0.08 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | .NET 9.0  | .NET 9.0  | LastNull   | 10000      |  24,813.7 ns |    25.97 ns |    24.29 ns |  1.33 |    0.00 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **.NET 10.0** | **.NET 10.0** | **OneNull**    | **1000**       |     **321.8 ns** |     **3.31 ns** |     **3.10 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | .NET 10.0 | .NET 10.0 | OneNull    | 1000       |  19,244.9 ns |   157.29 ns |   147.13 ns | 59.81 |    0.71 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | .NET 10.0 | .NET 10.0 | OneNull    | 1000       |   1,247.2 ns |     1.00 ns |     0.94 ns |  3.88 |    0.04 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| ExplicitNullChecks    | .NET 9.0  | .NET 9.0  | OneNull    | 1000       |     322.4 ns |     3.78 ns |     3.54 ns |  1.00 |    0.02 |       - |         - |          NA |
| LinqAnyWithArray      | .NET 9.0  | .NET 9.0  | OneNull    | 1000       |  19,279.8 ns |   187.92 ns |   175.78 ns | 59.80 |    0.82 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | .NET 9.0  | .NET 9.0  | OneNull    | 1000       |   1,248.3 ns |     1.26 ns |     1.05 ns |  3.87 |    0.04 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **.NET 10.0** | **.NET 10.0** | **OneNull**    | **10000**      |   **3,136.8 ns** |    **14.76 ns** |    **12.33 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | .NET 10.0 | .NET 10.0 | OneNull    | 10000      | 192,192.2 ns | 2,080.56 ns | 1,946.16 ns | 61.27 |    0.64 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | .NET 10.0 | .NET 10.0 | OneNull    | 10000      |  12,422.5 ns |    34.73 ns |    29.00 ns |  3.96 |    0.02 |       - |         - |          NA |
|                       |           |           |            |            |              |             |             |       |         |         |           |             |
| ExplicitNullChecks    | .NET 9.0  | .NET 9.0  | OneNull    | 10000      |   3,114.8 ns |     6.82 ns |     5.70 ns |  1.00 |    0.00 |       - |         - |          NA |
| LinqAnyWithArray      | .NET 9.0  | .NET 9.0  | OneNull    | 10000      | 193,188.2 ns | 1,114.36 ns |   987.85 ns | 62.02 |    0.33 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | .NET 9.0  | .NET 9.0  | OneNull    | 10000      |  12,545.4 ns |    53.77 ns |    50.30 ns |  4.03 |    0.02 |       - |         - |          NA |
