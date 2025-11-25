# Finding if a collection has elements matching a collection. Any() vs. Length > 0 and variants.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count  | Mean           | Error          | StdDev         | Ratio      | RatioSD  | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|-------------------------------- |------- |---------------:|---------------:|---------------:|-----------:|---------:|---------:|---------:|---------:|----------:|------------:|
| **ToArrayDotLengthGreaterThanZero** | **10**     |      **95.696 ns** |      **0.7061 ns** |      **0.6259 ns** |      **43.32** |     **0.56** |   **0.0086** |        **-** |        **-** |     **144 B** |          **NA** |
| LinqCountGreaterThanZero        | 10     |      32.070 ns |      0.3464 ns |      0.3071 ns |      14.52 |     0.21 |   0.0029 |        - |        - |      48 B |          NA |
| Any                             | 10     |       2.209 ns |      0.0274 ns |      0.0256 ns |       1.00 |     0.02 |        - |        - |        - |         - |          NA |
|                                 |        |                |                |                |            |          |          |          |          |           |             |
| **ToArrayDotLengthGreaterThanZero** | **100000** | **772,492.214 ns** | **14,429.6110 ns** | **13,497.4671 ns** | **408,037.85** | **8,521.24** | **125.9766** | **125.9766** | **125.9766** |  **721172 B** |          **NA** |
| LinqCountGreaterThanZero        | 100000 | 224,264.196 ns |    707.5123 ns |    590.8048 ns | 118,458.52 | 1,481.48 |        - |        - |        - |      48 B |          NA |
| Any                             | 100000 |       1.893 ns |      0.0255 ns |      0.0238 ns |       1.00 |     0.02 |        - |        - |        - |         - |          NA |
