# Combining data into a dictionary



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Job       | Runtime   | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------- |---------- |---------- |----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| OriginalLinqApproach | .NET 10.0 | .NET 10.0 | 10.732 μs | 0.1275 μs | 0.1193 μs |  5.00 |    0.07 | 0.7782 | 0.0153 |  12.95 KB |        1.94 |
| LoopWithoutPresize   | .NET 10.0 | .NET 10.0 |  3.807 μs | 0.0471 μs | 0.0441 μs |  1.77 |    0.03 | 1.3313 | 0.0534 |  21.79 KB |        3.27 |
| LoopsWithPresize     | .NET 10.0 | .NET 10.0 |  2.149 μs | 0.0255 μs | 0.0226 μs |  1.00 |    0.01 | 0.4082 |      - |   6.66 KB |        1.00 |
|                      |           |           |           |           |           |       |         |        |        |           |             |
| OriginalLinqApproach | .NET 9.0  | .NET 9.0  | 10.668 μs | 0.1438 μs | 0.1345 μs |  4.93 |    0.10 | 0.7782 | 0.0153 |  12.95 KB |        1.94 |
| LoopWithoutPresize   | .NET 9.0  | .NET 9.0  |  3.918 μs | 0.0770 μs | 0.0720 μs |  1.81 |    0.04 | 1.3275 | 0.0534 |  21.79 KB |        3.27 |
| LoopsWithPresize     | .NET 9.0  | .NET 9.0  |  2.163 μs | 0.0393 μs | 0.0368 μs |  1.00 |    0.02 | 0.4082 |      - |   6.66 KB |        1.00 |
