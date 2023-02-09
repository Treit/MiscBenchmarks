# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.


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
|                             SumJagged | 1000 |   810.6 μs | 16.14 μs |  43.07 μs |   798.7 μs |  0.46 |    0.03 |
|                   SumMultiDimensional | 1000 | 1,749.9 μs | 38.89 μs | 114.06 μs | 1,723.8 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | 1000 | 1,775.8 μs | 35.40 μs |  63.83 μs | 1,769.7 μs |  1.02 |    0.07 |
|              SumJaggedReversedIndexes | 1000 | 1,480.7 μs | 46.69 μs | 136.94 μs | 1,433.5 μs |  0.85 |    0.09 |
|                SumJaggedOptimizedKozi | 1000 |   478.3 μs | 10.40 μs |  29.16 μs |   473.1 μs |  0.27 |    0.02 |
| SumMultiDimensionalLocalVariableGoose | 1000 | 1,169.1 μs | 28.50 μs |  83.14 μs | 1,157.1 μs |  0.67 |    0.06 |
|           SumJaggedLocalVariableGoose | 1000 |   735.6 μs | 14.71 μs |  39.52 μs |   727.3 μs |  0.42 |    0.03 |
