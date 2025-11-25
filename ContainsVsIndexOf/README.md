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
| **CountUsingContains**                                   | **100**    |       **759.0 ns** |      **3.49 ns** |      **3.09 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | 100    |       748.4 ns |      5.87 ns |      5.20 ns |  0.99 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 100    |       502.4 ns |      5.97 ns |      5.59 ns |  0.66 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | 100    |     1,681.6 ns |     18.12 ns |     16.95 ns |  2.22 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 100    |     1,765.1 ns |     12.23 ns |     11.44 ns |  2.33 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | 100    |     1,495.1 ns |     10.54 ns |      9.34 ns |  1.97 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 100    |     1,659.8 ns |     17.05 ns |     15.95 ns |  2.19 |    0.02 |
| CountUsingIndexOf                                    | 100    |     1,793.0 ns |      7.68 ns |      7.19 ns |  2.36 |    0.01 |
| CountUsingIndexOfInvariantCulture                    | 100    |     1,480.9 ns |     11.39 ns |      9.51 ns |  1.95 |    0.01 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 100    |     1,572.3 ns |     11.19 ns |     10.46 ns |  2.07 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 100    |     1,861.2 ns |     19.36 ns |     18.11 ns |  2.45 |    0.03 |
| CountUsingIndexOfOrdinal                             | 100    |       750.2 ns |      2.90 ns |      2.57 ns |  0.99 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 100    |       490.5 ns |      5.15 ns |      4.82 ns |  0.65 |    0.01 |
|                                                      |        |                |              |              |       |         |
| **CountUsingContains**                                   | **1000**   |     **7,193.6 ns** |     **36.47 ns** |     **28.47 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | 1000   |     7,450.5 ns |     60.86 ns |     50.82 ns |  1.04 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 1000   |     4,943.7 ns |     40.34 ns |     37.74 ns |  0.69 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | 1000   |    18,331.7 ns |    179.35 ns |    167.77 ns |  2.55 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 1000   |    20,225.2 ns |    117.71 ns |    104.35 ns |  2.81 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | 1000   |    16,563.4 ns |    154.86 ns |    144.86 ns |  2.30 |    0.02 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 1000   |    18,269.8 ns |    137.15 ns |    128.29 ns |  2.54 |    0.02 |
| CountUsingIndexOf                                    | 1000   |    19,288.1 ns |    120.22 ns |    112.46 ns |  2.68 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | 1000   |    16,618.9 ns |    146.30 ns |    136.85 ns |  2.31 |    0.02 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 1000   |    18,626.6 ns |    132.53 ns |    123.97 ns |  2.59 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 1000   |    20,577.4 ns |    235.60 ns |    220.38 ns |  2.86 |    0.03 |
| CountUsingIndexOfOrdinal                             | 1000   |     7,273.3 ns |    143.17 ns |    147.02 ns |  1.01 |    0.02 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 1000   |     4,956.9 ns |     31.41 ns |     27.84 ns |  0.69 |    0.00 |
|                                                      |        |                |              |              |       |         |
| **CountUsingContains**                                   | **10000**  |    **99,860.9 ns** |  **1,975.86 ns** |  **1,940.56 ns** |  **1.00** |    **0.03** |
| CountUsingContainsExplicitOrdinal                    | 10000  |    97,147.4 ns |    822.56 ns |    642.20 ns |  0.97 |    0.02 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 10000  |    75,964.2 ns |  1,509.74 ns |  1,854.10 ns |  0.76 |    0.02 |
| CountUsingContainsExplicitCurrentCulture             | 10000  |   191,782.0 ns |    766.27 ns |    716.77 ns |  1.92 |    0.04 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 10000  |   212,121.2 ns |  1,093.93 ns |    969.74 ns |  2.12 |    0.04 |
| CountUsingContainsExplicitInvariantCulture           | 10000  |   176,829.5 ns |  1,168.49 ns |  1,093.00 ns |  1.77 |    0.03 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 10000  |   201,267.3 ns |  1,111.66 ns |    867.91 ns |  2.02 |    0.04 |
| CountUsingIndexOf                                    | 10000  |   200,850.2 ns |    845.51 ns |    749.52 ns |  2.01 |    0.04 |
| CountUsingIndexOfInvariantCulture                    | 10000  |   181,129.6 ns |    809.48 ns |    717.58 ns |  1.81 |    0.03 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 10000  |   202,188.1 ns |    870.76 ns |    679.83 ns |  2.03 |    0.04 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 10000  |   223,453.8 ns |  1,073.74 ns |    896.62 ns |  2.24 |    0.04 |
| CountUsingIndexOfOrdinal                             | 10000  |    99,335.3 ns |    917.85 ns |    813.65 ns |  1.00 |    0.02 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 10000  |    73,440.6 ns |  1,461.40 ns |  2,635.21 ns |  0.74 |    0.03 |
|                                                      |        |                |              |              |       |         |
| **CountUsingContains**                                   | **100000** | **1,095,408.2 ns** |  **8,058.33 ns** |  **7,537.76 ns** |  **1.00** |    **0.01** |
| CountUsingContainsExplicitOrdinal                    | 100000 | 1,090,444.3 ns |  8,857.24 ns |  8,285.06 ns |  1.00 |    0.01 |
| CountUsingContainsExplicitOrdinalIgnoreCase          | 100000 |   916,442.7 ns |  2,235.92 ns |  1,867.09 ns |  0.84 |    0.01 |
| CountUsingContainsExplicitCurrentCulture             | 100000 | 2,046,750.0 ns | 21,687.30 ns | 20,286.32 ns |  1.87 |    0.02 |
| CountUsingContainsExplicitCurrentCultureIgnoreCase   | 100000 | 2,312,290.9 ns | 18,490.94 ns | 17,296.44 ns |  2.11 |    0.02 |
| CountUsingContainsExplicitInvariantCulture           | 100000 | 1,898,327.4 ns |  2,667.94 ns |  2,365.06 ns |  1.73 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 100000 | 2,125,252.9 ns | 15,926.59 ns | 14,897.74 ns |  1.94 |    0.02 |
| CountUsingIndexOf                                    | 100000 | 2,108,996.6 ns | 20,360.65 ns | 19,045.36 ns |  1.93 |    0.02 |
| CountUsingIndexOfInvariantCulture                    | 100000 | 1,878,858.2 ns |  7,787.38 ns |  6,502.81 ns |  1.72 |    0.01 |
| CountUsingIndexOfInvariantCultureIgnoreCase          | 100000 | 2,182,993.9 ns | 17,809.00 ns | 16,658.55 ns |  1.99 |    0.02 |
| CountUsingIndexOfCurrentCultureIgnoreCase            | 100000 | 2,365,632.1 ns | 15,913.80 ns | 14,885.78 ns |  2.16 |    0.02 |
| CountUsingIndexOfOrdinal                             | 100000 | 1,103,149.8 ns |  9,519.05 ns |  8,904.12 ns |  1.01 |    0.01 |
| CountUsingIndexOfOrdinalIgnoreCase                   | 100000 |   905,473.1 ns |  1,807.72 ns |  1,690.95 ns |  0.83 |    0.01 |
