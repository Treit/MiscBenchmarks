# Redundant ToString calls






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Job       | Runtime   | Count  | Mean            | Error         | StdDev         | Median          | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------- |---------- |---------- |------- |----------------:|--------------:|---------------:|----------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **ConcatAllStringsDirectly**              | **.NET 10.0** | **.NET 10.0** | **1**      |        **17.51 ns** |      **0.223 ns** |       **0.208 ns** |        **17.46 ns** |  **1.00** |    **0.02** |   **0.0076** |        **-** |        **-** |     **128 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | .NET 10.0 | .NET 10.0 | 1      |        17.50 ns |      0.265 ns |       0.248 ns |        17.50 ns |  1.00 |    0.02 |   0.0076 |        - |        - |     128 B |        1.00 |
|                                       |           |           |        |                 |               |                |                 |       |         |          |          |          |           |             |
| ConcatAllStringsDirectly              | .NET 9.0  | .NET 9.0  | 1      |        17.53 ns |      0.177 ns |       0.165 ns |        17.49 ns |  1.00 |    0.01 |   0.0076 |        - |        - |     128 B |        1.00 |
| ConcatAllStringsWithRedundantToString | .NET 9.0  | .NET 9.0  | 1      |        17.67 ns |      0.128 ns |       0.120 ns |        17.68 ns |  1.01 |    0.01 |   0.0076 |        - |        - |     128 B |        1.00 |
|                                       |           |           |        |                 |               |                |                 |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **.NET 10.0** | **.NET 10.0** | **100**    |       **438.15 ns** |      **1.927 ns** |       **1.609 ns** |       **437.82 ns** |  **1.00** |    **0.00** |   **0.0763** |        **-** |        **-** |    **1280 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | .NET 10.0 | .NET 10.0 | 100    |       434.65 ns |      3.324 ns |       2.947 ns |       434.85 ns |  0.99 |    0.01 |   0.0763 |        - |        - |    1280 B |        1.00 |
|                                       |           |           |        |                 |               |                |                 |       |         |          |          |          |           |             |
| ConcatAllStringsDirectly              | .NET 9.0  | .NET 9.0  | 100    |       426.99 ns |      2.346 ns |       1.959 ns |       426.79 ns |  1.00 |    0.01 |   0.0763 |        - |        - |    1280 B |        1.00 |
| ConcatAllStringsWithRedundantToString | .NET 9.0  | .NET 9.0  | 100    |       433.42 ns |      4.748 ns |       4.441 ns |       433.34 ns |  1.02 |    0.01 |   0.0763 |        - |        - |    1280 B |        1.00 |
|                                       |           |           |        |                 |               |                |                 |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **.NET 10.0** | **.NET 10.0** | **100000** | **2,065,376.15 ns** | **41,162.508 ns** | **116,771.194 ns** | **2,060,775.39 ns** |  **1.00** |    **0.08** | **230.4688** | **191.4063** | **171.8750** | **1976693 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | .NET 10.0 | .NET 10.0 | 100000 | 2,071,667.01 ns | 41,078.109 ns | 111,057.064 ns | 2,107,119.53 ns |  1.01 |    0.08 | 230.4688 | 195.3125 | 171.8750 | 1976660 B |        1.00 |
|                                       |           |           |        |                 |               |                |                 |       |         |          |          |          |           |             |
| ConcatAllStringsDirectly              | .NET 9.0  | .NET 9.0  | 100000 | 2,056,137.01 ns | 45,525.559 ns | 134,233.147 ns | 2,058,447.85 ns |  1.00 |    0.09 | 230.4688 | 195.3125 | 171.8750 | 1976692 B |        1.00 |
| ConcatAllStringsWithRedundantToString | .NET 9.0  | .NET 9.0  | 100000 | 2,084,319.86 ns | 41,375.525 ns |  78,721.243 ns | 2,072,506.84 ns |  1.02 |    0.08 | 228.5156 | 193.3594 | 169.9219 | 1976688 B |        1.00 |
