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
| **ICollectionForLoopWithCastToArray**                         | **10**     |       **4.767 ns** |     **0.0256 ns** |     **0.0239 ns** |       **4.762 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 10     |       4.849 ns |     0.2255 ns |     0.6649 ns |       4.596 ns |  1.02 |    0.14 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | 10     |       9.874 ns |     0.0700 ns |     0.0655 ns |       9.870 ns |  2.07 |    0.02 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | 10     |       4.348 ns |     0.0390 ns |     0.0365 ns |       4.343 ns |  0.91 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 10     |       8.690 ns |     0.0918 ns |     0.0859 ns |       8.699 ns |  1.82 |    0.02 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 10     |       5.132 ns |     0.0287 ns |     0.0269 ns |       5.139 ns |  1.08 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 10     |       4.147 ns |     0.0451 ns |     0.0422 ns |       4.136 ns |  0.87 |    0.01 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      14.161 ns |     0.1605 ns |     0.1502 ns |      14.179 ns |  2.97 |    0.03 |         - |          NA |
|                                                           |        |                |               |               |                |       |         |           |             |
| **ICollectionForLoopWithCastToArray**                         | **100000** |  **66,616.933 ns** | **1,435.3994 ns** | **4,232.3078 ns** |  **67,929.828 ns** |  **1.00** |    **0.10** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 100000 |  67,336.693 ns | 1,681.5165 ns | 4,957.9896 ns |  68,562.585 ns |  1.02 |    0.11 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | 100000 |  75,712.773 ns |   413.5127 ns |   386.8000 ns |  75,694.922 ns |  1.14 |    0.09 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | 100000 |  65,564.930 ns | 2,049.9682 ns | 6,044.3779 ns |  68,096.716 ns |  0.99 |    0.12 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 100000 |  76,050.678 ns |   578.8876 ns |   541.4919 ns |  76,145.923 ns |  1.15 |    0.09 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 100000 |  68,268.657 ns |   810.4464 ns |   758.0921 ns |  68,463.550 ns |  1.03 |    0.08 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 100000 |  67,071.249 ns | 1,333.9642 ns | 3,583.6086 ns |  68,596.872 ns |  1.01 |    0.09 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 125,188.687 ns |   866.1533 ns |   810.2003 ns | 125,255.005 ns |  1.89 |    0.14 |         - |          NA |
