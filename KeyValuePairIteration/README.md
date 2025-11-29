# Enumerating KeyValuePair objects





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------ |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| EnumerateDictionary                | .NET 10.0 | .NET 10.0 | 100   |   108.02 ns |  0.649 ns |  0.607 ns |  1.11 |    0.01 |      - |         - |          NA |
| EnumerateSortedDictionary          | .NET 10.0 | .NET 10.0 | 100   |   550.80 ns |  5.361 ns |  4.752 ns |  5.64 |    0.05 | 0.0086 |     152 B |          NA |
| EnumerateReadOnlyDictionary        | .NET 10.0 | .NET 10.0 | 100   | 1,470.04 ns |  7.577 ns |  7.087 ns | 15.06 |    0.10 | 0.0019 |      56 B |          NA |
| EnumerateFrozenDictionary          | .NET 10.0 | .NET 10.0 | 100   |   218.50 ns |  0.842 ns |  0.788 ns |  2.24 |    0.01 |      - |         - |          NA |
| EnumerateList                      | .NET 10.0 | .NET 10.0 | 100   |    97.62 ns |  0.565 ns |  0.472 ns |  1.00 |    0.01 |      - |         - |          NA |
| EnumerateSortedList                | .NET 10.0 | .NET 10.0 | 100   |   122.26 ns |  1.653 ns |  1.546 ns |  1.25 |    0.02 |      - |         - |          NA |
| EnumerateImmutableDictionary       | .NET 10.0 | .NET 10.0 | 100   | 1,949.48 ns | 14.925 ns | 13.961 ns | 19.97 |    0.17 |      - |         - |          NA |
| EnumerateImmutableSortedDictionary | .NET 10.0 | .NET 10.0 | 100   |   721.23 ns |  6.027 ns |  5.343 ns |  7.39 |    0.06 |      - |         - |          NA |
| EnumerateArray                     | .NET 10.0 | .NET 10.0 | 100   |    57.80 ns |  0.627 ns |  0.587 ns |  0.59 |    0.01 |      - |         - |          NA |
| EnumerateHashSet                   | .NET 10.0 | .NET 10.0 | 100   |   113.63 ns |  0.450 ns |  0.376 ns |  1.16 |    0.01 |      - |         - |          NA |
| EnumerateSortedSet                 | .NET 10.0 | .NET 10.0 | 100   |   537.17 ns |  4.681 ns |  4.379 ns |  5.50 |    0.05 | 0.0086 |     152 B |          NA |
| EnumerateImmutableHashSet          | .NET 10.0 | .NET 10.0 | 100   | 2,103.01 ns | 22.505 ns | 21.052 ns | 21.54 |    0.23 |      - |         - |          NA |
| EnumerateImmutableSortedSet        | .NET 10.0 | .NET 10.0 | 100   |   665.36 ns |  5.180 ns |  4.845 ns |  6.82 |    0.06 |      - |         - |          NA |
| EnumerateHashtable                 | .NET 10.0 | .NET 10.0 | 100   | 1,340.65 ns | 21.651 ns | 18.080 ns | 13.73 |    0.19 | 0.1945 |    3256 B |          NA |
| EnumerateArrayList                 | .NET 10.0 | .NET 10.0 | 100   |   361.73 ns |  3.985 ns |  3.727 ns |  3.71 |    0.04 | 0.0029 |      48 B |          NA |
| EnumerateQueue                     | .NET 10.0 | .NET 10.0 | 100   |   447.13 ns |  2.470 ns |  2.310 ns |  4.58 |    0.03 | 0.0024 |      40 B |          NA |
| EnumerateStack                     | .NET 10.0 | .NET 10.0 | 100   |   418.53 ns |  8.261 ns |  7.727 ns |  4.29 |    0.08 | 0.0024 |      40 B |          NA |
| EnumerateGenericQueue              | .NET 10.0 | .NET 10.0 | 100   |   117.41 ns |  0.431 ns |  0.382 ns |  1.20 |    0.01 |      - |         - |          NA |
| EnumerateGenericStack              | .NET 10.0 | .NET 10.0 | 100   |   101.79 ns |  0.481 ns |  0.401 ns |  1.04 |    0.01 |      - |         - |          NA |
|                                    |           |           |       |             |           |           |       |         |        |           |             |
| EnumerateDictionary                | .NET 9.0  | .NET 9.0  | 100   |   107.74 ns |  0.482 ns |  0.376 ns |  1.10 |    0.01 |      - |         - |          NA |
| EnumerateSortedDictionary          | .NET 9.0  | .NET 9.0  | 100   |   552.86 ns |  8.034 ns |  7.515 ns |  5.66 |    0.08 | 0.0086 |     152 B |          NA |
| EnumerateReadOnlyDictionary        | .NET 9.0  | .NET 9.0  | 100   | 1,468.56 ns |  6.000 ns |  5.010 ns | 15.03 |    0.07 | 0.0019 |      56 B |          NA |
| EnumerateFrozenDictionary          | .NET 9.0  | .NET 9.0  | 100   |   218.57 ns |  1.138 ns |  1.065 ns |  2.24 |    0.01 |      - |         - |          NA |
| EnumerateList                      | .NET 9.0  | .NET 9.0  | 100   |    97.70 ns |  0.362 ns |  0.339 ns |  1.00 |    0.00 |      - |         - |          NA |
| EnumerateSortedList                | .NET 9.0  | .NET 9.0  | 100   |   121.97 ns |  1.503 ns |  1.406 ns |  1.25 |    0.01 |      - |         - |          NA |
| EnumerateImmutableDictionary       | .NET 9.0  | .NET 9.0  | 100   | 2,090.28 ns | 14.810 ns | 13.853 ns | 21.40 |    0.16 |      - |         - |          NA |
| EnumerateImmutableSortedDictionary | .NET 9.0  | .NET 9.0  | 100   |   719.01 ns |  7.448 ns |  6.603 ns |  7.36 |    0.07 |      - |         - |          NA |
| EnumerateArray                     | .NET 9.0  | .NET 9.0  | 100   |    57.59 ns |  0.551 ns |  0.515 ns |  0.59 |    0.01 |      - |         - |          NA |
| EnumerateHashSet                   | .NET 9.0  | .NET 9.0  | 100   |   113.54 ns |  0.422 ns |  0.374 ns |  1.16 |    0.01 |      - |         - |          NA |
| EnumerateSortedSet                 | .NET 9.0  | .NET 9.0  | 100   |   538.57 ns |  4.183 ns |  3.913 ns |  5.51 |    0.04 | 0.0086 |     152 B |          NA |
| EnumerateImmutableHashSet          | .NET 9.0  | .NET 9.0  | 100   | 2,115.45 ns | 16.357 ns | 15.300 ns | 21.65 |    0.17 |      - |         - |          NA |
| EnumerateImmutableSortedSet        | .NET 9.0  | .NET 9.0  | 100   |   667.09 ns |  4.552 ns |  3.801 ns |  6.83 |    0.04 |      - |         - |          NA |
| EnumerateHashtable                 | .NET 9.0  | .NET 9.0  | 100   | 1,348.78 ns | 25.033 ns | 23.416 ns | 13.81 |    0.24 | 0.1945 |    3256 B |          NA |
| EnumerateArrayList                 | .NET 9.0  | .NET 9.0  | 100   |   367.10 ns |  7.098 ns |  7.289 ns |  3.76 |    0.07 | 0.0029 |      48 B |          NA |
| EnumerateQueue                     | .NET 9.0  | .NET 9.0  | 100   |   445.16 ns |  2.045 ns |  1.813 ns |  4.56 |    0.02 | 0.0024 |      40 B |          NA |
| EnumerateStack                     | .NET 9.0  | .NET 9.0  | 100   |   413.58 ns |  7.952 ns |  7.438 ns |  4.23 |    0.08 | 0.0024 |      40 B |          NA |
| EnumerateGenericQueue              | .NET 9.0  | .NET 9.0  | 100   |   116.88 ns |  0.613 ns |  0.573 ns |  1.20 |    0.01 |      - |         - |          NA |
| EnumerateGenericStack              | .NET 9.0  | .NET 9.0  | 100   |   101.70 ns |  0.470 ns |  0.393 ns |  1.04 |    0.01 |      - |         - |          NA |
