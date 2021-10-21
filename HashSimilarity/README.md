## Similarity matching

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22483
Unknown processor
.NET Core SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET Core 5.0.11 (CoreCLR 5.0.1121.47308, CoreFX 5.0.1121.47308), X64 RyuJIT
  DefaultJob : .NET Core 5.0.11 (CoreCLR 5.0.1121.47308, CoreFX 5.0.1121.47308), X64 RyuJIT


```
|                                    Method |  Count |          Mean |       Error |      StdDev | Ratio | RatioSD |
|------------------------------------------ |------- |--------------:|------------:|------------:|------:|--------:|
|                       **CheckHashesOriginal** |    **100** |     **12.228 μs** |   **0.2397 μs** |   **0.3802 μs** |  **1.00** |    **0.00** |
|                  CheckHashesWithSpanTable |    100 |      7.137 μs |   0.1397 μs |   0.2256 μs |  0.58 |    0.02 |
|                           CheckHashesKozi |    100 |      8.418 μs |   0.1673 μs |   0.4009 μs |  0.69 |    0.04 |
|                      CheckHashesTechPizza |    100 |      8.374 μs |   0.1652 μs |   0.3485 μs |  0.68 |    0.04 |
|                   CheckHashesSauceControl |    100 |      6.303 μs |   0.1223 μs |   0.1793 μs |  0.52 |    0.02 |
|       CheckHashesSauceControlUnrolledKozi |    100 |      4.097 μs |   0.0814 μs |   0.1489 μs |  0.34 |    0.01 |
|                CheckHashesHugeLookupTable |    100 |      4.619 μs |   0.0923 μs |   0.1688 μs |  0.38 |    0.02 |
|           CheckHashesSauceControlUnrolled |    100 |      3.995 μs |   0.0767 μs |   0.0913 μs |  0.33 |    0.01 |
| CheckHashesSauceControlUnrolledHugeLookup |    100 |      2.562 μs |   0.0501 μs |   0.0795 μs |  0.21 |    0.01 |
|             CheckHashesSseKozidHugeLookup |    100 |      2.700 μs |   0.0531 μs |   0.0568 μs |  0.22 |    0.01 |
|                                           |        |               |             |             |       |         |
|                       **CheckHashesOriginal** | **100000** | **12,187.126 μs** | **161.0630 μs** | **197.7998 μs** |  **1.00** |    **0.00** |
|                  CheckHashesWithSpanTable | 100000 |  7,232.068 μs | 102.4787 μs |  85.5743 μs |  0.59 |    0.02 |
|                           CheckHashesKozi | 100000 |  5,742.437 μs | 112.6618 μs | 120.5468 μs |  0.47 |    0.01 |
|                      CheckHashesTechPizza | 100000 |  5,245.122 μs | 103.0436 μs | 133.9858 μs |  0.43 |    0.01 |
|                   CheckHashesSauceControl | 100000 |  6,314.368 μs |  92.7801 μs | 130.0647 μs |  0.52 |    0.01 |
|       CheckHashesSauceControlUnrolledKozi | 100000 |  4,230.871 μs |  84.4058 μs | 185.2727 μs |  0.36 |    0.02 |
|                CheckHashesHugeLookupTable | 100000 |  5,877.909 μs | 115.7304 μs | 199.6292 μs |  0.48 |    0.02 |
|           CheckHashesSauceControlUnrolled | 100000 |  4,272.894 μs |  84.6680 μs | 129.2970 μs |  0.35 |    0.01 |
| CheckHashesSauceControlUnrolledHugeLookup | 100000 |  2,734.082 μs |  54.4119 μs |  90.9101 μs |  0.22 |    0.01 |
|             CheckHashesSseKozidHugeLookup | 100000 |  2,881.480 μs |  55.7429 μs |  74.4152 μs |  0.24 |    0.01 |
