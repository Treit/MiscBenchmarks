# Collection Bulk vs Individual Add Benchmark

Looping through and calling Add vs. using other techniques.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|--------------------------------- |------ |--------------:|-------------:|-------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **ListIndividualAdd**                | **10**    |      **23.12 ns** |     **0.122 ns** |     **0.102 ns** |  **1.00** |    **0.01** |  **0.0057** |       **-** |       **-** |      **96 B** |        **1.00** |
| ListAddRange                     | 10    |      12.40 ns |     0.313 ns |     0.514 ns |  0.54 |    0.02 |  0.0057 |       - |       - |      96 B |        1.00 |
| ListConstructorWithCollection    | 10    |      11.08 ns |     0.151 ns |     0.141 ns |  0.48 |    0.01 |  0.0057 |       - |       - |      96 B |        1.00 |
| HashSetIndividualAdd             | 10    |      89.85 ns |     0.859 ns |     0.804 ns |  3.89 |    0.04 |  0.0176 |       - |       - |     296 B |        3.08 |
| HashSetUnionWith                 | 10    |      95.80 ns |     0.749 ns |     0.664 ns |  4.14 |    0.03 |  0.0176 |       - |       - |     296 B |        3.08 |
| HashSetConstructorWithCollection | 10    |      97.36 ns |     1.731 ns |     1.619 ns |  4.21 |    0.07 |  0.0176 |       - |       - |     296 B |        3.08 |
|                                  |       |               |              |              |       |         |         |         |         |           |             |
| **ListIndividualAdd**                | **10000** |  **15,694.59 ns** |   **276.266 ns** |   **258.419 ns** |  **1.00** |    **0.02** |  **2.3804** |  **0.2747** |       **-** |   **40056 B** |        **1.00** |
| ListAddRange                     | 10000 |   2,162.58 ns |    41.608 ns |    51.099 ns |  0.14 |    0.00 |  2.3918 |  0.2975 |       - |   40056 B |        1.00 |
| ListConstructorWithCollection    | 10000 |   2,145.96 ns |    42.715 ns |    65.230 ns |  0.14 |    0.00 |  2.3918 |  0.2975 |       - |   40056 B |        1.00 |
| HashSetIndividualAdd             | 10000 | 124,418.44 ns | 3,015.677 ns | 8,891.792 ns |  7.93 |    0.58 | 38.3301 | 38.3301 | 38.3301 |  161781 B |        4.04 |
| HashSetUnionWith                 | 10000 | 133,515.55 ns | 2,648.986 ns | 5,924.837 ns |  8.51 |    0.40 | 38.3301 | 38.3301 | 38.3301 |  161781 B |        4.04 |
| HashSetConstructorWithCollection | 10000 | 135,202.28 ns | 2,082.624 ns | 1,948.088 ns |  8.62 |    0.18 | 38.3301 | 38.3301 | 38.3301 |  161781 B |        4.04 |
