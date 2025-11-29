# Representing objects having many properties





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Job       | Runtime   | Count  | Mean            | Error           | StdDev          | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated    | Alloc Ratio |
|-------------------------------------------- |---------- |---------- |------- |----------------:|----------------:|----------------:|------:|--------:|-----------:|-----------:|----------:|-------------:|------------:|
| **NullablePropertiesCreeateAndSet50Properties** | **.NET 10.0** | **.NET 10.0** | **10**     |        **717.1 ns** |        **13.66 ns** |        **15.19 ns** |  **1.00** |    **0.03** |     **0.9737** |     **0.0286** |         **-** |     **15.91 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | .NET 10.0 | .NET 10.0 | 10     |        641.9 ns |         4.73 ns |         4.20 ns |  0.90 |    0.02 |     0.4950 |     0.0153 |         - |       8.1 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | .NET 10.0 | .NET 10.0 | 10     |      1,275.3 ns |         8.28 ns |         7.34 ns |  1.78 |    0.04 |     0.5436 |     0.0172 |         - |      8.88 KB |        0.56 |
|                                             |           |           |        |                 |                 |                 |       |         |            |            |           |              |             |
| NullablePropertiesCreeateAndSet50Properties | .NET 9.0  | .NET 9.0  | 10     |        721.5 ns |         8.53 ns |         7.97 ns |  1.00 |    0.02 |     0.9737 |     0.0286 |         - |     15.91 KB |        1.00 |
| SentinelValuesCreeateAndSet50Properties     | .NET 9.0  | .NET 9.0  | 10     |        626.8 ns |         8.92 ns |         8.34 ns |  0.87 |    0.01 |     0.4950 |     0.0153 |         - |       8.1 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | .NET 9.0  | .NET 9.0  | 10     |      1,283.1 ns |        10.52 ns |         9.33 ns |  1.78 |    0.02 |     0.5436 |     0.0172 |         - |      8.88 KB |        0.56 |
|                                             |           |           |        |                 |                 |                 |       |         |            |            |           |              |             |
| **NullablePropertiesCreeateAndSet50Properties** | **.NET 10.0** | **.NET 10.0** | **1000**   |     **76,435.5 ns** |     **1,499.43 ns** |     **1,726.74 ns** |  **1.00** |    **0.03** |    **97.0459** |    **81.0547** |         **-** |   **1585.99 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | .NET 10.0 | .NET 10.0 | 1000   |     66,177.0 ns |       909.01 ns |       805.81 ns |  0.87 |    0.02 |    49.1943 |    34.4238 |         - |    804.74 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | .NET 10.0 | .NET 10.0 | 1000   |    134,130.5 ns |     1,334.76 ns |     1,248.54 ns |  1.76 |    0.04 |    53.9551 |    27.0996 |         - |    882.87 KB |        0.56 |
|                                             |           |           |        |                 |                 |                 |       |         |            |            |           |              |             |
| NullablePropertiesCreeateAndSet50Properties | .NET 9.0  | .NET 9.0  | 1000   |     80,430.3 ns |       530.86 ns |       496.57 ns |  1.00 |    0.01 |    97.0459 |    81.0547 |         - |   1585.99 KB |        1.00 |
| SentinelValuesCreeateAndSet50Properties     | .NET 9.0  | .NET 9.0  | 1000   |     65,782.4 ns |       823.20 ns |       729.75 ns |  0.82 |    0.01 |    49.1943 |    34.4238 |         - |    804.74 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | .NET 9.0  | .NET 9.0  | 1000   |    134,539.6 ns |     1,626.99 ns |     1,358.61 ns |  1.67 |    0.02 |    53.9551 |    27.0996 |         - |    882.87 KB |        0.56 |
|                                             |           |           |        |                 |                 |                 |       |         |            |            |           |              |             |
| **NullablePropertiesCreeateAndSet50Properties** | **.NET 10.0** | **.NET 10.0** | **100000** | **62,976,730.6 ns** | **1,255,876.68 ns** | **2,098,287.97 ns** |  **1.00** |    **0.05** | **11875.0000** | **11750.0000** | **2250.0000** | **158595.52 KB** |        **1.00** |
| SentinelValuesCreeateAndSet50Properties     | .NET 10.0 | .NET 10.0 | 100000 | 46,805,200.0 ns |   904,031.52 ns | 1,325,117.79 ns |  0.74 |    0.03 |  6636.3636 |  6545.4545 | 1818.1818 |  80470.55 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | .NET 10.0 | .NET 10.0 | 100000 | 77,899,859.4 ns | 1,552,231.72 ns | 2,416,637.98 ns |  1.24 |    0.06 |  7000.0000 |  6857.1429 | 1714.2857 |  88282.13 KB |        0.56 |
|                                             |           |           |        |                 |                 |                 |       |         |            |            |           |              |             |
| NullablePropertiesCreeateAndSet50Properties | .NET 9.0  | .NET 9.0  | 100000 | 62,727,114.2 ns | 1,236,110.36 ns | 2,321,715.07 ns |  1.00 |    0.05 | 11875.0000 | 11750.0000 | 2250.0000 | 158595.52 KB |        1.00 |
| SentinelValuesCreeateAndSet50Properties     | .NET 9.0  | .NET 9.0  | 100000 | 45,588,207.0 ns |   736,496.81 ns |   615,008.19 ns |  0.73 |    0.03 |  6636.3636 |  6545.4545 | 1818.1818 |  80470.44 KB |        0.51 |
| BitArrayCreeateAndSet50Properties           | .NET 9.0  | .NET 9.0  | 100000 | 76,092,044.9 ns | 1,497,984.50 ns | 2,148,364.79 ns |  1.21 |    0.06 |  7000.0000 |  6857.1429 | 1714.2857 |   88282.1 KB |        0.56 |
