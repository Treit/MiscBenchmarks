# Loops, but with different counter types 😅





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method         | Count   | Mean             | Error          | StdDev         | Ratio | RatioSD |
|--------------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
| **ForLoopInteger** | **100**     |         **81.65 ns** |       **1.342 ns** |       **1.256 ns** |  **1.00** |    **0.02** |
| ForLoopFloat   | 100     |        138.88 ns |       1.026 ns |       0.959 ns |  1.70 |    0.03 |
| ForLoopDouble  | 100     |        140.34 ns |       1.166 ns |       1.090 ns |  1.72 |    0.03 |
| ForLoopDecimal | 100     |      1,751.44 ns |       3.977 ns |       3.720 ns | 21.45 |    0.32 |
|                |         |                  |                |                |       |         |
| **ForLoopInteger** | **1000000** |    **769,088.81 ns** |   **3,266.524 ns** |   **2,727.695 ns** |  **1.00** |    **0.00** |
| ForLoopFloat   | 1000000 |  1,548,514.90 ns |   6,883.213 ns |   6,438.562 ns |  2.01 |    0.01 |
| ForLoopDouble  | 1000000 |  1,558,133.84 ns |   6,363.101 ns |   5,640.723 ns |  2.03 |    0.01 |
| ForLoopDecimal | 1000000 | 17,841,904.17 ns | 115,855.182 ns | 108,371.009 ns | 23.20 |    0.16 |
