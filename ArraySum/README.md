# Summing up multi-dimensional and jagged arrays.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25290.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]   : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|                                                         Method | Size |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |
|--------------------------------------------------------------- |----- |------------:|----------:|-----------:|------------:|------:|--------:|
|                                                      SumJagged | 1000 |   910.02 μs | 28.102 μs |  82.859 μs |   900.93 μs |  0.51 |    0.05 |
|                                            SumMultiDimensional | 1000 | 1,775.90 μs | 40.525 μs | 119.490 μs | 1,756.25 μs |  1.00 |    0.00 |
|                             SumMultiDimensionalReversedIndexes | 1000 | 1,944.56 μs | 67.447 μs | 197.809 μs | 1,888.41 μs |  1.10 |    0.12 |
|                                       SumJaggedReversedIndexes | 1000 | 1,458.00 μs | 27.633 μs |  75.178 μs | 1,451.68 μs |  0.83 |    0.07 |
|                                         SumJaggedOptimizedKozi | 1000 |   488.59 μs |  9.635 μs |  21.549 μs |   488.49 μs |  0.28 |    0.02 |
|                          SumMultiDimensionalLocalVariableGoose | 1000 | 1,310.38 μs | 51.095 μs | 150.656 μs | 1,307.08 μs |  0.74 |    0.11 |
|                                    SumJaggedLocalVariableGoose | 1000 |   786.31 μs | 19.140 μs |  56.435 μs |   777.50 μs |  0.44 |    0.04 |
|                                        SumWithReadOnlySpanKozi | 1000 |   460.74 μs | 12.655 μs |  37.115 μs |   454.24 μs |  0.26 |    0.03 |
|                                       SumMultiDimensionalAkari | 1000 |   488.90 μs |  9.655 μs |  20.366 μs |   484.13 μs |  0.28 |    0.02 |
|                                 SumMultiDimensionalVectorAkari | 1000 |   237.72 μs |  6.456 μs |  18.730 μs |   235.89 μs |  0.13 |    0.01 |
|                              SumMultiDimensionalVector256Akari | 1000 |    82.96 μs |  1.644 μs |   1.957 μs |    82.60 μs |  0.05 |    0.00 |
|                       SumMultiDimensionalVector256AkariNoFixed | 1000 |    82.98 μs |  1.277 μs |   1.132 μs |    83.31 μs |  0.05 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | 1000 |    40.04 μs |  1.142 μs |   3.348 μs |    39.75 μs |  0.02 |    0.00 |
|                                            SumHandrolledAkseli | 1000 |   771.79 μs | 26.011 μs |  75.463 μs |   752.15 μs |  0.44 |    0.05 |
