# Testing if two sequences have at least one common element



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ListAnyListContains**         | **10**    |     **18.74 ns** |   **0.261 ns** |   **0.231 ns** |  **1.45** |    **0.02** |      **-** |      **-** |         **-** |          **NA** |
| ListAnyHashSetContains      | 10    |     19.42 ns |   0.097 ns |   0.091 ns |  1.51 |    0.01 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | 10    |     10.20 ns |   0.072 ns |   0.068 ns |  0.79 |    0.01 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | 10    |    194.35 ns |   1.010 ns |   0.895 ns | 15.08 |    0.08 | 0.0257 |      - |     432 B |          NA |
| HashSetOverlapsListMethod   | 10    |     24.73 ns |   0.074 ns |   0.070 ns |  1.92 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | 10    |     12.89 ns |   0.038 ns |   0.036 ns |  1.00 |    0.00 |      - |      - |         - |          NA |
|                             |       |              |            |            |       |         |        |        |           |             |
| **ListAnyListContains**         | **1000**  | **42,834.84 ns** | **270.061 ns** | **252.615 ns** | **31.05** |    **0.21** |      **-** |      **-** |         **-** |          **NA** |
| ListAnyHashSetContains      | 1000  |  1,537.95 ns |   7.099 ns |   6.640 ns |  1.11 |    0.01 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | 1000  |  1,207.96 ns |   8.089 ns |   7.566 ns |  0.88 |    0.01 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | 1000  | 11,912.65 ns | 104.638 ns |  97.878 ns |  8.64 |    0.08 | 1.0681 | 0.0610 |   17904 B |          NA |
| HashSetOverlapsListMethod   | 1000  |  1,776.29 ns |  11.858 ns |   9.902 ns |  1.29 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | 1000  |  1,379.37 ns |   5.938 ns |   5.264 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
