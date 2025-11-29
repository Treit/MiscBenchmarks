# MaxBy() vs. OrderByDescending().First()







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Job       | Runtime   | Count  | Mean            | Error         | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------------- |---------- |---------- |------- |----------------:|--------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **MaxBy**                                       | **.NET 10.0** | **.NET 10.0** | **100**    |        **236.7 ns** |       **0.78 ns** |      **0.70 ns** |  **1.00** |    **0.00** |   **0.0024** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | .NET 10.0 | .NET 10.0 | 100    |        279.2 ns |       0.85 ns |      0.76 ns |  1.18 |    0.00 |   0.0076 |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | .NET 10.0 | .NET 10.0 | 100    |      1,739.2 ns |       8.70 ns |      8.14 ns |  7.35 |    0.04 |   0.1621 |        - |        - |    2736 B |       68.40 |
| SuperLinqPartialSortByDescendingFirst       | .NET 10.0 | .NET 10.0 | 100    |        747.6 ns |       4.85 ns |      4.54 ns |  3.16 |    0.02 |   0.0420 |        - |        - |     704 B |       17.60 |
|                                             |           |           |        |                 |               |              |       |         |          |          |          |           |             |
| MaxBy                                       | .NET 9.0  | .NET 9.0  | 100    |        237.2 ns |       1.53 ns |      1.36 ns |  1.00 |    0.01 |   0.0024 |        - |        - |      40 B |        1.00 |
| OrderByDescendingFirst                      | .NET 9.0  | .NET 9.0  | 100    |        279.6 ns |       1.62 ns |      1.51 ns |  1.18 |    0.01 |   0.0076 |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | .NET 9.0  | .NET 9.0  | 100    |      1,679.5 ns |      13.08 ns |     12.24 ns |  7.08 |    0.06 |   0.1621 |        - |        - |    2736 B |       68.40 |
| SuperLinqPartialSortByDescendingFirst       | .NET 9.0  | .NET 9.0  | 100    |        758.2 ns |       5.43 ns |      4.54 ns |  3.20 |    0.03 |   0.0420 |        - |        - |     704 B |       17.60 |
|                                             |           |           |        |                 |               |              |       |         |          |          |          |           |             |
| **MaxBy**                                       | **.NET 10.0** | **.NET 10.0** | **100000** |    **385,949.7 ns** |   **1,826.64 ns** |  **1,708.64 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | .NET 10.0 | .NET 10.0 | 100000 |    364,084.0 ns |     705.92 ns |    589.48 ns |  0.94 |    0.00 |        - |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | .NET 10.0 | .NET 10.0 | 100000 | 10,638,262.3 ns |  46,728.10 ns | 39,020.08 ns | 27.56 |    0.15 | 187.5000 | 187.5000 | 187.5000 | 2401803 B |   60,045.07 |
| SuperLinqPartialSortByDescendingFirst       | .NET 10.0 | .NET 10.0 | 100000 |    737,433.4 ns |   5,127.27 ns |  4,796.05 ns |  1.91 |    0.01 |        - |        - |        - |    1136 B |       28.40 |
|                                             |           |           |        |                 |               |              |       |         |          |          |          |           |             |
| MaxBy                                       | .NET 9.0  | .NET 9.0  | 100000 |    381,795.6 ns |     681.58 ns |    604.21 ns |  1.00 |    0.00 |        - |        - |        - |      40 B |        1.00 |
| OrderByDescendingFirst                      | .NET 9.0  | .NET 9.0  | 100000 |    373,999.8 ns |   3,335.92 ns |  3,120.42 ns |  0.98 |    0.01 |        - |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | .NET 9.0  | .NET 9.0  | 100000 | 10,600,561.1 ns | 101,255.66 ns | 94,714.61 ns | 27.77 |    0.24 | 187.5000 | 187.5000 | 187.5000 | 2401758 B |   60,043.95 |
| SuperLinqPartialSortByDescendingFirst       | .NET 9.0  | .NET 9.0  | 100000 |    743,774.3 ns |   4,959.32 ns |  4,396.31 ns |  1.95 |    0.01 |        - |        - |        - |    1136 B |       28.40 |
