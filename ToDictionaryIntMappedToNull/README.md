# Building an array that maps int to nulls with the intention of replacing the nulls later.
At least, that's what the original code I found that uses Zip was being used for

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27686.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 9.0.0 (9.0.24.32707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.32707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                 | Count | Mean         | Error       | StdDev       | Median       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------------- |------ |-------------:|------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **BuildDictionaryUsingForLoop**            | **10**    |     **123.6 ns** |     **2.83 ns** |      **8.02 ns** |     **121.0 ns** |  **1.00** |    **0.00** |   **0.1018** |        **-** |        **-** |     **440 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | 10    |     498.8 ns |     6.38 ns |      5.65 ns |     497.5 ns |  4.03 |    0.22 |   0.3672 |        - |        - |    1584 B |        3.60 |
| BuildDictionaryUsingToDictionary       | 10    |     138.8 ns |     2.66 ns |      2.36 ns |     138.1 ns |  1.12 |    0.06 |   0.1018 |        - |        - |     440 B |        1.00 |
|                                        |       |              |             |              |              |       |         |          |          |          |           |             |
| **BuildDictionaryUsingForLoop**            | **10000** | **188,841.9 ns** | **1,504.38 ns** |  **1,333.59 ns** | **188,365.9 ns** |  **1.00** |    **0.00** |  **76.9043** |  **76.9043** |  **76.9043** |  **283042 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | 10000 | 648,088.2 ns | 9,414.03 ns |  8,345.29 ns | 644,425.4 ns |  3.43 |    0.04 | 221.6797 | 221.6797 | 221.6797 | 1342275 B |        4.74 |
| BuildDictionaryUsingToDictionary       | 10000 | 205,022.5 ns | 4,077.87 ns | 10,230.58 ns | 200,662.1 ns |  1.08 |    0.07 |  76.9043 |  76.9043 |  76.9043 |  283042 B |        1.00 |
