# 'as' cast vs direct C-style cast


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|     Method |   Count |            Mean |        Error |       StdDev | Ratio |
|----------- |-------- |----------------:|-------------:|-------------:|------:|
|     **AsCast** |      **10** |        **108.3 ns** |      **0.64 ns** |      **0.60 ns** |  **1.00** |
| DirectCast |      10 |        101.6 ns |      1.11 ns |      1.04 ns |  0.94 |
|            |         |                 |              |              |       |
|     **AsCast** |    **1000** |     **10,958.0 ns** |    **122.15 ns** |    **108.28 ns** |  **1.00** |
| DirectCast |    1000 |     11,022.3 ns |     51.51 ns |     48.18 ns |  1.01 |
|            |         |                 |              |              |       |
|     **AsCast** | **1000000** | **11,182,833.8 ns** | **51,760.20 ns** | **43,222.11 ns** |  **1.00** |
| DirectCast | 1000000 | 10,284,217.1 ns | 39,505.46 ns | 36,953.43 ns |  0.92 |
