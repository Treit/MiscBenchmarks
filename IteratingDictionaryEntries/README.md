# Iterating dictionary entries.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22616
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.202
  [Host]     : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET Core 6.0.4 (CoreCLR 6.0.422.16404, CoreFX 6.0.422.16404), X64 RyuJIT


```
|                    Method |  Count |          Mean |         Error |        StdDev | Ratio | RatioSD |
|-------------------------- |------- |--------------:|--------------:|--------------:|------:|--------:|
| **IterateAndLookupUsingKeys** |     **10** |      **90.47 ns** |      **1.845 ns** |      **3.031 ns** |  **3.05** |    **0.18** |
| IterateUsingKeyValuePairs |     10 |      42.56 ns |      0.881 ns |      1.914 ns |  1.44 |    0.09 |
|        IterateUsingValues |     10 |      29.60 ns |      0.630 ns |      1.382 ns |  1.00 |    0.00 |
|                           |        |               |               |               |       |         |
| **IterateAndLookupUsingKeys** |   **1000** |   **8,251.63 ns** |    **162.954 ns** |    **253.700 ns** |  **3.44** |    **0.14** |
| IterateUsingKeyValuePairs |   1000 |   3,032.78 ns |     60.413 ns |    114.941 ns |  1.27 |    0.06 |
|        IterateUsingValues |   1000 |   2,403.39 ns |     47.116 ns |     70.521 ns |  1.00 |    0.00 |
|                           |        |               |               |               |       |         |
| **IterateAndLookupUsingKeys** | **100000** | **844,911.27 ns** | **16,863.042 ns** | **34,446.725 ns** |  **3.49** |    **0.22** |
| IterateUsingKeyValuePairs | 100000 | 302,522.19 ns |  6,005.079 ns | 13,676.605 ns |  1.25 |    0.08 |
|        IterateUsingValues | 100000 | 242,553.47 ns |  4,779.989 ns | 11,266.997 ns |  1.00 |    0.00 |
