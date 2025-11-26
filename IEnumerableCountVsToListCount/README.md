# Calling ToList() to access the Count property vs. just calling Count()




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Count  | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **IEnumerableCount** | **10**     |      **15.44 ns** |      **0.165 ns** |      **0.154 ns** |      **15.49 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |         **-** |          **NA** |
| ToListCount      | 10     |      62.52 ns |      0.745 ns |      0.660 ns |      62.54 ns |  4.05 |    0.06 |   0.0129 |        - |        - |     216 B |          NA |
|                  |        |               |               |               |               |       |         |          |          |          |           |             |
| **IEnumerableCount** | **1000**   |   **1,075.49 ns** |      **7.934 ns** |      **7.033 ns** |   **1,078.14 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |         **-** |          **NA** |
| ToListCount      | 1000   |   3,733.26 ns |     18.412 ns |     17.223 ns |   3,735.19 ns |  3.47 |    0.03 |   0.5035 |        - |        - |    8424 B |          NA |
|                  |        |               |               |               |               |       |         |          |          |          |           |             |
| **IEnumerableCount** | **100000** | **106,284.76 ns** |    **325.320 ns** |    **288.388 ns** | **106,360.63 ns** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |         **-** |          **NA** |
| ToListCount      | 100000 | 623,228.45 ns | 16,024.066 ns | 47,247.324 ns | 641,046.58 ns |  5.86 |    0.44 | 285.1563 | 285.1563 | 285.1563 | 1049072 B |          NA |
