# Deduplicating a comma delimited string



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **DedupeWithRemoveDuplicateFunction**        | **10**    |    **529.8 ns** |   **6.18 ns** |   **5.79 ns** |  **1.31** |    **0.02** | **0.0925** |      **-** |   **1.52 KB** |        **1.41** |
| DedupeWithLinqDistinct                   | 10    |    404.6 ns |   3.90 ns |   3.46 ns |  1.00 |    0.01 | 0.0658 |      - |   1.08 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | 10    |    408.3 ns |   3.30 ns |   3.09 ns |  1.01 |    0.01 | 0.0648 |      - |   1.06 KB |        0.99 |
|                                          |       |             |           |           |       |         |        |        |           |             |
| **DedupeWithRemoveDuplicateFunction**        | **1000**  | **45,463.8 ns** | **465.73 ns** | **412.85 ns** |  **1.47** |    **0.02** | **9.5825** | **1.8921** | **157.11 KB** |        **1.42** |
| DedupeWithLinqDistinct                   | 1000  | 30,968.2 ns | 366.84 ns | 325.20 ns |  1.00 |    0.01 | 6.7139 | 2.1973 | 110.45 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | 1000  | 32,005.9 ns | 319.87 ns | 283.55 ns |  1.03 |    0.01 | 6.7139 | 2.1973 | 110.43 KB |        1.00 |
