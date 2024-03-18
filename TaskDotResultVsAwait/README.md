# For an already completed task, calling .Result vs. await.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------ |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **AlreadyCompletedTaskDotResult** | **1**     |  **1.996 μs** | **0.1525 μs** | **0.4498 μs** |  **1.720 μs** |  **1.00** |    **0.00** | **0.0954** |      **-** |     **416 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | 1     |  2.434 μs | 0.2386 μs | 0.7035 μs |  2.454 μs |  1.26 |    0.39 | 0.1163 |      - |     503 B |        1.21 |
|                               |       |           |           |           |           |       |         |        |        |           |             |
| **AlreadyCompletedTaskDotResult** | **50**    | **18.318 μs** | **0.3647 μs** | **0.7850 μs** | **18.243 μs** |  **1.00** |    **0.00** | **2.5024** | **0.0305** |   **10760 B** |        **1.00** |
| AlreadyCompletedTaskAwait     | 50    | 28.805 μs | 0.5756 μs | 0.6397 μs | 28.789 μs |  1.59 |    0.08 | 2.5024 |      - |   10839 B |        1.01 |
