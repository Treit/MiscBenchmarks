# Deduplicating a comma delimited string

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                            | Count | Mean        | Error       | StdDev      | Median      | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|---------------------------------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **DedupeWithRemoveDuplicateFunction** | **10**    |    **998.9 ns** |    **54.13 ns** |   **157.04 ns** |    **942.5 ns** |  **1.27** |    **0.19** |  **0.3595** |      **-** |   **1.52 KB** |        **1.41** |
| DedupeWithLinqDistinct            | 10    |    788.9 ns |    29.49 ns |    86.04 ns |    768.3 ns |  1.00 |    0.00 |  0.2556 |      - |   1.08 KB |        1.00 |
|                                   |       |             |             |             |             |       |         |         |        |           |             |
| **DedupeWithRemoveDuplicateFunction** | **1000**  | **95,458.9 ns** | **2,708.00 ns** | **7,899.36 ns** | **94,455.3 ns** |  **1.38** |    **0.19** | **36.9873** |      **-** | **157.11 KB** |        **1.42** |
| DedupeWithLinqDistinct            | 1000  | 70,087.0 ns | 3,423.11 ns | 9,876.47 ns | 67,964.3 ns |  1.00 |    0.00 | 26.1230 | 4.2725 | 110.45 KB |        1.00 |
