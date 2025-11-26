## IndexOf vs. Contains




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                               | Count  | Mean           | Error        | StdDev       | Ratio | RatioSD |
|----------------------------------------------------- |------- |---------------:|-------------:|-------------:|------:|--------:|
| **CountUsingContains**                                   | **100**    |       **760.7 ns** |      **6.63 ns** |      **5.88 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | 100    |       759.1 ns |      2.92 ns |      2.73 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 100    |       518.7 ns |      3.92 ns |      3.67 ns |  0.68 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | 100    |     1,654.3 ns |     14.78 ns |     13.83 ns |  2.17 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 100    |     1,804.8 ns |      4.27 ns |      3.57 ns |  2.37 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | 100    |     1,571.1 ns |     11.87 ns |     11.11 ns |  2.07 |    0.02 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 100    |     1,635.9 ns |      3.95 ns |      3.50 ns |  2.15 |    0.02 |
| CountUsingIndexOf                                    | 100    |     1,715.8 ns |      8.49 ns |      7.52 ns |  2.26 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | 100    |     1,519.7 ns |      9.31 ns |      8.71 ns |  2.00 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 100    |     1,597.6 ns |      7.08 ns |      6.27 ns |  2.10 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 100    |     1,859.0 ns |     16.28 ns |     15.23 ns |  2.44 |    0.03 |
| CountUsingIndexOfOrdinal                             | 100    |       755.8 ns |      5.23 ns |      4.89 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 100    |       533.3 ns |      4.32 ns |      3.61 ns |  0.70 |    0.01 |
|                                                      |        |                |              |              |       |         |
| **CountUsingContains**                                   | **1000**   |     **7,290.0 ns** |    **119.86 ns** |    **106.25 ns** |  **1.00** |    **0.02** |
| CountUsingContainsExplicitOrdinal                    | 1000   |     7,316.3 ns |     17.48 ns |     15.50 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 1000   |     5,366.6 ns |     29.03 ns |     27.16 ns |  0.74 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | 1000   |    18,028.1 ns |    138.85 ns |    129.88 ns |  2.47 |    0.04 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 1000   |    20,292.5 ns |    278.27 ns |    246.68 ns |  2.78 |    0.05 |
| CountUsingContainsExplicitInvariantCulture           | 1000   |    16,668.7 ns |    151.52 ns |    141.73 ns |  2.29 |    0.04 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 1000   |    18,188.0 ns |    148.36 ns |    138.78 ns |  2.50 |    0.04 |
| CountUsingIndexOf                                    | 1000   |    19,218.0 ns |    155.29 ns |    145.25 ns |  2.64 |    0.04 |
| CountUsingIndexOfInvariantCulture                    | 1000   |    16,649.6 ns |    140.14 ns |    131.09 ns |  2.28 |    0.04 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 1000   |    18,336.8 ns |    135.69 ns |    126.93 ns |  2.52 |    0.04 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 1000   |    21,272.0 ns |    183.04 ns |    162.26 ns |  2.92 |    0.05 |
| CountUsingIndexOfOrdinal                             | 1000   |     7,263.0 ns |     21.85 ns |     19.37 ns |  1.00 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 1000   |     5,004.1 ns |     30.40 ns |     28.44 ns |  0.69 |    0.01 |
|                                                      |        |                |              |              |       |         |
| **CountUsingContains**                                   | **10000**  |    **97,988.1 ns** |    **653.78 ns** |    **611.54 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | 10000  |    97,755.0 ns |    667.40 ns |    624.28 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 10000  |    69,490.4 ns |  1,369.23 ns |  2,131.72 ns |  0.71 |    0.02 |
| CountUsingContainsExplicitCurrentCulture             | 10000  |   192,815.4 ns |    754.68 ns |    705.93 ns |  1.97 |    0.01 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 10000  |   218,944.9 ns |    822.01 ns |    728.69 ns |  2.23 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | 10000  |   181,372.0 ns |    939.68 ns |    878.98 ns |  1.85 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 10000  |   201,733.6 ns |    800.97 ns |    749.23 ns |  2.06 |    0.01 |
| CountUsingIndexOf                                    | 10000  |   201,014.2 ns |    565.65 ns |    472.34 ns |  2.05 |    0.01 |
| CountUsingIndexOfInvariantCulture                    | 10000  |   181,631.2 ns |  1,199.27 ns |  1,121.80 ns |  1.85 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 10000  |   203,591.9 ns |    799.40 ns |    708.65 ns |  2.08 |    0.01 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 10000  |   220,530.6 ns |  1,026.66 ns |    960.34 ns |  2.25 |    0.02 |
| CountUsingIndexOfOrdinal                             | 10000  |    96,819.8 ns |    808.38 ns |    756.16 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 10000  |    69,300.4 ns |  1,371.54 ns |  2,010.38 ns |  0.71 |    0.02 |
|                                                      |        |                |              |              |       |         |
| **CountUsingContains**                                   | **100000** | **1,099,272.2 ns** |  **7,936.63 ns** |  **7,423.93 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | 100000 | 1,096,506.4 ns |  6,577.84 ns |  6,152.92 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 100000 |   890,488.2 ns |  2,018.67 ns |  1,685.68 ns |  0.81 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | 100000 | 2,036,792.2 ns | 18,089.29 ns | 16,920.73 ns |  1.85 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 100000 | 2,263,086.3 ns | 14,712.34 ns | 13,042.11 ns |  2.06 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | 100000 | 1,907,509.3 ns |  3,766.95 ns |  3,523.61 ns |  1.74 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 100000 | 2,139,358.0 ns | 18,069.07 ns | 16,901.82 ns |  1.95 |    0.02 |
| CountUsingIndexOf                                    | 100000 | 2,119,317.5 ns | 19,685.45 ns | 17,450.64 ns |  1.93 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | 100000 | 1,907,529.5 ns |  5,196.24 ns |  4,606.33 ns |  1.74 |    0.01 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 100000 | 2,144,916.0 ns | 15,919.31 ns | 14,112.06 ns |  1.95 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 100000 | 2,377,741.2 ns | 20,236.34 ns | 18,929.08 ns |  2.16 |    0.02 |
| CountUsingIndexOfOrdinal                             | 100000 | 1,106,615.4 ns |  6,953.01 ns |  6,503.85 ns |  1.01 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 100000 |   894,507.1 ns |  3,066.41 ns |  2,868.32 ns |  0.81 |    0.01 |
