# Deduplicating a comma delimited string




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Job       | Runtime   | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------- |---------- |---------- |------ |------------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **DedupeWithRemoveDuplicateFunction**        | **.NET 10.0** | **.NET 10.0** | **10**    |    **521.0 ns** |   **8.29 ns** |   **6.92 ns** |  **1.26** |    **0.03** | **0.0925** |      **-** |   **1.52 KB** |        **1.41** |
| DedupeWithLinqDistinct                   | .NET 10.0 | .NET 10.0 | 10    |    415.0 ns |   7.91 ns |   9.11 ns |  1.00 |    0.03 | 0.0658 |      - |   1.08 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | .NET 10.0 | .NET 10.0 | 10    |    405.0 ns |   4.94 ns |   4.62 ns |  0.98 |    0.02 | 0.0648 |      - |   1.06 KB |        0.99 |
|                                          |           |           |       |             |           |           |       |         |        |        |           |             |
| DedupeWithRemoveDuplicateFunction        | .NET 9.0  | .NET 9.0  | 10    |    520.6 ns |   7.29 ns |   7.16 ns |  1.33 |    0.02 | 0.0925 |      - |   1.52 KB |        1.41 |
| DedupeWithLinqDistinct                   | .NET 9.0  | .NET 9.0  | 10    |    390.1 ns |   3.17 ns |   2.97 ns |  1.00 |    0.01 | 0.0658 |      - |   1.08 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | .NET 9.0  | .NET 9.0  | 10    |    389.6 ns |   3.45 ns |   3.22 ns |  1.00 |    0.01 | 0.0648 |      - |   1.06 KB |        0.99 |
|                                          |           |           |       |             |           |           |       |         |        |        |           |             |
| **DedupeWithRemoveDuplicateFunction**        | **.NET 10.0** | **.NET 10.0** | **1000**  | **46,736.5 ns** | **568.75 ns** | **532.01 ns** |  **1.55** |    **0.02** | **9.5825** | **1.8921** | **157.11 KB** |        **1.42** |
| DedupeWithLinqDistinct                   | .NET 10.0 | .NET 10.0 | 1000  | 30,098.1 ns | 389.11 ns | 324.92 ns |  1.00 |    0.01 | 6.7444 | 2.2278 | 110.45 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | .NET 10.0 | .NET 10.0 | 1000  | 32,052.1 ns | 623.86 ns | 583.56 ns |  1.07 |    0.02 | 6.7139 | 2.1973 | 110.43 KB |        1.00 |
|                                          |           |           |       |             |           |           |       |         |        |        |           |             |
| DedupeWithRemoveDuplicateFunction        | .NET 9.0  | .NET 9.0  | 1000  | 44,677.7 ns | 527.68 ns | 493.59 ns |  1.42 |    0.03 | 9.5825 | 1.8921 | 157.11 KB |        1.42 |
| DedupeWithLinqDistinct                   | .NET 9.0  | .NET 9.0  | 1000  | 31,579.7 ns | 593.17 ns | 634.69 ns |  1.00 |    0.03 | 6.7139 | 2.1973 | 110.45 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | .NET 9.0  | .NET 9.0  | 1000  | 32,325.4 ns | 625.80 ns | 642.65 ns |  1.02 |    0.03 | 6.7139 | 2.1973 | 110.43 KB |        1.00 |
