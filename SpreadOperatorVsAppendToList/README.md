# Return a copy of a list with a new item added to the end


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27723.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                    | Count | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **AddWithSpreadOperator**     | **5**     |     **27.42 ns** |   **1.316 ns** |   **3.818 ns** |     **26.72 ns** |  **1.00** |    **0.00** |  **0.0185** |      **-** |      **80 B** |        **1.00** |
| AddWithAppendAndToList    | 5     |     75.78 ns |   3.519 ns |  10.209 ns |     73.77 ns |  2.82 |    0.59 |  0.0315 |      - |     136 B |        1.70 |
| CopyListWithNewThenAdd    | 5     |     50.44 ns |   1.941 ns |   5.570 ns |     49.01 ns |  1.87 |    0.34 |  0.0334 |      - |     144 B |        1.80 |
| CopyListWithToListThenAdd | 5     |     58.53 ns |   1.605 ns |   4.526 ns |     57.21 ns |  2.17 |    0.33 |  0.0334 |      - |     144 B |        1.80 |
|                           |       |              |            |            |              |       |         |         |        |           |             |
| **AddWithSpreadOperator**     | **50**    |     **38.63 ns** |   **2.034 ns** |   **5.670 ns** |     **37.57 ns** |  **1.00** |    **0.00** |  **0.0612** |      **-** |     **264 B** |        **1.00** |
| AddWithAppendAndToList    | 50    |     76.55 ns |   2.092 ns |   6.103 ns |     75.51 ns |  2.02 |    0.30 |  0.0741 |      - |     320 B |        1.21 |
| CopyListWithNewThenAdd    | 50    |     87.10 ns |   2.568 ns |   7.327 ns |     86.91 ns |  2.31 |    0.38 |  0.1576 |      - |     680 B |        2.58 |
| CopyListWithToListThenAdd | 50    |     88.21 ns |   1.829 ns |   4.052 ns |     87.05 ns |  2.26 |    0.25 |  0.1576 |      - |     680 B |        2.58 |
|                           |       |              |            |            |              |       |         |         |        |           |             |
| **AddWithSpreadOperator**     | **10000** |  **4,048.52 ns** |  **78.485 ns** |  **99.259 ns** |  **4,052.98 ns** |  **1.00** |    **0.00** |  **9.2545** | **1.0223** |   **40064 B** |        **1.00** |
| AddWithAppendAndToList    | 10000 |  4,141.50 ns |  79.258 ns |  77.842 ns |  4,127.40 ns |  1.02 |    0.03 |  9.2545 | 1.0223 |   40120 B |        1.00 |
| CopyListWithNewThenAdd    | 10000 | 12,160.75 ns | 229.137 ns | 214.335 ns | 12,093.22 ns |  3.01 |    0.12 | 27.7710 | 4.6234 |  120080 B |        3.00 |
| CopyListWithToListThenAdd | 10000 | 12,077.66 ns | 216.650 ns | 212.779 ns | 12,041.40 ns |  2.99 |    0.10 | 27.7710 | 4.6234 |  120080 B |        3.00 |
