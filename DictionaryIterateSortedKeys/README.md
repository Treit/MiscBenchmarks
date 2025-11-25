# Adding items to a dictionary




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **IterateSortedKeysWithLINQOrderBy**    | **10**    |   **1.121 μs** | **0.0127 μs** | **0.0112 μs** |  **1.00** |    **0.01** | **0.0305** |     **512 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | 10    |   1.459 μs | 0.0138 μs | 0.0129 μs |  1.30 |    0.02 | 0.0076 |     136 B |        0.27 |
| IterateSortedKeysWithOrder          | 10    |   1.295 μs | 0.0153 μs | 0.0128 μs |  1.16 |    0.02 | 0.0229 |     408 B |        0.80 |
| IterateSortedKeysOriginal           | 10    |   1.640 μs | 0.0086 μs | 0.0072 μs |  1.46 |    0.02 | 0.0706 |    1200 B |        2.34 |
|                                     |       |            |           |           |       |         |        |           |             |
| **IterateSortedKeysWithLINQOrderBy**    | **1000**  | **471.657 μs** | **4.6147 μs** | **4.0908 μs** |  **1.00** |    **0.01** | **0.9766** |   **20312 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | 1000  | 532.136 μs | 7.9737 μs | 7.4586 μs |  1.13 |    0.02 |      - |    8056 B |        0.40 |
| IterateSortedKeysWithOrder          | 1000  | 506.930 μs | 5.6998 μs | 5.3316 μs |  1.07 |    0.01 |      - |   12288 B |        0.60 |
| IterateSortedKeysOriginal           | 1000  | 536.806 μs | 6.1654 μs | 5.7671 μs |  1.14 |    0.02 | 3.9063 |   67416 B |        3.32 |
