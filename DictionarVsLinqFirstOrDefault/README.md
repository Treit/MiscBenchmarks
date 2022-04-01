# Finding matches using Dictionary vs Linear Search.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22587
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                Method | Count |             Mean |            Error |           StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------------:|-----------------:|-----------------:|---------:|--------:|--------:|------:|------:|----------:|
|            **FindMatchesUsingDictionary** |    **10** |         **197.4 ns** |          **7.05 ns** |         **20.79 ns** |     **1.00** |    **0.00** |  **0.0203** |     **-** |     **-** |      **88 B** |
|         FindMatchesUsingFirstOrDeault |    10 |       1,612.8 ns |         75.53 ns |        222.71 ns |     8.28 |    1.53 |  0.3166 |     - |     - |    1368 B |
| FindMatchesUsingFirstOrDeaultNoLambda |    10 |       1,620.0 ns |         53.74 ns |        157.61 ns |     8.31 |    1.30 |  0.2613 |     - |     - |    1128 B |
|                                       |       |                  |                  |                  |          |         |         |       |       |           |
|            **FindMatchesUsingDictionary** |   **100** |       **2,000.5 ns** |         **72.10 ns** |        **212.59 ns** |     **1.00** |    **0.00** |  **0.2651** |     **-** |     **-** |    **1144 B** |
|         FindMatchesUsingFirstOrDeault |   100 |      65,850.4 ns |      2,624.31 ns |      7,737.83 ns |    33.31 |    5.32 |  3.1738 |     - |     - |   13944 B |
| FindMatchesUsingFirstOrDeaultNoLambda |   100 |      67,936.5 ns |      3,911.03 ns |     11,531.75 ns |    34.39 |    7.12 |  2.6245 |     - |     - |   11544 B |
|                                       |       |                  |                  |                  |          |         |         |       |       |           |
|            **FindMatchesUsingDictionary** | **10000** |     **150,278.5 ns** |      **6,754.95 ns** |     **19,704.52 ns** |     **1.00** |    **0.00** | **15.1367** |     **-** |     **-** |   **65800 B** |
|         FindMatchesUsingFirstOrDeault | 10000 | 543,364,954.0 ns | 32,980,374.50 ns | 97,243,378.31 ns | 3,710.89 |  895.74 |       - |     - |     - | 1346280 B |
| FindMatchesUsingFirstOrDeaultNoLambda | 10000 | 546,219,653.0 ns | 32,401,769.87 ns | 95,537,349.51 ns | 3,728.46 |  954.63 |       - |     - |     - | 1106280 B |
