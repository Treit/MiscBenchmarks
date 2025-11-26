# MemoryStream vs. List<byte>





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Count  | Mean          | Error        | StdDev        | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|------------------------------------- |------- |--------------:|-------------:|--------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **WriteMemoryStream**                    | **1**      |      **20.78 ns** |     **0.424 ns** |      **0.397 ns** |  **1.00** |    **0.03** |  **0.0186** |       **-** |       **-** |     **312 B** |        **1.00** |
| WriteListOfByte                      | 1      |      16.99 ns |     0.179 ns |      0.159 ns |  0.82 |    0.02 |  0.0057 |       - |       - |      96 B |        0.31 |
| WriteMemoryStreamWithInitialCapacity | 1      |      17.20 ns |     0.316 ns |      0.296 ns |  0.83 |    0.02 |  0.0076 |       - |       - |     128 B |        0.41 |
| WriteListOfByteWithInitialCapacity   | 1      |      14.96 ns |     0.212 ns |      0.188 ns |  0.72 |    0.02 |  0.0057 |       - |       - |      96 B |        0.31 |
|                                      |        |               |              |               |       |         |         |         |         |           |             |
| **WriteMemoryStream**                    | **1000**   |   **1,993.87 ns** |    **27.808 ns** |     **24.651 ns** |  **1.00** |    **0.02** |  **0.1755** |       **-** |       **-** |    **2952 B** |        **1.00** |
| WriteListOfByte                      | 1000   |   3,073.27 ns |    10.776 ns |      9.553 ns |  1.54 |    0.02 |  0.1984 |       - |       - |    3320 B |        1.12 |
| WriteMemoryStreamWithInitialCapacity | 1000   |   1,897.73 ns |    15.397 ns |     13.649 ns |  0.95 |    0.01 |  0.1259 |       - |       - |    2112 B |        0.72 |
| WriteListOfByteWithInitialCapacity   | 1000   |   1,571.15 ns |     7.015 ns |      5.858 ns |  0.79 |    0.01 |  0.1240 |       - |       - |    2080 B |        0.70 |
|                                      |        |               |              |               |       |         |         |         |         |           |             |
| **WriteMemoryStream**                    | **100000** | **339,417.47 ns** | **6,687.970 ns** | **14,539.099 ns** |  **1.00** |    **0.07** | **71.2891** | **71.2891** | **71.2891** |  **362240 B** |        **1.00** |
| WriteListOfByte                      | 100000 | 317,993.97 ns | 6,298.979 ns | 15,091.952 ns |  0.94 |    0.06 | 71.2891 | 71.2891 | 71.2891 |  362608 B |        1.00 |
| WriteMemoryStreamWithInitialCapacity | 100000 | 290,089.19 ns | 5,058.048 ns | 12,689.655 ns |  0.86 |    0.06 | 62.0117 | 62.0117 | 62.0117 |  200133 B |        0.55 |
| WriteListOfByteWithInitialCapacity   | 100000 | 243,074.67 ns | 3,372.667 ns |  3,154.795 ns |  0.72 |    0.04 | 62.0117 | 62.0117 | 62.0117 |  200101 B |        0.55 |
