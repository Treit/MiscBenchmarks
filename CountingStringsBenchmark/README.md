## Counting strings





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                         | Job       | Runtime   | Count   | Mean             | Error          | StdDev         | Median           | Ratio | RatioSD |
|----------------------------------------------- |---------- |---------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
| **ForLoopCountUsingLengthEqualsZero**              | **.NET 10.0** | **.NET 10.0** | **10**      |         **7.495 ns** |      **0.0685 ns** |      **0.0641 ns** |         **7.481 ns** |  **0.74** |    **0.04** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 10.0 | .NET 10.0 | 10      |         9.102 ns |      0.0926 ns |      0.0866 ns |         9.105 ns |  0.90 |    0.05 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 10.0 | .NET 10.0 | 10      |        31.509 ns |      0.6729 ns |      1.6757 ns |        31.157 ns |  3.11 |    0.23 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 10.0 | .NET 10.0 | 10      |        10.174 ns |      0.2340 ns |      0.5423 ns |         9.929 ns |  1.00 |    0.07 |
| ForLoopCountUsingStringDotEmpty                | .NET 10.0 | .NET 10.0 | 10      |         9.760 ns |      0.1497 ns |      0.1250 ns |         9.726 ns |  0.96 |    0.05 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 10.0 | .NET 10.0 | 10      |         8.568 ns |      0.0930 ns |      0.0726 ns |         8.599 ns |  0.84 |    0.04 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 10.0 | .NET 10.0 | 10      |        10.372 ns |      0.0513 ns |      0.0480 ns |        10.378 ns |  1.02 |    0.05 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 10.0 | .NET 10.0 | 10      |        10.348 ns |      0.0361 ns |      0.0320 ns |        10.359 ns |  1.02 |    0.05 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 10.0 | .NET 10.0 | 10      |         9.364 ns |      0.0667 ns |      0.0624 ns |         9.373 ns |  0.92 |    0.05 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 10.0 | .NET 10.0 | 10      |        42.550 ns |      0.3034 ns |      0.2838 ns |        42.515 ns |  4.19 |    0.21 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 10.0 | .NET 10.0 | 10      |        37.287 ns |      0.4853 ns |      0.4540 ns |        37.279 ns |  3.67 |    0.19 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| ForLoopCountUsingLengthEqualsZero              | .NET 9.0  | .NET 9.0  | 10      |         7.518 ns |      0.0977 ns |      0.0914 ns |         7.542 ns |  0.77 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 9.0  | .NET 9.0  | 10      |         9.141 ns |      0.1442 ns |      0.1204 ns |         9.142 ns |  0.94 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 9.0  | .NET 9.0  | 10      |        30.676 ns |      0.2262 ns |      0.2005 ns |        30.684 ns |  3.14 |    0.03 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 9.0  | .NET 9.0  | 10      |         9.768 ns |      0.1028 ns |      0.0858 ns |         9.763 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 9.0  | .NET 9.0  | 10      |         9.795 ns |      0.1994 ns |      0.1665 ns |         9.795 ns |  1.00 |    0.02 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 9.0  | .NET 9.0  | 10      |         8.720 ns |      0.2035 ns |      0.1904 ns |         8.655 ns |  0.89 |    0.02 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 9.0  | .NET 9.0  | 10      |        10.360 ns |      0.0627 ns |      0.0587 ns |        10.374 ns |  1.06 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 9.0  | .NET 9.0  | 10      |        10.409 ns |      0.0731 ns |      0.0684 ns |        10.426 ns |  1.07 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 9.0  | .NET 9.0  | 10      |         9.399 ns |      0.1227 ns |      0.1025 ns |         9.394 ns |  0.96 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 9.0  | .NET 9.0  | 10      |        42.653 ns |      0.4637 ns |      0.4337 ns |        42.692 ns |  4.37 |    0.06 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 9.0  | .NET 9.0  | 10      |        36.855 ns |      0.4083 ns |      0.3819 ns |        36.847 ns |  3.77 |    0.05 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **.NET 10.0** | **.NET 10.0** | **100**     |        **73.847 ns** |      **0.5753 ns** |      **0.5381 ns** |        **73.778 ns** |  **0.74** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 10.0 | .NET 10.0 | 100     |        87.594 ns |      0.6488 ns |      0.5066 ns |        87.632 ns |  0.88 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 10.0 | .NET 10.0 | 100     |       251.551 ns |      1.0950 ns |      1.0243 ns |       251.373 ns |  2.53 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 10.0 | .NET 10.0 | 100     |        99.574 ns |      0.5793 ns |      0.5135 ns |        99.572 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 10.0 | .NET 10.0 | 100     |       100.433 ns |      0.7763 ns |      0.7262 ns |       100.321 ns |  1.01 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 10.0 | .NET 10.0 | 100     |        80.806 ns |      0.9822 ns |      0.9187 ns |        80.636 ns |  0.81 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 10.0 | .NET 10.0 | 100     |       104.194 ns |      1.2787 ns |      1.1961 ns |       103.967 ns |  1.05 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 10.0 | .NET 10.0 | 100     |       103.920 ns |      0.7901 ns |      0.7391 ns |       103.905 ns |  1.04 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 10.0 | .NET 10.0 | 100     |       108.223 ns |      0.4970 ns |      0.4649 ns |       108.270 ns |  1.09 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 10.0 | .NET 10.0 | 100     |       304.459 ns |      2.4488 ns |      2.2906 ns |       305.455 ns |  3.06 |    0.03 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 10.0 | .NET 10.0 | 100     |       240.479 ns |      2.0401 ns |      1.9083 ns |       240.764 ns |  2.42 |    0.02 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| ForLoopCountUsingLengthEqualsZero              | .NET 9.0  | .NET 9.0  | 100     |        74.392 ns |      1.4800 ns |      1.6450 ns |        73.777 ns |  0.75 |    0.02 |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 9.0  | .NET 9.0  | 100     |        88.566 ns |      0.9761 ns |      0.8150 ns |        88.593 ns |  0.89 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 9.0  | .NET 9.0  | 100     |       252.046 ns |      3.2758 ns |      3.0642 ns |       251.468 ns |  2.53 |    0.03 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 9.0  | .NET 9.0  | 100     |        99.627 ns |      0.4363 ns |      0.3867 ns |        99.733 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 9.0  | .NET 9.0  | 100     |        99.991 ns |      0.8466 ns |      0.7069 ns |       100.099 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 9.0  | .NET 9.0  | 100     |        80.381 ns |      0.5812 ns |      0.5436 ns |        80.474 ns |  0.81 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 9.0  | .NET 9.0  | 100     |       103.837 ns |      1.1018 ns |      1.0307 ns |       103.562 ns |  1.04 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 9.0  | .NET 9.0  | 100     |       104.448 ns |      1.2292 ns |      1.0896 ns |       104.452 ns |  1.05 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 9.0  | .NET 9.0  | 100     |       108.998 ns |      0.8914 ns |      0.7902 ns |       108.644 ns |  1.09 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 9.0  | .NET 9.0  | 100     |       305.898 ns |      3.2446 ns |      3.0350 ns |       305.764 ns |  3.07 |    0.03 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 9.0  | .NET 9.0  | 100     |       240.226 ns |      2.5491 ns |      2.3844 ns |       240.447 ns |  2.41 |    0.02 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **.NET 10.0** | **.NET 10.0** | **1000**    |       **725.709 ns** |      **4.5220 ns** |      **4.0086 ns** |       **726.314 ns** |  **0.78** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 10.0 | .NET 10.0 | 1000    |       806.905 ns |      5.1582 ns |      4.8250 ns |       808.564 ns |  0.87 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 10.0 | .NET 10.0 | 1000    |     2,435.817 ns |     22.1076 ns |     20.6795 ns |     2,443.138 ns |  2.62 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 10.0 | .NET 10.0 | 1000    |       931.408 ns |      4.6249 ns |      4.3261 ns |       930.313 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 10.0 | .NET 10.0 | 1000    |       929.424 ns |      1.8189 ns |      1.5189 ns |       929.394 ns |  1.00 |    0.00 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 10.0 | .NET 10.0 | 1000    |       796.420 ns |      6.3927 ns |      5.9798 ns |       794.893 ns |  0.86 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 10.0 | .NET 10.0 | 1000    |       979.234 ns |     11.7508 ns |     10.4168 ns |       979.087 ns |  1.05 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 10.0 | .NET 10.0 | 1000    |       976.460 ns |     10.7256 ns |     10.0327 ns |       978.786 ns |  1.05 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 10.0 | .NET 10.0 | 1000    |     1,042.452 ns |      9.9524 ns |      9.3095 ns |     1,048.077 ns |  1.12 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 10.0 | .NET 10.0 | 1000    |     2,873.247 ns |     17.1839 ns |     15.2330 ns |     2,881.108 ns |  3.08 |    0.02 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 10.0 | .NET 10.0 | 1000    |     2,220.695 ns |     13.9790 ns |     13.0760 ns |     2,225.333 ns |  2.38 |    0.02 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| ForLoopCountUsingLengthEqualsZero              | .NET 9.0  | .NET 9.0  | 1000    |       728.235 ns |      4.7089 ns |      4.1744 ns |       729.710 ns |  0.78 |    0.00 |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 9.0  | .NET 9.0  | 1000    |       806.540 ns |      5.8601 ns |      4.8934 ns |       807.764 ns |  0.87 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 9.0  | .NET 9.0  | 1000    |     2,429.079 ns |     15.0026 ns |     14.0334 ns |     2,433.101 ns |  2.61 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 9.0  | .NET 9.0  | 1000    |       931.891 ns |      3.4691 ns |      2.8968 ns |       932.076 ns |  1.00 |    0.00 |
| ForLoopCountUsingStringDotEmpty                | .NET 9.0  | .NET 9.0  | 1000    |       934.340 ns |      5.3097 ns |      4.7069 ns |       933.697 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 9.0  | .NET 9.0  | 1000    |       786.884 ns |      4.3766 ns |      3.8797 ns |       787.211 ns |  0.84 |    0.00 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 9.0  | .NET 9.0  | 1000    |       968.548 ns |     18.1733 ns |     16.9994 ns |       968.224 ns |  1.04 |    0.02 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 9.0  | .NET 9.0  | 1000    |       977.998 ns |     14.4257 ns |     13.4938 ns |       973.870 ns |  1.05 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 9.0  | .NET 9.0  | 1000    |     1,044.861 ns |     15.4557 ns |     12.9062 ns |     1,047.029 ns |  1.12 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 9.0  | .NET 9.0  | 1000    |     2,888.248 ns |     28.5279 ns |     25.2892 ns |     2,880.667 ns |  3.10 |    0.03 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 9.0  | .NET 9.0  | 1000    |     2,224.667 ns |     17.7497 ns |     16.6031 ns |     2,230.069 ns |  2.39 |    0.02 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **.NET 10.0** | **.NET 10.0** | **100000**  |    **80,131.892 ns** |    **478.7832 ns** |    **447.8541 ns** |    **80,308.203 ns** |  **0.86** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 10.0 | .NET 10.0 | 100000  |    80,979.659 ns |    861.8937 ns |    806.2159 ns |    80,948.340 ns |  0.87 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 10.0 | .NET 10.0 | 100000  |   241,454.304 ns |    416.2912 ns |    369.0313 ns |   241,489.441 ns |  2.59 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 10.0 | .NET 10.0 | 100000  |    93,217.716 ns |    772.1186 ns |    644.7540 ns |    93,257.776 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 10.0 | .NET 10.0 | 100000  |    93,627.655 ns |    751.0305 ns |    702.5144 ns |    93,724.170 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 10.0 | .NET 10.0 | 100000  |    83,548.081 ns |    462.7818 ns |    432.8863 ns |    83,591.663 ns |  0.90 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 10.0 | .NET 10.0 | 100000  |    92,924.728 ns |    565.2522 ns |    501.0813 ns |    93,044.556 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 10.0 | .NET 10.0 | 100000  |    93,299.904 ns |  1,317.2153 ns |  1,232.1240 ns |    92,957.434 ns |  1.00 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 10.0 | .NET 10.0 | 100000  |   102,405.811 ns |  1,945.9680 ns |  2,240.9797 ns |   102,418.475 ns |  1.10 |    0.02 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 10.0 | .NET 10.0 | 100000  |   291,914.984 ns |  2,916.0190 ns |  2,727.6460 ns |   293,171.582 ns |  3.13 |    0.04 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 10.0 | .NET 10.0 | 100000  |   218,867.383 ns |  1,720.4986 ns |  1,525.1772 ns |   218,834.497 ns |  2.35 |    0.02 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| ForLoopCountUsingLengthEqualsZero              | .NET 9.0  | .NET 9.0  | 100000  |    80,193.866 ns |    467.9337 ns |    437.7055 ns |    80,366.785 ns |  0.86 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 9.0  | .NET 9.0  | 100000  |    80,772.187 ns |    590.3152 ns |    523.2990 ns |    80,816.248 ns |  0.87 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 9.0  | .NET 9.0  | 100000  |   241,335.718 ns |    483.8060 ns |    428.8814 ns |   241,455.383 ns |  2.60 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 9.0  | .NET 9.0  | 100000  |    92,969.802 ns |    676.5522 ns |    632.8473 ns |    93,071.509 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 9.0  | .NET 9.0  | 100000  |    93,632.547 ns |    571.1357 ns |    506.2969 ns |    93,712.439 ns |  1.01 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 9.0  | .NET 9.0  | 100000  |    83,577.352 ns |    311.3781 ns |    260.0148 ns |    83,602.832 ns |  0.90 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 9.0  | .NET 9.0  | 100000  |    92,965.977 ns |    810.5039 ns |    758.1459 ns |    92,920.593 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 9.0  | .NET 9.0  | 100000  |    93,071.327 ns |    970.6574 ns |    860.4625 ns |    93,140.417 ns |  1.00 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 9.0  | .NET 9.0  | 100000  |   102,288.828 ns |  1,978.9891 ns |  2,900.7768 ns |   103,561.926 ns |  1.10 |    0.03 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 9.0  | .NET 9.0  | 100000  |   290,582.471 ns |  2,524.6152 ns |  2,361.5267 ns |   291,093.018 ns |  3.13 |    0.03 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 9.0  | .NET 9.0  | 100000  |   218,548.203 ns |    781.7820 ns |    731.2794 ns |   218,756.836 ns |  2.35 |    0.02 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| **ForLoopCountUsingLengthEqualsZero**              | **.NET 10.0** | **.NET 10.0** | **1000000** | **1,721,075.117 ns** | **15,213.9926 ns** | **14,231.1781 ns** | **1,724,420.703 ns** |  **1.01** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 10.0 | .NET 10.0 | 1000000 | 1,674,152.832 ns | 16,387.6933 ns | 15,329.0584 ns | 1,672,080.566 ns |  0.98 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 10.0 | .NET 10.0 | 1000000 | 2,650,613.516 ns | 22,544.5570 ns | 21,088.1926 ns | 2,646,785.547 ns |  1.56 |    0.01 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 10.0 | .NET 10.0 | 1000000 | 1,702,043.978 ns | 11,976.2513 ns |  9,350.2692 ns | 1,703,506.055 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 10.0 | .NET 10.0 | 1000000 | 1,721,794.420 ns | 10,460.4522 ns |  9,272.9184 ns | 1,720,967.773 ns |  1.01 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 10.0 | .NET 10.0 | 1000000 | 1,756,277.760 ns | 12,794.4549 ns | 11,967.9411 ns | 1,756,553.711 ns |  1.03 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 10.0 | .NET 10.0 | 1000000 | 1,716,885.282 ns | 16,704.3887 ns | 14,808.0055 ns | 1,714,389.746 ns |  1.01 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 10.0 | .NET 10.0 | 1000000 | 1,722,161.810 ns | 19,839.0584 ns | 18,557.4675 ns | 1,718,421.289 ns |  1.01 |    0.01 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 10.0 | .NET 10.0 | 1000000 | 1,725,955.859 ns | 25,544.3777 ns | 22,644.4255 ns | 1,723,898.242 ns |  1.01 |    0.01 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 10.0 | .NET 10.0 | 1000000 | 3,289,091.224 ns | 19,543.2195 ns | 18,280.7396 ns | 3,285,071.484 ns |  1.93 |    0.01 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 10.0 | .NET 10.0 | 1000000 | 2,374,129.544 ns | 18,726.6504 ns | 17,516.9204 ns | 2,380,199.023 ns |  1.39 |    0.01 |
|                                                |           |           |         |                  |                |                |                  |       |         |
| ForLoopCountUsingLengthEqualsZero              | .NET 9.0  | .NET 9.0  | 1000000 | 1,741,895.382 ns | 28,289.9252 ns | 25,078.2819 ns | 1,737,653.418 ns |  1.01 |    0.02 |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | .NET 9.0  | .NET 9.0  | 1000000 | 1,662,289.886 ns | 14,485.9797 ns | 12,841.4437 ns | 1,659,559.668 ns |  0.96 |    0.01 |
| ForLoopCountUsingLengthEqualsZeroWithTryCatch  | .NET 9.0  | .NET 9.0  | 1000000 | 2,645,467.591 ns | 19,398.0522 ns | 18,144.9501 ns | 2,645,906.445 ns |  1.54 |    0.02 |
| ForLoopCountUsingEmptyStringLiteral            | .NET 9.0  | .NET 9.0  | 1000000 | 1,722,976.940 ns | 18,007.5533 ns | 16,844.2766 ns | 1,722,564.844 ns |  1.00 |    0.01 |
| ForLoopCountUsingStringDotEmpty                | .NET 9.0  | .NET 9.0  | 1000000 | 1,715,176.237 ns | 20,242.0786 ns | 15,803.6835 ns | 1,715,177.734 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingLengthEqualsZero          | .NET 9.0  | .NET 9.0  | 1000000 | 1,759,980.527 ns | 16,335.5336 ns | 15,280.2683 ns | 1,762,926.270 ns |  1.02 |    0.01 |
| ForEachLoopCountUsingEmptyStringLiteral        | .NET 9.0  | .NET 9.0  | 1000000 | 1,716,668.931 ns | 18,568.1881 ns | 16,460.2151 ns | 1,712,486.816 ns |  1.00 |    0.01 |
| ForEachLoopCountUsingStringDotEmpty            | .NET 9.0  | .NET 9.0  | 1000000 | 1,749,070.430 ns | 34,161.7649 ns | 31,954.9361 ns | 1,748,687.695 ns |  1.02 |    0.02 |
| ForLoopCountUsingIsNullOrEmpty                 | .NET 9.0  | .NET 9.0  | 1000000 | 1,738,107.474 ns | 31,887.3642 ns | 29,827.4602 ns | 1,736,290.430 ns |  1.01 |    0.02 |
| CountUsingLinqWhereEmptyStringLiteral          | .NET 9.0  | .NET 9.0  | 1000000 | 3,313,782.533 ns | 12,951.8495 ns | 11,481.4772 ns | 3,315,862.305 ns |  1.92 |    0.02 |
| CountUsingLinqWhereLengthEqualsZero            | .NET 9.0  | .NET 9.0  | 1000000 | 2,406,947.917 ns | 25,822.5431 ns | 24,154.4228 ns | 2,406,764.062 ns |  1.40 |    0.02 |
