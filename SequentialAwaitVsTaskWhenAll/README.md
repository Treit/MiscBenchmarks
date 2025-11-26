# Using await on tasks sequentially vs. calling await Task.WhenAll




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                 | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated  | Alloc Ratio |
|----------------------- |------ |-----------:|----------:|----------:|------:|--------:|-----------:|------------:|
| **AwaitTasksSequentially** | **10**    |   **4.627 ms** | **0.0924 ms** | **0.2160 ms** |  **1.00** |    **0.07** |   **18.47 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | 10    |   4.651 ms | 0.0930 ms | 0.1746 ms |  1.01 |    0.06 |   30.91 KB |        1.67 |
|                        |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** | **100**   |  **48.304 ms** | **0.3501 ms** | **0.3275 ms** |  **1.00** |    **0.01** |  **272.03 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | 100   |  48.611 ms | 0.9224 ms | 0.8177 ms |  1.01 |    0.02 |  266.23 KB |        0.98 |
|                        |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** | **1000**  | **505.272 ms** | **9.3905 ms** | **8.3244 ms** |  **1.00** |    **0.02** | **2484.98 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | 1000  | 504.834 ms | 7.8827 ms | 7.3735 ms |  1.00 |    0.02 | 2486.56 KB |        1.00 |
