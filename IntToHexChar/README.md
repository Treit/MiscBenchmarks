# Looking up hex characters





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |---------- |---------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **GetHexCharWithIndexLookup** | **.NET 10.0** | **.NET 10.0** | **3**     |     **6.140 ns** |  **0.0965 ns** |  **0.0856 ns** |  **1.00** |    **0.02** | **0.0019** |      **32 B** |        **1.00** |
| GetHexCharWithMath        | .NET 10.0 | .NET 10.0 | 3     |     7.025 ns |  0.0572 ns |  0.0477 ns |  1.14 |    0.02 | 0.0019 |      32 B |        1.00 |
|                           |           |           |       |              |            |            |       |         |        |           |             |
| GetHexCharWithIndexLookup | .NET 9.0  | .NET 9.0  | 3     |     6.223 ns |  0.1134 ns |  0.1061 ns |  1.00 |    0.02 | 0.0019 |      32 B |        1.00 |
| GetHexCharWithMath        | .NET 9.0  | .NET 9.0  | 3     |     7.053 ns |  0.1510 ns |  0.1412 ns |  1.13 |    0.03 | 0.0019 |      32 B |        1.00 |
|                           |           |           |       |              |            |            |       |         |        |           |             |
| **GetHexCharWithIndexLookup** | **.NET 10.0** | **.NET 10.0** | **50**    |    **53.635 ns** |  **0.4037 ns** |  **0.3579 ns** |  **1.00** |    **0.01** | **0.0076** |     **128 B** |        **1.00** |
| GetHexCharWithMath        | .NET 10.0 | .NET 10.0 | 50    |    46.497 ns |  0.9847 ns |  1.5038 ns |  0.87 |    0.03 | 0.0076 |     128 B |        1.00 |
|                           |           |           |       |              |            |            |       |         |        |           |             |
| GetHexCharWithIndexLookup | .NET 9.0  | .NET 9.0  | 50    |    54.273 ns |  0.7399 ns |  0.6178 ns |  1.00 |    0.02 | 0.0076 |     128 B |        1.00 |
| GetHexCharWithMath        | .NET 9.0  | .NET 9.0  | 50    |    46.175 ns |  0.9759 ns |  0.9128 ns |  0.85 |    0.02 | 0.0076 |     128 B |        1.00 |
|                           |           |           |       |              |            |            |       |         |        |           |             |
| **GetHexCharWithIndexLookup** | **.NET 10.0** | **.NET 10.0** | **1000**  | **1,028.976 ns** |  **9.7838 ns** |  **9.1518 ns** |  **1.00** |    **0.01** | **0.1202** |    **2024 B** |        **1.00** |
| GetHexCharWithMath        | .NET 10.0 | .NET 10.0 | 1000  | 1,138.164 ns | 20.1851 ns | 18.8812 ns |  1.11 |    0.02 | 0.1202 |    2024 B |        1.00 |
|                           |           |           |       |              |            |            |       |         |        |           |             |
| GetHexCharWithIndexLookup | .NET 9.0  | .NET 9.0  | 1000  | 1,026.007 ns | 11.8846 ns | 11.1169 ns |  1.00 |    0.01 | 0.1202 |    2024 B |        1.00 |
| GetHexCharWithMath        | .NET 9.0  | .NET 9.0  | 1000  | 1,145.161 ns | 16.7408 ns | 15.6593 ns |  1.12 |    0.02 | 0.1202 |    2024 B |        1.00 |
