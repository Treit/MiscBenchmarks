# Finding min and max on different numeric types.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25125
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.300
  [Host]     : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET Core 6.0.5 (CoreCLR 6.0.522.21309, CoreFX 6.0.522.21309), X64 RyuJIT


```
|           Method |  Count |          Mean |        Error |       StdDev | Ratio | RatioSD |
|----------------- |------- |--------------:|-------------:|-------------:|------:|--------:|
|    **MinAndMaxInts** |     **10** |      **14.99 ns** |     **0.333 ns** |     **0.672 ns** |  **1.00** |    **0.00** |
|   MinAndMaxLongs |     10 |      19.41 ns |     0.424 ns |     1.063 ns |  1.29 |    0.09 |
|  MinAndMaxFloats |     10 |      20.42 ns |     0.436 ns |     1.052 ns |  1.36 |    0.10 |
| MinAndMaxDoubles |     10 |      18.33 ns |     0.395 ns |     0.626 ns |  1.22 |    0.07 |
|                  |        |               |              |              |       |         |
|    **MinAndMaxInts** |    **100** |     **103.44 ns** |     **2.068 ns** |     **3.621 ns** |  **1.00** |    **0.00** |
|   MinAndMaxLongs |    100 |     200.76 ns |     4.040 ns |     7.181 ns |  1.94 |    0.10 |
|  MinAndMaxFloats |    100 |     205.45 ns |     4.117 ns |     7.834 ns |  2.00 |    0.09 |
| MinAndMaxDoubles |    100 |     195.42 ns |     3.725 ns |     6.996 ns |  1.89 |    0.11 |
|                  |        |               |              |              |       |         |
|    **MinAndMaxInts** | **100000** |  **98,696.33 ns** | **1,892.180 ns** | **4,641.550 ns** |  **1.00** |    **0.00** |
|   MinAndMaxLongs | 100000 | 190,897.94 ns | 3,743.337 ns | 6,844.904 ns |  1.95 |    0.13 |
|  MinAndMaxFloats | 100000 | 219,345.60 ns | 4,340.229 ns | 8,767.476 ns |  2.23 |    0.14 |
| MinAndMaxDoubles | 100000 | 188,017.90 ns | 3,713.707 ns | 5,326.087 ns |  1.92 |    0.11 |
