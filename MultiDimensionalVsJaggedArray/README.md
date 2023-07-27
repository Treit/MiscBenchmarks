# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25915.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]   : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|                                Method | Size |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |
|-------------------------------------- |----- |------------:|----------:|----------:|------------:|------:|--------:|
|                             SumJagged | 1000 |   722.21 μs | 23.234 μs | 67.035 μs |   695.12 μs |  0.52 |    0.05 |
|                   SumMultiDimensional | 1000 | 1,437.16 μs | 28.442 μs | 29.207 μs | 1,437.84 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | 1000 | 1,439.54 μs |  8.796 μs | 10.802 μs | 1,441.57 μs |  1.00 |    0.02 |
|              SumJaggedReversedIndexes | 1000 | 1,214.34 μs | 23.650 μs | 39.514 μs | 1,197.64 μs |  0.86 |    0.04 |
|                SumJaggedOptimizedKozi | 1000 |   374.74 μs |  6.732 μs |  8.988 μs |   370.66 μs |  0.26 |    0.01 |
| SumMultiDimensionalLocalVariableGoose | 1000 |   877.99 μs | 16.468 μs | 16.174 μs |   878.36 μs |  0.61 |    0.02 |
|           SumJaggedLocalVariableGoose | 1000 |   584.54 μs | 11.655 μs | 10.332 μs |   581.78 μs |  0.41 |    0.01 |
|                   SumHandrolledAkseli | 1000 |    26.92 μs |  0.683 μs |  1.991 μs |    26.29 μs |  0.02 |    0.00 |
