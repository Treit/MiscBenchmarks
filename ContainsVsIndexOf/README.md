## IndexOf vs. Contains





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Job       | Runtime   | Count  | Mean           | Error        | StdDev       | Median         | Ratio | RatioSD |
|----------------------------------------------------- |---------- |---------- |------- |---------------:|-------------:|-------------:|---------------:|------:|--------:|
| **CountUsingContains**                                   | **.NET 10.0** | **.NET 10.0** | **100**    |       **748.2 ns** |      **5.53 ns** |      **4.91 ns** |       **747.8 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | .NET 10.0 | .NET 10.0 | 100    |       771.0 ns |      3.92 ns |      3.48 ns |       771.8 ns |  1.03 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 100    |       592.1 ns |      5.44 ns |      5.09 ns |       593.9 ns |  0.79 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | .NET 10.0 | .NET 10.0 | 100    |     1,648.2 ns |      8.55 ns |      7.58 ns |     1,650.0 ns |  2.20 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 100    |     1,744.0 ns |      9.06 ns |      8.48 ns |     1,743.9 ns |  2.33 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 10.0 | .NET 10.0 | 100    |     1,539.7 ns |      5.64 ns |      5.00 ns |     1,541.0 ns |  2.06 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 100    |     1,663.7 ns |      9.16 ns |      7.65 ns |     1,665.8 ns |  2.22 |    0.02 |
| CountUsingIndexOf                                    | .NET 10.0 | .NET 10.0 | 100    |     1,831.4 ns |      5.84 ns |      5.46 ns |     1,831.8 ns |  2.45 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | .NET 10.0 | .NET 10.0 | 100    |     1,493.1 ns |      8.83 ns |      8.26 ns |     1,497.9 ns |  2.00 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 10.0 | .NET 10.0 | 100    |     1,676.5 ns |     10.61 ns |      8.86 ns |     1,675.4 ns |  2.24 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 10.0 | .NET 10.0 | 100    |     1,891.7 ns |     18.75 ns |     17.54 ns |     1,894.4 ns |  2.53 |    0.03 |
| CountUsingIndexOfOrdinal                             | .NET 10.0 | .NET 10.0 | 100    |       764.1 ns |      3.88 ns |      3.44 ns |       765.2 ns |  1.02 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 10.0 | .NET 10.0 | 100    |       533.0 ns |      4.17 ns |      3.90 ns |       534.1 ns |  0.71 |    0.01 |
|                                                      |           |           |        |                |              |              |                |       |         |
| CountUsingContains                                   | .NET 9.0  | .NET 9.0  | 100    |       749.9 ns |      3.46 ns |      3.24 ns |       750.6 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinal                    | .NET 9.0  | .NET 9.0  | 100    |       793.7 ns |      4.36 ns |      3.64 ns |       795.0 ns |  1.06 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 100    |       546.0 ns |      5.03 ns |      4.46 ns |       548.8 ns |  0.73 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | .NET 9.0  | .NET 9.0  | 100    |     1,681.8 ns |      5.71 ns |      5.34 ns |     1,683.8 ns |  2.24 |    0.01 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 100    |     1,856.0 ns |      9.34 ns |      8.28 ns |     1,856.5 ns |  2.48 |    0.01 |
| CountUsingContainsExplicitInvariantCulture           | .NET 9.0  | .NET 9.0  | 100    |     1,494.6 ns |     11.17 ns |      9.33 ns |     1,495.9 ns |  1.99 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 100    |     1,685.2 ns |     13.39 ns |     11.18 ns |     1,684.6 ns |  2.25 |    0.02 |
| CountUsingIndexOf                                    | .NET 9.0  | .NET 9.0  | 100    |     1,809.8 ns |      3.90 ns |      3.46 ns |     1,809.9 ns |  2.41 |    0.01 |
| CountUsingIndexOfInvariantCulture                    | .NET 9.0  | .NET 9.0  | 100    |     1,469.0 ns |     10.92 ns |     10.21 ns |     1,471.0 ns |  1.96 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 9.0  | .NET 9.0  | 100    |     1,637.4 ns |      6.35 ns |      5.94 ns |     1,637.7 ns |  2.18 |    0.01 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 9.0  | .NET 9.0  | 100    |     1,846.9 ns |      9.31 ns |      8.71 ns |     1,847.5 ns |  2.46 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 9.0  | .NET 9.0  | 100    |       747.8 ns |      4.55 ns |      4.04 ns |       748.9 ns |  1.00 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 9.0  | .NET 9.0  | 100    |       564.8 ns |      5.47 ns |      5.11 ns |       565.5 ns |  0.75 |    0.01 |
|                                                      |           |           |        |                |              |              |                |       |         |
| **CountUsingContains**                                   | **.NET 10.0** | **.NET 10.0** | **1000**   |     **7,233.7 ns** |     **27.59 ns** |     **23.03 ns** |     **7,236.2 ns** |  **1.00** |    **0.00** |
| CountUsingContainsExplicitOrdinal                    | .NET 10.0 | .NET 10.0 | 1000   |     7,262.2 ns |     70.49 ns |     65.94 ns |     7,251.1 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 1000   |     5,136.0 ns |     35.37 ns |     33.09 ns |     5,149.9 ns |  0.71 |    0.00 |
| CountUsingContainsExplicitCurrentCulture             | .NET 10.0 | .NET 10.0 | 1000   |    18,258.7 ns |    201.98 ns |    188.93 ns |    18,242.2 ns |  2.52 |    0.03 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 1000   |    20,189.1 ns |    124.59 ns |    116.54 ns |    20,245.4 ns |  2.79 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 10.0 | .NET 10.0 | 1000   |    16,643.8 ns |    144.49 ns |    135.15 ns |    16,671.9 ns |  2.30 |    0.02 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 1000   |    18,270.0 ns |    185.93 ns |    173.92 ns |    18,331.3 ns |  2.53 |    0.02 |
| CountUsingIndexOf                                    | .NET 10.0 | .NET 10.0 | 1000   |    19,320.8 ns |    135.67 ns |    126.91 ns |    19,379.7 ns |  2.67 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | .NET 10.0 | .NET 10.0 | 1000   |    17,145.4 ns |    124.55 ns |    116.50 ns |    17,226.3 ns |  2.37 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 10.0 | .NET 10.0 | 1000   |    18,392.7 ns |    152.23 ns |    142.40 ns |    18,450.5 ns |  2.54 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 10.0 | .NET 10.0 | 1000   |    20,785.6 ns |    169.08 ns |    158.16 ns |    20,788.6 ns |  2.87 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 10.0 | .NET 10.0 | 1000   |     7,237.8 ns |     31.25 ns |     26.09 ns |     7,235.9 ns |  1.00 |    0.00 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 10.0 | .NET 10.0 | 1000   |     5,013.9 ns |     61.71 ns |     57.73 ns |     4,997.0 ns |  0.69 |    0.01 |
|                                                      |           |           |        |                |              |              |                |       |         |
| CountUsingContains                                   | .NET 9.0  | .NET 9.0  | 1000   |     7,197.9 ns |     41.92 ns |     37.16 ns |     7,185.2 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinal                    | .NET 9.0  | .NET 9.0  | 1000   |     7,235.2 ns |     18.45 ns |     17.26 ns |     7,233.7 ns |  1.01 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 1000   |     4,968.4 ns |     39.90 ns |     37.32 ns |     4,976.2 ns |  0.69 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | .NET 9.0  | .NET 9.0  | 1000   |    18,231.5 ns |    155.03 ns |    145.02 ns |    18,300.7 ns |  2.53 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 1000   |    20,202.7 ns |    122.21 ns |    114.32 ns |    20,256.2 ns |  2.81 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 9.0  | .NET 9.0  | 1000   |    16,650.9 ns |    181.10 ns |    169.40 ns |    16,736.3 ns |  2.31 |    0.03 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 1000   |    18,304.1 ns |    147.33 ns |    137.81 ns |    18,380.8 ns |  2.54 |    0.02 |
| CountUsingIndexOf                                    | .NET 9.0  | .NET 9.0  | 1000   |    19,275.6 ns |    128.69 ns |    120.37 ns |    19,327.0 ns |  2.68 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | .NET 9.0  | .NET 9.0  | 1000   |    17,051.3 ns |    138.29 ns |    122.59 ns |    17,043.2 ns |  2.37 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 9.0  | .NET 9.0  | 1000   |    18,395.5 ns |    171.97 ns |    160.86 ns |    18,467.8 ns |  2.56 |    0.03 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 9.0  | .NET 9.0  | 1000   |    20,638.7 ns |    109.08 ns |    102.03 ns |    20,676.8 ns |  2.87 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 9.0  | .NET 9.0  | 1000   |     7,129.5 ns |     27.89 ns |     24.72 ns |     7,134.4 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 9.0  | .NET 9.0  | 1000   |     5,107.1 ns |     59.71 ns |     55.85 ns |     5,115.5 ns |  0.71 |    0.01 |
|                                                      |           |           |        |                |              |              |                |       |         |
| **CountUsingContains**                                   | **.NET 10.0** | **.NET 10.0** | **10000**  |   **100,807.1 ns** |  **1,097.25 ns** |  **1,026.37 ns** |   **100,540.5 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | .NET 10.0 | .NET 10.0 | 10000  |    96,607.5 ns |  1,080.90 ns |    958.19 ns |    96,506.8 ns |  0.96 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 10000  |    66,708.0 ns |  1,304.66 ns |  2,179.80 ns |    66,874.7 ns |  0.66 |    0.02 |
| CountUsingContainsExplicitCurrentCulture             | .NET 10.0 | .NET 10.0 | 10000  |   195,830.1 ns |  1,010.97 ns |    896.20 ns |   195,905.1 ns |  1.94 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 10000  |   212,504.1 ns |  1,159.89 ns |    968.56 ns |   212,511.7 ns |  2.11 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 10.0 | .NET 10.0 | 10000  |   181,588.7 ns |    937.22 ns |    876.67 ns |   181,976.3 ns |  1.80 |    0.02 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 10000  |   201,496.4 ns |    958.10 ns |    896.21 ns |   201,707.0 ns |  2.00 |    0.02 |
| CountUsingIndexOf                                    | .NET 10.0 | .NET 10.0 | 10000  |   203,771.5 ns |    964.15 ns |    854.69 ns |   204,072.3 ns |  2.02 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | .NET 10.0 | .NET 10.0 | 10000  |   181,814.5 ns |  1,048.41 ns |    980.68 ns |   181,900.3 ns |  1.80 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 10.0 | .NET 10.0 | 10000  |   201,784.8 ns |  1,255.83 ns |    980.47 ns |   201,811.1 ns |  2.00 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 10.0 | .NET 10.0 | 10000  |   222,803.1 ns |    608.29 ns |    507.95 ns |   222,917.7 ns |  2.21 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 10.0 | .NET 10.0 | 10000  |    97,233.1 ns |  1,010.12 ns |    843.49 ns |    97,370.4 ns |  0.96 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 10.0 | .NET 10.0 | 10000  |    69,470.0 ns |  1,302.52 ns |  1,337.59 ns |    69,675.7 ns |  0.69 |    0.01 |
|                                                      |           |           |        |                |              |              |                |       |         |
| CountUsingContains                                   | .NET 9.0  | .NET 9.0  | 10000  |    98,433.4 ns |    794.44 ns |    743.12 ns |    98,272.8 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinal                    | .NET 9.0  | .NET 9.0  | 10000  |    95,345.1 ns |    879.04 ns |    822.26 ns |    95,513.5 ns |  0.97 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 10000  |    70,547.8 ns |  1,385.65 ns |  2,031.07 ns |    71,044.6 ns |  0.72 |    0.02 |
| CountUsingContainsExplicitCurrentCulture             | .NET 9.0  | .NET 9.0  | 10000  |   193,022.1 ns |  1,217.12 ns |  1,078.94 ns |   193,329.6 ns |  1.96 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 10000  |   219,064.2 ns |    989.60 ns |    925.68 ns |   218,987.7 ns |  2.23 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 9.0  | .NET 9.0  | 10000  |   181,712.0 ns |  1,101.92 ns |  1,030.74 ns |   182,085.1 ns |  1.85 |    0.02 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 10000  |   201,820.1 ns |    730.54 ns |    647.60 ns |   201,973.1 ns |  2.05 |    0.02 |
| CountUsingIndexOf                                    | .NET 9.0  | .NET 9.0  | 10000  |   202,061.5 ns |    709.37 ns |    592.36 ns |   202,056.9 ns |  2.05 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | .NET 9.0  | .NET 9.0  | 10000  |   181,405.6 ns |  1,034.53 ns |    967.70 ns |   181,793.6 ns |  1.84 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 9.0  | .NET 9.0  | 10000  |   203,088.3 ns |    886.12 ns |    828.87 ns |   203,432.6 ns |  2.06 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 9.0  | .NET 9.0  | 10000  |   223,209.4 ns |    857.64 ns |    802.24 ns |   223,396.2 ns |  2.27 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 9.0  | .NET 9.0  | 10000  |    97,554.6 ns |    894.63 ns |    836.84 ns |    97,600.7 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 9.0  | .NET 9.0  | 10000  |    68,868.7 ns |  1,376.78 ns |  1,884.55 ns |    68,616.6 ns |  0.70 |    0.02 |
|                                                      |           |           |        |                |              |              |                |       |         |
| **CountUsingContains**                                   | **.NET 10.0** | **.NET 10.0** | **100000** | **1,094,202.0 ns** |  **9,116.08 ns** |  **8,527.18 ns** | **1,098,612.3 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | .NET 10.0 | .NET 10.0 | 100000 | 1,093,583.5 ns |  8,410.58 ns |  7,867.26 ns | 1,099,703.3 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 10.0 | .NET 10.0 | 100000 |   917,794.1 ns |  4,127.63 ns |  3,860.99 ns |   918,219.0 ns |  0.84 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | .NET 10.0 | .NET 10.0 | 100000 | 2,044,598.0 ns | 23,308.69 ns | 21,802.97 ns | 2,052,778.5 ns |  1.87 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 10.0 | .NET 10.0 | 100000 | 2,323,518.7 ns | 15,452.49 ns | 14,454.27 ns | 2,327,528.5 ns |  2.12 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 10.0 | .NET 10.0 | 100000 | 1,910,480.7 ns |  6,743.17 ns |  6,307.56 ns | 1,912,782.0 ns |  1.75 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 10.0 | .NET 10.0 | 100000 | 2,158,914.9 ns | 18,487.00 ns | 17,292.75 ns | 2,169,041.0 ns |  1.97 |    0.02 |
| CountUsingIndexOf                                    | .NET 10.0 | .NET 10.0 | 100000 | 2,129,367.3 ns | 29,384.83 ns | 26,048.89 ns | 2,131,529.7 ns |  1.95 |    0.03 |
| CountUsingIndexOfInvariantCulture                    | .NET 10.0 | .NET 10.0 | 100000 | 1,907,718.2 ns |  6,328.90 ns |  5,920.06 ns | 1,910,182.2 ns |  1.74 |    0.01 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 10.0 | .NET 10.0 | 100000 | 2,194,493.1 ns | 18,988.35 ns | 17,761.72 ns | 2,200,199.6 ns |  2.01 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 10.0 | .NET 10.0 | 100000 | 2,377,999.3 ns | 16,745.62 ns | 15,663.87 ns | 2,382,498.0 ns |  2.17 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 10.0 | .NET 10.0 | 100000 | 1,079,343.3 ns |  7,575.84 ns |  7,086.44 ns | 1,084,390.6 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 10.0 | .NET 10.0 | 100000 |   892,947.0 ns |  2,208.46 ns |  1,957.74 ns |   893,325.5 ns |  0.82 |    0.01 |
|                                                      |           |           |        |                |              |              |                |       |         |
| CountUsingContains                                   | .NET 9.0  | .NET 9.0  | 100000 | 1,088,217.2 ns |  9,274.06 ns |  8,674.96 ns | 1,091,268.4 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinal                    | .NET 9.0  | .NET 9.0  | 100000 | 1,095,103.8 ns | 10,115.99 ns |  9,462.50 ns | 1,097,971.0 ns |  1.01 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | .NET 9.0  | .NET 9.0  | 100000 |   916,133.3 ns |  3,796.26 ns |  3,365.28 ns |   917,136.5 ns |  0.84 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | .NET 9.0  | .NET 9.0  | 100000 | 2,045,776.6 ns | 17,386.03 ns | 16,262.90 ns | 2,053,178.1 ns |  1.88 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | .NET 9.0  | .NET 9.0  | 100000 | 2,258,346.8 ns | 18,480.46 ns | 17,286.64 ns | 2,265,455.5 ns |  2.08 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | .NET 9.0  | .NET 9.0  | 100000 | 1,884,025.5 ns |  4,995.11 ns |  4,428.04 ns | 1,884,895.1 ns |  1.73 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | .NET 9.0  | .NET 9.0  | 100000 | 2,149,925.0 ns | 19,396.07 ns | 18,143.10 ns | 2,155,020.7 ns |  1.98 |    0.02 |
| CountUsingIndexOf                                    | .NET 9.0  | .NET 9.0  | 100000 | 2,152,194.4 ns | 15,713.81 ns | 14,698.71 ns | 2,156,146.5 ns |  1.98 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | .NET 9.0  | .NET 9.0  | 100000 | 1,907,444.9 ns |  5,677.61 ns |  5,033.06 ns | 1,908,807.1 ns |  1.75 |    0.01 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | .NET 9.0  | .NET 9.0  | 100000 | 2,146,490.2 ns | 15,461.01 ns | 14,462.24 ns | 2,155,336.5 ns |  1.97 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | .NET 9.0  | .NET 9.0  | 100000 | 2,348,651.1 ns | 20,353.44 ns | 19,038.62 ns | 2,353,716.8 ns |  2.16 |    0.02 |
| CountUsingIndexOfOrdinal                             | .NET 9.0  | .NET 9.0  | 100000 | 1,082,675.7 ns |  9,788.83 ns |  9,156.48 ns | 1,087,637.1 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | .NET 9.0  | .NET 9.0  | 100000 |   889,567.3 ns |  4,024.46 ns |  3,764.48 ns |   890,620.8 ns |  0.82 |    0.01 |
