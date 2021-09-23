## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.100-rc.1.21458.32
  [Host]   : .NET Core 6.0.0 (CoreCLR 6.0.21.45113, CoreFX 6.0.21.45113), X64 RyuJIT
  ShortRun : .NET Core 6.0.0 (CoreCLR 6.0.21.45113, CoreFX 6.0.21.45113), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                                  Method | Count |             Mean |            Error |        StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|-------------------------------------------------------- |------ |-----------------:|-----------------:|--------------:|------:|--------:|-----------:|----------:|------:|------------:|
|                                   **BuildStringWithConcat** |     **2** |         **14.72 ns** |         **1.521 ns** |      **0.083 ns** |  **1.00** |    **0.00** |     **0.0038** |         **-** |     **-** |        **32 B** |
|                            BuildStringWithStringBuilder |     2 |         26.37 ns |         3.371 ns |      0.185 ns |  1.79 |    0.02 |     0.0162 |         - |     - |       136 B |
|                     BuildStringWithStringBuilderPrecalc |     2 |         34.01 ns |        11.254 ns |      0.617 ns |  2.31 |    0.05 |     0.0134 |         - |     - |       112 B |
|                            BuildStringWithInterpolation |     2 |         14.27 ns |         1.061 ns |      0.058 ns |  0.97 |    0.00 |     0.0038 |         - |     - |        32 B |
|                        BuildStringWithStringCreateAkari |     2 |         19.11 ns |         0.867 ns |      0.048 ns |  1.30 |    0.01 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateLengthPrecalc |     2 |         16.87 ns |         0.642 ns |      0.035 ns |  1.15 |    0.01 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateWithCountKozi |     2 |         21.17 ns |        10.335 ns |      0.566 ns |  1.44 |    0.05 |     0.0038 |         - |     - |        32 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |     2 |         14.06 ns |         6.988 ns |      0.383 ns |  0.96 |    0.03 |     0.0038 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |     2 |         12.98 ns |         1.146 ns |      0.063 ns |  0.88 |    0.01 |     0.0038 |         - |     - |        32 B |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |     2 |         32.05 ns |         7.380 ns |      0.405 ns |  2.18 |    0.04 |     0.0038 |         - |     - |        32 B |
|                                                         |       |                  |                  |               |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |     **4** |         **39.25 ns** |         **4.257 ns** |      **0.233 ns** |  **1.00** |    **0.00** |     **0.0114** |         **-** |     **-** |        **96 B** |
|                            BuildStringWithStringBuilder |     4 |         33.53 ns |        22.014 ns |      1.207 ns |  0.85 |    0.03 |     0.0162 |         - |     - |       136 B |
|                     BuildStringWithStringBuilderPrecalc |     4 |         41.29 ns |         1.145 ns |      0.063 ns |  1.05 |    0.00 |     0.0134 |         - |     - |       112 B |
|                            BuildStringWithInterpolation |     4 |         37.00 ns |         4.539 ns |      0.249 ns |  0.94 |    0.01 |     0.0114 |         - |     - |        96 B |
|                        BuildStringWithStringCreateAkari |     4 |         28.20 ns |         0.371 ns |      0.020 ns |  0.72 |    0.00 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateLengthPrecalc |     4 |         25.59 ns |        14.396 ns |      0.789 ns |  0.65 |    0.02 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateWithCountKozi |     4 |         30.43 ns |         6.578 ns |      0.361 ns |  0.78 |    0.01 |     0.0038 |         - |     - |        32 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |     4 |         20.77 ns |         0.945 ns |      0.052 ns |  0.53 |    0.00 |     0.0038 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |     4 |         17.91 ns |         2.323 ns |      0.127 ns |  0.46 |    0.00 |     0.0038 |         - |     - |        32 B |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |     4 |         40.49 ns |        12.730 ns |      0.698 ns |  1.03 |    0.02 |     0.0038 |         - |     - |        32 B |
|                                                         |       |                  |                  |               |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |    **10** |        **117.48 ns** |        **22.930 ns** |      **1.257 ns** |  **1.00** |    **0.00** |     **0.0401** |         **-** |     **-** |       **336 B** |
|                            BuildStringWithStringBuilder |    10 |         54.19 ns |         1.554 ns |      0.085 ns |  0.46 |    0.00 |     0.0181 |         - |     - |       152 B |
|                     BuildStringWithStringBuilderPrecalc |    10 |         62.64 ns |        48.487 ns |      2.658 ns |  0.53 |    0.03 |     0.0172 |         - |     - |       144 B |
|                            BuildStringWithInterpolation |    10 |        113.34 ns |        15.205 ns |      0.833 ns |  0.96 |    0.00 |     0.0401 |         - |     - |       336 B |
|                        BuildStringWithStringCreateAkari |    10 |         55.54 ns |        22.274 ns |      1.221 ns |  0.47 |    0.01 |     0.0057 |         - |     - |        48 B |
|                BuildStringWithStringCreateLengthPrecalc |    10 |         45.68 ns |         2.042 ns |      0.112 ns |  0.39 |    0.00 |     0.0057 |         - |     - |        48 B |
|                BuildStringWithStringCreateWithCountKozi |    10 |         54.52 ns |        48.334 ns |      2.649 ns |  0.46 |    0.03 |     0.0057 |         - |     - |        48 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |    10 |         39.95 ns |        50.628 ns |      2.775 ns |  0.34 |    0.03 |     0.0057 |         - |     - |        48 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |    10 |         34.02 ns |         2.880 ns |      0.158 ns |  0.29 |    0.00 |     0.0057 |         - |     - |        48 B |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |    10 |         60.56 ns |        39.653 ns |      2.173 ns |  0.52 |    0.02 |     0.0057 |         - |     - |        48 B |
|                                                         |       |                  |                  |               |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |   **100** |      **2,163.38 ns** |       **255.989 ns** |     **14.032 ns** |  **1.00** |    **0.00** |     **2.4910** |         **-** |     **-** |     **20856 B** |
|                            BuildStringWithStringBuilder |   100 |        646.73 ns |        35.490 ns |      1.945 ns |  0.30 |    0.00 |     0.1526 |         - |     - |      1280 B |
|                     BuildStringWithStringBuilderPrecalc |   100 |        495.40 ns |       141.608 ns |      7.762 ns |  0.23 |    0.00 |     0.1030 |         - |     - |       864 B |
|                            BuildStringWithInterpolation |   100 |      2,286.24 ns |       154.428 ns |      8.465 ns |  1.06 |    0.00 |     2.4910 |         - |     - |     20856 B |
|                        BuildStringWithStringCreateAkari |   100 |        520.19 ns |       351.828 ns |     19.285 ns |  0.24 |    0.01 |     0.0486 |         - |     - |       408 B |
|                BuildStringWithStringCreateLengthPrecalc |   100 |        404.38 ns |        71.561 ns |      3.923 ns |  0.19 |    0.00 |     0.0486 |         - |     - |       408 B |
|                BuildStringWithStringCreateWithCountKozi |   100 |        453.60 ns |        67.975 ns |      3.726 ns |  0.21 |    0.00 |     0.0486 |         - |     - |       408 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |   100 |        352.53 ns |        28.400 ns |      1.557 ns |  0.16 |    0.00 |     0.0486 |         - |     - |       408 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |   100 |        301.85 ns |        19.939 ns |      1.093 ns |  0.14 |    0.00 |     0.0486 |         - |     - |       408 B |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |   100 |        402.28 ns |        12.548 ns |      0.688 ns |  0.19 |    0.00 |     0.0486 |         - |     - |       408 B |
|                                                         |       |                  |                  |               |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |  **1000** |    **135,878.40 ns** |    **11,999.666 ns** |    **657.742 ns** |  **1.00** |    **0.00** |   **336.6699** |    **4.8828** |     **-** |   **2818056 B** |
|                            BuildStringWithStringBuilder |  1000 |      7,481.19 ns |     6,777.971 ns |    371.523 ns |  0.06 |    0.00 |     1.7471 |    0.0534 |     - |     14648 B |
|                     BuildStringWithStringBuilderPrecalc |  1000 |      6,063.10 ns |     3,896.758 ns |    213.594 ns |  0.04 |    0.00 |     1.3885 |    0.0153 |     - |     11664 B |
|                            BuildStringWithInterpolation |  1000 |    134,882.71 ns |    10,296.576 ns |    564.390 ns |  0.99 |    0.00 |   336.6699 |    4.6387 |     - |   2818059 B |
|                        BuildStringWithStringCreateAkari |  1000 |      5,255.73 ns |       121.252 ns |      6.646 ns |  0.04 |    0.00 |     0.6866 |         - |     - |      5808 B |
|                BuildStringWithStringCreateLengthPrecalc |  1000 |      4,027.22 ns |       195.983 ns |     10.743 ns |  0.03 |    0.00 |     0.6866 |         - |     - |      5808 B |
|                BuildStringWithStringCreateWithCountKozi |  1000 |      4,442.98 ns |       914.764 ns |     50.141 ns |  0.03 |    0.00 |     0.6866 |         - |     - |      5808 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |  1000 |      3,531.32 ns |       124.028 ns |      6.798 ns |  0.03 |    0.00 |     0.6905 |         - |     - |      5808 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |  1000 |      2,852.09 ns |       260.563 ns |     14.282 ns |  0.02 |    0.00 |     0.6905 |         - |     - |      5808 B |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |  1000 |      4,432.97 ns |       659.650 ns |     36.158 ns |  0.03 |    0.00 |     0.6866 |         - |     - |      5808 B |
|                                                         |       |                  |                  |               |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** | **10000** | **16,194,626.04 ns** |   **329,769.374 ns** | **18,075.772 ns** | **1.000** |    **0.00** | **45062.5000** | **6968.7500** |     **-** | **379126071 B** |
|                            BuildStringWithStringBuilder | 10000 |     68,003.00 ns |    52,163.029 ns |  2,859.232 ns | 0.004 |    0.00 |    18.7988 |    3.0518 |     - |    159200 B |
|                     BuildStringWithStringBuilderPrecalc | 10000 |     57,991.48 ns |     4,279.817 ns |    234.591 ns | 0.004 |    0.00 |    18.4937 |         - |     - |    155664 B |
|                            BuildStringWithInterpolation | 10000 | 16,062,161.46 ns | 1,181,968.450 ns | 64,787.679 ns | 0.992 |    0.00 | 45062.5000 | 6968.7500 |     - | 379126071 B |
|                        BuildStringWithStringCreateAkari | 10000 |     51,100.75 ns |     4,921.092 ns |    269.742 ns | 0.003 |    0.00 |     9.2163 |         - |     - |     77808 B |
|                BuildStringWithStringCreateLengthPrecalc | 10000 |     38,812.53 ns |       798.366 ns |     43.761 ns | 0.002 |    0.00 |     9.2163 |         - |     - |     77808 B |
|                BuildStringWithStringCreateWithCountKozi | 10000 |     49,635.50 ns |     2,697.425 ns |    147.855 ns | 0.003 |    0.00 |     9.2163 |         - |     - |     77808 B |
|            BuildStringWithStringCreateLengthPrecalcKozi | 10000 |     35,964.60 ns |     1,004.171 ns |     55.042 ns | 0.002 |    0.00 |     9.2163 |         - |     - |     77808 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10000 |     31,001.46 ns |       233.087 ns |     12.776 ns | 0.002 |    0.00 |     9.2163 |         - |     - |     77808 B |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred | 10000 |     45,439.53 ns |    37,651.357 ns |  2,063.798 ns | 0.003 |    0.00 |     9.2163 |         - |     - |     77808 B |


