## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22454
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                       Method | Count |             Mean |            Error |           StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|----------------------------- |------ |-----------------:|-----------------:|-----------------:|------:|--------:|-----------:|----------:|------:|------------:|
|        **BuildStringWithConcat** |     **2** |         **20.93 ns** |         **15.03 ns** |         **0.824 ns** |  **1.00** |    **0.00** |     **0.0074** |         **-** |     **-** |        **32 B** |
| BuildStringWithStringBuilder |     2 |         30.61 ns |         24.68 ns |         1.353 ns |  1.46 |    0.05 |     0.0315 |         - |     - |       136 B |
| BuildStringWithInterpolation |     2 |        180.83 ns |         95.82 ns |         5.252 ns |  8.64 |    0.12 |     0.0241 |         - |     - |       104 B |
|                              |       |                  |                  |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |     **4** |         **60.32 ns** |         **74.73 ns** |         **4.096 ns** |  **1.00** |    **0.00** |     **0.0222** |         **-** |     **-** |        **96 B** |
| BuildStringWithStringBuilder |     4 |         41.04 ns |         35.22 ns |         1.931 ns |  0.68 |    0.01 |     0.0315 |         - |     - |       136 B |
| BuildStringWithInterpolation |     4 |        370.97 ns |        214.38 ns |        11.751 ns |  6.16 |    0.25 |     0.0501 |         - |     - |       216 B |
|                              |       |                  |                  |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |    **10** |        **187.21 ns** |        **107.83 ns** |         **5.911 ns** |  **1.00** |    **0.00** |     **0.0777** |         **-** |     **-** |       **336 B** |
| BuildStringWithStringBuilder |    10 |         76.08 ns |         57.13 ns |         3.132 ns |  0.41 |    0.00 |     0.0352 |         - |     - |       152 B |
| BuildStringWithInterpolation |    10 |        992.32 ns |      1,352.37 ns |        74.128 ns |  5.31 |    0.55 |     0.1373 |         - |     - |       600 B |
|                              |       |                  |                  |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |   **100** |      **3,198.48 ns** |        **807.64 ns** |        **44.270 ns** |  **1.00** |    **0.00** |     **4.8332** |         **-** |     **-** |     **20856 B** |
| BuildStringWithStringBuilder |   100 |        866.31 ns |        157.40 ns |         8.628 ns |  0.27 |    0.01 |     0.2966 |         - |     - |      1280 B |
| BuildStringWithInterpolation |   100 |     11,367.30 ns |      2,044.57 ns |       112.070 ns |  3.55 |    0.06 |     5.3864 |         - |     - |     23280 B |
|                              |       |                  |                  |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** |  **1000** |    **254,743.70 ns** |    **316,196.37 ns** |    **17,331.790 ns** |  **1.00** |    **0.00** |   **652.8320** |         **-** |     **-** |   **2818056 B** |
| BuildStringWithStringBuilder |  1000 |      9,823.43 ns |      7,622.60 ns |       417.820 ns |  0.04 |    0.00 |     3.3875 |    0.1068 |     - |     14648 B |
| BuildStringWithInterpolation |  1000 |    443,154.92 ns |     54,483.43 ns |     2,986.421 ns |  1.75 |    0.12 |   658.6914 |         - |     - |   2842208 B |
|                              |       |                  |                  |                  |       |         |            |           |       |             |
|        **BuildStringWithConcat** | **10000** | **52,737,983.33 ns** | **27,792,765.43 ns** | **1,523,415.256 ns** | **1.000** |    **0.00** | **87100.0000** | **2600.0000** |     **-** | **379126130 B** |
| BuildStringWithStringBuilder | 10000 |     91,359.46 ns |     65,235.62 ns |     3,575.784 ns | 0.002 |    0.00 |    36.4990 |    6.1035 |     - |    159200 B |
| BuildStringWithInterpolation | 10000 | 60,132,844.44 ns |  1,317,564.57 ns |    72,220.160 ns | 1.141 |    0.03 | 87333.3333 | 1444.4444 |     - | 379366368 B |
