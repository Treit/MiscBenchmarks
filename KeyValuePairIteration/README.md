# Enumerating KeyValuePair objects




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumerateDictionary                | 100   |   107.46 ns |  0.599 ns |  0.500 ns |  1.10 |    0.01 |      - |         - |          NA |
| EnumerateSortedDictionary          | 100   |   546.97 ns |  4.118 ns |  3.439 ns |  5.61 |    0.04 | 0.0086 |     152 B |          NA |
| EnumerateReadOnlyDictionary        | 100   | 1,470.68 ns |  5.793 ns |  4.838 ns | 15.09 |    0.06 | 0.0019 |      56 B |          NA |
| EnumerateFrozenDictionary          | 100   |   217.65 ns |  0.926 ns |  0.866 ns |  2.23 |    0.01 |      - |         - |          NA |
| EnumerateList                      | 100   |    97.47 ns |  0.285 ns |  0.238 ns |  1.00 |    0.00 |      - |         - |          NA |
| EnumerateSortedList                | 100   |   125.25 ns |  1.102 ns |  0.977 ns |  1.28 |    0.01 |      - |         - |          NA |
| EnumerateImmutableDictionary       | 100   | 2,082.33 ns | 16.168 ns | 14.333 ns | 21.36 |    0.15 |      - |         - |          NA |
| EnumerateImmutableSortedDictionary | 100   |   720.73 ns |  8.885 ns |  7.876 ns |  7.39 |    0.08 |      - |         - |          NA |
| EnumerateArray                     | 100   |    58.00 ns |  0.099 ns |  0.093 ns |  0.60 |    0.00 |      - |         - |          NA |
| EnumerateHashSet                   | 100   |   113.59 ns |  0.490 ns |  0.409 ns |  1.17 |    0.00 |      - |         - |          NA |
| EnumerateSortedSet                 | 100   |   536.39 ns |  5.006 ns |  4.438 ns |  5.50 |    0.05 | 0.0086 |     152 B |          NA |
| EnumerateImmutableHashSet          | 100   | 2,098.07 ns | 18.903 ns | 17.682 ns | 21.52 |    0.18 |      - |         - |          NA |
| EnumerateImmutableSortedSet        | 100   |   683.38 ns |  3.985 ns |  3.728 ns |  7.01 |    0.04 |      - |         - |          NA |
| EnumerateHashtable                 | 100   | 1,350.44 ns | 14.600 ns | 13.657 ns | 13.85 |    0.14 | 0.1945 |    3256 B |          NA |
| EnumerateArrayList                 | 100   |   361.40 ns |  4.422 ns |  4.136 ns |  3.71 |    0.04 | 0.0029 |      48 B |          NA |
| EnumerateQueue                     | 100   |   434.20 ns |  2.032 ns |  1.801 ns |  4.45 |    0.02 | 0.0024 |      40 B |          NA |
| EnumerateStack                     | 100   |   382.06 ns |  7.372 ns |  9.054 ns |  3.92 |    0.09 | 0.0024 |      40 B |          NA |
| EnumerateGenericQueue              | 100   |   116.11 ns |  0.999 ns |  0.934 ns |  1.19 |    0.01 |      - |         - |          NA |
| EnumerateGenericStack              | 100   |    88.57 ns |  0.360 ns |  0.301 ns |  0.91 |    0.00 |      - |         - |          NA |
