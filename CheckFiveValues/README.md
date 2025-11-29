# Check if a value is one of five known constants, and if not assign it one of the values







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Value         | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |---------- |---------- |-------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **CheckWithHashSet**                | **.NET 10.0** | **.NET 10.0** | **FirstValue**    |  **14.270 ns** | **0.1653 ns** | **0.1466 ns** |  **1.61** |    **0.02** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | .NET 10.0 | .NET 10.0 | FirstValue    |   6.582 ns | 0.0679 ns | 0.0635 ns |  0.74 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | .NET 10.0 | .NET 10.0 | FirstValue    | 145.652 ns | 2.8913 ns | 2.7045 ns | 16.40 |    0.31 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | .NET 10.0 | .NET 10.0 | FirstValue    |  12.256 ns | 0.1389 ns | 0.1231 ns |  1.38 |    0.02 |      - |         - |          NA |
| CheckWithSimpleIf               | .NET 10.0 | .NET 10.0 | FirstValue    |   2.456 ns | 0.0341 ns | 0.0302 ns |  0.28 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | .NET 10.0 | .NET 10.0 | FirstValue    |   8.906 ns | 0.0458 ns | 0.0406 ns |  1.00 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | .NET 10.0 | .NET 10.0 | FirstValue    |   8.881 ns | 0.0577 ns | 0.0540 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |           |           |               |            |           |           |       |         |        |           |             |
| CheckWithHashSet                | .NET 9.0  | .NET 9.0  | FirstValue    |  14.333 ns | 0.1437 ns | 0.1274 ns |  1.51 |    0.02 |      - |         - |          NA |
| CheckWithListSearch             | .NET 9.0  | .NET 9.0  | FirstValue    |   6.630 ns | 0.0998 ns | 0.0934 ns |  0.70 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | .NET 9.0  | .NET 9.0  | FirstValue    | 145.119 ns | 2.8899 ns | 2.7032 ns | 15.28 |    0.31 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | .NET 9.0  | .NET 9.0  | FirstValue    |  12.658 ns | 0.1142 ns | 0.1068 ns |  1.33 |    0.02 |      - |         - |          NA |
| CheckWithSimpleIf               | .NET 9.0  | .NET 9.0  | FirstValue    |   2.467 ns | 0.0297 ns | 0.0232 ns |  0.26 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | .NET 9.0  | .NET 9.0  | FirstValue    |   9.447 ns | 0.0758 ns | 0.0709 ns |  1.00 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | .NET 9.0  | .NET 9.0  | FirstValue    |   9.495 ns | 0.0902 ns | 0.0844 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |           |           |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **.NET 10.0** | **.NET 10.0** | **LastValue**     |  **14.062 ns** | **0.1143 ns** | **0.1069 ns** |  **1.49** |    **0.01** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | .NET 10.0 | .NET 10.0 | LastValue     |   5.755 ns | 0.0668 ns | 0.0625 ns |  0.61 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | .NET 10.0 | .NET 10.0 | LastValue     | 147.251 ns | 2.5586 ns | 2.3933 ns | 15.62 |    0.26 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | .NET 10.0 | .NET 10.0 | LastValue     |  12.099 ns | 0.1459 ns | 0.1218 ns |  1.28 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | .NET 10.0 | .NET 10.0 | LastValue     |   1.870 ns | 0.0252 ns | 0.0197 ns |  0.20 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | .NET 10.0 | .NET 10.0 | LastValue     |   9.508 ns | 0.0766 ns | 0.0679 ns |  1.01 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | .NET 10.0 | .NET 10.0 | LastValue     |   9.430 ns | 0.0609 ns | 0.0540 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |           |           |               |            |           |           |       |         |        |           |             |
| CheckWithHashSet                | .NET 9.0  | .NET 9.0  | LastValue     |  14.170 ns | 0.2442 ns | 0.2284 ns |  1.60 |    0.03 |      - |         - |          NA |
| CheckWithListSearch             | .NET 9.0  | .NET 9.0  | LastValue     |   6.479 ns | 0.0583 ns | 0.0517 ns |  0.73 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | .NET 9.0  | .NET 9.0  | LastValue     | 145.563 ns | 2.0776 ns | 1.9434 ns | 16.40 |    0.22 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | .NET 9.0  | .NET 9.0  | LastValue     |  12.292 ns | 0.1764 ns | 0.1650 ns |  1.38 |    0.02 |      - |         - |          NA |
| CheckWithSimpleIf               | .NET 9.0  | .NET 9.0  | LastValue     |   2.477 ns | 0.0488 ns | 0.0433 ns |  0.28 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | .NET 9.0  | .NET 9.0  | LastValue     |   9.446 ns | 0.0666 ns | 0.0591 ns |  1.06 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | .NET 9.0  | .NET 9.0  | LastValue     |   8.877 ns | 0.0498 ns | 0.0389 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |           |           |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **.NET 10.0** | **.NET 10.0** | **ValueNotInSet** |  **14.087 ns** | **0.1500 ns** | **0.1403 ns** |  **1.49** |    **0.02** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | .NET 10.0 | .NET 10.0 | ValueNotInSet |   5.613 ns | 0.0490 ns | 0.0459 ns |  0.59 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | .NET 10.0 | .NET 10.0 | ValueNotInSet | 147.737 ns | 2.1673 ns | 2.0273 ns | 15.62 |    0.25 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | .NET 10.0 | .NET 10.0 | ValueNotInSet |  12.386 ns | 0.1887 ns | 0.1765 ns |  1.31 |    0.02 |      - |         - |          NA |
| CheckWithSimpleIf               | .NET 10.0 | .NET 10.0 | ValueNotInSet |   2.455 ns | 0.0274 ns | 0.0243 ns |  0.26 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | .NET 10.0 | .NET 10.0 | ValueNotInSet |   8.880 ns | 0.0699 ns | 0.0584 ns |  0.94 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | .NET 10.0 | .NET 10.0 | ValueNotInSet |   9.460 ns | 0.0951 ns | 0.0889 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |           |           |               |            |           |           |       |         |        |           |             |
| CheckWithHashSet                | .NET 9.0  | .NET 9.0  | ValueNotInSet |  13.892 ns | 0.1208 ns | 0.1130 ns |  1.47 |    0.01 |      - |         - |          NA |
| CheckWithListSearch             | .NET 9.0  | .NET 9.0  | ValueNotInSet |   6.628 ns | 0.0696 ns | 0.0651 ns |  0.70 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | .NET 9.0  | .NET 9.0  | ValueNotInSet | 142.172 ns | 2.5420 ns | 2.3778 ns | 15.07 |    0.26 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | .NET 9.0  | .NET 9.0  | ValueNotInSet |  12.263 ns | 0.1230 ns | 0.1151 ns |  1.30 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | .NET 9.0  | .NET 9.0  | ValueNotInSet |   2.486 ns | 0.0340 ns | 0.0284 ns |  0.26 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | .NET 9.0  | .NET 9.0  | ValueNotInSet |   8.902 ns | 0.0781 ns | 0.0731 ns |  0.94 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | .NET 9.0  | .NET 9.0  | ValueNotInSet |   9.434 ns | 0.0605 ns | 0.0536 ns |  1.00 |    0.01 |      - |         - |          NA |
