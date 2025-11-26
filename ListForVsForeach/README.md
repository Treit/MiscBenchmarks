# Counting strings in a list using different types of loops.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean             | Error          | StdDev         | Ratio | RatioSD |
|----------------------------------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
| **ForLoopCount**                             | **10**      |         **7.478 ns** |      **0.0835 ns** |      **0.0781 ns** |  **0.84** |    **0.01** |
| ForEachLoopCount                         | 10      |         8.910 ns |      0.0732 ns |      0.0685 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | 10      |         5.041 ns |      0.0355 ns |      0.0332 ns |  0.57 |    0.01 |
| ListDotForEachLoopCount                  | 10      |        12.282 ns |      0.0692 ns |      0.0613 ns |  1.38 |    0.01 |
| ListExplicitEnumeratorCount              | 10      |         8.926 ns |      0.0610 ns |      0.0541 ns |  1.00 |    0.01 |
|                                          |         |                  |                |                |       |         |
| **ForLoopCount**                             | **1000**    |       **723.807 ns** |      **4.2530 ns** |      **3.7702 ns** |  **0.90** |    **0.01** |
| ForEachLoopCount                         | 1000    |       803.545 ns |      3.4090 ns |      3.1888 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000    |       526.780 ns |      5.0758 ns |      4.4996 ns |  0.66 |    0.01 |
| ListDotForEachLoopCount                  | 1000    |       922.376 ns |      4.2312 ns |      3.9579 ns |  1.15 |    0.01 |
| ListExplicitEnumeratorCount              | 1000    |       808.810 ns |      3.1133 ns |      2.7599 ns |  1.01 |    0.01 |
|                                          |         |                  |                |                |       |         |
| **ForLoopCount**                             | **1000000** | **1,700,566.484 ns** | **15,210.3692 ns** | **14,227.7888 ns** |  **1.01** |    **0.01** |
| ForEachLoopCount                         | 1000000 | 1,686,409.593 ns | 20,237.1556 ns | 16,898.9414 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | 1000000 | 1,444,446.833 ns | 13,550.4080 ns | 12,012.0837 ns |  0.86 |    0.01 |
| ListDotForEachLoopCount                  | 1000000 | 1,840,987.625 ns | 36,672.7712 ns | 48,957.1003 ns |  1.09 |    0.03 |
| ListExplicitEnumeratorCount              | 1000000 | 1,705,712.904 ns | 12,980.3305 ns | 12,141.8092 ns |  1.01 |    0.01 |
