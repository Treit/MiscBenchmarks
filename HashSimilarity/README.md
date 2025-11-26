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
| **CheckHashesNoLookup**                       | **100**   |    **11,609.6 ns** |    **63.51 ns** |    **59.41 ns** |    **11,618.9 ns** | **25.38** |    **0.46** |
| CheckHashesOriginalWithLookup             | 100   |     4,114.9 ns |    46.45 ns |    43.45 ns |     4,124.2 ns |  9.00 |    0.18 |
| CheckHashesWithSpanTable                  | 100   |     4,627.4 ns |    90.43 ns |   143.44 ns |     4,674.6 ns | 10.12 |    0.36 |
| CheckHashesKozi                           | 100   |     4,105.1 ns |    35.94 ns |    33.62 ns |     4,116.3 ns |  8.97 |    0.17 |
| CheckHashesTechPizza                      | 100   |     3,444.0 ns |     9.29 ns |     8.69 ns |     3,444.6 ns |  7.53 |    0.13 |
| CheckHashesSauceControl                   | 100   |     3,649.4 ns |     8.61 ns |     8.06 ns |     3,645.3 ns |  7.98 |    0.14 |
| CheckHashesSauceControlUnrolledKozi       | 100   |     2,681.7 ns |    14.31 ns |    13.38 ns |     2,685.9 ns |  5.86 |    0.11 |
| CheckHashesHugeLookupTable                | 100   |     1,949.9 ns |    38.34 ns |    67.15 ns |     1,913.9 ns |  4.26 |    0.16 |
| CheckHashesSauceControlUnrolled           | 100   |     2,630.5 ns |    15.74 ns |    14.73 ns |     2,637.6 ns |  5.75 |    0.11 |
| CheckHashesSauceControlUnrolledHugeLookup | 100   |     1,695.3 ns |    33.15 ns |    47.54 ns |     1,668.3 ns |  3.71 |    0.12 |
| CheckHashesSseKozidHugeLookup             | 100   |     1,583.7 ns |     9.15 ns |     8.56 ns |     1,584.9 ns |  3.46 |    0.06 |
| CheckHashesSauceControlSse                | 100   |       951.4 ns |     8.47 ns |     7.92 ns |       947.6 ns |  2.08 |    0.04 |
| CheckHashesSauceControlFirstAvx           | 100   |       478.5 ns |     3.60 ns |     3.37 ns |       476.3 ns |  1.05 |    0.02 |
| CheckHashesSauceControlSecondAvx          | 100   |       492.9 ns |     9.75 ns |    10.01 ns |       488.5 ns |  1.08 |    0.03 |
| CheckHashesSauceControlThirdAvx           | 100   |       432.5 ns |     8.67 ns |    20.10 ns |       423.5 ns |  0.95 |    0.05 |
| CheckHashesSauceControlFourthAvx          | 100   |       457.5 ns |     8.92 ns |     8.34 ns |       454.1 ns |  1.00 |    0.02 |
|                                           |       |                |             |             |                |       |         |
| **CheckHashesNoLookup**                       | **10000** | **1,158,448.1 ns** | **6,056.43 ns** | **5,665.19 ns** | **1,161,875.2 ns** | **25.70** |    **0.20** |
| CheckHashesOriginalWithLookup             | 10000 |   419,769.4 ns | 2,245.96 ns | 2,100.88 ns |   419,593.5 ns |  9.31 |    0.07 |
| CheckHashesWithSpanTable                  | 10000 |   409,921.4 ns | 1,568.90 ns | 1,467.55 ns |   410,472.1 ns |  9.09 |    0.07 |
| CheckHashesKozi                           | 10000 |   408,611.8 ns | 2,869.17 ns | 2,683.82 ns |   408,063.3 ns |  9.06 |    0.08 |
| CheckHashesTechPizza                      | 10000 |   344,549.7 ns | 2,047.84 ns | 1,915.55 ns |   344,779.3 ns |  7.64 |    0.06 |
| CheckHashesSauceControl                   | 10000 |   360,273.6 ns | 2,423.23 ns | 2,266.69 ns |   360,596.8 ns |  7.99 |    0.07 |
| CheckHashesSauceControlUnrolledKozi       | 10000 |   268,628.1 ns | 2,135.36 ns | 1,997.42 ns |   269,607.9 ns |  5.96 |    0.06 |
| CheckHashesHugeLookupTable                | 10000 |   193,854.3 ns | 1,530.58 ns | 1,431.70 ns |   193,842.3 ns |  4.30 |    0.04 |
| CheckHashesSauceControlUnrolled           | 10000 |   263,727.2 ns | 1,868.81 ns | 1,748.09 ns |   264,872.9 ns |  5.85 |    0.05 |
| CheckHashesSauceControlUnrolledHugeLookup | 10000 |   168,682.1 ns | 1,287.90 ns | 1,204.70 ns |   168,814.8 ns |  3.74 |    0.03 |
| CheckHashesSseKozidHugeLookup             | 10000 |   159,969.1 ns |   976.24 ns |   913.18 ns |   160,346.4 ns |  3.55 |    0.03 |
| CheckHashesSauceControlSse                | 10000 |    96,067.2 ns |   693.75 ns |   648.94 ns |    96,051.3 ns |  2.13 |    0.02 |
| CheckHashesSauceControlFirstAvx           | 10000 |    48,476.6 ns |   142.21 ns |   133.02 ns |    48,501.2 ns |  1.08 |    0.01 |
| CheckHashesSauceControlSecondAvx          | 10000 |    49,027.0 ns |   237.82 ns |   222.46 ns |    49,057.5 ns |  1.09 |    0.01 |
| CheckHashesSauceControlThirdAvx           | 10000 |    43,411.7 ns |   350.84 ns |   328.18 ns |    43,382.4 ns |  0.96 |    0.01 |
| CheckHashesSauceControlFourthAvx          | 10000 |    45,085.1 ns |   313.48 ns |   293.23 ns |    45,094.7 ns |  1.00 |    0.01 |
