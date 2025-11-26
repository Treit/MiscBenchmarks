# Async/Await vs Task Return Chain Performance Benchmark




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |------ |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| AsyncAwaitWithAwaitChain  | 100   | 75.40 μs | 1.286 μs | 1.925 μs |  1.40 |    0.04 | 1.7090 |  29.84 KB |        3.13 |
| AsyncAwaitWithReturnChain | 100   | 53.90 μs | 1.028 μs | 0.962 μs |  1.00 |    0.02 | 0.4883 |   9.55 KB |        1.00 |
