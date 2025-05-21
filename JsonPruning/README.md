# Pruning JSON subtrees

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27863.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                   | Count  | Mean        | Error     | StdDev     | Median      | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated  | Alloc Ratio |
|------------------------- |------- |------------:|----------:|-----------:|------------:|------:|--------:|-----------:|-----------:|----------:|-----------:|------------:|
| **PruneRecursiveWithWriter** | **1000**   |    **13.36 ms** |  **0.327 ms** |   **0.922 ms** |    **13.23 ms** |  **1.00** |    **0.00** |  **1671.8750** |   **921.8750** |  **906.2500** |    **9.18 MB** |        **1.00** |
| PruneWithJsonNodeRemove  | 1000   |    23.07 ms |  0.843 ms |   2.486 ms |    22.33 ms |  1.72 |    0.22 |  1375.0000 |  1250.0000 |  500.0000 |    7.92 MB |        0.86 |
|                          |        |             |           |            |             |       |         |            |            |           |            |             |
| **PruneRecursiveWithWriter** | **100000** | **1,273.02 ms** | **18.427 ms** |  **18.923 ms** | **1,274.30 ms** |  **1.00** |    **0.00** | **75000.0000** |          **-** |         **-** | **1045.54 MB** |        **1.00** |
| PruneWithJsonNodeRemove  | 100000 | 3,333.92 ms | 65.388 ms | 117.909 ms | 3,323.64 ms |  2.64 |    0.11 | 87000.0000 | 44000.0000 | 2000.0000 |  800.27 MB |        0.77 |
