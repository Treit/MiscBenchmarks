# Incrementing a counter from multiple threads.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-YQNYGE : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                      | Count | Mean         | Error       | StdDev      | Median       | Ratio  | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------ |-------------:|------------:|------------:|-------------:|-------:|--------:|----------:|------------:|
| IncrementUsingInterlocked   | 10000 |     411.0 μs |    18.65 μs |    53.51 μs |     411.4 μs |   1.00 |    0.00 |   2.29 KB |        1.00 |
| IncrementUsingLock          | 10000 |   1,802.9 μs |    72.62 μs |   208.35 μs |   1,812.3 μs |   4.47 |    0.84 |   4.08 KB |        1.78 |
| IncrementUsingSemaphore     | 10000 | 264,536.9 μs | 4,584.29 μs | 4,288.15 μs | 264,724.3 μs | 610.99 |   52.34 |   4.37 KB |        1.91 |
| IncrementUsingSemaphoreSlim | 10000 |   2,494.2 μs |   178.78 μs |   512.94 μs |   2,334.5 μs |   6.20 |    1.62 |   3.62 KB |        1.58 |
