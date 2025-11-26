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
| RegularLock            |   1.784 ms | 0.0423 ms | 0.1228 ms |   1.789 ms |  1.00 |    0.10 |    5.95 KB |        1.00 |
| SemaphoreWait          | 144.939 ms | 1.6678 ms | 2.4447 ms | 144.641 ms | 81.64 |    5.79 |    5.38 KB |        0.91 |
| SemaphoreSlimWait      |   2.885 ms | 0.0813 ms | 0.2333 ms |   2.883 ms |  1.63 |    0.17 |    4.98 KB |        0.84 |
| SemaphoreSlimWaitAsync |   3.480 ms | 0.1316 ms | 0.3818 ms |   3.483 ms |  1.96 |    0.25 | 2085.84 KB |      350.84 |
| NitoAsyncMonitor       |   4.356 ms | 0.3601 ms | 1.0560 ms |   3.933 ms |  2.45 |    0.62 | 2866.63 KB |      482.17 |
