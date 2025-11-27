# Updating an existing dictionary entry.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|----------:|------------:|
| **IncrementUsingDictionary**           | **.NET 10.0** | **.NET 10.0** | **10**    |     **167.2 ns** |     **1.06 ns** |     **0.94 ns** |  **1.00** |    **0.01** |       **-** |         **-** |          **NA** |
| IncrementUsingConcurrentDictionary | .NET 10.0 | .NET 10.0 | 10    |     379.3 ns |     3.39 ns |     3.18 ns |  2.27 |    0.02 |       - |         - |          NA |
|                                    |           |           |       |              |             |             |       |         |         |           |             |
| IncrementUsingDictionary           | .NET 9.0  | .NET 9.0  | 10    |     166.8 ns |     1.03 ns |     0.86 ns |  1.00 |    0.01 |       - |         - |          NA |
| IncrementUsingConcurrentDictionary | .NET 9.0  | .NET 9.0  | 10    |     384.4 ns |     2.16 ns |     2.02 ns |  2.30 |    0.02 |       - |         - |          NA |
|                                    |           |           |       |              |             |             |       |         |         |           |             |
| **IncrementUsingDictionary**           | **.NET 10.0** | **.NET 10.0** | **10000** | **432,845.7 ns** | **2,567.72 ns** | **2,401.85 ns** |  **1.00** |    **0.01** | **18.5547** |  **310400 B** |        **1.00** |
| IncrementUsingConcurrentDictionary | .NET 10.0 | .NET 10.0 | 10000 | 550,790.3 ns | 6,023.71 ns | 5,634.58 ns |  1.27 |    0.01 | 18.5547 |  310400 B |        1.00 |
|                                    |           |           |       |              |             |             |       |         |         |           |             |
| IncrementUsingDictionary           | .NET 9.0  | .NET 9.0  | 10000 | 418,630.0 ns | 3,512.70 ns | 3,113.91 ns |  1.00 |    0.01 | 18.5547 |  310400 B |        1.00 |
| IncrementUsingConcurrentDictionary | .NET 9.0  | .NET 9.0  | 10000 | 558,002.1 ns | 7,412.27 ns | 6,933.45 ns |  1.33 |    0.02 | 18.5547 |  310400 B |        1.00 |
