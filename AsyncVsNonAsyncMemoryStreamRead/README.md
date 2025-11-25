# Async vs. non-async reads of a MemoryStream



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |-------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **ReadMemoryStream**                         | **1000**    | **15.11 ns** | **0.313 ns** | **0.278 ns** |  **1.00** |    **0.03** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | 1000    | 29.54 ns | 0.625 ns | 0.614 ns |  1.95 |    0.05 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 1000    | 35.22 ns | 0.512 ns | 0.479 ns |  2.33 |    0.05 | 0.0210 |     352 B |        1.26 |
|                                          |         |          |          |          |       |         |        |           |             |
| **ReadMemoryStream**                         | **100000**  | **11.86 ns** | **0.273 ns** | **0.242 ns** |  **1.00** |    **0.03** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | 100000  | 29.65 ns | 0.647 ns | 0.665 ns |  2.50 |    0.07 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 100000  | 36.17 ns | 0.680 ns | 0.603 ns |  3.05 |    0.08 | 0.0210 |     352 B |        1.26 |
|                                          |         |          |          |          |       |         |        |           |             |
| **ReadMemoryStream**                         | **1000000** | **11.90 ns** | **0.285 ns** | **0.280 ns** |  **1.00** |    **0.03** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | 1000000 | 29.73 ns | 0.486 ns | 0.455 ns |  2.50 |    0.07 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 1000000 | 36.16 ns | 0.637 ns | 0.565 ns |  3.04 |    0.09 | 0.0210 |     352 B |        1.26 |
