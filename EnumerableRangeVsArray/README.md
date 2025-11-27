# Enumerable.Range vs Explicit Array population.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22449
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                                    Method |   Count |            Mean |            Error |         StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------------------------ |-------- |----------------:|-----------------:|---------------:|------:|--------:|---------:|---------:|---------:|----------:|
|                 PopulateWithExplicitArray |      10 |        10.19 ns |         4.371 ns |       0.240 ns |  1.00 |    0.00 |   0.0148 |        - |        - |      64 B |
|               PopulateWithEnumerableRange |      10 |        33.51 ns |        31.497 ns |       1.726 ns |  3.29 |    0.21 |   0.0241 |        - |        - |     104 B |
|   PopulateAndTakeAverageWithExplicitArray |      10 |        77.88 ns |        27.269 ns |       1.495 ns |  7.65 |    0.25 |   0.0222 |        - |        - |      96 B |
| PopulateAndTakeAverageWithEnumerableRange |      10 |        72.93 ns |        54.152 ns |       2.968 ns |  7.17 |    0.45 |   0.0092 |        - |        - |      40 B |
|       PopulateAndTakeSumWithExplicitArray |      10 |        74.65 ns |       103.103 ns |       5.651 ns |  7.33 |    0.50 |   0.0315 |        - |        - |     136 B |
|     PopulateAndTakeSumWithEnumerableRange |      10 |       140.02 ns |        33.862 ns |       1.856 ns | 13.75 |    0.50 |   0.0203 |        - |        - |      88 B |
|                                           |         |                 |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray |     100 |        73.11 ns |         8.988 ns |       0.493 ns |  1.00 |    0.00 |   0.0982 |        - |        - |     424 B |
|               PopulateWithEnumerableRange |     100 |       104.38 ns |        21.081 ns |       1.156 ns |  1.43 |    0.01 |   0.1075 |        - |        - |     464 B |
|   PopulateAndTakeAverageWithExplicitArray |     100 |       659.78 ns |       294.690 ns |      16.153 ns |  9.03 |    0.28 |   0.1049 |        - |        - |     456 B |
| PopulateAndTakeAverageWithEnumerableRange |     100 |       541.67 ns |       822.861 ns |      45.104 ns |  7.41 |    0.60 |   0.0086 |        - |        - |      40 B |
|       PopulateAndTakeSumWithExplicitArray |     100 |       652.50 ns |       188.012 ns |      10.306 ns |  8.93 |    0.17 |   0.1984 |        - |        - |     856 B |
|     PopulateAndTakeSumWithEnumerableRange |     100 |       740.92 ns |       512.656 ns |      28.100 ns | 10.14 |    0.45 |   0.0200 |        - |        - |      88 B |
|                                           |         |                 |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray |    1000 |       618.09 ns |       584.717 ns |      32.050 ns |  1.00 |    0.00 |   0.9327 |        - |        - |    4024 B |
|               PopulateWithEnumerableRange |    1000 |       745.11 ns |       355.843 ns |      19.505 ns |  1.21 |    0.03 |   0.9413 |        - |        - |    4064 B |
|   PopulateAndTakeAverageWithExplicitArray |    1000 |     5,758.23 ns |       126.860 ns |       6.954 ns |  9.33 |    0.48 |   0.9384 |        - |        - |    4056 B |
| PopulateAndTakeAverageWithEnumerableRange |    1000 |     4,552.54 ns |     1,767.492 ns |      96.882 ns |  7.38 |    0.52 |   0.0076 |        - |        - |      40 B |
|       PopulateAndTakeSumWithExplicitArray |    1000 |     6,632.77 ns |     2,043.274 ns |     111.999 ns | 10.75 |    0.61 |   1.8616 |        - |        - |    8056 B |
|     PopulateAndTakeSumWithEnumerableRange |    1000 |     6,629.08 ns |     3,078.279 ns |     168.731 ns | 10.73 |    0.29 |   0.0153 |        - |        - |      88 B |
|                                           |         |                 |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray |  100000 |   203,189.25 ns |    49,658.201 ns |   2,721.934 ns |  1.00 |    0.00 | 124.7559 | 124.7559 | 124.7559 |  400024 B |
|               PopulateWithEnumerableRange |  100000 |   206,636.74 ns |   191,269.148 ns |  10,484.107 ns |  1.02 |    0.04 | 124.7559 | 124.7559 | 124.7559 |  400064 B |
|   PopulateAndTakeAverageWithExplicitArray |  100000 |   773,426.60 ns |   663,815.020 ns |  36,385.941 ns |  3.81 |    0.16 | 124.0234 | 124.0234 | 124.0234 |  400056 B |
| PopulateAndTakeAverageWithEnumerableRange |  100000 |   452,971.31 ns |   552,192.562 ns |  30,267.538 ns |  2.23 |    0.18 |        - |        - |        - |      40 B |
|       PopulateAndTakeSumWithExplicitArray |  100000 |   942,324.69 ns |   305,441.312 ns |  16,742.269 ns |  4.64 |    0.09 | 249.0234 | 249.0234 | 249.0234 |  800056 B |
|     PopulateAndTakeSumWithEnumerableRange |  100000 |   667,046.61 ns | 1,150,713.916 ns |  63,074.513 ns |  3.28 |    0.30 |        - |        - |        - |      88 B |
|                                           |         |                 |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray | 1000000 | 1,919,133.53 ns |   873,554.939 ns |  47,882.494 ns |  1.00 |    0.00 | 996.0938 | 996.0938 | 996.0938 | 4000024 B |
|               PopulateWithEnumerableRange | 1000000 | 2,189,561.46 ns | 1,684,442.699 ns |  92,329.988 ns |  1.14 |    0.02 | 996.0938 | 996.0938 | 996.0938 | 4000064 B |
|   PopulateAndTakeAverageWithExplicitArray | 1000000 | 6,856,286.33 ns | 1,846,080.919 ns | 101,189.924 ns |  3.57 |    0.07 | 992.1875 | 992.1875 | 992.1875 | 4000056 B |
| PopulateAndTakeAverageWithEnumerableRange | 1000000 | 4,667,765.36 ns | 1,671,784.888 ns |  91,636.171 ns |  2.43 |    0.07 |        - |        - |        - |      40 B |
|       PopulateAndTakeSumWithExplicitArray | 1000000 | 6,883,645.31 ns | 1,449,744.781 ns |  79,465.403 ns |  3.59 |    0.13 | 500.0000 | 500.0000 | 500.0000 | 8000044 B |
|     PopulateAndTakeSumWithEnumerableRange | 1000000 | 6,645,228.39 ns | 2,905,598.496 ns | 159,265.658 ns |  3.46 |    0.09 |        - |        - |        - |      88 B |






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Job       | Runtime   | Count   | Mean             | Error          | StdDev         | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------------------------------ |---------- |---------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **PopulateWithExplicitArray**                 | **.NET 10.0** | **.NET 10.0** | **10**      |         **6.774 ns** |      **0.1508 ns** |      **0.1481 ns** |  **1.00** |    **0.03** |   **0.0038** |        **-** |        **-** |      **64 B** |        **1.00** |
| PopulateWithEnumerableRange               | .NET 10.0 | .NET 10.0 | 10      |        10.035 ns |      0.1371 ns |      0.1216 ns |  1.48 |    0.04 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 10.0 | .NET 10.0 | 10      |        24.049 ns |      0.1915 ns |      0.1791 ns |  3.55 |    0.08 |   0.0038 |        - |        - |      64 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 10.0 | .NET 10.0 | 10      |        18.308 ns |      0.2688 ns |      0.2383 ns |  2.70 |    0.07 |   0.0024 |        - |        - |      40 B |        0.62 |
| PopulateAndTakeSumWithExplicitArray       | .NET 10.0 | .NET 10.0 | 10      |        13.644 ns |      0.1639 ns |      0.1533 ns |  2.01 |    0.05 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 10.0 | .NET 10.0 | 10      |        33.712 ns |      0.5509 ns |      0.5153 ns |  4.98 |    0.13 |   0.0052 |        - |        - |      88 B |        1.38 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| PopulateWithExplicitArray                 | .NET 9.0  | .NET 9.0  | 10      |         6.739 ns |      0.1100 ns |      0.0975 ns |  1.00 |    0.02 |   0.0038 |        - |        - |      64 B |        1.00 |
| PopulateWithEnumerableRange               | .NET 9.0  | .NET 9.0  | 10      |         9.893 ns |      0.1086 ns |      0.0907 ns |  1.47 |    0.02 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 9.0  | .NET 9.0  | 10      |        23.937 ns |      0.1419 ns |      0.1258 ns |  3.55 |    0.05 |   0.0038 |        - |        - |      64 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 9.0  | .NET 9.0  | 10      |        18.284 ns |      0.3492 ns |      0.3266 ns |  2.71 |    0.06 |   0.0024 |        - |        - |      40 B |        0.62 |
| PopulateAndTakeSumWithExplicitArray       | .NET 9.0  | .NET 9.0  | 10      |        13.401 ns |      0.1834 ns |      0.1626 ns |  1.99 |    0.04 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 9.0  | .NET 9.0  | 10      |        34.084 ns |      0.5577 ns |      0.4944 ns |  5.06 |    0.10 |   0.0052 |        - |        - |      88 B |        1.38 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **.NET 10.0** | **.NET 10.0** | **100**     |        **51.943 ns** |      **1.0204 ns** |      **1.0021 ns** |  **1.00** |    **0.03** |   **0.0253** |        **-** |        **-** |     **424 B** |        **1.00** |
| PopulateWithEnumerableRange               | .NET 10.0 | .NET 10.0 | 100     |        24.565 ns |      0.5054 ns |      0.4964 ns |  0.47 |    0.01 |   0.0277 |        - |        - |     464 B |        1.09 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 10.0 | .NET 10.0 | 100     |        65.701 ns |      1.0930 ns |      1.0224 ns |  1.27 |    0.03 |   0.0253 |        - |        - |     424 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 10.0 | .NET 10.0 | 100     |       104.392 ns |      2.1026 ns |      3.8974 ns |  2.01 |    0.08 |   0.0024 |        - |        - |      40 B |        0.09 |
| PopulateAndTakeSumWithExplicitArray       | .NET 10.0 | .NET 10.0 | 100     |        71.307 ns |      1.2814 ns |      1.1986 ns |  1.37 |    0.03 |   0.0492 |        - |        - |     824 B |        1.94 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 10.0 | .NET 10.0 | 100     |       138.201 ns |      2.7625 ns |      2.7132 ns |  2.66 |    0.07 |   0.0052 |        - |        - |      88 B |        0.21 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| PopulateWithExplicitArray                 | .NET 9.0  | .NET 9.0  | 100     |        52.846 ns |      0.8550 ns |      0.7580 ns |  1.00 |    0.02 |   0.0253 |        - |        - |     424 B |        1.00 |
| PopulateWithEnumerableRange               | .NET 9.0  | .NET 9.0  | 100     |        24.714 ns |      0.5160 ns |      0.6888 ns |  0.47 |    0.01 |   0.0277 |        - |        - |     464 B |        1.09 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 9.0  | .NET 9.0  | 100     |        64.454 ns |      0.7166 ns |      0.6353 ns |  1.22 |    0.02 |   0.0253 |        - |        - |     424 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 9.0  | .NET 9.0  | 100     |       104.362 ns |      2.1159 ns |      4.4167 ns |  1.98 |    0.09 |   0.0024 |        - |        - |      40 B |        0.09 |
| PopulateAndTakeSumWithExplicitArray       | .NET 9.0  | .NET 9.0  | 100     |        71.690 ns |      1.2726 ns |      1.1904 ns |  1.36 |    0.03 |   0.0492 |        - |        - |     824 B |        1.94 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 9.0  | .NET 9.0  | 100     |       134.314 ns |      2.6621 ns |      3.4614 ns |  2.54 |    0.07 |   0.0052 |        - |        - |      88 B |        0.21 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **.NET 10.0** | **.NET 10.0** | **1000**    |       **451.397 ns** |      **7.6521 ns** |      **6.7834 ns** |  **1.00** |    **0.02** |   **0.2403** |        **-** |        **-** |    **4024 B** |       **1.000** |
| PopulateWithEnumerableRange               | .NET 10.0 | .NET 10.0 | 1000    |       169.837 ns |      3.3699 ns |      6.2464 ns |  0.38 |    0.01 |   0.2427 |        - |        - |    4064 B |       1.010 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 10.0 | .NET 10.0 | 1000    |       602.986 ns |     10.7542 ns |     10.0595 ns |  1.34 |    0.03 |   0.2403 |        - |        - |    4024 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 10.0 | .NET 10.0 | 1000    |       956.464 ns |     10.3627 ns |      9.6933 ns |  2.12 |    0.04 |   0.0019 |        - |        - |      40 B |       0.010 |
| PopulateAndTakeSumWithExplicitArray       | .NET 10.0 | .NET 10.0 | 1000    |       780.705 ns |     15.3689 ns |     21.5451 ns |  1.73 |    0.05 |   0.4787 |        - |        - |    8024 B |       1.994 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 10.0 | .NET 10.0 | 1000    |     1,110.984 ns |     10.3978 ns |      9.7261 ns |  2.46 |    0.04 |   0.0038 |        - |        - |      88 B |       0.022 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| PopulateWithExplicitArray                 | .NET 9.0  | .NET 9.0  | 1000    |       453.560 ns |      8.9091 ns |      9.5326 ns |  1.00 |    0.03 |   0.2403 |        - |        - |    4024 B |       1.000 |
| PopulateWithEnumerableRange               | .NET 9.0  | .NET 9.0  | 1000    |       171.243 ns |      3.4576 ns |      5.3831 ns |  0.38 |    0.01 |   0.2427 |        - |        - |    4064 B |       1.010 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 9.0  | .NET 9.0  | 1000    |       589.721 ns |      8.1270 ns |      7.6020 ns |  1.30 |    0.03 |   0.2403 |        - |        - |    4024 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 9.0  | .NET 9.0  | 1000    |       697.101 ns |      6.5100 ns |      6.0894 ns |  1.54 |    0.03 |   0.0019 |        - |        - |      40 B |       0.010 |
| PopulateAndTakeSumWithExplicitArray       | .NET 9.0  | .NET 9.0  | 1000    |       715.586 ns |     11.8050 ns |     11.0424 ns |  1.58 |    0.04 |   0.4787 |        - |        - |    8024 B |       1.994 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 9.0  | .NET 9.0  | 1000    |     1,111.763 ns |     12.7627 ns |     11.3138 ns |  2.45 |    0.06 |   0.0038 |        - |        - |      88 B |       0.022 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **.NET 10.0** | **.NET 10.0** | **100000**  |   **197,238.840 ns** |  **1,320.4096 ns** |  **1,235.1120 ns** |  **1.00** |    **0.01** | **124.7559** | **124.7559** | **124.7559** |  **400066 B** |       **1.000** |
| PopulateWithEnumerableRange               | .NET 10.0 | .NET 10.0 | 100000  |   177,546.477 ns |  1,621.7585 ns |  1,437.6466 ns |  0.90 |    0.01 | 124.7559 | 124.7559 | 124.7559 |  400106 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 10.0 | .NET 10.0 | 100000  |   208,448.844 ns |  1,474.8009 ns |  1,379.5297 ns |  1.06 |    0.01 | 124.7559 | 124.7559 | 124.7559 |  400066 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 10.0 | .NET 10.0 | 100000  |    70,730.868 ns |    611.8082 ns |    510.8875 ns |  0.36 |    0.00 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | .NET 10.0 | .NET 10.0 | 100000  |   406,217.272 ns |  4,748.9251 ns |  4,442.1475 ns |  2.06 |    0.03 | 249.5117 | 249.5117 | 249.5117 |  800108 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 10.0 | .NET 10.0 | 100000  |   125,410.164 ns |  1,074.4386 ns |  1,005.0305 ns |  0.64 |    0.01 |        - |        - |        - |      88 B |       0.000 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| PopulateWithExplicitArray                 | .NET 9.0  | .NET 9.0  | 100000  |   193,081.685 ns |  1,029.3683 ns |    962.8718 ns |  1.00 |    0.01 | 124.7559 | 124.7559 | 124.7559 |  400066 B |       1.000 |
| PopulateWithEnumerableRange               | .NET 9.0  | .NET 9.0  | 100000  |   177,676.551 ns |  1,459.5804 ns |  1,365.2924 ns |  0.92 |    0.01 | 124.7559 | 124.7559 | 124.7559 |  400106 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 9.0  | .NET 9.0  | 100000  |   211,314.134 ns |  2,063.0914 ns |  1,929.8169 ns |  1.09 |    0.01 | 124.7559 | 124.7559 | 124.7559 |  400066 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 9.0  | .NET 9.0  | 100000  |    70,597.775 ns |    877.7434 ns |    685.2843 ns |  0.37 |    0.00 |        - |        - |        - |      42 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | .NET 9.0  | .NET 9.0  | 100000  |   405,526.371 ns |  4,714.9960 ns |  4,179.7212 ns |  2.10 |    0.02 | 249.5117 | 249.5117 | 249.5117 |  800108 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 9.0  | .NET 9.0  | 100000  |   125,533.644 ns |    872.0752 ns |    815.7397 ns |  0.65 |    0.01 |        - |        - |        - |      88 B |       0.000 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **.NET 10.0** | **.NET 10.0** | **1000000** | **1,867,032.435 ns** | **11,351.4367 ns** | **10,618.1409 ns** |  **1.00** |    **0.01** | **998.0469** | **998.0469** | **998.0469** | **4000383 B** |       **1.000** |
| PopulateWithEnumerableRange               | .NET 10.0 | .NET 10.0 | 1000000 | 1,711,520.463 ns |  9,007.2299 ns |  7,521.4449 ns |  0.92 |    0.01 | 998.0469 | 998.0469 | 998.0469 | 4000399 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 10.0 | .NET 10.0 | 1000000 | 2,098,624.938 ns | 41,606.1355 ns | 46,245.1094 ns |  1.12 |    0.02 | 996.0938 | 996.0938 | 996.0938 | 4000359 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 10.0 | .NET 10.0 | 1000000 |   683,532.520 ns |  4,774.9013 ns |  4,232.8256 ns |  0.37 |    0.00 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | .NET 10.0 | .NET 10.0 | 1000000 | 2,038,759.266 ns | 40,337.4479 ns | 43,160.6173 ns |  1.09 |    0.02 | 500.0000 | 500.0000 | 500.0000 | 8000180 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 10.0 | .NET 10.0 | 1000000 | 1,283,680.729 ns | 12,417.8150 ns | 11,615.6319 ns |  0.69 |    0.01 |        - |        - |        - |      88 B |       0.000 |
|                                           |           |           |         |                  |                |                |       |         |          |          |          |           |             |
| PopulateWithExplicitArray                 | .NET 9.0  | .NET 9.0  | 1000000 | 1,881,053.802 ns |  7,201.1605 ns |  6,735.9700 ns |  1.00 |    0.00 | 998.0469 | 998.0469 | 998.0469 | 4000383 B |       1.000 |
| PopulateWithEnumerableRange               | .NET 9.0  | .NET 9.0  | 1000000 | 1,724,519.978 ns |  8,379.3024 ns |  7,428.0333 ns |  0.92 |    0.00 | 998.0469 | 998.0469 | 998.0469 | 4000399 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | .NET 9.0  | .NET 9.0  | 1000000 | 2,051,350.846 ns | 28,260.8845 ns | 26,435.2489 ns |  1.09 |    0.01 | 996.0938 | 996.0938 | 996.0938 | 4000359 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | .NET 9.0  | .NET 9.0  | 1000000 |   681,187.715 ns |  5,296.7908 ns |  4,954.6214 ns |  0.36 |    0.00 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | .NET 9.0  | .NET 9.0  | 1000000 | 1,634,162.513 ns | 25,851.5031 ns | 24,181.5121 ns |  0.87 |    0.01 | 500.0000 | 500.0000 | 500.0000 | 8000180 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | .NET 9.0  | .NET 9.0  | 1000000 | 1,258,579.954 ns | 11,473.6893 ns | 10,732.4961 ns |  0.67 |    0.01 |        - |        - |        - |      88 B |       0.000 |
