# Incrementing a counter from multiple threads.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                      | Count | Mean         | Error       | StdDev      | Ratio  | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------ |-------------:|------------:|------------:|-------:|--------:|----------:|------------:|
| IncrementUsingInterlocked   | 10000 |     221.0 μs |     7.62 μs |    22.10 μs |   1.01 |    0.16 |   2.82 KB |        1.00 |
| IncrementUsingLock          | 10000 |   1,560.8 μs |    34.67 μs |   100.04 μs |   7.15 |    0.97 |   5.13 KB |        1.82 |
| IncrementUsingSemaphore     | 10000 | 144,352.7 μs | 2,688.73 μs | 2,515.04 μs | 660.97 |   79.70 |    5.2 KB |        1.84 |
| IncrementUsingSemaphoreSlim | 10000 |   3,257.3 μs |    99.81 μs |   284.76 μs |  14.91 |    2.21 |   5.13 KB |        1.82 |
