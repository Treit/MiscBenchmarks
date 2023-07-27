# Summing up multi-dimensional and jagged arrays.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]   : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|                                                         Method | Size |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |
|--------------------------------------------------------------- |----- |------------:|----------:|----------:|------------:|------:|--------:|
|                                                      SumJagged | 1000 |   656.52 μs | 12.389 μs | 11.589 μs |   659.74 μs |  0.46 |    0.01 |
|                                            SumMultiDimensional | 1000 | 1,416.91 μs | 23.876 μs | 24.519 μs | 1,408.40 μs |  1.00 |    0.00 |
|                             SumMultiDimensionalReversedIndexes | 1000 | 1,469.45 μs | 27.170 μs | 35.329 μs | 1,463.73 μs |  1.04 |    0.04 |
|                                       SumJaggedReversedIndexes | 1000 | 1,188.58 μs | 10.744 μs |  9.524 μs | 1,188.44 μs |  0.84 |    0.02 |
|                                         SumJaggedOptimizedKozi | 1000 |   382.84 μs |  7.414 μs | 13.369 μs |   379.14 μs |  0.27 |    0.01 |
|                          SumMultiDimensionalLocalVariableGoose | 1000 |   941.39 μs | 30.009 μs | 81.642 μs |   914.51 μs |  0.67 |    0.05 |
|                                    SumJaggedLocalVariableGoose | 1000 |   606.43 μs | 11.959 μs | 18.967 μs |   602.77 μs |  0.43 |    0.01 |
|                                        SumWithReadOnlySpanKozi | 1000 |   390.13 μs |  9.156 μs | 25.522 μs |   381.65 μs |  0.27 |    0.01 |
|                                       SumMultiDimensionalAkari | 1000 |   410.88 μs |  6.320 μs |  5.603 μs |   411.64 μs |  0.29 |    0.00 |
|                                 SumMultiDimensionalVectorAkari | 1000 |   177.44 μs |  3.164 μs |  2.470 μs |   178.04 μs |  0.12 |    0.00 |
|                              SumMultiDimensionalVector256Akari | 1000 |    78.57 μs |  1.407 μs |  1.316 μs |    78.66 μs |  0.06 |    0.00 |
|                       SumMultiDimensionalVector256AkariNoFixed | 1000 |    79.38 μs |  1.535 μs |  1.436 μs |    78.95 μs |  0.06 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | 1000 |    35.28 μs |  0.992 μs |  2.877 μs |    34.35 μs |  0.02 |    0.00 |
|                                            SumHandrolledAkseli | 1000 |   628.30 μs | 20.024 μs | 57.129 μs |   611.17 μs |  0.46 |    0.05 |
|                                    SumHandrolledAkseliJuly2023 | 1000 |    26.43 μs |  0.627 μs |  1.790 μs |    26.19 μs |  0.02 |    0.00 |
