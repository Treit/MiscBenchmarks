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
| IncrementUsingInterlocked   | 10000 |     220.7 μs |     8.40 μs |    24.24 μs |   1.01 |    0.16 |      3 KB |        1.00 |
| IncrementUsingLock          | 10000 |   1,612.7 μs |    50.85 μs |   148.34 μs |   7.40 |    1.12 |   5.04 KB |        1.68 |
| IncrementUsingSemaphore     | 10000 | 143,348.7 μs | 1,432.85 μs | 1,270.18 μs | 658.03 |   78.97 |   5.26 KB |        1.75 |
| IncrementUsingSemaphoreSlim | 10000 |   3,133.7 μs |   139.39 μs |   406.60 μs |  14.38 |    2.54 |   4.98 KB |        1.66 |
