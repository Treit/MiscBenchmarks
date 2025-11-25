# Looking up hex characters



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count | Mean         | Error      | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------- |------ |-------------:|-----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **GetHexCharWithIndexLookup** | **3**     |     **6.292 ns** |  **0.1520 ns** | **0.1422 ns** |  **1.00** |    **0.03** | **0.0019** |      **32 B** |        **1.00** |
| GetHexCharWithMath        | 3     |     7.279 ns |  0.2068 ns | 0.2761 ns |  1.16 |    0.05 | 0.0019 |      32 B |        1.00 |
|                           |       |              |            |           |       |         |        |           |             |
| **GetHexCharWithIndexLookup** | **50**    |    **53.537 ns** |  **0.6076 ns** | **0.5387 ns** |  **1.00** |    **0.01** | **0.0076** |     **128 B** |        **1.00** |
| GetHexCharWithMath        | 50    |    45.175 ns |  0.3195 ns | 0.2668 ns |  0.84 |    0.01 | 0.0076 |     128 B |        1.00 |
|                           |       |              |            |           |       |         |        |           |             |
| **GetHexCharWithIndexLookup** | **1000**  | **1,013.743 ns** | **10.5777 ns** | **9.8944 ns** |  **1.00** |    **0.01** | **0.1202** |    **2024 B** |        **1.00** |
| GetHexCharWithMath        | 1000  | 1,124.870 ns |  9.5641 ns | 8.9463 ns |  1.11 |    0.01 | 0.1202 |    2024 B |        1.00 |
