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
| **CheckWithHashSet**                | **FirstValue**    |  **13.949 ns** | **0.1225 ns** | **0.1086 ns** |  **1.48** |    **0.01** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | FirstValue    |   6.599 ns | 0.0625 ns | 0.0584 ns |  0.70 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | FirstValue    | 141.367 ns | 2.0899 ns | 1.9549 ns | 15.00 |    0.22 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | FirstValue    |  12.058 ns | 0.1226 ns | 0.1147 ns |  1.28 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | FirstValue    |   2.457 ns | 0.0336 ns | 0.0281 ns |  0.26 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | FirstValue    |   8.844 ns | 0.0508 ns | 0.0475 ns |  0.94 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | FirstValue    |   9.423 ns | 0.0732 ns | 0.0649 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **LastValue**     |  **14.230 ns** | **0.1445 ns** | **0.1352 ns** |  **1.51** |    **0.02** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | LastValue     |   5.627 ns | 0.0651 ns | 0.0609 ns |  0.60 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | LastValue     | 149.532 ns | 2.2774 ns | 2.0189 ns | 15.92 |    0.22 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | LastValue     |  12.804 ns | 0.1283 ns | 0.1201 ns |  1.36 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | LastValue     |   1.823 ns | 0.0280 ns | 0.0262 ns |  0.19 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | LastValue     |   9.393 ns | 0.0348 ns | 0.0291 ns |  1.00 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | LastValue     |   9.394 ns | 0.0519 ns | 0.0460 ns |  1.00 |    0.01 |      - |         - |          NA |
|                                 |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **ValueNotInSet** |  **14.082 ns** | **0.1163 ns** | **0.1088 ns** |  **1.59** |    **0.02** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | ValueNotInSet |   5.693 ns | 0.0683 ns | 0.0638 ns |  0.64 |    0.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | ValueNotInSet | 147.988 ns | 1.8378 ns | 1.6292 ns | 16.73 |    0.20 | 0.0277 |     464 B |          NA |
| CheckWithDictionary             | ValueNotInSet |  12.322 ns | 0.1846 ns | 0.1726 ns |  1.39 |    0.02 |      - |         - |          NA |
| CheckWithSimpleIf               | ValueNotInSet |   2.477 ns | 0.0308 ns | 0.0257 ns |  0.28 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | ValueNotInSet |   8.917 ns | 0.0853 ns | 0.0756 ns |  1.01 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | ValueNotInSet |   8.848 ns | 0.0606 ns | 0.0538 ns |  1.00 |    0.01 |      - |         - |          NA |
