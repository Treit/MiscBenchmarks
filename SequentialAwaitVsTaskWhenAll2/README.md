# Using await on tasks sequentially vs. calling await Task.WhenAll





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Job       | Runtime   | Mean     | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|----------------------- |---------- |---------- |---------:|--------:|--------:|------:|----------:|------------:|
| AwaitTasksSequentially | .NET 10.0 | .NET 10.0 | 500.6 ms | 1.26 ms | 1.18 ms |  1.00 |   4.15 KB |        1.00 |
| AwaitTasksUsingWhenAll | .NET 10.0 | .NET 10.0 | 499.6 ms | 2.95 ms | 2.76 ms |  1.00 |   4.43 KB |        1.07 |
|                        |           |           |          |         |         |       |           |             |
| AwaitTasksSequentially | .NET 9.0  | .NET 9.0  | 501.1 ms | 1.14 ms | 1.01 ms |  1.00 |   4.15 KB |        1.00 |
| AwaitTasksUsingWhenAll | .NET 9.0  | .NET 9.0  | 501.0 ms | 1.43 ms | 1.27 ms |  1.00 |   4.43 KB |        1.07 |
