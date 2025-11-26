# Async vs. non-async reads of a MemoryStream




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count   | Mean     | Error    | StdDev   | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |-------- |---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **ReadMemoryStream**                         | **1000**    | **12.10 ns** | **0.297 ns** | **0.263 ns** | **12.13 ns** |  **1.00** |    **0.03** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | 1000    | 30.28 ns | 0.664 ns | 0.765 ns | 30.05 ns |  2.50 |    0.08 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 1000    | 35.21 ns | 0.616 ns | 0.546 ns | 35.18 ns |  2.91 |    0.08 | 0.0210 |     352 B |        1.26 |
|                                          |         |          |          |          |          |       |         |        |           |             |
| **ReadMemoryStream**                         | **100000**  | **12.09 ns** | **0.306 ns** | **0.314 ns** | **12.14 ns** |  **1.00** |    **0.04** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | 100000  | 30.39 ns | 0.665 ns | 0.739 ns | 30.54 ns |  2.51 |    0.09 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 100000  | 36.26 ns | 0.773 ns | 1.270 ns | 35.68 ns |  3.00 |    0.13 | 0.0210 |     352 B |        1.26 |
|                                          |         |          |          |          |          |       |         |        |           |             |
| **ReadMemoryStream**                         | **1000000** | **12.02 ns** | **0.298 ns** | **0.292 ns** | **12.05 ns** |  **1.00** |    **0.03** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | 1000000 | 29.40 ns | 0.373 ns | 0.349 ns | 29.32 ns |  2.45 |    0.06 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 1000000 | 35.59 ns | 0.522 ns | 0.489 ns | 35.60 ns |  2.96 |    0.08 | 0.0210 |     352 B |        1.26 |
