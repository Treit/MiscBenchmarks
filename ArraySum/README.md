# Summing up multi-dimensional and jagged arrays.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27798.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                         | Size | Mean        | Error      | StdDev     | Median      | Ratio | RatioSD |
|--------------------------------------------------------------- |----- |------------:|-----------:|-----------:|------------:|------:|--------:|
| SumJagged                                                      | 1000 | 1,385.51 μs |  26.812 μs |  30.876 μs | 1,389.64 μs |  0.62 |    0.05 |
| SumMultiDimensional                                            | 1000 | 2,040.09 μs |  84.530 μs | 249.238 μs | 2,111.74 μs |  1.00 |    0.00 |
| SumMultiDimensionalReversedIndexes                             | 1000 | 2,070.78 μs | 147.614 μs | 435.244 μs | 1,944.07 μs |  1.02 |    0.21 |
| SumJaggedReversedIndexes                                       | 1000 | 1,394.45 μs |  35.457 μs | 104.545 μs | 1,398.08 μs |  0.69 |    0.09 |
| SumJaggedOptimizedKozi                                         | 1000 |   417.68 μs |   8.348 μs |  22.570 μs |   413.38 μs |  0.21 |    0.03 |
| SumMultiDimensionalLocalVariableGoose                          | 1000 |   948.79 μs |  21.467 μs |  61.247 μs |   938.35 μs |  0.47 |    0.07 |
| SumJaggedLocalVariableGoose                                    | 1000 |   475.71 μs |  11.496 μs |  33.169 μs |   463.60 μs |  0.24 |    0.03 |
| SumWithReadOnlySpanKozi                                        | 1000 |   419.49 μs |  11.317 μs |  33.368 μs |   407.85 μs |  0.21 |    0.04 |
| SumMultiDimensionalAkari                                       | 1000 |   404.99 μs |  14.135 μs |  41.008 μs |   390.40 μs |  0.20 |    0.04 |
| SumMultiDimensionalVectorAkari                                 | 1000 |   124.33 μs |   2.404 μs |   2.672 μs |   125.29 μs |  0.06 |    0.00 |
| SumMultiDimensionalVector256Akari                              | 1000 |    78.75 μs |   1.278 μs |   1.196 μs |    78.72 μs |  0.04 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixed                       | 1000 |    80.18 μs |   1.527 μs |   2.377 μs |    79.61 μs |  0.04 |    0.00 |
| SumMultiDimensionalVector256AkariNoFixedWithIntermediateShorts | 1000 |    32.47 μs |   0.744 μs |   2.121 μs |    31.67 μs |  0.02 |    0.00 |
| SumHandrolledAkseli                                            | 1000 |   617.21 μs |  13.938 μs |  40.216 μs |   603.56 μs |  0.31 |    0.04 |
| SumHandrolledAkseliJuly2023                                    | 1000 |    21.67 μs |   0.406 μs |   1.146 μs |    21.33 μs |  0.01 |    0.00 |
