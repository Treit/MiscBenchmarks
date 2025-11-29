# ListSpreadVsReadOnly




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------------ |---------- |---------- |------ |---------:|----------:|----------:|------:|-------:|----------:|------------:|
| ExpressionBodyWithItems | .NET 10.0 | .NET 10.0 | 100   | 5.228 μs | 0.0424 μs | 0.0376 μs |  1.00 | 1.6251 |  26.56 KB |        1.00 |
| ExpressionBodyEmpty     | .NET 10.0 | .NET 10.0 | 100   | 1.945 μs | 0.0378 μs | 0.0517 μs |  0.37 | 0.7172 |  11.72 KB |        0.44 |
| IReadOnlyListWithItems  | .NET 10.0 | .NET 10.0 | 100   | 4.364 μs | 0.0840 μs | 0.0745 μs |  0.83 | 1.0452 |  17.19 KB |        0.65 |
| IReadOnlyListEmpty      | .NET 10.0 | .NET 10.0 | 100   | 1.558 μs | 0.0190 μs | 0.0159 μs |  0.30 | 0.5245 |   8.59 KB |        0.32 |
| FrozenSetWithItems      | .NET 10.0 | .NET 10.0 | 100   | 4.260 μs | 0.0482 μs | 0.0451 μs |  0.81 | 1.0452 |  17.19 KB |        0.65 |
| FrozenSetEmpty          | .NET 10.0 | .NET 10.0 | 100   | 1.542 μs | 0.0107 μs | 0.0090 μs |  0.29 | 0.5245 |   8.59 KB |        0.32 |
|                         |           |           |       |          |           |           |       |        |           |             |
| ExpressionBodyWithItems | .NET 9.0  | .NET 9.0  | 100   | 5.143 μs | 0.0432 μs | 0.0383 μs |  1.00 | 1.6251 |  26.56 KB |        1.00 |
| ExpressionBodyEmpty     | .NET 9.0  | .NET 9.0  | 100   | 1.917 μs | 0.0192 μs | 0.0180 μs |  0.37 | 0.7172 |  11.72 KB |        0.44 |
| IReadOnlyListWithItems  | .NET 9.0  | .NET 9.0  | 100   | 4.150 μs | 0.0249 μs | 0.0221 μs |  0.81 | 1.0452 |  17.19 KB |        0.65 |
| IReadOnlyListEmpty      | .NET 9.0  | .NET 9.0  | 100   | 1.537 μs | 0.0098 μs | 0.0092 μs |  0.30 | 0.5245 |   8.59 KB |        0.32 |
| FrozenSetWithItems      | .NET 9.0  | .NET 9.0  | 100   | 4.065 μs | 0.0411 μs | 0.0384 μs |  0.79 | 1.0452 |  17.19 KB |        0.65 |
| FrozenSetEmpty          | .NET 9.0  | .NET 9.0  | 100   | 1.537 μs | 0.0163 μs | 0.0136 μs |  0.30 | 0.5245 |   8.59 KB |        0.32 |
