# Swapping array elements.
``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25314.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|                Method |  Count |          Mean |         Error |        StdDev |        Median |    Gen0 |    Gen1 |    Gen2 | Allocated |
|---------------------- |------- |--------------:|--------------:|--------------:|--------------:|--------:|--------:|--------:|----------:|
|  **SwapWithTempVariable** |     **10** |      **27.14 ns** |      **1.135 ns** |      **3.293 ns** |      **26.23 ns** |  **0.0111** |       **-** |       **-** |      **48 B** |
| SwapWithLocalFunction |     10 |      28.81 ns |      0.845 ns |      2.478 ns |      28.22 ns |  0.0111 |       - |       - |      48 B |
|         SwapWithTuple |     10 |      28.45 ns |      0.904 ns |      2.592 ns |      28.35 ns |  0.0111 |       - |       - |      48 B |
|  **SwapWithTempVariable** | **100000** | **193,731.58 ns** |  **7,831.690 ns** | **23,091.916 ns** | **197,024.41 ns** | **62.2559** | **62.2559** | **62.2559** |  **200045 B** |
| SwapWithLocalFunction | 100000 | 233,944.89 ns | 11,464.820 ns | 33,804.281 ns | 225,893.86 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
|         SwapWithTuple | 100000 | 188,080.64 ns |  4,066.303 ns | 11,666.984 ns | 188,518.48 ns | 62.2559 | 62.2559 | 62.2559 |  200045 B |
