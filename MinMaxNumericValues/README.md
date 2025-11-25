# Finding min and max on different numeric types.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Count  | Mean          | Error       | StdDev      | Ratio | RatioSD |
|----------------- |------- |--------------:|------------:|------------:|------:|--------:|
| **MinAndMaxInts**    | **10**     |     **10.081 ns** |   **0.1095 ns** |   **0.1024 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | 10     |      9.601 ns |   0.0429 ns |   0.0401 ns |  0.95 |    0.01 |
| MinAndMaxFloats  | 10     |     11.458 ns |   0.1525 ns |   0.1426 ns |  1.14 |    0.02 |
| MinAndMaxDoubles | 10     |     11.155 ns |   0.0573 ns |   0.0536 ns |  1.11 |    0.01 |
|                  |        |               |             |             |       |         |
| **MinAndMaxInts**    | **100**    |     **85.822 ns** |   **0.6530 ns** |   **0.6108 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | 100    |     85.846 ns |   0.4078 ns |   0.3814 ns |  1.00 |    0.01 |
| MinAndMaxFloats  | 100    |    119.795 ns |   1.1893 ns |   1.1125 ns |  1.40 |    0.02 |
| MinAndMaxDoubles | 100    |     97.678 ns |   1.0969 ns |   1.0261 ns |  1.14 |    0.01 |
|                  |        |               |             |             |       |         |
| **MinAndMaxInts**    | **100000** | **86,209.400 ns** | **501.9502 ns** | **469.5245 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | 100000 | 94,811.611 ns | 516.5030 ns | 483.1372 ns |  1.10 |    0.01 |
| MinAndMaxFloats  | 100000 | 94,521.369 ns | 466.2742 ns | 413.3399 ns |  1.10 |    0.01 |
| MinAndMaxDoubles | 100000 | 86,506.209 ns | 457.3363 ns | 427.7926 ns |  1.00 |    0.01 |
