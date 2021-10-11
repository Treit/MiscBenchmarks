## Similarity matching

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22473
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  DefaultJob : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT


```
|                                    Method |  Count |          Mean |       Error |      StdDev | Ratio | RatioSD |
|------------------------------------------ |------- |--------------:|------------:|------------:|------:|--------:|
|                       **CheckHashesOriginal** |    **100** |     **12.606 μs** |   **0.2492 μs** |   **0.4024 μs** |  **1.00** |    **0.00** |
|                  CheckHashesWithSpanTable |    100 |      7.601 μs |   0.1519 μs |   0.3366 μs |  0.61 |    0.03 |
|                           CheckHashesKozi |    100 |      8.845 μs |   0.1751 μs |   0.3536 μs |  0.70 |    0.04 |
|                      CheckHashesTechPizza |    100 |      5.509 μs |   0.1091 μs |   0.1666 μs |  0.44 |    0.02 |
|                   CheckHashesSauceControl |    100 |      5.401 μs |   0.1078 μs |   0.2251 μs |  0.43 |    0.02 |
|       CheckHashesSauceControlUnrolledKozi |    100 |      3.988 μs |   0.0793 μs |   0.2117 μs |  0.32 |    0.02 |
|                CheckHashesHugeLookupTable |    100 |      4.871 μs |   0.0962 μs |   0.1554 μs |  0.39 |    0.02 |
|           CheckHashesSauceControlUnrolled |    100 |      4.378 μs |   0.0830 μs |   0.1751 μs |  0.35 |    0.02 |
| CheckHashesSauceControlUnrolledHugeLookup |    100 |      2.703 μs |   0.0534 μs |   0.0694 μs |  0.21 |    0.01 |
|                                           |        |               |             |             |       |         |
|                       **CheckHashesOriginal** | **100000** | **12,848.409 μs** | **251.9675 μs** | **460.7369 μs** |  **1.00** |    **0.00** |
|                  CheckHashesWithSpanTable | 100000 |  7,851.178 μs | 156.6736 μs | 316.4885 μs |  0.61 |    0.03 |
|                           CheckHashesKozi | 100000 |  6,205.876 μs | 123.9808 μs | 173.8037 μs |  0.48 |    0.03 |
|                      CheckHashesTechPizza | 100000 |  5,683.495 μs | 108.8583 μs | 277.0790 μs |  0.45 |    0.02 |
|                   CheckHashesSauceControl | 100000 |  5,745.891 μs | 114.8220 μs | 244.6951 μs |  0.45 |    0.03 |
|       CheckHashesSauceControlUnrolledKozi | 100000 |  4,522.782 μs |  89.5839 μs | 237.5638 μs |  0.35 |    0.03 |
|                CheckHashesHugeLookupTable | 100000 |  5,010.220 μs |  92.9036 μs | 181.2014 μs |  0.39 |    0.02 |
|           CheckHashesSauceControlUnrolled | 100000 |  3,995.102 μs |  79.5094 μs | 202.3769 μs |  0.31 |    0.02 |
| CheckHashesSauceControlUnrolledHugeLookup | 100000 |  2,840.382 μs |  56.0524 μs |  95.1813 μs |  0.22 |    0.01 |
