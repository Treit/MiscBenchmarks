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
|                   Method |  Count |         Mean |         Error |      StdDev | Ratio | RatioSD |
|------------------------- |------- |-------------:|--------------:|------------:|------:|--------:|
|       **CountUsingContains** |    **100** |     **1.330 μs** |     **0.5565 μs** |   **0.0305 μs** |  **1.00** |    **0.00** |
|        CountUsingIndexOf |    100 |     5.182 μs |     4.5424 μs |   0.2490 μs |  3.90 |    0.21 |
| CountUsingIndexOfOrdinal |    100 |     2.200 μs |     1.5828 μs |   0.0868 μs |  1.65 |    0.06 |
|                          |        |              |               |             |       |         |
|       **CountUsingContains** |   **1000** |    **13.772 μs** |     **4.1094 μs** |   **0.2253 μs** |  **1.00** |    **0.00** |
|        CountUsingIndexOf |   1000 |    57.991 μs |    18.5035 μs |   1.0142 μs |  4.21 |    0.04 |
| CountUsingIndexOfOrdinal |   1000 |    20.111 μs |     6.8975 μs |   0.3781 μs |  1.46 |    0.02 |
|                          |        |              |               |             |       |         |
|       **CountUsingContains** |  **10000** |   **148.440 μs** |    **34.0979 μs** |   **1.8690 μs** |  **1.00** |    **0.00** |
|        CountUsingIndexOf |  10000 |   572.725 μs |   289.1006 μs |  15.8466 μs |  3.86 |    0.14 |
| CountUsingIndexOfOrdinal |  10000 |   220.082 μs |   132.6999 μs |   7.2737 μs |  1.48 |    0.03 |
|                          |        |              |               |             |       |         |
|       **CountUsingContains** | **100000** | **1,531.128 μs** |   **199.4357 μs** |  **10.9317 μs** |  **1.00** |    **0.00** |
|        CountUsingIndexOf | 100000 | 6,012.671 μs | 3,243.5962 μs | 177.7925 μs |  3.93 |    0.14 |
| CountUsingIndexOfOrdinal | 100000 | 2,172.388 μs |   376.2860 μs |  20.6255 μs |  1.42 |    0.01 |
