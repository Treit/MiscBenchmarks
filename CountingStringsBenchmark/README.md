## Counting strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22463
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                         Method |   Count |            Mean |            Error |         StdDev | Ratio | RatioSD |
|----------------------------------------------- |-------- |----------------:|-----------------:|---------------:|------:|--------:|
|              **ForLoopCountUsingLengthEqualsZero** |      **10** |        **14.86 ns** |        **17.133 ns** |       **0.939 ns** |  **0.46** |    **0.03** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |      10 |        13.16 ns |        16.342 ns |       0.896 ns |  0.40 |    0.02 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |      10 |        22.99 ns |         8.962 ns |       0.491 ns |  0.71 |    0.02 |
|            ForLoopCountUsingEmptyStringLiteral |      10 |        32.49 ns |         6.712 ns |       0.368 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |      10 |        40.43 ns |        19.059 ns |       1.045 ns |  1.24 |    0.03 |
|          ForEachLoopCountUsingLengthEqualsZero |      10 |        59.18 ns |        13.503 ns |       0.740 ns |  1.82 |    0.03 |
|        ForEachLoopCountUsingEmptyStringLiteral |      10 |        81.58 ns |        15.111 ns |       0.828 ns |  2.51 |    0.02 |
|            ForEachLoopCountUsingStringDotEmpty |      10 |        77.92 ns |        28.103 ns |       1.540 ns |  2.40 |    0.07 |
|                 ForLoopCountUsingIsNullOrEmpty |      10 |        14.51 ns |         3.465 ns |       0.190 ns |  0.45 |    0.01 |
|          CountUsingLinqWhereEmptyStringLiteral |      10 |        90.78 ns |        75.952 ns |       4.163 ns |  2.79 |    0.14 |
|            CountUsingLinqWhereLengthEqualsZero |      10 |        71.53 ns |        35.422 ns |       1.942 ns |  2.20 |    0.06 |
|                                                |         |                 |                  |                |       |         |
|              **ForLoopCountUsingLengthEqualsZero** |     **100** |       **130.46 ns** |        **30.573 ns** |       **1.676 ns** |  **0.34** |    **0.06** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |     100 |       131.29 ns |        76.808 ns |       4.210 ns |  0.34 |    0.07 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |     100 |       228.60 ns |       107.254 ns |       5.879 ns |  0.59 |    0.10 |
|            ForLoopCountUsingEmptyStringLiteral |     100 |       393.62 ns |     1,491.388 ns |      81.748 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |     100 |       416.58 ns |       684.451 ns |      37.517 ns |  1.09 |    0.27 |
|          ForEachLoopCountUsingLengthEqualsZero |     100 |       448.61 ns |       199.312 ns |      10.925 ns |  1.17 |    0.24 |
|        ForEachLoopCountUsingEmptyStringLiteral |     100 |       732.12 ns |       338.861 ns |      18.574 ns |  1.92 |    0.40 |
|            ForEachLoopCountUsingStringDotEmpty |     100 |       804.55 ns |       306.149 ns |      16.781 ns |  2.09 |    0.36 |
|                 ForLoopCountUsingIsNullOrEmpty |     100 |       144.74 ns |       149.831 ns |       8.213 ns |  0.38 |    0.09 |
|          CountUsingLinqWhereEmptyStringLiteral |     100 |       521.26 ns |       666.709 ns |      36.545 ns |  1.36 |    0.30 |
|            CountUsingLinqWhereLengthEqualsZero |     100 |       334.15 ns |       260.454 ns |      14.276 ns |  0.87 |    0.17 |
|                                                |         |                 |                  |                |       |         |
|              **ForLoopCountUsingLengthEqualsZero** |    **1000** |     **1,369.41 ns** |     **1,052.789 ns** |      **57.707 ns** |  **0.36** |    **0.03** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |    1000 |     1,418.30 ns |       899.839 ns |      49.323 ns |  0.37 |    0.01 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |    1000 |     2,319.83 ns |     1,387.024 ns |      76.027 ns |  0.61 |    0.01 |
|            ForLoopCountUsingEmptyStringLiteral |    1000 |     3,792.07 ns |     3,381.720 ns |     185.363 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |    1000 |     3,856.43 ns |       175.930 ns |       9.643 ns |  1.02 |    0.05 |
|          ForEachLoopCountUsingLengthEqualsZero |    1000 |     4,123.44 ns |       780.448 ns |      42.779 ns |  1.09 |    0.06 |
|        ForEachLoopCountUsingEmptyStringLiteral |    1000 |     7,721.44 ns |     1,375.936 ns |      75.420 ns |  2.04 |    0.12 |
|            ForEachLoopCountUsingStringDotEmpty |    1000 |     7,239.80 ns |     2,461.560 ns |     134.926 ns |  1.91 |    0.06 |
|                 ForLoopCountUsingIsNullOrEmpty |    1000 |     1,508.91 ns |       713.393 ns |      39.103 ns |  0.40 |    0.02 |
|          CountUsingLinqWhereEmptyStringLiteral |    1000 |     4,543.22 ns |     1,731.213 ns |      94.894 ns |  1.20 |    0.08 |
|            CountUsingLinqWhereLengthEqualsZero |    1000 |     2,704.77 ns |       451.970 ns |      24.774 ns |  0.71 |    0.04 |
|                                                |         |                 |                  |                |       |         |
|              **ForLoopCountUsingLengthEqualsZero** |  **100000** |   **164,119.17 ns** |   **136,708.474 ns** |   **7,493.453 ns** |  **0.49** |    **0.02** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |  100000 |   158,877.75 ns |    88,827.349 ns |   4,868.927 ns |  0.47 |    0.00 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |  100000 |   249,793.42 ns |   357,039.465 ns |  19,570.538 ns |  0.75 |    0.08 |
|            ForLoopCountUsingEmptyStringLiteral |  100000 |   334,669.06 ns |   222,391.128 ns |  12,190.008 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |  100000 |   395,725.46 ns |   196,639.200 ns |  10,778.458 ns |  1.18 |    0.06 |
|          ForEachLoopCountUsingLengthEqualsZero |  100000 |   440,902.90 ns |    78,054.647 ns |   4,278.439 ns |  1.32 |    0.06 |
|        ForEachLoopCountUsingEmptyStringLiteral |  100000 |   718,218.21 ns |   187,283.582 ns |  10,265.645 ns |  2.15 |    0.05 |
|            ForEachLoopCountUsingStringDotEmpty |  100000 |   776,621.63 ns |   549,504.903 ns |  30,120.218 ns |  2.32 |    0.01 |
|                 ForLoopCountUsingIsNullOrEmpty |  100000 |   162,762.04 ns |    42,569.017 ns |   2,333.351 ns |  0.49 |    0.02 |
|          CountUsingLinqWhereEmptyStringLiteral |  100000 |   398,692.73 ns |    42,154.938 ns |   2,310.654 ns |  1.19 |    0.04 |
|            CountUsingLinqWhereLengthEqualsZero |  100000 |   283,709.59 ns |   199,009.159 ns |  10,908.364 ns |  0.85 |    0.01 |
|                                                |         |                 |                  |                |       |         |
|              **ForLoopCountUsingLengthEqualsZero** | **1000000** | **3,771,292.84 ns** | **2,321,924.990 ns** | **127,272.544 ns** |  **0.88** |    **0.03** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000000 | 3,636,951.30 ns | 1,441,576.908 ns |  79,017.695 ns |  0.85 |    0.01 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch | 1000000 | 4,015,237.24 ns | 1,732,758.983 ns |  94,978.367 ns |  0.94 |    0.02 |
|            ForLoopCountUsingEmptyStringLiteral | 1000000 | 4,293,148.44 ns |   696,583.631 ns |  38,182.099 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty | 1000000 | 4,746,605.99 ns | 1,988,887.121 ns | 109,017.614 ns |  1.11 |    0.02 |
|          ForEachLoopCountUsingLengthEqualsZero | 1000000 | 5,527,450.52 ns | 9,594,842.037 ns | 525,925.668 ns |  1.29 |    0.13 |
|        ForEachLoopCountUsingEmptyStringLiteral | 1000000 | 7,940,907.29 ns |   798,182.235 ns |  43,751.062 ns |  1.85 |    0.01 |
|            ForEachLoopCountUsingStringDotEmpty | 1000000 | 7,817,611.46 ns | 4,636,638.464 ns | 254,149.800 ns |  1.82 |    0.08 |
|                 ForLoopCountUsingIsNullOrEmpty | 1000000 | 3,658,824.48 ns | 2,943,548.516 ns | 161,345.827 ns |  0.85 |    0.04 |
|          CountUsingLinqWhereEmptyStringLiteral | 1000000 | 4,581,021.09 ns | 1,374,380.923 ns |  75,334.456 ns |  1.07 |    0.01 |
|            CountUsingLinqWhereLengthEqualsZero | 1000000 | 3,905,742.19 ns | 3,047,263.333 ns | 167,030.786 ns |  0.91 |    0.03 |
