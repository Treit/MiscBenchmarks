# MaxBy() vs. OrderByDescending().First()






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                      | Count  | Mean            | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------------- |------- |----------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **MaxBy**                                       | **100**    |        **238.9 ns** |      **3.20 ns** |      **2.99 ns** |  **1.00** |    **0.02** |   **0.0024** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | 100    |        280.2 ns |      2.12 ns |      1.88 ns |  1.17 |    0.02 |   0.0076 |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | 100    |      1,756.9 ns |     17.36 ns |     16.23 ns |  7.35 |    0.11 |   0.1621 |        - |        - |    2736 B |       68.40 |
| SuperLinqPartialSortByDescendingFirst       | 100    |        759.4 ns |      3.92 ns |      3.27 ns |  3.18 |    0.04 |   0.0420 |        - |        - |     704 B |       17.60 |
|                                             |        |                 |              |              |       |         |          |          |          |           |             |
| **MaxBy**                                       | **100000** |    **387,211.5 ns** |  **1,853.93 ns** |  **1,734.17 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | 100000 |    375,023.9 ns |  2,285.40 ns |  2,137.77 ns |  0.97 |    0.01 |        - |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | 100000 | 10,946,519.7 ns | 79,447.34 ns | 74,315.09 ns | 28.27 |    0.22 | 187.5000 | 187.5000 | 187.5000 | 2401865 B |   60,046.62 |
| SuperLinqPartialSortByDescendingFirst       | 100000 |    765,930.7 ns |  6,127.51 ns |  5,731.67 ns |  1.98 |    0.02 |        - |        - |        - |    1136 B |       28.40 |
