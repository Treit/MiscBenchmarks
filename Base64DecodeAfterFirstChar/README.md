# Base64 decoding when the input string has some prefix that need to be skipped.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Job       | Runtime   | Count | Mean        | Error       | StdDev      | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|--------------------------------------- |---------- |---------- |------ |------------:|------------:|------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConvertFromBase64WtihSubstring**         | **.NET 10.0** | **.NET 10.0** | **100**   |    **366.5 μs** |     **3.77 μs** |     **3.34 μs** |  **1.13** |    **0.01** |   **26.8555** |   **11.7188** |         **-** |   **441.98 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | .NET 10.0 | .NET 10.0 | 100   |    323.7 μs |     2.70 μs |     2.39 μs |  1.00 |    0.01 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | .NET 10.0 | .NET 10.0 | 100   |    318.7 μs |     2.71 μs |     2.11 μs |  0.98 |    0.01 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
|                                        |           |           |       |             |             |             |       |         |           |           |           |             |             |
| ConvertFromBase64WtihSubstring         | .NET 9.0  | .NET 9.0  | 100   |    366.8 μs |     3.04 μs |     2.84 μs |  1.13 |    0.02 |   26.8555 |   11.7188 |         - |   441.98 KB |        1.54 |
| ConvertTryFromBase64Chars              | .NET 9.0  | .NET 9.0  | 100   |    325.3 μs |     4.69 μs |     4.39 μs |  1.00 |    0.02 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | .NET 9.0  | .NET 9.0  | 100   |    346.2 μs |     4.92 μs |     4.60 μs |  1.06 |    0.02 |   17.5781 |    7.3242 |         - |    287.3 KB |        1.00 |
|                                        |           |           |       |             |             |             |       |         |           |           |           |             |             |
| **ConvertFromBase64WtihSubstring**         | **.NET 10.0** | **.NET 10.0** | **10000** | **85,935.4 μs** | **1,708.89 μs** | **3,490.80 μs** |  **1.18** |    **0.06** | **3333.3333** | **3000.0000** | **1000.0000** | **44241.92 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | .NET 10.0 | .NET 10.0 | 10000 | 72,784.4 μs | 1,435.79 μs | 2,192.60 μs |  1.00 |    0.04 | 2375.0000 | 2250.0000 |  750.0000 | 28772.62 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | .NET 10.0 | .NET 10.0 | 10000 | 72,305.0 μs | 1,443.65 μs | 1,604.62 μs |  0.99 |    0.04 | 2375.0000 | 2250.0000 |  750.0000 | 28772.54 KB |        1.00 |
|                                        |           |           |       |             |             |             |       |         |           |           |           |             |             |
| ConvertFromBase64WtihSubstring         | .NET 9.0  | .NET 9.0  | 10000 | 81,630.6 μs | 1,602.76 μs | 3,380.76 μs |  1.14 |    0.05 | 3333.3333 | 3000.0000 | 1000.0000 | 44241.92 KB |        1.54 |
| ConvertTryFromBase64Chars              | .NET 9.0  | .NET 9.0  | 10000 | 71,841.7 μs | 1,417.39 μs | 1,575.42 μs |  1.00 |    0.03 | 2375.0000 | 2250.0000 |  750.0000 | 28773.08 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | .NET 9.0  | .NET 9.0  | 10000 | 72,300.7 μs | 1,411.28 μs | 1,884.02 μs |  1.01 |    0.03 | 2375.0000 | 2250.0000 |  750.0000 | 28773.27 KB |        1.00 |
