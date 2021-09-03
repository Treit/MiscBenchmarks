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


