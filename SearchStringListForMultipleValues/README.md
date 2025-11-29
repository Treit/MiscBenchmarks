# Searching for several items in a list of strings.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  ShortRun  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | Job       | Runtime   | IterationCount | LaunchCount | WarmupCount | Count | Mean          | Error         | StdDev     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------- |---------- |---------- |--------------- |------------ |------------ |------ |--------------:|--------------:|-----------:|------:|--------:|----------:|------------:|
| **CheckWithForEachSinglePass**     | **.NET 10.0** | **.NET 10.0** | **Default**        | **Default**     | **Default**     | **5**     |      **24.97 ns** |      **0.059 ns** |   **0.049 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 5     |      26.79 ns |      0.053 ns |   0.047 ns |  1.07 |    0.00 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| CheckWithForEachSinglePass     | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 5     |      24.43 ns |      0.093 ns |   0.087 ns |  1.00 |    0.00 |         - |          NA |
| CheckWithMultipleContainsCalls | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 5     |      26.28 ns |      0.041 ns |   0.034 ns |  1.08 |    0.00 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| CheckWithForEachSinglePass     | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 5     |      24.98 ns |      0.573 ns |   0.031 ns |  1.00 |    0.00 |         - |          NA |
| CheckWithMultipleContainsCalls | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 5     |      24.43 ns |      1.669 ns |   0.091 ns |  0.98 |    0.00 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| **CheckWithForEachSinglePass**     | **.NET 10.0** | **.NET 10.0** | **Default**        | **Default**     | **Default**     | **50**    |     **138.61 ns** |      **1.199 ns** |   **1.063 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 50    |     138.13 ns |      2.769 ns |   2.590 ns |  1.00 |    0.02 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| CheckWithForEachSinglePass     | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 50    |     139.73 ns |      0.640 ns |   0.534 ns |  1.00 |    0.01 |         - |          NA |
| CheckWithMultipleContainsCalls | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 50    |     139.80 ns |      2.804 ns |   2.623 ns |  1.00 |    0.02 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| CheckWithForEachSinglePass     | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 50    |     139.70 ns |     19.117 ns |   1.048 ns |  1.00 |    0.01 |         - |          NA |
| CheckWithMultipleContainsCalls | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 50    |     151.52 ns |      4.796 ns |   0.263 ns |  1.08 |    0.01 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| **CheckWithForEachSinglePass**     | **.NET 10.0** | **.NET 10.0** | **Default**        | **Default**     | **Default**     | **50000** | **124,585.15 ns** |    **286.032 ns** | **253.560 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CheckWithMultipleContainsCalls | .NET 10.0 | .NET 10.0 | Default        | Default     | Default     | 50000 | 124,699.07 ns |    357.004 ns | 333.942 ns |  1.00 |    0.00 |         - |          NA |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| CheckWithForEachSinglePass     | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 50000 | 123,937.98 ns |    209.375 ns | 174.838 ns |  1.00 |    0.00 |       3 B |        1.00 |
| CheckWithMultipleContainsCalls | .NET 9.0  | .NET 9.0  | Default        | Default     | Default     | 50000 | 124,463.44 ns |    548.864 ns | 486.554 ns |  1.00 |    0.00 |         - |        0.00 |
|                                |           |           |                |             |             |       |               |               |            |       |         |           |             |
| CheckWithForEachSinglePass     | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 50000 | 124,916.47 ns | 15,188.719 ns | 832.545 ns |  1.00 |    0.01 |         - |          NA |
| CheckWithMultipleContainsCalls | ShortRun  | .NET 10.0 | 3              | 1           | 3           | 50000 | 132,730.02 ns |  8,121.339 ns | 445.158 ns |  1.06 |    0.01 |         - |          NA |
