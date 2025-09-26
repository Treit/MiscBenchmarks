# Enumerating KeyValuePair objects

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27954.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count | Mean         | Error        | StdDev       | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------ |-------------:|-------------:|-------------:|------:|--------:|-------:|----------:|------------:|
| **EnumerateDictionary**         | **100**   |     **238.3 ns** |      **4.39 ns** |      **3.89 ns** |  **1.85** |    **0.26** |      **-** |         **-** |          **NA** |
| EnumerateSortedDictionary   | 100   |   1,998.1 ns |    127.71 ns |    376.54 ns | 15.48 |    3.62 | 0.0343 |     152 B |          NA |
| EnumerateReadOnlyDictionary | 100   |   1,153.4 ns |     22.76 ns |     21.29 ns |  8.94 |    1.24 | 0.0114 |      56 B |          NA |
| EnumerateFrozenDictionary   | 100   |     276.4 ns |      8.12 ns |     23.95 ns |  2.14 |    0.35 |      - |         - |          NA |
| EnumerateList               | 100   |     131.7 ns |      6.73 ns |     19.75 ns |  1.02 |    0.21 |      - |         - |          NA |
|                             |       |              |              |              |       |         |        |           |             |
| **EnumerateDictionary**         | **10000** |  **19,836.0 ns** |  **1,013.36 ns** |  **2,987.90 ns** |  **1.18** |    **0.23** |      **-** |         **-** |          **NA** |
| EnumerateSortedDictionary   | 10000 | 183,972.3 ns | 10,952.73 ns | 32,294.36 ns | 10.93 |    2.39 |      - |     264 B |          NA |
| EnumerateReadOnlyDictionary | 10000 | 105,580.6 ns |  2,077.70 ns |  3,851.16 ns |  6.27 |    0.84 |      - |      56 B |          NA |
| EnumerateFrozenDictionary   | 10000 |  29,732.0 ns |    789.28 ns |  2,327.20 ns |  1.77 |    0.27 |      - |         - |          NA |
| EnumerateList               | 10000 |  17,110.2 ns |    753.53 ns |  2,221.79 ns |  1.02 |    0.19 |      - |         - |          NA |
