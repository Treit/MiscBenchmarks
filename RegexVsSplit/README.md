# Regex parsing vs string.Split, as well as other techniques like using Span<T>.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Count  | Mean             | Error           | StdDev          | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|---------------------------------- |---------- |---------- |------- |-----------------:|----------------:|----------------:|------:|--------:|----------:|-----------:|------------:|
| **FindTokenUsingSplit**               | **.NET 10.0** | **.NET 10.0** | **10**     |       **2,050.3 ns** |        **25.27 ns** |        **21.10 ns** |  **1.00** |    **0.01** |    **0.2480** |     **4200 B** |        **1.00** |
| FindTokenUsingRegex               | .NET 10.0 | .NET 10.0 | 10     |      38,620.2 ns |       339.79 ns |       301.22 ns | 18.84 |    0.24 |    0.1221 |     2792 B |        0.66 |
| FindTokenUsingCompiledRegex       | .NET 10.0 | .NET 10.0 | 10     |       9,311.7 ns |        60.14 ns |        50.22 ns |  4.54 |    0.05 |    0.1526 |     2792 B |        0.66 |
| FindTokenUsingSpan                | .NET 10.0 | .NET 10.0 | 10     |         175.0 ns |         3.48 ns |         5.09 ns |  0.09 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 10.0 | .NET 10.0 | 10     |         421.0 ns |         0.91 ns |         0.81 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 10.0 | .NET 10.0 | 10     |         440.2 ns |         1.67 ns |         1.48 ns |  0.21 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| FindTokenUsingSplit               | .NET 9.0  | .NET 9.0  | 10     |       2,001.8 ns |        16.41 ns |        13.71 ns |  1.00 |    0.01 |    0.2480 |     4200 B |        1.00 |
| FindTokenUsingRegex               | .NET 9.0  | .NET 9.0  | 10     |      38,448.8 ns |       287.47 ns |       268.90 ns | 19.21 |    0.18 |    0.1221 |     2792 B |        0.66 |
| FindTokenUsingCompiledRegex       | .NET 9.0  | .NET 9.0  | 10     |       9,363.3 ns |        70.46 ns |        65.90 ns |  4.68 |    0.04 |    0.1526 |     2792 B |        0.66 |
| FindTokenUsingSpan                | .NET 9.0  | .NET 9.0  | 10     |         151.5 ns |         2.31 ns |         1.93 ns |  0.08 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 9.0  | .NET 9.0  | 10     |         420.4 ns |         0.35 ns |         0.33 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 9.0  | .NET 9.0  | 10     |         436.7 ns |         0.60 ns |         0.53 ns |  0.22 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **.NET 10.0** | **.NET 10.0** | **100**    |      **20,258.0 ns** |       **130.95 ns** |       **122.49 ns** |  **1.00** |    **0.01** |    **2.7466** |    **45960 B** |        **1.00** |
| FindTokenUsingRegex               | .NET 10.0 | .NET 10.0 | 100    |     400,835.1 ns |     1,955.28 ns |     1,828.97 ns | 19.79 |    0.15 |    1.4648 |    27992 B |        0.61 |
| FindTokenUsingCompiledRegex       | .NET 10.0 | .NET 10.0 | 100    |      93,217.4 ns |       535.05 ns |       474.31 ns |  4.60 |    0.04 |    1.5869 |    27992 B |        0.61 |
| FindTokenUsingSpan                | .NET 10.0 | .NET 10.0 | 100    |       1,661.1 ns |        10.91 ns |        10.21 ns |  0.08 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 10.0 | .NET 10.0 | 100    |       4,263.1 ns |        14.03 ns |        13.12 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 10.0 | .NET 10.0 | 100    |       4,530.0 ns |        10.26 ns |         9.09 ns |  0.22 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| FindTokenUsingSplit               | .NET 9.0  | .NET 9.0  | 100    |      20,231.3 ns |       155.34 ns |       145.30 ns |  1.00 |    0.01 |    2.7466 |    45960 B |        1.00 |
| FindTokenUsingRegex               | .NET 9.0  | .NET 9.0  | 100    |     407,135.3 ns |     1,305.80 ns |     1,221.45 ns | 20.13 |    0.15 |    1.4648 |    27992 B |        0.61 |
| FindTokenUsingCompiledRegex       | .NET 9.0  | .NET 9.0  | 100    |      93,307.8 ns |       535.67 ns |       501.06 ns |  4.61 |    0.04 |    1.5869 |    27992 B |        0.61 |
| FindTokenUsingSpan                | .NET 9.0  | .NET 9.0  | 100    |       1,702.2 ns |        33.36 ns |        31.21 ns |  0.08 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 9.0  | .NET 9.0  | 100    |       4,228.7 ns |         7.19 ns |         6.73 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 9.0  | .NET 9.0  | 100    |       4,479.5 ns |         8.95 ns |         7.94 ns |  0.22 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **.NET 10.0** | **.NET 10.0** | **1000**   |     **203,008.2 ns** |     **1,102.75 ns** |     **1,031.51 ns** |  **1.00** |    **0.01** |   **27.5879** |   **463560 B** |        **1.00** |
| FindTokenUsingRegex               | .NET 10.0 | .NET 10.0 | 1000   |   5,030,185.3 ns |    36,721.16 ns |    34,349.00 ns | 24.78 |    0.20 |   15.6250 |   279996 B |        0.60 |
| FindTokenUsingCompiledRegex       | .NET 10.0 | .NET 10.0 | 1000   |   1,001,453.4 ns |     5,759.67 ns |     4,809.59 ns |  4.93 |    0.03 |   15.6250 |   279995 B |        0.60 |
| FindTokenUsingSpan                | .NET 10.0 | .NET 10.0 | 1000   |      25,870.8 ns |       324.33 ns |       287.51 ns |  0.13 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 10.0 | .NET 10.0 | 1000   |      38,742.9 ns |        93.71 ns |        87.65 ns |  0.19 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 10.0 | .NET 10.0 | 1000   |      41,132.0 ns |        72.04 ns |        67.39 ns |  0.20 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| FindTokenUsingSplit               | .NET 9.0  | .NET 9.0  | 1000   |     203,702.0 ns |     1,638.28 ns |     1,532.45 ns |  1.00 |    0.01 |   27.5879 |   463560 B |        1.00 |
| FindTokenUsingRegex               | .NET 9.0  | .NET 9.0  | 1000   |   5,101,125.4 ns |    32,268.31 ns |    30,183.80 ns | 25.04 |    0.23 |   15.6250 |   279996 B |        0.60 |
| FindTokenUsingCompiledRegex       | .NET 9.0  | .NET 9.0  | 1000   |     985,256.0 ns |     8,094.99 ns |     7,572.06 ns |  4.84 |    0.05 |   15.6250 |   279995 B |        0.60 |
| FindTokenUsingSpan                | .NET 9.0  | .NET 9.0  | 1000   |      25,549.3 ns |       260.83 ns |       243.98 ns |  0.13 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 9.0  | .NET 9.0  | 1000   |      38,678.7 ns |        39.23 ns |        32.76 ns |  0.19 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 9.0  | .NET 9.0  | 1000   |      40,957.3 ns |        58.67 ns |        54.88 ns |  0.20 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **.NET 10.0** | **.NET 10.0** | **100000** |  **20,334,110.8 ns** |   **126,532.10 ns** |   **118,358.21 ns** |  **1.00** |    **0.01** | **2750.0000** | **46400000 B** |        **1.00** |
| FindTokenUsingRegex               | .NET 10.0 | .NET 10.0 | 100000 | 816,805,753.8 ns | 3,874,283.31 ns | 3,235,202.03 ns | 40.17 |    0.27 | 1000.0000 | 28000448 B |        0.60 |
| FindTokenUsingCompiledRegex       | .NET 10.0 | .NET 10.0 | 100000 | 101,317,538.7 ns |   550,898.99 ns |   515,311.25 ns |  4.98 |    0.04 | 1600.0000 | 28000410 B |        0.60 |
| FindTokenUsingSpan                | .NET 10.0 | .NET 10.0 | 100000 |   3,633,481.0 ns |    32,858.05 ns |    29,127.81 ns |  0.18 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 10.0 | .NET 10.0 | 100000 |   3,529,357.5 ns |     4,393.39 ns |     3,668.68 ns |  0.17 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 10.0 | .NET 10.0 | 100000 |   3,762,125.1 ns |     2,846.40 ns |     2,376.87 ns |  0.19 |    0.00 |         - |          - |        0.00 |
|                                   |           |           |        |                  |                 |                 |       |         |           |            |             |
| FindTokenUsingSplit               | .NET 9.0  | .NET 9.0  | 100000 |  20,560,263.5 ns |   129,731.75 ns |   121,351.16 ns |  1.00 |    0.01 | 2750.0000 | 46400000 B |        1.00 |
| FindTokenUsingRegex               | .NET 9.0  | .NET 9.0  | 100000 | 829,595,376.9 ns | 1,736,819.85 ns | 1,450,323.24 ns | 40.35 |    0.24 | 1000.0000 | 28000448 B |        0.60 |
| FindTokenUsingCompiledRegex       | .NET 9.0  | .NET 9.0  | 100000 | 103,437,640.0 ns |   621,135.29 ns |   581,010.33 ns |  5.03 |    0.04 | 1600.0000 | 28000410 B |        0.60 |
| FindTokenUsingSpan                | .NET 9.0  | .NET 9.0  | 100000 |   3,122,295.9 ns |    22,513.25 ns |    21,058.91 ns |  0.15 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | .NET 9.0  | .NET 9.0  | 100000 |   3,525,313.5 ns |     2,537.80 ns |     2,119.18 ns |  0.17 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | .NET 9.0  | .NET 9.0  | 100000 |   3,769,664.8 ns |     8,327.32 ns |     7,789.38 ns |  0.18 |    0.00 |         - |          - |        0.00 |
