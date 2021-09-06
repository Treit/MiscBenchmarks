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
|                                   Method | Count |             Mean |             Error |           StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|----------------------------------------- |------ |-----------------:|------------------:|-----------------:|------:|--------:|-----------:|----------:|------:|------------:|
|                    **BuildStringWithConcat** |     **2** |         **23.47 ns** |          **2.420 ns** |         **0.133 ns** |  **1.00** |    **0.00** |     **0.0074** |         **-** |     **-** |        **32 B** |
|             BuildStringWithStringBuilder |     2 |         32.91 ns |         19.260 ns |         1.056 ns |  1.40 |    0.05 |     0.0315 |         - |     - |       136 B |
|             BuildStringWithInterpolation |     2 |        185.77 ns |        108.848 ns |         5.966 ns |  7.92 |    0.30 |     0.0241 |         - |     - |       104 B |
|         BuildStringWithStringCreateAkari |     2 |         36.21 ns |         40.773 ns |         2.235 ns |  1.54 |    0.09 |     0.0074 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalc |     2 |         32.59 ns |         17.520 ns |         0.960 ns |  1.39 |    0.05 |     0.0074 |         - |     - |        32 B |
|                                          |       |                  |                   |                  |       |         |            |           |       |             |
|                    **BuildStringWithConcat** |     **4** |         **57.63 ns** |         **34.976 ns** |         **1.917 ns** |  **1.00** |    **0.00** |     **0.0222** |         **-** |     **-** |        **96 B** |
|             BuildStringWithStringBuilder |     4 |         43.68 ns |         33.332 ns |         1.827 ns |  0.76 |    0.05 |     0.0315 |         - |     - |       136 B |
|             BuildStringWithInterpolation |     4 |        396.86 ns |        243.589 ns |        13.352 ns |  6.90 |    0.46 |     0.0501 |         - |     - |       216 B |
|         BuildStringWithStringCreateAkari |     4 |         59.13 ns |         33.508 ns |         1.837 ns |  1.03 |    0.01 |     0.0074 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalc |     4 |         52.63 ns |         28.613 ns |         1.568 ns |  0.91 |    0.05 |     0.0074 |         - |     - |        32 B |
|                                          |       |                  |                   |                  |       |         |            |           |       |             |
|                    **BuildStringWithConcat** |    **10** |        **186.41 ns** |        **180.273 ns** |         **9.881 ns** |  **1.00** |    **0.00** |     **0.0777** |         **-** |     **-** |       **336 B** |
|             BuildStringWithStringBuilder |    10 |         70.31 ns |         13.931 ns |         0.764 ns |  0.38 |    0.02 |     0.0352 |         - |     - |       152 B |
|             BuildStringWithInterpolation |    10 |        956.59 ns |        501.694 ns |        27.500 ns |  5.14 |    0.28 |     0.1373 |         - |     - |       600 B |
|         BuildStringWithStringCreateAkari |    10 |        142.00 ns |         48.952 ns |         2.683 ns |  0.76 |    0.03 |     0.0110 |         - |     - |        48 B |
| BuildStringWithStringCreateLengthPrecalc |    10 |        120.08 ns |         57.369 ns |         3.145 ns |  0.64 |    0.02 |     0.0110 |         - |     - |        48 B |
|                                          |       |                  |                   |                  |       |         |            |           |       |             |
|                    **BuildStringWithConcat** |   **100** |      **3,115.87 ns** |      **1,012.986 ns** |        **55.525 ns** |  **1.00** |    **0.00** |     **4.8332** |         **-** |     **-** |     **20856 B** |
|             BuildStringWithStringBuilder |   100 |        779.07 ns |        969.432 ns |        53.138 ns |  0.25 |    0.02 |     0.2966 |         - |     - |      1280 B |
|             BuildStringWithInterpolation |   100 |     11,026.86 ns |      4,996.899 ns |       273.897 ns |  3.54 |    0.15 |     5.3864 |         - |     - |     23280 B |
|         BuildStringWithStringCreateAkari |   100 |      1,233.48 ns |        542.333 ns |        29.727 ns |  0.40 |    0.01 |     0.0935 |         - |     - |       408 B |
| BuildStringWithStringCreateLengthPrecalc |   100 |        908.37 ns |        290.369 ns |        15.916 ns |  0.29 |    0.01 |     0.0944 |         - |     - |       408 B |
|                                          |       |                  |                   |                  |       |         |            |           |       |             |
|                    **BuildStringWithConcat** |  **1000** |    **247,618.45 ns** |     **93,081.820 ns** |     **5,102.129 ns** |  **1.00** |    **0.00** |   **653.0762** |         **-** |     **-** |   **2818056 B** |
|             BuildStringWithStringBuilder |  1000 |      9,793.10 ns |      9,169.488 ns |       502.611 ns |  0.04 |    0.00 |     3.3875 |    0.1068 |     - |     14648 B |
|             BuildStringWithInterpolation |  1000 |    419,373.81 ns |    206,239.783 ns |    11,304.698 ns |  1.69 |    0.08 |   658.6914 |         - |     - |   2842208 B |
|         BuildStringWithStringCreateAkari |  1000 |     10,503.14 ns |      4,958.163 ns |       271.774 ns |  0.04 |    0.00 |     1.3428 |         - |     - |      5808 B |
| BuildStringWithStringCreateLengthPrecalc |  1000 |      8,710.60 ns |      5,626.401 ns |       308.402 ns |  0.04 |    0.00 |     1.3428 |         - |     - |      5808 B |
|                                          |       |                  |                   |                  |       |         |            |           |       |             |
|                    **BuildStringWithConcat** | **10000** | **52,020,990.00 ns** | **25,966,051.195 ns** | **1,423,286.885 ns** | **1.000** |    **0.00** | **87100.0000** | **2600.0000** |     **-** | **379126056 B** |
|             BuildStringWithStringBuilder | 10000 |     89,231.80 ns |    100,613.360 ns |     5,514.958 ns | 0.002 |    0.00 |    36.4990 |    6.1035 |     - |    159200 B |
|             BuildStringWithInterpolation | 10000 | 60,491,174.07 ns | 35,650,450.248 ns | 1,954,121.475 ns | 1.163 |    0.01 | 87333.3333 | 1444.4444 |     - | 379366368 B |
|         BuildStringWithStringCreateAkari | 10000 |    115,974.07 ns |     30,608.981 ns |     1,677.782 ns | 0.002 |    0.00 |    17.8223 |         - |     - |     77808 B |
| BuildStringWithStringCreateLengthPrecalc | 10000 |     83,013.75 ns |     41,862.064 ns |     2,294.601 ns | 0.002 |    0.00 |    17.8223 |         - |     - |     77808 B |
