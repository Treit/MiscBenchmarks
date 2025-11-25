# Calling an async method vs. wrapping it in a Task.Run


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| AwaitAsyncMethodCallDirectly              |   639.1 ns | 10.24 ns |  9.58 ns |  1.00 |    0.02 | 0.0172 |     296 B |        1.00 |
| AwaitAsyncMethodCallWithTaskDotRunWrapper | 1,005.0 ns | 19.89 ns | 20.42 ns |  1.57 |    0.04 | 0.0305 |     512 B |        1.73 |
