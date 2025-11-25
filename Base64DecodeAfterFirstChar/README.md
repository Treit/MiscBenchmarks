# Base64 decoding when the input string has some prefix that need to be skipped.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Count | Mean        | Error       | StdDev      | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|--------------------------------------- |------ |------------:|------------:|------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConvertFromBase64WtihSubstring**         | **100**   |    **369.6 μs** |     **2.95 μs** |     **2.76 μs** |  **1.17** |    **0.01** |   **26.8555** |   **11.7188** |         **-** |   **441.98 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | 100   |    314.6 μs |     2.36 μs |     2.21 μs |  1.00 |    0.01 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | 100   |    323.8 μs |     2.39 μs |     2.12 μs |  1.03 |    0.01 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
|                                        |       |             |             |             |       |         |           |           |           |             |             |
| **ConvertFromBase64WtihSubstring**         | **10000** | **82,225.1 μs** | **1,575.80 μs** | **2,841.49 μs** |  **1.14** |    **0.05** | **3333.3333** | **3000.0000** | **1000.0000** | **44241.82 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | 10000 | 71,959.4 μs | 1,417.49 μs | 1,575.54 μs |  1.00 |    0.03 | 2375.0000 | 2250.0000 |  750.0000 | 28772.87 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | 10000 | 72,587.2 μs | 1,398.05 μs | 1,307.74 μs |  1.01 |    0.03 | 2375.0000 | 2250.0000 |  750.0000 | 28772.58 KB |        1.00 |
