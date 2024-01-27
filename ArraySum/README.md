# Summing up multi-dimensional and jagged arrays.




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26040.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                                         Method | Size |        Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------------------------------------------------------- |----- |------------:|----------:|----------:|------:|--------:|
|                                                      SumJagged | 1000 |   693.14 μs | 13.806 μs | 23.814 μs |  0.46 |    0.02 |
|                                            SumMultiDimensional | 1000 | 1,509.62 μs | 29.854 μs | 49.051 μs |  1.00 |    0.00 |
|                             SumMultiDimensionalReversedIndexes | 1000 | 1,517.75 μs | 29.809 μs | 26.425 μs |  1.00 |    0.03 |
|                                       SumJaggedReversedIndexes | 1000 | 1,258.01 μs | 23.398 μs | 24.028 μs |  0.83 |    0.03 |
|                                         SumJaggedOptimizedKozi | 1000 |   402.66 μs |  7.972 μs | 13.099 μs |  0.27 |    0.01 |
|                          SumMultiDimensionalLocalVariableGoose | 1000 |   946.14 μs | 23.538 μs | 66.773 μs |  0.63 |    0.05 |
|                                    SumJaggedLocalVariableGoose | 1000 |   600.06 μs | 11.769 μs | 19.337 μs |  0.40 |    0.02 |
|                                        SumWithReadOnlySpanKozi | 1000 |   381.37 μs |  7.353 μs | 10.778 μs |  0.25 |    0.01 |
|                                       SumMultiDimensionalAkari | 1000 |   409.13 μs |  7.440 μs |  9.409 μs |  0.27 |    0.01 |
|                                 SumMultiDimensionalVectorAkari | 1000 |   122.61 μs |  1.401 μs |  1.310 μs |  0.08 |    0.00 |
|                              SumMultiDimensionalVector256Akari | 1000 |    79.86 μs |  1.531 μs |  1.504 μs |  0.05 |    0.00 |
|                       SumMultiDimensionalVector256AkariNoFixed | 1000 |    81.05 μs |  1.609 μs |  2.203 μs |  0.05 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | 1000 |    32.40 μs |  0.648 μs |  1.422 μs |  0.02 |    0.00 |
|                                            SumHandrolledAkseli | 1000 |   610.91 μs | 12.192 μs | 30.588 μs |  0.40 |    0.02 |
|                                    SumHandrolledAkseliJuly2023 | 1000 |    22.04 μs |  0.438 μs |  1.032 μs |  0.01 |    0.00 |
