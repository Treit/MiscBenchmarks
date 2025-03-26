# Test performance of iterating over IEnumerable vs casting to underlying collection types like array or list.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27823.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-DNPGZS : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count | Mean          | Error       | StdDev        | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------ |--------------:|------------:|--------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **IEnumerableForLoopWithCastToArray**                         | **10**    |      **8.645 ns** |   **0.3869 ns** |     **1.1407 ns** |      **8.442 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 10    |     34.168 ns |   0.7116 ns |     1.4696 ns |     34.033 ns |  4.03 |    0.40 | 0.0074 |      32 B |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 10    |     48.489 ns |   0.9872 ns |     1.1368 ns |     48.293 ns |  5.98 |    0.17 | 0.0092 |      40 B |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 10    |      6.906 ns |   0.1756 ns |     0.4372 ns |      6.755 ns |  0.81 |    0.10 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 10    |     11.189 ns |   0.2581 ns |     0.7021 ns |     10.904 ns |  1.31 |    0.16 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 10    |      8.620 ns |   0.2054 ns |     0.4637 ns |      8.458 ns |  1.02 |    0.11 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 10    |      5.574 ns |   0.1469 ns |     0.3001 ns |      5.474 ns |  0.66 |    0.07 |      - |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 10    |     55.336 ns |   1.1385 ns |     3.0192 ns |     54.406 ns |  6.49 |    0.77 | 0.0092 |      40 B |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | 10    |     44.721 ns |   0.9277 ns |     2.7207 ns |     44.407 ns |  5.24 |    0.58 | 0.0092 |      40 B |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | 10    |     15.211 ns |   0.3366 ns |     0.4719 ns |     15.091 ns |  1.85 |    0.12 |      - |         - |          NA |
|                                                           |       |               |             |               |               |       |         |        |           |             |
| **IEnumerableForLoopWithCastToArray**                         | **5000**  |  **7,138.183 ns** |  **31.2120 ns** |    **29.1958 ns** |  **7,141.102 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| IEnumerableForEachLoopWithArrayAsIEnumerable              | 5000  | 13,016.737 ns | 259.5333 ns |   569.6820 ns | 12,786.383 ns |  1.89 |    0.12 |      - |      32 B |          NA |
| IEnumerableForEachLoopWithListAsIEnumerable               | 5000  | 18,805.926 ns | 364.4647 ns |   588.5426 ns | 18,677.696 ns |  2.66 |    0.09 |      - |      40 B |          NA |
| IEnumerableForEachLoopWithCastToArray                     | 5000  |  3,071.544 ns |  56.7747 ns |    53.1071 ns |  3,057.841 ns |  0.43 |    0.01 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToList                      | 5000  |  4,747.394 ns |  94.6978 ns |   252.7677 ns |  4,651.352 ns |  0.65 |    0.02 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToListAndSpan               | 5000  |  3,064.309 ns |  42.1412 ns |    39.4189 ns |  3,053.419 ns |  0.43 |    0.01 |      - |         - |          NA |
| IEnumerableForEachLoopWithCastToArrayAndSpan              | 5000  |  3,316.028 ns | 109.6027 ns |   323.1661 ns |  3,213.655 ns |  0.51 |    0.07 |      - |         - |          NA |
| IEnumerableForEachLoopNoCastUnderlyingCollectionIsHashSet | 5000  | 21,764.332 ns | 967.7896 ns | 2,853.5495 ns | 20,733.121 ns |  2.94 |    0.20 |      - |      40 B |          NA |
| IEnumerableForEachLoopDictionaryKeys                      | 5000  | 16,008.788 ns | 424.1603 ns | 1,250.6463 ns | 15,733.376 ns |  2.21 |    0.14 |      - |      40 B |          NA |
| IEnumerableForEachLoopDictionaryKeyValuePairs             | 5000  |  7,610.535 ns | 182.8576 ns |   539.1598 ns |  7,474.858 ns |  1.12 |    0.14 |      - |         - |          NA |
