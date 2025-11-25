## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                  | Count | Mean              | Error           | StdDev          | Median            | Ratio | RatioSD | Gen0       | Gen1      | Allocated   | Alloc Ratio |
|-------------------------------------------------------- |------ |------------------:|----------------:|----------------:|------------------:|------:|--------:|-----------:|----------:|------------:|------------:|
| **BuildStringWithConcat**                                   | **2**     |         **12.320 ns** |       **0.1584 ns** |       **0.1323 ns** |         **12.314 ns** |  **1.00** |    **0.01** |     **0.0019** |         **-** |        **32 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 2     |         21.318 ns |       0.2365 ns |       0.2213 ns |         21.336 ns |  1.73 |    0.02 |     0.0081 |         - |       136 B |        4.25 |
| BuildStringWithStringBuilderPrecalc                     | 2     |         21.579 ns |       0.1839 ns |       0.1721 ns |         21.597 ns |  1.75 |    0.02 |     0.0067 |         - |       112 B |        3.50 |
| BuildStringWithInterpolation                            | 2     |         12.237 ns |       0.0717 ns |       0.0635 ns |         12.236 ns |  0.99 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 2     |         14.911 ns |       0.1749 ns |       0.1636 ns |         14.898 ns |  1.21 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalc                | 2     |         14.050 ns |       0.1577 ns |       0.1475 ns |         14.041 ns |  1.14 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateWithCountKozi                | 2     |         14.898 ns |       0.1738 ns |       0.1541 ns |         14.875 ns |  1.21 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 2     |         11.814 ns |       0.0889 ns |       0.0788 ns |         11.799 ns |  0.96 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 2     |          9.841 ns |       0.1031 ns |       0.0914 ns |          9.854 ns |  0.80 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 2     |         22.929 ns |       0.1730 ns |       0.1444 ns |         23.004 ns |  1.86 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **4**     |         **30.230 ns** |       **0.4169 ns** |       **0.3900 ns** |         **30.154 ns** |  **1.00** |    **0.02** |     **0.0057** |         **-** |        **96 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 4     |         26.289 ns |       0.0969 ns |       0.0906 ns |         26.296 ns |  0.87 |    0.01 |     0.0081 |         - |       136 B |        1.42 |
| BuildStringWithStringBuilderPrecalc                     | 4     |         26.242 ns |       0.1818 ns |       0.1700 ns |         26.220 ns |  0.87 |    0.01 |     0.0067 |         - |       112 B |        1.17 |
| BuildStringWithInterpolation                            | 4     |         30.482 ns |       0.4266 ns |       0.3990 ns |         30.453 ns |  1.01 |    0.02 |     0.0057 |         - |        96 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 4     |         23.958 ns |       0.1456 ns |       0.1291 ns |         23.963 ns |  0.79 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalc                | 4     |         20.723 ns |       0.2201 ns |       0.2059 ns |         20.711 ns |  0.69 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateWithCountKozi                | 4     |         22.168 ns |       0.0960 ns |       0.0851 ns |         22.177 ns |  0.73 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 4     |         17.447 ns |       0.1688 ns |       0.1579 ns |         17.467 ns |  0.58 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 4     |         14.485 ns |       0.1958 ns |       0.1736 ns |         14.515 ns |  0.48 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 4     |         30.651 ns |       0.4019 ns |       0.3759 ns |         30.777 ns |  1.01 |    0.02 |     0.0019 |         - |        32 B |        0.33 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **10**    |         **85.824 ns** |       **0.8831 ns** |       **0.8261 ns** |         **85.821 ns** |  **1.00** |    **0.01** |     **0.0200** |         **-** |       **336 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 10    |         46.488 ns |       0.2538 ns |       0.2374 ns |         46.484 ns |  0.54 |    0.01 |     0.0091 |         - |       152 B |        0.45 |
| BuildStringWithStringBuilderPrecalc                     | 10    |         41.733 ns |       0.5069 ns |       0.4742 ns |         41.792 ns |  0.49 |    0.01 |     0.0086 |         - |       144 B |        0.43 |
| BuildStringWithInterpolation                            | 10    |         85.211 ns |       0.9902 ns |       0.9262 ns |         85.294 ns |  0.99 |    0.01 |     0.0200 |         - |       336 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 10    |         53.411 ns |       0.4032 ns |       0.3575 ns |         53.329 ns |  0.62 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalc                | 10    |         43.265 ns |       0.2699 ns |       0.2392 ns |         43.351 ns |  0.50 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateWithCountKozi                | 10    |         47.601 ns |       0.3580 ns |       0.2989 ns |         47.591 ns |  0.55 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 10    |         32.230 ns |       0.3653 ns |       0.3051 ns |         32.169 ns |  0.38 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10    |         27.401 ns |       0.1809 ns |       0.1692 ns |         27.435 ns |  0.32 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 10    |         54.006 ns |       0.2130 ns |       0.1993 ns |         53.999 ns |  0.63 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **100**   |      **1,742.081 ns** |      **34.6305 ns** |      **38.4917 ns** |      **1,754.846 ns** |  **1.00** |    **0.03** |     **1.2455** |         **-** |     **20856 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 100   |        447.006 ns |       3.1400 ns |       2.9372 ns |        447.910 ns |  0.26 |    0.01 |     0.0763 |         - |      1280 B |        0.06 |
| BuildStringWithStringBuilderPrecalc                     | 100   |        311.481 ns |       2.8691 ns |       2.5434 ns |        311.747 ns |  0.18 |    0.00 |     0.0515 |         - |       864 B |        0.04 |
| BuildStringWithInterpolation                            | 100   |      1,766.442 ns |      20.4247 ns |      19.1053 ns |      1,766.865 ns |  1.01 |    0.02 |     1.2455 |         - |     20856 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 100   |        478.915 ns |       4.7576 ns |       4.2175 ns |        479.721 ns |  0.28 |    0.01 |     0.0238 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalc                | 100   |        380.399 ns |       2.1531 ns |       1.9087 ns |        380.812 ns |  0.22 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateWithCountKozi                | 100   |        419.858 ns |       1.8400 ns |       1.6311 ns |        419.477 ns |  0.24 |    0.01 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 100   |        305.656 ns |       6.1065 ns |      14.6307 ns |        314.295 ns |  0.18 |    0.01 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 100   |        238.482 ns |       5.1826 ns |      15.2811 ns |        233.208 ns |  0.14 |    0.01 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 100   |        405.749 ns |       2.3708 ns |       2.2177 ns |        406.007 ns |  0.23 |    0.01 |     0.0243 |         - |       408 B |        0.02 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **1000**  |    **127,103.843 ns** |   **2,478.1589 ns** |   **3,222.3068 ns** |    **127,624.731 ns** |  **1.00** |    **0.04** |   **168.4570** |    **2.4414** |   **2818056 B** |       **1.000** |
| BuildStringWithStringBuilder                            | 1000  |      4,903.896 ns |      55.1743 ns |      51.6101 ns |      4,918.682 ns |  0.04 |    0.00 |     0.8698 |    0.0229 |     14648 B |       0.005 |
| BuildStringWithStringBuilderPrecalc                     | 1000  |      3,984.535 ns |      35.6774 ns |      31.6271 ns |      3,992.779 ns |  0.03 |    0.00 |     0.6943 |    0.0153 |     11664 B |       0.004 |
| BuildStringWithInterpolation                            | 1000  |    132,142.954 ns |   2,288.5226 ns |   2,140.6855 ns |    132,404.736 ns |  1.04 |    0.03 |   168.4570 |    2.4414 |   2818056 B |       1.000 |
| BuildStringWithStringCreateAkari                        | 1000  |      4,780.317 ns |      77.9143 ns |      65.0620 ns |      4,775.556 ns |  0.04 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalc                | 1000  |      3,844.960 ns |      50.9506 ns |      47.6593 ns |      3,831.333 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateWithCountKozi                | 1000  |      4,232.623 ns |      45.1495 ns |      42.2328 ns |      4,247.730 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 1000  |      2,801.745 ns |      22.3092 ns |      18.6292 ns |      2,803.891 ns |  0.02 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 1000  |      2,339.555 ns |      46.7814 ns |     114.7556 ns |      2,305.826 ns |  0.02 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 1000  |      4,369.833 ns |      29.0872 ns |      25.7850 ns |      4,374.706 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **10000** | **19,699,177.083 ns** | **327,971.9102 ns** | **306,785.1284 ns** | **19,791,081.250 ns** | **1.000** |    **0.02** | **22562.5000** | **3968.7500** | **379126056 B** |       **1.000** |
| BuildStringWithStringBuilder                            | 10000 |     44,794.322 ns |     400.1471 ns |     374.2978 ns |     44,719.501 ns | 0.002 |    0.00 |     9.4604 |    2.0752 |    159200 B |       0.000 |
| BuildStringWithStringBuilderPrecalc                     | 10000 |     65,734.845 ns |     887.7676 ns |     830.4183 ns |     65,814.600 ns | 0.003 |    0.00 |     9.1553 |         - |    155664 B |       0.000 |
| BuildStringWithInterpolation                            | 10000 | 20,771,673.611 ns | 393,658.9142 ns | 421,210.6282 ns | 20,791,810.938 ns | 1.055 |    0.03 | 22562.5000 | 3968.7500 | 379126056 B |       1.000 |
| BuildStringWithStringCreateAkari                        | 10000 |     46,186.976 ns |     421.1678 ns |     393.9606 ns |     46,132.932 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalc                | 10000 |     38,156.483 ns |     245.6500 ns |     229.7812 ns |     38,201.447 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateWithCountKozi                | 10000 |     41,349.172 ns |     328.6794 ns |     291.3658 ns |     41,325.259 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 10000 |     28,321.442 ns |     220.8329 ns |     206.5672 ns |     28,383.426 ns | 0.001 |    0.00 |     4.6082 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10000 |     25,480.256 ns |     298.2716 ns |     232.8708 ns |     25,483.940 ns | 0.001 |    0.00 |     4.6082 |         - |     77808 B |       0.000 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 10000 |     65,478.446 ns |     554.5367 ns |     518.7140 ns |     65,426.294 ns | 0.003 |    0.00 |     4.5166 |         - |     77808 B |       0.000 |
