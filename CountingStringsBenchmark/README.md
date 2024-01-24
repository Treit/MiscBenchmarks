## Counting strings


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                         Method |   Count |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD |
|----------------------------------------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
|              **ForLoopCountUsingLengthEqualsZero** |      **10** |         **7.851 ns** |      **0.0644 ns** |      **0.0603 ns** |         **7.843 ns** |  **0.85** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |      10 |         9.942 ns |      0.1823 ns |      0.1423 ns |        10.015 ns |  1.08 |    0.02 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |      10 |        28.951 ns |      0.0343 ns |      0.0286 ns |        28.961 ns |  3.13 |    0.01 |
|            ForLoopCountUsingEmptyStringLiteral |      10 |         9.241 ns |      0.0281 ns |      0.0263 ns |         9.231 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |      10 |         9.178 ns |      0.0130 ns |      0.0116 ns |         9.181 ns |  0.99 |    0.00 |
|          ForEachLoopCountUsingLengthEqualsZero |      10 |         9.228 ns |      0.0160 ns |      0.0141 ns |         9.230 ns |  1.00 |    0.00 |
|        ForEachLoopCountUsingEmptyStringLiteral |      10 |         9.254 ns |      0.0448 ns |      0.0397 ns |         9.252 ns |  1.00 |    0.00 |
|            ForEachLoopCountUsingStringDotEmpty |      10 |         9.267 ns |      0.0605 ns |      0.0537 ns |         9.258 ns |  1.00 |    0.01 |
|                 ForLoopCountUsingIsNullOrEmpty |      10 |         9.071 ns |      0.0477 ns |      0.0423 ns |         9.057 ns |  0.98 |    0.01 |
|          CountUsingLinqWhereEmptyStringLiteral |      10 |        35.809 ns |      0.1946 ns |      0.1820 ns |        35.842 ns |  3.88 |    0.02 |
|            CountUsingLinqWhereLengthEqualsZero |      10 |        36.353 ns |      0.2076 ns |      0.1942 ns |        36.311 ns |  3.93 |    0.02 |
|                                                |         |                  |                |                |                  |       |         |
|              **ForLoopCountUsingLengthEqualsZero** |     **100** |        **79.478 ns** |      **1.6031 ns** |      **2.2473 ns** |        **78.707 ns** |  **0.90** |    **0.04** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |     100 |       105.773 ns |      2.1095 ns |      2.9572 ns |       105.610 ns |  1.19 |    0.05 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |     100 |       288.837 ns |      0.3133 ns |      0.2446 ns |       288.837 ns |  3.22 |    0.09 |
|            ForLoopCountUsingEmptyStringLiteral |     100 |        89.117 ns |      1.8143 ns |      2.2944 ns |        88.050 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |     100 |        88.499 ns |      1.3487 ns |      1.1262 ns |        88.214 ns |  0.99 |    0.03 |
|          ForEachLoopCountUsingLengthEqualsZero |     100 |        86.502 ns |      1.2237 ns |      1.1446 ns |        86.360 ns |  0.97 |    0.03 |
|        ForEachLoopCountUsingEmptyStringLiteral |     100 |        85.611 ns |      1.7375 ns |      2.0683 ns |        85.367 ns |  0.96 |    0.04 |
|            ForEachLoopCountUsingStringDotEmpty |     100 |        85.345 ns |      1.7111 ns |      3.1288 ns |        83.789 ns |  0.96 |    0.04 |
|                 ForLoopCountUsingIsNullOrEmpty |     100 |       106.569 ns |      2.1363 ns |      4.8219 ns |       105.287 ns |  1.21 |    0.06 |
|          CountUsingLinqWhereEmptyStringLiteral |     100 |       181.659 ns |      1.3118 ns |      1.2271 ns |       181.567 ns |  2.04 |    0.05 |
|            CountUsingLinqWhereLengthEqualsZero |     100 |       197.956 ns |      0.6431 ns |      0.6015 ns |       197.708 ns |  2.22 |    0.06 |
|                                                |         |                  |                |                |                  |       |         |
|              **ForLoopCountUsingLengthEqualsZero** |    **1000** |       **795.147 ns** |      **4.6790 ns** |      **4.3768 ns** |       **795.259 ns** |  **0.95** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |    1000 |       974.424 ns |      7.0511 ns |      6.2506 ns |       971.075 ns |  1.17 |    0.01 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |    1000 |     2,477.346 ns |      3.3265 ns |      2.9488 ns |     2,476.763 ns |  2.97 |    0.01 |
|            ForLoopCountUsingEmptyStringLiteral |    1000 |       833.147 ns |      2.7537 ns |      2.4410 ns |       833.437 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |    1000 |       830.837 ns |      6.1445 ns |      5.1309 ns |       829.876 ns |  1.00 |    0.01 |
|          ForEachLoopCountUsingLengthEqualsZero |    1000 |     1,086.975 ns |     16.8031 ns |     15.7177 ns |     1,089.228 ns |  1.30 |    0.02 |
|        ForEachLoopCountUsingEmptyStringLiteral |    1000 |     1,079.211 ns |     32.7452 ns |     96.5499 ns |     1,076.861 ns |  1.17 |    0.09 |
|            ForEachLoopCountUsingStringDotEmpty |    1000 |     1,072.033 ns |     28.1473 ns |     82.1070 ns |     1,082.022 ns |  1.24 |    0.11 |
|                 ForLoopCountUsingIsNullOrEmpty |    1000 |     1,030.842 ns |     20.0800 ns |     23.1242 ns |     1,030.297 ns |  1.25 |    0.03 |
|          CountUsingLinqWhereEmptyStringLiteral |    1000 |     1,638.214 ns |     32.5062 ns |     48.6538 ns |     1,638.823 ns |  1.95 |    0.06 |
|            CountUsingLinqWhereLengthEqualsZero |    1000 |     1,762.709 ns |     34.0672 ns |     43.0841 ns |     1,770.843 ns |  2.12 |    0.05 |
|                                                |         |                  |                |                |                  |       |         |
|              **ForLoopCountUsingLengthEqualsZero** |  **100000** |    **80,263.787 ns** |    **915.5618 ns** |    **856.4171 ns** |    **80,060.364 ns** |  **0.96** |    **0.01** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck |  100000 |    99,172.591 ns |  1,130.6460 ns |  1,002.2882 ns |    98,884.674 ns |  1.18 |    0.01 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch |  100000 |   250,145.274 ns |    947.3474 ns |    839.7988 ns |   249,900.732 ns |  2.99 |    0.01 |
|            ForLoopCountUsingEmptyStringLiteral |  100000 |    83,654.400 ns |    273.6504 ns |    213.6482 ns |    83,620.435 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty |  100000 |    83,023.118 ns |    611.1712 ns |    510.3557 ns |    83,152.502 ns |  0.99 |    0.01 |
|          ForEachLoopCountUsingLengthEqualsZero |  100000 |    78,735.225 ns |    675.8142 ns |    599.0917 ns |    78,545.142 ns |  0.94 |    0.01 |
|        ForEachLoopCountUsingEmptyStringLiteral |  100000 |    81,881.831 ns |    208.7432 ns |    185.0454 ns |    81,858.636 ns |  0.98 |    0.00 |
|            ForEachLoopCountUsingStringDotEmpty |  100000 |    82,069.562 ns |    376.0619 ns |    314.0287 ns |    82,053.552 ns |  0.98 |    0.01 |
|                 ForLoopCountUsingIsNullOrEmpty |  100000 |    96,549.447 ns |  1,681.4887 ns |  1,490.5959 ns |    96,345.093 ns |  1.15 |    0.02 |
|          CountUsingLinqWhereEmptyStringLiteral |  100000 |   153,777.393 ns |  1,371.4308 ns |  1,215.7377 ns |   153,380.078 ns |  1.84 |    0.02 |
|            CountUsingLinqWhereLengthEqualsZero |  100000 |   150,611.897 ns |    776.2059 ns |    648.1671 ns |   150,494.458 ns |  1.80 |    0.01 |
|                                                |         |                  |                |                |                  |       |         |
|              **ForLoopCountUsingLengthEqualsZero** | **1000000** | **1,679,634.102 ns** | **27,418.5616 ns** | **25,647.3395 ns** | **1,674,949.414 ns** |  **0.97** |    **0.02** |
| ForLoopCountUsingLengthEqualsZeroWithNullCheck | 1000000 | 1,747,750.605 ns | 28,044.2578 ns | 26,232.6161 ns | 1,743,471.582 ns |  1.00 |    0.02 |
|  ForLoopCountUsingLengthEqualsZeroWithTryCatch | 1000000 | 2,716,787.249 ns | 22,845.0399 ns | 20,251.5328 ns | 2,708,007.422 ns |  1.56 |    0.02 |
|            ForLoopCountUsingEmptyStringLiteral | 1000000 | 1,741,087.402 ns | 26,194.0088 ns | 23,220.3066 ns | 1,741,923.242 ns |  1.00 |    0.00 |
|                ForLoopCountUsingStringDotEmpty | 1000000 | 1,725,645.306 ns | 14,428.4584 ns | 13,496.3890 ns | 1,727,054.004 ns |  0.99 |    0.02 |
|          ForEachLoopCountUsingLengthEqualsZero | 1000000 | 1,693,758.073 ns | 12,988.9063 ns | 12,149.8310 ns | 1,691,600.977 ns |  0.97 |    0.02 |
|        ForEachLoopCountUsingEmptyStringLiteral | 1000000 | 1,756,840.684 ns | 16,976.7910 ns | 15,880.1008 ns | 1,752,925.684 ns |  1.01 |    0.01 |
|            ForEachLoopCountUsingStringDotEmpty | 1000000 | 1,753,434.362 ns | 16,963.4217 ns | 15,867.5952 ns | 1,751,710.156 ns |  1.01 |    0.02 |
|                 ForLoopCountUsingIsNullOrEmpty | 1000000 | 1,706,080.957 ns | 15,891.9670 ns | 14,087.8148 ns | 1,711,966.797 ns |  0.98 |    0.02 |
|          CountUsingLinqWhereEmptyStringLiteral | 1000000 | 2,111,925.000 ns | 24,662.3562 ns | 20,594.1844 ns | 2,110,482.812 ns |  1.21 |    0.02 |
|            CountUsingLinqWhereLengthEqualsZero | 1000000 | 2,114,545.647 ns | 17,426.1838 ns | 15,447.8580 ns | 2,117,649.219 ns |  1.21 |    0.02 |
