# Counting strings in a list using different types of loops.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Job       | Runtime   | Count   | Mean             | Error          | StdDev         | Median           | Ratio | RatioSD |
|----------------------------------------- |---------- |---------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
| **ForLoopCount**                             | **.NET 10.0** | **.NET 10.0** | **10**      |         **7.573 ns** |      **0.0640 ns** |      **0.0567 ns** |         **7.565 ns** |  **0.89** |    **0.01** |
| ForEachLoopCount                         | .NET 10.0 | .NET 10.0 | 10      |         8.462 ns |      0.0420 ns |      0.0372 ns |         8.458 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | .NET 10.0 | .NET 10.0 | 10      |         5.095 ns |      0.0295 ns |      0.0246 ns |         5.098 ns |  0.60 |    0.00 |
| ListDotForEachLoopCount                  | .NET 10.0 | .NET 10.0 | 10      |        12.305 ns |      0.0777 ns |      0.0727 ns |        12.302 ns |  1.45 |    0.01 |
| ListExplicitEnumeratorCount              | .NET 10.0 | .NET 10.0 | 10      |         8.621 ns |      0.1989 ns |      0.1763 ns |         8.536 ns |  1.02 |    0.02 |
|                                          |           |           |         |                  |                |                |                  |       |         |
| ForLoopCount                             | .NET 9.0  | .NET 9.0  | 10      |         7.549 ns |      0.0500 ns |      0.0468 ns |         7.534 ns |  0.89 |    0.01 |
| ForEachLoopCount                         | .NET 9.0  | .NET 9.0  | 10      |         8.484 ns |      0.1388 ns |      0.1231 ns |         8.436 ns |  1.00 |    0.02 |
| ForEachLoopCountCollectionsMarshalAsSpan | .NET 9.0  | .NET 9.0  | 10      |         5.086 ns |      0.0301 ns |      0.0282 ns |         5.087 ns |  0.60 |    0.01 |
| ListDotForEachLoopCount                  | .NET 9.0  | .NET 9.0  | 10      |        12.305 ns |      0.1086 ns |      0.0962 ns |        12.308 ns |  1.45 |    0.02 |
| ListExplicitEnumeratorCount              | .NET 9.0  | .NET 9.0  | 10      |         8.478 ns |      0.0343 ns |      0.0286 ns |         8.474 ns |  1.00 |    0.01 |
|                                          |           |           |         |                  |                |                |                  |       |         |
| **ForLoopCount**                             | **.NET 10.0** | **.NET 10.0** | **1000**    |       **997.557 ns** |     **19.6526 ns** |     **38.7923 ns** |     **1,010.282 ns** |  **1.28** |    **0.05** |
| ForEachLoopCount                         | .NET 10.0 | .NET 10.0 | 1000    |       780.546 ns |      2.4555 ns |      2.1767 ns |       779.674 ns |  1.00 |    0.00 |
| ForEachLoopCountCollectionsMarshalAsSpan | .NET 10.0 | .NET 10.0 | 1000    |       519.801 ns |      2.1247 ns |      1.9875 ns |       520.029 ns |  0.67 |    0.00 |
| ListDotForEachLoopCount                  | .NET 10.0 | .NET 10.0 | 1000    |       926.318 ns |      2.9536 ns |      2.4664 ns |       926.129 ns |  1.19 |    0.00 |
| ListExplicitEnumeratorCount              | .NET 10.0 | .NET 10.0 | 1000    |       784.595 ns |      3.9478 ns |      3.2966 ns |       784.316 ns |  1.01 |    0.00 |
|                                          |           |           |         |                  |                |                |                  |       |         |
| ForLoopCount                             | .NET 9.0  | .NET 9.0  | 1000    |       983.668 ns |     19.6722 ns |     45.5932 ns |     1,000.414 ns |  1.26 |    0.06 |
| ForEachLoopCount                         | .NET 9.0  | .NET 9.0  | 1000    |       781.769 ns |      3.2010 ns |      2.9942 ns |       781.357 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | .NET 9.0  | .NET 9.0  | 1000    |       521.577 ns |      2.6555 ns |      2.3540 ns |       522.180 ns |  0.67 |    0.00 |
| ListDotForEachLoopCount                  | .NET 9.0  | .NET 9.0  | 1000    |       925.030 ns |      2.2434 ns |      1.8733 ns |       924.255 ns |  1.18 |    0.00 |
| ListExplicitEnumeratorCount              | .NET 9.0  | .NET 9.0  | 1000    |       786.574 ns |      9.9075 ns |      8.7828 ns |       783.302 ns |  1.01 |    0.01 |
|                                          |           |           |         |                  |                |                |                  |       |         |
| **ForLoopCount**                             | **.NET 10.0** | **.NET 10.0** | **1000000** | **1,640,581.829 ns** | **15,467.9431 ns** | **14,468.7236 ns** | **1,636,228.418 ns** |  **0.97** |    **0.01** |
| ForEachLoopCount                         | .NET 10.0 | .NET 10.0 | 1000000 | 1,685,681.732 ns | 13,287.3211 ns | 12,428.9684 ns | 1,680,439.258 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | .NET 10.0 | .NET 10.0 | 1000000 | 1,371,899.622 ns | 11,141.1901 ns | 10,421.4761 ns | 1,369,147.461 ns |  0.81 |    0.01 |
| ListDotForEachLoopCount                  | .NET 10.0 | .NET 10.0 | 1000000 | 1,813,858.371 ns | 33,396.1621 ns | 29,604.8279 ns | 1,812,532.812 ns |  1.08 |    0.02 |
| ListExplicitEnumeratorCount              | .NET 10.0 | .NET 10.0 | 1000000 | 1,705,241.992 ns | 11,816.4022 ns | 11,053.0700 ns | 1,705,491.992 ns |  1.01 |    0.01 |
|                                          |           |           |         |                  |                |                |                  |       |         |
| ForLoopCount                             | .NET 9.0  | .NET 9.0  | 1000000 | 1,637,330.664 ns |  8,600.3755 ns |  7,181.7031 ns | 1,638,535.547 ns |  0.96 |    0.01 |
| ForEachLoopCount                         | .NET 9.0  | .NET 9.0  | 1000000 | 1,698,565.052 ns | 10,266.9950 ns |  9,603.7535 ns | 1,698,748.242 ns |  1.00 |    0.01 |
| ForEachLoopCountCollectionsMarshalAsSpan | .NET 9.0  | .NET 9.0  | 1000000 | 1,359,701.699 ns |  9,927.5892 ns |  9,286.2731 ns | 1,364,079.004 ns |  0.80 |    0.01 |
| ListDotForEachLoopCount                  | .NET 9.0  | .NET 9.0  | 1000000 | 1,798,863.728 ns | 26,294.3123 ns | 23,309.2229 ns | 1,804,476.562 ns |  1.06 |    0.01 |
| ListExplicitEnumeratorCount              | .NET 9.0  | .NET 9.0  | 1000000 | 1,725,365.951 ns | 17,822.5180 ns | 13,914.6497 ns | 1,729,789.746 ns |  1.02 |    0.01 |
