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
|                                                 Method | Count |             Mean |             Error |           StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 | Gen 2 |   Allocated |
|------------------------------------------------------- |------ |-----------------:|------------------:|-----------------:|------:|--------:|-----------:|----------:|------:|------------:|
|                                  **BuildStringWithConcat** |     **2** |         **22.62 ns** |         **26.339 ns** |         **1.444 ns** |  **1.00** |    **0.00** |     **0.0074** |         **-** |     **-** |        **32 B** |
|                           BuildStringWithStringBuilder |     2 |         33.21 ns |         27.751 ns |         1.521 ns |  1.47 |    0.13 |     0.0315 |         - |     - |       136 B |
|                           BuildStringWithInterpolation |     2 |        187.03 ns |        137.178 ns |         7.519 ns |  8.28 |    0.22 |     0.0241 |         - |     - |       104 B |
|                       BuildStringWithStringCreateAkari |     2 |         36.64 ns |         42.302 ns |         2.319 ns |  1.62 |    0.11 |     0.0074 |         - |     - |        32 B |
|               BuildStringWithStringCreateLengthPrecalc |     2 |         32.57 ns |         31.556 ns |         1.730 ns |  1.44 |    0.07 |     0.0074 |         - |     - |        32 B |
|               BuildStringWithStringCreateWithCountKozi |     2 |         43.91 ns |         17.361 ns |         0.952 ns |  1.95 |    0.16 |     0.0074 |         - |     - |        32 B |
|            BuildStringWithStringCreateLengthPrecalKozi |     2 |         32.56 ns |         18.751 ns |         1.028 ns |  1.44 |    0.10 |     0.0074 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalKoziUnsafeMagic |     2 |         25.11 ns |          9.374 ns |         0.514 ns |  1.11 |    0.09 |     0.0074 |         - |     - |        32 B |
|                                                        |       |                  |                   |                  |       |         |            |           |       |             |
|                                  **BuildStringWithConcat** |     **4** |         **59.69 ns** |         **82.078 ns** |         **4.499 ns** |  **1.00** |    **0.00** |     **0.0222** |         **-** |     **-** |        **96 B** |
|                           BuildStringWithStringBuilder |     4 |         40.50 ns |         15.543 ns |         0.852 ns |  0.68 |    0.04 |     0.0315 |         - |     - |       136 B |
|                           BuildStringWithInterpolation |     4 |        382.96 ns |        162.773 ns |         8.922 ns |  6.45 |    0.60 |     0.0501 |         - |     - |       216 B |
|                       BuildStringWithStringCreateAkari |     4 |         61.00 ns |         32.698 ns |         1.792 ns |  1.03 |    0.08 |     0.0074 |         - |     - |        32 B |
|               BuildStringWithStringCreateLengthPrecalc |     4 |         52.20 ns |         24.168 ns |         1.325 ns |  0.88 |    0.08 |     0.0074 |         - |     - |        32 B |
|               BuildStringWithStringCreateWithCountKozi |     4 |         66.59 ns |         16.659 ns |         0.913 ns |  1.12 |    0.08 |     0.0074 |         - |     - |        32 B |
|            BuildStringWithStringCreateLengthPrecalKozi |     4 |         42.38 ns |         19.644 ns |         1.077 ns |  0.71 |    0.03 |     0.0074 |         - |     - |        32 B |
| BuildStringWithStringCreateLengthPrecalKoziUnsafeMagic |     4 |         31.44 ns |         15.310 ns |         0.839 ns |  0.53 |    0.05 |     0.0074 |         - |     - |        32 B |
|                                                        |       |                  |                   |                  |       |         |            |           |       |             |
|                                  **BuildStringWithConcat** |    **10** |        **181.57 ns** |        **173.984 ns** |         **9.537 ns** |  **1.00** |    **0.00** |     **0.0777** |         **-** |     **-** |       **336 B** |
|                           BuildStringWithStringBuilder |    10 |         65.28 ns |         60.170 ns |         3.298 ns |  0.36 |    0.03 |     0.0352 |         - |     - |       152 B |
|                           BuildStringWithInterpolation |    10 |        989.93 ns |        274.548 ns |        15.049 ns |  5.46 |    0.29 |     0.1373 |         - |     - |       600 B |
|                       BuildStringWithStringCreateAkari |    10 |        141.94 ns |        132.539 ns |         7.265 ns |  0.78 |    0.07 |     0.0110 |         - |     - |        48 B |
|               BuildStringWithStringCreateLengthPrecalc |    10 |        123.47 ns |         87.427 ns |         4.792 ns |  0.68 |    0.02 |     0.0111 |         - |     - |        48 B |
|               BuildStringWithStringCreateWithCountKozi |    10 |        141.16 ns |        155.411 ns |         8.519 ns |  0.78 |    0.03 |     0.0110 |         - |     - |        48 B |
|            BuildStringWithStringCreateLengthPrecalKozi |    10 |         78.96 ns |         69.978 ns |         3.836 ns |  0.44 |    0.02 |     0.0111 |         - |     - |        48 B |
| BuildStringWithStringCreateLengthPrecalKoziUnsafeMagic |    10 |         47.47 ns |         23.052 ns |         1.264 ns |  0.26 |    0.02 |     0.0111 |         - |     - |        48 B |
|                                                        |       |                  |                   |                  |       |         |            |           |       |             |
|                                  **BuildStringWithConcat** |   **100** |      **3,062.13 ns** |      **2,726.891 ns** |       **149.470 ns** |  **1.00** |    **0.00** |     **4.8332** |         **-** |     **-** |     **20856 B** |
|                           BuildStringWithStringBuilder |   100 |        766.21 ns |        202.265 ns |        11.087 ns |  0.25 |    0.01 |     0.2966 |         - |     - |      1280 B |
|                           BuildStringWithInterpolation |   100 |     11,628.78 ns |     13,684.712 ns |       750.105 ns |  3.80 |    0.33 |     5.3864 |         - |     - |     23280 B |
|                       BuildStringWithStringCreateAkari |   100 |      1,194.48 ns |        674.462 ns |        36.970 ns |  0.39 |    0.03 |     0.0935 |         - |     - |       408 B |
|               BuildStringWithStringCreateLengthPrecalc |   100 |      1,060.65 ns |        889.898 ns |        48.778 ns |  0.35 |    0.03 |     0.0935 |         - |     - |       408 B |
|               BuildStringWithStringCreateWithCountKozi |   100 |      1,130.08 ns |        718.752 ns |        39.397 ns |  0.37 |    0.03 |     0.0935 |         - |     - |       408 B |
|            BuildStringWithStringCreateLengthPrecalKozi |   100 |        606.33 ns |        439.398 ns |        24.085 ns |  0.20 |    0.01 |     0.0944 |         - |     - |       408 B |
| BuildStringWithStringCreateLengthPrecalKoziUnsafeMagic |   100 |        313.33 ns |        325.863 ns |        17.862 ns |  0.10 |    0.01 |     0.0944 |         - |     - |       408 B |
|                                                        |       |                  |                   |                  |       |         |            |           |       |             |
|                                  **BuildStringWithConcat** |  **1000** |    **295,192.09 ns** |    **184,277.734 ns** |    **10,100.884 ns** |  **1.00** |    **0.00** |   **652.8320** |         **-** |     **-** |   **2818056 B** |
|                           BuildStringWithStringBuilder |  1000 |      9,669.49 ns |      5,202.756 ns |       285.181 ns |  0.03 |    0.00 |     3.3875 |    0.1068 |     - |     14648 B |
|                           BuildStringWithInterpolation |  1000 |    423,587.03 ns |    285,262.800 ns |    15,636.217 ns |  1.44 |    0.10 |   658.6914 |         - |     - |   2842208 B |
|                       BuildStringWithStringCreateAkari |  1000 |     11,600.27 ns |      8,185.369 ns |       448.668 ns |  0.04 |    0.00 |     1.3428 |         - |     - |      5808 B |
|               BuildStringWithStringCreateLengthPrecalc |  1000 |      9,793.81 ns |      6,504.488 ns |       356.533 ns |  0.03 |    0.00 |     1.3428 |         - |     - |      5808 B |
|               BuildStringWithStringCreateWithCountKozi |  1000 |     11,429.84 ns |      6,296.396 ns |       345.127 ns |  0.04 |    0.00 |     1.3428 |         - |     - |      5808 B |
|            BuildStringWithStringCreateLengthPrecalKozi |  1000 |      5,620.78 ns |      6,357.807 ns |       348.493 ns |  0.02 |    0.00 |     1.3428 |         - |     - |      5808 B |
| BuildStringWithStringCreateLengthPrecalKoziUnsafeMagic |  1000 |      3,314.06 ns |     10,038.733 ns |       550.257 ns |  0.01 |    0.00 |     1.3428 |         - |     - |      5808 B |
|                                                        |       |                  |                   |                  |       |         |            |           |       |             |
|                                  **BuildStringWithConcat** | **10000** | **50,765,593.33 ns** |  **8,177,522.017 ns** |   **448,237.576 ns** | **1.000** |    **0.00** | **87100.0000** | **2600.0000** |     **-** | **379126130 B** |
|                           BuildStringWithStringBuilder | 10000 |     90,877.45 ns |     51,986.615 ns |     2,849.562 ns | 0.002 |    0.00 |    36.4990 |    6.1035 |     - |    159200 B |
|                           BuildStringWithInterpolation | 10000 | 59,977,988.89 ns | 23,152,384.605 ns | 1,269,060.324 ns | 1.182 |    0.03 | 87333.3333 | 1444.4444 |     - | 379366368 B |
|                       BuildStringWithStringCreateAkari | 10000 |    110,649.54 ns |     49,573.714 ns |     2,717.303 ns | 0.002 |    0.00 |    17.8223 |         - |     - |     77808 B |
|               BuildStringWithStringCreateLengthPrecalc | 10000 |     94,535.14 ns |     32,824.983 ns |     1,799.248 ns | 0.002 |    0.00 |    17.8223 |         - |     - |     77808 B |
|               BuildStringWithStringCreateWithCountKozi | 10000 |    109,183.14 ns |    121,106.323 ns |     6,638.246 ns | 0.002 |    0.00 |    17.8223 |         - |     - |     77808 B |
|            BuildStringWithStringCreateLengthPrecalKozi | 10000 |     51,031.91 ns |     42,239.217 ns |     2,315.274 ns | 0.001 |    0.00 |    17.8223 |         - |     - |     77808 B |
| BuildStringWithStringCreateLengthPrecalKoziUnsafeMagic | 10000 |     29,849.69 ns |     15,443.488 ns |       846.510 ns | 0.001 |    0.00 |    17.8528 |         - |     - |     77808 B |
