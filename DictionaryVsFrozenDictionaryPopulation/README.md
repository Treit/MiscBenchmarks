# DictionaryVsFrozenDictionaryPopulation


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated   | Alloc Ratio |
|------------------------------------- |------- |-------------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|------------:|------------:|
| **CreateDictionary**                     | **1000**   |     **19.47 μs** |   **0.284 μs** |   **0.265 μs** |  **1.00** |    **0.02** |   **6.0730** |   **1.4954** |        **-** |    **99.82 KB** |        **1.00** |
| CreateDictionaryWithCapacity         | 1000   |     12.10 μs |   0.105 μs |   0.093 μs |  0.62 |    0.01 |   1.8463 |        - |        - |    30.29 KB |        0.30 |
| CreateDictionaryFromEnumerable       | 1000   |     12.78 μs |   0.125 μs |   0.111 μs |  0.66 |    0.01 |   1.8463 |        - |        - |    30.29 KB |        0.30 |
| CreateFrozenDictionary               | 1000   |     77.72 μs |   0.839 μs |   0.785 μs |  3.99 |    0.07 |  11.4746 |   2.8076 |        - |   188.35 KB |        1.89 |
| CreateFrozenDictionaryFromEnumerable | 1000   |     70.93 μs |   0.992 μs |   0.928 μs |  3.64 |    0.07 |   7.2021 |   0.6104 |        - |   118.82 KB |        1.19 |
| CreateFrozenDictionaryFromDictionary | 1000   |     71.06 μs |   0.966 μs |   0.903 μs |  3.65 |    0.07 |   7.2021 |   0.6104 |        - |   118.82 KB |        1.19 |
|                                      |        |              |            |            |       |         |          |          |          |             |             |
| **CreateDictionary**                     | **100000** |  **3,779.17 μs** |  **71.421 μs** |  **97.762 μs** |  **1.00** |    **0.04** | **992.1875** | **980.4688** | **980.4688** |  **8254.49 KB** |        **1.00** |
| CreateDictionaryWithCapacity         | 100000 |  2,828.52 μs |  24.075 μs |  22.519 μs |  0.75 |    0.02 | 281.2500 | 281.2500 | 281.2500 |  2970.71 KB |        0.36 |
| CreateDictionaryFromEnumerable       | 100000 |  2,983.09 μs |  41.949 μs |  39.239 μs |  0.79 |    0.02 | 285.1563 | 285.1563 | 285.1563 |  2970.65 KB |        0.36 |
| CreateFrozenDictionary               | 100000 | 15,959.46 μs | 204.113 μs | 190.927 μs |  4.23 |    0.12 | 968.7500 | 968.7500 | 968.7500 | 16924.36 KB |        2.05 |
| CreateFrozenDictionaryFromEnumerable | 100000 | 13,728.43 μs | 100.682 μs |  89.252 μs |  3.63 |    0.09 | 984.3750 | 984.3750 | 984.3750 | 11644.09 KB |        1.41 |
| CreateFrozenDictionaryFromDictionary | 100000 | 13,235.09 μs | 100.339 μs |  83.787 μs |  3.50 |    0.09 | 984.3750 | 984.3750 | 984.3750 | 11644.35 KB |        1.41 |
