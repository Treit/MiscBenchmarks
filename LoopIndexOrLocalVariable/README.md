# Loop using a variable vs index.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|            Method |   Count |           Mean |         Error |        StdDev | Ratio | RatioSD |
|------------------ |-------- |---------------:|--------------:|--------------:|------:|--------:|
|    **LoopUsingIndex** |      **10** |       **9.458 ns** |     **0.2077 ns** |     **0.1943 ns** |  **1.31** |    **0.05** |
| LoopUsingVariable |      10 |       7.220 ns |     0.1752 ns |     0.1874 ns |  1.00 |    0.00 |
|                   |         |                |               |               |       |         |
|    **LoopUsingIndex** |     **100** |      **98.425 ns** |     **0.0929 ns** |     **0.0776 ns** |  **1.44** |    **0.01** |
| LoopUsingVariable |     100 |      68.170 ns |     0.3122 ns |     0.2607 ns |  1.00 |    0.00 |
|                   |         |                |               |               |       |         |
|    **LoopUsingIndex** |    **1000** |     **935.282 ns** |     **1.8370 ns** |     **1.5340 ns** |  **1.50** |    **0.00** |
| LoopUsingVariable |    1000 |     625.445 ns |     0.2851 ns |     0.2381 ns |  1.00 |    0.00 |
|                   |         |                |               |               |       |         |
|    **LoopUsingIndex** |  **100000** |  **93,050.369 ns** |    **44.5377 ns** |    **34.7721 ns** |  **1.49** |    **0.00** |
| LoopUsingVariable |  100000 |  62,377.509 ns |    78.1268 ns |    69.2573 ns |  1.00 |    0.00 |
|                   |         |                |               |               |       |         |
|    **LoopUsingIndex** | **1000000** | **933,861.613 ns** |   **615.0835 ns** |   **480.2168 ns** |  **1.49** |    **0.01** |
| LoopUsingVariable | 1000000 | 625,510.404 ns | 3,576.7972 ns | 2,986.7876 ns |  1.00 |    0.00 |
