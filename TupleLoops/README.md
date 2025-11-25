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
| **ForEachOfIListOfValueTupleBackedByList**  | **3**     |        **121.244 ns** |      **1.1171 ns** |      **0.9903 ns** |  **1.00** | **0.0086** |     **144 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | 3     |          3.955 ns |      0.0572 ns |      0.0535 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | 3     |          3.941 ns |      0.0390 ns |      0.0346 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | 3     |         47.940 ns |      0.2506 ns |      0.2344 ns |  0.40 | 0.0057 |      96 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | 3     |         10.520 ns |      0.0694 ns |      0.0615 ns |  0.09 |      - |         - |        0.00 |
|                                         |       |                   |                |                |       |        |           |             |
| **ForEachOfIListOfValueTupleBackedByList**  | **50**    |     **27,138.384 ns** |     **87.1571 ns** |     **72.7802 ns** |  **1.00** | **0.1221** |    **2400 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | 50    |        919.384 ns |      3.0089 ns |      2.5126 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | 50    |        869.128 ns |      3.2156 ns |      3.0079 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | 50    |      6,693.204 ns |     45.5348 ns |     42.5933 ns |  0.25 | 0.0916 |    1600 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | 50    |      2,379.750 ns |     18.7989 ns |     16.6647 ns |  0.09 |      - |         - |        0.00 |
|                                         |       |                   |                |                |       |        |           |             |
| **ForEachOfIListOfValueTupleBackedByList**  | **1000**  | **10,666,583.958 ns** | **48,716.0118 ns** | **45,568.9877 ns** |  **1.00** |      **-** |   **48000 B** |        **1.00** |
| ForEachOfArrayOfKeyValuePair            | 1000  |    320,328.789 ns |  1,520.0640 ns |  1,421.8688 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfArrayOfValueTuple              | 1000  |    320,310.661 ns |  2,412.4613 ns |  2,256.6178 ns |  0.03 |      - |         - |        0.00 |
| ForEachOfIListOfValueTupleBackedByArray | 1000  |  2,428,371.224 ns | 14,729.6175 ns | 13,778.0933 ns |  0.23 |      - |   32000 B |        0.67 |
| ForEachOfConcreteListOfValueTuple       | 1000  |    736,861.354 ns |  3,761.4463 ns |  3,518.4592 ns |  0.07 |      - |         - |        0.00 |
