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
| **IterateList**                    | **3**      |      **2.296 ns** |   **0.0387 ns** |   **0.0362 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IterateDictionaryKeys          | 3      |      4.122 ns |   0.0259 ns |   0.0242 ns |  1.80 |    0.03 |         - |          NA |
| IterateDictionaryValues        | 3      |      4.101 ns |   0.0268 ns |   0.0251 ns |  1.79 |    0.03 |         - |          NA |
| IterateDictionaryKeyValuePairs | 3      |      2.847 ns |   0.0273 ns |   0.0255 ns |  1.24 |    0.02 |         - |          NA |
|                                |        |               |             |             |       |         |           |             |
| **IterateList**                    | **50**     |     **31.577 ns** |   **0.2480 ns** |   **0.2320 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | 50     |     47.784 ns |   0.2161 ns |   0.1804 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryValues        | 50     |     48.149 ns |   0.2000 ns |   0.1670 ns |  1.52 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 50     |     46.862 ns |   0.2013 ns |   0.1883 ns |  1.48 |    0.01 |         - |          NA |
|                                |        |               |             |             |       |         |           |             |
| **IterateList**                    | **1000**   |    **630.270 ns** |   **3.3144 ns** |   **2.7677 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | 1000   |    942.142 ns |   1.9722 ns |   1.7483 ns |  1.49 |    0.01 |         - |          NA |
| IterateDictionaryValues        | 1000   |    942.639 ns |   6.4083 ns |   5.9943 ns |  1.50 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 1000   |    941.759 ns |   0.9774 ns |   0.9142 ns |  1.49 |    0.01 |         - |          NA |
|                                |        |               |             |             |       |         |           |             |
| **IterateList**                    | **100000** | **62,595.606 ns** | **423.5320 ns** | **396.1721 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IterateDictionaryKeys          | 100000 | 94,809.958 ns | 313.8800 ns | 278.2465 ns |  1.51 |    0.01 |         - |          NA |
| IterateDictionaryValues        | 100000 | 94,900.276 ns | 310.7114 ns | 275.4375 ns |  1.52 |    0.01 |         - |          NA |
| IterateDictionaryKeyValuePairs | 100000 | 95,024.763 ns | 465.3871 ns | 412.5536 ns |  1.52 |    0.01 |         - |          NA |
