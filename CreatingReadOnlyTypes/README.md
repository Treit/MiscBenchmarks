# Testing creating records vs. primary constructors and other ways of creating read-only types.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count  | Mean           | Error          | StdDev         | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|---------------------------- |------- |---------------:|---------------:|---------------:|------:|--------:|---------:|----------:|------------:|
| **New_ClassInit**               | **1**      |       **6.313 ns** |      **0.1570 ns** |      **0.1680 ns** |  **1.00** |    **0.04** |   **0.0019** |      **32 B** |        **1.00** |
| New_RecordPositional        | 1      |       6.330 ns |      0.1555 ns |      0.1379 ns |  1.00 |    0.03 |   0.0019 |      32 B |        1.00 |
| New_RecordInitProperties    | 1      |       6.320 ns |      0.1291 ns |      0.1208 ns |  1.00 |    0.03 |   0.0019 |      32 B |        1.00 |
| New_ClassExpressionBodied   | 1      |       6.320 ns |      0.1339 ns |      0.1187 ns |  1.00 |    0.03 |   0.0019 |      32 B |        1.00 |
| New_ClassPrimaryConstructor | 1      |       6.395 ns |      0.1383 ns |      0.1293 ns |  1.01 |    0.03 |   0.0019 |      32 B |        1.00 |
|                             |        |                |                |                |       |         |          |           |             |
| **New_ClassInit**               | **1000**   |   **5,228.083 ns** |    **103.3890 ns** |    **166.9539 ns** |  **1.00** |    **0.04** |   **1.9073** |   **32000 B** |        **1.00** |
| New_RecordPositional        | 1000   |   5,191.454 ns |     66.7853 ns |     55.7687 ns |  0.99 |    0.03 |   1.9073 |   32000 B |        1.00 |
| New_RecordInitProperties    | 1000   |   5,175.928 ns |     95.1029 ns |    105.7066 ns |  0.99 |    0.04 |   1.9073 |   32000 B |        1.00 |
| New_ClassExpressionBodied   | 1000   |   5,175.048 ns |    100.0911 ns |    119.1514 ns |  0.99 |    0.04 |   1.9073 |   32000 B |        1.00 |
| New_ClassPrimaryConstructor | 1000   |   5,102.741 ns |     62.6771 ns |     52.3382 ns |  0.98 |    0.03 |   1.9073 |   32000 B |        1.00 |
|                             |        |                |                |                |       |         |          |           |             |
| **New_ClassInit**               | **100000** | **527,729.041 ns** | **10,424.6402 ns** | **14,269.3664 ns** |  **1.00** |    **0.04** | **190.4297** | **3200000 B** |        **1.00** |
| New_RecordPositional        | 100000 | 526,017.327 ns | 10,513.9044 ns | 16,676.1679 ns |  1.00 |    0.04 | 190.4297 | 3200000 B |        1.00 |
| New_RecordInitProperties    | 100000 | 521,031.997 ns | 10,367.5966 ns | 10,646.7584 ns |  0.99 |    0.03 | 190.4297 | 3200000 B |        1.00 |
| New_ClassExpressionBodied   | 100000 | 519,171.524 ns | 10,155.6896 ns | 15,811.1865 ns |  0.98 |    0.04 | 190.4297 | 3200000 B |        1.00 |
| New_ClassPrimaryConstructor | 100000 | 530,444.778 ns | 10,251.3730 ns | 11,394.3739 ns |  1.01 |    0.03 | 190.4297 | 3200000 B |        1.00 |
