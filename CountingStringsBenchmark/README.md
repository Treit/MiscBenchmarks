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
| **ForLoopCountUsingLengthEqualsZero**              | **10**      |         **9.733 ns** |      **0.0539 ns** |      **0.0478 ns** |  **0.99** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 10      |         9.263 ns |      0.0721 ns |      0.0639 ns |  0.94 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 10      |        29.973 ns |      0.1962 ns |      0.1835 ns |  3.06 |    0.04 |
| ForLoopCountUsingEmptyStringLiteral            | 10      |         9.806 ns |      0.1346 ns |      0.1051 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 10      |         9.826 ns |      0.1044 ns |      0.0872 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 10      |         8.880 ns |      0.0620 ns |      0.0580 ns |  0.91 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 10      |        10.135 ns |      0.1084 ns |      0.0905 ns |  1.03 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | 10      |        10.091 ns |      0.0784 ns |      0.0695 ns |  1.03 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | 10      |         9.128 ns |      0.0670 ns |      0.0627 ns |  0.93 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 10      |        45.727 ns |      0.3589 ns |      0.3357 ns |  4.66 |    0.06 |
| CountUsingLinqWhereLengthEqualsZero            | 10      |        35.134 ns |      0.2617 ns |      0.2320 ns |  3.58 |    0.04 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **100**     |       **107.532 ns** |      **0.5564 ns** |      **0.5205 ns** |  **1.06** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 100     |        88.756 ns |      0.7803 ns |      0.7299 ns |  0.88 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 100     |       246.024 ns |      1.2104 ns |      1.1322 ns |  2.43 |    0.01 |
| ForLoopCountUsingEmptyStringLiteral            | 100     |       101.312 ns |      0.4555 ns |      0.4038 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 100     |       100.781 ns |      1.0673 ns |      0.9461 ns |  0.99 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 100     |        81.282 ns |      0.6166 ns |      0.5767 ns |  0.80 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 100     |       105.000 ns |      1.2695 ns |      1.1875 ns |  1.04 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | 100     |       105.832 ns |      0.7309 ns |      0.6103 ns |  1.04 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | 100     |        88.172 ns |      0.7334 ns |      0.6124 ns |  0.87 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 100     |       334.886 ns |      2.0812 ns |      1.8449 ns |  3.31 |    0.02 |
| CountUsingLinqWhereLengthEqualsZero            | 100     |       235.141 ns |      2.6609 ns |      2.4890 ns |  2.32 |    0.03 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **1000**    |     **1,008.148 ns** |     **20.0174 ns** |     **31.7497 ns** |  **1.09** |    **0.03** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000    |       811.825 ns |      4.3258 ns |      4.0463 ns |  0.88 |    0.00 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 1000    |     2,395.807 ns |     10.5349 ns |      9.8544 ns |  2.58 |    0.01 |
| ForLoopCountUsingEmptyStringLiteral            | 1000    |       926.993 ns |      1.7678 ns |      1.4762 ns |  1.00 |    0.00 |
| ForLoopCountUsingStringDotEmpty                | 1000    |       930.093 ns |      3.5284 ns |      3.1278 ns |  1.00 |    0.00 |
| ForEachLoopCountUsingLengthEqualsZero          | 1000    |       806.488 ns |      2.8495 ns |      2.5260 ns |  0.87 |    0.00 |
| ForEachLoopCountUsingEmptyStringLiteral        | 1000    |     1,005.784 ns |      7.0426 ns |      6.5877 ns |  1.08 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | 1000    |     1,008.200 ns |      7.7045 ns |      7.2068 ns |  1.09 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | 1000    |       805.700 ns |      3.3598 ns |      2.9784 ns |  0.87 |    0.00 |
| CountUsingLinqWhereEmptyStringLiteral          | 1000    |     3,150.864 ns |     13.8835 ns |     12.9866 ns |  3.40 |    0.01 |
| CountUsingLinqWhereLengthEqualsZero            | 1000    |     2,186.725 ns |     18.4559 ns |     17.2637 ns |  2.36 |    0.02 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **100000**  |    **81,717.712 ns** |    **461.4830 ns** |    **409.0927 ns** |  **0.88** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 100000  |    81,686.222 ns |    593.9890 ns |    555.6177 ns |  0.88 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 100000  |   245,657.995 ns |  1,515.8268 ns |  1,417.9053 ns |  2.65 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | 100000  |    92,875.408 ns |    593.4177 ns |    555.0832 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 100000  |    93,271.016 ns |    452.5145 ns |    423.2823 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 100000  |    79,233.466 ns |    440.2431 ns |    411.8037 ns |  0.85 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 100000  |   100,135.173 ns |  1,743.4848 ns |  1,630.8568 ns |  1.08 |    0.02 |
| ForEachLoopCountUsingStringDotEmpty            | 100000  |   100,228.186 ns |  1,929.0244 ns |  1,804.4107 ns |  1.08 |    0.02 |
| ForLoopCountUsingIsNullOrEmpty                 | 100000  |    81,730.553 ns |    466.4581 ns |    436.3252 ns |  0.88 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 100000  |   319,046.610 ns |  1,467.1216 ns |  1,300.5650 ns |  3.44 |    0.02 |
| CountUsingLinqWhereLengthEqualsZero            | 100000  |   221,331.248 ns |    656.5218 ns |    581.9895 ns |  2.38 |    0.02 |
|                                                |         |                  |                |                |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **1000000** | **1,728,311.706 ns** | **23,197.9080 ns** | **21,699.3375 ns** |  **1.00** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000000 | 1,647,346.296 ns | 14,306.1668 ns | 13,381.9973 ns |  0.95 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | 1000000 | 2,686,700.977 ns | 22,552.4400 ns | 21,095.5664 ns |  1.56 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | 1000000 | 1,725,578.620 ns | 12,211.9362 ns | 11,423.0527 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | 1000000 | 1,705,337.237 ns | 13,615.0371 ns | 11,369.1726 ns |  0.99 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | 1000000 | 1,691,370.396 ns | 13,193.9233 ns | 11,696.0693 ns |  0.98 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | 1000000 | 1,795,738.672 ns | 28,524.0747 ns | 25,285.8493 ns |  1.04 |    0.02 |
| ForEachLoopCountUsingStringDotEmpty            | 1000000 | 1,772,436.549 ns | 31,341.2231 ns | 29,316.5995 ns |  1.03 |    0.02 |
| ForLoopCountUsingIsNullOrEmpty                 | 1000000 | 1,647,316.518 ns | 10,440.6185 ns |  9,255.3363 ns |  0.95 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | 1000000 | 3,319,862.081 ns | 13,293.9510 ns | 11,784.7413 ns |  1.92 |    0.01 |
| CountUsingLinqWhereLengthEqualsZero            | 1000000 | 2,409,547.812 ns | 13,101.4669 ns | 12,255.1203 ns |  1.40 |    0.01 |
