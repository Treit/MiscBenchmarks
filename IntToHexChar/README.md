# Looking up hex characters




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| **GetHexCharWithIndexLookup** | **3**     |     **6.499 ns** |  **0.1885 ns** |  **0.2451 ns** |  **1.00** |    **0.05** | **0.0019** |      **32 B** |        **1.00** |
| GetHexCharWithMath        | 3     |     7.049 ns |  0.1076 ns |  0.0954 ns |  1.09 |    0.04 | 0.0019 |      32 B |        1.00 |
|                           |       |              |            |            |       |         |        |           |             |
| **GetHexCharWithIndexLookup** | **50**    |    **53.951 ns** |  **0.7429 ns** |  **0.5800 ns** |  **1.00** |    **0.01** | **0.0076** |     **128 B** |        **1.00** |
| GetHexCharWithMath        | 50    |    45.484 ns |  0.5300 ns |  0.4426 ns |  0.84 |    0.01 | 0.0076 |     128 B |        1.00 |
|                           |       |              |            |            |       |         |        |           |             |
| **GetHexCharWithIndexLookup** | **1000**  | **1,019.728 ns** |  **9.3014 ns** |  **8.7005 ns** |  **1.00** |    **0.01** | **0.1202** |    **2024 B** |        **1.00** |
| GetHexCharWithMath        | 1000  | 1,134.216 ns | 13.1168 ns | 12.2694 ns |  1.11 |    0.01 | 0.1202 |    2024 B |        1.00 |
