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
| **BuildStringWithConcat**                                   | **2**     |         **12.590 ns** |       **0.1749 ns** |       **0.1636 ns** |         **12.545 ns** |  **1.00** |    **0.02** |     **0.0019** |         **-** |        **32 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 2     |         20.520 ns |       0.1674 ns |       0.1566 ns |         20.565 ns |  1.63 |    0.02 |     0.0081 |         - |       136 B |        4.25 |
| BuildStringWithStringBuilderPrecalc                     | 2     |         21.079 ns |       0.3498 ns |       0.3272 ns |         21.023 ns |  1.67 |    0.03 |     0.0067 |         - |       112 B |        3.50 |
| BuildStringWithInterpolation                            | 2     |         12.577 ns |       0.1169 ns |       0.0976 ns |         12.593 ns |  1.00 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 2     |         14.912 ns |       0.1723 ns |       0.1612 ns |         14.904 ns |  1.18 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalc                | 2     |         14.928 ns |       0.1934 ns |       0.1809 ns |         14.959 ns |  1.19 |    0.02 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateWithCountKozi                | 2     |         14.506 ns |       0.2951 ns |       0.2760 ns |         14.551 ns |  1.15 |    0.03 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 2     |         11.808 ns |       0.1002 ns |       0.0836 ns |         11.791 ns |  0.94 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 2     |          9.766 ns |       0.1030 ns |       0.0913 ns |          9.741 ns |  0.78 |    0.01 |     0.0019 |         - |        32 B |        1.00 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 2     |         22.616 ns |       0.2217 ns |       0.2074 ns |         22.556 ns |  1.80 |    0.03 |     0.0019 |         - |        32 B |        1.00 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **4**     |         **30.422 ns** |       **0.4477 ns** |       **0.4187 ns** |         **30.451 ns** |  **1.00** |    **0.02** |     **0.0057** |         **-** |        **96 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 4     |         26.949 ns |       0.1689 ns |       0.1497 ns |         26.938 ns |  0.89 |    0.01 |     0.0081 |         - |       136 B |        1.42 |
| BuildStringWithStringBuilderPrecalc                     | 4     |         26.340 ns |       0.3479 ns |       0.3084 ns |         26.398 ns |  0.87 |    0.02 |     0.0067 |         - |       112 B |        1.17 |
| BuildStringWithInterpolation                            | 4     |         30.168 ns |       0.3240 ns |       0.3031 ns |         30.161 ns |  0.99 |    0.02 |     0.0057 |         - |        96 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 4     |         23.854 ns |       0.1760 ns |       0.1646 ns |         23.831 ns |  0.78 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalc                | 4     |         21.017 ns |       0.2483 ns |       0.2323 ns |         20.991 ns |  0.69 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateWithCountKozi                | 4     |         22.674 ns |       0.2273 ns |       0.2126 ns |         22.654 ns |  0.75 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 4     |         16.871 ns |       0.1542 ns |       0.1442 ns |         16.910 ns |  0.55 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 4     |         14.259 ns |       0.2725 ns |       0.2549 ns |         14.258 ns |  0.47 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 4     |         30.587 ns |       0.1880 ns |       0.1666 ns |         30.613 ns |  1.01 |    0.01 |     0.0019 |         - |        32 B |        0.33 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **10**    |         **85.780 ns** |       **0.9371 ns** |       **0.8766 ns** |         **85.901 ns** |  **1.00** |    **0.01** |     **0.0200** |         **-** |       **336 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 10    |         42.008 ns |       0.8708 ns |       1.1323 ns |         41.746 ns |  0.49 |    0.01 |     0.0091 |         - |       152 B |        0.45 |
| BuildStringWithStringBuilderPrecalc                     | 10    |         41.433 ns |       0.6110 ns |       0.5416 ns |         41.332 ns |  0.48 |    0.01 |     0.0086 |         - |       144 B |        0.43 |
| BuildStringWithInterpolation                            | 10    |         84.306 ns |       1.1366 ns |       1.0632 ns |         84.437 ns |  0.98 |    0.02 |     0.0200 |         - |       336 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 10    |         53.969 ns |       0.2343 ns |       0.1957 ns |         54.002 ns |  0.63 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalc                | 10    |         43.491 ns |       0.3148 ns |       0.2944 ns |         43.470 ns |  0.51 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateWithCountKozi                | 10    |         48.111 ns |       0.3049 ns |       0.2852 ns |         48.135 ns |  0.56 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 10    |         32.509 ns |       0.3060 ns |       0.2555 ns |         32.495 ns |  0.38 |    0.00 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10    |         28.883 ns |       0.6095 ns |       1.0675 ns |         29.059 ns |  0.34 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 10    |         54.350 ns |       0.3012 ns |       0.2670 ns |         54.356 ns |  0.63 |    0.01 |     0.0029 |         - |        48 B |        0.14 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **100**   |      **1,717.269 ns** |      **28.1219 ns** |      **26.3052 ns** |      **1,714.473 ns** |  **1.00** |    **0.02** |     **1.2455** |         **-** |     **20856 B** |        **1.00** |
| BuildStringWithStringBuilder                            | 100   |        432.915 ns |       2.3148 ns |       2.0520 ns |        433.404 ns |  0.25 |    0.00 |     0.0763 |         - |      1280 B |        0.06 |
| BuildStringWithStringBuilderPrecalc                     | 100   |        292.694 ns |       2.6082 ns |       2.4398 ns |        292.521 ns |  0.17 |    0.00 |     0.0515 |         - |       864 B |        0.04 |
| BuildStringWithInterpolation                            | 100   |      1,759.056 ns |      24.6120 ns |      23.0221 ns |      1,754.717 ns |  1.02 |    0.02 |     1.2455 |         - |     20856 B |        1.00 |
| BuildStringWithStringCreateAkari                        | 100   |        484.597 ns |       4.2263 ns |       3.9533 ns |        486.265 ns |  0.28 |    0.00 |     0.0238 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalc                | 100   |        381.147 ns |       2.5148 ns |       2.1000 ns |        382.160 ns |  0.22 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateWithCountKozi                | 100   |        426.721 ns |       2.3051 ns |       2.1562 ns |        427.038 ns |  0.25 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 100   |        287.964 ns |       2.8453 ns |       2.6615 ns |        287.935 ns |  0.17 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 100   |        222.848 ns |       1.3295 ns |       1.1102 ns |        223.052 ns |  0.13 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 100   |        409.609 ns |       2.0330 ns |       1.8022 ns |        410.078 ns |  0.24 |    0.00 |     0.0243 |         - |       408 B |        0.02 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **1000**  |    **120,048.296 ns** |   **1,952.8255 ns** |   **1,731.1289 ns** |    **120,054.968 ns** |  **1.00** |    **0.02** |   **168.4570** |    **2.4414** |   **2818056 B** |       **1.000** |
| BuildStringWithStringBuilder                            | 1000  |      5,024.384 ns |      92.0927 ns |     140.6353 ns |      5,000.269 ns |  0.04 |    0.00 |     0.8698 |    0.0229 |     14648 B |       0.005 |
| BuildStringWithStringBuilderPrecalc                     | 1000  |      3,982.230 ns |      49.2731 ns |      46.0901 ns |      4,001.498 ns |  0.03 |    0.00 |     0.6943 |    0.0153 |     11664 B |       0.004 |
| BuildStringWithInterpolation                            | 1000  |    126,501.099 ns |   2,428.5417 ns |   2,699.3177 ns |    126,200.244 ns |  1.05 |    0.03 |   168.4570 |    2.4414 |   2818056 B |       1.000 |
| BuildStringWithStringCreateAkari                        | 1000  |      4,793.795 ns |      41.3796 ns |      38.7065 ns |      4,794.241 ns |  0.04 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalc                | 1000  |      3,810.770 ns |      38.7637 ns |      36.2596 ns |      3,808.135 ns |  0.03 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateWithCountKozi                | 1000  |      4,230.537 ns |      48.1786 ns |      45.0663 ns |      4,223.064 ns |  0.04 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 1000  |      2,938.590 ns |      58.3967 ns |     119.2889 ns |      2,916.964 ns |  0.02 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 1000  |      2,660.306 ns |      52.7625 ns |     141.7430 ns |      2,742.172 ns |  0.02 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 1000  |      4,391.386 ns |      28.0629 ns |      23.4338 ns |      4,397.298 ns |  0.04 |    0.00 |     0.3433 |         - |      5808 B |       0.002 |
|                                                         |       |                   |                 |                 |                   |       |         |            |           |             |             |
| **BuildStringWithConcat**                                   | **10000** | **18,118,182.212 ns** | **272,064.7686 ns** | **227,186.4037 ns** | **18,112,056.250 ns** | **1.000** |    **0.02** | **22562.5000** | **3968.7500** | **379126056 B** |       **1.000** |
| BuildStringWithStringBuilder                            | 10000 |     44,312.846 ns |     420.5989 ns |     372.8499 ns |     44,248.819 ns | 0.002 |    0.00 |     9.4604 |    2.0752 |    159200 B |       0.000 |
| BuildStringWithStringBuilderPrecalc                     | 10000 |     64,838.198 ns |     552.8026 ns |     490.0451 ns |     64,968.433 ns | 0.004 |    0.00 |     9.1553 |         - |    155664 B |       0.000 |
| BuildStringWithInterpolation                            | 10000 | 18,160,528.606 ns | 196,372.8405 ns | 163,980.2156 ns | 18,194,384.375 ns | 1.002 |    0.01 | 22562.5000 | 3968.7500 | 379126056 B |       1.000 |
| BuildStringWithStringCreateAkari                        | 10000 |     46,221.589 ns |     489.1727 ns |     457.5725 ns |     46,309.546 ns | 0.003 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalc                | 10000 |     38,639.717 ns |     469.5921 ns |     439.2568 ns |     38,727.771 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateWithCountKozi                | 10000 |     41,408.576 ns |     441.0755 ns |     391.0020 ns |     41,536.313 ns | 0.002 |    0.00 |     4.5776 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalcKozi            | 10000 |     27,958.355 ns |     458.3658 ns |     428.7557 ns |     28,036.829 ns | 0.002 |    0.00 |     4.6082 |         - |     77808 B |       0.000 |
| BuildStringWithStringCreateLengthPrecalcKoziUnsafeMagic | 10000 |     25,516.962 ns |     312.7574 ns |     292.5535 ns |     25,495.769 ns | 0.001 |    0.00 |     4.6082 |         - |     77808 B |       0.000 |
| BuildStringWithDefaultInterpolatedStringHandler333Fred  | 10000 |     65,396.188 ns |     429.0835 ns |     401.3650 ns |     65,467.163 ns | 0.004 |    0.00 |     4.5166 |         - |     77808 B |       0.000 |
