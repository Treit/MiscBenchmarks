# InterlockedIncrement

```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3


```
| Method                     | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| **PlainIncrement**             | **100**   |     **39.32 ns** |   **0.424 ns** |   **0.396 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| InterlockedIncrementMethod | 100   |    239.12 ns |   3.187 ns |   2.981 ns |  6.08 |    0.09 |         - |          NA |
|                            |       |              |            |            |       |         |           |             |
| **PlainIncrement**             | **10000** |  **3,200.19 ns** |  **40.873 ns** |  **36.233 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| InterlockedIncrementMethod | 10000 | 23,850.34 ns | 179.459 ns | 167.866 ns |  7.45 |    0.10 |         - |          NA |
