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
| **IterateSortedKeysWithLINQOrderBy**    | **10**    |   **1.130 μs** | **0.0140 μs** | **0.0131 μs** |  **1.00** |    **0.02** | **0.0305** |     **512 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | 10    |   1.451 μs | 0.0107 μs | 0.0089 μs |  1.28 |    0.02 | 0.0076 |     136 B |        0.27 |
| IterateSortedKeysWithOrder          | 10    |   1.091 μs | 0.0110 μs | 0.0102 μs |  0.97 |    0.01 | 0.0229 |     408 B |        0.80 |
| IterateSortedKeysOriginal           | 10    |   1.485 μs | 0.0165 μs | 0.0146 μs |  1.31 |    0.02 | 0.0706 |    1200 B |        2.34 |
|                                     |       |            |           |           |       |         |        |           |             |
| **IterateSortedKeysWithLINQOrderBy**    | **1000**  | **477.944 μs** | **4.9502 μs** | **4.1336 μs** |  **1.00** |    **0.01** | **0.9766** |   **20312 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | 1000  | 526.477 μs | 7.2014 μs | 6.7362 μs |  1.10 |    0.02 |      - |    8056 B |        0.40 |
| IterateSortedKeysWithOrder          | 1000  | 505.680 μs | 4.2064 μs | 3.7288 μs |  1.06 |    0.01 |      - |   12288 B |        0.60 |
| IterateSortedKeysOriginal           | 1000  | 519.234 μs | 5.2984 μs | 4.9561 μs |  1.09 |    0.01 | 3.9063 |   67416 B |        3.32 |
