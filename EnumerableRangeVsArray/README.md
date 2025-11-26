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
| **PopulateWithExplicitArray**                 | **10**      |         **6.994 ns** |      **0.1477 ns** |       **0.1382 ns** |         **6.997 ns** |  **1.00** |    **0.03** |   **0.0038** |        **-** |        **-** |      **64 B** |        **1.00** |
| PopulateWithEnumerableRange               | 10      |        10.222 ns |      0.1787 ns |       0.1671 ns |        10.274 ns |  1.46 |    0.04 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeAverageWithExplicitArray   | 10      |        23.759 ns |      0.2189 ns |       0.2048 ns |        23.729 ns |  3.40 |    0.07 |   0.0038 |        - |        - |      64 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | 10      |        18.231 ns |      0.2567 ns |       0.2401 ns |        18.143 ns |  2.61 |    0.06 |   0.0024 |        - |        - |      40 B |        0.62 |
| PopulateAndTakeSumWithExplicitArray       | 10      |        13.679 ns |      0.2647 ns |       0.2476 ns |        13.582 ns |  1.96 |    0.05 |   0.0062 |        - |        - |     104 B |        1.62 |
| PopulateAndTakeSumWithEnumerableRange     | 10      |        34.470 ns |      0.4416 ns |       0.4131 ns |        34.394 ns |  4.93 |    0.11 |   0.0052 |        - |        - |      88 B |        1.38 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **100**     |        **47.059 ns** |      **0.3033 ns** |       **0.2688 ns** |        **47.061 ns** |  **1.00** |    **0.01** |   **0.0253** |        **-** |        **-** |     **424 B** |        **1.00** |
| PopulateWithEnumerableRange               | 100     |        25.964 ns |      0.2961 ns |       0.2770 ns |        26.044 ns |  0.55 |    0.01 |   0.0277 |        - |        - |     464 B |        1.09 |
| PopulateAndTakeAverageWithExplicitArray   | 100     |        65.073 ns |      0.9864 ns |       0.9227 ns |        64.768 ns |  1.38 |    0.02 |   0.0253 |        - |        - |     424 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange | 100     |        98.320 ns |      1.9934 ns |       4.7375 ns |        98.696 ns |  2.09 |    0.10 |   0.0024 |        - |        - |      40 B |        0.09 |
| PopulateAndTakeSumWithExplicitArray       | 100     |        71.852 ns |      1.0551 ns |       0.9869 ns |        72.241 ns |  1.53 |    0.02 |   0.0492 |        - |        - |     824 B |        1.94 |
| PopulateAndTakeSumWithEnumerableRange     | 100     |       133.519 ns |      2.6236 ns |       3.0213 ns |       134.536 ns |  2.84 |    0.06 |   0.0052 |        - |        - |      88 B |        0.21 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **1000**    |       **450.087 ns** |      **4.1567 ns** |       **3.8882 ns** |       **448.968 ns** |  **1.00** |    **0.01** |   **0.2403** |        **-** |        **-** |    **4024 B** |       **1.000** |
| PopulateWithEnumerableRange               | 1000    |       177.779 ns |      3.4396 ns |       4.2241 ns |       178.012 ns |  0.40 |    0.01 |   0.2427 |        - |        - |    4064 B |       1.010 |
| PopulateAndTakeAverageWithExplicitArray   | 1000    |       587.833 ns |      7.4300 ns |       6.5865 ns |       588.241 ns |  1.31 |    0.02 |   0.2403 |        - |        - |    4024 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 1000    |       688.463 ns |      9.2851 ns |       7.7535 ns |       685.927 ns |  1.53 |    0.02 |   0.0019 |        - |        - |      40 B |       0.010 |
| PopulateAndTakeSumWithExplicitArray       | 1000    |       723.815 ns |      8.0776 ns |       7.1606 ns |       723.947 ns |  1.61 |    0.02 |   0.4787 |        - |        - |    8024 B |       1.994 |
| PopulateAndTakeSumWithEnumerableRange     | 1000    |     1,105.217 ns |     10.9433 ns |       9.7010 ns |     1,107.676 ns |  2.46 |    0.03 |   0.0038 |        - |        - |      88 B |       0.022 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **100000**  |   **269,518.697 ns** | **10,590.5548 ns** |  **31,060.2662 ns** |   **282,576.831 ns** |  **1.02** |    **0.19** | **124.7559** | **124.7559** | **124.7559** |  **400066 B** |       **1.000** |
| PopulateWithEnumerableRange               | 100000  |   267,689.326 ns |  3,452.4664 ns |   3,229.4392 ns |   269,169.971 ns |  1.01 |    0.15 | 124.5117 | 124.5117 | 124.5117 |  400106 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | 100000  |   297,036.228 ns |  6,672.1462 ns |  19,672.9751 ns |   301,128.857 ns |  1.12 |    0.19 | 124.5117 | 124.5117 | 124.5117 |  400066 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 100000  |    66,864.375 ns |    649.0638 ns |     607.1347 ns |    66,799.890 ns |  0.25 |    0.04 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | 100000  |   543,255.188 ns | 14,177.0371 ns |  41,578.7988 ns |   553,735.254 ns |  2.05 |    0.35 | 249.0234 | 249.0234 | 249.0234 |  800108 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | 100000  |   125,226.951 ns |  1,336.4925 ns |   1,184.7658 ns |   125,081.616 ns |  0.47 |    0.07 |        - |        - |        - |      88 B |       0.000 |
|                                           |         |                  |                |                 |                  |       |         |          |          |          |           |             |
| **PopulateWithExplicitArray**                 | **1000000** | **2,742,174.875 ns** | **70,822.5295 ns** | **208,821.8412 ns** | **2,792,666.016 ns** |  **1.01** |    **0.13** | **996.0938** | **996.0938** | **996.0938** | **4000359 B** |       **1.000** |
| PopulateWithEnumerableRange               | 1000000 | 2,588,133.211 ns | 82,232.9222 ns | 239,877.3112 ns | 2,653,939.258 ns |  0.95 |    0.14 | 996.0938 | 996.0938 | 996.0938 | 4000399 B |       1.000 |
| PopulateAndTakeAverageWithExplicitArray   | 1000000 | 2,903,293.776 ns | 28,595.7095 ns |  26,748.4444 ns | 2,909,534.766 ns |  1.07 |    0.12 | 996.0938 | 996.0938 | 996.0938 | 4000359 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 1000000 |   682,286.146 ns |  5,107.4969 ns |   4,777.5557 ns |   680,823.926 ns |  0.25 |    0.03 |        - |        - |        - |      40 B |       0.000 |
| PopulateAndTakeSumWithExplicitArray       | 1000000 | 2,328,654.492 ns | 44,902.6644 ns |  44,100.4205 ns | 2,341,511.523 ns |  0.86 |    0.09 | 500.0000 | 500.0000 | 500.0000 | 8000180 B |       2.000 |
| PopulateAndTakeSumWithEnumerableRange     | 1000000 | 1,251,546.445 ns |  8,235.2487 ns |   7,703.2567 ns | 1,254,647.070 ns |  0.46 |    0.05 |        - |        - |        - |      88 B |       0.000 |
