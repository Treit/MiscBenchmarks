# LINQ Where foreach vs for loop

Compares a filtered LINQ sequence followed by `foreach` against an indexed `for` loop with `continue`, matching this pattern:


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26200.8655)
AMD Ryzen 9 7940HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.203
  [Host]    : .NET 10.0.7 (10.0.726.21808), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 10.0 : .NET 10.0.7 (10.0.726.21808), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method                     | Count   | MatchPercent | Mean           | Error        | StdDev       | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |-------- |------------- |---------------:|-------------:|-------------:|------:|--------:|-------:|----------:|------------:|
| **LinqWhereThenForeach**       | **1000**    | **10**           |       **842.0 ns** |      **2.27 ns** |      **2.13 ns** |  **1.08** |    **0.00** | **0.0057** |      **48 B** |          **NA** |
| LinqWhereThenSum           | 1000    | 10           |       811.9 ns |      2.20 ns |      2.06 ns |  1.04 |    0.00 | 0.0057 |      48 B |          NA |
| ForLoopWithContinue        | 1000    | 10           |       779.5 ns |      1.24 ns |      1.04 ns |  1.00 |    0.00 |      - |         - |          NA |
| ForLoopWithInlineCondition | 1000    | 10           |       441.2 ns |      2.23 ns |      2.09 ns |  0.57 |    0.00 |      - |         - |          NA |
|                            |         |              |                |              |              |       |         |        |           |             |
| **LinqWhereThenForeach**       | **1000**    | **50**           |     **1,008.5 ns** |      **3.64 ns** |      **3.41 ns** |  **1.20** |    **0.00** | **0.0057** |      **48 B** |          **NA** |
| LinqWhereThenSum           | 1000    | 50           |     1,005.6 ns |      3.09 ns |      2.89 ns |  1.19 |    0.00 | 0.0057 |      48 B |          NA |
| ForLoopWithContinue        | 1000    | 50           |       841.9 ns |      2.20 ns |      2.06 ns |  1.00 |    0.00 |      - |         - |          NA |
| ForLoopWithInlineCondition | 1000    | 50           |       535.1 ns |      3.36 ns |      3.15 ns |  0.64 |    0.00 |      - |         - |          NA |
|                            |         |              |                |              |              |       |         |        |           |             |
| **LinqWhereThenForeach**       | **1000**    | **90**           |     **1,077.8 ns** |      **3.65 ns** |      **3.23 ns** |  **1.28** |    **0.03** | **0.0057** |      **48 B** |          **NA** |
| LinqWhereThenSum           | 1000    | 90           |     1,071.3 ns |      3.88 ns |      3.44 ns |  1.28 |    0.03 | 0.0057 |      48 B |          NA |
| ForLoopWithContinue        | 1000    | 90           |       840.1 ns |     16.69 ns |     21.11 ns |  1.00 |    0.04 |      - |         - |          NA |
| ForLoopWithInlineCondition | 1000    | 90           |       585.0 ns |     11.61 ns |     17.02 ns |  0.70 |    0.03 |      - |         - |          NA |
|                            |         |              |                |              |              |       |         |        |           |             |
| **LinqWhereThenForeach**       | **1000000** | **10**           |   **880,516.5 ns** | **16,832.45 ns** | **15,745.08 ns** |  **1.07** |    **0.03** |      **-** |      **48 B** |          **NA** |
| LinqWhereThenSum           | 1000000 | 10           |   878,315.8 ns | 16,853.00 ns | 20,062.30 ns |  1.06 |    0.03 |      - |      48 B |          NA |
| ForLoopWithContinue        | 1000000 | 10           |   825,616.2 ns | 15,511.85 ns | 15,234.71 ns |  1.00 |    0.03 |      - |         - |          NA |
| ForLoopWithInlineCondition | 1000000 | 10           |   493,411.4 ns |  9,799.40 ns | 12,393.10 ns |  0.60 |    0.02 |      - |         - |          NA |
|                            |         |              |                |              |              |       |         |        |           |             |
| **LinqWhereThenForeach**       | **1000000** | **50**           | **1,014,395.5 ns** | **19,567.08 ns** | **20,093.95 ns** |  **1.33** |    **0.03** |      **-** |      **48 B** |          **NA** |
| LinqWhereThenSum           | 1000000 | 50           | 1,041,013.7 ns | 20,072.43 ns | 25,385.20 ns |  1.36 |    0.04 |      - |      48 B |          NA |
| ForLoopWithContinue        | 1000000 | 50           |   762,851.3 ns | 13,509.08 ns | 12,636.40 ns |  1.00 |    0.02 |      - |         - |          NA |
| ForLoopWithInlineCondition | 1000000 | 50           |   510,417.5 ns |  8,245.32 ns |  7,712.67 ns |  0.67 |    0.01 |      - |         - |          NA |
|                            |         |              |                |              |              |       |         |        |           |             |
| **LinqWhereThenForeach**       | **1000000** | **90**           | **1,117,353.9 ns** | **21,138.14 ns** | **22,617.57 ns** |  **1.45** |    **0.04** |      **-** |      **48 B** |          **NA** |
| LinqWhereThenSum           | 1000000 | 90           | 1,112,278.4 ns | 21,765.08 ns | 26,729.47 ns |  1.44 |    0.04 |      - |      48 B |          NA |
| ForLoopWithContinue        | 1000000 | 90           |   772,327.4 ns | 14,786.87 ns | 14,522.69 ns |  1.00 |    0.03 |      - |         - |          NA |
| ForLoopWithInlineCondition | 1000000 | 90           |   505,310.4 ns |  9,993.20 ns | 11,896.19 ns |  0.65 |    0.02 |      - |         - |          NA |
