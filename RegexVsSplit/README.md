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
| **FindTokenUsingSplit**               | **10**     |       **2,042.3 ns** |        **39.66 ns** |        **37.10 ns** |  **1.00** |    **0.02** |    **0.2480** |     **4200 B** |        **1.00** |
| FindTokenUsingRegex               | 10     |      38,254.2 ns |       226.78 ns |       212.13 ns | 18.74 |    0.34 |    0.1221 |     2792 B |        0.66 |
| FindTokenUsingCompiledRegex       | 10     |       9,414.1 ns |        89.29 ns |        83.52 ns |  4.61 |    0.09 |    0.1526 |     2792 B |        0.66 |
| FindTokenUsingSpan                | 10     |         170.1 ns |         1.95 ns |         2.39 ns |  0.08 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 10     |         423.0 ns |         1.67 ns |         1.56 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 10     |         471.0 ns |         1.26 ns |         1.12 ns |  0.23 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **100**    |      **20,652.5 ns** |       **209.19 ns** |       **185.44 ns** |  **1.00** |    **0.01** |    **2.7466** |    **45960 B** |        **1.00** |
| FindTokenUsingRegex               | 100    |     402,363.9 ns |     2,315.63 ns |     2,166.05 ns | 19.48 |    0.20 |    1.4648 |    27992 B |        0.61 |
| FindTokenUsingCompiledRegex       | 100    |      94,616.8 ns |       654.90 ns |       612.59 ns |  4.58 |    0.05 |    1.5869 |    27992 B |        0.61 |
| FindTokenUsingSpan                | 100    |       1,664.8 ns |        20.41 ns |        18.09 ns |  0.08 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 100    |       4,253.2 ns |        27.40 ns |        25.63 ns |  0.21 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 100    |       4,499.6 ns |        31.11 ns |        29.10 ns |  0.22 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **1000**   |     **208,888.5 ns** |     **1,473.41 ns** |     **1,230.37 ns** |  **1.00** |    **0.01** |   **27.5879** |   **463560 B** |        **1.00** |
| FindTokenUsingRegex               | 1000   |   5,068,202.3 ns |    44,568.71 ns |    41,689.60 ns | 24.26 |    0.24 |   15.6250 |   279996 B |        0.60 |
| FindTokenUsingCompiledRegex       | 1000   |   1,020,173.6 ns |     7,261.97 ns |     6,792.85 ns |  4.88 |    0.04 |   15.6250 |   279995 B |        0.60 |
| FindTokenUsingSpan                | 1000   |      22,623.9 ns |       261.58 ns |       244.68 ns |  0.11 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 1000   |      38,977.7 ns |       214.46 ns |       200.60 ns |  0.19 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 1000   |      41,072.3 ns |       218.30 ns |       204.20 ns |  0.20 |    0.00 |         - |          - |        0.00 |
|                                   |        |                  |                 |                 |       |         |           |            |             |
| **FindTokenUsingSplit**               | **100000** |  **21,053,274.9 ns** |   **237,941.75 ns** |   **222,570.86 ns** |  **1.00** |    **0.01** | **2750.0000** | **46400000 B** |        **1.00** |
| FindTokenUsingRegex               | 100000 | 835,630,921.4 ns | 3,653,709.51 ns | 3,238,918.32 ns | 39.70 |    0.43 | 1000.0000 | 28000448 B |        0.60 |
| FindTokenUsingCompiledRegex       | 100000 | 102,785,512.0 ns |   753,687.33 ns |   704,999.60 ns |  4.88 |    0.06 | 1600.0000 | 28000410 B |        0.60 |
| FindTokenUsingSpan                | 100000 |   3,205,986.9 ns |    15,659.16 ns |    14,647.59 ns |  0.15 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenize            | 100000 |   3,552,420.5 ns |     8,912.06 ns |     7,441.97 ns |  0.17 |    0.00 |         - |          - |        0.00 |
| FindTokenUsingTokenizeWithForEach | 100000 |   3,788,801.7 ns |     7,446.16 ns |     6,600.83 ns |  0.18 |    0.00 |         - |          - |        0.00 |
