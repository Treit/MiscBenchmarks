# Finding max value of a list of ints



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|        Method |     Count |             Mean |          Error |         StdDev | Ratio | Allocated | Alloc Ratio |
|-------------- |---------- |-----------------:|---------------:|---------------:|------:|----------:|------------:|
|   **MaxWithLoop** |      **1000** |        **336.73 ns** |       **2.422 ns** |       **2.023 ns** |  **1.00** |         **-** |          **NA** |
| EnumerableMax |      1000 |         57.67 ns |       0.289 ns |       0.256 ns |  0.17 |         - |          NA |
|               |           |                  |                |                |       |           |             |
|   **MaxWithLoop** | **100000000** | **33,846,473.33 ns** | **152,791.655 ns** | **142,921.409 ns** |  **1.00** |         **-** |          **NA** |
| EnumerableMax | 100000000 | 16,800,733.12 ns | 130,410.255 ns | 121,985.833 ns |  0.50 |         - |          NA |
