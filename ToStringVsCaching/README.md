# Getting the string representations of many items by calling ToString() vs. caching the string value.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 5.0.17 (CoreCLR 5.0.1722.21314, CoreFX 5.0.1722.21314), X64 RyuJIT
  DefaultJob : .NET Core 5.0.17 (CoreCLR 5.0.1722.21314, CoreFX 5.0.1722.21314), X64 RyuJIT


```
|                      Method |   Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |  Allocated |
|---------------------------- |-------- |------------:|------------:|------------:|------------:|------:|--------:|-----------:|------:|------:|-----------:|
|     **ProcessDataWithToString** |   **10000** |    **576.8 μs** |    **10.63 μs** |    **28.92 μs** |    **569.7 μs** |  **1.00** |    **0.00** |   **128.9063** |     **-** |     **-** |   **559749 B** |
| ProcessDataWithCachedString |   10000 |    286.6 μs |     2.20 μs |     1.72 μs |    286.9 μs |  0.51 |    0.02 |          - |     - |     - |          - |
|                             |         |             |             |             |             |       |         |            |       |       |            |
|     **ProcessDataWithToString** | **1000000** | **61,546.1 μs** | **1,321.86 μs** | **3,771.35 μs** | **60,456.0 μs** |  **1.00** |    **0.00** | **14625.0000** |     **-** |     **-** | **63207468 B** |
| ProcessDataWithCachedString | 1000000 | 29,211.3 μs |   566.54 μs | 1,541.31 μs | 28,706.4 μs |  0.48 |    0.03 |          - |     - |     - |          - |
