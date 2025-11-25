# Illustrating the overhead of unboxing



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | Count  | Mean        | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|-------------------------- |------- |------------:|----------:|----------:|------:|----------:|------------:|
| **SumIntListWithoutUnboxing** | **1000**   |    **632.0 ns** |   **5.48 ns** |   **5.13 ns** |  **1.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | 1000   |    813.5 ns |   4.23 ns |   3.96 ns |  1.29 |         - |          NA |
|                           |        |             |           |           |       |           |             |
| **SumIntListWithoutUnboxing** | **100000** | **62,720.6 ns** | **406.27 ns** | **380.02 ns** |  **1.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | 100000 | 81,590.8 ns | 521.59 ns | 487.89 ns |  1.30 |         - |          NA |
