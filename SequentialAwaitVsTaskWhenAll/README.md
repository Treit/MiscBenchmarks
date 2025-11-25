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
| **AwaitTasksSequentially** | **10**    |   **4.793 ms** | **0.0946 ms** | **0.1263 ms** |  **1.00** |    **0.04** |   **21.68 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | 10    |   4.768 ms | 0.0857 ms | 0.1230 ms |  1.00 |    0.04 |   33.21 KB |        1.53 |
|                        |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** | **100**   |  **53.201 ms** | **1.0635 ms** | **2.1484 ms** |  **1.00** |    **0.06** |  **236.64 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | 100   |  52.690 ms | 0.9298 ms | 1.5534 ms |  0.99 |    0.05 |   236.7 KB |        1.00 |
|                        |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** | **1000**  | **521.060 ms** | **5.7796 ms** | **4.8262 ms** |  **1.00** |    **0.01** | **2484.98 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | 1000  | 524.420 ms | 5.1576 ms | 4.8245 ms |  1.01 |    0.01 | 2484.86 KB |        1.00 |
