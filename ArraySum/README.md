# Summing up multi-dimensional and jagged arrays.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                         | Size | Mean        | Error    | StdDev   | Ratio |
|--------------------------------------------------------------- |----- |------------:|---------:|---------:|------:|
| SumJagged                                                      | 1000 |   769.79 μs | 3.644 μs | 3.230 μs |  0.77 |
| SumMultiDimensional                                            | 1000 | 1,004.11 μs | 7.241 μs | 5.653 μs |  1.00 |
| SumMultiDimensionalReversedIndexes                             | 1000 | 1,297.72 μs | 6.940 μs | 6.491 μs |  1.29 |
| SumJaggedReversedIndexes                                       | 1000 | 1,452.31 μs | 7.128 μs | 6.668 μs |  1.45 |
| SumJaggedOptimizedKozi                                         | 1000 |   355.45 μs | 2.080 μs | 1.844 μs |  0.35 |
| SumMultiDimensionalLocalVariableGoose                          | 1000 |   740.76 μs | 3.911 μs | 3.266 μs |  0.74 |
| SumJaggedLocalVariableGoose                                    | 1000 |   633.47 μs | 4.574 μs | 4.279 μs |  0.63 |
| SumWithReadOnlySpanKozi                                        | 1000 |   333.02 μs | 3.956 μs | 3.303 μs |  0.33 |
| SumMultiDimensionalAkari                                       | 1000 |   326.23 μs | 2.598 μs | 2.431 μs |  0.32 |
| SumMultiDimensionalVectorAkari                                 | 1000 |    78.77 μs | 0.314 μs | 0.294 μs |  0.08 |
| SumMultiDimensionalVector256Akari                              | 1000 |   102.84 μs | 0.279 μs | 0.261 μs |  0.10 |
| SumMultiDimensionalVector256AkariNoFixed                       | 1000 |   102.82 μs | 0.291 μs | 0.272 μs |  0.10 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | 1000 |    35.11 μs | 0.244 μs | 0.228 μs |  0.03 |
| SumHandrolledAkseli                                            | 1000 |   643.44 μs | 4.359 μs | 4.078 μs |  0.64 |
| SumHandrolledAkseliJuly2023                                    | 1000 |    19.07 μs | 0.119 μs | 0.111 μs |  0.02 |
