# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.






```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27754.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Size | Mean         | Error      | StdDev     | Ratio | RatioSD |
|-------------------------------------- |----- |-------------:|-----------:|-----------:|------:|--------:|
| SumJagged                             | 1000 |    819.20 μs |   8.579 μs |   6.698 μs |  0.60 |    0.01 |
| SumMultiDimensional                   | 1000 |  1,363.50 μs |  27.255 μs |  24.161 μs |  1.00 |    0.00 |
| SumMultiDimensionalReversedIndexes    | 1000 |  1,418.16 μs |  19.525 μs |  16.304 μs |  1.04 |    0.02 |
| SumJaggedReversedIndexes              | 1000 |  1,159.40 μs |  19.064 μs |  15.920 μs |  0.85 |    0.02 |
| SumJaggedOptimizedKozi                | 1000 |    365.38 μs |   6.323 μs |   5.605 μs |  0.27 |    0.01 |
| SumMultiDimensionalLocalVariableGoose | 1000 |    830.75 μs |   3.389 μs |   3.004 μs |  0.61 |    0.01 |
| SumJaggedLocalVariableGoose           | 1000 |    445.29 μs |   8.754 μs |  15.785 μs |  0.33 |    0.01 |
| SumHandrolledAkseli                   | 1000 |     20.64 μs |   0.401 μs |   0.446 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | 1000 |  2,566.02 μs |  46.246 μs |  38.617 μs |  1.89 |    0.04 |
| SumMultiDimensionalLinq               | 1000 | 42,335.00 μs | 752.722 μs | 628.557 μs | 31.16 |    0.72 |
