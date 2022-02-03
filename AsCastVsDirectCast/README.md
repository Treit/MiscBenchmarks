# 'as' cast vs direct C-style cast

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22538
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|     Method |   Count |            Mean |         Error |          StdDev | Ratio | RatioSD |
|----------- |-------- |----------------:|--------------:|----------------:|------:|--------:|
|     **AsCast** |      **10** |        **424.6 ns** |       **8.42 ns** |        **17.58 ns** |  **1.00** |    **0.00** |
| DirectCast |      10 |        130.9 ns |       2.80 ns |         8.24 ns |  0.30 |    0.02 |
|            |         |                 |               |                 |       |         |
|     **AsCast** |    **1000** |     **42,516.4 ns** |     **812.81 ns** |     **1,784.13 ns** |  **1.00** |    **0.00** |
| DirectCast |    1000 |     12,503.2 ns |     308.24 ns |       884.39 ns |  0.29 |    0.02 |
|            |         |                 |               |                 |       |         |
|     **AsCast** | **1000000** | **42,041,094.2 ns** | **832,340.99 ns** | **2,306,412.97 ns** |  **1.00** |    **0.00** |
| DirectCast | 1000000 | 12,364,476.1 ns | 258,330.58 ns |   720,122.39 ns |  0.29 |    0.02 |
