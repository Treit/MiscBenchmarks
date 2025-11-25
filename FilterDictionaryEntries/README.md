# Filtering dictionary entries


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Count | Mean             | Error           | StdDev          | Ratio    | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|------------------------------------ |------ |-----------------:|----------------:|----------------:|---------:|--------:|----------:|------------:|------------:|
| **FilterUsingConvolutedLinq**           | **100**   |      **29,651.7 ns** |       **153.32 ns** |       **143.42 ns** |    **40.78** |    **0.28** |    **1.6785** |     **28352 B** |       **80.55** |
| FilterUsingCleanedUpPatternMatching | 100   |         727.2 ns |         4.67 ns |         3.90 ns |     1.00 |    0.01 |    0.0210 |       352 B |        1.00 |
|                                     |       |                  |                 |                 |          |         |           |             |             |
| **FilterUsingConvolutedLinq**           | **10000** | **263,251,400.0 ns** | **2,865,962.68 ns** | **2,680,823.27 ns** | **3,038.59** |   **42.61** | **6500.0000** | **110021784 B** |    **5,050.58** |
| FilterUsingCleanedUpPatternMatching | 10000 |      86,644.7 ns |     1,011.70 ns |       896.85 ns |     1.00 |    0.01 |    1.2207 |     21784 B |        1.00 |
