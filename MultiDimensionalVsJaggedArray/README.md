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
|                             SumJagged | 1000 |   890.9 μs | 19.07 μs |  56.21 μs |   893.5 μs |  0.50 |    0.05 |
|                   SumMultiDimensional | 1000 | 1,782.5 μs | 35.54 μs |  77.26 μs | 1,776.7 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | 1000 | 1,870.3 μs | 45.29 μs | 130.67 μs | 1,838.6 μs |  1.06 |    0.08 |
|              SumJaggedReversedIndexes | 1000 | 1,384.5 μs | 27.58 μs |  35.87 μs | 1,381.2 μs |  0.77 |    0.04 |
|                SumJaggedOptimizedKozi | 1000 |   514.8 μs | 16.22 μs |  47.56 μs |   517.9 μs |  0.28 |    0.03 |
| SumMultiDimensionalLocalVariableGoose | 1000 | 1,152.2 μs | 30.92 μs |  88.73 μs | 1,143.0 μs |  0.66 |    0.06 |
|           SumJaggedLocalVariableGoose | 1000 |   673.7 μs | 13.10 μs |  20.40 μs |   671.9 μs |  0.37 |    0.02 |
|               SumWithReadOnlySpanKozi | 1000 |   475.2 μs | 13.01 μs |  38.16 μs |   463.2 μs |  0.26 |    0.02 |
|              SumMultiDimensionalAkari | 1000 |   492.5 μs | 10.29 μs |  29.53 μs |   488.9 μs |  0.28 |    0.02 |
|                   SumHandrolledAkseli | 1000 |   797.5 μs | 38.59 μs | 113.79 μs |   750.6 μs |  0.45 |    0.08 |
