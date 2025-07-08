# Async/Await vs Task Return Chain Performance Benchmark



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27891.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                    | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| AsyncAwaitWithAwaitChain  | 100   | 129.24 μs | 2.549 μs | 5.958 μs |  2.09 |    0.12 | 6.8359 |  29.84 KB |        3.14 |
| AsyncAwaitWithReturnChain | 100   |  61.98 μs | 1.215 μs | 2.399 μs |  1.00 |    0.05 | 2.1973 |   9.49 KB |        1.00 |
