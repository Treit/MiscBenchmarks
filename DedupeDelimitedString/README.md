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
| **DedupeWithRemoveDuplicateFunction**        | **10**    |    **509.7 ns** |   **5.86 ns** |   **5.48 ns** |  **1.37** |    **0.02** | **0.0925** |      **-** |   **1.52 KB** |        **1.41** |
| DedupeWithLinqDistinct                   | 10    |    371.4 ns |   2.78 ns |   2.60 ns |  1.00 |    0.01 | 0.0658 |      - |   1.08 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | 10    |    381.8 ns |   5.03 ns |   4.70 ns |  1.03 |    0.01 | 0.0648 |      - |   1.06 KB |        0.99 |
|                                          |       |             |           |           |       |         |        |        |           |             |
| **DedupeWithRemoveDuplicateFunction**        | **1000**  | **44,196.9 ns** | **318.18 ns** | **297.62 ns** |  **1.47** |    **0.02** | **9.5825** | **1.8921** | **157.11 KB** |        **1.42** |
| DedupeWithLinqDistinct                   | 1000  | 30,123.2 ns | 346.95 ns | 324.54 ns |  1.00 |    0.01 | 6.7139 | 2.1973 | 110.45 KB |        1.00 |
| DedupeWithLinqDistinctStringSplitOptions | 1000  | 32,092.3 ns | 503.42 ns | 470.90 ns |  1.07 |    0.02 | 6.7139 | 2.1973 | 110.43 KB |        1.00 |
