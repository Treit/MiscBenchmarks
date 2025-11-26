# Building an array that maps int to nulls with the intention of replacing the nulls later.
At least, that's what the original code I found that uses Zip was being used for



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------------- |------ |--------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **BuildDictionaryUsingForLoop**            | **10**    |      **92.15 ns** |     **0.676 ns** |     **0.564 ns** |  **1.00** |    **0.01** |   **0.0262** |        **-** |        **-** |     **440 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | 10    |     395.07 ns |     3.691 ns |     3.453 ns |  4.29 |    0.04 |   0.0944 |        - |        - |    1584 B |        3.60 |
| BuildDictionaryUsingToDictionary       | 10    |      95.31 ns |     1.470 ns |     1.375 ns |  1.03 |    0.02 |   0.0262 |        - |        - |     440 B |        1.00 |
|                                        |       |               |              |              |       |         |          |          |          |           |             |
| **BuildDictionaryUsingForLoop**            | **10000** | **141,729.51 ns** | **2,787.272 ns** | **2,607.216 ns** |  **1.00** |    **0.03** |  **76.9043** |  **76.9043** |  **76.9043** |  **283042 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | 10000 | 489,996.63 ns | 4,144.463 ns | 3,673.959 ns |  3.46 |    0.07 | 222.1680 | 222.1680 | 222.1680 | 1342275 B |        4.74 |
| BuildDictionaryUsingToDictionary       | 10000 | 168,113.77 ns | 1,531.808 ns | 1,432.854 ns |  1.19 |    0.02 |  76.9043 |  76.9043 |  76.9043 |  283042 B |        1.00 |
