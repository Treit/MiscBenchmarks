# Calling ToList() to access the Count property vs. just calling Count()


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|           Method |  Count |          Mean |         Error |        StdDev |        Median | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|----------------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **IEnumerableCount** |     **10** |      **30.07 ns** |      **0.214 ns** |      **0.200 ns** |      **30.03 ns** |  **1.00** |    **0.00** |   **0.0024** |        **-** |        **-** |      **40 B** |        **1.00** |
|      ToListCount |     10 |      79.76 ns |      0.488 ns |      0.433 ns |      79.70 ns |  2.65 |    0.02 |   0.0153 |        - |        - |     256 B |        6.40 |
|                  |        |               |               |               |               |       |         |          |          |          |           |             |
| **IEnumerableCount** |   **1000** |   **1,268.64 ns** |      **1.041 ns** |      **0.923 ns** |   **1,268.34 ns** |  **1.00** |    **0.00** |   **0.0019** |        **-** |        **-** |      **40 B** |        **1.00** |
|      ToListCount |   1000 |   2,578.78 ns |     26.096 ns |     24.410 ns |   2,572.82 ns |  2.03 |    0.02 |   0.5035 |   0.0038 |        - |    8464 B |      211.60 |
|                  |        |               |               |               |               |       |         |          |          |          |           |             |
| **IEnumerableCount** | **100000** | **123,990.81 ns** |    **209.776 ns** |    **175.172 ns** | **123,930.71 ns** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
|      ToListCount | 100000 | 562,195.21 ns | 14,697.228 ns | 43,335.108 ns | 534,298.29 ns |  4.62 |    0.40 | 285.1563 | 285.1563 | 285.1563 | 1049112 B |   26,227.80 |
