# Enumerating various collection types

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27852.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count  | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **EnumerateArray**              | **10**     |      **34.19 ns** |      **1.051 ns** |      **3.048 ns** |      **33.79 ns** |  **1.18** |    **0.12** | **0.0074** |      **32 B** |        **1.00** |
| EnumerateList               | 10     |      43.46 ns |      1.047 ns |      3.021 ns |      42.78 ns |  1.45 |    0.12 | 0.0092 |      40 B |        1.25 |
| EnumerateReadOnlyCollection | 10     |      29.59 ns |      0.627 ns |      1.584 ns |      29.41 ns |  1.00 |    0.00 | 0.0074 |      32 B |        1.00 |
| EnumerateImmutableArray     | 10     |      33.88 ns |      0.713 ns |      1.736 ns |      33.79 ns |  1.14 |    0.08 | 0.0129 |      56 B |        1.75 |
| EnumerateReadOnlyList       | 10     |      56.79 ns |      1.847 ns |      5.300 ns |      55.55 ns |  1.96 |    0.22 | 0.0092 |      40 B |        1.25 |
| EnumerateArraySegment       | 10     |      44.27 ns |      1.364 ns |      4.000 ns |      43.14 ns |  1.51 |    0.15 | 0.0167 |      72 B |        2.25 |
| EnumerateLinkedList         | 10     |      64.03 ns |      1.334 ns |      3.829 ns |      64.16 ns |  2.18 |    0.16 | 0.0111 |      48 B |        1.50 |
|                             |        |               |               |               |               |       |         |        |           |             |
| **EnumerateArray**              | **100000** | **213,586.13 ns** |  **5,249.597 ns** | **15,478.556 ns** | **208,836.21 ns** |  **1.32** |    **0.09** |      **-** |      **32 B** |        **1.00** |
| EnumerateList               | 100000 | 334,285.09 ns |  6,698.594 ns | 19,540.113 ns | 328,521.88 ns |  2.10 |    0.13 |      - |      40 B |        1.25 |
| EnumerateReadOnlyCollection | 100000 | 159,418.68 ns |  3,068.200 ns |  3,989.526 ns | 158,543.73 ns |  1.00 |    0.00 |      - |      32 B |        1.00 |
| EnumerateImmutableArray     | 100000 | 174,169.16 ns |  3,405.736 ns |  4,307.165 ns | 174,490.61 ns |  1.09 |    0.05 |      - |      56 B |        1.75 |
| EnumerateReadOnlyList       | 100000 | 245,860.86 ns |  5,786.427 ns | 16,970.588 ns | 241,393.36 ns |  1.49 |    0.09 |      - |      40 B |        1.25 |
| EnumerateArraySegment       | 100000 | 208,624.98 ns |  4,445.240 ns | 12,682.520 ns | 205,204.97 ns |  1.32 |    0.10 |      - |      72 B |        2.25 |
| EnumerateLinkedList         | 100000 | 506,548.85 ns | 18,732.268 ns | 54,345.707 ns | 485,042.09 ns |  3.32 |    0.44 |      - |      48 B |        1.50 |
