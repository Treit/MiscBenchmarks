# Locking

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.1848/22H2/2022Update/SunValley2)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-EAXUDW : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                 | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated  | Alloc Ratio |
|----------------------- |----------:|----------:|----------:|------:|--------:|-----------:|------------:|
| RegularLock            |  1.397 ms | 0.1441 ms | 0.4182 ms |  1.00 |    0.00 |    6.77 KB |        1.00 |
| SemaphoreWait          | 37.217 ms | 1.2269 ms | 3.5594 ms | 33.18 |   26.59 |    6.55 KB |        0.97 |
| SemaphoreSlimWait      |  1.401 ms | 0.0568 ms | 0.1628 ms |  1.33 |    1.32 |    6.71 KB |        0.99 |
| SemaphoreSlimWaitAsync |  3.141 ms | 0.1908 ms | 0.5566 ms |  2.99 |    3.08 |  1959.4 KB |      289.28 |
| NitoAsyncMonitor       |  3.108 ms | 0.2374 ms | 0.6849 ms |  2.96 |    3.09 | 3016.28 KB |      445.31 |
