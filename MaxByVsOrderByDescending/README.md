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
| **MaxBy**                                       | **100**    |        **240.0 ns** |      **2.47 ns** |      **2.19 ns** |  **1.00** |    **0.01** |   **0.0024** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | 100    |        283.5 ns |      3.88 ns |      3.63 ns |  1.18 |    0.02 |   0.0076 |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | 100    |      1,677.4 ns |     15.81 ns |     13.20 ns |  6.99 |    0.08 |   0.1621 |        - |        - |    2736 B |       68.40 |
| SuperLinqPartialSortByDescendingFirst       | 100    |        761.5 ns |      9.09 ns |      8.51 ns |  3.17 |    0.04 |   0.0420 |        - |        - |     704 B |       17.60 |
|                                             |        |                 |              |              |       |         |          |          |          |           |             |
| **MaxBy**                                       | **100000** |    **375,415.0 ns** |  **1,875.27 ns** |  **1,662.38 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
| OrderByDescendingFirst                      | 100000 |    371,546.5 ns |  3,375.71 ns |  3,157.65 ns |  0.99 |    0.01 |        - |        - |        - |     128 B |        3.20 |
| OrderByDescendingFirstWithUnnecessaryToList | 100000 | 11,277,527.2 ns | 64,903.72 ns | 57,535.46 ns | 30.04 |    0.20 | 187.5000 | 187.5000 | 187.5000 | 2401806 B |   60,045.15 |
| SuperLinqPartialSortByDescendingFirst       | 100000 |    741,565.4 ns |  4,764.56 ns |  4,223.66 ns |  1.98 |    0.01 |        - |        - |        - |    1136 B |       28.40 |
