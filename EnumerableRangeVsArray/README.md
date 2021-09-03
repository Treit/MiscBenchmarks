# Enumerable.Range vs Explicit Array population.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22449
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|                      Method |   Count |            Mean |            Error |        StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|---------------------------- |-------- |----------------:|-----------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|
|   PopulateWithExplicitArray |      10 |        10.10 ns |         4.283 ns |      0.235 ns |  1.00 |    0.00 |   0.0148 |        - |        - |      64 B |
| PopulateWithEnumerableRange |      10 |        32.58 ns |        18.802 ns |      1.031 ns |  3.23 |    0.18 |   0.0241 |        - |        - |     104 B |
|                             |         |                 |                  |               |       |         |          |          |          |           |
|   PopulateWithExplicitArray |     100 |        71.41 ns |        46.902 ns |      2.571 ns |  1.00 |    0.00 |   0.0982 |        - |        - |     424 B |
| PopulateWithEnumerableRange |     100 |       107.82 ns |        37.826 ns |      2.073 ns |  1.51 |    0.07 |   0.1075 |        - |        - |     464 B |
|                             |         |                 |                  |               |       |         |          |          |          |           |
|   PopulateWithExplicitArray |    1000 |       560.72 ns |       338.708 ns |     18.566 ns |  1.00 |    0.00 |   0.9327 |        - |        - |    4024 B |
| PopulateWithEnumerableRange |    1000 |       703.61 ns |       588.211 ns |     32.242 ns |  1.26 |    0.09 |   0.9413 |        - |        - |    4064 B |
|                             |         |                 |                  |               |       |         |          |          |          |           |
|   PopulateWithExplicitArray |  100000 |   203,350.20 ns |    72,169.798 ns |  3,955.870 ns |  1.00 |    0.00 | 124.7559 | 124.7559 | 124.7559 |  400024 B |
| PopulateWithEnumerableRange |  100000 |   205,501.73 ns |   103,777.620 ns |  5,688.402 ns |  1.01 |    0.04 | 124.7559 | 124.7559 | 124.7559 |  400064 B |
|                             |         |                 |                  |               |       |         |          |          |          |           |
|   PopulateWithExplicitArray | 1000000 | 1,900,777.90 ns |   877,820.711 ns | 48,116.315 ns |  1.00 |    0.00 | 998.0469 | 998.0469 | 998.0469 | 4000024 B |
| PopulateWithEnumerableRange | 1000000 | 2,012,993.36 ns | 1,069,243.499 ns | 58,608.844 ns |  1.06 |    0.02 | 996.0938 | 996.0938 | 996.0938 | 4000064 B |

