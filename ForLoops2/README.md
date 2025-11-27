# Loops, but with different counter types 😅







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method         | Job       | Runtime   | Count   | Mean             | Error          | StdDev         | Ratio | RatioSD |
|--------------- |---------- |---------- |-------- |-----------------:|---------------:|---------------:|------:|--------:|
| **ForLoopInteger** | **.NET 10.0** | **.NET 10.0** | **100**     |         **82.51 ns** |       **1.102 ns** |       **0.976 ns** |  **1.00** |    **0.02** |
| ForLoopFloat   | .NET 10.0 | .NET 10.0 | 100     |        145.77 ns |       1.577 ns |       1.475 ns |  1.77 |    0.03 |
| ForLoopDouble  | .NET 10.0 | .NET 10.0 | 100     |        141.52 ns |       1.041 ns |       0.923 ns |  1.72 |    0.02 |
| ForLoopDecimal | .NET 10.0 | .NET 10.0 | 100     |      1,847.06 ns |       2.052 ns |       1.919 ns | 22.39 |    0.26 |
|                |           |           |         |                  |                |                |       |         |
| ForLoopInteger | .NET 9.0  | .NET 9.0  | 100     |         82.12 ns |       0.821 ns |       0.768 ns |  1.00 |    0.01 |
| ForLoopFloat   | .NET 9.0  | .NET 9.0  | 100     |        141.19 ns |       1.270 ns |       0.992 ns |  1.72 |    0.02 |
| ForLoopDouble  | .NET 9.0  | .NET 9.0  | 100     |        141.61 ns |       1.755 ns |       1.556 ns |  1.72 |    0.02 |
| ForLoopDecimal | .NET 9.0  | .NET 9.0  | 100     |      1,803.51 ns |       4.494 ns |       4.204 ns | 21.96 |    0.20 |
|                |           |           |         |                  |                |                |       |         |
| **ForLoopInteger** | **.NET 10.0** | **.NET 10.0** | **1000000** |    **780,407.17 ns** |   **6,413.046 ns** |   **5,998.768 ns** |  **1.00** |    **0.01** |
| ForLoopFloat   | .NET 10.0 | .NET 10.0 | 1000000 |  1,560,589.83 ns |  19,811.107 ns |  16,543.172 ns |  2.00 |    0.03 |
| ForLoopDouble  | .NET 10.0 | .NET 10.0 | 1000000 |  1,577,377.02 ns |  19,342.631 ns |  18,093.109 ns |  2.02 |    0.03 |
| ForLoopDecimal | .NET 10.0 | .NET 10.0 | 1000000 | 18,195,154.58 ns | 147,721.452 ns | 138,178.738 ns | 23.32 |    0.24 |
|                |           |           |         |                  |                |                |       |         |
| ForLoopInteger | .NET 9.0  | .NET 9.0  | 1000000 |    780,351.91 ns |   9,868.771 ns |   8,748.409 ns |  1.00 |    0.02 |
| ForLoopFloat   | .NET 9.0  | .NET 9.0  | 1000000 |  1,559,399.71 ns |   9,839.051 ns |   8,722.063 ns |  2.00 |    0.02 |
| ForLoopDouble  | .NET 9.0  | .NET 9.0  | 1000000 |  1,561,547.20 ns |   6,147.451 ns |   5,750.329 ns |  2.00 |    0.02 |
| ForLoopDecimal | .NET 9.0  | .NET 9.0  | 1000000 | 18,213,688.75 ns | 127,768.146 ns | 119,514.403 ns | 23.34 |    0.29 |
