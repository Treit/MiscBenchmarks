# Return a copy of a list with a new item added to the end






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Job       | Runtime   | Count | Mean        | Error      | StdDev     | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------------------- |---------- |---------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **AddWithSpreadOperator**                   | **.NET 10.0** | **.NET 10.0** | **5**     |    **11.22 ns** |   **0.126 ns** |   **0.118 ns** |  **1.00** |    **0.01** | **0.0048** |      **-** |      **80 B** |        **1.00** |
| AddWithAppendAndToList                  | .NET 10.0 | .NET 10.0 | 5     |    24.67 ns |   0.178 ns |   0.139 ns |  2.20 |    0.03 | 0.0081 |      - |     136 B |        1.70 |
| CopyListWithNewThenAdd                  | .NET 10.0 | .NET 10.0 | 5     |    27.89 ns |   0.333 ns |   0.295 ns |  2.48 |    0.04 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithToListThenAdd               | .NET 10.0 | .NET 10.0 | 5     |    26.58 ns |   0.251 ns |   0.223 ns |  2.37 |    0.03 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithAppendingNewArrayThenToList | .NET 10.0 | .NET 10.0 | 5     |    40.89 ns |   0.387 ns |   0.362 ns |  3.64 |    0.05 | 0.0100 |      - |     168 B |        2.10 |
|                                         |           |           |       |             |            |            |       |         |        |        |           |             |
| AddWithSpreadOperator                   | .NET 9.0  | .NET 9.0  | 5     |    11.00 ns |   0.120 ns |   0.112 ns |  1.00 |    0.01 | 0.0048 |      - |      80 B |        1.00 |
| AddWithAppendAndToList                  | .NET 9.0  | .NET 9.0  | 5     |    25.56 ns |   0.179 ns |   0.167 ns |  2.32 |    0.03 | 0.0081 |      - |     136 B |        1.70 |
| CopyListWithNewThenAdd                  | .NET 9.0  | .NET 9.0  | 5     |    26.13 ns |   0.288 ns |   0.269 ns |  2.38 |    0.03 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithToListThenAdd               | .NET 9.0  | .NET 9.0  | 5     |    26.49 ns |   0.246 ns |   0.230 ns |  2.41 |    0.03 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithAppendingNewArrayThenToList | .NET 9.0  | .NET 9.0  | 5     |    46.20 ns |   0.464 ns |   0.434 ns |  4.20 |    0.06 | 0.0100 |      - |     168 B |        2.10 |
|                                         |           |           |       |             |            |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**                   | **.NET 10.0** | **.NET 10.0** | **50**    |    **18.41 ns** |   **0.285 ns** |   **0.252 ns** |  **1.00** |    **0.02** | **0.0158** |      **-** |     **264 B** |        **1.00** |
| AddWithAppendAndToList                  | .NET 10.0 | .NET 10.0 | 50    |    31.87 ns |   0.458 ns |   0.429 ns |  1.73 |    0.03 | 0.0191 |      - |     320 B |        1.21 |
| CopyListWithNewThenAdd                  | .NET 10.0 | .NET 10.0 | 50    |    44.00 ns |   0.557 ns |   0.521 ns |  2.39 |    0.04 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithToListThenAdd               | .NET 10.0 | .NET 10.0 | 50    |    45.70 ns |   0.967 ns |   1.075 ns |  2.48 |    0.07 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithAppendingNewArrayThenToList | .NET 10.0 | .NET 10.0 | 50    |    56.14 ns |   0.808 ns |   0.756 ns |  3.05 |    0.06 | 0.0210 |      - |     352 B |        1.33 |
|                                         |           |           |       |             |            |            |       |         |        |        |           |             |
| AddWithSpreadOperator                   | .NET 9.0  | .NET 9.0  | 50    |    18.58 ns |   0.368 ns |   0.345 ns |  1.00 |    0.03 | 0.0158 |      - |     264 B |        1.00 |
| AddWithAppendAndToList                  | .NET 9.0  | .NET 9.0  | 50    |    33.31 ns |   0.707 ns |   0.590 ns |  1.79 |    0.04 | 0.0191 |      - |     320 B |        1.21 |
| CopyListWithNewThenAdd                  | .NET 9.0  | .NET 9.0  | 50    |    46.13 ns |   0.884 ns |   0.784 ns |  2.48 |    0.06 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithToListThenAdd               | .NET 9.0  | .NET 9.0  | 50    |    44.53 ns |   0.437 ns |   0.409 ns |  2.40 |    0.05 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithAppendingNewArrayThenToList | .NET 9.0  | .NET 9.0  | 50    |    56.46 ns |   0.644 ns |   0.603 ns |  3.04 |    0.06 | 0.0210 |      - |     352 B |        1.33 |
|                                         |           |           |       |             |            |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**                   | **.NET 10.0** | **.NET 10.0** | **10000** | **2,097.62 ns** |  **18.625 ns** |  **17.422 ns** |  **1.00** |    **0.01** | **2.3918** | **0.2975** |   **40064 B** |        **1.00** |
| AddWithAppendAndToList                  | .NET 10.0 | .NET 10.0 | 10000 | 2,074.90 ns |  36.923 ns |  49.291 ns |  0.99 |    0.02 | 2.3918 | 0.2975 |   40120 B |        1.00 |
| CopyListWithNewThenAdd                  | .NET 10.0 | .NET 10.0 | 10000 | 4,888.75 ns |  94.929 ns | 147.793 ns |  2.33 |    0.07 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithToListThenAdd               | .NET 10.0 | .NET 10.0 | 10000 | 5,302.76 ns | 105.036 ns | 175.491 ns |  2.53 |    0.09 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithAppendingNewArrayThenToList | .NET 10.0 | .NET 10.0 | 10000 | 2,089.69 ns |  41.734 ns |  58.505 ns |  1.00 |    0.03 | 2.3918 | 0.2975 |   40152 B |        1.00 |
|                                         |           |           |       |             |            |            |       |         |        |        |           |             |
| AddWithSpreadOperator                   | .NET 9.0  | .NET 9.0  | 10000 | 2,072.26 ns |  39.471 ns |  32.960 ns |  1.00 |    0.02 | 2.3918 | 0.2975 |   40064 B |        1.00 |
| AddWithAppendAndToList                  | .NET 9.0  | .NET 9.0  | 10000 | 1,937.31 ns |  37.676 ns |  48.990 ns |  0.94 |    0.03 | 2.3918 | 0.2975 |   40120 B |        1.00 |
| CopyListWithNewThenAdd                  | .NET 9.0  | .NET 9.0  | 10000 | 5,071.64 ns |  97.006 ns |  95.273 ns |  2.45 |    0.06 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithToListThenAdd               | .NET 9.0  | .NET 9.0  | 10000 | 4,830.81 ns |  34.882 ns |  32.628 ns |  2.33 |    0.04 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithAppendingNewArrayThenToList | .NET 9.0  | .NET 9.0  | 10000 | 2,133.71 ns |  42.614 ns |  62.463 ns |  1.03 |    0.03 | 2.3918 | 0.2975 |   40152 B |        1.00 |
