# Using await on tasks sequentially vs. calling await Task.WhenAll



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | Mean     | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|----------------------- |---------:|--------:|--------:|------:|----------:|------------:|
| AwaitTasksSequentially | 500.3 ms | 3.40 ms | 3.18 ms |  1.00 |   4.15 KB |        1.00 |
| AwaitTasksUsingWhenAll | 500.7 ms | 3.57 ms | 3.34 ms |  1.00 |   4.43 KB |        1.07 |
