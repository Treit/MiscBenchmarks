## Comparing strings and ints


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|               Method |  Count |            Mean |        Error |       StdDev | Ratio |     Gen0 | Allocated | Alloc Ratio |
|--------------------- |------- |----------------:|-------------:|-------------:|------:|---------:|----------:|------------:|
| **CompareUsingTryParse** |     **10** |        **69.37 ns** |     **0.098 ns** |     **0.087 ns** |  **1.00** |        **-** |         **-** |          **NA** |
| CompareUsingToString |     10 |        77.34 ns |     0.960 ns |     0.898 ns |  1.12 |   0.0191 |     320 B |          NA |
|                      |        |                 |              |              |       |          |           |             |
| **CompareUsingTryParse** | **100000** | **1,086,869.11 ns** | **2,531.925 ns** | **2,368.364 ns** |  **1.00** |        **-** |         **-** |          **NA** |
| CompareUsingToString | 100000 |   949,206.63 ns | 2,231.653 ns | 1,742.328 ns |  0.87 | 190.4297 | 3200000 B |          NA |
