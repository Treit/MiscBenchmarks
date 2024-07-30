# Finding if a collection has elements matching a collection. Any() vs. Length > 0 and variants.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Count  | Mean            | Error         | StdDev        | Median          | Ratio     | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------- |------- |----------------:|--------------:|--------------:|----------------:|----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **ToArrayDotLengthGreaterThanZero** | **10**     |       **188.52 ns** |      **3.741 ns** |      **7.208 ns** |       **186.10 ns** |      **9.04** |     **0.32** |   **0.0870** |        **-** |        **-** |     **376 B** |       **11.75** |
| LinqCountGreaterThanZero        | 10     |        40.99 ns |      0.782 ns |      1.122 ns |        40.70 ns |      1.97 |     0.07 |   0.0111 |        - |        - |      48 B |        1.50 |
| Any                             | 10     |        21.03 ns |      0.433 ns |      0.361 ns |        20.87 ns |      1.00 |     0.00 |   0.0074 |        - |        - |      32 B |        1.00 |
|                                 |        |                 |               |               |                 |           |          |          |          |          |           |             |
| **ToArrayDotLengthGreaterThanZero** | **100000** | **1,058,351.98 ns** | **20,345.522 ns** | **16,989.432 ns** | **1,057,572.17 ns** | **46,853.83** | **3,006.73** | **259.7656** | **234.3750** | **228.5156** | **1522325 B** |   **47,572.66** |
| LinqCountGreaterThanZero        | 100000 |   145,850.66 ns |  3,147.275 ns |  8,876.946 ns |   144,158.50 ns |  6,386.50 |   578.03 |        - |        - |        - |      48 B |        1.50 |
| Any                             | 100000 |        22.95 ns |      0.600 ns |      1.691 ns |        22.48 ns |      1.00 |     0.00 |   0.0074 |        - |        - |      32 B |        1.00 |
