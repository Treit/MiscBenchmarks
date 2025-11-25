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
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                    | Count   | Mean             | Error          | StdDev          | Median           | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|------------------------------------------ |-------- |-----------------:|---------------:|----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **PopulateWithExplicitArray**                 | **10**      |         **6.843 ns** |      **0.1501 ns** |       **0.1404 ns** |         **6.805 ns** |  **1.00** |    **0.03** |   **0.0038** |        **-** |        **-** |      **64 B** |        **1.00** |
| PopulateWithEnumerableRange               | 10      |        10.088 ns |      0.0938 ns |       0.0877 ns |        10.101 ns |  1.47 |    0.03 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeAverageWithExplicitArray   | 10      |        24.007 ns |      0.1929 ns |       0.1805 ns |        24.025 ns |  3.51 |    0.07 |   0.0038 |        - |        - |      64 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | 10      |        18.051 ns |      0.2703 ns |       0.2397 ns |        18.082 ns |  2.64 |    0.06 |   0.0024 |        - |        - |      40 B |        0.62 |
| PopulateAndTakeSumWithExplicitArray       | 10      |        13.561 ns |      0.2798 ns |       0.2618 ns |        13.524 ns |  1.98 |    0.05 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeSumWithEnumerableRange     | 10      |        33.012 ns |      0.3634 ns |       0.3399 ns |        33.061 ns |  4.83 |    0.11 |   0.0052 |        - |        - |      88 B |        1.38 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **100**     |        **51.783 ns** |      **0.6605 ns** |       **0.6179 ns** |        **51.957 ns** |  **1.00** |    **0.02** |   **0.0253** |        **-** |        **-** |     **424 B** |        **1.00** |
| PopulateWithEnumerableRange               | 100     |        25.179 ns |      0.5203 ns |       0.5343 ns |        25.333 ns |  0.49 |    0.01 |   0.0277 |        - |        - |     464 B |        1.09 |
| PopulateAndTakeAverageWithExplicitArray   | 100     |        64.903 ns |      1.0735 ns |       1.0042 ns |        64.904 ns |  1.25 |    0.02 |   0.0253 |        - |        - |     424 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | 100     |       101.801 ns |      2.0607 ns |       5.0935 ns |       103.058 ns |  1.97 |    0.10 |   0.0024 |        - |        - |      40 B |        0.09 |
| PopulateAndTakeSumWithExplicitArray       | 100     |        70.460 ns |      0.8762 ns |       0.8196 ns |        70.461 ns |  1.36 |    0.02 |   0.0492 |        - |        - |     824 B |        1.94 |
| PopulateAndTakeSumWithEnumerableRange     | 100     |       129.973 ns |      1.9086 ns |       1.7853 ns |       129.839 ns |  2.51 |    0.04 |   0.0052 |        - |        - |      88 B |        0.21 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **1000**    |       **440.950 ns** |      **4.9444 ns** |       **4.3831 ns** |       **441.700 ns** |  **1.00** |    **0.01** |   **0.2403** |        **-** |        **-** |    **4024 B** |       **1.000** |
| PopulateWithEnumerableRange               | 1000    |       174.615 ns |      3.4713 ns |       4.6341 ns |       175.003 ns |  0.40 |    0.01 |   0.2427 |        - |        - |    4064 B |       1.010 |
| PopulateAndTakeAverageWithExplicitArray   | 1000    |       587.625 ns |      7.1387 ns |       6.6775 ns |       587.853 ns |  1.33 |    0.02 |   0.2403 |        - |        - |    4024 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 1000    |       688.830 ns |      6.2540 ns |       5.8500 ns |       687.219 ns |  1.56 |    0.02 |   0.0019 |        - |        - |      40 B |       0.010 |
| PopulateAndTakeSumWithExplicitArray       | 1000    |       720.035 ns |      7.1030 ns |       6.2966 ns |       720.913 ns |  1.63 |    0.02 |   0.4787 |        - |        - |    8024 B |       1.994 |
| PopulateAndTakeSumWithEnumerableRange     | 1000    |     1,102.879 ns |      8.4876 ns |       7.5241 ns |     1,105.320 ns |  2.50 |    0.03 |   0.0038 |        - |        - |      88 B |       0.022 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **100000**  |   **285,315.840 ns** |  **2,539.3101 ns** |   **2,375.2723 ns** |   **285,387.549 ns** |  **1.00** |    **0.01** | **124.5117** | **124.5117** | **124.5117** |  **400066 B** |       **1.000** |
| PopulateWithEnumerableRange               | 100000  |   268,329.007 ns |  8,614.4013 ns |  25,399.7584 ns |   275,679.883 ns |  0.94 |    0.09 | 124.5117 | 124.5117 | 124.5117 |  400106 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | 100000  |   304,715.345 ns |  2,931.0325 ns |   2,741.6896 ns |   305,075.830 ns |  1.07 |    0.01 | 124.5117 | 124.5117 | 124.5117 |  400066 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 100000  |    70,472.641 ns |    729.4023 ns |     646.5961 ns |    70,354.016 ns |  0.25 |    0.00 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | 100000  |   569,262.307 ns | 11,336.2546 ns |  31,223.3397 ns |   574,360.693 ns |  2.00 |    0.11 | 249.0234 | 249.0234 | 249.0234 |  800108 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | 100000  |   125,347.872 ns |    836.3209 ns |     698.3658 ns |   125,594.556 ns |  0.44 |    0.00 |        - |        - |        - |      88 B |       0.000 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **1000000** | **2,828,572.904 ns** | **26,077.2310 ns** |  **24,392.6581 ns** | **2,827,620.508 ns** |  **1.00** |    **0.01** | **996.0938** | **996.0938** | **996.0938** | **4000359 B** |       **1.000** |
| PopulateWithEnumerableRange               | 1000000 | 2,643,524.605 ns | 81,952.2329 ns | 240,351.7301 ns | 2,710,630.078 ns |  0.93 |    0.08 | 996.0938 | 996.0938 | 996.0938 | 4000399 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | 1000000 | 2,967,553.581 ns | 27,718.7035 ns |  25,928.0924 ns | 2,968,241.992 ns |  1.05 |    0.01 | 996.0938 | 996.0938 | 996.0938 | 4000359 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 1000000 |   677,194.999 ns |  4,116.5810 ns |   3,649.2418 ns |   678,020.850 ns |  0.24 |    0.00 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | 1000000 | 2,153,497.708 ns | 17,480.8439 ns |  16,351.5923 ns | 2,155,499.609 ns |  0.76 |    0.01 | 500.0000 | 500.0000 | 500.0000 | 8000180 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | 1000000 | 1,269,005.130 ns | 10,209.4049 ns |   9,549.8837 ns | 1,272,292.383 ns |  0.45 |    0.00 |        - |        - |        - |      88 B |       0.000 |
