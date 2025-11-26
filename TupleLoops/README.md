# Looping over sets of tuples




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Count | Mean              | Error          | StdDev         | Ratio | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |------ |------------------:|---------------:|---------------:|------:|-------:|----------:|------------:|
| **ForEachOfIListOfValueTupleBackedByList**  | **3**     |        **123.133 ns** |      **1.0084 ns** |      **0.9432 ns** |  **1.00** | **0.0086** |     **144 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | 3     |          3.956 ns |      0.0699 ns |      0.0654 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | 3     |          3.943 ns |      0.0353 ns |      0.0331 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | 3     |         48.038 ns |      0.4454 ns |      0.3949 ns |  0.39 | 0.0057 |      96 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | 3     |         10.310 ns |      0.0552 ns |      0.0517 ns |  0.08 |      - |         - |        0.00 |
|                                         |       |                   |                |                |       |        |           |             |
| **ForEachOfIListOfValueTupleBackedByList**  | **50**    |     **27,191.642 ns** |     **79.1196 ns** |     **66.0685 ns** |  **1.00** | **0.1221** |    **2400 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | 50    |        931.842 ns |      3.8612 ns |      3.4228 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | 50    |        873.047 ns |      4.1079 ns |      3.6416 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | 50    |      6,631.024 ns |     23.1771 ns |     19.3539 ns |  0.24 | 0.0916 |    1600 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | 50    |      2,390.496 ns |     19.9490 ns |     18.6603 ns |  0.09 |      - |         - |        0.00 |
|                                         |       |                   |                |                |       |        |           |             |
| **ForEachOfIListOfValueTupleBackedByList**  | **1000**  | **10,704,621.250 ns** | **48,843.1219 ns** | **45,687.8866 ns** |  **1.00** |      **-** |   **48000 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | 1000  |    323,753.867 ns |  2,808.9569 ns |  2,627.5000 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | 1000  |    324,334.079 ns |  3,061.0984 ns |  2,713.5840 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | 1000  |  2,429,900.117 ns | 14,191.3237 ns | 13,274.5730 ns |  0.23 |      - |   32000 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | 1000  |    740,157.064 ns |  3,914.1905 ns |  3,661.3362 ns |  0.07 |      - |         - |        0.00 |
