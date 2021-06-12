# Counting strings using a for loop vs. a foreach loop.

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.21390
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21258.4
  [Host]   : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  ShortRun : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1
WarmupCount=3

|           Method |   Count |             Mean |            Error |         StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |-------- |-----------------:|-----------------:|---------------:|------:|------:|------:|----------:|
|     ForLoopCount |      10 |        11.416 ns |        14.625 ns |      0.8017 ns |     - |     - |     - |         - |
| ForEachLoopCount |      10 |         9.346 ns |         8.467 ns |      0.4641 ns |     - |     - |     - |         - |
|     ForLoopCount |     100 |       118.705 ns |        28.082 ns |      1.5392 ns |     - |     - |     - |         - |
| ForEachLoopCount |     100 |       113.537 ns |        48.408 ns |      2.6534 ns |     - |     - |     - |         - |
|     ForLoopCount |    1000 |     1,531.019 ns |     2,894.062 ns |    158.6333 ns |     - |     - |     - |         - |
| ForEachLoopCount |    1000 |     1,018.476 ns |     1,530.213 ns |     83.8761 ns |     - |     - |     - |         - |
|     ForLoopCount |  100000 |   147,645.418 ns |   140,863.132 ns |  7,721.1836 ns |     - |     - |     - |         - |
| ForEachLoopCount |  100000 |   158,701.990 ns |    25,669.319 ns |  1,407.0220 ns |     - |     - |     - |         - |
|     ForLoopCount | 1000000 | 3,917,452.734 ns | 1,364,232.871 ns | 74,778.2071 ns |     - |     - |     - |         - |
| ForEachLoopCount | 1000000 | 3,593,329.557 ns | 1,030,691.166 ns | 56,495.6607 ns |     - |     - |     - |         - |
