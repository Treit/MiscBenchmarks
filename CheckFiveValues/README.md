# Check if a value is one of five known constants, and if not assign it one of the values






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Value         | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |-------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **CheckWithHashSet**                | **FirstValue**    |  **13.919 ns** | **0.1364 ns** | **0.1276 ns** |  **1.47** |    **0.02** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | FirstValue    |   5.693 ns | 0.1019 ns | 0.0953 ns |  0.60 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | FirstValue    | 144.304 ns | 2.2154 ns | 2.0723 ns | 15.24 |    0.24 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | FirstValue    |  12.125 ns | 0.1160 ns | 0.1085 ns |  1.28 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | FirstValue    |   2.490 ns | 0.0241 ns | 0.0188 ns |  0.26 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | FirstValue    |   9.407 ns | 0.0587 ns | 0.0520 ns |  0.99 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | FirstValue    |   9.468 ns | 0.0743 ns | 0.0695 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **LastValue**     |  **14.202 ns** | **0.1053 ns** | **0.0985 ns** |  **1.60** |    **0.01** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | LastValue     |   5.628 ns | 0.0895 ns | 0.0837 ns |  0.63 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | LastValue     | 147.733 ns | 1.4735 ns | 1.3062 ns | 16.63 |    0.18 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | LastValue     |  12.164 ns | 0.1215 ns | 0.1136 ns |  1.37 |    0.02 |      - |         - |          NA |
| CheckWithSimpleIf               | LastValue     |   2.468 ns | 0.0309 ns | 0.0258 ns |  0.28 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | LastValue     |   9.392 ns | 0.0595 ns | 0.0497 ns |  1.06 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | LastValue     |   8.882 ns | 0.0615 ns | 0.0575 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **ValueNotInSet** |  **13.873 ns** | **0.0910 ns** | **0.0851 ns** |  **1.48** |    **0.01** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | ValueNotInSet |   5.695 ns | 0.0674 ns | 0.0631 ns |  0.61 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | ValueNotInSet | 146.817 ns | 1.5301 ns | 1.4312 ns | 15.63 |    0.16 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | ValueNotInSet |  12.192 ns | 0.1037 ns | 0.0970 ns |  1.30 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | ValueNotInSet |   1.858 ns | 0.0322 ns | 0.0301 ns |  0.20 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | ValueNotInSet |   9.451 ns | 0.0754 ns | 0.0705 ns |  1.01 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | ValueNotInSet |   9.395 ns | 0.0418 ns | 0.0349 ns |  1.00 |    0.01 |      - |         - |          NA |
