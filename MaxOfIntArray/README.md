# Finding max value of an array of ints


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26020.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|        Method |     Count |             Mean |           Error |          StdDev | Ratio | Allocated | Alloc Ratio |
|-------------- |---------- |-----------------:|----------------:|----------------:|------:|----------:|------------:|
|   **MaxWithLoop** |      **1000** |       **1,510.5 ns** |        **29.46 ns** |        **36.18 ns** |  **1.00** |         **-** |          **NA** |
| EnumerableMax |      1000 |         124.2 ns |         2.51 ns |         6.31 ns |  0.08 |         - |          NA |
|               |           |                  |                 |                 |       |           |             |
|   **MaxWithLoop** | **100000000** | **151,134,552.8 ns** | **2,432,410.16 ns** | **2,602,651.62 ns** |  **1.00** |     **126 B** |        **1.00** |
| EnumerableMax | 100000000 |  35,946,050.9 ns |   696,640.90 ns |   881,027.68 ns |  0.24 |      36 B |        0.29 |
