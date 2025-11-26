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
| **FilterUsingConvolutedLinq**           | **100**   |      **29,251.8 ns** |       **105.01 ns** |        **81.99 ns** |    **40.10** |    **0.28** |    **1.6785** |     **28352 B** |       **80.55** |
| FilterUsingCleanedUpPatternMatching | 100   |         729.6 ns |         5.81 ns |         4.85 ns |     1.00 |    0.01 |    0.0210 |       352 B |        1.00 |
|                                     |       |                  |                 |                 |          |         |           |             |             |
| **FilterUsingConvolutedLinq**           | **10000** | **263,653,323.3 ns** | **3,743,725.51 ns** | **3,501,883.17 ns** | **2,863.21** |   **65.89** | **6500.0000** | **110021784 B** |    **5,050.58** |
| FilterUsingCleanedUpPatternMatching | 10000 |      92,115.9 ns |     1,819.85 ns |     1,787.33 ns |     1.00 |    0.03 |    1.2207 |     21784 B |        1.00 |
