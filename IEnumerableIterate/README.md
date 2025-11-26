# Test performance of iterating over IEnumerable vs casting to underlying collection types like array or list.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count | Mean         | Error      | StdDev     | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|----------:|------------:|
| **IEnumerableForLoopWithCastToArray**                         | **10**    |     **4.772 ns** |  **0.0459 ns** |  **0.0429 ns** |     **4.767 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 10    |     4.585 ns |  0.0297 ns |  0.0278 ns |     4.585 ns |  0.96 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 10    |    10.758 ns |  0.2462 ns |  0.6613 ns |    10.426 ns |  2.25 |    0.14 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 10    |     4.344 ns |  0.0394 ns |  0.0369 ns |     4.343 ns |  0.91 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 10    |     9.070 ns |  0.0577 ns |  0.0539 ns |     9.082 ns |  1.90 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 10    |     5.177 ns |  0.0243 ns |  0.0227 ns |     5.184 ns |  1.08 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 10    |     4.148 ns |  0.0319 ns |  0.0299 ns |     4.147 ns |  0.87 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 10    |    14.409 ns |  0.1068 ns |  0.0999 ns |    14.425 ns |  3.02 |    0.03 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | 10    |    14.437 ns |  0.2412 ns |  0.2257 ns |    14.410 ns |  3.03 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | 10    |    10.195 ns |  0.2335 ns |  0.4090 ns |    10.125 ns |  2.14 |    0.09 |         - |          NA |
|                                                           |       |              |            |            |              |       |         |           |             |
| **IEnumerableForLoopWithCastToArray**                         | **5000**  | **2,086.988 ns** | **23.6147 ns** | **22.0892 ns** | **2,092.881 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 5000  | 2,282.254 ns | 17.5591 ns | 16.4248 ns | 2,283.054 ns |  1.09 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 5000  | 3,783.957 ns | 22.5993 ns | 21.1394 ns | 3,783.749 ns |  1.81 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 5000  | 2,081.386 ns | 16.3437 ns | 15.2879 ns | 2,090.670 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 5000  | 3,689.089 ns | 16.2096 ns | 15.1624 ns | 3,682.506 ns |  1.77 |    0.02 |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 5000  | 2,085.939 ns | 17.3921 ns | 16.2686 ns | 2,093.381 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 5000  | 2,086.949 ns | 24.2952 ns | 22.7258 ns | 2,087.839 ns |  1.00 |    0.01 |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 5000  | 6,259.483 ns | 81.6168 ns | 76.3444 ns | 6,267.551 ns |  3.00 |    0.05 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | 5000  | 4,876.112 ns | 53.3509 ns | 49.9045 ns | 4,871.958 ns |  2.34 |    0.03 |         - |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | 5000  | 4,770.957 ns | 45.9743 ns | 43.0044 ns | 4,758.575 ns |  2.29 |    0.03 |         - |          NA |
