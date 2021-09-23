## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)
.NET 6 was used.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.100-rc.1.21458.32
  [Host]   : .NET Core 6.0.0 (CoreCLR 6.0.21.45113, CoreFX 6.0.21.45113), X64 RyuJIT
  ShortRun : .NET Core 6.0.0 (CoreCLR 6.0.21.45113, CoreFX 6.0.21.45113), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                                  Method | Count |             Mean |            Error |         StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|-------------------------------------------------------- |------ |-----------------:|-----------------:|---------------:|------:|--------:|-----------:|----------:|------:|------------:|
|                                   **BuildStringWithConcat** |     **2** |         **14.91 ns** |         **1.079 ns** |       **0.059 ns** |  **1.00** |    **0.00** |     **0.0038** |         **-** |     **-** |        **32 B** |
|                            BuildStringWithStringBuilder |     2 |         25.39 ns |         2.585 ns |       0.142 ns |  1.70 |    0.01 |     0.0162 |         - |     - |       136 B |
|                     BuildStringWithStringBuilderPrecalc |     2 |         32.94 ns |         5.016 ns |       0.275 ns |  2.21 |    0.01 |     0.0134 |         - |     - |       112 B |
|                            BuildStringWithInterpolation |     2 |         72.75 ns |         2.982 ns |       0.163 ns |  4.88 |    0.03 |     0.0067 |         - |     - |        56 B |
|                        BuildStringWithStringCreateAkari |     2 |         20.36 ns |         3.191 ns |       0.175 ns |  1.37 |    0.02 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateLengthPrecalc |     2 |         16.18 ns |         3.669 ns |       0.201 ns |  1.09 |    0.02 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateWithCountKozi |     2 |         20.21 ns |        14.166 ns |       0.776 ns |  1.36 |    0.06 |     0.0038 |         - |     - |        32 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |     2 |         17.27 ns |        11.664 ns |       0.639 ns |  1.16 |    0.04 |     0.0038 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |     2 |         12.85 ns |         5.492 ns |       0.301 ns |  0.86 |    0.02 |     0.0038 |         - |     - |        32 B |
|                                                         |       |                  |                  |                |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |     **4** |         **38.45 ns** |        **32.314 ns** |       **1.771 ns** |  **1.00** |    **0.00** |     **0.0114** |         **-** |     **-** |        **96 B** |
|                            BuildStringWithStringBuilder |     4 |         31.87 ns |        24.081 ns |       1.320 ns |  0.83 |    0.03 |     0.0162 |         - |     - |       136 B |
|                     BuildStringWithStringBuilderPrecalc |     4 |         40.61 ns |         7.870 ns |       0.431 ns |  1.06 |    0.04 |     0.0134 |         - |     - |       112 B |
|                            BuildStringWithInterpolation |     4 |        144.49 ns |         6.446 ns |       0.353 ns |  3.76 |    0.18 |     0.0143 |         - |     - |       120 B |
|                        BuildStringWithStringCreateAkari |     4 |         29.35 ns |         1.315 ns |       0.072 ns |  0.76 |    0.03 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateLengthPrecalc |     4 |         24.86 ns |         1.935 ns |       0.106 ns |  0.65 |    0.03 |     0.0038 |         - |     - |        32 B |
|                BuildStringWithStringCreateWithCountKozi |     4 |         29.55 ns |        18.755 ns |       1.028 ns |  0.77 |    0.05 |     0.0038 |         - |     - |        32 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |     4 |         24.12 ns |        24.273 ns |       1.331 ns |  0.63 |    0.04 |     0.0038 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |     4 |         17.21 ns |         9.099 ns |       0.499 ns |  0.45 |    0.01 |     0.0038 |         - |     - |        32 B |
|                                                         |       |                  |                  |                |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |    **10** |        **112.79 ns** |        **38.982 ns** |       **2.137 ns** |  **1.00** |    **0.00** |     **0.0401** |         **-** |     **-** |       **336 B** |
|                            BuildStringWithStringBuilder |    10 |         54.08 ns |         4.586 ns |       0.251 ns |  0.48 |    0.01 |     0.0181 |         - |     - |       152 B |
|                     BuildStringWithStringBuilderPrecalc |    10 |         63.82 ns |        47.779 ns |       2.619 ns |  0.57 |    0.03 |     0.0172 |         - |     - |       144 B |
|                            BuildStringWithInterpolation |    10 |        369.34 ns |        36.198 ns |       1.984 ns |  3.28 |    0.07 |     0.0429 |         - |     - |       360 B |
|                        BuildStringWithStringCreateAkari |    10 |         53.49 ns |         2.452 ns |       0.134 ns |  0.47 |    0.01 |     0.0057 |         - |     - |        48 B |
|                BuildStringWithStringCreateLengthPrecalc |    10 |         47.14 ns |         1.446 ns |       0.079 ns |  0.42 |    0.01 |     0.0057 |         - |     - |        48 B |
|                BuildStringWithStringCreateWithCountKozi |    10 |         54.53 ns |        24.625 ns |       1.350 ns |  0.48 |    0.01 |     0.0057 |         - |     - |        48 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |    10 |         42.60 ns |         7.990 ns |       0.438 ns |  0.38 |    0.01 |     0.0057 |         - |     - |        48 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |    10 |         33.04 ns |        20.514 ns |       1.124 ns |  0.29 |    0.01 |     0.0057 |         - |     - |        48 B |
|                                                         |       |                  |                  |                |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |   **100** |      **2,305.09 ns** |     **1,139.636 ns** |      **62.467 ns** |  **1.00** |    **0.00** |     **2.4910** |         **-** |     **-** |     **20856 B** |
|                            BuildStringWithStringBuilder |   100 |        641.92 ns |        66.266 ns |       3.632 ns |  0.28 |    0.01 |     0.1526 |         - |     - |      1280 B |
|                     BuildStringWithStringBuilderPrecalc |   100 |        500.97 ns |       149.381 ns |       8.188 ns |  0.22 |    0.00 |     0.1030 |         - |     - |       864 B |
|                            BuildStringWithInterpolation |   100 |      5,500.97 ns |     1,671.694 ns |      91.631 ns |  2.39 |    0.04 |     2.4948 |         - |     - |     20880 B |
|                        BuildStringWithStringCreateAkari |   100 |        489.45 ns |       120.102 ns |       6.583 ns |  0.21 |    0.01 |     0.0486 |         - |     - |       408 B |
|                BuildStringWithStringCreateLengthPrecalc |   100 |        402.66 ns |        26.612 ns |       1.459 ns |  0.17 |    0.00 |     0.0486 |         - |     - |       408 B |
|                BuildStringWithStringCreateWithCountKozi |   100 |        481.94 ns |       176.841 ns |       9.693 ns |  0.21 |    0.01 |     0.0486 |         - |     - |       408 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |   100 |        360.73 ns |        71.709 ns |       3.931 ns |  0.16 |    0.00 |     0.0486 |         - |     - |       408 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |   100 |        300.76 ns |        13.701 ns |       0.751 ns |  0.13 |    0.00 |     0.0486 |         - |     - |       408 B |
|                                                         |       |                  |                  |                |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** |  **1000** |    **138,598.95 ns** |    **93,640.224 ns** |   **5,132.737 ns** |  **1.00** |    **0.00** |   **336.6699** |    **4.8828** |     **-** |   **2818056 B** |
|                            BuildStringWithStringBuilder |  1000 |      7,029.32 ns |     4,051.867 ns |     222.096 ns |  0.05 |    0.00 |     1.7471 |    0.0534 |     - |     14648 B |
|                     BuildStringWithStringBuilderPrecalc |  1000 |      5,988.99 ns |       262.379 ns |      14.382 ns |  0.04 |    0.00 |     1.3885 |         - |     - |     11664 B |
|                            BuildStringWithInterpolation |  1000 |    249,422.74 ns |    85,917.586 ns |   4,709.433 ns |  1.80 |    0.05 |   336.4258 |         - |     - |   2818081 B |
|                        BuildStringWithStringCreateAkari |  1000 |      5,118.94 ns |     9,424.492 ns |     516.588 ns |  0.04 |    0.00 |     0.6866 |         - |     - |      5808 B |
|                BuildStringWithStringCreateLengthPrecalc |  1000 |      4,317.12 ns |     2,750.668 ns |     150.773 ns |  0.03 |    0.00 |     0.6866 |         - |     - |      5808 B |
|                BuildStringWithStringCreateWithCountKozi |  1000 |      4,915.37 ns |       429.816 ns |      23.560 ns |  0.04 |    0.00 |     0.6866 |         - |     - |      5808 B |
|            BuildStringWithStringCreateLengthPrecalcKozi |  1000 |      3,508.85 ns |       104.494 ns |       5.728 ns |  0.03 |    0.00 |     0.6905 |         - |     - |      5808 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |  1000 |      2,862.31 ns |     1,094.906 ns |      60.016 ns |  0.02 |    0.00 |     0.6905 |         - |     - |      5808 B |
|                                                         |       |                  |                  |                |       |         |            |           |       |             |
|                                   **BuildStringWithConcat** | **10000** | **15,950,860.94 ns** | **1,226,806.466 ns** |  **67,245.402 ns** | **1.000** |    **0.00** | **45062.5000** | **6968.7500** |     **-** | **379126071 B** |
|                            BuildStringWithStringBuilder | 10000 |     67,015.05 ns |    13,393.969 ns |     734.169 ns | 0.004 |    0.00 |    18.7988 |    3.0518 |     - |    159200 B |
|                     BuildStringWithStringBuilderPrecalc | 10000 |     55,402.52 ns |     2,975.296 ns |     163.086 ns | 0.003 |    0.00 |    18.4937 |         - |     - |    155664 B |
|                            BuildStringWithInterpolation | 10000 | 23,131,989.58 ns | 2,696,205.011 ns | 147,788.095 ns | 1.450 |    0.00 | 45062.5000 |         - |     - | 379126095 B |
|                        BuildStringWithStringCreateAkari | 10000 |     47,095.94 ns |    36,525.812 ns |   2,002.103 ns | 0.003 |    0.00 |     9.2163 |         - |     - |     77808 B |
|                BuildStringWithStringCreateLengthPrecalc | 10000 |     40,167.72 ns |    27,127.152 ns |   1,486.931 ns | 0.003 |    0.00 |     9.2163 |         - |     - |     77808 B |
|                BuildStringWithStringCreateWithCountKozi | 10000 |     47,291.47 ns |    10,052.350 ns |     551.003 ns | 0.003 |    0.00 |     9.2163 |         - |     - |     77808 B |
|            BuildStringWithStringCreateLengthPrecalcKozi | 10000 |     36,089.44 ns |     3,829.088 ns |     209.885 ns | 0.002 |    0.00 |     9.2163 |         - |     - |     77808 B |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10000 |     31,351.54 ns |    15,127.097 ns |     829.167 ns | 0.002 |    0.00 |     9.2163 |         - |     - |     77809 B |
