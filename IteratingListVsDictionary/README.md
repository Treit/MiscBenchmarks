# Iterating a list vs. iterating a dictionary.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Count  | Mean          | Error       | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |------- |--------------:|------------:|------------:|------:|--------:|----------:|------------:|
| **IterateList**                    | **3**      |      **1.832 ns** |   **0.0390 ns** |   **0.0345 ns** |  **1.00** |    **0.03** |         **-** |          **NA** |
| IterateDictionaryKeys          | 3      |      3.809 ns |   0.0304 ns |   0.0254 ns |  2.08 |    0.04 |         - |          NA |
| IterateDictionaryValues        | 3      |      4.120 ns |   0.0296 ns |   0.0262 ns |  2.25 |    0.04 |         - |          NA |
| IterateDictionaryKeyValuePairs | 3      |      2.858 ns |   0.0356 ns |   0.0333 ns |  1.56 |    0.03 |         - |          NA |
|                                |        |               |             |             |       |         |           |             |
| **IterateList**                    | **50**     |     **31.735 ns** |   **0.3021 ns** |   **0.2678 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | 50     |     48.457 ns |   0.3293 ns |   0.3080 ns |  1.53 |    0.02 |         - |          NA |
| IterateDictionaryValues        | 50     |     48.000 ns |   0.1951 ns |   0.1825 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 50     |     47.338 ns |   0.2556 ns |   0.2134 ns |  1.49 |    0.01 |         - |          NA |
|                                |        |               |             |             |       |         |           |             |
| **IterateList**                    | **1000**   |    **632.825 ns** |   **5.8055 ns** |   **5.1464 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | 1000   |    944.330 ns |   1.1790 ns |   0.9845 ns |  1.49 |    0.01 |         - |          NA |
| IterateDictionaryValues        | 1000   |    947.372 ns |   3.2903 ns |   3.0778 ns |  1.50 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 1000   |    946.195 ns |   3.5847 ns |   3.3531 ns |  1.50 |    0.01 |         - |          NA |
|                                |        |               |             |             |       |         |           |             |
| **IterateList**                    | **100000** | **62,697.249 ns** | **422.1906 ns** | **394.9173 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | 100000 | 94,892.316 ns | 449.3149 ns | 398.3060 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryValues        | 100000 | 94,766.777 ns | 416.9108 ns | 389.9786 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 100000 | 94,995.050 ns | 438.2388 ns | 409.9288 ns |  1.52 |    0.01 |         - |          NA |
