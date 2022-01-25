# Indexing strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22538
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|                 Method | Count |          Mean |        Error |       StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------ |--------------:|-------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|    **FindIndexesInString** |    **10** |      **67.67 ns** |     **1.311 ns** |     **1.227 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|  FindIndexesInIntArray |    10 |      71.71 ns |     1.942 ns |     5.727 ns |  1.04 |    0.07 |     - |     - |     - |         - |
| FindIndexesInCharArray |    10 |      74.19 ns |     1.867 ns |     5.416 ns |  1.10 |    0.10 |     - |     - |     - |         - |
|                        |       |               |              |              |       |         |       |       |       |           |
|    **FindIndexesInString** |  **1000** |   **8,496.27 ns** |   **168.946 ns** |   **247.639 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|  FindIndexesInIntArray |  1000 |   8,656.83 ns |   173.065 ns |   430.991 ns |  1.00 |    0.06 |     - |     - |     - |         - |
| FindIndexesInCharArray |  1000 |   8,583.68 ns |   171.151 ns |   423.043 ns |  1.03 |    0.06 |     - |     - |     - |         - |
|                        |       |               |              |              |       |         |       |       |       |           |
|    **FindIndexesInString** | **10000** | **133,790.34 ns** | **2,672.906 ns** | **6,194.865 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|  FindIndexesInIntArray | 10000 | 134,091.13 ns | 2,664.436 ns | 5,561.670 ns |  1.00 |    0.07 |     - |     - |     - |         - |
| FindIndexesInCharArray | 10000 | 139,757.19 ns | 2,761.082 ns | 6,562.004 ns |  1.05 |    0.07 |     - |     - |     - |         - |
