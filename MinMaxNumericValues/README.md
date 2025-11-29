# Finding min and max on different numeric types.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Job       | Runtime   | Count  | Mean          | Error         | StdDev        | Ratio | RatioSD |
|----------------- |---------- |---------- |------- |--------------:|--------------:|--------------:|------:|--------:|
| **MinAndMaxInts**    | **.NET 10.0** | **.NET 10.0** | **10**     |      **9.844 ns** |     **0.1244 ns** |     **0.1163 ns** |  **1.00** |    **0.02** |
| MinAndMaxLongs   | .NET 10.0 | .NET 10.0 | 10     |      9.591 ns |     0.0412 ns |     0.0386 ns |  0.97 |    0.01 |
| MinAndMaxFloats  | .NET 10.0 | .NET 10.0 | 10     |     11.329 ns |     0.1007 ns |     0.0893 ns |  1.15 |    0.02 |
| MinAndMaxDoubles | .NET 10.0 | .NET 10.0 | 10     |     11.123 ns |     0.0400 ns |     0.0334 ns |  1.13 |    0.01 |
|                  |           |           |        |               |               |               |       |         |
| MinAndMaxInts    | .NET 9.0  | .NET 9.0  | 10     |      9.815 ns |     0.0423 ns |     0.0396 ns |  1.00 |    0.01 |
| MinAndMaxLongs   | .NET 9.0  | .NET 9.0  | 10     |      9.568 ns |     0.0624 ns |     0.0584 ns |  0.97 |    0.01 |
| MinAndMaxFloats  | .NET 9.0  | .NET 9.0  | 10     |     11.331 ns |     0.0801 ns |     0.0787 ns |  1.15 |    0.01 |
| MinAndMaxDoubles | .NET 9.0  | .NET 9.0  | 10     |     11.097 ns |     0.0695 ns |     0.0650 ns |  1.13 |    0.01 |
|                  |           |           |        |               |               |               |       |         |
| **MinAndMaxInts**    | **.NET 10.0** | **.NET 10.0** | **100**    |     **84.485 ns** |     **0.5814 ns** |     **0.5154 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | .NET 10.0 | .NET 10.0 | 100    |     86.052 ns |     1.2266 ns |     1.1474 ns |  1.02 |    0.01 |
| MinAndMaxFloats  | .NET 10.0 | .NET 10.0 | 100    |    108.611 ns |     0.3503 ns |     0.3276 ns |  1.29 |    0.01 |
| MinAndMaxDoubles | .NET 10.0 | .NET 10.0 | 100    |    105.142 ns |     2.1106 ns |     2.6693 ns |  1.24 |    0.03 |
|                  |           |           |        |               |               |               |       |         |
| MinAndMaxInts    | .NET 9.0  | .NET 9.0  | 100    |     83.932 ns |     0.5245 ns |     0.4906 ns |  1.00 |    0.01 |
| MinAndMaxLongs   | .NET 9.0  | .NET 9.0  | 100    |     86.002 ns |     0.8685 ns |     0.8124 ns |  1.02 |    0.01 |
| MinAndMaxFloats  | .NET 9.0  | .NET 9.0  | 100    |    108.862 ns |     0.2687 ns |     0.2382 ns |  1.30 |    0.01 |
| MinAndMaxDoubles | .NET 9.0  | .NET 9.0  | 100    |    103.762 ns |     2.1041 ns |     2.5840 ns |  1.24 |    0.03 |
|                  |           |           |        |               |               |               |       |         |
| **MinAndMaxInts**    | **.NET 10.0** | **.NET 10.0** | **100000** | **89,369.019 ns** | **1,742.9095 ns** | **3,187.0087 ns** |  **1.00** |    **0.05** |
| MinAndMaxLongs   | .NET 10.0 | .NET 10.0 | 100000 | 94,112.078 ns |   159.3020 ns |   149.0111 ns |  1.05 |    0.04 |
| MinAndMaxFloats  | .NET 10.0 | .NET 10.0 | 100000 | 93,862.801 ns |   123.8816 ns |   115.8789 ns |  1.05 |    0.04 |
| MinAndMaxDoubles | .NET 10.0 | .NET 10.0 | 100000 | 94,599.853 ns |   348.5809 ns |   309.0079 ns |  1.06 |    0.04 |
|                  |           |           |        |               |               |               |       |         |
| MinAndMaxInts    | .NET 9.0  | .NET 9.0  | 100000 | 84,888.521 ns |   621.4663 ns |   518.9525 ns |  1.00 |    0.01 |
| MinAndMaxLongs   | .NET 9.0  | .NET 9.0  | 100000 | 94,166.180 ns |   185.2095 ns |   164.1834 ns |  1.11 |    0.01 |
| MinAndMaxFloats  | .NET 9.0  | .NET 9.0  | 100000 | 94,140.203 ns |   363.2046 ns |   303.2923 ns |  1.11 |    0.01 |
| MinAndMaxDoubles | .NET 9.0  | .NET 9.0  | 100000 | 94,521.687 ns |   432.2580 ns |   360.9550 ns |  1.11 |    0.01 |
