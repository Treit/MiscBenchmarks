# Test performance of iterating over ICollection.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count  | Mean           | Error         | StdDev        | Median         | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|----------:|------------:|
| **ICollectionForLoopWithCastToArray**                         | **10**     |       **4.775 ns** |     **0.0262 ns** |     **0.0245 ns** |       **4.778 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 10     |       4.630 ns |     0.0547 ns |     0.0512 ns |       4.632 ns |  0.97 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | 10     |       9.966 ns |     0.0847 ns |     0.0792 ns |       9.973 ns |  2.09 |    0.02 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | 10     |       4.336 ns |     0.0350 ns |     0.0328 ns |       4.341 ns |  0.91 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 10     |       8.711 ns |     0.1305 ns |     0.1220 ns |       8.702 ns |  1.82 |    0.03 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 10     |       5.158 ns |     0.0224 ns |     0.0209 ns |       5.160 ns |  1.08 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 10     |       4.125 ns |     0.0359 ns |     0.0335 ns |       4.123 ns |  0.86 |    0.01 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      14.149 ns |     0.1098 ns |     0.1027 ns |      14.189 ns |  2.96 |    0.03 |         - |          NA |
|                                                           |        |                |               |               |                |       |         |           |             |
| **ICollectionForLoopWithCastToArray**                         | **100000** |  **66,784.811 ns** | **1,820.2403 ns** | **5,367.0201 ns** |  **68,550.476 ns** |  **1.01** |    **0.13** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 100000 |  66,490.431 ns | 1,576.5476 ns | 4,648.4866 ns |  68,121.069 ns |  1.00 |    0.12 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | 100000 |  75,499.153 ns |   880.3863 ns |   823.5139 ns |  75,314.294 ns |  1.14 |    0.11 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | 100000 |  66,624.938 ns | 1,789.7409 ns | 5,277.0918 ns |  68,350.708 ns |  1.01 |    0.13 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 100000 |  76,823.414 ns |   705.8822 ns |   660.2826 ns |  76,855.884 ns |  1.16 |    0.11 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 100000 |  65,326.810 ns | 2,372.5991 ns | 6,995.6626 ns |  67,934.900 ns |  0.99 |    0.14 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 100000 |  66,444.095 ns | 1,858.6509 ns | 5,480.2746 ns |  68,421.338 ns |  1.00 |    0.13 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 125,042.204 ns |   883.6284 ns |   826.5466 ns | 125,172.534 ns |  1.89 |    0.18 |         - |          NA |
