# Base64 decoding when the input string has some prefix that need to be skipped.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26096.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                 | Count | Mean         | Error       | StdDev       | Median       | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated   | Alloc Ratio |
|--------------------------------------- |------ |-------------:|------------:|-------------:|-------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **ConvertFromBase64WtihSubstring**         | **100**   |     **657.7 μs** |    **11.50 μs** |     **27.33 μs** |     **651.3 μs** |  **1.09** |    **0.09** |   **95.7031** |   **30.2734** |         **-** |   **441.99 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | 100   |     603.2 μs |    16.36 μs |     45.86 μs |     585.5 μs |  1.00 |    0.00 |   66.4063 |   21.4844 |         - |    287.3 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | 100   |     579.5 μs |    11.49 μs |     23.72 μs |     573.9 μs |  0.95 |    0.08 |   66.4063 |   21.4844 |         - |    287.3 KB |        1.00 |
|                                        |       |              |             |              |              |       |         |           |           |           |             |             |
| **ConvertFromBase64WtihSubstring**         | **10000** | **150,420.1 μs** | **5,782.29 μs** | **16,683.22 μs** | **144,601.4 μs** |  **1.14** |    **0.17** | **8000.0000** | **3500.0000** | **1250.0000** | **44243.52 KB** |        **1.54** |
| ConvertTryFromBase64Chars              | 10000 | 131,563.0 μs | 4,385.57 μs | 12,152.39 μs | 129,072.0 μs |  1.00 |    0.00 | 5400.0000 | 3000.0000 | 1000.0000 |  28775.4 KB |        1.00 |
| ConvertTryFromBase64CharsWithArrayPool | 10000 | 131,205.3 μs | 8,375.09 μs | 24,694.14 μs | 135,668.6 μs |  0.98 |    0.20 | 4000.0000 | 2000.0000 | 1000.0000 | 28772.65 KB |        1.00 |
