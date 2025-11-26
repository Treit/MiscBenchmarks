# Representing objects having many properties




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count  | Mean            | Error           | StdDev          | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated    | Alloc Ratio |
|-------------------------------------------- |------- |----------------:|----------------:|----------------:|------:|--------:|-----------:|-----------:|----------:|-------------:|------------:|
| **NullablePropertiesCreeateAndSet50Properties** | **10**     |        **712.2 ns** |        **13.85 ns** |        **15.40 ns** |  **1.00** |    **0.03** |     **0.9737** |     **0.0286** |         **-** |     **15.91 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | 10     |        647.7 ns |        12.74 ns |        14.67 ns |  0.91 |    0.03 |     0.4950 |     0.0153 |         - |       8.1 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | 10     |      1,292.1 ns |        13.83 ns |        12.93 ns |  1.82 |    0.04 |     0.5436 |     0.0172 |         - |      8.88 KB |        0.56 |
|                                             |        |                 |                 |                 |       |         |            |            |           |              |             |
| **NullablePropertiesCreeateAndSet50Properties** | **1000**   |     **80,296.9 ns** |     **1,570.87 ns** |     **1,469.39 ns** |  **1.00** |    **0.03** |    **97.0459** |    **81.0547** |         **-** |   **1585.99 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | 1000   |     66,300.8 ns |     1,299.75 ns |     1,779.11 ns |  0.83 |    0.03 |    49.1943 |    34.4238 |         - |    804.74 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | 1000   |    137,315.9 ns |     1,808.00 ns |     1,602.75 ns |  1.71 |    0.04 |    53.9551 |    27.0996 |         - |    882.87 KB |        0.56 |
|                                             |        |                 |                 |                 |       |         |            |            |           |              |             |
| **NullablePropertiesCreeateAndSet50Properties** | **100000** | **77,727,701.0 ns** | **1,527,418.43 ns** | **2,792,971.19 ns** |  **1.00** |    **0.05** | **11714.2857** | **11571.4286** | **2142.8571** | **158595.47 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | 100000 | 50,873,333.0 ns | 1,012,258.95 ns | 1,663,170.62 ns |  0.66 |    0.03 |  6555.5556 |  6444.4444 | 1777.7778 |  80470.42 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | 100000 | 85,803,228.1 ns | 1,714,802.26 ns | 3,262,589.77 ns |  1.11 |    0.06 |  7166.6667 |  7000.0000 | 1833.3333 |  88282.21 KB |        0.56 |
