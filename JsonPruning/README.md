# Pruning JSON subtrees



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count  | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0       | Gen1       | Gen2      | Allocated  | Alloc Ratio |
|------------------------- |------- |-------------:|-----------:|-----------:|------:|--------:|-----------:|-----------:|----------:|-----------:|------------:|
| **PruneRecursiveWithWriter** | **1000**   |     **9.867 ms** |  **0.1908 ms** |  **0.2674 ms** |  **1.00** |    **0.04** |   **796.8750** |   **609.3750** |  **609.3750** |    **9.18 MB** |        **1.00** |
| PruneWithJsonNodeRemove  | 1000   |    11.244 ms |  0.2239 ms |  0.4523 ms |  1.14 |    0.06 |   828.1250 |   750.0000 |  484.3750 |     8.5 MB |        0.93 |
|                          |        |              |            |            |       |         |            |            |           |            |             |
| **PruneRecursiveWithWriter** | **100000** | **1,046.427 ms** | **13.7232 ms** | **12.1653 ms** |  **1.00** |    **0.02** | **19000.0000** |          **-** |         **-** | **1045.31 MB** |        **1.00** |
| PruneWithJsonNodeRemove  | 100000 | 2,182.118 ms | 35.1355 ms | 31.1467 ms |  2.09 |    0.04 | 37000.0000 | 36000.0000 | 2000.0000 |   858.1 MB |        0.82 |
