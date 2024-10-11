# Return a copy of a list with a new item added to the end



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27723.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                  | Count | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|---------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **AddWithSpreadOperator**                   | **5**     |     **22.00 ns** |   **0.479 ns** |   **0.989 ns** |     **21.74 ns** |  **1.00** |    **0.00** |  **0.0185** |      **-** |      **80 B** |        **1.00** |
| AddWithAppendAndToList                  | 5     |     57.48 ns |   0.857 ns |   0.715 ns |     57.38 ns |  2.61 |    0.17 |  0.0315 |      - |     136 B |        1.70 |
| CopyListWithNewThenAdd                  | 5     |     53.02 ns |   1.845 ns |   5.235 ns |     52.18 ns |  2.42 |    0.27 |  0.0334 |      - |     144 B |        1.80 |
| CopyListWithToListThenAdd               | 5     |     56.95 ns |   1.790 ns |   5.078 ns |     55.91 ns |  2.57 |    0.28 |  0.0334 |      - |     144 B |        1.80 |
| CopyListWithAppendingNewArrayThenToList | 5     |     98.64 ns |   2.034 ns |   4.464 ns |     97.93 ns |  4.50 |    0.30 |  0.0389 |      - |     168 B |        2.10 |
|                                         |       |              |            |            |              |       |         |         |        |           |             |
| **AddWithSpreadOperator**                   | **50**    |     **32.97 ns** |   **0.720 ns** |   **1.121 ns** |     **32.71 ns** |  **1.00** |    **0.00** |  **0.0612** |      **-** |     **264 B** |        **1.00** |
| AddWithAppendAndToList                  | 50    |     77.23 ns |   2.230 ns |   6.469 ns |     75.40 ns |  2.37 |    0.20 |  0.0741 |      - |     320 B |        1.21 |
| CopyListWithNewThenAdd                  | 50    |     86.32 ns |   1.903 ns |   5.552 ns |     86.16 ns |  2.51 |    0.16 |  0.1576 |      - |     680 B |        2.58 |
| CopyListWithToListThenAdd               | 50    |     88.94 ns |   1.839 ns |   4.844 ns |     88.10 ns |  2.69 |    0.17 |  0.1576 |      - |     680 B |        2.58 |
| CopyListWithAppendingNewArrayThenToList | 50    |    116.83 ns |   2.418 ns |   6.660 ns |    115.00 ns |  3.64 |    0.28 |  0.0815 |      - |     352 B |        1.33 |
|                                         |       |              |            |            |              |       |         |         |        |           |             |
| **AddWithSpreadOperator**                   | **10000** |  **4,070.78 ns** |  **80.475 ns** |  **89.447 ns** |  **4,063.83 ns** |  **1.00** |    **0.00** |  **9.2545** | **1.0223** |   **40064 B** |        **1.00** |
| AddWithAppendAndToList                  | 10000 |  4,168.26 ns |  80.477 ns |  95.802 ns |  4,161.37 ns |  1.02 |    0.04 |  9.2545 | 1.0223 |   40120 B |        1.00 |
| CopyListWithNewThenAdd                  | 10000 | 12,791.60 ns | 255.397 ns | 668.329 ns | 12,658.92 ns |  3.20 |    0.20 | 27.7710 | 4.6234 |  120080 B |        3.00 |
| CopyListWithToListThenAdd               | 10000 | 12,021.13 ns | 176.799 ns | 147.635 ns | 12,050.51 ns |  2.95 |    0.10 | 27.7710 | 4.6234 |  120080 B |        3.00 |
| CopyListWithAppendingNewArrayThenToList | 10000 |  4,232.29 ns |  84.570 ns | 126.580 ns |  4,207.83 ns |  1.04 |    0.04 |  9.2545 | 1.0223 |   40152 B |        1.00 |
