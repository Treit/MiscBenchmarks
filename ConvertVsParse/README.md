## Convert.ToInt32 vs. int.Parse

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22581
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.15 (CoreCLR 5.0.1522.11506, CoreFX 5.0.1522.11506), X64 RyuJIT


```
|                   Method |  Count |           Mean |        Error |       StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------- |---------------:|-------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|  **StringToIntUsingConvert** |     **10** |       **155.9 ns** |      **3.13 ns** |      **6.61 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse |     10 |       153.0 ns |      3.06 ns |      7.03 ns |  0.98 |    0.07 |     - |     - |     - |         - |
| StringToIntUsingTryParse |     10 |       153.7 ns |      3.03 ns |      6.40 ns |  0.99 |    0.06 |     - |     - |     - |         - |
|                          |        |                |              |              |       |         |       |       |       |           |
|  **StringToIntUsingConvert** |    **100** |     **1,498.0 ns** |     **28.07 ns** |     **56.69 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse |    100 |     1,478.0 ns |     29.41 ns |     59.42 ns |  0.99 |    0.06 |     - |     - |     - |         - |
| StringToIntUsingTryParse |    100 |     1,504.0 ns |     29.59 ns |     49.44 ns |  1.01 |    0.05 |     - |     - |     - |         - |
|                          |        |                |              |              |       |         |       |       |       |           |
|  **StringToIntUsingConvert** |  **10000** |   **167,147.2 ns** |  **3,304.41 ns** |  **6,124.95 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse |  10000 |   166,619.9 ns |  3,257.60 ns |  5,260.42 ns |  1.00 |    0.05 |     - |     - |     - |         - |
| StringToIntUsingTryParse |  10000 |   161,897.3 ns |  3,219.90 ns |  7,462.61 ns |  0.97 |    0.06 |     - |     - |     - |         - |
|                          |        |                |              |              |       |         |       |       |       |           |
|  **StringToIntUsingConvert** | **100000** | **1,671,566.2 ns** | **33,127.66 ns** | **52,543.98 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|    StringToIntUsingParse | 100000 | 1,832,999.2 ns | 36,151.11 ns | 63,315.75 ns |  1.10 |    0.05 |     - |     - |     - |         - |
| StringToIntUsingTryParse | 100000 | 1,700,512.6 ns | 33,452.88 ns | 58,590.02 ns |  1.02 |    0.05 |     - |     - |     - |         - |
