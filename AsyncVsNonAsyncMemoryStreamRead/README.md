# Async vs. non-async reads of a MemoryStream

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22572
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.200
  [Host]     : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET Core 5.0.12 (CoreCLR 5.0.1221.52207, CoreFX 5.0.1221.52207), X64 RyuJIT


```
|                                   Method |   Count |     Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |-------- |---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                         **ReadMemoryStream** |    **1000** | **27.07 ns** | **1.486 ns** |  **4.359 ns** |  **1.00** |    **0.00** | **0.0649** |     **-** |     **-** |     **280 B** |
|                    ReadMemoryStreamAsync |    1000 | 70.99 ns | 3.670 ns | 10.820 ns |  2.68 |    0.52 | 0.0815 |     - |     - |     352 B |
| ReadMemoryStreamAsyncCancelTokenOverload |    1000 | 92.91 ns | 3.848 ns | 11.102 ns |  3.54 |    0.73 | 0.0815 |     - |     - |     352 B |
|                                          |         |          |          |           |       |         |        |       |       |           |
|                         **ReadMemoryStream** |  **100000** | **30.37 ns** | **1.774 ns** |  **5.231 ns** |  **1.00** |    **0.00** | **0.0649** |     **-** |     **-** |     **280 B** |
|                    ReadMemoryStreamAsync |  100000 | 86.95 ns | 3.974 ns | 11.717 ns |  2.93 |    0.58 | 0.0815 |     - |     - |     352 B |
| ReadMemoryStreamAsyncCancelTokenOverload |  100000 | 89.40 ns | 3.583 ns | 10.564 ns |  3.03 |    0.62 | 0.0815 |     - |     - |     352 B |
|                                          |         |          |          |           |       |         |        |       |       |           |
|                         **ReadMemoryStream** | **1000000** | **27.70 ns** | **1.197 ns** |  **3.530 ns** |  **1.00** |    **0.00** | **0.0649** |     **-** |     **-** |     **280 B** |
|                    ReadMemoryStreamAsync | 1000000 | 78.98 ns | 3.515 ns | 10.365 ns |  2.91 |    0.57 | 0.0815 |     - |     - |     352 B |
| ReadMemoryStreamAsyncCancelTokenOverload | 1000000 | 92.77 ns | 4.089 ns | 11.993 ns |  3.41 |    0.63 | 0.0815 |     - |     - |     352 B |
