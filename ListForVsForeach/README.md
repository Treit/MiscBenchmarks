# Counting strings in a list using different types of loops.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                   Method |   Count |             Mean |          Error |         StdDev | Ratio | RatioSD |
|----------------------------------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
|                             **ForLoopCount** |      **10** |         **7.859 ns** |      **0.0449 ns** |      **0.0420 ns** |  **0.85** |    **0.01** |
|                         ForEachLoopCount |      10 |         9.271 ns |      0.0438 ns |      0.0410 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan |      10 |         5.253 ns |      0.0110 ns |      0.0092 ns |  0.57 |    0.00 |
|                  ListDotForEachLoopCount |      10 |        21.739 ns |      0.1659 ns |      0.1552 ns |  2.34 |    0.02 |
|              ListExplicitEnumeratorCount |      10 |         9.033 ns |      0.0223 ns |      0.0198 ns |  0.97 |    0.01 |
|                                          |         |                  |                |                |       |         |
|                             **ForLoopCount** |    **1000** |       **795.897 ns** |      **6.0490 ns** |      **5.3623 ns** |  **0.73** |    **0.00** |
|                         ForEachLoopCount |    1000 |     1,096.252 ns |      5.9054 ns |      5.5239 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan |    1000 |       442.799 ns |      6.1065 ns |      5.7121 ns |  0.40 |    0.01 |
|                  ListDotForEachLoopCount |    1000 |     1,060.895 ns |      1.9639 ns |      1.6399 ns |  0.97 |    0.01 |
|              ListExplicitEnumeratorCount |    1000 |       807.018 ns |      3.8047 ns |      3.5590 ns |  0.74 |    0.00 |
|                                          |         |                  |                |                |       |         |
|                             **ForLoopCount** | **1000000** | **1,627,522.712 ns** | **13,741.8391 ns** | **12,181.7824 ns** |  **0.97** |    **0.01** |
|                         ForEachLoopCount | 1000000 | 1,685,917.090 ns | 15,404.8032 ns | 13,655.9568 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000000 | 1,405,823.275 ns | 11,514.3582 ns | 10,770.5378 ns |  0.83 |    0.01 |
|                  ListDotForEachLoopCount | 1000000 | 1,887,875.521 ns | 17,728.2795 ns | 16,583.0436 ns |  1.12 |    0.01 |
|              ListExplicitEnumeratorCount | 1000000 | 1,682,890.513 ns | 10,511.0114 ns |  9,317.7379 ns |  1.00 |    0.01 |
