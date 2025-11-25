# Calling ToList() to access the Count property vs. just calling Count()



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Count  | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|----------------- |------- |--------------:|-------------:|-------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **IEnumerableCount** | **10**     |      **15.78 ns** |     **0.170 ns** |     **0.159 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |         **-** |          **NA** |
| ToListCount      | 10     |      60.97 ns |     0.673 ns |     0.597 ns |  3.86 |    0.05 |   0.0129 |        - |        - |     216 B |          NA |
|                  |        |               |              |              |       |         |          |          |          |           |             |
| **IEnumerableCount** | **1000**   |   **1,073.17 ns** |     **6.652 ns** |     **6.222 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |         **-** |          **NA** |
| ToListCount      | 1000   |   2,533.01 ns |    33.684 ns |    31.508 ns |  2.36 |    0.03 |   0.5035 |        - |        - |    8424 B |          NA |
|                  |        |               |              |              |       |         |          |          |          |           |             |
| **IEnumerableCount** | **100000** | **123,908.61 ns** |   **943.980 ns** |   **883.000 ns** |  **1.00** |    **0.01** |        **-** |        **-** |        **-** |         **-** |          **NA** |
| ToListCount      | 100000 | 654,199.76 ns | 3,847.051 ns | 3,598.534 ns |  5.28 |    0.05 | 285.1563 | 285.1563 | 285.1563 | 1049072 B |          NA |
