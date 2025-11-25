# Testing if two sequences have at least one common element


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ListAnyListContains**         | **10**    |     **18.75 ns** |   **0.099 ns** |   **0.092 ns** |     **18.78 ns** |  **1.45** |    **0.01** |      **-** |      **-** |         **-** |          **NA** |
| ListAnyHashSetContains      | 10    |     19.61 ns |   0.425 ns |   0.788 ns |     19.62 ns |  1.51 |    0.06 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | 10    |     10.27 ns |   0.235 ns |   0.647 ns |     10.07 ns |  0.79 |    0.05 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | 10    |    197.50 ns |   1.304 ns |   1.219 ns |    197.66 ns | 15.25 |    0.10 | 0.0257 |      - |     432 B |          NA |
| HashSetOverlapsListMethod   | 10    |     24.31 ns |   0.117 ns |   0.109 ns |     24.31 ns |  1.88 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | 10    |     12.95 ns |   0.038 ns |   0.036 ns |     12.94 ns |  1.00 |    0.00 |      - |      - |         - |          NA |
|                             |       |              |            |            |              |       |         |        |        |           |             |
| **ListAnyListContains**         | **1000**  | **42,613.28 ns** | **154.853 ns** | **120.899 ns** | **42,636.25 ns** | **31.00** |    **0.18** |      **-** |      **-** |         **-** |          **NA** |
| ListAnyHashSetContains      | 1000  |  1,528.32 ns |   6.030 ns |   5.640 ns |  1,531.19 ns |  1.11 |    0.01 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | 1000  |  1,201.53 ns |   8.717 ns |   8.154 ns |  1,202.47 ns |  0.87 |    0.01 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | 1000  | 11,732.21 ns |  74.561 ns |  69.745 ns | 11,742.48 ns |  8.53 |    0.07 | 1.0681 | 0.0610 |   17904 B |          NA |
| HashSetOverlapsListMethod   | 1000  |  1,766.21 ns |  10.181 ns |   9.025 ns |  1,762.61 ns |  1.28 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | 1000  |  1,374.83 ns |   7.582 ns |   7.092 ns |  1,376.23 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
