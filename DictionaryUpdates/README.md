# Updating an existing dictionary entry.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean         | Error       | StdDev      | Ratio | Gen0    | Allocated | Alloc Ratio |
|----------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|----------:|------------:|
| **IncrementUsingDictionary**           | **10**    |     **167.6 ns** |     **0.94 ns** |     **0.88 ns** |  **1.00** |       **-** |         **-** |          **NA** |
| IncrementUsingConcurrentDictionary | 10    |     382.9 ns |     1.52 ns |     1.35 ns |  2.28 |       - |         - |          NA |
|                                    |       |              |             |             |       |         |           |             |
| **IncrementUsingDictionary**           | **10000** | **424,811.1 ns** | **1,656.37 ns** | **1,549.37 ns** |  **1.00** | **18.5547** |  **310400 B** |        **1.00** |
| IncrementUsingConcurrentDictionary | 10000 | 560,082.1 ns | 4,901.33 ns | 4,584.70 ns |  1.32 | 18.5547 |  310400 B |        1.00 |
