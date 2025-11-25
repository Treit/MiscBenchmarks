## Similarity matching




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-KEOOAO : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                    | Count | Mean           | Error       | StdDev      | Median         | Ratio | RatioSD |
|------------------------------------------ |------ |---------------:|------------:|------------:|---------------:|------:|--------:|
| **CheckHashesNoLookup**                       | **100**   |    **11,596.6 ns** |    **50.77 ns** |    **47.49 ns** |    **11,600.8 ns** | **25.51** |    **0.84** |
| CheckHashesOriginalWithLookup             | 100   |     4,099.6 ns |    25.55 ns |    23.90 ns |     4,114.7 ns |  9.02 |    0.30 |
| CheckHashesWithSpanTable                  | 100   |     4,633.0 ns |    92.48 ns |   126.58 ns |     4,657.0 ns | 10.19 |    0.43 |
| CheckHashesKozi                           | 100   |     4,068.2 ns |    28.59 ns |    26.74 ns |     4,084.6 ns |  8.95 |    0.30 |
| CheckHashesTechPizza                      | 100   |     3,446.6 ns |    26.98 ns |    25.24 ns |     3,441.2 ns |  7.58 |    0.25 |
| CheckHashesSauceControl                   | 100   |     3,643.2 ns |    12.37 ns |    11.57 ns |     3,643.0 ns |  8.01 |    0.26 |
| CheckHashesSauceControlUnrolledKozi       | 100   |     2,680.9 ns |    16.45 ns |    15.39 ns |     2,681.6 ns |  5.90 |    0.19 |
| CheckHashesHugeLookupTable                | 100   |     2,217.5 ns |    24.39 ns |    22.81 ns |     2,214.6 ns |  4.88 |    0.17 |
| CheckHashesSauceControlUnrolled           | 100   |     2,633.3 ns |    15.19 ns |    14.21 ns |     2,634.3 ns |  5.79 |    0.19 |
| CheckHashesSauceControlUnrolledHugeLookup | 100   |     1,657.4 ns |    10.04 ns |     9.39 ns |     1,657.6 ns |  3.65 |    0.12 |
| CheckHashesSseKozidHugeLookup             | 100   |     1,578.1 ns |     6.27 ns |     5.87 ns |     1,577.0 ns |  3.47 |    0.11 |
| CheckHashesSauceControlSse                | 100   |       951.0 ns |     2.15 ns |     2.01 ns |       949.9 ns |  2.09 |    0.07 |
| CheckHashesSauceControlFirstAvx           | 100   |       478.8 ns |     4.16 ns |     3.89 ns |       476.4 ns |  1.05 |    0.04 |
| CheckHashesSauceControlSecondAvx          | 100   |       485.0 ns |     4.27 ns |     4.00 ns |       484.1 ns |  1.07 |    0.04 |
| CheckHashesSauceControlThirdAvx           | 100   |       430.7 ns |     8.63 ns |    13.18 ns |       423.4 ns |  0.95 |    0.04 |
| CheckHashesSauceControlFourthAvx          | 100   |       455.1 ns |     9.06 ns |    15.63 ns |       445.7 ns |  1.00 |    0.05 |
|                                           |       |                |             |             |                |       |         |
| **CheckHashesNoLookup**                       | **10000** | **1,158,386.3 ns** | **6,930.84 ns** | **6,483.11 ns** | **1,161,565.6 ns** | **25.80** |    **0.19** |
| CheckHashesOriginalWithLookup             | 10000 |   419,903.8 ns | 2,338.34 ns | 2,187.29 ns |   419,998.0 ns |  9.35 |    0.07 |
| CheckHashesWithSpanTable                  | 10000 |   412,659.3 ns | 7,840.62 ns | 9,333.71 ns |   410,289.2 ns |  9.19 |    0.21 |
| CheckHashesKozi                           | 10000 |   406,640.5 ns | 1,327.42 ns | 1,241.67 ns |   406,681.3 ns |  9.06 |    0.05 |
| CheckHashesTechPizza                      | 10000 |   343,822.3 ns | 1,828.06 ns | 1,709.96 ns |   344,356.1 ns |  7.66 |    0.05 |
| CheckHashesSauceControl                   | 10000 |   359,136.2 ns | 1,496.37 ns | 1,399.70 ns |   359,784.7 ns |  8.00 |    0.05 |
| CheckHashesSauceControlUnrolledKozi       | 10000 |   268,488.6 ns | 1,812.79 ns | 1,695.68 ns |   269,337.1 ns |  5.98 |    0.05 |
| CheckHashesHugeLookupTable                | 10000 |   194,299.3 ns |   784.24 ns |   733.58 ns |   194,510.6 ns |  4.33 |    0.03 |
| CheckHashesSauceControlUnrolled           | 10000 |   263,660.5 ns | 2,122.74 ns | 1,985.62 ns |   264,594.8 ns |  5.87 |    0.05 |
| CheckHashesSauceControlUnrolledHugeLookup | 10000 |   167,534.1 ns |   990.75 ns |   926.75 ns |   167,735.2 ns |  3.73 |    0.03 |
| CheckHashesSseKozidHugeLookup             | 10000 |   158,525.7 ns |   931.46 ns |   871.29 ns |   158,879.7 ns |  3.53 |    0.03 |
| CheckHashesSauceControlSse                | 10000 |    95,850.0 ns |   393.23 ns |   367.82 ns |    95,929.5 ns |  2.13 |    0.01 |
| CheckHashesSauceControlFirstAvx           | 10000 |    48,345.9 ns |   166.72 ns |   155.95 ns |    48,391.5 ns |  1.08 |    0.01 |
| CheckHashesSauceControlSecondAvx          | 10000 |    48,908.0 ns |   163.58 ns |   153.02 ns |    48,923.9 ns |  1.09 |    0.01 |
| CheckHashesSauceControlThirdAvx           | 10000 |    43,265.5 ns |   268.81 ns |   251.45 ns |    43,312.7 ns |  0.96 |    0.01 |
| CheckHashesSauceControlFourthAvx          | 10000 |    44,904.5 ns |   242.75 ns |   227.07 ns |    44,968.2 ns |  1.00 |    0.01 |
