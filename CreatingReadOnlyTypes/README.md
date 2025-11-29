# Testing creating records vs. primary constructors and other ways of creating read-only types.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count  | Mean           | Error         | StdDev        | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |------- |---------------:|--------------:|--------------:|------:|--------:|---------:|----------:|------------:|
| **New_ClassInit**               | **1**      |       **6.305 ns** |     **0.0855 ns** |     **0.0800 ns** |  **1.00** |    **0.02** |   **0.0019** |      **32 B** |        **1.00** |
| New_RecordPositional        | 1      |       6.584 ns |     0.0721 ns |     0.0674 ns |  1.04 |    0.02 |   0.0019 |      32 B |        1.00 |
| New_RecordInitProperties    | 1      |       6.271 ns |     0.0820 ns |     0.0767 ns |  0.99 |    0.02 |   0.0019 |      32 B |        1.00 |
| New_ClassExpressionBodied   | 1      |       6.272 ns |     0.0783 ns |     0.0733 ns |  0.99 |    0.02 |   0.0019 |      32 B |        1.00 |
| New_ClassPrimaryConstructor | 1      |       6.150 ns |     0.0780 ns |     0.0730 ns |  0.98 |    0.02 |   0.0019 |      32 B |        1.00 |
|                             |        |                |               |               |       |         |          |           |             |
| **New_ClassInit**               | **1000**   |   **5,051.830 ns** |    **22.5352 ns** |    **19.9769 ns** |  **1.00** |    **0.01** |   **1.9073** |   **32000 B** |        **1.00** |
| New_RecordPositional        | 1000   |   5,035.197 ns |    41.2847 ns |    36.5978 ns |  1.00 |    0.01 |   1.9073 |   32000 B |        1.00 |
| New_RecordInitProperties    | 1000   |   5,093.635 ns |    38.3090 ns |    35.8342 ns |  1.01 |    0.01 |   1.9073 |   32000 B |        1.00 |
| New_ClassExpressionBodied   | 1000   |   5,059.479 ns |    51.9727 ns |    46.0725 ns |  1.00 |    0.01 |   1.9073 |   32000 B |        1.00 |
| New_ClassPrimaryConstructor | 1000   |   5,063.408 ns |    41.4575 ns |    38.7793 ns |  1.00 |    0.01 |   1.9073 |   32000 B |        1.00 |
|                             |        |                |               |               |       |         |          |           |             |
| **New_ClassInit**               | **100000** | **509,416.198 ns** | **4,702.2458 ns** | **4,398.4836 ns** |  **1.00** |    **0.01** | **190.4297** | **3200000 B** |        **1.00** |
| New_RecordPositional        | 100000 | 503,124.212 ns | 4,796.9560 ns | 4,252.3766 ns |  0.99 |    0.01 | 190.4297 | 3200000 B |        1.00 |
| New_RecordInitProperties    | 100000 | 499,953.574 ns | 4,391.2160 ns | 4,107.5461 ns |  0.98 |    0.01 | 190.4297 | 3200000 B |        1.00 |
| New_ClassExpressionBodied   | 100000 | 497,647.656 ns | 2,341.6279 ns | 1,828.1891 ns |  0.98 |    0.01 | 190.4297 | 3200000 B |        1.00 |
| New_ClassPrimaryConstructor | 100000 | 503,575.795 ns | 3,900.8763 ns | 3,458.0252 ns |  0.99 |    0.01 | 190.4297 | 3200000 B |        1.00 |
