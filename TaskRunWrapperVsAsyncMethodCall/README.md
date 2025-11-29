# Calling an async method vs. wrapping it in a Task.Run




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |---------- |---------- |-----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| AwaitAsyncMethodCallDirectly              | .NET 10.0 | .NET 10.0 |   653.1 ns |  9.96 ns |  8.31 ns |  1.00 |    0.02 | 0.0172 |     296 B |        1.00 |
| AwaitAsyncMethodCallWithTaskDotRunWrapper | .NET 10.0 | .NET 10.0 | 1,021.7 ns | 18.92 ns | 21.03 ns |  1.56 |    0.04 | 0.0305 |     512 B |        1.73 |
|                                           |           |           |            |          |          |       |         |        |           |             |
| AwaitAsyncMethodCallDirectly              | .NET 9.0  | .NET 9.0  |   659.4 ns |  8.52 ns |  7.97 ns |  1.00 |    0.02 | 0.0172 |     296 B |        1.00 |
| AwaitAsyncMethodCallWithTaskDotRunWrapper | .NET 9.0  | .NET 9.0  | 1,012.2 ns | 20.10 ns | 26.14 ns |  1.54 |    0.04 | 0.0305 |     512 B |        1.73 |
