# Redundant ToString calls




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Count  | Mean            | Error         | StdDev         | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------- |------- |----------------:|--------------:|---------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **ConcatAllStringsDirectly**              | **1**      |        **17.99 ns** |      **0.288 ns** |       **0.269 ns** |  **1.00** |    **0.02** |   **0.0076** |        **-** |        **-** |     **128 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 1      |        20.57 ns |      0.454 ns |       0.574 ns |  1.14 |    0.04 |   0.0076 |        - |        - |     128 B |        1.00 |
|                                       |        |                 |               |                |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100**    |       **442.62 ns** |      **1.768 ns** |       **1.568 ns** |  **1.00** |    **0.00** |   **0.0763** |        **-** |        **-** |    **1280 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100    |       437.10 ns |      3.564 ns |       3.334 ns |  0.99 |    0.01 |   0.0763 |        - |        - |    1280 B |        1.00 |
|                                       |        |                 |               |                |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100000** | **1,637,590.65 ns** | **41,462.429 ns** | **122,252.917 ns** |  **1.01** |    **0.11** | **228.5156** | **195.3125** | **169.9219** | **1976381 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100000 | 1,623,438.95 ns | 32,255.762 ns |  92,027.511 ns |  1.00 |    0.09 | 228.5156 | 197.2656 | 169.9219 | 1976343 B |        1.00 |
