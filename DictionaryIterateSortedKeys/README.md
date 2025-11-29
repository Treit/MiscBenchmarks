# Adding items to a dictionary






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |---------- |---------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **IterateSortedKeysWithLINQOrderBy**    | **.NET 10.0** | **.NET 10.0** | **10**    |   **1.120 μs** | **0.0198 μs** | **0.0175 μs** |  **1.00** |    **0.02** | **0.0305** |     **512 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | .NET 10.0 | .NET 10.0 | 10    |   1.241 μs | 0.0152 μs | 0.0135 μs |  1.11 |    0.02 | 0.0076 |     136 B |        0.27 |
| IterateSortedKeysWithOrder          | .NET 10.0 | .NET 10.0 | 10    |   1.103 μs | 0.0206 μs | 0.0192 μs |  0.98 |    0.02 | 0.0229 |     408 B |        0.80 |
| IterateSortedKeysOriginal           | .NET 10.0 | .NET 10.0 | 10    |   1.513 μs | 0.0090 μs | 0.0080 μs |  1.35 |    0.02 | 0.0706 |    1200 B |        2.34 |
|                                     |           |           |       |            |           |           |       |         |        |           |             |
| IterateSortedKeysWithLINQOrderBy    | .NET 9.0  | .NET 9.0  | 10    |   1.126 μs | 0.0121 μs | 0.0114 μs |  1.00 |    0.01 | 0.0305 |     512 B |        1.00 |
| IterateSortedKeysWithNewListAndSort | .NET 9.0  | .NET 9.0  | 10    |   1.243 μs | 0.0117 μs | 0.0098 μs |  1.10 |    0.01 | 0.0076 |     136 B |        0.27 |
| IterateSortedKeysWithOrder          | .NET 9.0  | .NET 9.0  | 10    |   1.109 μs | 0.0137 μs | 0.0128 μs |  0.98 |    0.01 | 0.0229 |     408 B |        0.80 |
| IterateSortedKeysOriginal           | .NET 9.0  | .NET 9.0  | 10    |   1.517 μs | 0.0126 μs | 0.0111 μs |  1.35 |    0.02 | 0.0706 |    1200 B |        2.34 |
|                                     |           |           |       |            |           |           |       |         |        |           |             |
| **IterateSortedKeysWithLINQOrderBy**    | **.NET 10.0** | **.NET 10.0** | **1000**  | **480.750 μs** | **6.3910 μs** | **5.9781 μs** |  **1.00** |    **0.02** | **0.9766** |   **20312 B** |        **1.00** |
| IterateSortedKeysWithNewListAndSort | .NET 10.0 | .NET 10.0 | 1000  | 555.378 μs | 4.3448 μs | 4.0641 μs |  1.16 |    0.02 |      - |    8056 B |        0.40 |
| IterateSortedKeysWithOrder          | .NET 10.0 | .NET 10.0 | 1000  | 477.126 μs | 3.2580 μs | 3.0475 μs |  0.99 |    0.01 | 0.4883 |   12288 B |        0.60 |
| IterateSortedKeysOriginal           | .NET 10.0 | .NET 10.0 | 1000  | 539.952 μs | 8.0761 μs | 7.5544 μs |  1.12 |    0.02 | 3.9063 |   67416 B |        3.32 |
|                                     |           |           |       |            |           |           |       |         |        |           |             |
| IterateSortedKeysWithLINQOrderBy    | .NET 9.0  | .NET 9.0  | 1000  | 475.432 μs | 1.9017 μs | 1.6858 μs |  1.00 |    0.00 | 0.9766 |   20312 B |        1.00 |
| IterateSortedKeysWithNewListAndSort | .NET 9.0  | .NET 9.0  | 1000  | 605.280 μs | 6.9088 μs | 6.4625 μs |  1.27 |    0.01 |      - |    8056 B |        0.40 |
| IterateSortedKeysWithOrder          | .NET 9.0  | .NET 9.0  | 1000  | 474.917 μs | 3.3942 μs | 3.1750 μs |  1.00 |    0.01 | 0.4883 |   12288 B |        0.60 |
| IterateSortedKeysOriginal           | .NET 9.0  | .NET 9.0  | 1000  | 553.111 μs | 9.3880 μs | 8.7816 μs |  1.16 |    0.02 | 3.9063 |   67416 B |        3.32 |
