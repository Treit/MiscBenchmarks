## Convert.ToInt32 vs. int.Parse

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22460
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                   Method |  Count |           Mean |         Error |       StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |---------------:|--------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|  **StringToIntUsingConvert** |     **10** |       **128.7 ns** |     **109.05 ns** |      **5.98 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse |     10 |       126.3 ns |       6.42 ns |      0.35 ns |  0.98 |    0.05 |     - |     - |     - |         - |
| StringToIntUsingTryParse |     10 |       122.4 ns |      11.43 ns |      0.63 ns |  0.95 |    0.05 |     - |     - |     - |         - |
|                          |        |                |               |              |       |         |       |       |       |           |
|  **StringToIntUsingConvert** |    **100** |     **1,223.4 ns** |     **208.26 ns** |     **11.42 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse |    100 |     1,504.5 ns |   1,182.79 ns |     64.83 ns |  1.23 |    0.05 |     - |     - |     - |         - |
| StringToIntUsingTryParse |    100 |     1,230.4 ns |     529.36 ns |     29.02 ns |  1.01 |    0.01 |     - |     - |     - |         - |
|                          |        |                |               |              |       |         |       |       |       |           |
|  **StringToIntUsingConvert** |  **10000** |   **147,282.2 ns** |  **35,246.21 ns** |  **1,931.96 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse |  10000 |   144,831.3 ns |  58,640.33 ns |  3,214.27 ns |  0.98 |    0.03 |     - |     - |     - |         - |
| StringToIntUsingTryParse |  10000 |   143,675.2 ns | 104,463.33 ns |  5,725.99 ns |  0.98 |    0.03 |     - |     - |     - |         - |
|                          |        |                |               |              |       |         |       |       |       |           |
|  **StringToIntUsingConvert** | **100000** | **1,452,694.5 ns** | **583,268.06 ns** | **31,970.89 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse | 100000 | 1,398,947.8 ns | 919,334.35 ns | 50,391.82 ns |  0.96 |    0.02 |     - |     - |     - |         - |
| StringToIntUsingTryParse | 100000 | 1,474,373.2 ns | 406,792.80 ns | 22,297.69 ns |  1.02 |    0.01 |     - |     - |     - |         - |
