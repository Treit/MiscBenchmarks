# Summing integer arrays



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method          | Job       | Runtime   | Count | Mean         | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------- |---------- |---------- |------ |-------------:|----------:|----------:|------:|--------:|----------:|------------:|
| **SumUsingForLoop** | **.NET 10.0** | **.NET 10.0** | **10**    |     **3.423 ns** | **0.0873 ns** | **0.0774 ns** |  **0.80** |    **0.02** |         **-** |          **NA** |
| SumUsingLinqSum | .NET 10.0 | .NET 10.0 | 10    |     4.262 ns | 0.0039 ns | 0.0030 ns |  1.00 |    0.00 |         - |          NA |
|                 |           |           |       |              |           |           |       |         |           |             |
| SumUsingForLoop | .NET 9.0  | .NET 9.0  | 10    |     3.380 ns | 0.0248 ns | 0.0232 ns |  0.78 |    0.01 |         - |          NA |
| SumUsingLinqSum | .NET 9.0  | .NET 9.0  | 10    |     4.320 ns | 0.0084 ns | 0.0070 ns |  1.00 |    0.00 |         - |          NA |
|                 |           |           |       |              |           |           |       |         |           |             |
| **SumUsingForLoop** | **.NET 10.0** | **.NET 10.0** | **10000** | **3,130.511 ns** | **5.8267 ns** | **5.1652 ns** |  **3.50** |    **0.01** |         **-** |          **NA** |
| SumUsingLinqSum | .NET 10.0 | .NET 10.0 | 10000 |   895.105 ns | 0.4455 ns | 0.4167 ns |  1.00 |    0.00 |         - |          NA |
|                 |           |           |       |              |           |           |       |         |           |             |
| SumUsingForLoop | .NET 9.0  | .NET 9.0  | 10000 | 3,126.909 ns | 3.4828 ns | 3.0874 ns |  3.49 |    0.00 |         - |          NA |
| SumUsingLinqSum | .NET 9.0  | .NET 9.0  | 10000 |   895.662 ns | 0.8928 ns | 0.8352 ns |  1.00 |    0.00 |         - |          NA |
