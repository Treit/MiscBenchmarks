# Finding min and max on different numeric types.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Count  | Mean          | Error       | StdDev      | Median        | Ratio | RatioSD |
|----------------- |------- |--------------:|------------:|------------:|--------------:|------:|--------:|
| **MinAndMaxInts**    | **10**     |     **10.080 ns** |   **0.1054 ns** |   **0.0934 ns** |     **10.114 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | 10     |      9.733 ns |   0.1767 ns |   0.1566 ns |      9.721 ns |  0.97 |    0.02 |
| MinAndMaxFloats  | 10     |     11.519 ns |   0.2398 ns |   0.2355 ns |     11.451 ns |  1.14 |    0.02 |
| MinAndMaxDoubles | 10     |     12.797 ns |   0.3665 ns |   1.0807 ns |     13.096 ns |  1.27 |    0.11 |
|                  |        |               |             |             |               |       |         |
| **MinAndMaxInts**    | **100**    |     **85.092 ns** |   **0.5120 ns** |   **0.4789 ns** |     **85.178 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | 100    |     85.371 ns |   0.6093 ns |   0.5699 ns |     85.507 ns |  1.00 |    0.01 |
| MinAndMaxFloats  | 100    |    119.904 ns |   1.1094 ns |   1.0377 ns |    119.802 ns |  1.41 |    0.01 |
| MinAndMaxDoubles | 100    |     99.168 ns |   2.0236 ns |   2.2493 ns |     99.362 ns |  1.17 |    0.03 |
|                  |        |               |             |             |               |       |         |
| **MinAndMaxInts**    | **100000** | **85,020.851 ns** | **556.4478 ns** | **520.5016 ns** | **85,114.453 ns** |  **1.00** |    **0.01** |
| MinAndMaxLongs   | 100000 | 94,725.196 ns | 509.2418 ns | 476.3451 ns | 94,872.681 ns |  1.11 |    0.01 |
| MinAndMaxFloats  | 100000 | 94,676.494 ns | 644.8032 ns | 571.6013 ns | 94,653.540 ns |  1.11 |    0.01 |
| MinAndMaxDoubles | 100000 | 86,476.021 ns | 383.0843 ns | 339.5943 ns | 86,611.871 ns |  1.02 |    0.01 |
