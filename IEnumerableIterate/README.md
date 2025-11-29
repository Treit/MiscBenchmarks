# Test performance of iterating over IEnumerable vs casting to underlying collection types like array or list.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Job       | Runtime   | Count | Mean         | Error       | StdDev     | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------------------- |---------- |---------- |------ |-------------:|------------:|-----------:|-------------:|------:|--------:|----------:|------------:|
| **IEnumerableForLoopWithCastToArray**                         | **.NET 10.0** | **.NET 10.0** | **10**    |     **4.771 ns** |   **0.0398 ns** |  **0.0372 ns** |     **4.768 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | .NET 10.0 | .NET 10.0 | 10    |     4.668 ns |   0.1263 ns |  0.2075 ns |     4.632 ns |  0.98 |    0.04 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | .NET 10.0 | .NET 10.0 | 10    |    10.651 ns |   0.2443 ns |  0.4707 ns |    10.372 ns |  2.23 |    0.10 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | .NET 10.0 | .NET 10.0 | 10    |     4.365 ns |   0.0519 ns |  0.0486 ns |     4.371 ns |  0.91 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | .NET 10.0 | .NET 10.0 | 10    |     9.108 ns |   0.0534 ns |  0.0499 ns |     9.121 ns |  1.91 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | .NET 10.0 | .NET 10.0 | 10    |     5.215 ns |   0.0767 ns |  0.0718 ns |     5.193 ns |  1.09 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | .NET 10.0 | .NET 10.0 | 10    |     4.168 ns |   0.0394 ns |  0.0369 ns |     4.171 ns |  0.87 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 10.0 | .NET 10.0 | 10    |    14.529 ns |   0.2150 ns |  0.2011 ns |    14.495 ns |  3.05 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | .NET 10.0 | .NET 10.0 | 10    |    14.335 ns |   0.1726 ns |  0.1614 ns |    14.244 ns |  3.00 |    0.04 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | .NET 10.0 | .NET 10.0 | 10    |    10.145 ns |   0.1191 ns |  0.1114 ns |    10.175 ns |  2.13 |    0.03 |         - |          NA |
|                                                           |           |           |       |              |             |            |              |       |         |           |             |
| IEnumerableForLoopWithCastToArray                         | .NET 9.0  | .NET 9.0  | 10    |     4.766 ns |   0.0350 ns |  0.0328 ns |     4.771 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | .NET 9.0  | .NET 9.0  | 10    |     4.648 ns |   0.0586 ns |  0.0548 ns |     4.649 ns |  0.98 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | .NET 9.0  | .NET 9.0  | 10    |    10.517 ns |   0.2375 ns |  0.4033 ns |    10.305 ns |  2.21 |    0.08 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | .NET 9.0  | .NET 9.0  | 10    |     4.358 ns |   0.0345 ns |  0.0323 ns |     4.361 ns |  0.91 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | .NET 9.0  | .NET 9.0  | 10    |     9.068 ns |   0.1077 ns |  0.1007 ns |     9.098 ns |  1.90 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | .NET 9.0  | .NET 9.0  | 10    |     5.183 ns |   0.0286 ns |  0.0267 ns |     5.184 ns |  1.09 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | .NET 9.0  | .NET 9.0  | 10    |     4.156 ns |   0.0465 ns |  0.0435 ns |     4.158 ns |  0.87 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 9.0  | .NET 9.0  | 10    |    14.468 ns |   0.1301 ns |  0.1217 ns |    14.484 ns |  3.04 |    0.03 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | .NET 9.0  | .NET 9.0  | 10    |    14.383 ns |   0.1433 ns |  0.1341 ns |    14.407 ns |  3.02 |    0.03 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | .NET 9.0  | .NET 9.0  | 10    |    10.139 ns |   0.1056 ns |  0.0988 ns |    10.157 ns |  2.13 |    0.02 |         - |          NA |
|                                                           |           |           |       |              |             |            |              |       |         |           |             |
| **IEnumerableForLoopWithCastToArray**                         | **.NET 10.0** | **.NET 10.0** | **5000**  | **2,101.913 ns** |  **20.3676 ns** | **19.0519 ns** | **2,102.159 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | .NET 10.0 | .NET 10.0 | 5000  | 2,283.591 ns |  17.3561 ns | 16.2349 ns | 2,282.482 ns |  1.09 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | .NET 10.0 | .NET 10.0 | 5000  | 3,647.775 ns |  28.4547 ns | 26.6165 ns | 3,640.449 ns |  1.74 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | .NET 10.0 | .NET 10.0 | 5000  | 2,086.929 ns |  19.3088 ns | 18.0615 ns | 2,083.788 ns |  0.99 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | .NET 10.0 | .NET 10.0 | 5000  | 3,688.439 ns |  13.3134 ns | 12.4533 ns | 3,688.645 ns |  1.75 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | .NET 10.0 | .NET 10.0 | 5000  | 2,092.010 ns |  15.5029 ns | 14.5014 ns | 2,097.470 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | .NET 10.0 | .NET 10.0 | 5000  | 2,093.069 ns |  24.8842 ns | 23.2767 ns | 2,095.575 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 10.0 | .NET 10.0 | 5000  | 6,201.304 ns | 102.6780 ns | 96.0450 ns | 6,222.259 ns |  2.95 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | .NET 10.0 | .NET 10.0 | 5000  | 4,894.134 ns |  59.0573 ns | 55.2422 ns | 4,894.865 ns |  2.33 |    0.03 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | .NET 10.0 | .NET 10.0 | 5000  | 4,818.533 ns |  49.3343 ns | 46.1474 ns | 4,815.283 ns |  2.29 |    0.03 |         - |          NA |
|                                                           |           |           |       |              |             |            |              |       |         |           |             |
| IEnumerableForLoopWithCastToArray                         | .NET 9.0  | .NET 9.0  | 5000  | 2,092.286 ns |  28.7128 ns | 26.8580 ns | 2,096.550 ns |  1.00 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | .NET 9.0  | .NET 9.0  | 5000  | 2,288.626 ns |  27.1623 ns | 25.4076 ns | 2,288.589 ns |  1.09 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | .NET 9.0  | .NET 9.0  | 5000  | 3,663.224 ns |  31.8615 ns | 29.8033 ns | 3,651.855 ns |  1.75 |    0.03 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | .NET 9.0  | .NET 9.0  | 5000  | 2,097.122 ns |  28.4271 ns | 26.5908 ns | 2,095.055 ns |  1.00 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | .NET 9.0  | .NET 9.0  | 5000  | 3,689.215 ns |  24.0416 ns | 22.4885 ns | 3,684.602 ns |  1.76 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | .NET 9.0  | .NET 9.0  | 5000  | 2,089.396 ns |  15.0867 ns | 14.1121 ns | 2,095.105 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | .NET 9.0  | .NET 9.0  | 5000  | 2,088.261 ns |  18.1676 ns | 16.9940 ns | 2,093.868 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 9.0  | .NET 9.0  | 5000  | 6,206.109 ns |  82.6292 ns | 77.2914 ns | 6,197.343 ns |  2.97 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | .NET 9.0  | .NET 9.0  | 5000  | 4,901.440 ns |  57.8410 ns | 54.1045 ns | 4,901.257 ns |  2.34 |    0.04 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | .NET 9.0  | .NET 9.0  | 5000  | 4,762.117 ns |  35.1208 ns | 32.8520 ns | 4,766.949 ns |  2.28 |    0.03 |         - |          NA |
