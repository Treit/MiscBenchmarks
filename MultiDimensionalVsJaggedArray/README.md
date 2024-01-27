# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26040.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                Method | Size |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |
|-------------------------------------- |----- |------------:|----------:|----------:|------------:|------:|--------:|
|                             SumJagged | 1000 |   689.56 μs | 13.873 μs | 39.355 μs |   675.06 μs |  0.49 |    0.03 |
|                   SumMultiDimensional | 1000 | 1,428.13 μs | 22.552 μs | 18.832 μs | 1,430.06 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | 1000 | 1,487.09 μs | 29.279 μs | 54.993 μs | 1,470.62 μs |  1.03 |    0.04 |
|              SumJaggedReversedIndexes | 1000 | 1,203.60 μs | 20.537 μs | 17.149 μs | 1,199.12 μs |  0.84 |    0.02 |
|                SumJaggedOptimizedKozi | 1000 |   423.07 μs |  8.397 μs | 23.128 μs |   419.00 μs |  0.30 |    0.02 |
| SumMultiDimensionalLocalVariableGoose | 1000 |   963.75 μs | 19.180 μs | 51.526 μs |   956.75 μs |  0.68 |    0.04 |
|           SumJaggedLocalVariableGoose | 1000 |   623.68 μs | 12.300 μs | 17.243 μs |   624.29 μs |  0.43 |    0.01 |
|                   SumHandrolledAkseli | 1000 |    22.53 μs |  0.447 μs |  0.882 μs |    22.30 μs |  0.02 |    0.00 |
