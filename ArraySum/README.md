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
| SumJagged                                                      | 1000 |   768.45 μs | 3.380 μs | 2.639 μs |  0.77 |
| SumMultiDimensional                                            | 1000 | 1,001.21 μs | 7.655 μs | 7.161 μs |  1.00 |
| SumMultiDimensionalReversedIndexes                             | 1000 | 1,299.19 μs | 8.048 μs | 7.134 μs |  1.30 |
| SumJaggedReversedIndexes                                       | 1000 | 1,475.30 μs | 4.880 μs | 4.565 μs |  1.47 |
| SumJaggedOptimizedKozi                                         | 1000 |   354.50 μs | 1.789 μs | 1.673 μs |  0.35 |
| SumMultiDimensionalLocalVariableGoose                          | 1000 |   738.24 μs | 6.167 μs | 5.467 μs |  0.74 |
| SumJaggedLocalVariableGoose                                    | 1000 |   632.90 μs | 3.653 μs | 3.238 μs |  0.63 |
| SumWithReadOnlySpanKozi                                        | 1000 |   323.20 μs | 3.227 μs | 3.019 μs |  0.32 |
| SumMultiDimensionalAkari                                       | 1000 |   327.51 μs | 1.976 μs | 1.849 μs |  0.33 |
| SumMultiDimensionalVectorAkari                                 | 1000 |    78.71 μs | 0.474 μs | 0.443 μs |  0.08 |
| SumMultiDimensionalVector256Akari                              | 1000 |   102.64 μs | 0.324 μs | 0.303 μs |  0.10 |
| SumMultiDimensionalVector256AkariNoFixed                       | 1000 |   102.56 μs | 0.312 μs | 0.277 μs |  0.10 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | 1000 |    35.20 μs | 0.259 μs | 0.242 μs |  0.04 |
| SumHandrolledAkseli                                            | 1000 |   640.71 μs | 3.958 μs | 3.702 μs |  0.64 |
| SumHandrolledAkseliJuly2023                                    | 1000 |    19.09 μs | 0.192 μs | 0.180 μs |  0.02 |
