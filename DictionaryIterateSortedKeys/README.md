# Adding items to a dictionary



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27818.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                              | Count | Mean       | Error      | StdDev     | Median     | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------------------ |------ |-----------:|-----------:|-----------:|-----------:|------:|--------:|--------:|-------:|----------:|------------:|
| **IterateSortedKeysWithLINQOrderBy**    | **10**    |   **1.988 μs** |  **0.0483 μs** |  **0.1369 μs** |   **1.945 μs** |  **1.00** |    **0.00** |  **0.1259** |      **-** |     **544 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | 10    |   1.924 μs |  0.0482 μs |  0.1384 μs |   1.891 μs |  0.97 |    0.10 |  0.0305 |      - |     136 B |        0.25 |
| IterateSortedKeysWithOrder          | 10    |   2.041 μs |  0.0583 μs |  0.1645 μs |   2.018 μs |  1.03 |    0.11 |  0.0992 |      - |     440 B |        0.81 |
| IterateSortedKeysOriginal           | 10    |   2.879 μs |  0.1411 μs |  0.3934 μs |   2.811 μs |  1.45 |    0.22 |  0.4120 |      - |    1784 B |        3.28 |
|                                     |       |            |            |            |            |       |         |         |        |           |             |
| **IterateSortedKeysWithLINQOrderBy**    | **1000**  | **754.671 μs** | **23.7445 μs** | **65.0003 μs** | **745.523 μs** |  **1.00** |    **0.00** |  **3.9063** |      **-** |   **20344 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | 1000  | 702.819 μs | 13.8587 μs | 31.8426 μs | 698.316 μs |  0.93 |    0.09 |  0.9766 |      - |    8056 B |        0.40 |
| IterateSortedKeysWithOrder          | 1000  | 666.847 μs | 12.4990 μs | 13.3738 μs | 666.234 μs |  0.86 |    0.06 |  1.9531 |      - |   12320 B |        0.61 |
| IterateSortedKeysOriginal           | 1000  | 734.572 μs | 14.5590 μs | 31.6501 μs | 723.993 μs |  0.97 |    0.08 | 31.2500 | 5.8594 |  138648 B |        6.82 |
