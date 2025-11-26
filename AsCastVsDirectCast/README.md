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
| **AsCast**     | **10**      |        **12.27 ns** |      **0.056 ns** |      **0.044 ns** |  **1.00** |    **0.00** |
| DirectCast | 10      |        13.72 ns |      0.208 ns |      0.194 ns |  1.12 |    0.02 |
|            |         |                 |               |               |       |         |
| **AsCast**     | **1000**    |     **1,060.02 ns** |      **7.555 ns** |      **7.067 ns** |  **1.00** |    **0.01** |
| DirectCast | 1000    |     1,069.66 ns |     12.307 ns |     10.910 ns |  1.01 |    0.01 |
|            |         |                 |               |               |       |         |
| **AsCast**     | **1000000** | **1,454,800.61 ns** | **12,240.694 ns** | **10,851.056 ns** |  **1.00** |    **0.01** |
| DirectCast | 1000000 | 1,377,617.75 ns | 21,275.130 ns | 19,900.770 ns |  0.95 |    0.01 |
