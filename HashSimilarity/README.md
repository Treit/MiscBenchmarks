## Similarity matching

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22483
Unknown processor
.NET Core SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET Core 5.0.11 (CoreCLR 5.0.1121.47308, CoreFX 5.0.1121.47308), X64 RyuJIT
  DefaultJob : .NET Core 5.0.11 (CoreCLR 5.0.1121.47308, CoreFX 5.0.1121.47308), X64 RyuJIT


```
|                                    Method |  Count |          Mean |       Error |      StdDev |        Median | Ratio | RatioSD |
|------------------------------------------ |------- |--------------:|------------:|------------:|--------------:|------:|--------:|
|                       **CheckHashesOriginal** |    **100** |     **14.491 μs** |   **0.6623 μs** |   **1.9529 μs** |     **15.001 μs** |  **1.00** |    **0.00** |
|                  CheckHashesWithSpanTable |    100 |      8.324 μs |   0.4982 μs |   1.4689 μs |      7.574 μs |  0.59 |    0.17 |
|                           CheckHashesKozi |    100 |      9.313 μs |   0.1632 μs |   0.1363 μs |      9.313 μs |  0.76 |    0.03 |
|                      CheckHashesTechPizza |    100 |      8.422 μs |   0.1617 μs |   0.3935 μs |      8.395 μs |  0.62 |    0.09 |
|                   CheckHashesSauceControl |    100 |      6.398 μs |   0.1241 μs |   0.1614 μs |      6.426 μs |  0.52 |    0.02 |
|       CheckHashesSauceControlUnrolledKozi |    100 |      3.699 μs |   0.0730 μs |   0.1539 μs |      3.688 μs |  0.29 |    0.03 |
|                CheckHashesHugeLookupTable |    100 |      4.643 μs |   0.0918 μs |   0.1724 μs |      4.612 μs |  0.37 |    0.02 |
|           CheckHashesSauceControlUnrolled |    100 |      3.705 μs |   0.0709 μs |   0.0843 μs |      3.720 μs |  0.30 |    0.01 |
| CheckHashesSauceControlUnrolledHugeLookup |    100 |      2.572 μs |   0.0501 μs |   0.0903 μs |      2.565 μs |  0.21 |    0.01 |
|             CheckHashesSseKozidHugeLookup |    100 |      2.729 μs |   0.0538 μs |   0.1011 μs |      2.718 μs |  0.22 |    0.01 |
|                CheckHashesSauceControlSse |    100 |      2.051 μs |   0.0410 μs |   0.0810 μs |      2.045 μs |  0.16 |    0.01 |
|           CheckHashesSauceControlFirstAvx |    100 |      1.255 μs |   0.0248 μs |   0.0370 μs |      1.251 μs |  0.10 |    0.01 |
|          CheckHashesSauceControlSecondAvx |    100 |      1.261 μs |   0.0246 μs |   0.0337 μs |      1.264 μs |  0.10 |    0.01 |
|           CheckHashesSauceControlThirdAvx |    100 |      1.088 μs |   0.0234 μs |   0.0647 μs |      1.077 μs |  0.08 |    0.01 |
|          CheckHashesSauceControlFourthAvx |    100 |      1.057 μs |   0.0211 μs |   0.0509 μs |      1.055 μs |  0.08 |    0.01 |
|                                           |        |               |             |             |               |       |         |
|                       **CheckHashesOriginal** | **100000** | **12,654.160 μs** | **251.7883 μs** | **318.4316 μs** | **12,592.034 μs** |  **1.00** |    **0.00** |
|                  CheckHashesWithSpanTable | 100000 |  7,660.325 μs | 146.0001 μs | 189.8414 μs |  7,668.600 μs |  0.61 |    0.02 |
|                           CheckHashesKozi | 100000 |  8,586.584 μs | 170.0030 μs | 400.7171 μs |  8,564.409 μs |  0.68 |    0.03 |
|                      CheckHashesTechPizza | 100000 |  8,734.459 μs | 171.4600 μs | 334.4195 μs |  8,702.580 μs |  0.69 |    0.03 |
|                   CheckHashesSauceControl | 100000 |  6,440.297 μs |  92.2577 μs |  81.7841 μs |  6,420.167 μs |  0.51 |    0.02 |
|       CheckHashesSauceControlUnrolledKozi | 100000 |  3,913.060 μs |  77.5250 μs | 127.3758 μs |  3,913.868 μs |  0.31 |    0.01 |
|                CheckHashesHugeLookupTable | 100000 |  4,897.376 μs |  97.7436 μs | 188.3188 μs |  4,897.100 μs |  0.39 |    0.02 |
|           CheckHashesSauceControlUnrolled | 100000 |  3,978.714 μs |  78.6765 μs | 139.8474 μs |  3,977.148 μs |  0.32 |    0.02 |
| CheckHashesSauceControlUnrolledHugeLookup | 100000 |  2,729.995 μs |  51.5696 μs | 107.6449 μs |  2,716.178 μs |  0.22 |    0.01 |
|             CheckHashesSseKozidHugeLookup | 100000 |  2,860.030 μs |  55.4541 μs | 114.5223 μs |  2,853.102 μs |  0.23 |    0.01 |
|                CheckHashesSauceControlSse | 100000 |  2,192.350 μs |  43.8421 μs |  93.4311 μs |  2,173.546 μs |  0.17 |    0.01 |
|           CheckHashesSauceControlFirstAvx | 100000 |  1,484.055 μs |  29.4437 μs |  66.4593 μs |  1,473.948 μs |  0.12 |    0.01 |
|          CheckHashesSauceControlSecondAvx | 100000 |  1,470.126 μs |  21.3290 μs |  18.9076 μs |  1,473.682 μs |  0.12 |    0.00 |
|           CheckHashesSauceControlThirdAvx | 100000 |  1,283.598 μs |  25.3055 μs |  41.5776 μs |  1,282.646 μs |  0.10 |    0.00 |
|          CheckHashesSauceControlFourthAvx | 100000 |  1,294.873 μs |  25.4134 μs |  46.4698 μs |  1,302.853 μs |  0.10 |    0.00 |
