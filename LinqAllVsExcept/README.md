# Linq 'All' vs 'Except' to find if one list is a subset of another

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25897.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2


```
|                      Method | Count |             Mean |            Error |           StdDev |  Ratio | RatioSD |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
|---------------------------- |------ |-----------------:|-----------------:|-----------------:|-------:|--------:|--------:|--------:|--------:|----------:|------------:|
|    **VerifySubsetUsingLinqAll** |    **10** |       **1,590.9 ns** |         **35.77 ns** |        **102.06 ns** |   **2.19** |    **0.15** |  **0.3490** |       **-** |       **-** |    **1512 B** |        **2.95** |
| VerifySubsetUsingLinqExcept |    10 |         756.3 ns |         14.96 ns |         21.46 ns |   1.00 |    0.00 |  0.1183 |       - |       - |     512 B |        1.00 |
|                             |       |                  |                  |                  |        |         |         |         |         |           |             |
|    **VerifySubsetUsingLinqAll** |  **1000** |   **6,949,636.8 ns** |    **145,638.62 ns** |    **422,524.04 ns** | **114.94** |    **8.84** | **23.4375** |       **-** |       **-** |  **128236 B** |        **5.74** |
| VerifySubsetUsingLinqExcept |  1000 |      60,656.3 ns |      1,233.56 ns |      3,559.11 ns |   1.00 |    0.00 |  5.1270 |  0.2441 |       - |   22352 B |        1.00 |
|                             |       |                  |                  |                  |        |         |         |         |         |           |             |
|    **VerifySubsetUsingLinqAll** | **10000** | **780,845,102.2 ns** | **29,747,466.08 ns** | **83,903,255.87 ns** | **952.68** |  **108.55** |       **-** |       **-** |       **-** | **1280776 B** |        **6.33** |
| VerifySubsetUsingLinqExcept | 10000 |     821,155.7 ns |     18,060.12 ns |     52,107.57 ns |   1.00 |    0.00 | 49.8047 | 49.8047 | 49.8047 |  202369 B |        1.00 |
