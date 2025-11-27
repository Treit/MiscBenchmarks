# Incrementing a counter from multiple threads.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                      | Job       | Runtime   | Count | Mean         | Error       | StdDev      | Ratio  | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------ |-------------:|------------:|------------:|-------:|--------:|----------:|------------:|
| IncrementUsingInterlocked   | .NET 10.0 | .NET 10.0 | 10000 |     281.5 μs |    10.77 μs |    30.54 μs |   1.02 |    0.26 |   4.03 KB |        1.00 |
| IncrementUsingLock          | .NET 10.0 | .NET 10.0 | 10000 |   1,675.6 μs |    49.83 μs |   138.90 μs |   6.09 |    1.51 |   4.91 KB |        1.22 |
| IncrementUsingSemaphore     | .NET 10.0 | .NET 10.0 | 10000 | 139,485.4 μs | 2,755.52 μs | 2,706.29 μs | 507.05 |  118.18 |   5.07 KB |        1.26 |
| IncrementUsingSemaphoreSlim | .NET 10.0 | .NET 10.0 | 10000 |   2,476.9 μs |    55.33 μs |   158.75 μs |   9.00 |    2.17 |   5.17 KB |        1.28 |
|                             |           |           |       |              |             |             |        |         |           |             |
| IncrementUsingInterlocked   | .NET 9.0  | .NET 9.0  | 10000 |     279.2 μs |     8.55 μs |    23.83 μs |   1.01 |    0.13 |   3.83 KB |        1.00 |
| IncrementUsingLock          | .NET 9.0  | .NET 9.0  | 10000 |   1,766.4 μs |    34.99 μs |    64.86 μs |   6.38 |    0.63 |   4.91 KB |        1.28 |
| IncrementUsingSemaphore     | .NET 9.0  | .NET 9.0  | 10000 | 139,959.8 μs | 2,728.42 μs | 2,801.89 μs | 505.16 |   47.70 |   4.98 KB |        1.30 |
| IncrementUsingSemaphoreSlim | .NET 9.0  | .NET 9.0  | 10000 |   2,897.7 μs |    98.01 μs |   282.78 μs |  10.46 |    1.40 |   5.07 KB |        1.32 |
