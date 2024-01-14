# Finding min and max on different numeric types.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|           Method |  Count |           Mean |       Error |      StdDev | Ratio | RatioSD |
|----------------- |------- |---------------:|------------:|------------:|------:|--------:|
|    **MinAndMaxInts** |     **10** |      **10.650 ns** |   **0.0768 ns** |   **0.0719 ns** |  **1.00** |    **0.00** |
|   MinAndMaxLongs |     10 |       9.190 ns |   0.0110 ns |   0.0092 ns |  0.86 |    0.01 |
|  MinAndMaxFloats |     10 |      13.873 ns |   0.1009 ns |   0.0843 ns |  1.30 |    0.01 |
| MinAndMaxDoubles |     10 |      12.186 ns |   0.0431 ns |   0.0403 ns |  1.14 |    0.01 |
|                  |        |                |             |             |       |         |
|    **MinAndMaxInts** |    **100** |      **84.520 ns** |   **0.5390 ns** |   **0.5041 ns** |  **1.00** |    **0.00** |
|   MinAndMaxLongs |    100 |      80.220 ns |   1.1447 ns |   1.0707 ns |  0.95 |    0.01 |
|  MinAndMaxFloats |    100 |     131.893 ns |   1.0134 ns |   0.9479 ns |  1.56 |    0.01 |
| MinAndMaxDoubles |    100 |      96.307 ns |   1.8693 ns |   1.4594 ns |  1.14 |    0.02 |
|                  |        |                |             |             |       |         |
|    **MinAndMaxInts** | **100000** |  **78,057.249 ns** | **200.8779 ns** | **178.0730 ns** |  **1.00** |    **0.00** |
|   MinAndMaxLongs | 100000 |  78,798.775 ns | 240.5044 ns | 200.8320 ns |  1.01 |    0.00 |
|  MinAndMaxFloats | 100000 |  93,340.042 ns |  37.8359 ns |  31.5947 ns |  1.20 |    0.00 |
| MinAndMaxDoubles | 100000 | 124,929.110 ns | 133.2941 ns | 118.1618 ns |  1.60 |    0.00 |
