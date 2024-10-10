# Check if a value is one of five known constants, and if not assign it one of the values



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27723.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Value         | Mean        | Error     | StdDev    | Median      | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |-------------- |------------:|----------:|----------:|------------:|-------:|--------:|-------:|----------:|------------:|
| **CheckWithHashSet**                | **FirstValue**    |  **13.5973 ns** | **0.2823 ns** | **0.2640 ns** |  **13.5334 ns** |  **15.20** |    **1.45** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | FirstValue    |   9.9847 ns | 0.2216 ns | 0.2073 ns |  10.0731 ns |  11.16 |    1.01 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | FirstValue    | 194.8653 ns | 3.2608 ns | 5.8800 ns | 194.2192 ns | 214.27 |   19.23 | 0.1075 |     464 B |          NA |
| CheckWithDictionary             | FirstValue    |  13.2278 ns | 0.3332 ns | 0.4884 ns |  13.1100 ns |  14.78 |    1.35 |      - |         - |          NA |
| CheckWithSimpleIf               | FirstValue    |   0.7021 ns | 0.0815 ns | 0.1221 ns |   0.6954 ns |   0.72 |    0.13 |      - |         - |          NA |
| CheckWithSwitchStatement        | FirstValue    |   0.8328 ns | 0.0735 ns | 0.0687 ns |   0.8125 ns |   0.93 |    0.11 |      - |         - |          NA |
| CheckWithSwitchExpression       | FirstValue    |   0.9084 ns | 0.0816 ns | 0.0838 ns |   0.9292 ns |   1.00 |    0.00 |      - |         - |          NA |
|                                 |               |             |           |           |             |        |         |        |           |             |
| **CheckWithHashSet**                | **LastValue**     |   **8.4128 ns** | **0.1945 ns** | **0.1518 ns** |   **8.4185 ns** |   **3.11** |    **0.15** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | LastValue     |  34.6720 ns | 0.7579 ns | 1.6151 ns |  34.5081 ns |  12.72 |    0.98 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | LastValue     | 195.1963 ns | 3.1601 ns | 2.6388 ns | 195.7243 ns |  72.50 |    3.35 | 0.1075 |     464 B |          NA |
| CheckWithDictionary             | LastValue     |  12.9878 ns | 0.2877 ns | 0.4306 ns |  13.0327 ns |   4.75 |    0.24 |      - |         - |          NA |
| CheckWithSimpleIf               | LastValue     |   5.5753 ns | 0.4073 ns | 1.1946 ns |   5.2233 ns |   2.10 |    0.43 |      - |         - |          NA |
| CheckWithSwitchStatement        | LastValue     |   1.6055 ns | 0.0932 ns | 0.1036 ns |   1.6020 ns |   0.59 |    0.05 |      - |         - |          NA |
| CheckWithSwitchExpression       | LastValue     |   2.7193 ns | 0.1248 ns | 0.1387 ns |   2.7132 ns |   1.00 |    0.00 |      - |         - |          NA |
|                                 |               |             |           |           |             |        |         |        |           |             |
| **CheckWithHashSet**                | **ValueNotInSet** |  **10.9844 ns** | **0.2894 ns** | **0.8350 ns** |  **10.8244 ns** |   **8.34** |    **0.73** |      **-** |         **-** |          **NA** |
| CheckWithListSearch             | ValueNotInSet |  21.7552 ns | 0.4716 ns | 0.5614 ns |  21.7432 ns |  16.78 |    0.68 |      - |         - |          NA |
| CheckWithNewDictionaryEveryTime | ValueNotInSet | 199.8781 ns | 3.8887 ns | 7.8553 ns | 199.9361 ns | 154.45 |    8.45 | 0.1075 |     464 B |          NA |
| CheckWithDictionary             | ValueNotInSet |  11.7386 ns | 0.2157 ns | 0.2017 ns |  11.7211 ns |   9.10 |    0.36 |      - |         - |          NA |
| CheckWithSimpleIf               | ValueNotInSet |   1.3050 ns | 0.0847 ns | 0.0792 ns |   1.3045 ns |   1.01 |    0.07 |      - |         - |          NA |
| CheckWithSwitchStatement        | ValueNotInSet |   1.9220 ns | 0.1014 ns | 0.0898 ns |   1.9003 ns |   1.49 |    0.08 |      - |         - |          NA |
| CheckWithSwitchExpression       | ValueNotInSet |   1.2981 ns | 0.0559 ns | 0.0598 ns |   1.2731 ns |   1.00 |    0.00 |      - |         - |          NA |
