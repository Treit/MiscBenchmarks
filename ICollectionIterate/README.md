# Test that converting an ICollection to an array yields better enumeration performance.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                    | Count  | Mean           | Error          | StdDev         | Median         | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------- |---------------:|---------------:|---------------:|---------------:|------:|--------:|-------:|----------:|------------:|
| **ICollectionForLoopWithCastToArray**                         | **10**     |       **7.796 ns** |      **0.1840 ns** |      **0.3456 ns** |       **7.783 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithList                            | 10     |      52.764 ns |      1.2437 ns |      3.6278 ns |      52.328 ns |  6.76 |    0.55 | 0.0092 |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 10     |      31.044 ns |      0.6507 ns |      1.1566 ns |      30.898 ns |  3.99 |    0.24 | 0.0074 |      32 B |          NA |
| ICollectionForEachLoopWithCastToList                      | 10     |      45.115 ns |      0.9312 ns |      1.3938 ns |      45.227 ns |  5.73 |    0.34 | 0.0092 |      40 B |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 10     |       9.090 ns |      0.2537 ns |      0.7238 ns |       8.987 ns |  1.13 |    0.10 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 10     |       7.858 ns |      0.1897 ns |      0.3832 ns |       7.792 ns |  1.00 |    0.06 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      59.651 ns |      1.2460 ns |      2.4006 ns |      59.403 ns |  7.68 |    0.50 | 0.0092 |      40 B |          NA |
|                                                           |        |                |                |                |                |       |         |        |           |             |
| **ICollectionForLoopWithCastToArray**                         | **100000** | **153,864.713 ns** |  **3,059.7740 ns** |  **8,779.0653 ns** | **153,890.710 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithList                            | 100000 | 289,253.854 ns |  5,745.7874 ns | 15,921.5498 ns | 284,252.588 ns |  1.88 |    0.14 |      - |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 100000 | 199,685.812 ns |  3,881.3942 ns |  3,630.6585 ns | 200,106.689 ns |  1.33 |    0.09 |      - |      32 B |          NA |
| ICollectionForEachLoopWithCastToList                      | 100000 | 274,585.356 ns |  4,349.7699 ns |  4,068.7775 ns | 275,215.308 ns |  1.82 |    0.11 |      - |      40 B |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 100000 | 141,696.268 ns |  2,876.6391 ns |  8,436.6846 ns | 141,783.154 ns |  0.92 |    0.08 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 100000 | 154,487.189 ns |  3,407.1699 ns |  9,775.8092 ns | 152,900.146 ns |  1.01 |    0.09 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 447,384.227 ns | 13,026.5509 ns | 37,792.3861 ns | 435,149.365 ns |  2.91 |    0.30 |      - |      40 B |          NA |
