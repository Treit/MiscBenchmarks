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
| **PruneRecursiveWithWriter** | **1000**   |     **9.915 ms** |  **0.1933 ms** |  **0.2301 ms** |  **1.00** |    **0.03** |   **765.6250** |   **578.1250** |  **578.1250** |    **9.18 MB** |        **1.00** |
| PruneWithJsonNodeRemove  | 1000   |    11.196 ms |  0.2223 ms |  0.4120 ms |  1.13 |    0.05 |   828.1250 |   750.0000 |  484.3750 |     8.5 MB |        0.93 |
|                          |        |              |            |            |       |         |            |            |           |            |             |
| **PruneRecursiveWithWriter** | **100000** | **1,010.078 ms** | **19.5742 ms** | **24.0389 ms** |  **1.00** |    **0.03** | **19000.0000** |          **-** |         **-** | **1045.55 MB** |        **1.00** |
| PruneWithJsonNodeRemove  | 100000 | 2,126.508 ms | 40.9513 ms | 40.2197 ms |  2.11 |    0.07 | 37000.0000 | 36000.0000 | 2000.0000 |   858.1 MB |        0.82 |
