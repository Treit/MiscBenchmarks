# Iterating a list vs. iterating a dictionary.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Job       | Runtime   | Count  | Mean          | Error       | StdDev      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |---------- |---------- |------- |--------------:|------------:|------------:|------:|--------:|----------:|------------:|
| **IterateList**                    | **.NET 10.0** | **.NET 10.0** | **3**      |      **2.279 ns** |   **0.0282 ns** |   **0.0264 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IterateDictionaryKeys          | .NET 10.0 | .NET 10.0 | 3      |      4.138 ns |   0.0261 ns |   0.0231 ns |  1.82 |    0.02 |         - |          NA |
| IterateDictionaryValues        | .NET 10.0 | .NET 10.0 | 3      |      4.112 ns |   0.0322 ns |   0.0285 ns |  1.80 |    0.02 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 10.0 | .NET 10.0 | 3      |      2.863 ns |   0.0268 ns |   0.0250 ns |  1.26 |    0.02 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| IterateList                    | .NET 9.0  | .NET 9.0  | 3      |      2.181 ns |   0.0614 ns |   0.0574 ns |  1.00 |    0.04 |         - |          NA |
| IterateDictionaryKeys          | .NET 9.0  | .NET 9.0  | 3      |      4.166 ns |   0.0405 ns |   0.0379 ns |  1.91 |    0.05 |         - |          NA |
| IterateDictionaryValues        | .NET 9.0  | .NET 9.0  | 3      |      4.167 ns |   0.0433 ns |   0.0405 ns |  1.91 |    0.05 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 9.0  | .NET 9.0  | 3      |      2.908 ns |   0.0402 ns |   0.0376 ns |  1.33 |    0.04 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| **IterateList**                    | **.NET 10.0** | **.NET 10.0** | **50**     |     **31.356 ns** |   **0.3962 ns** |   **0.3706 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IterateDictionaryKeys          | .NET 10.0 | .NET 10.0 | 50     |     48.352 ns |   0.2216 ns |   0.1964 ns |  1.54 |    0.02 |         - |          NA |
| IterateDictionaryValues        | .NET 10.0 | .NET 10.0 | 50     |     48.381 ns |   0.2186 ns |   0.1938 ns |  1.54 |    0.02 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 10.0 | .NET 10.0 | 50     |     47.757 ns |   0.3514 ns |   0.3287 ns |  1.52 |    0.02 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| IterateList                    | .NET 9.0  | .NET 9.0  | 50     |     31.464 ns |   0.3328 ns |   0.3113 ns |  1.00 |    0.01 |         - |          NA |
| IterateDictionaryKeys          | .NET 9.0  | .NET 9.0  | 50     |     48.646 ns |   0.3767 ns |   0.3524 ns |  1.55 |    0.02 |         - |          NA |
| IterateDictionaryValues        | .NET 9.0  | .NET 9.0  | 50     |     47.480 ns |   0.1874 ns |   0.1565 ns |  1.51 |    0.02 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 9.0  | .NET 9.0  | 50     |     47.381 ns |   0.2550 ns |   0.1991 ns |  1.51 |    0.02 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| **IterateList**                    | **.NET 10.0** | **.NET 10.0** | **1000**   |    **633.415 ns** |   **4.5597 ns** |   **4.2652 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | .NET 10.0 | .NET 10.0 | 1000   |    947.280 ns |   6.7733 ns |   6.3358 ns |  1.50 |    0.01 |         - |          NA |
| IterateDictionaryValues        | .NET 10.0 | .NET 10.0 | 1000   |    947.433 ns |  11.7443 ns |  10.9856 ns |  1.50 |    0.02 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 10.0 | .NET 10.0 | 1000   |    946.511 ns |   1.9248 ns |   1.7063 ns |  1.49 |    0.01 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| IterateList                    | .NET 9.0  | .NET 9.0  | 1000   |    631.309 ns |   3.3896 ns |   3.1706 ns |  1.00 |    0.01 |         - |          NA |
| IterateDictionaryKeys          | .NET 9.0  | .NET 9.0  | 1000   |    947.634 ns |   9.7535 ns |   9.1235 ns |  1.50 |    0.02 |         - |          NA |
| IterateDictionaryValues        | .NET 9.0  | .NET 9.0  | 1000   |    945.516 ns |   8.5682 ns |   8.0147 ns |  1.50 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 9.0  | .NET 9.0  | 1000   |    946.121 ns |   2.5928 ns |   2.1651 ns |  1.50 |    0.01 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| **IterateList**                    | **.NET 10.0** | **.NET 10.0** | **100000** | **62,765.115 ns** | **451.0931 ns** | **421.9528 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | .NET 10.0 | .NET 10.0 | 100000 | 94,811.639 ns | 526.9410 ns | 467.1195 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryValues        | .NET 10.0 | .NET 10.0 | 100000 | 94,881.074 ns | 553.9901 ns | 518.2027 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | .NET 10.0 | .NET 10.0 | 100000 | 95,636.101 ns | 838.7264 ns | 743.5091 ns |  1.52 |    0.02 |         - |          NA |
|                                |           |           |        |               |             |             |       |         |           |             |
| IterateList                    | .NET 9.0  | .NET 9.0  | 100000 | 62,770.181 ns | 543.5449 ns | 508.4322 ns |  1.00 |    0.01 |       2 B |        1.00 |
| IterateDictionaryKeys          | .NET 9.0  | .NET 9.0  | 100000 | 94,845.799 ns | 565.1401 ns | 471.9176 ns |  1.51 |    0.01 |         - |        0.00 |
| IterateDictionaryValues        | .NET 9.0  | .NET 9.0  | 100000 | 94,890.798 ns | 396.2496 ns | 351.2650 ns |  1.51 |    0.01 |       2 B |        1.00 |
| IterateDictionaryKeyValuePairs | .NET 9.0  | .NET 9.0  | 100000 | 95,064.795 ns | 544.7973 ns | 454.9304 ns |  1.51 |    0.01 |       2 B |        1.00 |
