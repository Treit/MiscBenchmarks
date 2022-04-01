# Finding matches using Dictionary vs Linear Search using LINQ.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22587
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                Method | Count |             Mean |            Error |           StdDev |           Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------------:|-----------------:|-----------------:|-----------------:|---------:|--------:|-------:|------:|------:|----------:|
|            **FindMatchesUsingDictionary** |    **10** |         **120.2 ns** |          **6.38 ns** |         **18.72 ns** |         **119.0 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|         FindMatchesUsingFirstOrDeault |    10 |       1,070.1 ns |         43.30 ns |        124.24 ns |       1,036.1 ns |     9.17 |    1.88 | 0.2966 |     - |     - |    1280 B |
| FindMatchesUsingFirstOrDeaultNoLambda |    10 |       1,046.3 ns |         47.27 ns |        138.62 ns |       1,025.0 ns |     8.88 |    1.63 | 0.2403 |     - |     - |    1040 B |
|                                       |       |                  |                  |                  |                  |          |         |        |       |       |           |
|            **FindMatchesUsingDictionary** |   **100** |       **1,179.2 ns** |         **57.45 ns** |        **169.39 ns** |       **1,135.9 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|         FindMatchesUsingFirstOrDeault |   100 |      56,546.4 ns |      2,395.07 ns |      7,061.93 ns |      55,823.1 ns |    48.96 |    9.59 | 2.9297 |     - |     - |   12800 B |
| FindMatchesUsingFirstOrDeaultNoLambda |   100 |      53,178.8 ns |      2,565.55 ns |      7,524.31 ns |      53,081.3 ns |    45.73 |    8.04 | 2.3804 |     - |     - |   10400 B |
|                                       |       |                  |                  |                  |                  |          |         |        |       |       |           |
|            **FindMatchesUsingDictionary** | **10000** |     **111,038.4 ns** |      **3,764.98 ns** |     **10,802.45 ns** |     **109,827.7 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|         FindMatchesUsingFirstOrDeault | 10000 | 489,954,083.8 ns | 24,096,761.06 ns | 70,671,628.87 ns | 481,828,000.0 ns | 4,449.98 |  757.95 |      - |     - |     - | 1280480 B |
| FindMatchesUsingFirstOrDeaultNoLambda | 10000 | 518,214,645.8 ns | 20,835,330.20 ns | 60,114,691.54 ns | 517,020,550.0 ns | 4,704.07 |  657.71 |      - |     - |     - | 1040480 B |
