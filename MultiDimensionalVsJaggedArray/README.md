# Multidimensional vs. Jagged arrays.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22621.963)
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET SDK=7.0.101
  [Host]   : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|                                Method |      Job |  Runtime |  Size |           Mean |         Error |        StdDev | Ratio | RatioSD |
|-------------------------------------- |--------- |--------- |------ |---------------:|--------------:|--------------:|------:|--------:|
|                             **SumJagged** | **.NET 6.0** | **.NET 6.0** |   **100** |       **5.229 μs** |     **0.0386 μs** |     **0.0361 μs** |  **0.67** |    **0.01** |
|                   SumMultiDimensional | .NET 6.0 | .NET 6.0 |   100 |       7.824 μs |     0.0599 μs |     0.0561 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | .NET 6.0 | .NET 6.0 |   100 |       7.937 μs |     0.0540 μs |     0.0505 μs |  1.01 |    0.01 |
|              SumJaggedReversedIndexes | .NET 6.0 | .NET 6.0 |   100 |       7.524 μs |     0.0492 μs |     0.0460 μs |  0.96 |    0.01 |
|                SumJaggedOptimizedKozi | .NET 6.0 | .NET 6.0 |   100 |       3.488 μs |     0.0340 μs |     0.0318 μs |  0.45 |    0.01 |
| SumMultiDimensionalLocalVariableGoose | .NET 6.0 | .NET 6.0 |   100 |       7.817 μs |     0.0499 μs |     0.0467 μs |  1.00 |    0.01 |
|           SumJaggedLocalVariableGoose | .NET 6.0 | .NET 6.0 |   100 |       5.356 μs |     0.0197 μs |     0.0153 μs |  0.69 |    0.00 |
|               SumWithReadOnlySpanKozi | .NET 6.0 | .NET 6.0 |   100 |       3.649 μs |     0.0334 μs |     0.0313 μs |  0.47 |    0.00 |
|                                       |          |          |       |                |               |               |       |         |
|                             SumJagged | .NET 7.0 | .NET 7.0 |   100 |       5.297 μs |     0.0651 μs |     0.0609 μs |  0.70 |    0.01 |
|                   SumMultiDimensional | .NET 7.0 | .NET 7.0 |   100 |       7.515 μs |     0.0773 μs |     0.0724 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | .NET 7.0 | .NET 7.0 |   100 |       7.479 μs |     0.0269 μs |     0.0252 μs |  1.00 |    0.01 |
|              SumJaggedReversedIndexes | .NET 7.0 | .NET 7.0 |   100 |       5.261 μs |     0.0390 μs |     0.0365 μs |  0.70 |    0.01 |
|                SumJaggedOptimizedKozi | .NET 7.0 | .NET 7.0 |   100 |       3.055 μs |     0.0489 μs |     0.0433 μs |  0.41 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 7.0 | .NET 7.0 |   100 |       6.899 μs |     0.0253 μs |     0.0236 μs |  0.92 |    0.01 |
|           SumJaggedLocalVariableGoose | .NET 7.0 | .NET 7.0 |   100 |       4.308 μs |     0.0527 μs |     0.0493 μs |  0.57 |    0.01 |
|               SumWithReadOnlySpanKozi | .NET 7.0 | .NET 7.0 |   100 |       3.392 μs |     0.0229 μs |     0.0203 μs |  0.45 |    0.01 |
|                                       |          |          |       |                |               |               |       |         |
|                             **SumJagged** | **.NET 6.0** | **.NET 6.0** |  **1024** |     **736.766 μs** |     **6.5381 μs** |     **6.1157 μs** |  **0.98** |    **0.01** |
|                   SumMultiDimensional | .NET 6.0 | .NET 6.0 |  1024 |     753.608 μs |     2.7567 μs |     2.4438 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | .NET 6.0 | .NET 6.0 |  1024 |   1,405.924 μs |     6.6482 μs |     6.2187 μs |  1.87 |    0.01 |
|              SumJaggedReversedIndexes | .NET 6.0 | .NET 6.0 |  1024 |   1,116.438 μs |    17.7404 μs |    16.5944 μs |  1.48 |    0.02 |
|                SumJaggedOptimizedKozi | .NET 6.0 | .NET 6.0 |  1024 |     331.057 μs |     2.0865 μs |     1.9517 μs |  0.44 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 6.0 | .NET 6.0 |  1024 |     753.972 μs |     2.5553 μs |     2.2652 μs |  1.00 |    0.00 |
|           SumJaggedLocalVariableGoose | .NET 6.0 | .NET 6.0 |  1024 |     494.811 μs |     1.4782 μs |     1.3827 μs |  0.66 |    0.00 |
|               SumWithReadOnlySpanKozi | .NET 6.0 | .NET 6.0 |  1024 |     330.456 μs |     1.6505 μs |     1.4631 μs |  0.44 |    0.00 |
|                                       |          |          |       |                |               |               |       |         |
|                             SumJagged | .NET 7.0 | .NET 7.0 |  1024 |     497.046 μs |     1.9148 μs |     1.7911 μs |  0.67 |    0.00 |
|                   SumMultiDimensional | .NET 7.0 | .NET 7.0 |  1024 |     737.240 μs |     2.2224 μs |     2.0788 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | .NET 7.0 | .NET 7.0 |  1024 |   1,377.274 μs |     7.9794 μs |     7.4640 μs |  1.87 |    0.01 |
|              SumJaggedReversedIndexes | .NET 7.0 | .NET 7.0 |  1024 |   1,078.852 μs |     6.1590 μs |     5.7611 μs |  1.46 |    0.01 |
|                SumJaggedOptimizedKozi | .NET 7.0 | .NET 7.0 |  1024 |     289.663 μs |     5.0505 μs |     4.7243 μs |  0.39 |    0.01 |
| SumMultiDimensionalLocalVariableGoose | .NET 7.0 | .NET 7.0 |  1024 |     658.256 μs |     3.6787 μs |     3.4410 μs |  0.89 |    0.01 |
|           SumJaggedLocalVariableGoose | .NET 7.0 | .NET 7.0 |  1024 |     391.192 μs |     3.9553 μs |     3.6998 μs |  0.53 |    0.00 |
|               SumWithReadOnlySpanKozi | .NET 7.0 | .NET 7.0 |  1024 |     328.456 μs |     2.5369 μs |     2.3730 μs |  0.45 |    0.00 |
|                                       |          |          |       |                |               |               |       |         |
|                             **SumJagged** | **.NET 6.0** | **.NET 6.0** | **10000** |  **48,111.721 μs** |   **453.8158 μs** |   **424.4996 μs** |  **0.67** |    **0.01** |
|                   SumMultiDimensional | .NET 6.0 | .NET 6.0 | 10000 |  71,974.604 μs |   321.8351 μs |   285.2984 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | .NET 6.0 | .NET 6.0 | 10000 | 505,647.629 μs | 2,989.5745 μs | 2,650.1799 μs |  7.03 |    0.05 |
|              SumJaggedReversedIndexes | .NET 6.0 | .NET 6.0 | 10000 | 778,438.680 μs | 7,245.1250 μs | 6,777.0944 μs | 10.81 |    0.11 |
|                SumJaggedOptimizedKozi | .NET 6.0 | .NET 6.0 | 10000 |  32,324.928 μs |   197.0462 μs |   184.3172 μs |  0.45 |    0.00 |
| SumMultiDimensionalLocalVariableGoose | .NET 6.0 | .NET 6.0 | 10000 |  72,626.379 μs |   733.1746 μs |   685.8120 μs |  1.01 |    0.01 |
|           SumJaggedLocalVariableGoose | .NET 6.0 | .NET 6.0 | 10000 |  47,571.844 μs |   246.2574 μs |   218.3008 μs |  0.66 |    0.00 |
|               SumWithReadOnlySpanKozi | .NET 6.0 | .NET 6.0 | 10000 |  32,070.442 μs |   121.7791 μs |   101.6911 μs |  0.45 |    0.00 |
|                                       |          |          |       |                |               |               |       |         |
|                             SumJagged | .NET 7.0 | .NET 7.0 | 10000 |  71,074.632 μs |   954.4777 μs |   892.8190 μs |  1.00 |    0.01 |
|                   SumMultiDimensional | .NET 7.0 | .NET 7.0 | 10000 |  70,892.392 μs |   515.9842 μs |   482.6519 μs |  1.00 |    0.00 |
|    SumMultiDimensionalReversedIndexes | .NET 7.0 | .NET 7.0 | 10000 | 491,363.607 μs | 4,255.7360 μs | 3,980.8181 μs |  6.93 |    0.08 |
|              SumJaggedReversedIndexes | .NET 7.0 | .NET 7.0 | 10000 | 721,255.931 μs | 3,007.4979 μs | 2,511.3970 μs | 10.17 |    0.07 |
|                SumJaggedOptimizedKozi | .NET 7.0 | .NET 7.0 | 10000 |  33,348.209 μs |   405.0813 μs |   378.9133 μs |  0.47 |    0.01 |
| SumMultiDimensionalLocalVariableGoose | .NET 7.0 | .NET 7.0 | 10000 |  63,144.844 μs |   615.1640 μs |   575.4248 μs |  0.89 |    0.01 |
|           SumJaggedLocalVariableGoose | .NET 7.0 | .NET 7.0 | 10000 |  35,904.367 μs |   201.1412 μs |   178.3064 μs |  0.51 |    0.01 |
|               SumWithReadOnlySpanKozi | .NET 7.0 | .NET 7.0 | 10000 |  34,327.886 μs |   141.9823 μs |   132.8104 μs |  0.48 |    0.00 |