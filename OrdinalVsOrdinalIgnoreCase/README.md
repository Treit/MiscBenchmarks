# Ordinal vs OrdinalIgnoreCase

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                     Method | Count |         Mean |       Error |      StdDev |       Median | Ratio | RatioSD |
|--------------------------- |------ |-------------:|------------:|------------:|-------------:|------:|--------:|
|                    **Ordinal** |   **100** |   **1,044.0 ns** |    **18.96 ns** |    **17.73 ns** |   **1,036.8 ns** |  **1.00** |    **0.00** |
|          OrdinalIgnoreCase |   100 |     883.5 ns |    16.97 ns |    21.46 ns |     874.0 ns |  0.85 |    0.03 |
|             CurrentCulture |   100 |   6,956.0 ns |    88.11 ns |    82.42 ns |   6,959.5 ns |  6.66 |    0.13 |
|   CurrentCultureIgnoreCase |   100 |   6,842.4 ns |    36.78 ns |    32.60 ns |   6,844.2 ns |  6.55 |    0.12 |
|           InvariantCulture |   100 |   6,227.4 ns |   122.38 ns |   140.93 ns |   6,190.4 ns |  5.99 |    0.19 |
| InvariantCultureIgnoreCase |   100 |   6,196.7 ns |   109.35 ns |   149.68 ns |   6,143.7 ns |  5.91 |    0.22 |
|                            |       |              |             |             |              |       |         |
|                    **Ordinal** |  **1000** |  **10,173.3 ns** |   **202.21 ns** |   **179.25 ns** |  **10,123.9 ns** |  **1.00** |    **0.00** |
|          OrdinalIgnoreCase |  1000 |   8,014.6 ns |    78.03 ns |    69.17 ns |   8,026.5 ns |  0.79 |    0.02 |
|             CurrentCulture |  1000 |  46,773.0 ns |   935.43 ns | 2,713.86 ns |  45,725.9 ns |  4.73 |    0.26 |
|   CurrentCultureIgnoreCase |  1000 |  45,598.9 ns |   425.86 ns |   398.35 ns |  45,612.6 ns |  4.48 |    0.09 |
|           InvariantCulture |  1000 |  39,135.4 ns |   733.89 ns | 1,185.09 ns |  38,845.3 ns |  3.93 |    0.17 |
| InvariantCultureIgnoreCase |  1000 |  39,351.3 ns |   567.56 ns |   503.13 ns |  39,319.3 ns |  3.87 |    0.09 |
|                            |       |              |             |             |              |       |         |
|                    **Ordinal** | **10000** | **103,844.2 ns** | **1,177.94 ns** |   **919.66 ns** | **103,564.3 ns** |  **1.00** |    **0.00** |
|          OrdinalIgnoreCase | 10000 |  82,665.9 ns | 1,632.17 ns | 1,879.60 ns |  81,891.0 ns |  0.80 |    0.02 |
|             CurrentCulture | 10000 | 449,976.3 ns | 8,747.74 ns | 8,983.29 ns | 449,722.0 ns |  4.34 |    0.08 |
|   CurrentCultureIgnoreCase | 10000 | 433,376.6 ns | 7,121.66 ns | 6,313.16 ns | 433,427.9 ns |  4.17 |    0.07 |
|           InvariantCulture | 10000 | 375,277.1 ns | 6,914.54 ns | 6,467.87 ns | 373,759.1 ns |  3.59 |    0.05 |
| InvariantCultureIgnoreCase | 10000 | 373,779.2 ns | 6,973.91 ns | 5,823.53 ns | 371,628.7 ns |  3.60 |    0.07 |
