# Consider each unique value in a set that has 'runs' of values.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25947.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
|                          Method |   Count |             Mean |           Error |          StdDev |           Median | Ratio |   Gen0 |  Allocated | Alloc Ratio |
|-------------------------------- |-------- |-----------------:|----------------:|----------------:|-----------------:|------:|-------:|-----------:|------------:|
| **IterateListAfterCallingDistinct** |      **10** |       **1,579.1 ns** |        **30.80 ns** |        **49.74 ns** |       **1,565.6 ns** |  **1.00** | **0.1526** |      **664 B** |        **1.00** |
|   IterateListSkippingDuplicates |      10 |         202.5 ns |         3.01 ns |         6.00 ns |         202.5 ns |  0.13 |      - |          - |        0.00 |
|                                 |         |                  |                 |                 |                  |       |        |            |             |
| **IterateListAfterCallingDistinct** | **1000000** | **168,947,483.1 ns** | **3,001,773.56 ns** | **7,249,620.54 ns** | **166,544,433.3 ns** |  **1.00** |      **-** | **43111301 B** |       **1.000** |
|   IterateListSkippingDuplicates | 1000000 |  28,151,762.4 ns |   557,452.43 ns | 1,033,273.83 ns |  27,914,306.2 ns |  0.17 |      - |       17 B |       0.000 |
