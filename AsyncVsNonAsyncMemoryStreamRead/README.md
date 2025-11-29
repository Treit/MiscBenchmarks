# Async vs. non-async reads of a MemoryStream





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Job       | Runtime   | Count   | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------------------- |---------- |---------- |-------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **ReadMemoryStream**                         | **.NET 10.0** | **.NET 10.0** | **1000**    | **11.92 ns** | **0.299 ns** | **0.516 ns** |  **1.00** |    **0.06** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | .NET 10.0 | .NET 10.0 | 1000    | 28.65 ns | 0.380 ns | 0.356 ns |  2.41 |    0.11 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | .NET 10.0 | .NET 10.0 | 1000    | 34.61 ns | 0.578 ns | 0.513 ns |  2.91 |    0.13 | 0.0210 |     352 B |        1.26 |
|                                          |           |           |         |          |          |          |       |         |        |           |             |
| ReadMemoryStream                         | .NET 9.0  | .NET 9.0  | 1000    | 11.37 ns | 0.253 ns | 0.337 ns |  1.00 |    0.04 | 0.0167 |     280 B |        1.00 |
| ReadMemoryStreamAsync                    | .NET 9.0  | .NET 9.0  | 1000    | 29.37 ns | 0.480 ns | 0.426 ns |  2.59 |    0.08 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | .NET 9.0  | .NET 9.0  | 1000    | 35.30 ns | 0.603 ns | 0.564 ns |  3.11 |    0.10 | 0.0210 |     352 B |        1.26 |
|                                          |           |           |         |          |          |          |       |         |        |           |             |
| **ReadMemoryStream**                         | **.NET 10.0** | **.NET 10.0** | **100000**  | **11.43 ns** | **0.294 ns** | **0.457 ns** |  **1.00** |    **0.05** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | .NET 10.0 | .NET 10.0 | 100000  | 30.08 ns | 0.645 ns | 0.690 ns |  2.64 |    0.12 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | .NET 10.0 | .NET 10.0 | 100000  | 36.38 ns | 0.487 ns | 0.456 ns |  3.19 |    0.13 | 0.0210 |     352 B |        1.26 |
|                                          |           |           |         |          |          |          |       |         |        |           |             |
| ReadMemoryStream                         | .NET 9.0  | .NET 9.0  | 100000  | 11.55 ns | 0.293 ns | 0.349 ns |  1.00 |    0.04 | 0.0167 |     280 B |        1.00 |
| ReadMemoryStreamAsync                    | .NET 9.0  | .NET 9.0  | 100000  | 29.94 ns | 0.664 ns | 0.815 ns |  2.60 |    0.10 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | .NET 9.0  | .NET 9.0  | 100000  | 34.86 ns | 0.494 ns | 0.462 ns |  3.02 |    0.10 | 0.0210 |     352 B |        1.26 |
|                                          |           |           |         |          |          |          |       |         |        |           |             |
| **ReadMemoryStream**                         | **.NET 10.0** | **.NET 10.0** | **1000000** | **11.55 ns** | **0.296 ns** | **0.374 ns** |  **1.00** |    **0.04** | **0.0167** |     **280 B** |        **1.00** |
| ReadMemoryStreamAsync                    | .NET 10.0 | .NET 10.0 | 1000000 | 30.45 ns | 0.411 ns | 0.365 ns |  2.64 |    0.09 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | .NET 10.0 | .NET 10.0 | 1000000 | 36.04 ns | 0.769 ns | 0.755 ns |  3.12 |    0.12 | 0.0210 |     352 B |        1.26 |
|                                          |           |           |         |          |          |          |       |         |        |           |             |
| ReadMemoryStream                         | .NET 9.0  | .NET 9.0  | 1000000 | 11.11 ns | 0.265 ns | 0.235 ns |  1.00 |    0.03 | 0.0167 |     280 B |        1.00 |
| ReadMemoryStreamAsync                    | .NET 9.0  | .NET 9.0  | 1000000 | 29.13 ns | 0.535 ns | 0.500 ns |  2.62 |    0.07 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | .NET 9.0  | .NET 9.0  | 1000000 | 34.83 ns | 0.583 ns | 0.546 ns |  3.14 |    0.08 | 0.0210 |     352 B |        1.26 |
