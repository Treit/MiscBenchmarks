# Looping over sets of tuples

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25231
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT
  DefaultJob : .NET Core 6.0.10 (CoreCLR 6.0.1022.47605, CoreFX 6.0.1022.47605), X64 RyuJIT


```
|                                  Method | Count |              Mean |           Error |            StdDev |            Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------- |------ |------------------:|----------------:|------------------:|------------------:|------:|--------:|-------:|------:|------:|----------:|
|  **ForEachOfIListOfValueTupleBackedByList** |     **3** |        **202.582 ns** |       **4.0885 ns** |         **8.8880 ns** |        **200.924 ns** |  **1.00** |    **0.00** | **0.0334** |     **-** |     **-** |     **144 B** |
|            ForEachOfArrayOfKeyValuePair |     3 |         10.817 ns |       0.2498 ns |         0.7004 ns |         10.720 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |     3 |          8.840 ns |       0.2117 ns |         0.6005 ns |          8.690 ns |  0.04 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |     3 |        135.649 ns |       4.9226 ns |        13.8842 ns |        131.751 ns |  0.67 |    0.08 | 0.0222 |     - |     - |      96 B |
|       ForEachOfConcreteListOfValueTuple |     3 |         59.654 ns |       1.2068 ns |         1.6110 ns |         59.822 ns |  0.29 |    0.02 |      - |     - |     - |         - |
|                                         |       |                   |                 |                   |                   |       |         |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |    **50** |     **39,504.479 ns** |     **992.9485 ns** |     **2,832.9379 ns** |     **39,068.164 ns** |  **1.00** |    **0.00** | **0.5493** |     **-** |     **-** |    **2400 B** |
|            ForEachOfArrayOfKeyValuePair |    50 |      2,351.288 ns |      44.4004 ns |        84.4764 ns |      2,314.953 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |    50 |      1,641.364 ns |      30.9270 ns |        56.5517 ns |      1,628.096 ns |  0.04 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |    50 |     19,764.762 ns |     478.0165 ns |     1,401.9395 ns |     19,299.930 ns |  0.50 |    0.05 | 0.3662 |     - |     - |    1600 B |
|       ForEachOfConcreteListOfValueTuple |    50 |      7,898.543 ns |     247.3175 ns |       705.6108 ns |      7,713.297 ns |  0.20 |    0.02 |      - |     - |     - |         - |
|                                         |       |                   |                 |                   |                   |       |         |        |       |       |           |
|  **ForEachOfIListOfValueTupleBackedByList** |  **1000** | **15,539,867.138 ns** | **430,005.4212 ns** | **1,233,766.1605 ns** | **15,149,231.250 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |   **48012 B** |
|            ForEachOfArrayOfKeyValuePair |  1000 |    930,800.488 ns |  17,466.7625 ns |    37,971.3042 ns |    934,729.590 ns |  0.06 |    0.01 |      - |     - |     - |         - |
|              ForEachOfArrayOfValueTuple |  1000 |    644,113.238 ns |  12,826.7526 ns |    36,387.3623 ns |    634,128.662 ns |  0.04 |    0.00 |      - |     - |     - |         - |
| ForEachOfIListOfValueTupleBackedByArray |  1000 |  7,757,569.754 ns | 221,803.6857 ns |   647,011.7620 ns |  7,649,430.859 ns |  0.50 |    0.06 |      - |     - |     - |   32003 B |
|       ForEachOfConcreteListOfValueTuple |  1000 |  2,829,991.274 ns |  56,554.3466 ns |   148,986.7697 ns |  2,808,113.086 ns |  0.18 |    0.02 |      - |     - |     - |       2 B |
