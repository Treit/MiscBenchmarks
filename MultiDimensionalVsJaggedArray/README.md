# Multidimensional vs. Jagged arrays.

See the ArraySum benchmark for some other results.










```

BenchmarkDotNet v0.16.0-preview.1, Windows 11 (10.0.22631.7582/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 63.95 GB Total, 44.36 GB Available
.NET SDK 11.0.100-rc.1.26425.128
  [Host]     : .NET 11.0.0 (11.0.0-rc.1.26425.128, 11.0.26.42628), X64 RyuJIT x86-64-v3
  Job-GFMUFT : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3
  Job-TQQVBQ : .NET 11.0.0 (11.0.0-rc.1.26425.128, 11.0.26.42628), X64 RyuJIT x86-64-v3

Arguments=/p:BenchmarkTargeting=true  

```
| Method                                | Runtime   | Size | Mean         | Error      | StdDev     | Ratio | RatioSD |
|-------------------------------------- |---------- |----- |-------------:|-----------:|-----------:|------:|--------:|
| SumJagged                             | .NET 10.0 | 1000 |    800.02 μs |   8.182 μs |   7.253 μs |  0.77 |    0.01 |
| SumMultiDimensional                   | .NET 10.0 | 1000 |  1,033.21 μs |  11.170 μs |  10.448 μs |  1.00 |    0.00 |
| SumMultiDimensionalReversedIndexes    | .NET 10.0 | 1000 |  1,335.12 μs |  13.430 μs |  12.562 μs |  1.29 |    0.02 |
| SumJaggedReversedIndexes              | .NET 10.0 | 1000 |  1,503.65 μs |  11.656 μs |  10.333 μs |  1.46 |    0.02 |
| SumJaggedOptimizedKozi                | .NET 10.0 | 1000 |    361.09 μs |   3.224 μs |   2.858 μs |  0.35 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 10.0 | 1000 |    763.78 μs |  12.020 μs |  10.656 μs |  0.74 |    0.01 |
| SumJaggedLocalVariableGoose           | .NET 10.0 | 1000 |    649.72 μs |   8.146 μs |   6.802 μs |  0.63 |    0.01 |
| SumHandrolledAkseli                   | .NET 10.0 | 1000 |     19.45 μs |   0.135 μs |   0.126 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | .NET 10.0 | 1000 |  1,970.77 μs |  20.237 μs |  17.940 μs |  1.91 |    0.03 |
| SumMultiDimensionalLinq               | .NET 10.0 | 1000 | 10,167.03 μs | 139.406 μs | 123.580 μs |  9.84 |    0.15 |
| SumSpan2DLocalVariableForEach         | .NET 10.0 | 1000 |    652.82 μs |   5.970 μs |   5.584 μs |  0.63 |    0.01 |
| SumSpan2DLocalVariableIndex           | .NET 10.0 | 1000 |    652.48 μs |   6.471 μs |   6.053 μs |  0.63 |    0.01 |
|                                       |           |      |              |            |            |       |         |
| SumJagged                             | .NET 11.0 | 1000 |    794.57 μs |   5.629 μs |   4.395 μs |  0.73 |    0.01 |
| SumMultiDimensional                   | .NET 11.0 | 1000 |  1,094.40 μs |  12.085 μs |  11.305 μs |  1.00 |    0.00 |
| SumMultiDimensionalReversedIndexes    | .NET 11.0 | 1000 |  1,446.91 μs |  26.863 μs |  25.128 μs |  1.32 |    0.03 |
| SumJaggedReversedIndexes              | .NET 11.0 | 1000 |  1,512.82 μs |  15.654 μs |  14.643 μs |  1.38 |    0.02 |
| SumJaggedOptimizedKozi                | .NET 11.0 | 1000 |    365.36 μs |   4.470 μs |   4.181 μs |  0.33 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 11.0 | 1000 |    767.86 μs |   9.978 μs |   8.332 μs |  0.70 |    0.01 |
| SumJaggedLocalVariableGoose           | .NET 11.0 | 1000 |    653.47 μs |   6.556 μs |   6.133 μs |  0.60 |    0.01 |
| SumHandrolledAkseli                   | .NET 11.0 | 1000 |     19.40 μs |   0.153 μs |   0.136 μs |  0.02 |    0.00 |
| SumJaggedLinq                         | .NET 11.0 | 1000 |  1,966.04 μs |  20.679 μs |  19.343 μs |  1.80 |    0.02 |
| SumMultiDimensionalLinq               | .NET 11.0 | 1000 | 10,758.54 μs | 205.231 μs | 201.565 μs |  9.83 |    0.20 |
| SumSpan2DLocalVariableForEach         | .NET 11.0 | 1000 |    649.13 μs |   4.714 μs |   4.410 μs |  0.59 |    0.01 |
| SumSpan2DLocalVariableIndex           | .NET 11.0 | 1000 |    652.73 μs |   8.016 μs |   7.106 μs |  0.60 |    0.01 |
