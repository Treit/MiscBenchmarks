# Looping over sets of tuples





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Job       | Runtime   | Count | Mean              | Error         | StdDev        | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |---------- |---------- |------ |------------------:|--------------:|--------------:|------:|-------:|----------:|------------:|
| **ForEachOfIListOfValueTupleBackedByList**  | **.NET 10.0** | **.NET 10.0** | **3**     |        **120.805 ns** |     **0.8745 ns** |     **0.8180 ns** |  **1.00** | **0.0086** |     **144 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | .NET 10.0 | .NET 10.0 | 3     |          3.923 ns |     0.0585 ns |     0.0547 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | .NET 10.0 | .NET 10.0 | 3     |          3.940 ns |     0.0621 ns |     0.0581 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | .NET 10.0 | .NET 10.0 | 3     |         47.429 ns |     0.1931 ns |     0.1807 ns |  0.39 | 0.0057 |      96 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | .NET 10.0 | .NET 10.0 | 3     |         10.454 ns |     0.0260 ns |     0.0230 ns |  0.09 |      - |         - |        0.00 |
|                                         |           |           |       |                   |               |               |       |        |           |             |
| ForEachOfIListOfValueTupleBackedByList  | .NET 9.0  | .NET 9.0  | 3     |        116.570 ns |     0.7733 ns |     0.6855 ns |  1.00 | 0.0086 |     144 B |        1.00 |
| ForEachOfArrayOfKeyValuePair            | .NET 9.0  | .NET 9.0  | 3     |          3.892 ns |     0.0411 ns |     0.0343 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | .NET 9.0  | .NET 9.0  | 3     |          3.895 ns |     0.0582 ns |     0.0516 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | .NET 9.0  | .NET 9.0  | 3     |         47.321 ns |     0.2793 ns |     0.2612 ns |  0.41 | 0.0057 |      96 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | .NET 9.0  | .NET 9.0  | 3     |         10.480 ns |     0.0617 ns |     0.0577 ns |  0.09 |      - |         - |        0.00 |
|                                         |           |           |       |                   |               |               |       |        |           |             |
| **ForEachOfIListOfValueTupleBackedByList**  | **.NET 10.0** | **.NET 10.0** | **50**    |     **27,028.119 ns** |    **25.0201 ns** |    **20.8930 ns** |  **1.00** | **0.1221** |    **2400 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | .NET 10.0 | .NET 10.0 | 50    |        914.490 ns |     2.3613 ns |     2.2088 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | .NET 10.0 | .NET 10.0 | 50    |        865.407 ns |     3.5938 ns |     3.3616 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | .NET 10.0 | .NET 10.0 | 50    |      6,645.784 ns |    24.1676 ns |    22.6063 ns |  0.25 | 0.0916 |    1600 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | .NET 10.0 | .NET 10.0 | 50    |      2,364.721 ns |     5.2269 ns |     4.6335 ns |  0.09 |      - |         - |        0.00 |
|                                         |           |           |       |                   |               |               |       |        |           |             |
| ForEachOfIListOfValueTupleBackedByList  | .NET 9.0  | .NET 9.0  | 50    |     26,981.388 ns |    60.1104 ns |    56.2273 ns |  1.00 | 0.1221 |    2400 B |        1.00 |
| ForEachOfArrayOfKeyValuePair            | .NET 9.0  | .NET 9.0  | 50    |        916.737 ns |     2.9148 ns |     2.7265 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | .NET 9.0  | .NET 9.0  | 50    |        876.913 ns |     1.5009 ns |     1.1718 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | .NET 9.0  | .NET 9.0  | 50    |      6,561.891 ns |    22.5860 ns |    18.8604 ns |  0.24 | 0.0916 |    1600 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | .NET 9.0  | .NET 9.0  | 50    |      2,363.941 ns |     4.7318 ns |     3.6943 ns |  0.09 |      - |         - |        0.00 |
|                                         |           |           |       |                   |               |               |       |        |           |             |
| **ForEachOfIListOfValueTupleBackedByList**  | **.NET 10.0** | **.NET 10.0** | **1000**  | **10,610,757.812 ns** | **3,341.9445 ns** | **2,790.6750 ns** |  **1.00** |      **-** |   **48000 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | .NET 10.0 | .NET 10.0 | 1000  |    319,119.697 ns |   531.4360 ns |   443.7731 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | .NET 10.0 | .NET 10.0 | 1000  |    318,611.475 ns |   542.1410 ns |   423.2681 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | .NET 10.0 | .NET 10.0 | 1000  |  2,409,771.244 ns | 4,525.8745 ns | 3,779.3102 ns |  0.23 |      - |   32000 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | .NET 10.0 | .NET 10.0 | 1000  |    733,827.585 ns | 2,362.7005 ns | 2,210.0715 ns |  0.07 |      - |         - |        0.00 |
|                                         |           |           |       |                   |               |               |       |        |           |             |
| ForEachOfIListOfValueTupleBackedByList  | .NET 9.0  | .NET 9.0  | 1000  | 10,620,452.865 ns | 5,094.9928 ns | 3,977.8353 ns |  1.00 |      - |   48000 B |        1.00 |
| ForEachOfArrayOfKeyValuePair            | .NET 9.0  | .NET 9.0  | 1000  |    318,588.657 ns |   826.3699 ns |   690.0563 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | .NET 9.0  | .NET 9.0  | 1000  |    318,162.906 ns |   576.6930 ns |   481.5648 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | .NET 9.0  | .NET 9.0  | 1000  |  2,381,420.162 ns | 2,173.5535 ns | 1,815.0156 ns |  0.22 |      - |   32000 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | .NET 9.0  | .NET 9.0  | 1000  |    732,682.749 ns |   782.2433 ns |   653.2086 ns |  0.07 |      - |         - |        0.00 |
