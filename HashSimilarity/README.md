## Similarity matching

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22473
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  DefaultJob : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT


```
|                          Method |  Count |          Mean |       Error |      StdDev |        Median | Ratio | RatioSD |
|-------------------------------- |------- |--------------:|------------:|------------:|--------------:|------:|--------:|
|             **CheckHashesOriginal** |    **100** |     **11.178 μs** |   **0.2216 μs** |   **0.4373 μs** |     **11.177 μs** |  **1.00** |    **0.00** |
|        CheckHashesWithSpanTable |    100 |      7.610 μs |   0.1471 μs |   0.2014 μs |      7.600 μs |  0.69 |    0.04 |
|                 CheckHashesKozi |    100 |      8.980 μs |   0.1668 μs |   0.2548 μs |      8.906 μs |  0.81 |    0.03 |
|            CheckHashesTechPizza |    100 |      8.955 μs |   0.1764 μs |   0.2473 μs |      8.930 μs |  0.81 |    0.05 |
|         CheckHashesSauceControl |    100 |      6.469 μs |   0.1241 μs |   0.1161 μs |      6.483 μs |  0.58 |    0.03 |
| CheckHashesSauceControlUnrolled |    100 |      6.448 μs |   0.1087 μs |   0.1017 μs |      6.467 μs |  0.58 |    0.03 |
|      CheckHashesHugeLookupTable |    100 |      5.659 μs |   0.1085 μs |   0.1814 μs |      5.650 μs |  0.51 |    0.03 |
|                                 |        |               |             |             |               |       |         |
|             **CheckHashesOriginal** | **100000** | **13,279.850 μs** | **263.4838 μs** | **610.6639 μs** | **13,073.583 μs** |  **1.00** |    **0.00** |
|        CheckHashesWithSpanTable | 100000 |  7,863.916 μs | 154.7274 μs | 236.2851 μs |  7,891.298 μs |  0.60 |    0.03 |
|                 CheckHashesKozi | 100000 |  9,041.063 μs | 179.7838 μs | 314.8769 μs |  8,991.456 μs |  0.68 |    0.04 |
|            CheckHashesTechPizza | 100000 |  8,918.707 μs | 174.5114 μs | 271.6933 μs |  8,870.604 μs |  0.68 |    0.04 |
|         CheckHashesSauceControl | 100000 |  6,548.838 μs | 127.2914 μs | 174.2379 μs |  6,539.822 μs |  0.49 |    0.03 |
| CheckHashesSauceControlUnrolled | 100000 |  6,581.089 μs | 129.0194 μs | 211.9826 μs |  6,509.485 μs |  0.50 |    0.03 |
|      CheckHashesHugeLookupTable | 100000 |  5,759.858 μs | 115.1481 μs | 165.1420 μs |  5,771.088 μs |  0.44 |    0.03 |
