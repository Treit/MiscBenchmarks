# 'as' cast vs direct C-style cast



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method     | Count   | Mean            | Error         | StdDev        | Ratio | RatioSD |
|----------- |-------- |----------------:|--------------:|--------------:|------:|--------:|
| **AsCast**     | **10**      |        **12.25 ns** |      **0.079 ns** |      **0.070 ns** |  **1.00** |    **0.01** |
| DirectCast | 10      |        13.49 ns |      0.127 ns |      0.113 ns |  1.10 |    0.01 |
|            |         |                 |               |               |       |         |
| **AsCast**     | **1000**    |     **1,052.33 ns** |      **6.917 ns** |      **6.470 ns** |  **1.00** |    **0.01** |
| DirectCast | 1000    |     1,060.74 ns |      9.248 ns |      8.198 ns |  1.01 |    0.01 |
|            |         |                 |               |               |       |         |
| **AsCast**     | **1000000** | **1,420,308.51 ns** | **14,514.454 ns** | **13,576.830 ns** |  **1.00** |    **0.01** |
| DirectCast | 1000000 | 1,324,906.58 ns | 21,046.829 ns | 19,687.217 ns |  0.93 |    0.02 |
