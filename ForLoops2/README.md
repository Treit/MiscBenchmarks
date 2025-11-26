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
| **ForLoopInteger** | **100**     |         **81.17 ns** |       **1.085 ns** |       **1.015 ns** |  **1.00** |    **0.02** |
| ForLoopFloat   | 100     |        139.08 ns |       0.946 ns |       0.885 ns |  1.71 |    0.02 |
| ForLoopDouble  | 100     |        140.74 ns |       0.804 ns |       0.712 ns |  1.73 |    0.02 |
| ForLoopDecimal | 100     |      1,834.93 ns |       2.783 ns |       2.603 ns | 22.61 |    0.27 |
|                |         |                  |                |                |       |         |
| **ForLoopInteger** | **1000000** |    **765,831.41 ns** |   **5,017.587 ns** |   **4,693.454 ns** |  **1.00** |    **0.01** |
| ForLoopFloat   | 1000000 |  1,548,800.08 ns |   6,612.238 ns |   5,521.518 ns |  2.02 |    0.01 |
| ForLoopDouble  | 1000000 |  1,560,837.47 ns |   8,452.505 ns |   7,906.478 ns |  2.04 |    0.02 |
| ForLoopDecimal | 1000000 | 17,341,682.08 ns | 118,059.238 ns | 110,432.684 ns | 22.65 |    0.19 |
