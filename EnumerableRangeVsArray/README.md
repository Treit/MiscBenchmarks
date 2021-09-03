# Enumerable.Range vs Explicit Array population.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22449
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                                    Method |   Count |             Mean |            Error |         StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------------------------ |-------- |-----------------:|-----------------:|---------------:|------:|--------:|---------:|---------:|---------:|----------:|
|                 PopulateWithExplicitArray |      10 |         9.923 ns |         9.152 ns |      0.5017 ns |  1.00 |    0.00 |   0.0148 |        - |        - |      64 B |
|               PopulateWithEnumerableRange |      10 |        33.875 ns |         9.268 ns |      0.5080 ns |  3.42 |    0.22 |   0.0241 |        - |        - |     104 B |
|   PopulateAndTakeAverageWithExplicitArray |      10 |        75.870 ns |        28.245 ns |      1.5482 ns |  7.66 |    0.53 |   0.0222 |        - |        - |      96 B |
| PopulateAndTakeAverageWithEnumerableRange |      10 |        74.734 ns |        86.065 ns |      4.7175 ns |  7.55 |    0.78 |   0.0092 |        - |        - |      40 B |
|                                           |         |                  |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray |     100 |        72.392 ns |        17.591 ns |      0.9642 ns |  1.00 |    0.00 |   0.0982 |        - |        - |     424 B |
|               PopulateWithEnumerableRange |     100 |       110.269 ns |       128.971 ns |      7.0693 ns |  1.52 |    0.11 |   0.1075 |        - |        - |     464 B |
|   PopulateAndTakeAverageWithExplicitArray |     100 |       637.863 ns |       429.533 ns |     23.5442 ns |  8.81 |    0.22 |   0.1049 |        - |        - |     456 B |
| PopulateAndTakeAverageWithEnumerableRange |     100 |       513.867 ns |       295.443 ns |     16.1942 ns |  7.10 |    0.30 |   0.0086 |        - |        - |      40 B |
|                                           |         |                  |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray |    1000 |       668.327 ns |       599.078 ns |     32.8375 ns |  1.00 |    0.00 |   0.9327 |        - |        - |    4024 B |
|               PopulateWithEnumerableRange |    1000 |       750.204 ns |       126.855 ns |      6.9533 ns |  1.12 |    0.05 |   0.9413 |        - |        - |    4064 B |
|   PopulateAndTakeAverageWithExplicitArray |    1000 |     5,602.747 ns |     5,870.564 ns |    321.7854 ns |  8.41 |    0.83 |   0.9384 |        - |        - |    4056 B |
| PopulateAndTakeAverageWithEnumerableRange |    1000 |     4,582.761 ns |     4,212.952 ns |    230.9261 ns |  6.88 |    0.65 |   0.0076 |        - |        - |      40 B |
|                                           |         |                  |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray |  100000 |   198,295.508 ns |    10,781.638 ns |    590.9780 ns |  1.00 |    0.00 | 124.7559 | 124.7559 | 124.7559 |  400024 B |
|               PopulateWithEnumerableRange |  100000 |   206,851.917 ns |    99,179.611 ns |  5,436.3692 ns |  1.04 |    0.03 | 124.7559 | 124.7559 | 124.7559 |  400064 B |
|   PopulateAndTakeAverageWithExplicitArray |  100000 |   729,418.376 ns |   166,016.147 ns |  9,099.9052 ns |  3.68 |    0.05 | 124.0234 | 124.0234 | 124.0234 |  400056 B |
| PopulateAndTakeAverageWithEnumerableRange |  100000 |   435,035.807 ns |   480,470.966 ns | 26,336.2349 ns |  2.19 |    0.14 |        - |        - |        - |      40 B |
|                                           |         |                  |                  |                |       |         |          |          |          |           |
|                 PopulateWithExplicitArray | 1000000 | 1,887,269.271 ns |   598,933.717 ns | 32,829.5781 ns |  1.00 |    0.00 | 996.0938 | 996.0938 | 996.0938 | 4000024 B |
|               PopulateWithEnumerableRange | 1000000 | 2,017,998.340 ns |   790,979.735 ns | 43,356.2683 ns |  1.07 |    0.04 | 998.0469 | 998.0469 | 998.0469 | 4000064 B |
|   PopulateAndTakeAverageWithExplicitArray | 1000000 | 7,744,359.375 ns |   657,543.307 ns | 36,042.1675 ns |  4.10 |    0.07 | 992.1875 | 992.1875 | 992.1875 | 4000056 B |
| PopulateAndTakeAverageWithEnumerableRange | 1000000 | 5,086,308.854 ns | 1,596,010.615 ns | 87,482.7273 ns |  2.70 |    0.06 |        - |        - |        - |      40 B |

