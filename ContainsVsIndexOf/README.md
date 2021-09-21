## IndexOf vs. Contains

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22463
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                   Method |  Count |         Mean |         Error |      StdDev | Ratio | RatioSD |
|----------------------------------------- |------- |-------------:|--------------:|------------:|------:|--------:|
|                       **CountUsingContains** |    **100** |     **1.247 μs** |     **0.2653 μs** |   **0.0145 μs** |  **1.00** |    **0.00** |
|        CountUsingContainsExplicitOrdinal |    100 |     2.046 μs |     0.8840 μs |   0.0485 μs |  1.64 |    0.06 |
| CountUsingContainsExplicitCurrentCulture |    100 |     5.529 μs |     0.7781 μs |   0.0426 μs |  4.44 |    0.02 |
|                        CountUsingIndexOf |    100 |     5.483 μs |     1.9497 μs |   0.1069 μs |  4.40 |    0.03 |
|                 CountUsingIndexOfOrdinal |    100 |     2.022 μs |     0.6654 μs |   0.0365 μs |  1.62 |    0.01 |
|                                          |        |              |               |             |       |         |
|                       **CountUsingContains** |   **1000** |    **14.300 μs** |     **2.4172 μs** |   **0.1325 μs** |  **1.00** |    **0.00** |
|        CountUsingContainsExplicitOrdinal |   1000 |    21.306 μs |     2.4475 μs |   0.1342 μs |  1.49 |    0.02 |
| CountUsingContainsExplicitCurrentCulture |   1000 |    60.995 μs |    38.7145 μs |   2.1221 μs |  4.27 |    0.18 |
|                        CountUsingIndexOf |   1000 |    55.889 μs |    35.2943 μs |   1.9346 μs |  3.91 |    0.17 |
|                 CountUsingIndexOfOrdinal |   1000 |    21.391 μs |     0.3060 μs |   0.0168 μs |  1.50 |    0.02 |
|                                          |        |              |               |             |       |         |
|                       **CountUsingContains** |  **10000** |   **147.182 μs** |    **49.1883 μs** |   **2.6962 μs** |  **1.00** |    **0.00** |
|        CountUsingContainsExplicitOrdinal |  10000 |   232.456 μs |   246.5133 μs |  13.5122 μs |  1.58 |    0.06 |
| CountUsingContainsExplicitCurrentCulture |  10000 |   599.630 μs |    55.4759 μs |   3.0408 μs |  4.07 |    0.07 |
|                        CountUsingIndexOf |  10000 |   576.707 μs |   142.2342 μs |   7.7963 μs |  3.92 |    0.02 |
|                 CountUsingIndexOfOrdinal |  10000 |   207.847 μs |    50.2066 μs |   2.7520 μs |  1.41 |    0.01 |
|                                          |        |              |               |             |       |         |
|                       **CountUsingContains** | **100000** | **1,518.970 μs** |   **774.1159 μs** |  **42.4319 μs** |  **1.00** |    **0.00** |
|        CountUsingContainsExplicitOrdinal | 100000 | 2,145.699 μs |   160.4007 μs |   8.7921 μs |  1.41 |    0.03 |
| CountUsingContainsExplicitCurrentCulture | 100000 | 6,531.780 μs | 1,662.6800 μs |  91.1371 μs |  4.30 |    0.08 |
|                        CountUsingIndexOf | 100000 | 5,967.884 μs | 2,631.7930 μs | 144.2575 μs |  3.93 |    0.03 |
|                 CountUsingIndexOfOrdinal | 100000 | 2,121.631 μs |   353.7068 μs |  19.3879 μs |  1.40 |    0.04 |
