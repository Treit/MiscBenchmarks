# Using await on tasks sequentially vs. calling await Task.WhenAll





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                 | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated  | Alloc Ratio |
|----------------------- |---------- |---------- |------ |-----------:|----------:|----------:|------:|--------:|-----------:|------------:|
| **AwaitTasksSequentially** | **.NET 10.0** | **.NET 10.0** | **10**    |   **5.430 ms** | **0.1076 ms** | **0.2558 ms** |  **1.00** |    **0.07** |   **19.73 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | .NET 10.0 | .NET 10.0 | 10    |   5.382 ms | 0.1067 ms | 0.3011 ms |  0.99 |    0.07 |   21.76 KB |        1.10 |
|                        |           |           |       |            |           |           |       |         |            |             |
| AwaitTasksSequentially | .NET 9.0  | .NET 9.0  | 10    |   5.298 ms | 0.1049 ms | 0.2411 ms |  1.00 |    0.06 |   21.56 KB |        1.00 |
| AwaitTasksUsingWhenAll | .NET 9.0  | .NET 9.0  | 10    |   5.125 ms | 0.0993 ms | 0.1256 ms |  0.97 |    0.05 |    23.2 KB |        1.08 |
|                        |           |           |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** | **.NET 10.0** | **.NET 10.0** | **100**   |  **57.897 ms** | **1.1536 ms** | **2.1383 ms** |  **1.00** |    **0.05** |  **238.13 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | .NET 10.0 | .NET 10.0 | 100   |  57.624 ms | 1.1371 ms | 2.1076 ms |  1.00 |    0.05 |   238.7 KB |        1.00 |
|                        |           |           |       |            |           |           |       |         |            |             |
| AwaitTasksSequentially | .NET 9.0  | .NET 9.0  | 100   |  56.232 ms | 1.1165 ms | 1.9554 ms |  1.00 |    0.05 |  239.81 KB |        1.00 |
| AwaitTasksUsingWhenAll | .NET 9.0  | .NET 9.0  | 100   |  56.215 ms | 1.0947 ms | 1.7363 ms |  1.00 |    0.05 |  237.56 KB |        0.99 |
|                        |           |           |       |            |           |           |       |         |            |             |
| **AwaitTasksSequentially** | **.NET 10.0** | **.NET 10.0** | **1000**  | **575.947 ms** | **8.3831 ms** | **7.4314 ms** |  **1.00** |    **0.02** |  **2471.9 KB** |        **1.00** |
| AwaitTasksUsingWhenAll | .NET 10.0 | .NET 10.0 | 1000  | 576.005 ms | 9.3687 ms | 8.7635 ms |  1.00 |    0.02 | 2475.46 KB |        1.00 |
|                        |           |           |       |            |           |           |       |         |            |             |
| AwaitTasksSequentially | .NET 9.0  | .NET 9.0  | 1000  | 576.291 ms | 9.2398 ms | 8.6429 ms |  1.00 |    0.02 | 2464.77 KB |        1.00 |
| AwaitTasksUsingWhenAll | .NET 9.0  | .NET 9.0  | 1000  | 570.432 ms | 5.9508 ms | 5.5664 ms |  0.99 |    0.02 | 2464.22 KB |        1.00 |
