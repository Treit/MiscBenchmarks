# Representing objects having many properties



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count  | Mean            | Error           | StdDev          | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated   | Alloc Ratio |
|-------------------------------------------- |------- |----------------:|----------------:|----------------:|------:|--------:|-----------:|-----------:|----------:|------------:|------------:|
| **NullablePropertiesCreeateAndSet50Properties** | **10**     |        **752.3 ns** |        **14.44 ns** |        **13.51 ns** |  **1.00** |    **0.02** |     **0.9737** |     **0.0286** |         **-** |    **15.91 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | 10     |        637.7 ns |         6.33 ns |         5.61 ns |  0.85 |    0.02 |     0.4950 |     0.0153 |         - |      8.1 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | 10     |      1,303.0 ns |        17.23 ns |        16.12 ns |  1.73 |    0.04 |     0.5436 |     0.0172 |         - |     8.88 KB |        0.56 |
|                                             |        |                 |                 |                 |       |         |            |            |           |             |             |
| **NullablePropertiesCreeateAndSet50Properties** | **1000**   |     **83,540.6 ns** |     **1,605.92 ns** |     **1,502.18 ns** |  **1.00** |    **0.02** |    **97.0459** |    **81.0547** |         **-** |  **1585.99 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | 1000   |     67,573.8 ns |     1,309.64 ns |     1,225.04 ns |  0.81 |    0.02 |    49.1943 |    34.4238 |         - |   804.74 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | 1000   |    138,695.2 ns |     1,714.49 ns |     1,603.74 ns |  1.66 |    0.03 |    53.9551 |    27.0996 |         - |   882.87 KB |        0.56 |
|                                             |        |                 |                 |                 |       |         |            |            |           |             |             |
| **NullablePropertiesCreeateAndSet50Properties** | **100000** | **79,439,034.4 ns** | **1,545,015.35 ns** | **2,705,969.98 ns** |  **1.00** |    **0.05** | **11714.2857** | **11571.4286** | **2142.8571** | **158595.4 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | 100000 | 54,463,854.7 ns | 1,086,394.76 ns | 2,474,270.81 ns |  0.69 |    0.04 |  6600.0000 |  6500.0000 | 1800.0000 | 80470.44 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | 100000 | 87,108,784.8 ns | 1,741,683.94 ns | 3,823,038.76 ns |  1.10 |    0.06 |  7166.6667 |  7000.0000 | 1833.3333 | 88282.14 KB |        0.56 |
