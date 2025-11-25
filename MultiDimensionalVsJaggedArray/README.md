# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Size | Mean        | Error      | StdDev     | Ratio | RatioSD |
|-------------------------------------- |----- |------------:|-----------:|-----------:|------:|--------:|
| SumJagged                             | 1000 |   777.12 μs |   5.389 μs |   4.777 μs |  0.78 |    0.01 |
| SumMultiDimensional                   | 1000 |   998.21 μs |   7.282 μs |   6.811 μs |  1.00 |    0.01 |
| SumMultiDimensionalReversedIndexes    | 1000 | 1,297.29 μs |   6.755 μs |   6.318 μs |  1.30 |    0.01 |
| SumJaggedReversedIndexes              | 1000 | 1,458.37 μs |   5.600 μs |   4.964 μs |  1.46 |    0.01 |
| SumJaggedOptimizedKozi                | 1000 |   355.94 μs |   1.780 μs |   1.665 μs |  0.36 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | 1000 |   741.44 μs |   2.900 μs |   2.712 μs |  0.74 |    0.01 |
| SumJaggedLocalVariableGoose           | 1000 |   633.27 μs |   3.172 μs |   2.967 μs |  0.63 |    0.01 |
| SumHandrolledAkseli                   | 1000 |    18.97 μs |   0.131 μs |   0.122 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | 1000 | 1,925.28 μs |  12.515 μs |  11.094 μs |  1.93 |    0.02 |
| SumMultiDimensionalLinq               | 1000 | 9,992.71 μs | 186.254 μs | 165.109 μs | 10.01 |    0.17 |
