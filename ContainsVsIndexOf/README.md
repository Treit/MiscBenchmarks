## IndexOf vs. Contains


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                               Method |  Count |           Mean |        Error |      StdDev | Ratio | RatioSD |
|----------------------------------------------------- |------- |---------------:|-------------:|------------:|------:|--------:|
|                                   **CountUsingContains** |    **100** |       **795.7 ns** |      **5.43 ns** |     **5.08 ns** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal |    100 |       799.8 ns |      4.65 ns |     4.13 ns |  1.01 |    0.01 |
|          CountUsingContainsExplicitOrdinalIgnoreCase |    100 |     1,246.1 ns |      7.03 ns |     5.87 ns |  1.57 |    0.01 |
|             CountUsingContainsExplicitCurrentCulture |    100 |     2,250.7 ns |      5.35 ns |     5.00 ns |  2.83 |    0.02 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase |    100 |     2,360.4 ns |      5.17 ns |     4.58 ns |  2.97 |    0.02 |
|           CountUsingContainsExplicitInvariantCulture |    100 |     2,174.4 ns |     11.78 ns |    11.02 ns |  2.73 |    0.02 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase |    100 |     2,260.1 ns |     16.87 ns |    14.96 ns |  2.84 |    0.03 |
|                                    CountUsingIndexOf |    100 |     2,246.2 ns |      9.01 ns |     7.04 ns |  2.82 |    0.02 |
|                    CountUsingIndexOfInvariantCulture |    100 |     2,132.7 ns |      9.83 ns |     9.19 ns |  2.68 |    0.02 |
|          CountUsingIndexOfInvariantCultureIgnoreCase |    100 |     2,206.2 ns |     10.32 ns |     9.65 ns |  2.77 |    0.02 |
|            CountUsingIndexOfCurrentCultureIgnoreCase |    100 |     2,356.6 ns |      8.82 ns |     8.25 ns |  2.96 |    0.02 |
|                             CountUsingIndexOfOrdinal |    100 |       844.9 ns |      7.79 ns |     7.28 ns |  1.06 |    0.01 |
|                   CountUsingIndexOfOrdinalIgnoreCase |    100 |     1,220.6 ns |     10.12 ns |     9.46 ns |  1.53 |    0.02 |
|                                                      |        |                |              |             |       |         |
|                                   **CountUsingContains** |   **1000** |     **8,477.4 ns** |    **166.13 ns** |   **170.61 ns** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal |   1000 |     8,689.0 ns |    166.49 ns |   178.15 ns |  1.03 |    0.03 |
|          CountUsingContainsExplicitOrdinalIgnoreCase |   1000 |    11,452.5 ns |     20.49 ns |    18.16 ns |  1.35 |    0.03 |
|             CountUsingContainsExplicitCurrentCulture |   1000 |    24,178.3 ns |     31.69 ns |    28.09 ns |  2.85 |    0.06 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase |   1000 |    24,811.3 ns |     38.17 ns |    33.84 ns |  2.93 |    0.06 |
|           CountUsingContainsExplicitInvariantCulture |   1000 |    23,312.2 ns |     58.99 ns |    55.18 ns |  2.75 |    0.06 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase |   1000 |    24,030.6 ns |     33.74 ns |    28.17 ns |  2.83 |    0.06 |
|                                    CountUsingIndexOf |   1000 |    24,160.6 ns |     39.77 ns |    37.20 ns |  2.85 |    0.06 |
|                    CountUsingIndexOfInvariantCulture |   1000 |    22,799.1 ns |     27.49 ns |    25.71 ns |  2.69 |    0.05 |
|          CountUsingIndexOfInvariantCultureIgnoreCase |   1000 |    23,956.1 ns |     31.50 ns |    27.92 ns |  2.83 |    0.06 |
|            CountUsingIndexOfCurrentCultureIgnoreCase |   1000 |    25,266.4 ns |     34.95 ns |    30.98 ns |  2.98 |    0.06 |
|                             CountUsingIndexOfOrdinal |   1000 |     8,493.2 ns |    160.15 ns |   149.80 ns |  1.00 |    0.02 |
|                   CountUsingIndexOfOrdinalIgnoreCase |   1000 |    11,450.0 ns |     18.74 ns |    16.61 ns |  1.35 |    0.03 |
|                                                      |        |                |              |             |       |         |
|                                   **CountUsingContains** |  **10000** |   **110,706.5 ns** |    **409.59 ns** |   **383.13 ns** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal |  10000 |   111,050.0 ns |    738.59 ns |   690.88 ns |  1.00 |    0.01 |
|          CountUsingContainsExplicitOrdinalIgnoreCase |  10000 |   143,732.1 ns |  2,125.58 ns | 1,988.27 ns |  1.30 |    0.02 |
|             CountUsingContainsExplicitCurrentCulture |  10000 |   295,388.6 ns |  3,589.89 ns | 3,357.99 ns |  2.67 |    0.03 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase |  10000 |   272,158.3 ns |    344.56 ns |   287.73 ns |  2.46 |    0.01 |
|           CountUsingContainsExplicitInvariantCulture |  10000 |   239,955.5 ns |    395.13 ns |   350.27 ns |  2.17 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase |  10000 |   257,712.5 ns |    161.03 ns |   125.72 ns |  2.33 |    0.01 |
|                                    CountUsingIndexOf |  10000 |   254,466.7 ns |  1,209.85 ns | 1,131.69 ns |  2.30 |    0.01 |
|                    CountUsingIndexOfInvariantCulture |  10000 |   240,531.2 ns |    275.84 ns |   230.34 ns |  2.17 |    0.01 |
|          CountUsingIndexOfInvariantCultureIgnoreCase |  10000 |   256,144.8 ns |    266.28 ns |   236.05 ns |  2.31 |    0.01 |
|            CountUsingIndexOfCurrentCultureIgnoreCase |  10000 |   273,169.4 ns |    283.03 ns |   236.34 ns |  2.47 |    0.01 |
|                             CountUsingIndexOfOrdinal |  10000 |   111,154.1 ns |    804.82 ns |   752.83 ns |  1.00 |    0.01 |
|                   CountUsingIndexOfOrdinalIgnoreCase |  10000 |   143,467.9 ns |    885.53 ns |   739.46 ns |  1.30 |    0.01 |
|                                                      |        |                |              |             |       |         |
|                                   **CountUsingContains** | **100000** | **1,214,052.5 ns** |  **3,135.03 ns** | **2,932.51 ns** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal | 100000 | 1,218,328.1 ns |  3,079.63 ns | 2,880.68 ns |  1.00 |    0.00 |
|          CountUsingContainsExplicitOrdinalIgnoreCase | 100000 | 1,579,285.6 ns |  2,612.99 ns | 2,316.35 ns |  1.30 |    0.00 |
|             CountUsingContainsExplicitCurrentCulture | 100000 | 2,641,498.0 ns |  3,512.05 ns | 2,741.98 ns |  2.18 |    0.01 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase | 100000 | 2,864,034.9 ns |  3,267.86 ns | 3,056.75 ns |  2.36 |    0.01 |
|           CountUsingContainsExplicitInvariantCulture | 100000 | 2,500,675.4 ns |  9,030.08 ns | 8,446.74 ns |  2.06 |    0.01 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 100000 | 2,787,778.2 ns |  3,011.75 ns | 2,817.19 ns |  2.30 |    0.01 |
|                                    CountUsingIndexOf | 100000 | 2,640,876.6 ns |  3,190.23 ns | 2,663.99 ns |  2.17 |    0.01 |
|                    CountUsingIndexOfInvariantCulture | 100000 | 2,518,651.0 ns | 10,236.92 ns | 9,575.62 ns |  2.07 |    0.01 |
|          CountUsingIndexOfInvariantCultureIgnoreCase | 100000 | 2,728,007.8 ns |  2,630.05 ns | 2,331.47 ns |  2.25 |    0.01 |
|            CountUsingIndexOfCurrentCultureIgnoreCase | 100000 | 2,859,104.7 ns |  2,138.71 ns | 1,895.91 ns |  2.36 |    0.01 |
|                             CountUsingIndexOfOrdinal | 100000 | 1,190,716.0 ns |  1,316.62 ns | 1,099.44 ns |  0.98 |    0.00 |
|                   CountUsingIndexOfOrdinalIgnoreCase | 100000 | 1,579,648.2 ns |  2,437.54 ns | 2,280.08 ns |  1.30 |    0.00 |
