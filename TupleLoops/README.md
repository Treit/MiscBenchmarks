# Looping over sets of tuples

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22593
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.3 (CoreCLR 6.0.322.12309, CoreFX 6.0.322.12309), X64 RyuJIT


```
|                                  Method | Count |              Mean |           Error |          StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------- |------ |------------------:|----------------:|----------------:|------:|-------:|------:|------:|----------:|
|  **ForEachOfIListOfValueTupleBackedByList** |     **3** |        **205.303 ns** |       **4.0655 ns** |       **8.0250 ns** |  **1.00** | **0.0334** |     **-** |     **-** |     **144 B** |
|            ForEachOfArrayOfKeyValuePair |     3 |         10.336 ns |       0.2338 ns |       0.5033 ns |  0.05 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |     3 |          8.065 ns |       0.1960 ns |       0.4582 ns |  0.04 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |     3 |          7.989 ns |       0.1966 ns |       0.3926 ns |  0.04 |      - |     - |     - |         - |
|                                         |       |                   |                 |                 |       |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |    **50** |     **36,855.740 ns** |     **730.4451 ns** |   **1,441.8273 ns** |  **1.00** | **0.5493** |     **-** |     **-** |    **2400 B** |
|            ForEachOfArrayOfKeyValuePair |    50 |      2,285.451 ns |      45.4844 ns |      75.9942 ns |  0.06 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |    50 |      1,581.696 ns |      31.4253 ns |      65.5963 ns |  0.04 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |    50 |      1,648.517 ns |      31.3489 ns |      30.7888 ns |  0.04 |      - |     - |     - |         - |
|                                         |       |                   |                 |                 |       |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |  **1000** | **14,200,238.884 ns** | **256,083.1976 ns** | **420,752.0374 ns** |  **1.00** |      **-** |     **-** |     **-** |   **48008 B** |
|            ForEachOfArrayOfKeyValuePair |  1000 |    906,094.370 ns |  17,661.3922 ns |  24,175.1130 ns |  0.06 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |  1000 |    622,703.703 ns |  12,313.5590 ns |  20,573.1908 ns |  0.04 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |  1000 |    615,160.500 ns |  12,144.0074 ns |  25,615.8333 ns |  0.04 |      - |     - |     - |         - |
