# Iterating a list vs. iterating a dictionary.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22554
Unknown processor
.NET Core SDK=6.0.200
  [Host]     : .NET Core 6.0.2 (CoreCLR 6.0.222.6406, CoreFX 6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET Core 6.0.2 (CoreCLR 6.0.222.6406, CoreFX 6.0.222.6406), X64 RyuJIT


```
|                         Method |  Count |           Mean |         Error |         StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |------- |---------------:|--------------:|---------------:|------:|--------:|------:|------:|------:|----------:|
|                    **IterateList** |      **3** |       **7.886 ns** |     **0.3363 ns** |      **0.9758 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|          IterateDictionaryKeys |      3 |      14.427 ns |     0.3389 ns |      0.9939 ns |  1.85 |    0.23 |     - |     - |     - |         - |
|        IterateDictionaryValues |      3 |      13.601 ns |     0.2994 ns |      0.4099 ns |  1.63 |    0.20 |     - |     - |     - |         - |
| IterateDictionaryKeyValuePairs |      3 |      20.617 ns |     0.4433 ns |      0.3929 ns |  2.48 |    0.25 |     - |     - |     - |         - |
|                                |        |                |               |                |       |         |       |       |       |           |
|                    **IterateList** |     **50** |     **109.608 ns** |     **2.2194 ns** |      **3.7688 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|          IterateDictionaryKeys |     50 |     151.887 ns |     3.3216 ns |      9.6893 ns |  1.38 |    0.09 |     - |     - |     - |         - |
|        IterateDictionaryValues |     50 |     151.605 ns |     3.0731 ns |      8.6677 ns |  1.39 |    0.10 |     - |     - |     - |         - |
| IterateDictionaryKeyValuePairs |     50 |     188.508 ns |     4.4112 ns |     12.3694 ns |  1.76 |    0.13 |     - |     - |     - |         - |
|                                |        |                |               |                |       |         |       |       |       |           |
|                    **IterateList** |   **1000** |   **2,042.382 ns** |    **40.6332 ns** |    **104.8872 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|          IterateDictionaryKeys |   1000 |   2,691.144 ns |    53.1116 ns |    128.2705 ns |  1.32 |    0.08 |     - |     - |     - |         - |
|        IterateDictionaryValues |   1000 |   2,715.560 ns |    50.4851 ns |    103.1278 ns |  1.33 |    0.09 |     - |     - |     - |         - |
| IterateDictionaryKeyValuePairs |   1000 |   3,372.173 ns |    60.6657 ns |    110.9307 ns |  1.65 |    0.10 |     - |     - |     - |         - |
|                                |        |                |               |                |       |         |       |       |       |           |
|                    **IterateList** | **100000** | **208,859.555 ns** | **5,769.6754 ns** | **16,083.5488 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|          IterateDictionaryKeys | 100000 | 274,859.067 ns | 6,481.9179 ns | 18,805.2191 ns |  1.33 |    0.13 |     - |     - |     - |         - |
|        IterateDictionaryValues | 100000 | 280,842.708 ns | 7,400.2130 ns | 21,703.5438 ns |  1.35 |    0.14 |     - |     - |     - |         - |
| IterateDictionaryKeyValuePairs | 100000 | 339,930.653 ns | 7,787.6478 ns | 21,579.5354 ns |  1.63 |    0.15 |     - |     - |     - |         - |
