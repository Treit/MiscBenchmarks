# Check if a value is one of five known constants, and if not assign it one of the values




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27723.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Value         | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |-------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **CheckWithHashSet**                | **FirstValue**    |   **9.618 ns** | **0.1107 ns** | **0.0864 ns** |  **0.94** |    **0.02** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | FirstValue    |  20.361 ns | 0.3893 ns | 0.3251 ns |  1.99 |    0.06 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | FirstValue    | 196.521 ns | 3.4624 ns | 7.8152 ns | 19.74 |    1.01 | 0.1075 |     464 B |          NA |
| CheckWithDictionary             | FirstValue    |  12.455 ns | 0.3156 ns | 0.4724 ns |  1.21 |    0.05 |      - |         - |          NA |
| CheckWithSimpleIf               | FirstValue    |   1.774 ns | 0.0315 ns | 0.0263 ns |  0.17 |    0.01 |      - |         - |          NA |
| CheckWithSwitchStatement        | FirstValue    |  10.880 ns | 0.2564 ns | 0.4212 ns |  1.09 |    0.04 |      - |         - |          NA |
| CheckWithSwitchExpression       | FirstValue    |  10.253 ns | 0.2555 ns | 0.2390 ns |  1.00 |    0.00 |      - |         - |          NA |
|                                 |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **LastValue**     |   **9.734 ns** | **0.2607 ns** | **0.3202 ns** |  **0.98** |    **0.04** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | LastValue     |  20.820 ns | 0.4045 ns | 0.3784 ns |  2.08 |    0.05 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | LastValue     | 189.414 ns | 3.8251 ns | 4.9737 ns | 18.76 |    0.49 | 0.1075 |     464 B |          NA |
| CheckWithDictionary             | LastValue     |  11.845 ns | 0.1432 ns | 0.1196 ns |  1.18 |    0.01 |      - |         - |          NA |
| CheckWithSimpleIf               | LastValue     |   1.237 ns | 0.0260 ns | 0.0230 ns |  0.12 |    0.00 |      - |         - |          NA |
| CheckWithSwitchStatement        | LastValue     |  10.530 ns | 0.0417 ns | 0.0348 ns |  1.05 |    0.01 |      - |         - |          NA |
| CheckWithSwitchExpression       | LastValue     |  10.005 ns | 0.0886 ns | 0.0785 ns |  1.00 |    0.00 |      - |         - |          NA |
|                                 |               |            |           |           |       |         |        |           |             |
| **CheckWithHashSet**                | **ValueNotInSet** |   **9.439 ns** | **0.2426 ns** | **0.2026 ns** |  **0.87** |    **0.03** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | ValueNotInSet |  20.833 ns | 0.4086 ns | 0.3822 ns |  1.92 |    0.08 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | ValueNotInSet | 189.829 ns | 2.6983 ns | 2.3919 ns | 17.49 |    0.58 | 0.1075 |     464 B |          NA |
| CheckWithDictionary             | ValueNotInSet |  12.022 ns | 0.3069 ns | 0.2720 ns |  1.11 |    0.03 |      - |         - |          NA |
| CheckWithSimpleIf               | ValueNotInSet |   1.871 ns | 0.0959 ns | 0.0897 ns |  0.17 |    0.01 |      - |         - |          NA |
| CheckWithSwitchStatement        | ValueNotInSet |  10.873 ns | 0.2749 ns | 0.2572 ns |  1.00 |    0.02 |      - |         - |          NA |
| CheckWithSwitchExpression       | ValueNotInSet |  10.881 ns | 0.2721 ns | 0.2673 ns |  1.00 |    0.00 |      - |         - |          NA |
