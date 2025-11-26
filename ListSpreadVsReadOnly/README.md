# ListSpreadVsReadOnly



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------ |------ |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| ExpressionBodyWithItems | 100   | 5.217 μs | 0.0704 μs | 0.0658 μs |  1.00 |    0.02 | 1.6251 |  26.56 KB |        1.00 |
| ExpressionBodyEmpty     | 100   | 1.945 μs | 0.0281 μs | 0.0263 μs |  0.37 |    0.01 | 0.7172 |  11.72 KB |        0.44 |
| IReadOnlyListWithItems  | 100   | 4.202 μs | 0.0561 μs | 0.0497 μs |  0.81 |    0.01 | 1.0452 |  17.19 KB |        0.65 |
| IReadOnlyListEmpty      | 100   | 1.563 μs | 0.0230 μs | 0.0215 μs |  0.30 |    0.01 | 0.5245 |   8.59 KB |        0.32 |
| FrozenSetWithItems      | 100   | 4.118 μs | 0.0666 μs | 0.0623 μs |  0.79 |    0.02 | 1.0452 |  17.19 KB |        0.65 |
| FrozenSetEmpty          | 100   | 1.561 μs | 0.0267 μs | 0.0250 μs |  0.30 |    0.01 | 0.5245 |   8.59 KB |        0.32 |
