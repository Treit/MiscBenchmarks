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
| **ConvertFromBase64WtihSubstring**         | **100**   |    **356.6 μs** |     **3.98 μs** |     **3.53 μs** |  **1.09** |    **0.01** |   **26.8555** |   **11.7188** |         **-** |   **441.98 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | 100   |    326.9 μs |     3.03 μs |     2.83 μs |  1.00 |    0.01 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | 100   |    322.0 μs |     3.07 μs |     2.73 μs |  0.99 |    0.01 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
|                                        |       |             |             |             |       |         |           |           |           |             |             |
| **ConvertFromBase64WtihSubstring**         | **10000** | **81,121.3 μs** | **1,604.64 μs** | **3,750.79 μs** |  **1.10** |    **0.05** | **3333.3333** | **3000.0000** | **1000.0000** |  **44241.9 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | 10000 | 73,683.3 μs | 1,245.99 μs | 1,104.54 μs |  1.00 |    0.02 | 2375.0000 | 2250.0000 |  750.0000 | 28772.56 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | 10000 | 73,766.5 μs | 1,437.52 μs | 2,195.24 μs |  1.00 |    0.03 | 2375.0000 | 2250.0000 |  750.0000 | 28772.61 KB |        1.00 |
