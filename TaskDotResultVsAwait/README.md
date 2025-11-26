# For an already completed task, calling .Result vs. await.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |------ |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **AlreadyCompletedTaskDotResult** | **1**     |    **673.0 ns** |  **13.35 ns** |  **27.28 ns** |  **1.00** |    **0.06** | **0.0248** |     **416 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | 1     |    711.6 ns |  13.42 ns |  12.56 ns |  1.06 |    0.05 | 0.0296 |     503 B |        1.21 |
|                               |       |             |           |           |       |         |        |           |             |
| **AlreadyCompletedTaskDotResult** | **50**    | **16,940.4 ns** | **326.15 ns** | **412.47 ns** |  **1.00** |    **0.03** | **0.6409** |   **10774 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | 50    | 26,926.2 ns | 518.77 ns | 555.08 ns |  1.59 |    0.05 | 0.6409 |   10893 B |        1.01 |
