# Counting strings in a list using different types of loops.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean             | Error          | StdDev         | Ratio |
|----------------------------------------- |-------- |-----------------:|---------------:|---------------:|------:|
| **ForLoopCount**                             | **10**      |         **7.476 ns** |      **0.0623 ns** |      **0.0583 ns** |  **0.84** |
| ForEachLoopCount                         | 10      |         8.912 ns |      0.0622 ns |      0.0582 ns |  1.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 10      |         5.064 ns |      0.0323 ns |      0.0287 ns |  0.57 |
| ListDotForEachLoopCount                  | 10      |        12.300 ns |      0.1289 ns |      0.1077 ns |  1.38 |
| ListExplicitEnumeratorCount              | 10      |         8.901 ns |      0.0836 ns |      0.0782 ns |  1.00 |
|                                          |         |                  |                |                |       |
| **ForLoopCount**                             | **1000**    |       **721.775 ns** |      **3.7196 ns** |      **3.4793 ns** |  **0.90** |
| ForEachLoopCount                         | 1000    |       806.402 ns |      3.0590 ns |      2.7117 ns |  1.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000    |       521.113 ns |      4.9370 ns |      4.6181 ns |  0.65 |
| ListDotForEachLoopCount                  | 1000    |       920.365 ns |      3.3543 ns |      2.9735 ns |  1.14 |
| ListExplicitEnumeratorCount              | 1000    |       808.496 ns |      2.6458 ns |      2.0656 ns |  1.00 |
|                                          |         |                  |                |                |       |
| **ForLoopCount**                             | **1000000** | **1,724,774.219 ns** | **14,237.1084 ns** | **12,620.8258 ns** |  **0.99** |
| ForEachLoopCount                         | 1000000 | 1,734,370.931 ns | 16,904.8793 ns | 15,812.8346 ns |  1.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000000 | 1,422,217.331 ns | 16,656.2855 ns | 15,580.2998 ns |  0.82 |
| ListDotForEachLoopCount                  | 1000000 | 1,845,514.193 ns | 24,766.7727 ns | 19,336.2671 ns |  1.06 |
| ListExplicitEnumeratorCount              | 1000000 | 1,725,212.799 ns | 18,471.1917 ns | 17,277.9642 ns |  0.99 |
