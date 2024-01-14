# Updating an existing dictionary entry.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                             Method | Count |         Mean |       Error |      StdDev | Ratio |    Gen0 | Allocated | Alloc Ratio |
|----------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|----------:|------------:|
|           **IncrementUsingDictionary** |    **10** |     **296.5 ns** |     **0.39 ns** |     **0.35 ns** |  **1.00** |       **-** |         **-** |          **NA** |
| IncrementUsingConcurrentDictionary |    10 |     549.3 ns |     1.37 ns |     1.21 ns |  1.85 |       - |         - |          NA |
|                                    |       |              |             |             |       |         |           |             |
|           **IncrementUsingDictionary** | **10000** | **524,790.1 ns** | **1,538.09 ns** | **1,438.73 ns** |  **1.00** | **18.5547** |  **310400 B** |        **1.00** |
| IncrementUsingConcurrentDictionary | 10000 | 796,425.9 ns | 1,906.04 ns | 1,591.63 ns |  1.52 | 18.5547 |  310400 B |        1.00 |
