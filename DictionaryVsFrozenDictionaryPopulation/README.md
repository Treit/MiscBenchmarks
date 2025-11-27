# DictionaryVsFrozenDictionaryPopulation



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|------------------------------------- |---------- |---------- |------- |-------------:|-----------:|-----------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **CreateDictionary**                     | **.NET 10.0** | **.NET 10.0** | **1000**   |     **20.14 μs** |   **0.296 μs** |   **0.263 μs** |  **1.00** |    **0.02** |    **6.0730** |    **1.4954** |         **-** |    **99.82 KB** |        **1.00** |
| CreateDictionaryWithCapacity         | .NET 10.0 | .NET 10.0 | 1000   |     12.38 μs |   0.218 μs |   0.204 μs |  0.61 |    0.01 |    1.8463 |         - |         - |    30.29 KB |        0.30 |
| CreateDictionaryFromEnumerable       | .NET 10.0 | .NET 10.0 | 1000   |     12.93 μs |   0.168 μs |   0.148 μs |  0.64 |    0.01 |    1.8463 |         - |         - |    30.29 KB |        0.30 |
| CreateFrozenDictionary               | .NET 10.0 | .NET 10.0 | 1000   |     79.41 μs |   0.779 μs |   0.729 μs |  3.94 |    0.06 |   11.4746 |    2.8076 |         - |   188.35 KB |        1.89 |
| CreateFrozenDictionaryFromEnumerable | .NET 10.0 | .NET 10.0 | 1000   |     71.15 μs |   0.979 μs |   0.916 μs |  3.53 |    0.06 |    7.2021 |    0.6104 |         - |   118.82 KB |        1.19 |
| CreateFrozenDictionaryFromDictionary | .NET 10.0 | .NET 10.0 | 1000   |     71.72 μs |   0.817 μs |   0.682 μs |  3.56 |    0.06 |    7.2021 |    0.6104 |         - |   118.82 KB |        1.19 |
|                                      |           |           |        |              |            |            |       |         |           |           |           |             |             |
| CreateDictionary                     | .NET 9.0  | .NET 9.0  | 1000   |     19.56 μs |   0.286 μs |   0.267 μs |  1.00 |    0.02 |    6.0730 |    1.4954 |         - |    99.82 KB |        1.00 |
| CreateDictionaryWithCapacity         | .NET 9.0  | .NET 9.0  | 1000   |     12.28 μs |   0.124 μs |   0.110 μs |  0.63 |    0.01 |    1.8463 |         - |         - |    30.29 KB |        0.30 |
| CreateDictionaryFromEnumerable       | .NET 9.0  | .NET 9.0  | 1000   |     13.05 μs |   0.136 μs |   0.127 μs |  0.67 |    0.01 |    1.8463 |         - |         - |    30.29 KB |        0.30 |
| CreateFrozenDictionary               | .NET 9.0  | .NET 9.0  | 1000   |     80.14 μs |   1.581 μs |   1.479 μs |  4.10 |    0.09 |   11.4746 |    2.8076 |         - |   188.35 KB |        1.89 |
| CreateFrozenDictionaryFromEnumerable | .NET 9.0  | .NET 9.0  | 1000   |     71.89 μs |   1.063 μs |   0.994 μs |  3.68 |    0.07 |    7.2021 |    0.6104 |         - |   118.82 KB |        1.19 |
| CreateFrozenDictionaryFromDictionary | .NET 9.0  | .NET 9.0  | 1000   |     71.57 μs |   0.886 μs |   0.829 μs |  3.66 |    0.06 |    7.2021 |    0.6104 |         - |   118.82 KB |        1.19 |
|                                      |           |           |        |              |            |            |       |         |           |           |           |             |             |
| **CreateDictionary**                     | **.NET 10.0** | **.NET 10.0** | **100000** |  **3,427.93 μs** |  **52.032 μs** |  **46.125 μs** |  **1.00** |    **0.02** | **1003.9063** |  **992.1875** |  **992.1875** |  **8254.47 KB** |        **1.00** |
| CreateDictionaryWithCapacity         | .NET 10.0 | .NET 10.0 | 100000 |  2,551.74 μs |  45.326 μs |  42.398 μs |  0.74 |    0.02 |  312.5000 |  312.5000 |  312.5000 |   2970.6 KB |        0.36 |
| CreateDictionaryFromEnumerable       | .NET 10.0 | .NET 10.0 | 100000 |  2,728.48 μs |  35.253 μs |  32.976 μs |  0.80 |    0.01 |  324.2188 |  324.2188 |  324.2188 |   2970.6 KB |        0.36 |
| CreateFrozenDictionary               | .NET 10.0 | .NET 10.0 | 100000 | 14,832.25 μs | 111.104 μs | 103.927 μs |  4.33 |    0.06 | 1000.0000 | 1000.0000 | 1000.0000 | 16924.54 KB |        2.05 |
| CreateFrozenDictionaryFromEnumerable | .NET 10.0 | .NET 10.0 | 100000 | 14,301.65 μs | 119.117 μs | 105.594 μs |  4.17 |    0.06 |  984.3750 |  984.3750 |  984.3750 | 11644.12 KB |        1.41 |
| CreateFrozenDictionaryFromDictionary | .NET 10.0 | .NET 10.0 | 100000 | 13,063.00 μs | 103.823 μs |  97.116 μs |  3.81 |    0.06 |  984.3750 |  984.3750 |  984.3750 | 11643.98 KB |        1.41 |
|                                      |           |           |        |              |            |            |       |         |           |           |           |             |             |
| CreateDictionary                     | .NET 9.0  | .NET 9.0  | 100000 |  3,372.80 μs |  39.005 μs |  30.453 μs |  1.00 |    0.01 |  980.4688 |  968.7500 |  968.7500 |   8254.5 KB |        1.00 |
| CreateDictionaryWithCapacity         | .NET 9.0  | .NET 9.0  | 100000 |  2,568.64 μs |  24.148 μs |  20.165 μs |  0.76 |    0.01 |  320.3125 |  320.3125 |  320.3125 |   2970.6 KB |        0.36 |
| CreateDictionaryFromEnumerable       | .NET 9.0  | .NET 9.0  | 100000 |  2,607.31 μs |  22.493 μs |  17.561 μs |  0.77 |    0.01 |  328.1250 |  328.1250 |  328.1250 |   2970.6 KB |        0.36 |
| CreateFrozenDictionary               | .NET 9.0  | .NET 9.0  | 100000 | 14,875.99 μs | 256.959 μs | 240.359 μs |  4.41 |    0.08 | 1000.0000 | 1000.0000 | 1000.0000 | 16924.54 KB |        2.05 |
| CreateFrozenDictionaryFromEnumerable | .NET 9.0  | .NET 9.0  | 100000 | 13,032.02 μs | 106.137 μs |  88.629 μs |  3.86 |    0.04 |  984.3750 |  984.3750 |  984.3750 | 11643.91 KB |        1.41 |
| CreateFrozenDictionaryFromDictionary | .NET 9.0  | .NET 9.0  | 100000 | 13,168.69 μs |  93.867 μs |  83.210 μs |  3.90 |    0.04 |  984.3750 |  984.3750 |  984.3750 | 11644.29 KB |        1.41 |
