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
| **WriteMemoryStream**                    | **1**      |      **27.23 ns** |     **0.589 ns** |      **0.522 ns** |  **1.00** |    **0.03** |  **0.0225** |       **-** |       **-** |     **376 B** |        **1.00** |
| WriteListOfByte                      | 1      |      16.86 ns |     0.325 ns |      0.304 ns |  0.62 |    0.02 |  0.0057 |       - |       - |      96 B |        0.26 |
| WriteMemoryStreamWithInitialCapacity | 1      |      17.06 ns |     0.175 ns |      0.156 ns |  0.63 |    0.01 |  0.0076 |       - |       - |     128 B |        0.34 |
| WriteListOfByteWithInitialCapacity   | 1      |      15.27 ns |     0.160 ns |      0.150 ns |  0.56 |    0.01 |  0.0057 |       - |       - |      96 B |        0.26 |
|                                      |        |               |              |               |       |         |         |         |         |           |             |
| **WriteMemoryStream**                    | **1000**   |   **1,988.62 ns** |    **30.268 ns** |     **28.313 ns** |  **1.00** |    **0.02** |  **0.1755** |       **-** |       **-** |    **2952 B** |        **1.00** |
| WriteListOfByte                      | 1000   |   3,059.66 ns |    13.107 ns |     10.945 ns |  1.54 |    0.02 |  0.1984 |       - |       - |    3320 B |        1.12 |
| WriteMemoryStreamWithInitialCapacity | 1000   |   1,881.62 ns |     5.792 ns |      4.836 ns |  0.95 |    0.01 |  0.1259 |       - |       - |    2112 B |        0.72 |
| WriteListOfByteWithInitialCapacity   | 1000   |   1,568.43 ns |     8.491 ns |      7.527 ns |  0.79 |    0.01 |  0.1240 |       - |       - |    2080 B |        0.70 |
|                                      |        |               |              |               |       |         |         |         |         |           |             |
| **WriteMemoryStream**                    | **100000** | **341,950.92 ns** | **6,730.223 ns** | **14,487.517 ns** |  **1.00** |    **0.06** | **71.2891** | **71.2891** | **71.2891** |  **362240 B** |        **1.00** |
| WriteListOfByte                      | 100000 | 321,974.16 ns | 6,384.247 ns | 12,146.695 ns |  0.94 |    0.06 | 71.2891 | 71.2891 | 71.2891 |  362608 B |        1.00 |
| WriteMemoryStreamWithInitialCapacity | 100000 | 320,347.37 ns | 6,249.903 ns |  8,761.491 ns |  0.94 |    0.05 | 62.0117 | 62.0117 | 62.0117 |  200133 B |        0.55 |
| WriteListOfByteWithInitialCapacity   | 100000 | 282,784.05 ns | 5,157.882 ns |  9,300.725 ns |  0.83 |    0.05 | 62.0117 | 62.0117 | 62.0117 |  200101 B |        0.55 |
