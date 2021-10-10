## Similarity matching

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22473
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-rc.1.21463.6
  [Host]   : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT
  ShortRun : .NET Core 5.0.10 (CoreCLR 5.0.1021.41214, CoreFX 5.0.1021.41214), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                   Method |   Count |             Mean |            Error |          StdDev | Ratio | RatioSD |
|------------------------- |-------- |-----------------:|-----------------:|----------------:|------:|--------:|
|      **CheckHashesOriginal** |      **10** |       **1,256.3 ns** |       **1,094.7 ns** |        **60.00 ns** |  **1.00** |    **0.00** |
| CheckHashesWithSpanTable |      10 |         761.9 ns |         520.8 ns |        28.55 ns |  0.61 |    0.05 |
|          CheckHashesKozi |      10 |         578.7 ns |         387.1 ns |        21.22 ns |  0.46 |    0.03 |
|     CheckHashesTechPizza |      10 |         612.4 ns |         486.3 ns |        26.66 ns |  0.49 |    0.01 |
|                          |         |                  |                  |                 |       |         |
|      **CheckHashesOriginal** |     **100** |      **11,100.8 ns** |      **11,138.9 ns** |       **610.56 ns** |  **1.00** |    **0.00** |
| CheckHashesWithSpanTable |     100 |       8,526.7 ns |       6,407.2 ns |       351.20 ns |  0.77 |    0.04 |
|          CheckHashesKozi |     100 |       8,568.7 ns |       2,213.4 ns |       121.32 ns |  0.77 |    0.03 |
|     CheckHashesTechPizza |     100 |       5,221.0 ns |       1,392.8 ns |        76.34 ns |  0.47 |    0.03 |
|                          |         |                  |                  |                 |       |         |
|      **CheckHashesOriginal** |   **10000** |   **1,084,821.8 ns** |     **322,154.1 ns** |    **17,658.35 ns** |  **1.00** |    **0.00** |
| CheckHashesWithSpanTable |   10000 |     770,228.6 ns |     353,276.6 ns |    19,364.28 ns |  0.71 |    0.03 |
|          CheckHashesKozi |   10000 |     852,952.9 ns |     540,695.2 ns |    29,637.33 ns |  0.79 |    0.03 |
|     CheckHashesTechPizza |   10000 |     597,542.3 ns |     460,610.4 ns |    25,247.61 ns |  0.55 |    0.02 |
|                          |         |                  |                  |                 |       |         |
|      **CheckHashesOriginal** | **1000000** | **126,153,883.3 ns** | **142,107,132.0 ns** | **7,789,371.42 ns** |  **1.00** |    **0.00** |
| CheckHashesWithSpanTable | 1000000 |  88,529,238.1 ns |  39,882,193.2 ns | 2,186,077.59 ns |  0.70 |    0.03 |
|          CheckHashesKozi | 1000000 |  62,508,048.1 ns |  23,006,005.5 ns | 1,261,036.79 ns |  0.50 |    0.04 |
|     CheckHashesTechPizza | 1000000 |  55,957,300.0 ns |  29,799,244.2 ns | 1,633,397.13 ns |  0.44 |    0.02 |
