# Combining data into a dictionary

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27907.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method               | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| OriginalLinqApproach | 17.020 μs | 0.9480 μs | 2.6584 μs | 16.026 μs |  3.83 |    0.72 | 3.0518 |      - |  12.95 KB |        1.94 |
| LoopWithoutPresize   |  7.553 μs | 0.2389 μs | 0.6619 μs |  7.430 μs |  1.70 |    0.23 | 5.1575 | 0.2441 |  21.79 KB |        3.27 |
| LoopsWithPresize     |  4.497 μs | 0.1814 μs | 0.5233 μs |  4.317 μs |  1.01 |    0.16 | 1.5793 |      - |   6.66 KB |        1.00 |
