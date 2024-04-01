## Checking someList.Count > 0 vs. Any(), and variants.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                         | Count  | Mean           | Error          | StdDev      | Ratio      | RatioSD   | Gen0    | Gen1   | Allocated | Alloc Ratio |
|----------------------------------------------- |------- |---------------:|---------------:|------------:|-----------:|----------:|--------:|-------:|----------:|------------:|
| **IListAnyResultsLinqAny**                         | **10**     |      **7.4845 ns** |      **1.5556 ns** |   **0.0853 ns** |      **21.46** |      **2.02** |       **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | 10     |      0.3507 ns |      0.5623 ns |   0.0308 ns |       1.00 |      0.00 |       - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | 10     |      8.3848 ns |     23.2735 ns |   1.2757 ns |      24.19 |      5.26 |       - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | 10     |     38.2053 ns |     19.9513 ns |   1.0936 ns |     109.44 |      9.31 |  0.0148 |      - |      64 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | 10     |      0.3486 ns |      0.5179 ns |   0.0284 ns |       1.00 |      0.17 |       - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | 10     |      0.6500 ns |      4.5633 ns |   0.2501 ns |       1.90 |      0.89 |       - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | 10     |     17.8504 ns |      7.7829 ns |   0.4266 ns |      51.13 |      4.03 |       - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | 10     |     52.1122 ns |     12.7071 ns |   0.6965 ns |     149.30 |     12.20 |  0.0148 |      - |      64 B |          NA |
| IEnumerableAnyResultsLinqCount                 | 10     |     16.8888 ns |      8.2288 ns |   0.4510 ns |      48.34 |      3.23 |       - |      - |         - |          NA |
|                                                |        |                |                |             |            |           |         |        |           |             |
| **IListAnyResultsLinqAny**                         | **100000** |      **7.8062 ns** |      **5.3052 ns** |   **0.2908 ns** |      **40.42** |      **8.48** |       **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                   | 100000 |      0.1989 ns |      0.7610 ns |   0.0417 ns |       1.00 |      0.00 |       - |      - |         - |          NA |
| IListAnyResultsLinqCount                       | 100000 |     10.3830 ns |     25.8511 ns |   1.4170 ns |      53.41 |     11.64 |       - |      - |         - |          NA |
| IListAnyResultsToListThenListDotCount          | 100000 | 10,043.0664 ns |  2,540.1513 ns | 139.2343 ns |  51,770.00 |  9,111.93 | 18.5089 | 3.0823 |   80056 B |          NA |
| IListAnyResultsPatternMatchOnCountPropertyKesa | 100000 |      0.3590 ns |      3.0532 ns |   0.1674 ns |       1.78 |      0.70 |       - |      - |         - |          NA |
| IListAnyResultsPatternMatchOnListPatternAaron  | 100000 |      0.1071 ns |      0.3480 ns |   0.0191 ns |       0.55 |      0.11 |       - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                   | 100000 |     17.3713 ns |      4.5929 ns |   0.2518 ns |      89.69 |     16.88 |       - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount    | 100000 | 26,232.0257 ns | 12,555.2304 ns | 688.1945 ns | 135,103.56 | 23,070.48 | 18.4937 | 3.0823 |   80056 B |          NA |
| IEnumerableAnyResultsLinqCount                 | 100000 | 11,052.0912 ns | 11,204.6640 ns | 614.1654 ns |  57,230.24 | 12,318.18 |       - |      - |         - |          NA |
