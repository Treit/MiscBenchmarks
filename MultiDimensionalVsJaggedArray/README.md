# Multidimensional vs. Jagged arrays.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22509
Unknown processor
.NET Core SDK=6.0.100
  [Host]   : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  ShortRun : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|              Method | Size |         Mean |        Error |     StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |----- |-------------:|-------------:|-----------:|------:|--------:|------:|------:|------:|----------:|
|           **SumJagged** |  **100** |     **7.170 μs** |     **2.235 μs** |  **0.1225 μs** |  **0.63** |    **0.05** |     **-** |     **-** |     **-** |         **-** |
| SumMultiDimensional |  100 |    11.347 μs |    14.440 μs |  0.7915 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                     |      |              |              |            |       |         |       |       |       |           |
|           **SumJagged** | **1024** |   **923.494 μs** |   **257.390 μs** | **14.1084 μs** |  **0.83** |    **0.03** |     **-** |     **-** |     **-** |         **-** |
| SumMultiDimensional | 1024 | 1,118.009 μs | 1,052.415 μs | 57.6864 μs |  1.00 |    0.00 |     - |     - |     - |         - |
