# Locking




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                 | Job       | Runtime   | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Allocated  | Alloc Ratio |
|----------------------- |---------- |---------- |-----------:|----------:|----------:|-----------:|------:|--------:|-----------:|------------:|
| RegularLock            | .NET 10.0 | .NET 10.0 |   1.675 ms | 0.0380 ms | 0.1077 ms |   1.681 ms |  1.00 |    0.09 |    4.98 KB |        1.00 |
| SemaphoreWait          | .NET 10.0 | .NET 10.0 | 141.366 ms | 2.7324 ms | 3.1467 ms | 140.552 ms | 84.75 |    5.98 |    4.98 KB |        1.00 |
| SemaphoreSlimWait      | .NET 10.0 | .NET 10.0 |   2.441 ms | 0.1020 ms | 0.2944 ms |   2.489 ms |  1.46 |    0.20 |    5.13 KB |        1.03 |
| SemaphoreSlimWaitAsync | .NET 10.0 | .NET 10.0 |   3.353 ms | 0.1246 ms | 0.3595 ms |   3.327 ms |  2.01 |    0.25 | 1957.95 KB |      393.43 |
| NitoAsyncMonitor       | .NET 10.0 | .NET 10.0 |   3.882 ms | 0.2348 ms | 0.6662 ms |   3.699 ms |  2.33 |    0.43 | 3003.54 KB |      603.54 |
|                        |           |           |            |           |           |            |       |         |            |             |
| RegularLock            | .NET 9.0  | .NET 9.0  |   1.731 ms | 0.0549 ms | 0.1548 ms |   1.706 ms |  1.01 |    0.13 |     5.2 KB |        1.00 |
| SemaphoreWait          | .NET 9.0  | .NET 9.0  | 138.669 ms | 2.6704 ms | 2.8573 ms | 138.438 ms | 80.72 |    7.17 |    5.23 KB |        1.01 |
| SemaphoreSlimWait      | .NET 9.0  | .NET 9.0  |   2.314 ms | 0.1104 ms | 0.3184 ms |   2.267 ms |  1.35 |    0.22 |    5.13 KB |        0.99 |
| SemaphoreSlimWaitAsync | .NET 9.0  | .NET 9.0  |   3.461 ms | 0.0894 ms | 0.2521 ms |   3.412 ms |  2.01 |    0.23 | 1958.01 KB |      376.88 |
| NitoAsyncMonitor       | .NET 9.0  | .NET 9.0  |   4.256 ms | 0.2696 ms | 0.7822 ms |   4.036 ms |  2.48 |    0.50 | 3019.81 KB |      581.26 |
