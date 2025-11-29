## Similarity matching






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                    | Job       | Runtime   | Count | Mean           | Error       | StdDev      | Median         | Ratio | RatioSD |
|------------------------------------------ |---------- |---------- |------ |---------------:|------------:|------------:|---------------:|------:|--------:|
| **CheckHashesNoLookup**                       | **.NET 10.0** | **.NET 10.0** | **100**   |    **11,640.0 ns** |    **49.63 ns** |    **46.43 ns** |    **11,632.7 ns** | **25.34** |    **0.96** |
| CheckHashesOriginalWithLookup             | .NET 10.0 | .NET 10.0 | 100   |     4,129.8 ns |    52.40 ns |    49.02 ns |     4,130.7 ns |  8.99 |    0.35 |
| CheckHashesWithSpanTable                  | .NET 10.0 | .NET 10.0 | 100   |     4,722.7 ns |    91.60 ns |    94.07 ns |     4,740.8 ns | 10.28 |    0.43 |
| CheckHashesKozi                           | .NET 10.0 | .NET 10.0 | 100   |     4,105.9 ns |    26.78 ns |    25.05 ns |     4,117.5 ns |  8.94 |    0.34 |
| CheckHashesTechPizza                      | .NET 10.0 | .NET 10.0 | 100   |     3,451.1 ns |    15.29 ns |    14.30 ns |     3,449.6 ns |  7.51 |    0.28 |
| CheckHashesSauceControl                   | .NET 10.0 | .NET 10.0 | 100   |     3,653.5 ns |    11.38 ns |    10.65 ns |     3,654.6 ns |  7.95 |    0.30 |
| CheckHashesSauceControlUnrolledKozi       | .NET 10.0 | .NET 10.0 | 100   |     2,689.3 ns |    15.30 ns |    14.31 ns |     2,690.4 ns |  5.86 |    0.22 |
| CheckHashesHugeLookupTable                | .NET 10.0 | .NET 10.0 | 100   |     2,205.0 ns |    30.76 ns |    28.78 ns |     2,208.6 ns |  4.80 |    0.19 |
| CheckHashesSauceControlUnrolled           | .NET 10.0 | .NET 10.0 | 100   |     2,646.5 ns |    18.39 ns |    17.20 ns |     2,646.4 ns |  5.76 |    0.22 |
| CheckHashesSauceControlUnrolledHugeLookup | .NET 10.0 | .NET 10.0 | 100   |     1,665.7 ns |    14.11 ns |    13.20 ns |     1,664.2 ns |  3.63 |    0.14 |
| CheckHashesSseKozidHugeLookup             | .NET 10.0 | .NET 10.0 | 100   |     1,585.5 ns |    10.45 ns |     9.77 ns |     1,586.4 ns |  3.45 |    0.13 |
| CheckHashesSauceControlSse                | .NET 10.0 | .NET 10.0 | 100   |       929.4 ns |     2.63 ns |     2.46 ns |       928.6 ns |  2.02 |    0.08 |
| CheckHashesSauceControlFirstAvx           | .NET 10.0 | .NET 10.0 | 100   |       481.5 ns |     4.49 ns |     4.20 ns |       483.9 ns |  1.05 |    0.04 |
| CheckHashesSauceControlSecondAvx          | .NET 10.0 | .NET 10.0 | 100   |       487.4 ns |     4.55 ns |     4.25 ns |       488.5 ns |  1.06 |    0.04 |
| CheckHashesSauceControlThirdAvx           | .NET 10.0 | .NET 10.0 | 100   |       464.4 ns |    11.26 ns |    33.19 ns |       485.4 ns |  1.01 |    0.08 |
| CheckHashesSauceControlFourthAvx          | .NET 10.0 | .NET 10.0 | 100   |       460.0 ns |     9.11 ns |    18.61 ns |       450.4 ns |  1.00 |    0.05 |
|                                           |           |           |       |                |             |             |                |       |         |
| CheckHashesNoLookup                       | .NET 9.0  | .NET 9.0  | 100   |    11,606.7 ns |    67.82 ns |    63.44 ns |    11,620.7 ns | 25.23 |    0.86 |
| CheckHashesOriginalWithLookup             | .NET 9.0  | .NET 9.0  | 100   |     4,111.8 ns |    35.50 ns |    33.21 ns |     4,127.4 ns |  8.94 |    0.31 |
| CheckHashesWithSpanTable                  | .NET 9.0  | .NET 9.0  | 100   |     4,623.3 ns |    89.25 ns |   125.11 ns |     4,650.7 ns | 10.05 |    0.43 |
| CheckHashesKozi                           | .NET 9.0  | .NET 9.0  | 100   |     4,122.7 ns |    31.40 ns |    29.37 ns |     4,127.4 ns |  8.96 |    0.31 |
| CheckHashesTechPizza                      | .NET 9.0  | .NET 9.0  | 100   |     3,373.9 ns |    18.84 ns |    17.63 ns |     3,375.3 ns |  7.34 |    0.25 |
| CheckHashesSauceControl                   | .NET 9.0  | .NET 9.0  | 100   |     3,549.9 ns |     9.10 ns |     8.52 ns |     3,550.6 ns |  7.72 |    0.26 |
| CheckHashesSauceControlUnrolledKozi       | .NET 9.0  | .NET 9.0  | 100   |     2,690.7 ns |    22.85 ns |    21.37 ns |     2,687.5 ns |  5.85 |    0.20 |
| CheckHashesHugeLookupTable                | .NET 9.0  | .NET 9.0  | 100   |     2,224.4 ns |    26.55 ns |    24.84 ns |     2,231.3 ns |  4.84 |    0.17 |
| CheckHashesSauceControlUnrolled           | .NET 9.0  | .NET 9.0  | 100   |     2,677.9 ns |    30.23 ns |    28.28 ns |     2,678.1 ns |  5.82 |    0.21 |
| CheckHashesSauceControlUnrolledHugeLookup | .NET 9.0  | .NET 9.0  | 100   |     1,666.3 ns |    13.65 ns |    12.77 ns |     1,666.7 ns |  3.62 |    0.13 |
| CheckHashesSseKozidHugeLookup             | .NET 9.0  | .NET 9.0  | 100   |     1,587.1 ns |    24.83 ns |    23.23 ns |     1,583.4 ns |  3.45 |    0.13 |
| CheckHashesSauceControlSse                | .NET 9.0  | .NET 9.0  | 100   |       954.9 ns |     3.61 ns |     3.38 ns |       953.6 ns |  2.08 |    0.07 |
| CheckHashesSauceControlFirstAvx           | .NET 9.0  | .NET 9.0  | 100   |       480.3 ns |     3.43 ns |     3.21 ns |       480.0 ns |  1.04 |    0.04 |
| CheckHashesSauceControlSecondAvx          | .NET 9.0  | .NET 9.0  | 100   |       487.3 ns |     5.20 ns |     4.87 ns |       484.3 ns |  1.06 |    0.04 |
| CheckHashesSauceControlThirdAvx           | .NET 9.0  | .NET 9.0  | 100   |       447.5 ns |     8.77 ns |     9.75 ns |       452.3 ns |  0.97 |    0.04 |
| CheckHashesSauceControlFourthAvx          | .NET 9.0  | .NET 9.0  | 100   |       460.5 ns |     9.20 ns |    16.35 ns |       452.5 ns |  1.00 |    0.05 |
|                                           |           |           |       |                |             |             |                |       |         |
| **CheckHashesNoLookup**                       | **.NET 10.0** | **.NET 10.0** | **10000** | **1,163,487.0 ns** | **7,026.49 ns** | **6,572.58 ns** | **1,167,892.6 ns** | **25.89** |    **0.23** |
| CheckHashesOriginalWithLookup             | .NET 10.0 | .NET 10.0 | 10000 |   422,599.1 ns | 2,435.81 ns | 2,278.46 ns |   422,540.0 ns |  9.40 |    0.08 |
| CheckHashesWithSpanTable                  | .NET 10.0 | .NET 10.0 | 10000 |   421,512.9 ns | 3,426.38 ns | 3,205.03 ns |   421,301.1 ns |  9.38 |    0.09 |
| CheckHashesKozi                           | .NET 10.0 | .NET 10.0 | 10000 |   419,076.7 ns | 3,505.39 ns | 3,278.94 ns |   418,318.6 ns |  9.32 |    0.10 |
| CheckHashesTechPizza                      | .NET 10.0 | .NET 10.0 | 10000 |   418,997.8 ns | 2,343.18 ns | 2,191.81 ns |   419,371.0 ns |  9.32 |    0.08 |
| CheckHashesSauceControl                   | .NET 10.0 | .NET 10.0 | 10000 |   418,476.1 ns | 1,848.81 ns | 1,729.37 ns |   418,789.5 ns |  9.31 |    0.07 |
| CheckHashesSauceControlUnrolledKozi       | .NET 10.0 | .NET 10.0 | 10000 |   270,136.6 ns | 2,737.80 ns | 2,560.94 ns |   270,533.1 ns |  6.01 |    0.07 |
| CheckHashesHugeLookupTable                | .NET 10.0 | .NET 10.0 | 10000 |   195,203.3 ns | 1,684.59 ns | 1,575.77 ns |   195,028.7 ns |  4.34 |    0.05 |
| CheckHashesSauceControlUnrolled           | .NET 10.0 | .NET 10.0 | 10000 |   273,383.5 ns | 2,343.15 ns | 2,191.78 ns |   274,312.6 ns |  6.08 |    0.06 |
| CheckHashesSauceControlUnrolledHugeLookup | .NET 10.0 | .NET 10.0 | 10000 |   167,767.6 ns | 1,255.32 ns | 1,174.23 ns |   167,898.6 ns |  3.73 |    0.04 |
| CheckHashesSseKozidHugeLookup             | .NET 10.0 | .NET 10.0 | 10000 |   159,899.7 ns |   885.10 ns |   827.92 ns |   160,222.6 ns |  3.56 |    0.03 |
| CheckHashesSauceControlSse                | .NET 10.0 | .NET 10.0 | 10000 |    93,534.2 ns |   378.06 ns |   353.64 ns |    93,567.7 ns |  2.08 |    0.02 |
| CheckHashesSauceControlFirstAvx           | .NET 10.0 | .NET 10.0 | 10000 |    46,355.8 ns |   267.73 ns |   250.44 ns |    46,397.0 ns |  1.03 |    0.01 |
| CheckHashesSauceControlSecondAvx          | .NET 10.0 | .NET 10.0 | 10000 |    47,238.3 ns |   398.71 ns |   372.95 ns |    47,218.1 ns |  1.05 |    0.01 |
| CheckHashesSauceControlThirdAvx           | .NET 10.0 | .NET 10.0 | 10000 |    43,366.1 ns |   308.61 ns |   288.67 ns |    43,429.6 ns |  0.96 |    0.01 |
| CheckHashesSauceControlFourthAvx          | .NET 10.0 | .NET 10.0 | 10000 |    44,944.4 ns |   345.93 ns |   323.58 ns |    44,936.0 ns |  1.00 |    0.01 |
|                                           |           |           |       |                |             |             |                |       |         |
| CheckHashesNoLookup                       | .NET 9.0  | .NET 9.0  | 10000 | 1,163,590.6 ns | 7,220.19 ns | 6,753.77 ns | 1,166,963.9 ns | 25.91 |    0.22 |
| CheckHashesOriginalWithLookup             | .NET 9.0  | .NET 9.0  | 10000 |   410,742.9 ns | 1,519.50 ns | 1,421.34 ns |   411,065.9 ns |  9.15 |    0.07 |
| CheckHashesWithSpanTable                  | .NET 9.0  | .NET 9.0  | 10000 |   419,961.4 ns | 4,297.05 ns | 4,019.46 ns |   419,456.6 ns |  9.35 |    0.11 |
| CheckHashesKozi                           | .NET 9.0  | .NET 9.0  | 10000 |   420,012.9 ns | 4,049.26 ns | 3,787.68 ns |   419,052.5 ns |  9.35 |    0.10 |
| CheckHashesTechPizza                      | .NET 9.0  | .NET 9.0  | 10000 |   418,367.7 ns | 2,534.60 ns | 2,370.86 ns |   418,477.6 ns |  9.32 |    0.08 |
| CheckHashesSauceControl                   | .NET 9.0  | .NET 9.0  | 10000 |   420,004.0 ns | 3,652.37 ns | 3,416.43 ns |   419,600.6 ns |  9.35 |    0.10 |
| CheckHashesSauceControlUnrolledKozi       | .NET 9.0  | .NET 9.0  | 10000 |   269,583.9 ns | 3,082.18 ns | 2,883.07 ns |   270,194.8 ns |  6.00 |    0.07 |
| CheckHashesHugeLookupTable                | .NET 9.0  | .NET 9.0  | 10000 |   220,267.3 ns | 4,363.66 ns | 9,204.44 ns |   218,607.1 ns |  4.91 |    0.21 |
| CheckHashesSauceControlUnrolled           | .NET 9.0  | .NET 9.0  | 10000 |   273,350.5 ns | 2,683.61 ns | 2,510.25 ns |   274,377.6 ns |  6.09 |    0.07 |
| CheckHashesSauceControlUnrolledHugeLookup | .NET 9.0  | .NET 9.0  | 10000 |   167,668.8 ns | 1,016.11 ns |   950.47 ns |   167,937.9 ns |  3.73 |    0.03 |
| CheckHashesSseKozidHugeLookup             | .NET 9.0  | .NET 9.0  | 10000 |   160,202.0 ns | 1,370.36 ns | 1,281.83 ns |   160,273.7 ns |  3.57 |    0.04 |
| CheckHashesSauceControlSse                | .NET 9.0  | .NET 9.0  | 10000 |    93,727.1 ns |   536.13 ns |   501.49 ns |    93,993.8 ns |  2.09 |    0.02 |
| CheckHashesSauceControlFirstAvx           | .NET 9.0  | .NET 9.0  | 10000 |    46,513.1 ns |   265.19 ns |   248.06 ns |    46,576.1 ns |  1.04 |    0.01 |
| CheckHashesSauceControlSecondAvx          | .NET 9.0  | .NET 9.0  | 10000 |    46,840.3 ns |   249.80 ns |   233.66 ns |    46,888.5 ns |  1.04 |    0.01 |
| CheckHashesSauceControlThirdAvx           | .NET 9.0  | .NET 9.0  | 10000 |    43,033.4 ns |   260.87 ns |   244.02 ns |    43,113.3 ns |  0.96 |    0.01 |
| CheckHashesSauceControlFourthAvx          | .NET 9.0  | .NET 9.0  | 10000 |    44,908.4 ns |   320.69 ns |   299.98 ns |    44,935.9 ns |  1.00 |    0.01 |
