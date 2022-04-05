# Looping over sets of tuples

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22593
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                  Method | Count |              Mean |           Error |          StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------- |------ |------------------:|----------------:|----------------:|------:|--------:|-------:|------:|------:|----------:|
|  **ForEachOfIListOfValueTupleBackedByList** |     **3** |        **201.732 ns** |       **4.0431 ns** |       **6.5288 ns** |  **1.00** |    **0.00** | **0.0334** |     **-** |     **-** |     **144 B** |
|            ForEachOfArrayOfKeyValuePair |     3 |         10.627 ns |       0.2440 ns |       0.4928 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |     3 |          8.461 ns |       0.2054 ns |       0.3316 ns |  0.04 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |     3 |        127.038 ns |       2.5742 ns |       4.2295 ns |  0.63 |    0.03 | 0.0222 |     - |     - |      96 B |
|                                         |       |                   |                 |                 |       |         |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |    **50** |     **36,712.651 ns** |     **724.6570 ns** |   **1,693.8623 ns** |  **1.00** |    **0.00** | **0.5493** |     **-** |     **-** |    **2400 B** |
|            ForEachOfArrayOfKeyValuePair |    50 |      2,435.565 ns |      48.0733 ns |      80.3197 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |    50 |      1,662.471 ns |      32.5663 ns |      62.7442 ns |  0.05 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |    50 |     20,374.084 ns |     400.9980 ns |     782.1159 ns |  0.56 |    0.03 | 0.3662 |     - |     - |    1600 B |
|                                         |       |                   |                 |                 |       |         |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |  **1000** | **13,891,392.779 ns** | **271,434.7293 ns** | **460,916.7704 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |   **48002 B** |
|            ForEachOfArrayOfKeyValuePair |  1000 |    962,922.953 ns |  19,112.8850 ns |  47,597.7162 ns |  0.07 |    0.00 |      - |     - |     - |       1 B |
|              ForEachOfArrayOfValueTuple |  1000 |    647,523.559 ns |  12,889.6680 ns |  29,094.1287 ns |  0.05 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |  1000 |  7,257,792.452 ns | 144,708.3496 ns | 320,663.7071 ns |  0.52 |    0.03 |      - |     - |     - |   32004 B |
