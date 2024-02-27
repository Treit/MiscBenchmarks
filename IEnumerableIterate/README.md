# Test performance of iterating over IEnumerable vs casting to underlying collection types like array or list.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]   : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  ShortRun : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

Job=ShortRun  OutlierMode=DontRemove  IterationCount=3  
LaunchCount=1  MemoryRandomization=True  WarmupCount=3  

```
| Method                                                    | Count  | Mean           | Error          | StdDev         | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------- |---------------:|---------------:|---------------:|------:|--------:|-------:|----------:|------------:|
| **IEnumerableForLoopWithCastToArray**                         | **10**     |       **8.238 ns** |       **7.366 ns** |      **0.4038 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 10     |      40.975 ns |      34.164 ns |      1.8726 ns |  4.99 |    0.40 | 0.0074 |      32 B |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 10     |      45.169 ns |       7.014 ns |      0.3844 ns |  5.49 |    0.31 | 0.0092 |      40 B |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 10     |       5.592 ns |       1.541 ns |      0.0844 ns |  0.68 |    0.02 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 10     |      11.223 ns |       3.701 ns |      0.2029 ns |  1.36 |    0.05 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 10     |       9.199 ns |       7.432 ns |      0.4074 ns |  1.12 |    0.07 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 10     |       8.243 ns |      11.848 ns |      0.6494 ns |  1.00 |    0.12 |      - |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      59.214 ns |      25.859 ns |      1.4174 ns |  7.19 |    0.21 | 0.0092 |      40 B |          NA |
|                                                           |        |                |                |                |       |         |        |           |             |
| **IEnumerableForLoopWithCastToArray**                         | **100000** | **156,994.759 ns** |  **62,695.870 ns** |  **3,436.5722 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 100000 | 248,150.903 ns | 332,596.038 ns | 18,230.7112 ns |  1.58 |    0.14 |      - |      32 B |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 100000 | 309,806.600 ns | 160,225.926 ns |  8,782.5237 ns |  1.97 |    0.01 |      - |      40 B |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 100000 | 156,316.402 ns |  77,463.239 ns |  4,246.0215 ns |  1.00 |    0.04 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 100000 | 170,850.724 ns |   3,228.366 ns |    176.9576 ns |  1.09 |    0.02 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 100000 | 166,146.464 ns |  95,517.851 ns |  5,235.6557 ns |  1.06 |    0.01 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 100000 | 164,384.058 ns |  71,484.573 ns |  3,918.3106 ns |  1.05 |    0.01 |      - |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 438,343.416 ns | 219,459.664 ns | 12,029.3247 ns |  2.79 |    0.12 |      - |      40 B |          NA |
