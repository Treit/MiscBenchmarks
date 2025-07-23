# LinkedList vs List<T> Iteration Benchmark

This benchmark compares the performance of iterating through LinkedList<T> vs List<T> collections using various approaches.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27909.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                 | Count | Mean         | Error      | StdDev       | Median       | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |------ |-------------:|-----------:|-------------:|-------------:|------:|--------:|-------:|----------:|------------:|
| **IterateList**            | **100**   |     **92.45 ns** |   **4.687 ns** |    **13.820 ns** |     **95.02 ns** |  **1.02** |    **0.23** |      **-** |         **-** |          **NA** |
| IterateListWithIndexer | 100   |     64.19 ns |   1.200 ns |     1.972 ns |     63.89 ns |  0.71 |    0.12 |      - |         - |          NA |
| IterateLinkedList      | 100   |    118.55 ns |   2.056 ns |     1.923 ns |    118.02 ns |  1.31 |    0.21 |      - |         - |          NA |
| IterateLinkedListNodes | 100   |    119.25 ns |   1.537 ns |     1.438 ns |    119.04 ns |  1.32 |    0.22 |      - |         - |          NA |
| IterateListArray       | 100   |     81.12 ns |   1.621 ns |     1.867 ns |     81.00 ns |  0.90 |    0.15 | 0.0982 |     424 B |          NA |
| IterateListLinq        | 100   |    233.96 ns |   4.715 ns |     6.294 ns |    235.68 ns |  2.59 |    0.43 | 0.0091 |      40 B |          NA |
| IterateLinkedListLinq  | 100   |    385.19 ns |   7.527 ns |     6.673 ns |    383.28 ns |  4.27 |    0.70 | 0.0110 |      48 B |          NA |
|                        |       |              |            |              |              |       |         |        |           |             |
| **IterateList**            | **1000**  |    **567.24 ns** |  **11.236 ns** |    **13.376 ns** |    **562.69 ns** |  **1.00** |    **0.03** |      **-** |         **-** |          **NA** |
| IterateListWithIndexer | 1000  |    568.51 ns |  11.258 ns |    16.851 ns |    562.27 ns |  1.00 |    0.04 |      - |         - |          NA |
| IterateLinkedList      | 1000  |  1,921.60 ns |  34.633 ns |    32.396 ns |  1,929.35 ns |  3.39 |    0.09 |      - |         - |          NA |
| IterateLinkedListNodes | 1000  |  1,888.08 ns |  14.278 ns |    11.147 ns |  1,889.65 ns |  3.33 |    0.08 |      - |         - |          NA |
| IterateListArray       | 1000  |    653.66 ns |  12.787 ns |    19.527 ns |    649.00 ns |  1.15 |    0.04 | 0.9327 |    4024 B |          NA |
| IterateListLinq        | 1000  |  3,409.44 ns |  68.143 ns |    86.179 ns |  3,422.02 ns |  6.01 |    0.20 | 0.0076 |      40 B |          NA |
| IterateLinkedListLinq  | 1000  |  4,217.60 ns |  83.839 ns |   106.030 ns |  4,181.51 ns |  7.44 |    0.25 | 0.0076 |      48 B |          NA |
|                        |       |              |            |              |              |       |         |        |           |             |
| **IterateList**            | **10000** |  **5,666.80 ns** |  **71.487 ns** |    **59.695 ns** |  **5,685.05 ns** |  **1.00** |    **0.01** |      **-** |         **-** |          **NA** |
| IterateListWithIndexer | 10000 |  6,806.41 ns | 415.759 ns | 1,179.439 ns |  6,413.03 ns |  1.20 |    0.21 |      - |         - |          NA |
| IterateLinkedList      | 10000 | 19,794.98 ns | 392.725 ns |   537.566 ns | 19,602.32 ns |  3.49 |    0.10 |      - |         - |          NA |
| IterateLinkedListNodes | 10000 | 19,387.85 ns | 329.045 ns |   492.499 ns | 19,319.17 ns |  3.42 |    0.09 |      - |         - |          NA |
| IterateListArray       | 10000 |  7,811.72 ns | 155.489 ns |   341.302 ns |  7,701.28 ns |  1.38 |    0.06 | 9.1705 |   40024 B |          NA |
| IterateListLinq        | 10000 | 28,287.39 ns | 587.027 ns | 1,712.385 ns | 28,279.51 ns |  4.99 |    0.31 |      - |      40 B |          NA |
| IterateLinkedListLinq  | 10000 | 37,146.82 ns | 671.447 ns | 1,340.951 ns | 36,818.37 ns |  6.56 |    0.24 |      - |      48 B |          NA |
