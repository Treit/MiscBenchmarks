# Redundant ToString calls



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27768.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Count  | Mean            | Error         | StdDev        | Median          | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------------- |------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **ConcatAllStringsDirectly**              | **1**      |        **23.56 ns** |      **0.839 ns** |      **2.406 ns** |        **22.50 ns** |  **1.00** |    **0.00** |   **0.0297** |        **-** |        **-** |     **128 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 1      |        24.55 ns |      0.319 ns |      0.298 ns |        24.45 ns |  0.99 |    0.11 |   0.0296 |        - |        - |     128 B |        1.00 |
|                                       |        |                 |               |               |                 |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100**    |       **485.85 ns** |      **8.212 ns** |      **9.128 ns** |       **483.77 ns** |  **1.00** |    **0.00** |   **0.2966** |        **-** |        **-** |    **1280 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100    |       473.61 ns |      9.424 ns |     20.686 ns |       465.30 ns |  1.00 |    0.05 |   0.2966 |        - |        - |    1280 B |        1.00 |
|                                       |        |                 |               |               |                 |       |         |          |          |          |           |             |
| **ConcatAllStringsDirectly**              | **100000** | **2,543,323.42 ns** | **48,805.501 ns** | **68,418.496 ns** | **2,542,031.25 ns** |  **1.00** |    **0.00** | **343.7500** | **296.8750** | **171.8750** | **1976727 B** |        **1.00** |
| ConcatAllStringsWithRedundantToString | 100000 | 2,553,661.85 ns | 50,103.939 ns | 59,645.175 ns | 2,543,219.92 ns |  1.00 |    0.04 | 343.7500 | 292.9688 | 171.8750 | 1976727 B |        1.00 |
