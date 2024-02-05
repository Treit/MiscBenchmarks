# Test that converting an ICollection to an array yields better enumeration performance.




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-MYVCMF : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count  | Mean           | Error          | StdDev         | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------- |---------------:|---------------:|---------------:|------:|--------:|-------:|----------:|------------:|
| **ICollectionForLoopWithCastToArray**                         | **10**     |       **7.703 ns** |      **0.1907 ns** |      **0.3719 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithList                            | 10     |      52.548 ns |      1.4596 ns |      4.3036 ns |  6.81 |    0.61 | 0.0092 |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 10     |       7.142 ns |      0.1840 ns |      0.5425 ns |  0.93 |    0.09 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 10     |      50.991 ns |      1.1790 ns |      3.4762 ns |  6.75 |    0.73 | 0.0092 |      40 B |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 10     |       8.323 ns |      0.2022 ns |      0.2557 ns |  1.09 |    0.05 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 10     |       5.552 ns |      0.1444 ns |      0.2291 ns |  0.72 |    0.05 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      58.330 ns |      1.5446 ns |      4.5544 ns |  7.71 |    0.75 | 0.0092 |      40 B |          NA |
|                                                           |        |                |                |                |       |         |        |           |             |
| **ICollectionForLoopWithCastToArray**                         | **100000** | **145,273.191 ns** |  **2,897.3874 ns** |  **8,172.1327 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithList                            | 100000 | 281,992.121 ns |  5,632.6013 ns | 14,936.8596 ns |  1.95 |    0.16 |      - |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 100000 | 142,098.226 ns |  3,111.6227 ns |  9,174.6897 ns |  0.98 |    0.08 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 100000 | 278,067.037 ns |  5,477.4970 ns |  9,448.4132 ns |  1.93 |    0.12 |      - |      40 B |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 100000 | 151,729.336 ns |  3,830.5712 ns | 11,294.5256 ns |  1.05 |    0.09 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 100000 | 144,703.092 ns |  3,283.1106 ns |  9,680.3258 ns |  1.00 |    0.08 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 442,717.717 ns | 14,120.2369 ns | 41,633.8371 ns |  3.06 |    0.36 |      - |      40 B |          NA |
