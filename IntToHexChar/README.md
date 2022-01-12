# Looking up hex characters

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22518
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|                    Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
| **GetHexCharWithIndexLookup** |     **3** |     **8.246 ns** |  **0.2555 ns** |  **0.6775 ns** |  **1.00** |    **0.00** | **0.0074** |     **-** |     **-** |      **32 B** |
|        GetHexCharWithMath |     3 |     6.909 ns |  0.2271 ns |  0.5217 ns |  0.84 |    0.11 | 0.0074 |     - |     - |      32 B |
|                           |       |              |            |            |       |         |        |       |       |           |
| **GetHexCharWithIndexLookup** |    **50** |    **74.672 ns** |  **1.5733 ns** |  **4.3332 ns** |  **1.00** |    **0.00** | **0.0296** |     **-** |     **-** |     **128 B** |
|        GetHexCharWithMath |    50 |    64.722 ns |  1.3593 ns |  2.6190 ns |  0.85 |    0.05 | 0.0296 |     - |     - |     128 B |
|                           |       |              |            |            |       |         |        |       |       |           |
| **GetHexCharWithIndexLookup** |  **1000** | **1,357.250 ns** | **27.0961 ns** | **54.1138 ns** |  **1.00** |    **0.00** | **0.4692** |     **-** |     **-** |    **2024 B** |
|        GetHexCharWithMath |  1000 | 2,779.603 ns | 54.9735 ns | 87.1937 ns |  2.06 |    0.11 | 0.4692 |     - |     - |    2024 B |
