# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.









```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Job       | Runtime   | Size | Mean        | Error      | StdDev     | Ratio | RatioSD |
|-------------------------------------- |---------- |---------- |----- |------------:|-----------:|-----------:|------:|--------:|
| SumJagged                             | .NET 10.0 | .NET 10.0 | 1000 |   772.50 μs |   2.114 μs |   1.765 μs |  0.73 |    0.00 |
| SumMultiDimensional                   | .NET 10.0 | .NET 10.0 | 1000 | 1,055.97 μs |   7.111 μs |   6.652 μs |  1.00 |    0.01 |
| SumMultiDimensionalReversedIndexes    | .NET 10.0 | .NET 10.0 | 1000 | 1,362.25 μs |   1.780 μs |   1.578 μs |  1.29 |    0.01 |
| SumJaggedReversedIndexes              | .NET 10.0 | .NET 10.0 | 1000 | 1,445.38 μs |   1.250 μs |   1.169 μs |  1.37 |    0.01 |
| SumJaggedOptimizedKozi                | .NET 10.0 | .NET 10.0 | 1000 |   348.68 μs |   0.647 μs |   0.540 μs |  0.33 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 10.0 | .NET 10.0 | 1000 |   735.83 μs |   2.182 μs |   1.934 μs |  0.70 |    0.00 |
| SumJaggedLocalVariableGoose           | .NET 10.0 | .NET 10.0 | 1000 |   628.18 μs |   1.721 μs |   1.610 μs |  0.59 |    0.00 |
| SumHandrolledAkseli                   | .NET 10.0 | .NET 10.0 | 1000 |    18.86 μs |   0.061 μs |   0.057 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | .NET 10.0 | .NET 10.0 | 1000 | 1,914.60 μs |   6.622 μs |   6.194 μs |  1.81 |    0.01 |
| SumMultiDimensionalLinq               | .NET 10.0 | .NET 10.0 | 1000 | 9,660.54 μs | 189.369 μs | 194.468 μs |  9.15 |    0.19 |
|                                       |           |           |      |             |            |            |       |         |
| SumJagged                             | .NET 9.0  | .NET 9.0  | 1000 |   769.26 μs |   2.899 μs |   2.711 μs |  0.73 |    0.00 |
| SumMultiDimensional                   | .NET 9.0  | .NET 9.0  | 1000 | 1,047.28 μs |   4.724 μs |   4.188 μs |  1.00 |    0.01 |
| SumMultiDimensionalReversedIndexes    | .NET 9.0  | .NET 9.0  | 1000 | 1,369.13 μs |   1.761 μs |   1.561 μs |  1.31 |    0.01 |
| SumJaggedReversedIndexes              | .NET 9.0  | .NET 9.0  | 1000 | 1,455.18 μs |   1.359 μs |   1.061 μs |  1.39 |    0.01 |
| SumJaggedOptimizedKozi                | .NET 9.0  | .NET 9.0  | 1000 |   348.52 μs |   0.340 μs |   0.302 μs |  0.33 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 9.0  | .NET 9.0  | 1000 |   731.73 μs |   0.716 μs |   0.559 μs |  0.70 |    0.00 |
| SumJaggedLocalVariableGoose           | .NET 9.0  | .NET 9.0  | 1000 |   627.30 μs |   0.713 μs |   0.632 μs |  0.60 |    0.00 |
| SumHandrolledAkseli                   | .NET 9.0  | .NET 9.0  | 1000 |    19.10 μs |   0.062 μs |   0.058 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | .NET 9.0  | .NET 9.0  | 1000 | 1,904.90 μs |   4.709 μs |   4.174 μs |  1.82 |    0.01 |
| SumMultiDimensionalLinq               | .NET 9.0  | .NET 9.0  | 1000 | 9,711.61 μs |  74.044 μs |  65.638 μs |  9.27 |    0.07 |
