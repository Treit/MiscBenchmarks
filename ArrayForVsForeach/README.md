# Counting strings using a for loop vs. a foreach loop.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21390
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21258.4
  [Host]   : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  ShortRun : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|           Method |   Count |             Mean |            Error |          StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |-------- |-----------------:|-----------------:|----------------:|------:|--------:|------:|------:|------:|----------:|
|     ForLoopCount |      10 |        12.809 ns |        22.841 ns |       1.2520 ns |  1.29 |    0.10 |     - |     - |     - |         - |
| ForEachLoopCount |      10 |         9.957 ns |         8.053 ns |       0.4414 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                  |         |                  |                  |                 |       |         |       |       |       |           |
|     ForLoopCount |     100 |       128.189 ns |       170.164 ns |       9.3273 ns |  1.06 |    0.16 |     - |     - |     - |         - |
| ForEachLoopCount |     100 |       122.290 ns |       302.690 ns |      16.5915 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                  |         |                  |                  |                 |       |         |       |       |       |           |
|     ForLoopCount |    1000 |     1,116.487 ns |       429.682 ns |      23.5523 ns |  1.08 |    0.07 |     - |     - |     - |         - |
| ForEachLoopCount |    1000 |     1,036.311 ns |     1,537.119 ns |      84.2547 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                  |         |                  |                  |                 |       |         |       |       |       |           |
|     ForLoopCount |  100000 |   155,010.246 ns |    17,358.951 ns |     951.5027 ns |  1.09 |    0.05 |     - |     - |     - |         - |
| ForEachLoopCount |  100000 |   142,868.604 ns |   125,334.381 ns |   6,870.0003 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|                  |         |                  |                  |                 |       |         |       |       |       |           |
|     ForLoopCount | 1000000 | 3,919,454.427 ns | 1,985,292.862 ns | 108,820.6008 ns |  1.07 |    0.04 |     - |     - |     - |         - |
| ForEachLoopCount | 1000000 | 3,678,613.346 ns |   895,732.166 ns |  49,098.1025 ns |  1.00 |    0.00 |     - |     - |     - |         - |
