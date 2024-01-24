# Finding max value of an array of ints



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|        Method |     Count |             Mean |          Error |         StdDev | Ratio | Allocated | Alloc Ratio |
|-------------- |---------- |-----------------:|---------------:|---------------:|------:|----------:|------------:|
|   **MaxWithLoop** |      **1000** |        **337.45 ns** |       **2.312 ns** |       **2.163 ns** |  **1.00** |         **-** |          **NA** |
| EnumerableMax |      1000 |         57.75 ns |       0.043 ns |       0.040 ns |  0.17 |         - |          NA |
|               |           |                  |                |                |       |           |             |
|   **MaxWithLoop** | **100000000** | **33,197,994.44 ns** | **167,429.735 ns** | **156,613.878 ns** |  **1.00** |         **-** |          **NA** |
| EnumerableMax | 100000000 | 16,747,956.92 ns |  74,852.511 ns |  66,354.801 ns |  0.50 |         - |          NA |
