# Regex parsing vs string.Split, as well as other techniques like using Span<T>.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Count  | Mean             | Error           | StdDev          | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|---------------------------------- |------- |-----------------:|----------------:|----------------:|------:|--------:|----------:|-----------:|------------:|
| **FindTokenUsingSplit**               | **10**     |       **2,030.1 ns** |        **22.57 ns** |        **20.00 ns** |  **1.00** |    **0.01** |    **0.2480** |     **4200 B** |        **1.00** |
| FindTokenUsingRegex               | 10     |      38,354.4 ns |       368.09 ns |       344.31 ns | 18.89 |    0.24 |    0.1221 |     2792 B |        0.66 |
| FindTokenUsingCompiledRegex       | 10     |       9,367.3 ns |       136.16 ns |       127.37 ns |  4.61 |    0.07 |    0.1526 |     2792 B |        0.66 |
| FindTokenUsingSpan                | 10     |         182.2 ns |         2.32 ns |         1.94 ns |  0.09 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 10     |         426.0 ns |         1.39 ns |         1.30 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 10     |         442.9 ns |         1.02 ns |         0.85 ns |  0.22 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **100**    |      **20,451.8 ns** |       **199.82 ns** |       **166.86 ns** |  **1.00** |    **0.01** |    **2.7466** |    **45960 B** |        **1.00** |
| FindTokenUsingRegex               | 100    |     402,772.2 ns |     2,077.66 ns |     1,734.94 ns | 19.69 |    0.18 |    1.4648 |    27992 B |        0.61 |
| FindTokenUsingCompiledRegex       | 100    |      93,653.3 ns |       638.36 ns |       533.06 ns |  4.58 |    0.04 |    1.5869 |    27992 B |        0.61 |
| FindTokenUsingSpan                | 100    |       1,671.1 ns |         9.74 ns |         9.11 ns |  0.08 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 100    |       4,265.5 ns |        28.40 ns |        25.18 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 100    |       4,526.1 ns |        42.59 ns |        37.76 ns |  0.22 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **1000**   |     **207,344.0 ns** |     **1,620.17 ns** |     **1,352.92 ns** |  **1.00** |    **0.01** |   **27.5879** |   **463560 B** |        **1.00** |
| FindTokenUsingRegex               | 1000   |   5,045,259.9 ns |    28,661.57 ns |    23,933.71 ns | 24.33 |    0.19 |   15.6250 |   279996 B |        0.60 |
| FindTokenUsingCompiledRegex       | 1000   |     995,100.5 ns |    12,227.40 ns |    11,437.52 ns |  4.80 |    0.06 |   15.6250 |   279995 B |        0.60 |
| FindTokenUsingSpan                | 1000   |      22,528.4 ns |       202.11 ns |       189.05 ns |  0.11 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 1000   |      38,885.5 ns |       202.89 ns |       189.78 ns |  0.19 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 1000   |      41,448.7 ns |       167.92 ns |       157.07 ns |  0.20 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **100000** |  **21,015,156.0 ns** |   **232,015.38 ns** |   **217,027.33 ns** |  **1.00** |    **0.01** | **2750.0000** | **46400000 B** |        **1.00** |
| FindTokenUsingRegex               | 100000 | 835,622,100.0 ns | 4,442,976.78 ns | 3,938,583.19 ns | 39.77 |    0.44 | 1000.0000 | 28000448 B |        0.60 |
| FindTokenUsingCompiledRegex       | 100000 | 103,404,116.0 ns | 1,567,313.26 ns | 1,466,065.79 ns |  4.92 |    0.08 | 1600.0000 | 28000410 B |        0.60 |
| FindTokenUsingSpan                | 100000 |   3,189,313.8 ns |    22,752.79 ns |    21,282.98 ns |  0.15 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 100000 |   3,557,214.6 ns |    10,771.14 ns |    10,075.33 ns |  0.17 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 100000 |   3,798,488.2 ns |    10,101.46 ns |     9,448.91 ns |  0.18 |    0.00 |         - |          - |        0.00 |
