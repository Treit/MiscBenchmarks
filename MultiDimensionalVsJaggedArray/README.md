# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27754.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Size | Mean        | Error     | StdDev    | Ratio | RatioSD |
|-------------------------------------- |----- |------------:|----------:|----------:|------:|--------:|
| SumJagged                             | 1000 |   847.43 μs | 16.109 μs | 17.906 μs |  0.60 |    0.02 |
| SumMultiDimensional                   | 1000 | 1,413.66 μs | 27.125 μs | 24.046 μs |  1.00 |    0.00 |
| SumMultiDimensionalReversedIndexes    | 1000 | 1,426.43 μs | 12.537 μs | 10.469 μs |  1.01 |    0.02 |
| SumJaggedReversedIndexes              | 1000 | 1,194.14 μs | 17.759 μs | 15.743 μs |  0.85 |    0.02 |
| SumJaggedOptimizedKozi                | 1000 |   397.44 μs |  7.643 μs | 10.204 μs |  0.28 |    0.01 |
| SumMultiDimensionalLocalVariableGoose | 1000 |   894.91 μs | 16.899 μs | 17.354 μs |  0.64 |    0.02 |
| SumJaggedLocalVariableGoose           | 1000 |   460.05 μs |  9.179 μs | 11.609 μs |  0.33 |    0.01 |
| SumHandrolledAkseli                   | 1000 |    21.73 μs |  0.430 μs |  0.402 μs |  0.02 |    0.00 |
