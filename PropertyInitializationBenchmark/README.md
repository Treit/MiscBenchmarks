Comparing the performance of two different property syntax patterns for accessing environment variables

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27913.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count  | Mean            | Error         | StdDev        | Median          | Ratio  | RatioSD | Gen0      | Allocated | Alloc Ratio |
|---------------------------- |------- |----------------:|--------------:|--------------:|----------------:|-------:|--------:|----------:|----------:|------------:|
| **ExpressionBodiedProperty**    | **10**     |      **1,975.5 ns** |      **39.07 ns** |      **84.94 ns** |      **1,961.6 ns** |   **9.68** |    **0.59** |    **0.1450** |     **640 B** |       **10.00** |
| AutoPropertyWithInitializer | 10     |        204.5 ns |       4.18 ns |       9.26 ns |        201.9 ns |   1.00 |    0.06 |    0.0148 |      64 B |        1.00 |
|                             |        |                 |               |               |                 |        |         |           |           |             |
| **ExpressionBodiedProperty**    | **100000** | **19,113,789.7 ns** | **378,702.38 ns** | **692,478.77 ns** | **19,009,548.4 ns** | **611.92** |   **50.85** | **1468.7500** | **6400000 B** |  **100,000.00** |
| AutoPropertyWithInitializer | 100000 |     31,421.1 ns |     853.99 ns |   2,491.14 ns |     30,426.3 ns |   1.01 |    0.11 |         - |      64 B |        1.00 |
