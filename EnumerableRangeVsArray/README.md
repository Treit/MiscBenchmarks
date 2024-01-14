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



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                    Method |   Count |             Mean |           Error |          StdDev |           Median | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|------------------------------------------ |-------- |-----------------:|----------------:|----------------:|-----------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
|                 **PopulateWithExplicitArray** |      **10** |         **7.599 ns** |       **0.0974 ns** |       **0.0911 ns** |         **7.596 ns** |  **1.00** |    **0.00** |   **0.0038** |        **-** |        **-** |      **64 B** |        **1.00** |
|               PopulateWithEnumerableRange |      10 |        17.844 ns |       0.2141 ns |       0.1898 ns |        17.929 ns |  2.35 |    0.02 |   0.0062 |        - |        - |     104 B |        1.62 |
|   PopulateAndTakeAverageWithExplicitArray |      10 |        23.517 ns |       0.2052 ns |       0.1920 ns |        23.576 ns |  3.10 |    0.05 |   0.0038 |        - |        - |      64 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange |      10 |        21.278 ns |       0.2065 ns |       0.1931 ns |        21.215 ns |  2.80 |    0.05 |   0.0024 |        - |        - |      40 B |        0.62 |
|       PopulateAndTakeSumWithExplicitArray |      10 |        12.322 ns |       0.1765 ns |       0.1651 ns |        12.339 ns |  1.62 |    0.02 |   0.0062 |        - |        - |     104 B |        1.62 |
|     PopulateAndTakeSumWithEnumerableRange |      10 |        38.455 ns |       0.6396 ns |       0.5982 ns |        38.335 ns |  5.06 |    0.12 |   0.0052 |        - |        - |      88 B |        1.38 |
|                                           |         |                  |                 |                 |                  |       |         |          |          |          |           |             |
|                 **PopulateWithExplicitArray** |     **100** |        **53.110 ns** |       **1.0292 ns** |       **0.9627 ns** |        **53.195 ns** |  **1.00** |    **0.00** |   **0.0253** |        **-** |        **-** |     **424 B** |        **1.00** |
|               PopulateWithEnumerableRange |     100 |        34.856 ns |       0.7161 ns |       0.7662 ns |        34.912 ns |  0.65 |    0.02 |   0.0277 |        - |        - |     464 B |        1.09 |
|   PopulateAndTakeAverageWithExplicitArray |     100 |        70.397 ns |       0.9619 ns |       0.8527 ns |        70.259 ns |  1.33 |    0.03 |   0.0253 |        - |        - |     424 B |        1.00 |
| PopulateAndTakeAverageWithEnumerableRange |     100 |       110.745 ns |       0.8100 ns |       0.7576 ns |       110.932 ns |  2.09 |    0.04 |   0.0024 |        - |        - |      40 B |        0.09 |
|       PopulateAndTakeSumWithExplicitArray |     100 |        76.278 ns |       0.7850 ns |       0.6959 ns |        76.266 ns |  1.44 |    0.02 |   0.0492 |        - |        - |     824 B |        1.94 |
|     PopulateAndTakeSumWithEnumerableRange |     100 |       158.720 ns |       0.5927 ns |       0.5544 ns |       158.748 ns |  2.99 |    0.05 |   0.0052 |        - |        - |      88 B |        0.21 |
|                                           |         |                  |                 |                 |                  |       |         |          |          |          |           |             |
|                 **PopulateWithExplicitArray** |    **1000** |       **456.548 ns** |       **7.0092 ns** |       **6.5564 ns** |       **456.079 ns** |  **1.00** |    **0.00** |   **0.2403** |        **-** |        **-** |    **4024 B** |       **1.000** |
|               PopulateWithEnumerableRange |    1000 |       192.460 ns |       3.2232 ns |       3.0150 ns |       192.698 ns |  0.42 |    0.00 |   0.2427 |        - |        - |    4064 B |       1.010 |
|   PopulateAndTakeAverageWithExplicitArray |    1000 |       610.980 ns |       6.4432 ns |       5.7117 ns |       609.199 ns |  1.34 |    0.02 |   0.2403 |        - |        - |    4024 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange |    1000 |       949.288 ns |       1.6998 ns |       1.5068 ns |       948.741 ns |  2.08 |    0.03 |   0.0019 |        - |        - |      40 B |       0.010 |
|       PopulateAndTakeSumWithExplicitArray |    1000 |       758.213 ns |       9.4183 ns |       8.8099 ns |       758.242 ns |  1.66 |    0.03 |   0.4787 |        - |        - |    8024 B |       1.994 |
|     PopulateAndTakeSumWithEnumerableRange |    1000 |     1,125.792 ns |       2.0891 ns |       1.6311 ns |     1,125.601 ns |  2.46 |    0.04 |   0.0038 |        - |        - |      88 B |       0.022 |
|                                           |         |                  |                 |                 |                  |       |         |          |          |          |           |             |
|                 **PopulateWithExplicitArray** |  **100000** |   **232,470.620 ns** |  **10,401.1322 ns** |  **30,667.9730 ns** |   **227,796.899 ns** |  **1.00** |    **0.00** | **124.7559** | **124.7559** | **124.7559** |  **400066 B** |       **1.000** |
|               PopulateWithEnumerableRange |  100000 |   210,785.531 ns |  12,547.4657 ns |  36,996.4856 ns |   192,190.747 ns |  0.92 |    0.21 | 124.5117 | 124.5117 | 124.5117 |  400106 B |       1.000 |
|   PopulateAndTakeAverageWithExplicitArray |  100000 |   245,973.023 ns |   9,577.2604 ns |  28,238.7684 ns |   242,909.546 ns |  1.08 |    0.19 | 124.7559 | 124.7559 | 124.7559 |  400066 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange |  100000 |    93,034.581 ns |     107.0211 ns |      89.3675 ns |    92,997.607 ns |  0.40 |    0.06 |        - |        - |        - |      40 B |       0.000 |
|       PopulateAndTakeSumWithExplicitArray |  100000 |   449,682.451 ns |  22,282.1438 ns |  65,699.4037 ns |   446,524.854 ns |  1.97 |    0.42 | 249.5117 | 249.5117 | 249.5117 |  800108 B |       2.000 |
|     PopulateAndTakeSumWithEnumerableRange |  100000 |   108,657.756 ns |     155.7534 ns |     138.0713 ns |   108,623.407 ns |  0.46 |    0.07 |        - |        - |        - |      88 B |       0.000 |
|                                           |         |                  |                 |                 |                  |       |         |          |          |          |           |             |
|                 **PopulateWithExplicitArray** | **1000000** | **2,206,056.855 ns** |  **90,155.9392 ns** | **265,826.8209 ns** | **2,198,640.234 ns** |  **1.00** |    **0.00** | **998.0469** | **998.0469** | **998.0469** | **4000360 B** |       **1.000** |
|               PopulateWithEnumerableRange | 1000000 | 2,022,750.879 ns | 113,141.2512 ns | 333,599.5318 ns | 1,805,446.680 ns |  0.93 |    0.19 | 996.0938 | 996.0938 | 996.0938 | 4000400 B |       1.000 |
|   PopulateAndTakeAverageWithExplicitArray | 1000000 | 2,552,424.500 ns | 133,161.0546 ns | 392,628.3739 ns | 2,679,778.125 ns |  1.17 |    0.21 | 996.0938 | 996.0938 | 996.0938 | 4000360 B |       1.000 |
| PopulateAndTakeAverageWithEnumerableRange | 1000000 |   933,103.568 ns |   5,241.5458 ns |   4,902.9452 ns |   930,342.090 ns |  0.42 |    0.05 |        - |        - |        - |      40 B |       0.000 |
|       PopulateAndTakeSumWithExplicitArray | 1000000 | 1,355,187.305 ns |  19,570.0727 ns |  17,348.3597 ns | 1,355,597.852 ns |  0.61 |    0.07 | 337.8906 | 337.8906 | 337.8906 | 8000130 B |       2.000 |
|     PopulateAndTakeSumWithEnumerableRange | 1000000 | 1,086,312.575 ns |   1,826.4021 ns |   1,525.1284 ns | 1,085,676.172 ns |  0.49 |    0.06 |        - |        - |        - |      89 B |       0.000 |
