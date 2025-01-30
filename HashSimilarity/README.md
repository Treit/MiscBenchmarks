## Similarity matching



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27783.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-ZBEUFQ : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                                    | Count | Mean           | Error        | StdDev        | Median         | Ratio | RatioSD |
|------------------------------------------ |------ |---------------:|-------------:|--------------:|---------------:|------:|--------:|
| **CheckHashesNoLookup**                       | **100**   |    **12,659.9 ns** |    **246.29 ns** |     **320.24 ns** |    **12,553.5 ns** | **19.63** |    **2.06** |
| CheckHashesOriginalWithLookup             | 100   |     9,208.2 ns |    181.47 ns |     366.58 ns |     9,034.6 ns | 14.91 |    1.29 |
| CheckHashesWithSpanTable                  | 100   |    10,889.5 ns |    217.83 ns |     298.16 ns |    10,764.3 ns | 16.78 |    1.79 |
| CheckHashesKozi                           | 100   |     5,705.0 ns |    424.32 ns |   1,251.11 ns |     5,170.2 ns |  9.27 |    1.94 |
| CheckHashesTechPizza                      | 100   |     4,318.5 ns |    312.95 ns |     922.75 ns |     3,898.8 ns |  7.07 |    1.71 |
| CheckHashesSauceControl                   | 100   |     4,140.6 ns |     92.91 ns |     273.95 ns |     4,061.0 ns |  6.76 |    0.75 |
| CheckHashesSauceControlUnrolledKozi       | 100   |     2,846.7 ns |     56.57 ns |     160.49 ns |     2,798.4 ns |  4.65 |    0.49 |
| CheckHashesHugeLookupTable                | 100   |     4,402.3 ns |    350.84 ns |   1,034.45 ns |     4,573.8 ns |  7.20 |    1.82 |
| CheckHashesSauceControlUnrolled           | 100   |     5,361.3 ns |     65.96 ns |      61.70 ns |     5,343.7 ns |  8.19 |    0.90 |
| CheckHashesSauceControlUnrolledHugeLookup | 100   |     3,207.6 ns |     41.23 ns |      38.56 ns |     3,203.5 ns |  4.90 |    0.53 |
| CheckHashesSseKozidHugeLookup             | 100   |     3,033.7 ns |     59.71 ns |      81.73 ns |     3,055.7 ns |  4.67 |    0.46 |
| CheckHashesSauceControlSse                | 100   |     1,718.7 ns |     24.71 ns |      23.12 ns |     1,725.6 ns |  2.62 |    0.27 |
| CheckHashesSauceControlFirstAvx           | 100   |       671.1 ns |     29.85 ns |      88.01 ns |       637.9 ns |  1.10 |    0.17 |
| CheckHashesSauceControlSecondAvx          | 100   |       611.6 ns |     24.91 ns |      73.44 ns |       593.1 ns |  1.00 |    0.13 |
| CheckHashesSauceControlThirdAvx           | 100   |       625.6 ns |     16.85 ns |      49.69 ns |       605.6 ns |  1.02 |    0.12 |
| CheckHashesSauceControlFourthAvx          | 100   |       616.8 ns |     18.68 ns |      55.09 ns |       597.0 ns |  1.00 |    0.00 |
|                                           |       |                |              |               |                |       |         |
| **CheckHashesNoLookup**                       | **10000** | **1,443,754.7 ns** | **65,550.54 ns** | **193,277.25 ns** | **1,356,822.5 ns** | **22.56** |    **3.53** |
| CheckHashesOriginalWithLookup             | 10000 |   945,034.3 ns | 18,825.31 ns |  46,531.50 ns |   936,766.0 ns | 14.76 |    1.18 |
| CheckHashesWithSpanTable                  | 10000 |   775,333.1 ns | 15,068.64 ns |  15,474.38 ns |   775,331.0 ns | 12.21 |    0.49 |
| CheckHashesKozi                           | 10000 |   440,414.5 ns |  8,769.51 ns |  21,511.76 ns |   435,897.6 ns |  6.87 |    0.56 |
| CheckHashesTechPizza                      | 10000 |   387,668.2 ns |  7,740.46 ns |  22,701.44 ns |   381,091.7 ns |  6.05 |    0.51 |
| CheckHashesSauceControl                   | 10000 |   402,913.8 ns | 11,166.12 ns |  32,923.55 ns |   393,039.4 ns |  6.29 |    0.64 |
| CheckHashesSauceControlUnrolledKozi       | 10000 |   282,326.1 ns |  5,600.32 ns |  16,424.78 ns |   276,176.6 ns |  4.41 |    0.36 |
| CheckHashesHugeLookupTable                | 10000 |   315,673.7 ns |  6,241.41 ns |  13,700.04 ns |   311,256.2 ns |  5.00 |    0.33 |
| CheckHashesSauceControlUnrolled           | 10000 |   304,802.1 ns |  8,766.50 ns |  25,848.23 ns |   295,932.1 ns |  4.75 |    0.44 |
| CheckHashesSauceControlUnrolledHugeLookup | 10000 |   176,454.3 ns |  2,938.78 ns |   2,748.94 ns |   176,238.6 ns |  2.78 |    0.13 |
| CheckHashesSseKozidHugeLookup             | 10000 |   186,392.5 ns |  4,430.09 ns |  13,062.23 ns |   181,788.8 ns |  2.91 |    0.29 |
| CheckHashesSauceControlSse                | 10000 |   109,301.1 ns |  2,173.97 ns |   5,038.51 ns |   108,411.6 ns |  1.72 |    0.11 |
| CheckHashesSauceControlFirstAvx           | 10000 |    64,044.8 ns |  1,969.09 ns |   5,805.91 ns |    62,657.7 ns |  1.00 |    0.11 |
| CheckHashesSauceControlSecondAvx          | 10000 |    59,542.4 ns |  1,139.47 ns |   1,356.45 ns |    59,152.9 ns |  0.94 |    0.05 |
| CheckHashesSauceControlThirdAvx           | 10000 |    61,511.2 ns |    892.83 ns |     835.15 ns |    61,519.6 ns |  0.97 |    0.04 |
| CheckHashesSauceControlFourthAvx          | 10000 |    64,316.5 ns |  1,383.22 ns |   4,078.45 ns |    63,039.9 ns |  1.00 |    0.00 |
