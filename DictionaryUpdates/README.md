# Updating an existing dictionary entry.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **IncrementUsingDictionary**           | **10**    |     **166.3 ns** |     **0.88 ns** |     **0.73 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| IncrementUsingConcurrentDictionary | 10    |     383.3 ns |     2.92 ns |     2.73 ns |  2.30 |    0.02 |       - |         - |          NA |
|                                    |       |              |             |             |       |         |         |           |             |
| **IncrementUsingDictionary**           | **10000** | **429,907.1 ns** | **1,331.05 ns** | **1,179.94 ns** |  **1.00** |    **0.00** | **18.5547** |  **310400 B** |        **1.00** |
| IncrementUsingConcurrentDictionary | 10000 | 566,582.1 ns | 4,063.91 ns | 3,602.55 ns |  1.32 |    0.01 | 18.5547 |  310400 B |        1.00 |
