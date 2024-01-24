## Similarity matching


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                    Method |  Count |           Mean |        Error |       StdDev | Ratio |
|------------------------------------------ |------- |---------------:|-------------:|-------------:|------:|
|                       **CheckHashesOriginal** |    **100** |     **4,173.2 ns** |     **52.50 ns** |     **43.84 ns** |  **1.00** |
|                  CheckHashesWithSpanTable |    100 |     4,194.5 ns |     10.18 ns |      8.50 ns |  1.01 |
|                           CheckHashesKozi |    100 |     4,099.5 ns |      5.14 ns |      4.01 ns |  0.98 |
|                      CheckHashesTechPizza |    100 |     4,120.1 ns |     23.53 ns |     20.86 ns |  0.99 |
|                   CheckHashesSauceControl |    100 |     4,108.2 ns |     11.68 ns |      9.75 ns |  0.98 |
|       CheckHashesSauceControlUnrolledKozi |    100 |     2,668.2 ns |      2.25 ns |      1.88 ns |  0.64 |
|                CheckHashesHugeLookupTable |    100 |     2,420.9 ns |      4.97 ns |      4.65 ns |  0.58 |
|           CheckHashesSauceControlUnrolled |    100 |     2,700.4 ns |     12.57 ns |     11.15 ns |  0.65 |
| CheckHashesSauceControlUnrolledHugeLookup |    100 |     1,656.4 ns |      9.84 ns |      9.20 ns |  0.40 |
|             CheckHashesSseKozidHugeLookup |    100 |     1,530.5 ns |      3.12 ns |      2.92 ns |  0.37 |
|                CheckHashesSauceControlSse |    100 |       947.5 ns |      2.37 ns |      1.98 ns |  0.23 |
|           CheckHashesSauceControlFirstAvx |    100 |       479.3 ns |      1.02 ns |      0.85 ns |  0.11 |
|          CheckHashesSauceControlSecondAvx |    100 |       472.1 ns |      0.38 ns |      0.34 ns |  0.11 |
|           CheckHashesSauceControlThirdAvx |    100 |       475.1 ns |      2.25 ns |      1.99 ns |  0.11 |
|          CheckHashesSauceControlFourthAvx |    100 |       449.4 ns |      1.19 ns |      1.11 ns |  0.11 |
|                                           |        |                |              |              |       |
|                       **CheckHashesOriginal** | **100000** | **4,125,805.5 ns** | **26,248.46 ns** | **23,268.58 ns** |  **1.00** |
|                  CheckHashesWithSpanTable | 100000 | 4,199,184.8 ns |  8,673.66 ns |  7,242.90 ns |  1.02 |
|                           CheckHashesKozi | 100000 | 4,071,034.3 ns |  8,361.09 ns |  6,981.89 ns |  0.99 |
|                      CheckHashesTechPizza | 100000 | 4,114,307.3 ns | 16,185.00 ns | 15,139.46 ns |  1.00 |
|                   CheckHashesSauceControl | 100000 | 4,109,917.3 ns | 13,763.14 ns | 12,200.67 ns |  1.00 |
|       CheckHashesSauceControlUnrolledKozi | 100000 | 2,680,185.0 ns |  5,878.83 ns |  5,499.06 ns |  0.65 |
|                CheckHashesHugeLookupTable | 100000 | 2,391,640.6 ns |  4,004.21 ns |  3,549.63 ns |  0.58 |
|           CheckHashesSauceControlUnrolled | 100000 | 2,698,832.3 ns |  4,013.12 ns |  3,557.53 ns |  0.65 |
| CheckHashesSauceControlUnrolledHugeLookup | 100000 | 1,640,420.9 ns |  4,332.39 ns |  4,052.52 ns |  0.40 |
|             CheckHashesSseKozidHugeLookup | 100000 | 1,557,256.4 ns |  3,597.88 ns |  3,189.42 ns |  0.38 |
|                CheckHashesSauceControlSse | 100000 | 1,098,299.4 ns |  8,227.32 ns |  7,695.84 ns |  0.27 |
|           CheckHashesSauceControlFirstAvx | 100000 |   503,814.9 ns |  1,048.04 ns |    929.06 ns |  0.12 |
|          CheckHashesSauceControlSecondAvx | 100000 |   488,960.0 ns |  1,948.32 ns |  1,727.13 ns |  0.12 |
|           CheckHashesSauceControlThirdAvx | 100000 |   475,186.3 ns |  5,361.80 ns |  5,015.43 ns |  0.12 |
|          CheckHashesSauceControlFourthAvx | 100000 |   486,510.0 ns |    848.80 ns |    752.44 ns |  0.12 |
