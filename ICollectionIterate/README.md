# Test that converting an ICollection to an array yields better enumeration performance.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26052.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-RBLWVN : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                                    | Count  | Mean           | Error          | StdDev         | Median         | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------------------------- |------- |---------------:|---------------:|---------------:|---------------:|------:|--------:|-------:|----------:|------------:|
| **ICollectionForLoopWithCastToArray**                         | **10**     |       **8.517 ns** |      **0.2105 ns** |      **0.4106 ns** |       **8.430 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 10     |      36.410 ns |      1.8147 ns |      5.3508 ns |      34.389 ns |  4.19 |    0.42 | 0.0074 |      32 B |          NA |
| ICollectionForEachLoopWithListAsICollection               | 10     |      52.195 ns |      1.6668 ns |      4.9145 ns |      50.698 ns |  6.01 |    0.59 | 0.0092 |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 10     |       9.048 ns |      0.6196 ns |      1.8270 ns |       8.520 ns |  1.02 |    0.15 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 10     |      13.510 ns |      0.9510 ns |      2.8040 ns |      12.603 ns |  1.62 |    0.33 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 10     |      11.095 ns |      0.6760 ns |      1.9931 ns |      10.578 ns |  1.20 |    0.20 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 10     |       5.957 ns |      0.2064 ns |      0.6085 ns |       5.779 ns |  0.70 |    0.08 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 10     |      60.131 ns |      1.9180 ns |      5.6554 ns |      58.718 ns |  7.11 |    0.78 | 0.0092 |      40 B |          NA |
|                                                           |        |                |                |                |                |       |         |        |           |             |
| **ICollectionForLoopWithCastToArray**                         | **100000** | **143,876.393 ns** |  **3,042.7067 ns** |  **8,971.4895 ns** | **143,784.534 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| ICollectionForEachLoopWithArrayAsICollection              | 100000 | 231,109.802 ns | 10,403.9318 ns | 30,676.2277 ns | 219,864.124 ns |  1.62 |    0.26 |      - |      32 B |          NA |
| ICollectionForEachLoopWithListAsICollection               | 100000 | 293,033.076 ns |  8,917.2177 ns | 26,292.6176 ns | 283,443.799 ns |  2.05 |    0.23 |      - |      40 B |          NA |
| ICollectionForEachLoopWithCastToArray                     | 100000 | 146,608.669 ns |  3,013.4406 ns |  8,885.1975 ns | 146,828.906 ns |  1.02 |    0.10 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToList                      | 100000 | 162,822.462 ns |  4,149.3638 ns | 12,234.4927 ns | 159,293.750 ns |  1.14 |    0.11 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToListAndSpan               | 100000 | 143,386.690 ns |  2,842.0047 ns |  7,130.0342 ns | 143,528.052 ns |  1.00 |    0.09 |      - |         - |          NA |
| ICollectionForEachLoopWithCastToArrayAndSpan              | 100000 | 146,875.931 ns |  2,932.5745 ns |  8,461.1480 ns | 147,056.995 ns |  1.03 |    0.09 |      - |         - |          NA |
| ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet | 100000 | 440,779.542 ns | 14,419.5262 ns | 42,516.2985 ns | 427,799.268 ns |  3.08 |    0.36 |      - |      40 B |          NA |
