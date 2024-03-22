# Loops, but with different counter types 😅




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26085.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method         | Count   | Mean             | Error          | StdDev         | Median           | Ratio | RatioSD |
|--------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
| **ForLoopInteger** | **100**     |         **76.43 ns** |       **1.518 ns** |       **3.607 ns** |         **75.15 ns** |  **1.00** |    **0.00** |
| ForLoopFloat   | 100     |        151.25 ns |       1.461 ns |       1.220 ns |        151.25 ns |  2.03 |    0.07 |
| ForLoopDouble  | 100     |        149.09 ns |       2.891 ns |       2.704 ns |        148.09 ns |  2.00 |    0.08 |
| ForLoopDecimal | 100     |      1,646.39 ns |      32.265 ns |      64.437 ns |      1,613.45 ns | 21.40 |    1.35 |
|                |         |                  |                |                |                  |       |         |
| **ForLoopInteger** | **1000000** |    **682,353.39 ns** |  **13,536.941 ns** |  **27,034.734 ns** |    **682,369.38 ns** |  **1.00** |    **0.00** |
| ForLoopFloat   | 1000000 |  1,424,602.84 ns |  23,234.445 ns |  21,733.515 ns |  1,425,588.67 ns |  2.09 |    0.11 |
| ForLoopDouble  | 1000000 |  1,395,758.67 ns |  24,900.841 ns |  23,292.262 ns |  1,392,506.25 ns |  2.05 |    0.10 |
| ForLoopDecimal | 1000000 | 17,467,489.88 ns | 347,038.870 ns | 668,626.084 ns | 17,414,279.69 ns | 25.62 |    1.61 |
