# Looping over sets of tuples


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                  Method | Count |              Mean |         Error |        StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|---------------------------------------- |------ |------------------:|--------------:|--------------:|------:|-------:|----------:|------------:|
|  **ForEachOfIListOfValueTupleBackedByList** |     **3** |        **119.677 ns** |     **0.5532 ns** |     **0.4904 ns** |  **1.00** | **0.0086** |     **144 B** |        **1.00** |
|            ForEachOfArrayOfKeyValuePair |     3 |          4.501 ns |     0.1045 ns |     0.0977 ns |  0.04 |      - |         - |        0.00 |
|              ForEachOfArrayOfValueTuple |     3 |          4.362 ns |     0.0482 ns |     0.0451 ns |  0.04 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray |     3 |         52.844 ns |     0.3851 ns |     0.3602 ns |  0.44 | 0.0057 |      96 B |        0.67 |
|       ForEachOfConcreteListOfValueTuple |     3 |          9.065 ns |     0.0501 ns |     0.0444 ns |  0.08 |      - |         - |        0.00 |
|                                         |       |                   |               |               |       |        |           |             |
|  **ForEachOfIListOfValueTupleBackedByList** |    **50** |     **26,909.856 ns** |    **21.0704 ns** |    **19.7093 ns** |  **1.00** | **0.1221** |    **2400 B** |        **1.00** |
|            ForEachOfArrayOfKeyValuePair |    50 |      1,627.503 ns |     0.4352 ns |     0.3634 ns |  0.06 |      - |         - |        0.00 |
|              ForEachOfArrayOfValueTuple |    50 |      1,678.621 ns |     2.8307 ns |     2.6479 ns |  0.06 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray |    50 |      7,430.310 ns |    93.9601 ns |    87.8903 ns |  0.28 | 0.0916 |    1600 B |        0.67 |
|       ForEachOfConcreteListOfValueTuple |    50 |      1,889.606 ns |     7.2880 ns |     6.8172 ns |  0.07 |      - |         - |        0.00 |
|                                         |       |                   |               |               |       |        |           |             |
|  **ForEachOfIListOfValueTupleBackedByList** |  **1000** | **10,604,615.885 ns** | **2,777.4004 ns** | **2,168.4115 ns** |  **1.00** |      **-** |   **48006 B** |        **1.00** |
|            ForEachOfArrayOfKeyValuePair |  1000 |    776,301.934 ns |   402.0705 ns |   376.0970 ns |  0.07 |      - |         - |        0.00 |
|              ForEachOfArrayOfValueTuple |  1000 |    812,843.945 ns | 4,367.2620 ns | 3,646.8615 ns |  0.08 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray |  1000 |  2,449,376.562 ns | 5,090.0333 ns | 4,250.4084 ns |  0.23 |      - |   32002 B |        0.67 |
|       ForEachOfConcreteListOfValueTuple |  1000 |    784,848.682 ns | 1,693.5026 ns | 1,501.2459 ns |  0.07 |      - |         - |        0.00 |
