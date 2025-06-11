# Testing if two sequences have at least one common element

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27876.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ListAnyListContains**         | **10**    |     **66.51 ns** |     **2.931 ns** |     **7.923 ns** |     **63.49 ns** |  **1.79** |    **0.34** | **0.0241** |      **-** |     **104 B** |        **2.60** |
| ListAnyHashSetContains      | 10    |     75.81 ns |     2.373 ns |     6.536 ns |     73.31 ns |  2.04 |    0.33 | 0.0241 |      - |     104 B |        2.60 |
| ListAnyFrozenSetContains    | 10    |     46.73 ns |     0.966 ns |     2.160 ns |     46.34 ns |  1.28 |    0.18 | 0.0241 |      - |     104 B |        2.60 |
| LinqIntersectListThenAny    | 10    |    271.39 ns |     5.469 ns |    10.405 ns |    269.27 ns |  7.83 |    0.77 | 0.1092 |      - |     472 B |       11.80 |
| HashSetOverlapsListMethod   | 10    |     59.53 ns |     1.218 ns |     1.583 ns |     59.91 ns |  1.74 |    0.12 | 0.0092 |      - |      40 B |        1.00 |
| FrozenSetOverlapsListMethod | 10    |     37.89 ns |     1.856 ns |     5.265 ns |     35.79 ns |  1.00 |    0.00 | 0.0092 |      - |      40 B |        1.00 |
|                             |       |              |              |              |              |       |         |        |        |           |             |
| **ListAnyListContains**         | **1000**  | **52,511.76 ns** | **1,040.157 ns** | **2,410.722 ns** | **52,338.76 ns** | **18.47** |    **1.30** |      **-** |      **-** |     **104 B** |        **2.60** |
| ListAnyHashSetContains      | 1000  |  4,450.78 ns |    87.630 ns |   143.979 ns |  4,392.39 ns |  1.58 |    0.12 | 0.0229 |      - |     104 B |        2.60 |
| ListAnyFrozenSetContains    | 1000  |  3,186.96 ns |    63.180 ns |   131.881 ns |  3,138.62 ns |  1.12 |    0.08 | 0.0229 |      - |     104 B |        2.60 |
| LinqIntersectListThenAny    | 1000  | 15,159.71 ns |   296.629 ns |   247.699 ns | 15,173.69 ns |  5.37 |    0.32 | 4.1351 | 0.2289 |   17944 B |      448.60 |
| HashSetOverlapsListMethod   | 1000  |  3,436.33 ns |    89.763 ns |   253.179 ns |  3,398.03 ns |  1.21 |    0.12 | 0.0076 |      - |      40 B |        1.00 |
| FrozenSetOverlapsListMethod | 1000  |  2,847.79 ns |    64.218 ns |   180.074 ns |  2,810.77 ns |  1.00 |    0.00 | 0.0076 |      - |      40 B |        1.00 |
