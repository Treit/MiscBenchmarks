# Testing creating records vs. primary constructors and other ways of creating read-only types.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count  | Mean           | Error          | StdDev        | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |------- |---------------:|---------------:|--------------:|------:|--------:|---------:|----------:|------------:|
| **New_ClassInit**               | **1**      |       **6.359 ns** |      **0.0897 ns** |     **0.0839 ns** |  **1.00** |    **0.02** |   **0.0019** |      **32 B** |        **1.00** |
| New_RecordPositional        | 1      |       6.325 ns |      0.0869 ns |     0.0771 ns |  0.99 |    0.02 |   0.0019 |      32 B |        1.00 |
| New_RecordInitProperties    | 1      |       6.312 ns |      0.0641 ns |     0.0568 ns |  0.99 |    0.02 |   0.0019 |      32 B |        1.00 |
| New_ClassExpressionBodied   | 1      |       6.919 ns |      0.1393 ns |     0.1303 ns |  1.09 |    0.02 |   0.0019 |      32 B |        1.00 |
| New_ClassPrimaryConstructor | 1      |       6.325 ns |      0.0866 ns |     0.0723 ns |  0.99 |    0.02 |   0.0019 |      32 B |        1.00 |
|                             |        |                |                |               |       |         |          |           |             |
| **New_ClassInit**               | **1000**   |   **5,102.814 ns** |     **45.8351 ns** |    **40.6316 ns** |  **1.00** |    **0.01** |   **1.9073** |   **32000 B** |        **1.00** |
| New_RecordPositional        | 1000   |   5,153.423 ns |     40.3024 ns |    35.7270 ns |  1.01 |    0.01 |   1.9073 |   32000 B |        1.00 |
| New_RecordInitProperties    | 1000   |   5,134.762 ns |     92.4616 ns |    86.4886 ns |  1.01 |    0.02 |   1.9073 |   32000 B |        1.00 |
| New_ClassExpressionBodied   | 1000   |   5,154.783 ns |     65.3954 ns |    61.1709 ns |  1.01 |    0.01 |   1.9073 |   32000 B |        1.00 |
| New_ClassPrimaryConstructor | 1000   |   5,111.136 ns |     51.8626 ns |    45.9748 ns |  1.00 |    0.01 |   1.9073 |   32000 B |        1.00 |
|                             |        |                |                |               |       |         |          |           |             |
| **New_ClassInit**               | **100000** | **513,401.152 ns** |  **5,383.4185 ns** | **5,035.6530 ns** |  **1.00** |    **0.01** | **190.4297** | **3200000 B** |        **1.00** |
| New_RecordPositional        | 100000 | 512,245.026 ns |  6,310.5641 ns | 5,902.9056 ns |  1.00 |    0.01 | 190.4297 | 3200000 B |        1.00 |
| New_RecordInitProperties    | 100000 | 517,743.353 ns | 10,343.2917 ns | 9,675.1215 ns |  1.01 |    0.02 | 190.4297 | 3200000 B |        1.00 |
| New_ClassExpressionBodied   | 100000 | 517,043.450 ns |  5,560.1860 ns | 4,928.9601 ns |  1.01 |    0.01 | 190.4297 | 3200000 B |        1.00 |
| New_ClassPrimaryConstructor | 100000 | 574,321.087 ns |  8,688.5373 ns | 7,702.1620 ns |  1.12 |    0.02 | 190.4297 | 3200000 B |        1.00 |
