# For an already completed task, calling .Result vs. await.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |------ |------------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **AlreadyCompletedTaskDotResult** | **.NET 10.0** | **.NET 10.0** | **1**     |    **675.7 ns** |   **7.62 ns** |   **6.76 ns** |  **1.00** |    **0.01** | **0.0248** |      **-** |     **416 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | .NET 10.0 | .NET 10.0 | 1     |    677.3 ns |  11.65 ns |  10.33 ns |  1.00 |    0.02 | 0.0286 |      - |     503 B |        1.21 |
|                               |           |           |       |             |           |           |       |         |        |        |           |             |
| AlreadyCompletedTaskDotResult | .NET 9.0  | .NET 9.0  | 1     |    613.1 ns |   5.60 ns |   4.97 ns |  1.00 |    0.01 | 0.0248 |      - |     416 B |        1.00 |
| AlreadyCompletedTaskAwait     | .NET 9.0  | .NET 9.0  | 1     |    681.2 ns |  10.18 ns |   8.50 ns |  1.11 |    0.02 | 0.0286 |      - |     503 B |        1.21 |
|                               |           |           |       |             |           |           |       |         |        |        |           |             |
| **AlreadyCompletedTaskDotResult** | **.NET 10.0** | **.NET 10.0** | **50**    | **16,019.0 ns** | **223.82 ns** | **209.36 ns** |  **1.00** |    **0.02** | **0.6409** | **0.0153** |   **10774 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | .NET 10.0 | .NET 10.0 | 50    | 32,215.5 ns | 529.28 ns | 495.09 ns |  2.01 |    0.04 | 0.6409 |      - |   10908 B |        1.01 |
|                               |           |           |       |             |           |           |       |         |        |        |           |             |
| AlreadyCompletedTaskDotResult | .NET 9.0  | .NET 9.0  | 50    | 16,200.3 ns | 320.78 ns | 417.10 ns |  1.00 |    0.04 | 0.6409 |      - |   10774 B |        1.00 |
| AlreadyCompletedTaskAwait     | .NET 9.0  | .NET 9.0  | 50    | 25,317.1 ns | 486.48 ns | 742.91 ns |  1.56 |    0.06 | 0.6409 |      - |   10893 B |        1.01 |
