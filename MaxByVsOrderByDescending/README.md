# MaxBy() vs. OrderByDescending().First()




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                      | Count  | Mean           | Error         | StdDev        | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------------- |------- |---------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **MaxBy**                                       | **100**    |       **452.9 ns** |       **8.94 ns** |       **6.98 ns** |  **1.00** |    **0.00** |   **0.0029** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | 100    |       667.3 ns |      10.06 ns |       8.92 ns |  1.47 |    0.03 |   0.0105 |        - |        - |     136 B |        3.40 |
| OrderByDescendingFirstWithUnnecessaryToList | 100    |     1,435.5 ns |      28.29 ns |      44.87 ns |  3.22 |    0.11 |   0.2155 |        - |        - |    2704 B |       67.60 |
| SuperLinqPartialSortByDescendingFirst       | 100    |       697.9 ns |      13.80 ns |      12.90 ns |  1.55 |    0.04 |   0.0553 |        - |        - |     704 B |       17.60 |
|                                             |        |                |               |               |       |         |          |          |          |           |             |
| **MaxBy**                                       | **100000** |   **443,173.0 ns** |   **8,133.31 ns** |  **13,363.27 ns** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | 100000 |   579,079.1 ns |  11,057.73 ns |  10,860.17 ns |  1.29 |    0.05 |        - |        - |        - |     136 B |        3.40 |
| OrderByDescendingFirstWithUnnecessaryToList | 100000 | 9,080,208.5 ns | 176,316.74 ns | 188,656.94 ns | 20.20 |    0.76 | 187.5000 | 187.5000 | 187.5000 | 2401784 B |   60,044.60 |
| SuperLinqPartialSortByDescendingFirst       | 100000 |   547,413.8 ns |  10,820.89 ns |  13,289.02 ns |  1.23 |    0.05 |        - |        - |        - |    1136 B |       28.40 |
