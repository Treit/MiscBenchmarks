# Enumerating KeyValuePair objects



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27954.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count | Mean        | Error     | StdDev     | Median      | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|----------:|------------:|
| EnumerateDictionary                | 100   |   128.13 ns |  2.579 ns |   4.165 ns |   127.59 ns |  1.29 |    0.06 |      - |         - |          NA |
| EnumerateSortedDictionary          | 100   | 1,163.26 ns | 22.733 ns |  27.062 ns | 1,159.42 ns | 11.67 |    0.53 | 0.0343 |     152 B |          NA |
| EnumerateReadOnlyDictionary        | 100   |   969.50 ns | 16.729 ns |  15.649 ns |   971.75 ns |  9.72 |    0.41 | 0.0124 |      56 B |          NA |
| EnumerateFrozenDictionary          | 100   |   230.29 ns |  4.130 ns |   3.864 ns |   230.72 ns |  2.31 |    0.10 |      - |         - |          NA |
| EnumerateList                      | 100   |    99.85 ns |  2.035 ns |   4.064 ns |    99.35 ns |  1.00 |    0.06 |      - |         - |          NA |
| EnumerateSortedList                | 100   |   411.74 ns |  8.264 ns |  16.313 ns |   409.01 ns |  4.13 |    0.23 | 0.0110 |      48 B |          NA |
| EnumerateImmutableDictionary       | 100   | 2,510.62 ns | 50.007 ns | 138.570 ns | 2,482.52 ns | 25.18 |    1.70 |      - |         - |          NA |
| EnumerateImmutableSortedDictionary | 100   | 1,016.98 ns | 35.665 ns | 102.903 ns |   986.69 ns | 10.20 |    1.10 |      - |         - |          NA |
| EnumerateArray                     | 100   |    62.25 ns |  1.239 ns |   2.328 ns |    61.71 ns |  0.62 |    0.03 |      - |         - |          NA |
| EnumerateHashSet                   | 100   |   202.18 ns |  4.087 ns |   4.197 ns |   202.56 ns |  2.03 |    0.09 |      - |         - |          NA |
| EnumerateSortedSet                 | 100   |   555.00 ns | 11.105 ns |  18.857 ns |   548.64 ns |  5.57 |    0.29 | 0.0343 |     152 B |          NA |
| EnumerateImmutableHashSet          | 100   | 2,792.87 ns | 55.629 ns |  81.540 ns | 2,769.97 ns | 28.01 |    1.36 |      - |         - |          NA |
| EnumerateImmutableSortedSet        | 100   |   926.64 ns | 16.175 ns |  15.130 ns |   929.57 ns |  9.29 |    0.39 |      - |         - |          NA |
| EnumerateHashtable                 | 100   | 1,766.63 ns | 35.209 ns |  81.602 ns | 1,746.76 ns | 17.72 |    1.07 | 0.7534 |    3256 B |          NA |
| EnumerateArrayList                 | 100   |   509.97 ns | 25.753 ns |  75.934 ns |   482.33 ns |  5.12 |    0.78 | 0.0110 |      48 B |          NA |
| EnumerateQueue                     | 100   |   741.22 ns | 14.906 ns |  41.799 ns |   734.04 ns |  7.44 |    0.51 | 0.0086 |      40 B |          NA |
| EnumerateStack                     | 100   |   468.97 ns | 10.181 ns |  29.536 ns |   458.88 ns |  4.70 |    0.35 | 0.0091 |      40 B |          NA |
| EnumerateGenericQueue              | 100   |   345.82 ns |  9.329 ns |  26.616 ns |   341.69 ns |  3.47 |    0.30 |      - |         - |          NA |
| EnumerateGenericStack              | 100   |   359.61 ns |  7.027 ns |  14.034 ns |   356.45 ns |  3.61 |    0.20 |      - |         - |          NA |
