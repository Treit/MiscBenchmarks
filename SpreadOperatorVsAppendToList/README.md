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
| **AddWithSpreadOperator**                   | **5**     |    **11.43 ns** |   **0.187 ns** |   **0.175 ns** |  **1.00** |    **0.02** | **0.0048** |      **-** |      **80 B** |        **1.00** |
| AddWithAppendAndToList                  | 5     |    26.30 ns |   0.515 ns |   0.551 ns |  2.30 |    0.06 | 0.0081 |      - |     136 B |        1.70 |
| CopyListWithNewThenAdd                  | 5     |    26.89 ns |   0.466 ns |   0.436 ns |  2.35 |    0.05 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithToListThenAdd               | 5     |    27.21 ns |   0.535 ns |   0.500 ns |  2.38 |    0.06 | 0.0086 |      - |     144 B |        1.80 |
| CopyListWithAppendingNewArrayThenToList | 5     |    42.39 ns |   0.584 ns |   0.546 ns |  3.71 |    0.07 | 0.0100 |      - |     168 B |        2.10 |
|                                         |       |             |            |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**                   | **50**    |    **18.40 ns** |   **0.349 ns** |   **0.309 ns** |  **1.00** |    **0.02** | **0.0158** |      **-** |     **264 B** |        **1.00** |
| AddWithAppendAndToList                  | 50    |    32.47 ns |   0.534 ns |   0.474 ns |  1.77 |    0.04 | 0.0191 |      - |     320 B |        1.21 |
| CopyListWithNewThenAdd                  | 50    |    47.51 ns |   0.870 ns |   0.814 ns |  2.58 |    0.06 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithToListThenAdd               | 50    |    47.82 ns |   1.021 ns |   1.291 ns |  2.60 |    0.08 | 0.0406 |      - |     680 B |        2.58 |
| CopyListWithAppendingNewArrayThenToList | 50    |    52.65 ns |   0.804 ns |   0.752 ns |  2.86 |    0.06 | 0.0210 |      - |     352 B |        1.33 |
|                                         |       |             |            |            |       |         |        |        |           |             |
| **AddWithSpreadOperator**                   | **10000** | **2,177.74 ns** |  **41.285 ns** |  **42.397 ns** |  **1.00** |    **0.03** | **2.3918** | **0.2975** |   **40064 B** |        **1.00** |
| AddWithAppendAndToList                  | 10000 | 2,019.76 ns |  40.330 ns |  65.125 ns |  0.93 |    0.03 | 2.3918 | 0.2975 |   40120 B |        1.00 |
| CopyListWithNewThenAdd                  | 10000 | 5,203.55 ns |  82.193 ns |  76.883 ns |  2.39 |    0.06 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithToListThenAdd               | 10000 | 5,229.01 ns | 102.948 ns | 110.154 ns |  2.40 |    0.07 | 7.1411 | 1.4267 |  120080 B |        3.00 |
| CopyListWithAppendingNewArrayThenToList | 10000 | 2,043.53 ns |  40.915 ns |  72.726 ns |  0.94 |    0.04 | 2.3918 | 0.2975 |   40152 B |        1.00 |
