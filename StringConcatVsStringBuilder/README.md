## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                                  Method | Count |              Mean |           Error |          StdDev | Ratio | RatioSD |       Gen0 |      Gen1 |   Allocated | Alloc Ratio |
|-------------------------------------------------------- |------ |------------------:|----------------:|----------------:|------:|--------:|-----------:|----------:|------------:|------------:|
|                                   **BuildStringWithConcat** |     **2** |         **13.006 ns** |       **0.0734 ns** |       **0.0686 ns** |  **1.00** |    **0.00** |     **0.0019** |         **-** |        **32 B** |        **1.00** |
|                            BuildStringWithStringBuilder |     2 |         23.256 ns |       0.2451 ns |       0.2173 ns |  1.79 |    0.02 |     0.0081 |         - |       136 B |        4.25 |
|                     BuildStringWithStringBuilderPrecalc |     2 |         22.210 ns |       0.2041 ns |       0.1809 ns |  1.71 |    0.02 |     0.0067 |         - |       112 B |        3.50 |
|                            BuildStringWithInterpolation |     2 |         12.182 ns |       0.1914 ns |       0.1697 ns |  0.94 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
|                        BuildStringWithStringCreateAkari |     2 |         16.216 ns |       0.0669 ns |       0.0626 ns |  1.25 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
|                BuildStringWithStringCreateLengthPrecalc |     2 |         15.192 ns |       0.1157 ns |       0.0966 ns |  1.17 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
|                BuildStringWithStringCreateWithCountKozi |     2 |         16.121 ns |       0.1175 ns |       0.0981 ns |  1.24 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
|            BuildStringWithStringCreateLengthPrecalcKozi |     2 |         13.497 ns |       0.0857 ns |       0.0802 ns |  1.04 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |     2 |          9.734 ns |       0.0668 ns |       0.0593 ns |  0.75 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |     2 |         24.355 ns |       0.1636 ns |       0.1530 ns |  1.87 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
|                                                         |       |                   |                 |                 |       |         |            |           |             |             |
|                                   **BuildStringWithConcat** |     **4** |         **33.702 ns** |       **0.2252 ns** |       **0.2107 ns** |  **1.00** |    **0.00** |     **0.0057** |         **-** |        **96 B** |        **1.00** |
|                            BuildStringWithStringBuilder |     4 |         26.770 ns |       0.2597 ns |       0.2429 ns |  0.79 |    0.01 |     0.0081 |         - |       136 B |        1.42 |
|                     BuildStringWithStringBuilderPrecalc |     4 |         26.252 ns |       0.2562 ns |       0.2271 ns |  0.78 |    0.01 |     0.0067 |         - |       112 B |        1.17 |
|                            BuildStringWithInterpolation |     4 |         33.415 ns |       0.2988 ns |       0.2795 ns |  0.99 |    0.01 |     0.0057 |         - |        96 B |        1.00 |
|                        BuildStringWithStringCreateAkari |     4 |         25.463 ns |       0.0819 ns |       0.0684 ns |  0.76 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
|                BuildStringWithStringCreateLengthPrecalc |     4 |         22.933 ns |       0.1043 ns |       0.0976 ns |  0.68 |    0.00 |     0.0019 |         - |        32 B |        0.33 |
|                BuildStringWithStringCreateWithCountKozi |     4 |         24.770 ns |       0.1272 ns |       0.1190 ns |  0.74 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
|            BuildStringWithStringCreateLengthPrecalcKozi |     4 |         18.227 ns |       0.0811 ns |       0.0678 ns |  0.54 |    0.00 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |     4 |         22.661 ns |       0.1005 ns |       0.0940 ns |  0.67 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |     4 |         33.780 ns |       0.1399 ns |       0.1240 ns |  1.00 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
|                                                         |       |                   |                 |                 |       |         |            |           |             |             |
|                                   **BuildStringWithConcat** |    **10** |        **112.162 ns** |       **0.6066 ns** |       **0.5674 ns** |  **1.00** |    **0.00** |     **0.0200** |         **-** |       **336 B** |        **1.00** |
|                            BuildStringWithStringBuilder |    10 |         39.854 ns |       0.3092 ns |       0.2582 ns |  0.36 |    0.00 |     0.0091 |         - |       152 B |        0.45 |
|                     BuildStringWithStringBuilderPrecalc |    10 |         41.327 ns |       0.5543 ns |       0.5185 ns |  0.37 |    0.00 |     0.0086 |         - |       144 B |        0.43 |
|                            BuildStringWithInterpolation |    10 |        110.226 ns |       0.6766 ns |       0.6329 ns |  0.98 |    0.01 |     0.0200 |         - |       336 B |        1.00 |
|                        BuildStringWithStringCreateAkari |    10 |         55.702 ns |       0.3235 ns |       0.3026 ns |  0.50 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
|                BuildStringWithStringCreateLengthPrecalc |    10 |         45.274 ns |       0.1522 ns |       0.1424 ns |  0.40 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
|                BuildStringWithStringCreateWithCountKozi |    10 |         50.446 ns |       0.1520 ns |       0.1422 ns |  0.45 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
|            BuildStringWithStringCreateLengthPrecalcKozi |    10 |         37.630 ns |       0.1483 ns |       0.1387 ns |  0.34 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |    10 |         29.387 ns |       0.3554 ns |       0.3324 ns |  0.26 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |    10 |         58.850 ns |       0.1999 ns |       0.1870 ns |  0.52 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
|                                                         |       |                   |                 |                 |       |         |            |           |             |             |
|                                   **BuildStringWithConcat** |   **100** |      **1,812.141 ns** |      **29.4420 ns** |      **27.5400 ns** |  **1.00** |    **0.00** |     **1.2455** |         **-** |     **20856 B** |        **1.00** |
|                            BuildStringWithStringBuilder |   100 |        386.906 ns |       3.3292 ns |       2.9513 ns |  0.21 |    0.00 |     0.0763 |         - |      1280 B |        0.06 |
|                     BuildStringWithStringBuilderPrecalc |   100 |        301.729 ns |       2.2850 ns |       2.1374 ns |  0.17 |    0.00 |     0.0515 |         - |       864 B |        0.04 |
|                            BuildStringWithInterpolation |   100 |      1,844.756 ns |      29.8313 ns |      27.9042 ns |  1.02 |    0.02 |     1.2436 |         - |     20856 B |        1.00 |
|                        BuildStringWithStringCreateAkari |   100 |        459.160 ns |       2.3621 ns |       2.2095 ns |  0.25 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
|                BuildStringWithStringCreateLengthPrecalc |   100 |        380.887 ns |       1.6109 ns |       1.4281 ns |  0.21 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
|                BuildStringWithStringCreateWithCountKozi |   100 |        413.446 ns |       0.9850 ns |       0.8225 ns |  0.23 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
|            BuildStringWithStringCreateLengthPrecalcKozi |   100 |        313.319 ns |       2.2876 ns |       2.1398 ns |  0.17 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |   100 |        311.673 ns |       5.0226 ns |       4.1941 ns |  0.17 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |   100 |        448.407 ns |       1.6118 ns |       1.5077 ns |  0.25 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
|                                                         |       |                   |                 |                 |       |         |            |           |             |             |
|                                   **BuildStringWithConcat** |  **1000** |    **128,009.089 ns** |   **2,471.4982 ns** |   **3,464.6952 ns** |  **1.00** |    **0.00** |   **168.4570** |    **2.4414** |   **2818056 B** |       **1.000** |
|                            BuildStringWithStringBuilder |  1000 |      4,580.265 ns |      39.1211 ns |      36.5939 ns |  0.04 |    0.00 |     0.8698 |    0.0229 |     14648 B |       0.005 |
|                     BuildStringWithStringBuilderPrecalc |  1000 |      4,512.043 ns |      48.3669 ns |      45.2424 ns |  0.04 |    0.00 |     0.6943 |    0.0153 |     11664 B |       0.004 |
|                            BuildStringWithInterpolation |  1000 |    125,553.022 ns |   2,486.8491 ns |   3,645.1912 ns |  0.98 |    0.03 |   168.4570 |    2.4414 |   2818056 B |       1.000 |
|                        BuildStringWithStringCreateAkari |  1000 |      4,517.306 ns |      13.4647 ns |      11.2436 ns |  0.04 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|                BuildStringWithStringCreateLengthPrecalc |  1000 |      3,709.923 ns |      17.8037 ns |      15.7825 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|                BuildStringWithStringCreateWithCountKozi |  1000 |      4,157.997 ns |      26.6298 ns |      24.9096 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|            BuildStringWithStringCreateLengthPrecalcKozi |  1000 |      3,035.540 ns |      10.6656 ns |       8.3270 ns |  0.02 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic |  1000 |      3,992.152 ns |      25.0480 ns |      22.2044 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred |  1000 |      4,928.940 ns |      21.0239 ns |      19.6658 ns |  0.04 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|                                                         |       |                   |                 |                 |       |         |            |           |             |             |
|                                   **BuildStringWithConcat** | **10000** | **19,409,884.167 ns** | **335,303.9829 ns** | **313,643.5536 ns** | **1.000** |    **0.00** | **22562.5000** | **3968.7500** | **379126068 B** |       **1.000** |
|                            BuildStringWithStringBuilder | 10000 |     48,481.401 ns |     248.1815 ns |     220.0064 ns | 0.002 |    0.00 |     9.4604 |    2.0752 |    159200 B |       0.000 |
|                     BuildStringWithStringBuilderPrecalc | 10000 |     70,090.970 ns |     310.0260 ns |     289.9985 ns | 0.004 |    0.00 |     9.1553 |         - |    155664 B |       0.000 |
|                            BuildStringWithInterpolation | 10000 | 19,262,369.167 ns | 369,110.1583 ns | 345,265.8711 ns | 0.993 |    0.02 | 22562.5000 | 3968.7500 | 379126068 B |       1.000 |
|                        BuildStringWithStringCreateAkari | 10000 |     48,436.540 ns |     120.4746 ns |     106.7976 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
|                BuildStringWithStringCreateLengthPrecalc | 10000 |     39,915.179 ns |     120.1062 ns |     106.4711 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
|                BuildStringWithStringCreateWithCountKozi | 10000 |     44,678.263 ns |     158.5882 ns |     148.3435 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
|            BuildStringWithStringCreateLengthPrecalcKozi | 10000 |     33,706.139 ns |     214.1309 ns |     200.2982 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10000 |     39,952.601 ns |     808.8978 ns |   1,351.4864 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
|  BuildStringWithDefaultInterpolatedStringHanlder333Fred | 10000 |     64,651.232 ns |     121.2388 ns |     101.2399 ns | 0.003 |    0.00 |     4.5166 |         - |     77808 B |       0.000 |
