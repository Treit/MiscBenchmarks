# Summing up multi-dimensional and jagged arrays.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                         | Job       | Runtime   | Size | Mean        | Error     | StdDev    | Ratio | RatioSD |
|--------------------------------------------------------------- |---------- |---------- |----- |------------:|----------:|----------:|------:|--------:|
| SumJagged                                                      | .NET 10.0 | .NET 10.0 | 1000 |   787.06 μs |  6.698 μs |  5.938 μs |  0.74 |    0.01 |
| SumMultiDimensional                                            | .NET 10.0 | .NET 10.0 | 1000 | 1,065.35 μs | 10.633 μs |  9.947 μs |  1.00 |    0.01 |
| SumMultiDimensionalReversedIndexes                             | .NET 10.0 | .NET 10.0 | 1000 | 1,373.37 μs |  5.448 μs |  5.096 μs |  1.29 |    0.01 |
| SumJaggedReversedIndexes                                       | .NET 10.0 | .NET 10.0 | 1000 | 1,462.63 μs |  8.283 μs |  7.748 μs |  1.37 |    0.01 |
| SumJaggedOptimizedKozi                                         | .NET 10.0 | .NET 10.0 | 1000 |   352.37 μs |  2.713 μs |  2.265 μs |  0.33 |    0.00 |
| SumMultiDimensionalLocalVariableGoose                          | .NET 10.0 | .NET 10.0 | 1000 |   743.67 μs |  9.527 μs |  8.445 μs |  0.70 |    0.01 |
| SumJaggedLocalVariableGoose                                    | .NET 10.0 | .NET 10.0 | 1000 |   632.91 μs |  3.867 μs |  3.618 μs |  0.59 |    0.01 |
| SumWithReadOnlySpanKozi                                        | .NET 10.0 | .NET 10.0 | 1000 |   333.31 μs |  4.003 μs |  3.744 μs |  0.31 |    0.00 |
| SumMultiDimensionalAkari                                       | .NET 10.0 | .NET 10.0 | 1000 |   316.62 μs |  2.092 μs |  1.957 μs |  0.30 |    0.00 |
| SumMultiDimensionalVectorAkari                                 | .NET 10.0 | .NET 10.0 | 1000 |    78.55 μs |  0.508 μs |  0.475 μs |  0.07 |    0.00 |
| SumMultiDimensionalVector256Akari                              | .NET 10.0 | .NET 10.0 | 1000 |   102.65 μs |  0.352 μs |  0.329 μs |  0.10 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixed                       | .NET 10.0 | .NET 10.0 | 1000 |   102.76 μs |  0.303 μs |  0.284 μs |  0.10 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | .NET 10.0 | .NET 10.0 | 1000 |    34.93 μs |  0.223 μs |  0.209 μs |  0.03 |    0.00 |
| SumHandrolledAkseli                                            | .NET 10.0 | .NET 10.0 | 1000 |   705.78 μs |  4.078 μs |  3.815 μs |  0.66 |    0.01 |
| SumHandrolledAkseliJuly2023                                    | .NET 10.0 | .NET 10.0 | 1000 |    18.90 μs |  0.145 μs |  0.135 μs |  0.02 |    0.00 |
|                                                                |           |           |      |             |           |           |       |         |
| SumJagged                                                      | .NET 9.0  | .NET 9.0  | 1000 |   781.29 μs |  4.303 μs |  4.025 μs |  0.74 |    0.01 |
| SumMultiDimensional                                            | .NET 9.0  | .NET 9.0  | 1000 | 1,056.40 μs |  8.800 μs |  8.232 μs |  1.00 |    0.01 |
| SumMultiDimensionalReversedIndexes                             | .NET 9.0  | .NET 9.0  | 1000 | 1,377.96 μs |  7.253 μs |  6.784 μs |  1.30 |    0.01 |
| SumJaggedReversedIndexes                                       | .NET 9.0  | .NET 9.0  | 1000 | 1,494.80 μs | 29.634 μs | 34.127 μs |  1.42 |    0.03 |
| SumJaggedOptimizedKozi                                         | .NET 9.0  | .NET 9.0  | 1000 |   359.30 μs |  7.145 μs |  7.645 μs |  0.34 |    0.01 |
| SumMultiDimensionalLocalVariableGoose                          | .NET 9.0  | .NET 9.0  | 1000 |   744.00 μs |  7.877 μs |  7.368 μs |  0.70 |    0.01 |
| SumJaggedLocalVariableGoose                                    | .NET 9.0  | .NET 9.0  | 1000 |   633.42 μs |  5.197 μs |  4.861 μs |  0.60 |    0.01 |
| SumWithReadOnlySpanKozi                                        | .NET 9.0  | .NET 9.0  | 1000 |   334.75 μs |  3.061 μs |  2.714 μs |  0.32 |    0.00 |
| SumMultiDimensionalAkari                                       | .NET 9.0  | .NET 9.0  | 1000 |   331.21 μs |  2.988 μs |  2.795 μs |  0.31 |    0.00 |
| SumMultiDimensionalVectorAkari                                 | .NET 9.0  | .NET 9.0  | 1000 |    78.74 μs |  0.491 μs |  0.459 μs |  0.07 |    0.00 |
| SumMultiDimensionalVector256Akari                              | .NET 9.0  | .NET 9.0  | 1000 |   102.64 μs |  0.289 μs |  0.270 μs |  0.10 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixed                       | .NET 9.0  | .NET 9.0  | 1000 |   102.55 μs |  0.365 μs |  0.342 μs |  0.10 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | .NET 9.0  | .NET 9.0  | 1000 |    34.96 μs |  0.270 μs |  0.253 μs |  0.03 |    0.00 |
| SumHandrolledAkseli                                            | .NET 9.0  | .NET 9.0  | 1000 |   705.21 μs |  4.239 μs |  3.965 μs |  0.67 |    0.01 |
| SumHandrolledAkseliJuly2023                                    | .NET 9.0  | .NET 9.0  | 1000 |    18.94 μs |  0.141 μs |  0.132 μs |  0.02 |    0.00 |
