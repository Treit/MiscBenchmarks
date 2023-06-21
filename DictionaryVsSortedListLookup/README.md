# SortedList vs. Dictionary lookups by simple integer keys.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25393.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.300-preview.23179.2
  [Host]     : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2


```
|                Method | Iterations |          Mean |        Error |       StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------- |----------- |--------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **LookupUsingDictionary** |         **10** |      **19.94 μs** |     **0.590 μs** |     **1.740 μs** |  **1.00** |    **0.00** |         **-** |          **NA** |
| LookupUsingSortedList |         10 |      24.02 μs |     0.470 μs |     0.689 μs |  1.18 |    0.15 |         - |          NA |
|                       |            |               |              |              |       |         |           |             |
| **LookupUsingDictionary** |      **10000** |  **17,228.52 μs** |   **335.930 μs** |   **459.825 μs** |  **1.00** |    **0.00** |      **17 B** |        **1.00** |
| LookupUsingSortedList |      10000 |  22,997.46 μs |   406.740 μs |   380.465 μs |  1.34 |    0.04 |      22 B |        1.29 |
|                       |            |               |              |              |       |         |           |             |
| **LookupUsingDictionary** |     **100000** | **170,225.06 μs** | **3,065.235 μs** | **2,717.251 μs** |  **1.00** |    **0.00** |    **1200 B** |        **1.00** |
| LookupUsingSortedList |     100000 | 230,093.41 μs | 3,577.169 μs | 2,792.819 μs |  1.35 |    0.03 |    1187 B |        0.99 |
