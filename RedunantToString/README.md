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
| **ConcatAllStringsDirectly**              | **1**      |        **18.26 ns** |      **0.259 ns** |       **0.242 ns** |  **1.00** |    **0.02** |   **0.0076** |        **-** |        **-** |     **128 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 1      |        18.38 ns |      0.412 ns |       0.405 ns |  1.01 |    0.03 |   0.0076 |        - |        - |     128 B |        1.00 |
|                                       |        |                 |               |                |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100**    |       **447.57 ns** |      **2.814 ns** |       **2.350 ns** |  **1.00** |    **0.01** |   **0.0763** |        **-** |        **-** |    **1280 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100    |       444.79 ns |      3.923 ns |       3.478 ns |  0.99 |    0.01 |   0.0763 |        - |        - |    1280 B |        1.00 |
|                                       |        |                 |               |                |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100000** | **2,040,614.97 ns** | **42,731.649 ns** | **125,995.240 ns** |  **1.00** |    **0.09** | **230.4688** | **195.3125** | **171.8750** | **1976661 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100000 | 2,086,610.67 ns | 41,789.606 ns | 122,561.689 ns |  1.03 |    0.09 | 226.5625 | 191.4063 | 167.9688 | 1976692 B |        1.00 |
