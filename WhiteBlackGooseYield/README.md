# Goose wants to see what Yield does.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method      | Job       | Runtime   | Count | Mean        | Error     | StdDev    | Ratio  | RatioSD | Allocated | Alloc Ratio |
|------------ |---------- |---------- |------ |------------:|----------:|----------:|-------:|--------:|----------:|------------:|
| NoYield     | .NET 10.0 | .NET 10.0 | 10000 |    15.50 μs |  0.018 μs |  0.015 μs |   1.00 |    0.00 |         - |          NA |
| TaskYield   | .NET 10.0 | .NET 10.0 | 10000 | 1,796.78 μs | 35.629 μs | 43.755 μs | 115.92 |    2.77 |     168 B |          NA |
| ThreadYield | .NET 10.0 | .NET 10.0 | 10000 | 1,919.67 μs |  1.636 μs |  1.450 μs | 123.85 |    0.15 |         - |          NA |
|             |           |           |       |             |           |           |        |         |           |             |
| NoYield     | .NET 9.0  | .NET 9.0  | 10000 |    15.52 μs |  0.038 μs |  0.036 μs |   1.00 |    0.00 |         - |          NA |
| TaskYield   | .NET 9.0  | .NET 9.0  | 10000 | 1,710.28 μs | 22.734 μs | 18.984 μs | 110.19 |    1.20 |     168 B |          NA |
| ThreadYield | .NET 9.0  | .NET 9.0  | 10000 | 1,925.84 μs |  2.626 μs |  2.328 μs | 124.08 |    0.31 |         - |          NA |
