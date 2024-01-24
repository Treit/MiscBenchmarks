# MemoryStream vs. List<byte>



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                               Method |  Count |          Mean |        Error |       StdDev | Ratio | RatioSD |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
|------------------------------------- |------- |--------------:|-------------:|-------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
|                    **WriteMemoryStream** |      **1** |      **28.05 ns** |     **0.543 ns** |     **0.481 ns** |  **1.00** |    **0.00** |  **0.0225** |       **-** |       **-** |     **376 B** |        **1.00** |
|                      WriteListOfByte |      1 |      22.23 ns |     0.262 ns |     0.245 ns |  0.79 |    0.02 |  0.0057 |       - |       - |      96 B |        0.26 |
| WriteMemoryStreamWithInitialCapacity |      1 |      18.74 ns |     0.174 ns |     0.155 ns |  0.67 |    0.01 |  0.0076 |       - |       - |     128 B |        0.34 |
|   WriteListOfByteWithInitialCapacity |      1 |      16.94 ns |     0.146 ns |     0.136 ns |  0.60 |    0.01 |  0.0057 |       - |       - |      96 B |        0.26 |
|                                      |        |               |              |              |       |         |         |         |         |           |             |
|                    **WriteMemoryStream** |   **1000** |   **2,021.45 ns** |    **10.102 ns** |     **9.449 ns** |  **1.00** |    **0.00** |  **0.1755** |       **-** |       **-** |    **2952 B** |        **1.00** |
|                      WriteListOfByte |   1000 |   3,421.44 ns |     9.536 ns |     8.920 ns |  1.69 |    0.01 |  0.1984 |       - |       - |    3320 B |        1.12 |
| WriteMemoryStreamWithInitialCapacity |   1000 |   1,916.28 ns |     8.922 ns |     7.909 ns |  0.95 |    0.01 |  0.1259 |       - |       - |    2112 B |        0.72 |
|   WriteListOfByteWithInitialCapacity |   1000 |   1,569.77 ns |     5.699 ns |     5.052 ns |  0.78 |    0.00 |  0.1240 |       - |       - |    2080 B |        0.70 |
|                                      |        |               |              |              |       |         |         |         |         |           |             |
|                    **WriteMemoryStream** | **100000** | **210,245.89 ns** |   **899.125 ns** |   **841.042 ns** |  **1.00** |    **0.00** | **71.2891** | **71.2891** | **71.2891** |  **362240 B** |        **1.00** |
|                      WriteListOfByte | 100000 | 191,117.52 ns | 1,002.274 ns |   888.490 ns |  0.91 |    0.00 | 71.2891 | 71.2891 | 71.2891 |  362608 B |        1.00 |
| WriteMemoryStreamWithInitialCapacity | 100000 | 197,707.49 ns |   495.950 ns |   463.912 ns |  0.94 |    0.00 | 62.2559 | 62.2559 | 62.2559 |  200133 B |        0.55 |
|   WriteListOfByteWithInitialCapacity | 100000 | 165,960.53 ns | 1,178.296 ns | 1,102.179 ns |  0.79 |    0.01 | 62.2559 | 62.2559 | 62.2559 |  200101 B |        0.55 |
