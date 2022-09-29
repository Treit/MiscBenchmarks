# Iterating distinct values

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25211
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|                                 Method | TotalItems | RandomNumberCeiling |       Mean |    Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------------------------- |----------- |-------------------- |-----------:|---------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
|                    **ForEachUsingHashSet** |     **100000** |                  **10** | **1,103.8 μs** | **29.57 μs** |  **85.31 μs** |  **1.00** |    **0.00** | **498.0469** | **498.0469** | **498.0469** | **1738648 B** |
| ForEachUsingHashSetWithInitialCapacity |     100000 |                  10 |   573.1 μs | 11.32 μs |  18.91 μs |  0.51 |    0.04 |        - |        - |        - |     560 B |
|                   ForEachUsingDistinct |     100000 |                  10 | 1,069.1 μs | 27.78 μs |  79.25 μs |  0.97 |    0.11 |        - |        - |        - |     657 B |
|                                        |            |                     |            |          |           |       |         |          |          |          |           |
|                    **ForEachUsingHashSet** |     **100000** |                 **100** | **1,086.6 μs** | **28.97 μs** |  **82.18 μs** |  **1.00** |    **0.00** | **498.0469** | **498.0469** | **498.0469** | **1740184 B** |
| ForEachUsingHashSetWithInitialCapacity |     100000 |                 100 |   602.2 μs | 14.25 μs |  41.12 μs |  0.56 |    0.06 |   0.9766 |        - |        - |    5896 B |
|                   ForEachUsingDistinct |     100000 |                 100 | 1,011.3 μs | 20.12 μs |  45.83 μs |  0.93 |    0.08 |   0.9766 |        - |        - |    5992 B |
|                                        |            |                     |            |          |           |       |         |          |          |          |           |
|                    **ForEachUsingHashSet** |     **100000** |              **100000** | **3,218.6 μs** | **65.10 μs** | **189.90 μs** |  **1.00** |    **0.00** | **496.0938** | **496.0938** | **496.0938** | **1738417 B** |
| ForEachUsingHashSetWithInitialCapacity |     100000 |              100000 | 3,008.7 μs | 59.92 μs | 114.00 μs |  0.95 |    0.07 | 550.7813 | 511.7188 | 500.0000 | 2327334 B |
|                   ForEachUsingDistinct |     100000 |              100000 | 3,947.6 μs | 87.36 μs | 254.84 μs |  1.23 |    0.11 | 546.8750 | 515.6250 | 500.0000 | 2327432 B |
