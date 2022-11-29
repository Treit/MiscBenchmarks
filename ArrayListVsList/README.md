# ArrayList vs List

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25252
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100
  [Host]     : .NET Core 6.0.11 (CoreCLR 6.0.1122.52304, CoreFX 6.0.1122.52304), X64 RyuJIT
  DefaultJob : .NET Core 6.0.11 (CoreCLR 6.0.1122.52304, CoreFX 6.0.1122.52304), X64 RyuJIT


```
|                   Method |  Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------- |------- |------------:|----------:|----------:|------------:|------:|--------:|---------:|---------:|---------:|----------:|
|     CreateArrayListOfInt | 100000 |  8,767.7 μs | 222.09 μs | 647.83 μs |  8,632.7 μs | 62.54 |    4.32 | 625.0000 | 453.1250 | 265.6250 | 4497639 B |
|          CreateListOfInt | 100000 |    550.1 μs |  10.85 μs |  17.21 μs |    552.3 μs |  3.84 |    0.11 |  55.6641 |  25.3906 |  25.3906 | 1049083 B |
|  CreateArrayListOfObject | 100000 | 10,829.0 μs | 216.50 μs | 514.52 μs | 10,798.4 μs | 76.21 |    2.94 | 734.3750 | 468.7500 | 281.2500 | 5297462 B |
|       CreateListOfObject | 100000 | 11,333.5 μs | 226.36 μs | 584.30 μs | 11,288.1 μs | 78.49 |    4.76 | 734.3750 | 421.8750 | 250.0000 | 5297534 B |
|    IterateArrayListOfInt | 100000 |    910.1 μs |  70.87 μs | 208.96 μs |    822.2 μs |  5.38 |    0.34 |        - |        - |        - |      48 B |
|         IterateListOfInt | 100000 |    141.7 μs |   1.57 μs |   1.31 μs |    141.8 μs |  1.00 |    0.00 |        - |        - |        - |         - |
| IterateArrayListOfObject | 100000 |    767.1 μs |  22.25 μs |  62.77 μs |    748.8 μs |  5.60 |    0.34 |        - |        - |        - |      48 B |
|      IterateListOfObject | 100000 |    162.2 μs |   3.20 μs |   4.60 μs |    161.4 μs |  1.15 |    0.04 |        - |        - |        - |         - |
