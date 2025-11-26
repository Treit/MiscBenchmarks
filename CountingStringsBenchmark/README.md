## Counting strings




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Count   | Mean             | Error          | StdDev         | Ratio | RatioSD |
|----------------------------------------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
| **ForLoopCountUsingLengthEqualsZero**              | **10**      |         **9.688 ns** |      **0.0505 ns** |      **0.0472 ns** |  **0.97** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 10      |         9.365 ns |      0.0708 ns |      0.0662 ns |  0.94 |    0.02 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 10      |        30.526 ns |      0.2071 ns |      0.1938 ns |  3.06 |    0.05 |
| ForLoopCountUsingEmptyStringLiteral            | 10      |         9.979 ns |      0.1694 ns |      0.1501 ns |  1.00 |    0.02 |
| ForLoopCountUsingStringDotEmpty                | 10      |         9.916 ns |      0.1871 ns |      0.1750 ns |  0.99 |    0.02 |
| ForEachLoopCountUsingLengthEqualsZero          | 10      |         8.951 ns |      0.0656 ns |      0.0614 ns |  0.90 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 10      |        10.307 ns |      0.1399 ns |      0.1240 ns |  1.03 |    0.02 |
| ForEachLoopCountUsingStringDotEmpty            | 10      |        10.401 ns |      0.1763 ns |      0.1563 ns |  1.04 |    0.02 |
| ForLoopCountUsingIsNullOrEmpty                 | 10      |         9.096 ns |      0.0644 ns |      0.0602 ns |  0.91 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 10      |        46.367 ns |      0.4553 ns |      0.3802 ns |  4.65 |    0.08 |
| CountUsingLinqWhereLengthEqualsZero            | 10      |        35.360 ns |      0.5235 ns |      0.4371 ns |  3.54 |    0.07 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **100**     |       **104.640 ns** |      **1.3152 ns** |      **1.2302 ns** |  **1.03** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 100     |        90.597 ns |      0.6598 ns |      0.6171 ns |  0.89 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 100     |       247.476 ns |      1.6741 ns |      1.5659 ns |  2.44 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | 100     |       101.539 ns |      0.6414 ns |      0.6000 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 100     |       101.435 ns |      0.6259 ns |      0.5854 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 100     |        81.351 ns |      0.4658 ns |      0.4129 ns |  0.80 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 100     |       102.506 ns |      1.3199 ns |      1.2347 ns |  1.01 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | 100     |       102.391 ns |      2.0103 ns |      1.8804 ns |  1.01 |    0.02 |
| ForLoopCountUsingIsNullOrEmpty                 | 100     |        88.475 ns |      0.6465 ns |      0.5731 ns |  0.87 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 100     |       336.409 ns |      2.0436 ns |      1.8116 ns |  3.31 |    0.03 |
| CountUsingLinqWhereLengthEqualsZero            | 100     |       240.060 ns |      2.5352 ns |      2.3714 ns |  2.36 |    0.03 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **1000**    |       **932.394 ns** |     **18.3360 ns** |     **23.8420 ns** |  **1.00** |    **0.03** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000    |       814.587 ns |      3.3745 ns |      3.1565 ns |  0.87 |    0.00 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 1000    |     2,406.937 ns |     13.7787 ns |     12.8886 ns |  2.58 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | 1000    |       933.901 ns |      3.3284 ns |      2.9505 ns |  1.00 |    0.00 |
| ForLoopCountUsingStringDotEmpty                | 1000    |       932.975 ns |      3.1881 ns |      2.8262 ns |  1.00 |    0.00 |
| ForEachLoopCountUsingLengthEqualsZero          | 1000    |       808.351 ns |      3.0397 ns |      2.5383 ns |  0.87 |    0.00 |
| ForEachLoopCountUsingEmptyStringLiteral        | 1000    |     1,009.010 ns |      7.1923 ns |      6.7276 ns |  1.08 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | 1000    |     1,009.160 ns |      8.3271 ns |      7.7891 ns |  1.08 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | 1000    |       812.734 ns |      3.1161 ns |      2.9148 ns |  0.87 |    0.00 |
| CountUsingLinqWhereEmptyStringLiteral          | 1000    |     3,186.813 ns |     10.5747 ns |      8.8303 ns |  3.41 |    0.01 |
| CountUsingLinqWhereLengthEqualsZero            | 1000    |     2,221.627 ns |     19.3905 ns |     18.1379 ns |  2.38 |    0.02 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **100000**  |    **95,415.436 ns** |  **2,267.3194 ns** |  **6,685.2429 ns** |  **1.03** |    **0.07** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 100000  |    81,688.585 ns |    480.8422 ns |    449.7801 ns |  0.88 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 100000  |   244,984.134 ns |  2,008.3975 ns |  1,878.6563 ns |  2.64 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | 100000  |    92,782.877 ns |    548.5327 ns |    486.2599 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 100000  |    92,909.279 ns |    583.0914 ns |    545.4241 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 100000  |    79,362.453 ns |    776.4602 ns |    726.3014 ns |  0.86 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 100000  |    92,850.028 ns |  1,825.5285 ns |  2,029.0701 ns |  1.00 |    0.02 |
| ForEachLoopCountUsingStringDotEmpty            | 100000  |    93,153.643 ns |  1,810.6604 ns |  2,223.6538 ns |  1.00 |    0.02 |
| ForLoopCountUsingIsNullOrEmpty                 | 100000  |    81,776.525 ns |    503.7605 ns |    420.6628 ns |  0.88 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 100000  |   316,718.569 ns |  2,257.6313 ns |  2,001.3313 ns |  3.41 |    0.03 |
| CountUsingLinqWhereLengthEqualsZero            | 100000  |   221,901.719 ns |    745.4499 ns |    581.9982 ns |  2.39 |    0.01 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **1000000** | **1,717,190.381 ns** |  **8,963.4370 ns** |  **6,998.0620 ns** |  **0.98** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000000 | 1,667,191.992 ns | 13,221.3008 ns | 11,720.3387 ns |  0.95 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 1000000 | 2,709,041.146 ns | 20,228.1122 ns | 18,921.3887 ns |  1.55 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | 1000000 | 1,750,447.214 ns | 15,985.0140 ns | 14,952.3921 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 1000000 | 1,707,260.749 ns | 13,197.3556 ns | 12,344.8147 ns |  0.98 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 1000000 | 1,728,521.836 ns | 26,190.7752 ns | 24,498.8674 ns |  0.99 |    0.02 |
| ForEachLoopCountUsingEmptyStringLiteral        | 1000000 | 1,804,940.319 ns | 14,485.7355 ns | 13,549.9660 ns |  1.03 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | 1000000 | 1,767,639.704 ns | 15,246.7363 ns | 13,515.8346 ns |  1.01 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | 1000000 | 1,682,569.907 ns | 10,136.9148 ns |  8,464.7830 ns |  0.96 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 1000000 | 3,028,928.542 ns | 15,691.4657 ns | 14,677.8067 ns |  1.73 |    0.02 |
| CountUsingLinqWhereLengthEqualsZero            | 1000000 | 2,439,947.552 ns | 20,659.3368 ns | 19,324.7564 ns |  1.39 |    0.02 |
