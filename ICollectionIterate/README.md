# Test performance of iterating over ICollection.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-HFAZRI : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count  | Mean           | Error          | StdDev          | Median         | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------- |---------------:|---------------:|----------------:|---------------:|------:|--------:|-------:|----------:|------------:|
| **ICollectionForLoopWithCastToArray**                         | **10**     |       **8.260 ns** |      **0.2652 ns** |       **0.7820 ns** |       **7.968 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 10     |      35.997 ns |      1.5504 ns |       4.5713 ns |      34.223 ns |  4.40 |    0.73 | 0.0074 |      32 B |          NA |
| ICollectionForEachLoopWithListAsICollection               | 10     |      50.477 ns |      1.9486 ns |       5.7455 ns |      48.438 ns |  6.15 |    0.83 | 0.0092 |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 10     |       7.683 ns |      0.3875 ns |       1.1425 ns |       7.334 ns |  0.94 |    0.15 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 10     |      12.259 ns |      0.4333 ns |       1.2776 ns |      11.989 ns |  1.50 |    0.20 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 10     |       8.951 ns |      0.3649 ns |       1.0758 ns |       8.566 ns |  1.09 |    0.15 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 10     |       7.010 ns |      0.4223 ns |       1.2451 ns |       6.669 ns |  0.86 |    0.18 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      62.799 ns |      2.4518 ns |       7.2293 ns |      60.809 ns |  7.68 |    1.25 | 0.0092 |      40 B |          NA |
|                                                           |        |                |                |                 |                |       |         |        |           |             |
| **ICollectionForLoopWithCastToArray**                         | **100000** | **153,221.874 ns** |  **3,041.7087 ns** |   **8,428.5605 ns** | **153,355.273 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 100000 | 239,202.620 ns | 11,108.1366 ns |  32,752.5914 ns | 226,282.153 ns |  1.58 |    0.25 |      - |      32 B |          NA |
| ICollectionForEachLoopWithListAsICollection               | 100000 | 331,337.549 ns | 19,846.7992 ns |  58,518.7352 ns | 311,830.591 ns |  2.20 |    0.41 |      - |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 100000 | 151,079.233 ns |  3,016.1736 ns |   6,869.3536 ns | 151,540.820 ns |  0.99 |    0.08 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 100000 | 166,390.001 ns |  4,075.1070 ns |  12,015.5450 ns | 162,763.940 ns |  1.10 |    0.11 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 100000 | 151,261.844 ns |  2,995.1079 ns |   7,784.6836 ns | 151,160.498 ns |  0.99 |    0.07 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 100000 | 150,688.917 ns |  2,973.5464 ns |   5,511.6589 ns | 151,038.623 ns |  0.98 |    0.07 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 468,197.918 ns | 35,811.7629 ns | 105,591.7908 ns | 417,217.725 ns |  3.11 |    0.74 |      - |      40 B |          NA |
