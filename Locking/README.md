# Locking


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                 | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Allocated  | Alloc Ratio |
|----------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-----------:|------------:|
| RegularLock            |   1.666 ms | 0.0377 ms | 0.1094 ms |   1.686 ms |  1.00 |    0.09 |    4.85 KB |        1.00 |
| SemaphoreWait          | 144.686 ms | 2.0059 ms | 1.8763 ms | 144.881 ms | 87.24 |    5.97 |    5.38 KB |        1.11 |
| SemaphoreSlimWait      |   2.776 ms | 0.0709 ms | 0.2035 ms |   2.780 ms |  1.67 |    0.17 |    5.07 KB |        1.05 |
| SemaphoreSlimWaitAsync |   3.310 ms | 0.0836 ms | 0.2411 ms |   3.287 ms |  2.00 |    0.20 | 1957.88 KB |      403.56 |
| NitoAsyncMonitor       |   4.267 ms | 0.3270 ms | 0.9487 ms |   3.931 ms |  2.57 |    0.60 |  2967.2 KB |      611.60 |
