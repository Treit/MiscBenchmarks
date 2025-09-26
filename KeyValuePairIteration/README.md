# Enumerating KeyValuePair objects


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27954.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count | Mean          | Error        | StdDev        | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |------ |--------------:|-------------:|--------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **EnumerateDictionary**                | **100**   |     **134.06 ns** |     **2.718 ns** |      **6.460 ns** |     **132.76 ns** |  **1.39** |    **0.07** |      **-** |         **-** |          **NA** |
| EnumerateSortedDictionary          | 100   |   1,210.74 ns |    25.033 ns |     73.022 ns |   1,188.60 ns | 12.53 |    0.76 | 0.0343 |     152 B |          NA |
| EnumerateReadOnlyDictionary        | 100   |     975.28 ns |    19.558 ns |     20.927 ns |     972.41 ns | 10.10 |    0.23 | 0.0114 |      56 B |          NA |
| EnumerateFrozenDictionary          | 100   |     231.04 ns |     3.807 ns |      3.561 ns |     230.34 ns |  2.39 |    0.04 |      - |         - |          NA |
| EnumerateList                      | 100   |      96.61 ns |     0.897 ns |      0.795 ns |      96.66 ns |  1.00 |    0.01 |      - |         - |          NA |
| EnumerateSortedList                | 100   |     397.10 ns |     6.284 ns |      5.571 ns |     396.96 ns |  4.11 |    0.06 | 0.0110 |      48 B |          NA |
| EnumerateImmutableDictionary       | 100   |   2,252.26 ns |    39.886 ns |     48.984 ns |   2,246.96 ns | 23.31 |    0.53 |      - |         - |          NA |
| EnumerateImmutableSortedDictionary | 100   |     891.03 ns |    15.645 ns |     22.933 ns |     887.84 ns |  9.22 |    0.24 |      - |         - |          NA |
| EnumerateArray                     | 100   |      60.35 ns |     1.078 ns |      0.901 ns |      60.15 ns |  0.62 |    0.01 |      - |         - |          NA |
|                                    |       |               |              |               |               |       |         |        |           |             |
| **EnumerateDictionary**                | **10000** |  **14,126.09 ns** |   **169.560 ns** |    **150.311 ns** |  **14,131.93 ns** |  **1.18** |    **0.02** |      **-** |         **-** |          **NA** |
| EnumerateSortedDictionary          | 10000 | 117,139.68 ns | 2,333.515 ns |  4,439.755 ns | 115,750.26 ns |  9.77 |    0.41 |      - |     264 B |          NA |
| EnumerateReadOnlyDictionary        | 10000 |  95,667.45 ns | 1,805.676 ns |  1,854.297 ns |  95,284.55 ns |  7.98 |    0.21 |      - |      56 B |          NA |
| EnumerateFrozenDictionary          | 10000 |  23,976.53 ns |   473.254 ns |    790.702 ns |  23,919.56 ns |  2.00 |    0.07 |      - |         - |          NA |
| EnumerateList                      | 10000 |  11,990.03 ns |   232.964 ns |    228.802 ns |  11,945.34 ns |  1.00 |    0.03 |      - |         - |          NA |
| EnumerateSortedList                | 10000 |  42,345.46 ns |   835.744 ns |  1,250.902 ns |  42,576.88 ns |  3.53 |    0.12 |      - |      48 B |          NA |
| EnumerateImmutableDictionary       | 10000 | 342,582.09 ns | 6,847.612 ns | 19,866.165 ns | 340,517.85 ns | 28.58 |    1.73 |      - |         - |          NA |
| EnumerateImmutableSortedDictionary | 10000 |  89,217.16 ns | 1,713.351 ns |  2,401.879 ns |  89,362.72 ns |  7.44 |    0.24 |      - |         - |          NA |
| EnumerateArray                     | 10000 |   7,878.90 ns |   134.228 ns |    118.990 ns |   7,855.07 ns |  0.66 |    0.02 |      - |         - |          NA |
