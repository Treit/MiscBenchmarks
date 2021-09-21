## IndexOf vs. Contains

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22463
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|             Method |  Count |         Mean |         Error |      StdDev | Ratio | RatioSD |
|------------------- |------- |-------------:|--------------:|------------:|------:|--------:|
| **CountUsingContains** |    **100** |     **1.402 μs** |     **0.6136 μs** |   **0.0336 μs** |  **1.00** |    **0.00** |
|  CountUsingIndexOf |    100 |     4.997 μs |     0.7892 μs |   0.0433 μs |  3.56 |    0.06 |
|                    |        |              |               |             |       |         |
| **CountUsingContains** |   **1000** |    **13.326 μs** |     **3.0623 μs** |   **0.1679 μs** |  **1.00** |    **0.00** |
|  CountUsingIndexOf |   1000 |    62.578 μs |    46.2392 μs |   2.5345 μs |  4.70 |    0.19 |
|                    |        |              |               |             |       |         |
| **CountUsingContains** |  **10000** |   **140.830 μs** |    **14.6588 μs** |   **0.8035 μs** |  **1.00** |    **0.00** |
|  CountUsingIndexOf |  10000 |   587.510 μs |   550.1596 μs |  30.1561 μs |  4.17 |    0.24 |
|                    |        |              |               |             |       |         |
| **CountUsingContains** | **100000** | **1,460.757 μs** |   **226.1701 μs** |  **12.3971 μs** |  **1.00** |    **0.00** |
|  CountUsingIndexOf | 100000 | 6,024.196 μs | 3,350.2509 μs | 183.6386 μs |  4.12 |    0.10 |
