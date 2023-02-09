# Multidimensional vs. Jagged arrays.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25290.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]   : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|                                Method | Size |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |
|-------------------------------------- |----- |-----------:|---------:|----------:|-----------:|------:|--------:|
|                             SumJagged | 1000 |   878.7 μs | 23.66 μs |  68.63 μs |   878.5 μs |  0.49 |    0.05 |
|                   SumMultiDimensional | 1000 | 1,786.0 μs | 35.76 μs | 105.43 μs | 1,770.0 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | 1000 | 1,985.2 μs | 69.17 μs | 202.88 μs | 1,953.9 μs |  1.11 |    0.13 |
|              SumJaggedReversedIndexes | 1000 | 1,472.4 μs | 32.92 μs |  97.06 μs | 1,454.8 μs |  0.83 |    0.08 |
|                SumJaggedOptimizedKozi | 1000 |   494.2 μs | 15.13 μs |  44.62 μs |   488.7 μs |  0.28 |    0.03 |
| SumMultiDimensionalLocalVariableGoose | 1000 | 1,142.8 μs | 26.44 μs |  77.56 μs | 1,147.3 μs |  0.64 |    0.06 |
|           SumJaggedLocalVariableGoose | 1000 |   740.2 μs | 18.92 μs |  55.48 μs |   728.6 μs |  0.42 |    0.04 |
|               SumWithReadOnlySpanKozi | 1000 |   470.2 μs | 13.36 μs |  38.32 μs |   457.1 μs |  0.26 |    0.03 |
|              SumMultiDimensionalAkari | 1000 |   493.4 μs | 11.78 μs |  33.60 μs |   488.5 μs |  0.28 |    0.02 |
|                   SumHandrolledAkseli | 1000 |   739.6 μs | 16.55 μs |  48.03 μs |   735.7 μs |  0.41 |    0.03 |
|         SumHandRolledVectorizedAkseli | 1000 |   194.0 μs |  2.77 μs |   2.45 μs |   194.7 μs |  0.11 |    0.01 |
