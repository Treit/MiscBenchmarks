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
| Method                                      | Count  | Mean           | Error          | StdDev        | Ratio      | RatioSD   | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------------- |------- |---------------:|---------------:|--------------:|-----------:|----------:|--------:|-------:|----------:|------------:|
| **IListAnyResultsLinqAny**                      | **10**     |      **6.7391 ns** |      **1.7912 ns** |     **0.0982 ns** |      **16.80** |      **2.55** |       **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                | 10     |      0.4069 ns |      1.0352 ns |     0.0567 ns |       1.00 |      0.00 |       - |      - |         - |          NA |
| IListAnyResultsLinqCount                    | 10     |      7.3263 ns |     11.3963 ns |     0.6247 ns |      18.13 |      1.60 |       - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                | 10     |     20.6401 ns |     27.0562 ns |     1.4830 ns |      51.29 |      6.95 |       - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount | 10     |     54.5751 ns |     83.2613 ns |     4.5638 ns |     134.91 |      8.73 |  0.0148 |      - |      64 B |          NA |
| IEnumerableAnyResultsLinqCount              | 10     |     16.8676 ns |     13.3251 ns |     0.7304 ns |      41.97 |      5.66 |       - |      - |         - |          NA |
|                                             |        |                |                |               |            |           |         |        |           |             |
| **IListAnyResultsLinqAny**                      | **100000** |      **7.0525 ns** |      **4.5083 ns** |     **0.2471 ns** |      **48.56** |     **16.76** |       **-** |      **-** |         **-** |          **NA** |
| IListAnyResultsIListDotCount                | 100000 |      0.1568 ns |      0.9202 ns |     0.0504 ns |       1.00 |      0.00 |       - |      - |         - |          NA |
| IListAnyResultsLinqCount                    | 100000 |      7.5838 ns |     17.6695 ns |     0.9685 ns |      53.80 |     26.47 |       - |      - |         - |          NA |
| IEnumerableAnyResultsLinqAny                | 100000 |     16.7796 ns |      4.8914 ns |     0.2681 ns |     116.43 |     44.28 |       - |      - |         - |          NA |
| IEnumerableAnyResultsToListThenListDotCount | 100000 | 27,963.7604 ns | 43,634.7510 ns | 2,391.7679 ns | 195,900.30 | 81,903.81 | 18.4937 | 3.0823 |   80056 B |          NA |
| IEnumerableAnyResultsLinqCount              | 100000 | 11,610.8246 ns | 11,266.0916 ns |   617.5325 ns |  79,269.57 | 24,614.96 |       - |      - |         - |          NA |
