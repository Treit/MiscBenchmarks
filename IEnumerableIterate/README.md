# Test performance of iterating over IEnumerable vs casting to underlying collection types like array or list.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count | Mean         | Error       | StdDev      | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |-------------:|------------:|------------:|-------------:|------:|--------:|----------:|------------:|
| **IEnumerableForLoopWithCastToArray**                         | **10**    |     **4.379 ns** |   **0.0705 ns** |   **0.0660 ns** |     **4.365 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 10    |     4.578 ns |   0.0157 ns |   0.0146 ns |     4.578 ns |  1.05 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 10    |    10.631 ns |   0.2450 ns |   0.7186 ns |    10.275 ns |  2.43 |    0.17 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 10    |     4.327 ns |   0.0321 ns |   0.0300 ns |     4.331 ns |  0.99 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 10    |     9.041 ns |   0.0469 ns |   0.0438 ns |     9.060 ns |  2.07 |    0.03 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 10    |     5.142 ns |   0.0273 ns |   0.0256 ns |     5.147 ns |  1.17 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 10    |     4.153 ns |   0.0355 ns |   0.0332 ns |     4.153 ns |  0.95 |    0.02 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 10    |    14.455 ns |   0.1231 ns |   0.1152 ns |    14.484 ns |  3.30 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | 10    |    14.270 ns |   0.1313 ns |   0.1228 ns |    14.299 ns |  3.26 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | 10    |    10.080 ns |   0.0583 ns |   0.0545 ns |    10.092 ns |  2.30 |    0.04 |         - |          NA |
|                                                           |       |              |             |             |              |       |         |           |             |
| **IEnumerableForLoopWithCastToArray**                         | **5000**  | **2,082.910 ns** |  **12.6090 ns** |  **11.7944 ns** | **2,087.794 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 5000  | 2,274.706 ns |  21.1541 ns |  19.7875 ns | 2,275.602 ns |  1.09 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 5000  | 3,656.973 ns |  29.2377 ns |  27.3489 ns | 3,653.384 ns |  1.76 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 5000  | 2,071.128 ns |  16.1457 ns |  15.1027 ns | 2,079.701 ns |  0.99 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 5000  | 3,675.333 ns |  10.5044 ns |   9.8258 ns | 3,672.388 ns |  1.76 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 5000  | 2,083.867 ns |  15.6584 ns |  14.6469 ns | 2,088.354 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 5000  | 2,075.217 ns |  13.9933 ns |  13.0894 ns | 2,083.396 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 5000  | 6,086.568 ns |  31.9219 ns |  29.8598 ns | 6,079.907 ns |  2.92 |    0.02 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | 5000  | 5,091.972 ns | 101.6435 ns | 251.2376 ns | 5,141.185 ns |  2.44 |    0.12 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | 5000  | 4,805.933 ns |  62.5117 ns |  58.4735 ns | 4,807.842 ns |  2.31 |    0.03 |         - |          NA |
