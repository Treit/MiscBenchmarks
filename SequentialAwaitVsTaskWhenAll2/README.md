# Using await on tasks sequentially vs. calling await Task.WhenAll


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-FKADUP : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                 Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Allocated | Alloc Ratio |
|----------------------- |------ |-----------:|----------:|----------:|------:|--------:|-----------:|------------:|
| **AwaitTasksSequentially** |    **10** |   **5.262 ms** | **0.1175 ms** | **0.3428 ms** |  **1.00** |    **0.00** |   **37.87 KB** |        **1.00** |
| AwaitTasksUsingWhenAll |    10 |   5.125 ms | 0.1003 ms | 0.2365 ms |  0.97 |    0.08 |   37.59 KB |        0.99 |
|                        |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** |   **100** |  **54.517 ms** | **1.0733 ms** | **1.9354 ms** |  **1.00** |    **0.00** |  **392.95 KB** |        **1.00** |
| AwaitTasksUsingWhenAll |   100 |  53.976 ms | 1.0619 ms | 1.4535 ms |  0.99 |    0.05 |  393.09 KB |        1.00 |
|                        |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** |  **1000** | **550.423 ms** | **6.8045 ms** | **6.0320 ms** |  **1.00** |    **0.00** | **3996.55 KB** |        **1.00** |
| AwaitTasksUsingWhenAll |  1000 | 550.308 ms | 6.0322 ms | 5.3474 ms |  1.00 |    0.02 | 3994.83 KB |        1.00 |
