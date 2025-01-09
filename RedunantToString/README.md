# Redundant ToString calls


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27768.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Count  | Mean            | Error         | StdDev        | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------- |------- |----------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **ConcatAllStringsDirectly**              | **1**      |        **24.32 ns** |      **0.401 ns** |      **0.356 ns** |  **1.00** |    **0.00** |   **0.0296** |        **-** |        **-** |     **128 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 1      |        24.65 ns |      0.270 ns |      0.266 ns |  1.01 |    0.02 |   0.0297 |        - |        - |     128 B |        1.00 |
|                                       |        |                 |               |               |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100**    |       **484.60 ns** |      **7.125 ns** |      **6.664 ns** |  **1.00** |    **0.00** |   **0.2966** |        **-** |        **-** |    **1280 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100    |       494.46 ns |      6.594 ns |      5.845 ns |  1.02 |    0.02 |   0.2966 |        - |        - |    1280 B |        1.00 |
|                                       |        |                 |               |               |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100000** | **2,581,158.01 ns** | **49,786.283 ns** | **64,736.230 ns** |  **1.00** |    **0.00** | **343.7500** | **296.8750** | **171.8750** | **1976728 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100000 | 2,477,163.53 ns | 48,893.629 ns | 76,121.490 ns |  0.96 |    0.04 | 343.7500 | 296.8750 | 171.8750 | 1976727 B |        1.00 |
