# Return a copy of a list with a new item added to the end





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                  | Count | Mean        | Error      | StdDev     | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|-------:|----------:|------------:|
| **AddWithSpreadOperator**                   | **5**     |    **11.33 ns** |   **0.281 ns** |   **0.289 ns** |  **1.00** |    **0.03** | **0.0048** |      **-** |      **80 B** |        **1.00** |
| AddWithAppendAndToList                  | 5     |    25.68 ns |   0.550 ns |   0.565 ns |  2.27 |    0.07 | 0.0081 |      - |     136 B |        1.70 |
| CopyListWithNewThenAdd                  | 5     |    27.24 ns |   0.584 ns |   0.717 ns |  2.41 |    0.09 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithToListThenAdd               | 5     |    26.51 ns |   0.201 ns |   0.188 ns |  2.34 |    0.06 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithAppendingNewArrayThenToList | 5     |    41.04 ns |   0.513 ns |   0.480 ns |  3.63 |    0.10 | 0.0100 |      - |     168 B |        2.10 |
|                                         |       |             |            |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**                   | **50**    |    **18.54 ns** |   **0.407 ns** |   **0.381 ns** |  **1.00** |    **0.03** | **0.0158** |      **-** |     **264 B** |        **1.00** |
| AddWithAppendAndToList                  | 50    |    32.57 ns |   0.532 ns |   0.498 ns |  1.76 |    0.04 | 0.0191 |      - |     320 B |        1.21 |
| CopyListWithNewThenAdd                  | 50    |    46.99 ns |   0.783 ns |   0.732 ns |  2.54 |    0.06 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithToListThenAdd               | 50    |    45.29 ns |   0.816 ns |   0.763 ns |  2.44 |    0.06 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithAppendingNewArrayThenToList | 50    |    53.30 ns |   0.838 ns |   0.743 ns |  2.88 |    0.07 | 0.0210 |      - |     352 B |        1.33 |
|                                         |       |             |            |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**                   | **10000** | **1,940.83 ns** |  **30.364 ns** |  **28.403 ns** |  **1.00** |    **0.02** | **2.3918** | **0.2975** |   **40064 B** |        **1.00** |
| AddWithAppendAndToList                  | 10000 | 2,000.25 ns |  16.367 ns |  13.667 ns |  1.03 |    0.02 | 2.3918 | 0.2975 |   40120 B |        1.00 |
| CopyListWithNewThenAdd                  | 10000 | 4,800.48 ns |  94.661 ns | 184.630 ns |  2.47 |    0.10 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithToListThenAdd               | 10000 | 5,185.06 ns | 102.614 ns | 140.460 ns |  2.67 |    0.08 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithAppendingNewArrayThenToList | 10000 | 1,973.54 ns |  32.975 ns |  29.232 ns |  1.02 |    0.02 | 2.3918 | 0.2975 |   40152 B |        1.00 |
