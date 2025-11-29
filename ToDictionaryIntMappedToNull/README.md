# Building an array that maps int to nulls with the intention of replacing the nulls later.
At least, that's what the original code I found that uses Zip was being used for




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Job       | Runtime   | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------------- |---------- |---------- |------ |--------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **BuildDictionaryUsingForLoop**            | **.NET 10.0** | **.NET 10.0** | **10**    |      **89.35 ns** |     **0.571 ns** |     **0.446 ns** |  **1.00** |    **0.01** |   **0.0262** |        **-** |        **-** |     **440 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | .NET 10.0 | .NET 10.0 | 10    |     388.94 ns |     4.170 ns |     3.901 ns |  4.35 |    0.05 |   0.0944 |        - |        - |    1584 B |        3.60 |
| BuildDictionaryUsingToDictionary       | .NET 10.0 | .NET 10.0 | 10    |      95.13 ns |     1.873 ns |     1.840 ns |  1.06 |    0.02 |   0.0262 |        - |        - |     440 B |        1.00 |
|                                        |           |           |       |               |              |              |       |         |          |          |          |           |             |
| BuildDictionaryUsingForLoop            | .NET 9.0  | .NET 9.0  | 10    |      89.60 ns |     0.598 ns |     0.560 ns |  1.00 |    0.01 |   0.0262 |        - |        - |     440 B |        1.00 |
| BuildDictionaryUsingZipAndToDictionary | .NET 9.0  | .NET 9.0  | 10    |     357.71 ns |     2.727 ns |     2.551 ns |  3.99 |    0.04 |   0.0944 |        - |        - |    1584 B |        3.60 |
| BuildDictionaryUsingToDictionary       | .NET 9.0  | .NET 9.0  | 10    |      92.33 ns |     1.676 ns |     1.568 ns |  1.03 |    0.02 |   0.0262 |        - |        - |     440 B |        1.00 |
|                                        |           |           |       |               |              |              |       |         |          |          |          |           |             |
| **BuildDictionaryUsingForLoop**            | **.NET 10.0** | **.NET 10.0** | **10000** | **138,827.94 ns** | **2,727.418 ns** | **2,800.858 ns** |  **1.00** |    **0.03** |  **76.9043** |  **76.9043** |  **76.9043** |  **283042 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | .NET 10.0 | .NET 10.0 | 10000 | 466,325.26 ns | 2,634.270 ns | 2,464.097 ns |  3.36 |    0.07 | 222.1680 | 222.1680 | 222.1680 | 1342275 B |        4.74 |
| BuildDictionaryUsingToDictionary       | .NET 10.0 | .NET 10.0 | 10000 | 161,652.34 ns | 2,044.082 ns | 1,912.036 ns |  1.16 |    0.03 |  76.9043 |  76.9043 |  76.9043 |  283042 B |        1.00 |
|                                        |           |           |       |               |              |              |       |         |          |          |          |           |             |
| BuildDictionaryUsingForLoop            | .NET 9.0  | .NET 9.0  | 10000 | 138,440.80 ns | 2,753.815 ns | 2,946.551 ns |  1.00 |    0.03 |  76.9043 |  76.9043 |  76.9043 |  283042 B |        1.00 |
| BuildDictionaryUsingZipAndToDictionary | .NET 9.0  | .NET 9.0  | 10000 | 492,723.05 ns | 5,306.685 ns | 4,963.876 ns |  3.56 |    0.08 | 221.6797 | 221.6797 | 221.6797 | 1342274 B |        4.74 |
| BuildDictionaryUsingToDictionary       | .NET 9.0  | .NET 9.0  | 10000 | 161,791.93 ns | 3,213.645 ns | 3,156.229 ns |  1.17 |    0.03 |  76.9043 |  76.9043 |  76.9043 |  283042 B |        1.00 |
