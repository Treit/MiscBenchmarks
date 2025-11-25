# Building an array that maps int to nulls with the intention of replacing the nulls later.
At least, that's what the original code I found that uses Zip was being used for


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Count | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------------- |------ |--------------:|--------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **BuildDictionaryUsingForLoop**            | **10**    |      **90.48 ns** |      **0.636 ns** |      **0.563 ns** |      **90.54 ns** |  **1.00** |    **0.01** |   **0.0262** |        **-** |        **-** |     **440 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | 10    |     386.99 ns |      4.016 ns |      3.756 ns |     386.39 ns |  4.28 |    0.05 |   0.0944 |        - |        - |    1584 B |        3.60 |
| BuildDictionaryUsingToDictionary       | 10    |      93.11 ns |      1.557 ns |      1.456 ns |      93.65 ns |  1.03 |    0.02 |   0.0262 |        - |        - |     440 B |        1.00 |
|                                        |       |               |               |               |               |       |         |          |          |          |           |             |
| **BuildDictionaryUsingForLoop**            | **10000** | **205,757.25 ns** |    **922.312 ns** |    **862.731 ns** | **205,793.65 ns** |  **1.00** |    **0.01** |  **76.9043** |  **76.9043** |  **76.9043** |  **283042 B** |        **1.00** |
| BuildDictionaryUsingZipAndToDictionary | 10000 | 570,156.92 ns | 11,311.859 ns | 32,455.845 ns | 579,398.54 ns |  2.77 |    0.16 | 221.6797 | 221.6797 | 221.6797 | 1342274 B |        4.74 |
| BuildDictionaryUsingToDictionary       | 10000 | 222,471.62 ns |  4,441.806 ns |  8,233.173 ns | 224,026.25 ns |  1.08 |    0.04 |  76.9043 |  76.9043 |  76.9043 |  283042 B |        1.00 |
