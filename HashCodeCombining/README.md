# Combining hashcodes


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method | Count |          Mean |     Error |    StdDev |
|----------------------- |------ |--------------:|----------:|----------:|
| **BuiltInHashCodeCombine** |    **10** |     **95.591 ns** | **0.0469 ns** | **0.0416 ns** |
|  CustomHashCodeCombine |    10 |      6.575 ns | 0.0816 ns | 0.0764 ns |
| **BuiltInHashCodeCombine** |  **1000** | **10,893.633 ns** | **9.4047 ns** | **8.7971 ns** |
|  CustomHashCodeCombine |  1000 |    925.335 ns | 1.3300 ns | 1.1790 ns |
