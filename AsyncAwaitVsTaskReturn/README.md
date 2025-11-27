# Async/Await vs Task Return Chain Performance Benchmark





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |---------- |---------- |------ |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| AsyncAwaitWithAwaitChain  | .NET 10.0 | .NET 10.0 | 100   | 74.98 μs | 1.450 μs | 2.079 μs | 74.31 μs |  1.39 |    0.05 | 1.7090 |  29.82 KB |        3.12 |
| AsyncAwaitWithReturnChain | .NET 10.0 | .NET 10.0 | 100   | 53.82 μs | 1.059 μs | 1.088 μs | 53.70 μs |  1.00 |    0.03 | 0.4883 |   9.55 KB |        1.00 |
|                           |           |           |       |          |          |          |          |       |         |        |           |             |
| AsyncAwaitWithAwaitChain  | .NET 9.0  | .NET 9.0  | 100   | 80.28 μs | 2.163 μs | 6.379 μs | 77.81 μs |  1.51 |    0.13 | 1.7090 |  29.82 KB |        3.12 |
| AsyncAwaitWithReturnChain | .NET 9.0  | .NET 9.0  | 100   | 53.32 μs | 1.045 μs | 1.532 μs | 53.35 μs |  1.00 |    0.04 | 0.4883 |   9.55 KB |        1.00 |
