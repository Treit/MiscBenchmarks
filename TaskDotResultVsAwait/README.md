# For an already completed task, calling .Result vs. await.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |------ |------------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **AlreadyCompletedTaskDotResult** | **1**     |    **638.5 ns** |   **8.30 ns** |   **7.77 ns** |  **1.00** |    **0.02** | **0.0248** |      **-** |     **416 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | 1     |    671.7 ns |   6.93 ns |   6.48 ns |  1.05 |    0.02 | 0.0296 |      - |     503 B |        1.21 |
|                               |       |             |           |           |       |         |        |        |           |             |
| **AlreadyCompletedTaskDotResult** | **50**    |  **9,901.0 ns** | **123.60 ns** | **115.62 ns** |  **1.00** |    **0.02** | **0.6409** | **0.0153** |   **10761 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | 50    | 10,686.0 ns | 211.24 ns | 510.16 ns |  1.08 |    0.05 | 0.6409 |      - |   10850 B |        1.01 |
