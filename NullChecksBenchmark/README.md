# Checking if any one of a series of values is null




```

BenchmarkDotNet v0.15.1, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Scenario   | Iterations | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|---------------------- |----------- |----------- |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **ExplicitNullChecks**    | **AllNonNull** | **1000**       |   **1,735.2 ns** |     **7.16 ns** |     **6.70 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | AllNonNull | 1000       |  22,235.3 ns |   185.99 ns |   164.87 ns | 12.81 |    0.10 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | AllNonNull | 1000       |   2,509.6 ns |    17.48 ns |    16.35 ns |  1.45 |    0.01 |       - |         - |          NA |
|                       |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **AllNonNull** | **10000**      |  **17,211.6 ns** |   **113.68 ns** |   **106.34 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | AllNonNull | 10000      | 221,851.4 ns | 1,646.59 ns | 1,459.66 ns | 12.89 |    0.11 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | AllNonNull | 10000      |  25,019.0 ns |   141.22 ns |   132.10 ns |  1.45 |    0.01 |       - |         - |          NA |
|                       |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **LastNull**   | **1000**       |   **1,733.3 ns** |    **10.68 ns** |     **9.99 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | LastNull   | 1000       |  22,940.5 ns |   436.98 ns |   408.75 ns | 13.24 |    0.24 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | LastNull   | 1000       |   2,510.3 ns |    18.37 ns |    15.34 ns |  1.45 |    0.01 |       - |         - |          NA |
|                       |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **LastNull**   | **10000**      |  **17,253.4 ns** |   **118.28 ns** |   **110.64 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | LastNull   | 10000      | 230,904.9 ns | 2,067.96 ns | 1,934.37 ns | 13.38 |    0.14 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | LastNull   | 10000      |  25,018.7 ns |   138.17 ns |   122.48 ns |  1.45 |    0.01 |       - |         - |          NA |
|                       |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **OneNull**    | **1000**       |     **326.0 ns** |     **2.74 ns** |     **2.57 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | OneNull    | 1000       |  19,544.7 ns |   344.68 ns |   322.41 ns | 59.96 |    1.06 |  6.1951 |  104000 B |          NA |
| PatternMatchingSwitch | OneNull    | 1000       |   1,260.4 ns |     8.88 ns |     8.31 ns |  3.87 |    0.04 |       - |         - |          NA |
|                       |            |            |              |             |             |       |         |         |           |             |
| **ExplicitNullChecks**    | **OneNull**    | **10000**      |   **3,162.2 ns** |    **30.59 ns** |    **28.61 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| LinqAnyWithArray      | OneNull    | 10000      | 198,738.8 ns | 3,389.43 ns | 2,830.33 ns | 62.85 |    1.02 | 62.0117 | 1040000 B |          NA |
| PatternMatchingSwitch | OneNull    | 10000      |  12,560.4 ns |    71.23 ns |    63.14 ns |  3.97 |    0.04 |       - |         - |          NA |
