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
|  **ForEachOfIListOfValueTupleBackedByList** |     **3** |        **198.580 ns** |       **3.9753 ns** |       **8.2979 ns** |  **1.00** |    **0.00** | **0.0334** |     **-** |     **-** |     **144 B** |
|            ForEachOfArrayOfKeyValuePair |     3 |         10.718 ns |       0.2513 ns |       0.5673 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |     3 |          8.782 ns |       0.2139 ns |       0.4872 ns |  0.04 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |     3 |        129.962 ns |       2.6268 ns |       5.7104 ns |  0.65 |    0.04 | 0.0222 |     - |     - |      96 B |
|       ForEachOfConcreteListOfValueTuple |     3 |         54.516 ns |       1.1100 ns |       1.2783 ns |  0.27 |    0.01 |      - |     - |     - |         - |
|                                         |       |                   |                 |                 |       |         |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |    **50** |     **38,917.509 ns** |     **765.4349 ns** |   **1,614.5620 ns** |  **1.00** |    **0.00** | **0.5493** |     **-** |     **-** |    **2400 B** |
|            ForEachOfArrayOfKeyValuePair |    50 |      2,445.765 ns |      47.2771 ns |      93.3204 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |    50 |      1,635.628 ns |      32.4220 ns |      53.2703 ns |  0.04 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |    50 |     22,128.714 ns |     440.0294 ns |     898.8635 ns |  0.57 |    0.03 | 0.3662 |     - |     - |    1600 B |
|       ForEachOfConcreteListOfValueTuple |    50 |      6,988.175 ns |     139.0958 ns |     194.9928 ns |  0.18 |    0.01 |      - |     - |     - |         - |
|                                         |       |                   |                 |                 |       |         |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |  **1000** | **13,451,759.149 ns** | **265,246.9286 ns** | **504,659.8486 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |   **48008 B** |
|            ForEachOfArrayOfKeyValuePair |  1000 |    911,129.289 ns |  17,874.9287 ns |  13,955.5686 ns |  0.07 |    0.00 |      - |     - |     - |       1 B |
|              ForEachOfArrayOfValueTuple |  1000 |    656,567.383 ns |  12,826.9655 ns |  18,396.0506 ns |  0.05 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |  1000 |  8,693,049.253 ns | 167,763.0469 ns | 323,222.4367 ns |  0.65 |    0.03 |      - |     - |     - |   32008 B |
|       ForEachOfConcreteListOfValueTuple |  1000 |  2,538,821.094 ns |  50,758.7337 ns | 111,416.6510 ns |  0.19 |    0.01 |      - |     - |     - |       2 B |
