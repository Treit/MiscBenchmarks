## IndexOf vs. Contains

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22463
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT
  ShortRun : .NET Core 5.0.9 (CoreCLR 5.0.921.35908, CoreFX 5.0.921.35908), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                                               Method |  Count |         Mean |         Error |      StdDev | Ratio | RatioSD |
|----------------------------------------------------- |------- |-------------:|--------------:|------------:|------:|--------:|
|                                   **CountUsingContains** |    **100** |     **1.349 μs** |     **0.3586 μs** |   **0.0197 μs** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal |    100 |     2.027 μs |     0.8737 μs |   0.0479 μs |  1.50 |    0.06 |
|          CountUsingContainsExplicitOrdinalIgnoreCase |    100 |     3.276 μs |     1.5013 μs |   0.0823 μs |  2.43 |    0.09 |
|             CountUsingContainsExplicitCurrentCulture |    100 |     5.606 μs |     2.5952 μs |   0.1422 μs |  4.16 |    0.12 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase |    100 |     5.499 μs |     0.9277 μs |   0.0508 μs |  4.08 |    0.03 |
|           CountUsingContainsExplicitInvariantCulture |    100 |     4.612 μs |     3.2374 μs |   0.1775 μs |  3.42 |    0.14 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase |    100 |     5.635 μs |    18.9103 μs |   1.0365 μs |  4.17 |    0.70 |
|                                    CountUsingIndexOf |    100 |     5.973 μs |    12.3333 μs |   0.6760 μs |  4.43 |    0.53 |
|                    CountUsingIndexOfInvariantCulture |    100 |     4.792 μs |     6.1982 μs |   0.3397 μs |  3.55 |    0.21 |
|          CountUsingIndexOfInvariantCultureIgnoreCase |    100 |     4.902 μs |     0.6183 μs |   0.0339 μs |  3.63 |    0.06 |
|            CountUsingIndexOfCurrentCultureIgnoreCase |    100 |     5.824 μs |     5.7010 μs |   0.3125 μs |  4.32 |    0.27 |
|                             CountUsingIndexOfOrdinal |    100 |     2.187 μs |     1.3729 μs |   0.0753 μs |  1.62 |    0.06 |
|                   CountUsingIndexOfOrdinalIgnoreCase |    100 |     3.256 μs |     1.6212 μs |   0.0889 μs |  2.41 |    0.03 |
|                                                      |        |              |               |             |       |         |
|                                   **CountUsingContains** |   **1000** |    **13.662 μs** |     **5.6303 μs** |   **0.3086 μs** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal |   1000 |    20.447 μs |    17.2244 μs |   0.9441 μs |  1.50 |    0.10 |
|          CountUsingContainsExplicitOrdinalIgnoreCase |   1000 |    34.495 μs |    15.2029 μs |   0.8333 μs |  2.53 |    0.12 |
|             CountUsingContainsExplicitCurrentCulture |   1000 |    55.578 μs |    14.2523 μs |   0.7812 μs |  4.07 |    0.05 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase |   1000 |    60.032 μs |     9.6124 μs |   0.5269 μs |  4.40 |    0.12 |
|           CountUsingContainsExplicitInvariantCulture |   1000 |    47.375 μs |    17.9017 μs |   0.9813 μs |  3.47 |    0.14 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase |   1000 |    48.955 μs |    15.3884 μs |   0.8435 μs |  3.59 |    0.14 |
|                                    CountUsingIndexOf |   1000 |    58.899 μs |    76.4511 μs |   4.1905 μs |  4.31 |    0.21 |
|                    CountUsingIndexOfInvariantCulture |   1000 |    48.671 μs |    28.4050 μs |   1.5570 μs |  3.56 |    0.17 |
|          CountUsingIndexOfInvariantCultureIgnoreCase |   1000 |    47.021 μs |    34.0644 μs |   1.8672 μs |  3.44 |    0.09 |
|            CountUsingIndexOfCurrentCultureIgnoreCase |   1000 |    56.228 μs |    41.8961 μs |   2.2965 μs |  4.12 |    0.12 |
|                             CountUsingIndexOfOrdinal |   1000 |    20.200 μs |     8.8968 μs |   0.4877 μs |  1.48 |    0.02 |
|                   CountUsingIndexOfOrdinalIgnoreCase |   1000 |    35.236 μs |    22.6601 μs |   1.2421 μs |  2.58 |    0.13 |
|                                                      |        |              |               |             |       |         |
|                                   **CountUsingContains** |  **10000** |   **139.994 μs** |    **48.1931 μs** |   **2.6416 μs** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal |  10000 |   249.646 μs |   902.9023 μs |  49.4911 μs |  1.78 |    0.34 |
|          CountUsingContainsExplicitOrdinalIgnoreCase |  10000 |   367.948 μs |   120.4162 μs |   6.6004 μs |  2.63 |    0.03 |
|             CountUsingContainsExplicitCurrentCulture |  10000 |   561.125 μs |   447.1170 μs |  24.5080 μs |  4.01 |    0.23 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase |  10000 |   553.434 μs |   141.3636 μs |   7.7486 μs |  3.95 |    0.13 |
|           CountUsingContainsExplicitInvariantCulture |  10000 |   476.855 μs |   352.4672 μs |  19.3199 μs |  3.41 |    0.19 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase |  10000 |   510.059 μs |   346.9758 μs |  19.0189 μs |  3.64 |    0.14 |
|                                    CountUsingIndexOf |  10000 |   557.190 μs |   330.6695 μs |  18.1251 μs |  3.98 |    0.20 |
|                    CountUsingIndexOfInvariantCulture |  10000 |   507.301 μs |   507.2760 μs |  27.8055 μs |  3.63 |    0.25 |
|          CountUsingIndexOfInvariantCultureIgnoreCase |  10000 |   499.970 μs |   200.9136 μs |  11.0127 μs |  3.57 |    0.15 |
|            CountUsingIndexOfCurrentCultureIgnoreCase |  10000 |   586.981 μs |   355.9657 μs |  19.5117 μs |  4.19 |    0.20 |
|                             CountUsingIndexOfOrdinal |  10000 |   212.736 μs |   167.9963 μs |   9.2084 μs |  1.52 |    0.09 |
|                   CountUsingIndexOfOrdinalIgnoreCase |  10000 |   354.465 μs |   146.4910 μs |   8.0297 μs |  2.53 |    0.03 |
|                                                      |        |              |               |             |       |         |
|                                   **CountUsingContains** | **100000** | **1,495.370 μs** | **1,521.1372 μs** |  **83.3787 μs** |  **1.00** |    **0.00** |
|                    CountUsingContainsExplicitOrdinal | 100000 | 2,100.051 μs | 2,044.3099 μs | 112.0555 μs |  1.41 |    0.15 |
|          CountUsingContainsExplicitOrdinalIgnoreCase | 100000 | 3,785.684 μs | 2,622.3356 μs | 143.7391 μs |  2.54 |    0.24 |
|             CountUsingContainsExplicitCurrentCulture | 100000 | 5,929.271 μs | 2,740.6460 μs | 150.2241 μs |  3.98 |    0.29 |
|   CountUsingContainsExplicitCurrentCultureIgnoreCase | 100000 | 5,915.469 μs | 1,991.8080 μs | 109.1777 μs |  3.96 |    0.15 |
|           CountUsingContainsExplicitInvariantCulture | 100000 | 5,015.209 μs | 3,937.0769 μs | 215.8045 μs |  3.36 |    0.29 |
| CountUsingContainsExplicitInvariantCultureIgnoreCase | 100000 | 5,314.661 μs | 1,201.8812 μs |  65.8792 μs |  3.56 |    0.16 |
|                                    CountUsingIndexOf | 100000 | 5,743.216 μs | 2,287.2176 μs | 125.3701 μs |  3.85 |    0.16 |
|                    CountUsingIndexOfInvariantCulture | 100000 | 4,915.470 μs |   999.4097 μs |  54.7810 μs |  3.29 |    0.16 |
|          CountUsingIndexOfInvariantCultureIgnoreCase | 100000 | 5,345.230 μs | 2,607.1199 μs | 142.9050 μs |  3.59 |    0.30 |
|            CountUsingIndexOfCurrentCultureIgnoreCase | 100000 | 5,776.265 μs | 1,273.3288 μs |  69.7954 μs |  3.87 |    0.18 |
|                             CountUsingIndexOfOrdinal | 100000 | 2,477.199 μs |   561.8781 μs |  30.7984 μs |  1.66 |    0.09 |
|                   CountUsingIndexOfOrdinalIgnoreCase | 100000 | 3,823.932 μs | 2,615.9663 μs | 143.3899 μs |  2.57 |    0.24 |
