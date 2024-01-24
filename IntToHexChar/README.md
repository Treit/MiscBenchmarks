# Looking up hex characters


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                    Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-------------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|----------:|------------:|
| **GetHexCharWithIndexLookup** |     **3** |     **6.786 ns** |  **0.1323 ns** |  **0.1173 ns** |     **6.747 ns** |  **1.00** |    **0.00** | **0.0019** |      **32 B** |        **1.00** |
|        GetHexCharWithMath |     3 |     6.665 ns |  0.1429 ns |  0.1266 ns |     6.643 ns |  0.98 |    0.02 | 0.0019 |      32 B |        1.00 |
|                           |       |              |            |            |              |       |         |        |           |             |
| **GetHexCharWithIndexLookup** |    **50** |    **57.230 ns** |  **1.2051 ns** |  **3.3394 ns** |    **56.460 ns** |  **1.00** |    **0.00** | **0.0076** |     **128 B** |        **1.00** |
|        GetHexCharWithMath |    50 |    51.927 ns |  0.2394 ns |  0.2239 ns |    51.948 ns |  0.89 |    0.05 | 0.0076 |     128 B |        1.00 |
|                           |       |              |            |            |              |       |         |        |           |             |
| **GetHexCharWithIndexLookup** |  **1000** | **1,021.384 ns** |  **7.2545 ns** |  **6.7858 ns** | **1,021.210 ns** |  **1.00** |    **0.00** | **0.1202** |    **2024 B** |        **1.00** |
|        GetHexCharWithMath |  1000 | 1,060.897 ns | 21.2161 ns | 37.7115 ns | 1,042.202 ns |  1.05 |    0.04 | 0.1202 |    2024 B |        1.00 |
