# Illustrating the overhead of unboxing





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Job       | Runtime   | Count  | Mean        | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|-------------------------- |---------- |---------- |------- |------------:|----------:|----------:|------:|----------:|------------:|
| **SumIntListWithoutUnboxing** | **.NET 10.0** | **.NET 10.0** | **1000**   |    **628.4 ns** |   **3.05 ns** |   **2.85 ns** |  **1.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | .NET 10.0 | .NET 10.0 | 1000   |    808.9 ns |   2.37 ns |   1.98 ns |  1.29 |         - |          NA |
|                           |           |           |        |             |           |           |       |           |             |
| SumIntListWithoutUnboxing | .NET 9.0  | .NET 9.0  | 1000   |    625.7 ns |   1.02 ns |   0.90 ns |  1.00 |         - |          NA |
| SumObjectListWithUnboxing | .NET 9.0  | .NET 9.0  | 1000   |    807.5 ns |   3.02 ns |   2.67 ns |  1.29 |         - |          NA |
|                           |           |           |        |             |           |           |       |           |             |
| **SumIntListWithoutUnboxing** | **.NET 10.0** | **.NET 10.0** | **100000** | **62,222.8 ns** | **157.11 ns** | **139.27 ns** |  **1.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | .NET 10.0 | .NET 10.0 | 100000 | 81,921.0 ns | 176.59 ns | 165.18 ns |  1.32 |         - |          NA |
|                           |           |           |        |             |           |           |       |           |             |
| SumIntListWithoutUnboxing | .NET 9.0  | .NET 9.0  | 100000 | 62,405.0 ns | 465.11 ns | 412.31 ns |  1.00 |         - |          NA |
| SumObjectListWithUnboxing | .NET 9.0  | .NET 9.0  | 100000 | 81,953.6 ns | 168.18 ns | 140.44 ns |  1.31 |         - |          NA |
