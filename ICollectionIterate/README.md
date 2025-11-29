# Test performance of iterating over ICollection.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Job       | Runtime   | Count  | Mean           | Error         | StdDev        | Median         | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------------------- |---------- |---------- |------- |---------------:|--------------:|--------------:|---------------:|------:|--------:|----------:|------------:|
| **ICollectionForLoopWithCastToArray**                         | **.NET 10.0** | **.NET 10.0** | **10**     |       **4.740 ns** |     **0.0278 ns** |     **0.0260 ns** |       **4.739 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | .NET 10.0 | .NET 10.0 | 10     |       4.673 ns |     0.0911 ns |     0.0853 ns |       4.660 ns |  0.99 |    0.02 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | .NET 10.0 | .NET 10.0 | 10     |      10.742 ns |     0.2460 ns |     0.7057 ns |      10.357 ns |  2.27 |    0.15 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | .NET 10.0 | .NET 10.0 | 10     |       4.364 ns |     0.0302 ns |     0.0283 ns |       4.361 ns |  0.92 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | .NET 10.0 | .NET 10.0 | 10     |       9.076 ns |     0.1376 ns |     0.1287 ns |       9.083 ns |  1.91 |    0.03 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | .NET 10.0 | .NET 10.0 | 10     |       5.207 ns |     0.0515 ns |     0.0482 ns |       5.207 ns |  1.10 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | .NET 10.0 | .NET 10.0 | 10     |       4.568 ns |     0.1526 ns |     0.4498 ns |       4.231 ns |  0.96 |    0.09 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 10.0 | .NET 10.0 | 10     |      14.494 ns |     0.1503 ns |     0.1406 ns |      14.526 ns |  3.06 |    0.03 |         - |          NA |
|                                                           |           |           |        |                |               |               |                |       |         |           |             |
| ICollectionForLoopWithCastToArray                         | .NET 9.0  | .NET 9.0  | 10     |       4.780 ns |     0.0543 ns |     0.0508 ns |       4.762 ns |  1.00 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithArrayAsICollection              | .NET 9.0  | .NET 9.0  | 10     |       4.712 ns |     0.1237 ns |     0.1814 ns |       4.644 ns |  0.99 |    0.04 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | .NET 9.0  | .NET 9.0  | 10     |      10.607 ns |     0.2409 ns |     0.5133 ns |      10.344 ns |  2.22 |    0.11 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | .NET 9.0  | .NET 9.0  | 10     |       4.394 ns |     0.0596 ns |     0.0558 ns |       4.384 ns |  0.92 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | .NET 9.0  | .NET 9.0  | 10     |       9.027 ns |     0.1096 ns |     0.1025 ns |       9.069 ns |  1.89 |    0.03 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | .NET 9.0  | .NET 9.0  | 10     |       5.199 ns |     0.0446 ns |     0.0417 ns |       5.186 ns |  1.09 |    0.01 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | .NET 9.0  | .NET 9.0  | 10     |       4.151 ns |     0.0481 ns |     0.0450 ns |       4.141 ns |  0.87 |    0.01 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 9.0  | .NET 9.0  | 10     |      14.618 ns |     0.1985 ns |     0.1857 ns |      14.599 ns |  3.06 |    0.05 |         - |          NA |
|                                                           |           |           |        |                |               |               |                |       |         |           |             |
| **ICollectionForLoopWithCastToArray**                         | **.NET 10.0** | **.NET 10.0** | **100000** |  **61,545.508 ns** | **2,119.0862 ns** | **6,248.1739 ns** |  **62,819.336 ns** |  **1.01** |    **0.15** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | .NET 10.0 | .NET 10.0 | 100000 |  65,286.737 ns | 1,652.8587 ns | 4,873.4916 ns |  67,518.561 ns |  1.07 |    0.14 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | .NET 10.0 | .NET 10.0 | 100000 |  75,333.756 ns | 1,070.5718 ns | 1,001.4135 ns |  75,324.011 ns |  1.24 |    0.13 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | .NET 10.0 | .NET 10.0 | 100000 |  57,908.718 ns | 2,528.7504 ns | 7,456.0781 ns |  52,567.969 ns |  0.95 |    0.16 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | .NET 10.0 | .NET 10.0 | 100000 |  76,463.426 ns |   805.4088 ns |   753.3799 ns |  76,496.021 ns |  1.26 |    0.13 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | .NET 10.0 | .NET 10.0 | 100000 |  60,171.951 ns | 2,327.5409 ns | 6,862.8074 ns |  61,603.830 ns |  0.99 |    0.15 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | .NET 10.0 | .NET 10.0 | 100000 |  62,688.620 ns | 2,130.8052 ns | 6,282.7276 ns |  66,248.944 ns |  1.03 |    0.15 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 10.0 | .NET 10.0 | 100000 | 124,982.619 ns | 1,998.0528 ns | 1,868.9799 ns | 124,366.284 ns |  2.05 |    0.22 |         - |          NA |
|                                                           |           |           |        |                |               |               |                |       |         |           |             |
| ICollectionForLoopWithCastToArray                         | .NET 9.0  | .NET 9.0  | 100000 |  60,782.454 ns | 2,491.7143 ns | 7,346.8764 ns |  64,308.929 ns |  1.02 |    0.18 |         - |          NA |
| ICollectionForEachLoopWithArrayAsICollection              | .NET 9.0  | .NET 9.0  | 100000 |  65,587.380 ns | 1,482.7502 ns | 4,371.9226 ns |  67,596.817 ns |  1.10 |    0.15 |         - |          NA |
| ICollectionForEachLoopWithListAsICollection               | .NET 9.0  | .NET 9.0  | 100000 |  76,084.751 ns |   483.2541 ns |   452.0362 ns |  76,081.152 ns |  1.27 |    0.16 |         - |          NA |
| ICollectionForEachLoopWithCastToArray                     | .NET 9.0  | .NET 9.0  | 100000 |  64,602.382 ns | 2,033.9514 ns | 5,997.1521 ns |  67,395.361 ns |  1.08 |    0.17 |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | .NET 9.0  | .NET 9.0  | 100000 |  75,840.375 ns |   787.6093 ns |   736.7303 ns |  75,715.503 ns |  1.27 |    0.16 |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | .NET 9.0  | .NET 9.0  | 100000 |  56,144.750 ns | 2,352.1829 ns | 6,935.4648 ns |  52,005.054 ns |  0.94 |    0.16 |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | .NET 9.0  | .NET 9.0  | 100000 |  59,941.612 ns | 2,536.2161 ns | 7,478.0909 ns |  61,682.050 ns |  1.00 |    0.18 |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | .NET 9.0  | .NET 9.0  | 100000 | 124,657.710 ns | 1,313.5382 ns | 1,228.6844 ns | 124,465.967 ns |  2.08 |    0.26 |         - |          NA |
