# Serializing the data from GC.GetGCMemoryInfo

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22538
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|                                     Method |   Count |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD |       Gen 0 | Gen 1 | Gen 2 |     Allocated |
|------------------------------------------- |-------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|------------:|------:|------:|--------------:|
|                      **SerializeGCMemoryInfo** |      **10** |        **36.59 μs** |      **0.713 μs** |      **1.267 μs** |        **36.31 μs** |  **1.00** |    **0.00** |      **7.2632** |     **-** |     **-** |      **30.67 KB** |
| SerializeGCMemoryInfoWithUnnecessarySelect |      10 |        37.70 μs |      0.713 μs |      1.735 μs |        37.16 μs |  1.03 |    0.06 |      7.6294 |     - |     - |      32.23 KB |
|                                            |         |                 |               |               |                 |       |         |             |       |       |               |
|                      **SerializeGCMemoryInfo** |    **1000** |     **3,551.32 μs** |     **69.555 μs** |     **90.441 μs** |     **3,569.42 μs** |  **1.00** |    **0.00** |    **718.7500** |     **-** |     **-** |    **3039.35 KB** |
| SerializeGCMemoryInfoWithUnnecessarySelect |    1000 |     3,831.66 μs |     76.587 μs |    212.221 μs |     3,766.13 μs |  1.06 |    0.07 |    757.8125 |     - |     - |     3195.6 KB |
|                                            |         |                 |               |               |                 |       |         |             |       |       |               |
|                      **SerializeGCMemoryInfo** | **1000000** | **3,483,475.65 μs** | **43,805.191 μs** | **36,579.318 μs** | **3,489,324.80 μs** |  **1.00** |    **0.00** | **719000.0000** |     **-** |     **-** | **3031251.08 KB** |
| SerializeGCMemoryInfoWithUnnecessarySelect | 1000000 | 3,763,545.65 μs | 74,767.877 μs | 94,557.425 μs | 3,745,910.50 μs |  1.08 |    0.03 | 753000.0000 |     - |     - | 3171876.08 KB |
