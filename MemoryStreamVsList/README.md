# MemoryStream vs. List<byte>


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25284.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|                               Method |  Count |          Mean |         Error |        StdDev |        Median | Ratio | RatioSD |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
|------------------------------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
|                    **WriteMemoryStream** |      **1** |      **59.48 ns** |      **2.735 ns** |      **7.978 ns** |      **57.76 ns** |  **1.00** |    **0.00** |  **0.0871** |       **-** |       **-** |     **376 B** |        **1.00** |
|                      WriteListOfByte |      1 |      32.01 ns |      1.111 ns |      3.133 ns |      31.05 ns |  0.55 |    0.10 |  0.0222 |       - |       - |      96 B |        0.26 |
| WriteMemoryStreamWithInitialCapacity |      1 |      30.05 ns |      0.663 ns |      0.620 ns |      29.93 ns |  0.54 |    0.05 |  0.0296 |       - |       - |     128 B |        0.34 |
|   WriteListOfByteWithInitialCapacity |      1 |      25.41 ns |      0.493 ns |      0.624 ns |      25.30 ns |  0.45 |    0.05 |  0.0222 |       - |       - |      96 B |        0.26 |
|                                      |        |               |               |               |               |       |         |         |         |         |           |             |
|                    **WriteMemoryStream** |   **1000** |   **5,124.66 ns** |     **99.646 ns** |    **114.752 ns** |   **5,125.63 ns** |  **1.00** |    **0.00** |  **0.6790** |       **-** |       **-** |    **2952 B** |        **1.00** |
|                      WriteListOfByte |   1000 |   1,902.06 ns |     37.844 ns |     35.400 ns |   1,903.87 ns |  0.37 |    0.01 |  0.7687 |       - |       - |    3320 B |        1.12 |
| WriteMemoryStreamWithInitialCapacity |   1000 |   4,451.58 ns |     88.649 ns |    115.269 ns |   4,459.73 ns |  0.87 |    0.03 |  0.4883 |       - |       - |    2112 B |        0.72 |
|   WriteListOfByteWithInitialCapacity |   1000 |   1,744.33 ns |     34.860 ns |     97.751 ns |   1,710.66 ns |  0.35 |    0.03 |  0.4807 |       - |       - |    2080 B |        0.70 |
|                                      |        |               |               |               |               |       |         |         |         |         |           |             |
|                    **WriteMemoryStream** | **100000** | **494,554.02 ns** | **11,330.846 ns** | **32,143.724 ns** | **483,825.56 ns** |  **1.00** |    **0.00** | **71.2891** | **71.2891** | **71.2891** |  **362240 B** |        **1.00** |
|                      WriteListOfByte | 100000 | 203,837.09 ns |  3,994.463 ns |  7,100.155 ns | 203,320.54 ns |  0.41 |    0.03 | 71.2891 | 71.2891 | 71.2891 |  362608 B |        1.00 |
| WriteMemoryStreamWithInitialCapacity | 100000 | 474,081.28 ns | 11,343.438 ns | 32,546.449 ns | 466,584.81 ns |  0.96 |    0.09 | 61.5234 | 61.5234 | 61.5234 |  200133 B |        0.55 |
|   WriteListOfByteWithInitialCapacity | 100000 | 187,708.24 ns |  4,890.281 ns | 14,031.132 ns | 181,904.68 ns |  0.38 |    0.04 | 62.2559 | 62.2559 | 62.2559 |  200101 B |        0.55 |
