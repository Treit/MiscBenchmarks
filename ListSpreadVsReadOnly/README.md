# ListSpreadVsReadOnly


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.28000.1199)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.10 (9.0.1025.47515), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                  | Count | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------ |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| ExpressionBodyWithItems | 100   | 9.718 μs | 0.3575 μs | 1.0372 μs | 9.360 μs |  1.01 |    0.15 | 6.3019 |  26.56 KB |        1.00 |
| ExpressionBodyEmpty     | 100   | 3.588 μs | 0.0707 μs | 0.1257 μs | 3.581 μs |  0.37 |    0.04 | 2.7809 |  11.72 KB |        0.44 |
| IReadOnlyListWithItems  | 100   | 7.578 μs | 0.2273 μs | 0.6631 μs | 7.455 μs |  0.79 |    0.10 | 4.0741 |  17.19 KB |        0.65 |
| IReadOnlyListEmpty      | 100   | 3.201 μs | 0.1303 μs | 0.3782 μs | 3.104 μs |  0.33 |    0.05 | 2.0370 |   8.59 KB |        0.32 |
| FrozenSetWithItems      | 100   | 7.657 μs | 0.1789 μs | 0.5162 μs | 7.580 μs |  0.80 |    0.10 | 4.0741 |  17.19 KB |        0.65 |
| FrozenSetEmpty          | 100   | 3.245 μs | 0.0830 μs | 0.2341 μs | 3.216 μs |  0.34 |    0.04 | 2.0370 |   8.59 KB |        0.32 |
