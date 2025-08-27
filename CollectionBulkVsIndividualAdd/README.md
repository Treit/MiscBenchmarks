# Collection Bulk vs Individual Add Benchmark

Looping through and calling Add vs. using other techniques.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27934.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 10.0.0 (10.0.25.35903), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                           | Count | Mean          | Error        | StdDev       | Median        | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|--------------------------------- |------ |--------------:|-------------:|-------------:|--------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **ListIndividualAdd**                | **10**    |      **32.12 ns** |     **0.704 ns** |     **1.484 ns** |      **31.67 ns** |  **1.00** |    **0.06** |  **0.0222** |       **-** |       **-** |      **96 B** |        **1.00** |
| ListAddRange                     | 10    |      24.50 ns |     0.556 ns |     1.085 ns |      24.43 ns |  0.76 |    0.05 |  0.0222 |       - |       - |      96 B |        1.00 |
| ListConstructorWithCollection    | 10    |      21.54 ns |     0.497 ns |     1.091 ns |      21.40 ns |  0.67 |    0.05 |  0.0222 |       - |       - |      96 B |        1.00 |
| HashSetIndividualAdd             | 10    |     116.78 ns |     2.405 ns |     6.337 ns |     115.06 ns |  3.64 |    0.26 |  0.0684 |       - |       - |     296 B |        3.08 |
| HashSetUnionWith                 | 10    |     110.92 ns |     2.580 ns |     7.402 ns |     108.82 ns |  3.46 |    0.28 |  0.0759 |       - |       - |     328 B |        3.42 |
| HashSetConstructorWithCollection | 10    |     109.23 ns |     2.121 ns |     4.333 ns |     107.90 ns |  3.41 |    0.20 |  0.0758 |       - |       - |     328 B |        3.42 |
|                                  |       |               |              |              |               |       |         |         |         |         |           |             |
| **ListIndividualAdd**                | **10000** |  **18,575.47 ns** |   **139.882 ns** |   **109.210 ns** |  **18,585.48 ns** |  **1.00** |    **0.01** |  **9.2468** |  **1.0071** |       **-** |   **40056 B** |        **1.00** |
| ListAddRange                     | 10000 |   3,832.99 ns |    37.907 ns |    33.603 ns |   3,827.06 ns |  0.21 |    0.00 |  9.2545 |  1.0223 |       - |   40056 B |        1.00 |
| ListConstructorWithCollection    | 10000 |   3,920.43 ns |    75.250 ns |    80.516 ns |   3,919.10 ns |  0.21 |    0.00 |  9.2545 |  1.0223 |       - |   40056 B |        1.00 |
| HashSetIndividualAdd             | 10000 | 138,445.37 ns | 2,278.076 ns | 3,868.346 ns | 137,661.13 ns |  7.45 |    0.21 | 38.3301 | 38.3301 | 38.3301 |  161781 B |        4.04 |
| HashSetUnionWith                 | 10000 | 126,675.43 ns | 2,506.531 ns | 6,733.632 ns | 125,346.73 ns |  6.82 |    0.36 | 38.4521 | 38.4521 | 38.4521 |  161813 B |        4.04 |
| HashSetConstructorWithCollection | 10000 | 119,994.04 ns | 2,389.474 ns | 4,546.223 ns | 118,935.23 ns |  6.46 |    0.24 | 38.4521 | 38.4521 | 38.4521 |  161813 B |        4.04 |
