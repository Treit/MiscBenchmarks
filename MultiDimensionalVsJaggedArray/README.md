# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Size | Mean         | Error     | StdDev    | Ratio | RatioSD |
|-------------------------------------- |----- |-------------:|----------:|----------:|------:|--------:|
| SumJagged                             | 1000 |    771.10 μs |  3.577 μs |  3.171 μs |  0.77 |    0.01 |
| SumMultiDimensional                   | 1000 |  1,002.83 μs |  8.329 μs |  7.384 μs |  1.00 |    0.01 |
| SumMultiDimensionalReversedIndexes    | 1000 |  1,304.17 μs | 10.052 μs |  9.403 μs |  1.30 |    0.01 |
| SumJaggedReversedIndexes              | 1000 |  1,462.12 μs |  6.839 μs |  6.063 μs |  1.46 |    0.01 |
| SumJaggedOptimizedKozi                | 1000 |    357.27 μs |  3.361 μs |  3.144 μs |  0.36 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | 1000 |    739.16 μs |  4.217 μs |  3.521 μs |  0.74 |    0.01 |
| SumJaggedLocalVariableGoose           | 1000 |    634.68 μs |  2.624 μs |  2.455 μs |  0.63 |    0.01 |
| SumHandrolledAkseli                   | 1000 |     19.01 μs |  0.137 μs |  0.128 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | 1000 |  1,919.58 μs |  6.712 μs |  5.950 μs |  1.91 |    0.01 |
| SumMultiDimensionalLinq               | 1000 | 10,025.97 μs | 94.219 μs | 88.132 μs | 10.00 |    0.11 |
