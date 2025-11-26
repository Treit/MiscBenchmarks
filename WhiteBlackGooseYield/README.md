# Goose wants to see what Yield does.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method      | Count | Mean        | Error     | StdDev    | Ratio  | RatioSD | Allocated | Alloc Ratio |
|------------ |------ |------------:|----------:|----------:|-------:|--------:|----------:|------------:|
| NoYield     | 10000 |    15.67 μs |  0.135 μs |  0.126 μs |   1.00 |    0.01 |         - |          NA |
| TaskYield   | 10000 | 1,860.15 μs | 35.241 μs | 31.240 μs | 118.71 |    2.14 |     168 B |          NA |
| ThreadYield | 10000 | 1,949.33 μs | 16.434 μs | 15.372 μs | 124.40 |    1.36 |         - |          NA |
