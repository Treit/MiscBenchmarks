# Linq 'All' vs 'Except' to find if one list is a subset of another


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                      Method | Count |             Mean |           Error |          StdDev |           Median |  Ratio | RatioSD |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
|---------------------------- |------ |-----------------:|----------------:|----------------:|-----------------:|-------:|--------:|--------:|--------:|--------:|----------:|------------:|
|    **VerifySubsetUsingLinqAll** |    **10** |         **834.0 ns** |         **9.32 ns** |         **8.72 ns** |         **833.1 ns** |   **1.92** |    **0.02** |  **0.0896** |       **-** |       **-** |    **1512 B** |        **2.95** |
| VerifySubsetUsingLinqExcept |    10 |         433.9 ns |         1.96 ns |         1.83 ns |         434.1 ns |   1.00 |    0.00 |  0.0305 |       - |       - |     512 B |        1.00 |
|                             |       |                  |                 |                 |                  |        |         |         |         |         |           |             |
|    **VerifySubsetUsingLinqAll** |  **1000** |   **4,342,628.6 ns** |    **86,231.31 ns** |    **80,660.82 ns** |   **4,329,964.8 ns** | **124.64** |    **2.30** |       **-** |       **-** |       **-** |  **128235 B** |        **5.74** |
| VerifySubsetUsingLinqExcept |  1000 |      34,841.6 ns |       169.95 ns |       158.97 ns |      34,894.6 ns |   1.00 |    0.00 |  1.2817 |  0.0610 |       - |   22352 B |        1.00 |
|                             |       |                  |                 |                 |                  |        |         |         |         |         |           |             |
|    **VerifySubsetUsingLinqAll** | **10000** | **410,106,842.9 ns** | **7,955,927.62 ns** | **7,052,722.61 ns** | **412,199,500.0 ns** | **730.60** |   **29.87** |       **-** |       **-** |       **-** | **1280632 B** |        **6.33** |
| VerifySubsetUsingLinqExcept | 10000 |     562,835.6 ns |    11,247.72 ns |    18,162.97 ns |     551,579.7 ns |   1.00 |    0.00 | 49.8047 | 49.8047 | 49.8047 |  202369 B |        1.00 |
