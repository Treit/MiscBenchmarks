## Reversing a string

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.100-rc.1.21458.32
  [Host]   : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  ShortRun : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                             Method | Count |           Mean |           Error |        StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 |  Allocated |
|----------------------------------- |------ |---------------:|----------------:|--------------:|------:|--------:|----------:|------:|------:|-----------:|
|       **ReverseStringUsingLinqAndNew** |    **10** |     **4,198.6 ns** |       **163.41 ns** |       **8.96 ns** |  **1.00** |    **0.00** |    **0.6943** |     **-** |     **-** |     **5840 B** |
|      ReverseStringUsingLinqAndJoin |    10 |     6,900.9 ns |     1,307.78 ns |      71.68 ns |  1.64 |    0.01 |    1.6785 |     - |     - |    14080 B |
|     ReverseStringUsingExplicitCopy |    10 |       372.8 ns |        93.05 ns |       5.10 ns |  0.09 |    0.00 |    0.2294 |     - |     - |     1920 B |
|     ReverseStringUsingStringCreate |    10 |       303.4 ns |        22.17 ns |       1.22 ns |  0.07 |    0.00 |    0.1144 |     - |     - |      960 B |
|     ReverseStringUsingArrayReverse |    10 |       329.2 ns |        35.77 ns |       1.96 ns |  0.08 |    0.00 |    0.2294 |     - |     - |     1920 B |
| ReverseStringUsingStringCreateKozi |    10 |       217.8 ns |        23.32 ns |       1.28 ns |  0.05 |    0.00 |    0.1147 |     - |     - |      960 B |
|                                    |       |                |                 |               |       |         |           |       |       |            |
|       **ReverseStringUsingLinqAndNew** |   **100** |    **42,749.6 ns** |     **1,531.33 ns** |      **83.94 ns** |  **1.00** |    **0.00** |    **6.9580** |     **-** |     **-** |    **58400 B** |
|      ReverseStringUsingLinqAndJoin |   100 |    64,972.1 ns |    13,482.68 ns |     739.03 ns |  1.52 |    0.02 |   16.7236 |     - |     - |   140800 B |
|     ReverseStringUsingExplicitCopy |   100 |     3,637.6 ns |       275.58 ns |      15.11 ns |  0.09 |    0.00 |    2.2926 |     - |     - |    19200 B |
|     ReverseStringUsingStringCreate |   100 |     2,916.0 ns |       227.34 ns |      12.46 ns |  0.07 |    0.00 |    1.1444 |     - |     - |     9600 B |
|     ReverseStringUsingArrayReverse |   100 |     3,307.7 ns |       798.94 ns |      43.79 ns |  0.08 |    0.00 |    2.2926 |     - |     - |    19200 B |
| ReverseStringUsingStringCreateKozi |   100 |     2,118.3 ns |       498.73 ns |      27.34 ns |  0.05 |    0.00 |    1.1444 |     - |     - |     9600 B |
|                                    |       |                |                 |               |       |         |           |       |       |            |
|       **ReverseStringUsingLinqAndNew** | **10000** | **4,305,858.6 ns** |   **142,582.16 ns** |   **7,815.41 ns** |  **1.00** |    **0.00** |  **695.3125** |     **-** |     **-** |  **5840000 B** |
|      ReverseStringUsingLinqAndJoin | 10000 | 6,593,706.8 ns | 2,450,495.21 ns | 134,319.91 ns |  1.53 |    0.03 | 1679.6875 |     - |     - | 14080000 B |
|     ReverseStringUsingExplicitCopy | 10000 |   397,313.9 ns |    30,314.95 ns |   1,661.66 ns |  0.09 |    0.00 |  229.4922 |     - |     - |  1920000 B |
|     ReverseStringUsingStringCreate | 10000 |   292,064.6 ns |    16,386.08 ns |     898.18 ns |  0.07 |    0.00 |  114.7461 |     - |     - |   960000 B |
|     ReverseStringUsingArrayReverse | 10000 |   330,007.1 ns |    54,237.19 ns |   2,972.92 ns |  0.08 |    0.00 |  229.4922 |     - |     - |  1920000 B |
| ReverseStringUsingStringCreateKozi | 10000 |   211,751.5 ns |    15,710.90 ns |     861.17 ns |  0.05 |    0.00 |  114.7461 |     - |     - |   960000 B |
