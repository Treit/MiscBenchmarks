# Async vs. non-async reads of a MemoryStream


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                   Method |   Count |     Mean |    Error |   StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------------------- |-------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
|                         **ReadMemoryStream** |    **1000** | **14.06 ns** | **0.340 ns** | **0.499 ns** |  **1.00** |    **0.00** | **0.0167** |     **280 B** |        **1.00** |
|                    ReadMemoryStreamAsync |    1000 | 33.78 ns | 0.419 ns | 0.391 ns |  2.41 |    0.07 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload |    1000 | 53.03 ns | 0.690 ns | 0.646 ns |  3.79 |    0.13 | 0.0210 |     352 B |        1.26 |
|                                          |         |          |          |          |       |         |        |           |             |
|                         **ReadMemoryStream** |  **100000** | **14.47 ns** | **0.347 ns** | **0.357 ns** |  **1.00** |    **0.00** | **0.0167** |     **280 B** |        **1.00** |
|                    ReadMemoryStreamAsync |  100000 | 35.21 ns | 0.733 ns | 0.720 ns |  2.44 |    0.06 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload |  100000 | 52.81 ns | 0.569 ns | 0.533 ns |  3.66 |    0.09 | 0.0210 |     352 B |        1.26 |
|                                          |         |          |          |          |       |         |        |           |             |
|                         **ReadMemoryStream** | **1000000** | **14.03 ns** | **0.241 ns** | **0.213 ns** |  **1.00** |    **0.00** | **0.0167** |     **280 B** |        **1.00** |
|                    ReadMemoryStreamAsync | 1000000 | 33.91 ns | 0.433 ns | 0.384 ns |  2.42 |    0.05 | 0.0210 |     352 B |        1.26 |
| ReadMemoryStreamAsyncCancelTokenOverload | 1000000 | 52.25 ns | 0.388 ns | 0.363 ns |  3.72 |    0.06 | 0.0210 |     352 B |        1.26 |
