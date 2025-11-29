# MemoryStream vs. List<byte>






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------- |---------- |---------- |------- |--------------:|-------------:|-------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **WriteMemoryStream**                    | **.NET 10.0** | **.NET 10.0** | **1**      |      **27.99 ns** |     **0.400 ns** |     **0.374 ns** |  **1.00** |    **0.02** |  **0.0225** |       **-** |       **-** |     **376 B** |        **1.00** |
| WriteListOfByte                      | .NET 10.0 | .NET 10.0 | 1      |      16.57 ns |     0.176 ns |     0.156 ns |  0.59 |    0.01 |  0.0057 |       - |       - |      96 B |        0.26 |
| WriteMemoryStreamWithInitialCapacity | .NET 10.0 | .NET 10.0 | 1      |      17.33 ns |     0.166 ns |     0.155 ns |  0.62 |    0.01 |  0.0076 |       - |       - |     128 B |        0.34 |
| WriteListOfByteWithInitialCapacity   | .NET 10.0 | .NET 10.0 | 1      |      14.93 ns |     0.178 ns |     0.158 ns |  0.53 |    0.01 |  0.0057 |       - |       - |      96 B |        0.26 |
|                                      |           |           |        |               |              |              |       |         |         |         |         |           |             |
| WriteMemoryStream                    | .NET 9.0  | .NET 9.0  | 1      |      27.51 ns |     0.218 ns |     0.193 ns |  1.00 |    0.01 |  0.0225 |       - |       - |     376 B |        1.00 |
| WriteListOfByte                      | .NET 9.0  | .NET 9.0  | 1      |      16.95 ns |     0.392 ns |     0.481 ns |  0.62 |    0.02 |  0.0057 |       - |       - |      96 B |        0.26 |
| WriteMemoryStreamWithInitialCapacity | .NET 9.0  | .NET 9.0  | 1      |      17.05 ns |     0.136 ns |     0.127 ns |  0.62 |    0.01 |  0.0076 |       - |       - |     128 B |        0.34 |
| WriteListOfByteWithInitialCapacity   | .NET 9.0  | .NET 9.0  | 1      |      14.68 ns |     0.126 ns |     0.118 ns |  0.53 |    0.01 |  0.0057 |       - |       - |      96 B |        0.26 |
|                                      |           |           |        |               |              |              |       |         |         |         |         |           |             |
| **WriteMemoryStream**                    | **.NET 10.0** | **.NET 10.0** | **1000**   |   **1,956.61 ns** |     **9.860 ns** |     **8.740 ns** |  **1.00** |    **0.01** |  **0.1755** |       **-** |       **-** |    **2952 B** |        **1.00** |
| WriteListOfByte                      | .NET 10.0 | .NET 10.0 | 1000   |   3,042.06 ns |     7.912 ns |     7.014 ns |  1.55 |    0.01 |  0.1984 |       - |       - |    3320 B |        1.12 |
| WriteMemoryStreamWithInitialCapacity | .NET 10.0 | .NET 10.0 | 1000   |   1,877.66 ns |     6.811 ns |     6.037 ns |  0.96 |    0.01 |  0.1259 |       - |       - |    2112 B |        0.72 |
| WriteListOfByteWithInitialCapacity   | .NET 10.0 | .NET 10.0 | 1000   |   1,565.51 ns |     6.171 ns |     5.471 ns |  0.80 |    0.00 |  0.1240 |       - |       - |    2080 B |        0.70 |
|                                      |           |           |        |               |              |              |       |         |         |         |         |           |             |
| WriteMemoryStream                    | .NET 9.0  | .NET 9.0  | 1000   |   1,962.40 ns |    12.830 ns |    12.001 ns |  1.00 |    0.01 |  0.1755 |       - |       - |    2952 B |        1.00 |
| WriteListOfByte                      | .NET 9.0  | .NET 9.0  | 1000   |   2,766.65 ns |    13.421 ns |    12.554 ns |  1.41 |    0.01 |  0.1984 |       - |       - |    3320 B |        1.12 |
| WriteMemoryStreamWithInitialCapacity | .NET 9.0  | .NET 9.0  | 1000   |   1,874.51 ns |     6.242 ns |     5.839 ns |  0.96 |    0.01 |  0.1259 |       - |       - |    2112 B |        0.72 |
| WriteListOfByteWithInitialCapacity   | .NET 9.0  | .NET 9.0  | 1000   |   1,565.44 ns |     8.152 ns |     7.625 ns |  0.80 |    0.01 |  0.1240 |       - |       - |    2080 B |        0.70 |
|                                      |           |           |        |               |              |              |       |         |         |         |         |           |             |
| **WriteMemoryStream**                    | **.NET 10.0** | **.NET 10.0** | **100000** | **284,110.25 ns** | **2,416.331 ns** | **2,260.238 ns** |  **1.00** |    **0.01** | **71.2891** | **71.2891** | **71.2891** |  **362240 B** |        **1.00** |
| WriteListOfByte                      | .NET 10.0 | .NET 10.0 | 100000 | 266,398.44 ns | 1,880.676 ns | 1,759.185 ns |  0.94 |    0.01 | 71.2891 | 71.2891 | 71.2891 |  362608 B |        1.00 |
| WriteMemoryStreamWithInitialCapacity | .NET 10.0 | .NET 10.0 | 100000 | 267,716.61 ns | 2,821.965 ns | 2,639.668 ns |  0.94 |    0.01 | 62.0117 | 62.0117 | 62.0117 |  200133 B |        0.55 |
| WriteListOfByteWithInitialCapacity   | .NET 10.0 | .NET 10.0 | 100000 | 239,082.87 ns |   788.180 ns |   737.264 ns |  0.84 |    0.01 | 62.2559 | 62.2559 | 62.2559 |  200101 B |        0.55 |
|                                      |           |           |        |               |              |              |       |         |         |         |         |           |             |
| WriteMemoryStream                    | .NET 9.0  | .NET 9.0  | 100000 | 285,324.05 ns | 3,309.732 ns | 3,095.925 ns |  1.00 |    0.01 | 71.2891 | 71.2891 | 71.2891 |  362240 B |        1.00 |
| WriteListOfByte                      | .NET 9.0  | .NET 9.0  | 100000 | 264,704.30 ns | 2,685.618 ns | 2,512.128 ns |  0.93 |    0.01 | 71.2891 | 71.2891 | 71.2891 |  362608 B |        1.00 |
| WriteMemoryStreamWithInitialCapacity | .NET 9.0  | .NET 9.0  | 100000 | 267,174.58 ns | 2,210.758 ns | 1,959.779 ns |  0.94 |    0.01 | 62.0117 | 62.0117 | 62.0117 |  200133 B |        0.55 |
| WriteListOfByteWithInitialCapacity   | .NET 9.0  | .NET 9.0  | 100000 | 238,535.59 ns | 1,196.941 ns | 1,119.620 ns |  0.84 |    0.01 | 62.2559 | 62.2559 | 62.2559 |  200101 B |        0.55 |
