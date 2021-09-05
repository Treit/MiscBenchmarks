## String.Concat vs. StringBuilder (for small strings.)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22451
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                       Method | Count |             Mean |             Error |           StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|----------------------------- |------ |-----------------:|------------------:|-----------------:|------:|--------:|-----------:|----------:|------:|------------:|
|        **BuildStringWithConcat** |     **2** |         **21.49 ns** |          **8.420 ns** |         **0.462 ns** |  **1.00** |    **0.00** |     **0.0074** |         **-** |     **-** |        **32 B** |
| BuildStringWithStringBuilder |     2 |         33.24 ns |         24.978 ns |         1.369 ns |  1.55 |    0.03 |     0.0315 |         - |     - |       136 B |
|                              |       |                  |                   |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |     **4** |         **63.69 ns** |         **64.100 ns** |         **3.514 ns** |  **1.00** |    **0.00** |     **0.0222** |         **-** |     **-** |        **96 B** |
| BuildStringWithStringBuilder |     4 |         41.66 ns |         20.491 ns |         1.123 ns |  0.66 |    0.03 |     0.0315 |         - |     - |       136 B |
|                              |       |                  |                   |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |    **10** |        **184.22 ns** |         **12.607 ns** |         **0.691 ns** |  **1.00** |    **0.00** |     **0.0777** |         **-** |     **-** |       **336 B** |
| BuildStringWithStringBuilder |    10 |         74.18 ns |         71.523 ns |         3.920 ns |  0.40 |    0.02 |     0.0352 |         - |     - |       152 B |
|                              |       |                  |                   |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |   **100** |      **3,236.06 ns** |        **687.791 ns** |        **37.700 ns** |  **1.00** |    **0.00** |     **4.8332** |         **-** |     **-** |     **20856 B** |
| BuildStringWithStringBuilder |   100 |        917.98 ns |      1,453.266 ns |        79.658 ns |  0.28 |    0.03 |     0.2966 |         - |     - |      1280 B |
|                              |       |                  |                   |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |  **1000** |    **266,059.99 ns** |    **157,460.353 ns** |     **8,630.933 ns** |  **1.00** |    **0.00** |   **652.8320** |         **-** |     **-** |   **2818056 B** |
| BuildStringWithStringBuilder |  1000 |     10,059.65 ns |      6,990.295 ns |       383.162 ns |  0.04 |    0.00 |     3.3875 |    0.1068 |     - |     14648 B |
|                              |       |                  |                   |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** | **10000** | **52,838,736.67 ns** | **48,840,306.350 ns** | **2,677,101.995 ns** | **1.000** |    **0.00** | **87100.0000** | **2600.0000** |     **-** | **379126130 B** |
| BuildStringWithStringBuilder | 10000 |    101,037.17 ns |     25,068.419 ns |     1,374.085 ns | 0.002 |    0.00 |    36.4990 |    6.1035 |     - |    159200 B |
