# Goose wants to see what Yield does.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method      | Count | Mean        | Error      | StdDev       | Median      | Ratio  | RatioSD | Allocated | Alloc Ratio |
|------------ |------ |------------:|-----------:|-------------:|------------:|-------:|--------:|----------:|------------:|
| NoYield     | 10000 |    15.62 μs |   0.092 μs |     0.086 μs |    15.65 μs |   1.00 |    0.01 |         - |          NA |
| TaskYield   | 10000 | 1,829.40 μs |  36.111 μs |    66.934 μs | 1,796.56 μs | 117.15 |    4.29 |     168 B |          NA |
| ThreadYield | 10000 | 4,779.08 μs | 817.697 μs | 2,359.243 μs | 4,423.06 μs | 306.04 |  150.36 |         - |          NA |
