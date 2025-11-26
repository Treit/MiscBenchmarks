# Combining data into a dictionary


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------- |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| OriginalLinqApproach | 10.500 μs | 0.0687 μs | 0.0574 μs |  4.85 |    0.08 | 0.7782 | 0.0153 |  12.95 KB |        1.94 |
| LoopWithoutPresize   |  3.737 μs | 0.0224 μs | 0.0198 μs |  1.72 |    0.03 | 1.3313 | 0.0534 |  21.79 KB |        3.27 |
| LoopsWithPresize     |  2.167 μs | 0.0353 μs | 0.0331 μs |  1.00 |    0.02 | 0.4082 |      - |   6.66 KB |        1.00 |
