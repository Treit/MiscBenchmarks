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
| **SumIntListWithoutUnboxing** | **1000**   |    **632.5 ns** |   **4.13 ns** |   **3.86 ns** |  **1.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | 1000   |    823.9 ns |   4.92 ns |   4.60 ns |  1.30 |         - |          NA |
|                           |        |             |           |           |       |           |             |
| **SumIntListWithoutUnboxing** | **100000** | **62,765.9 ns** | **571.54 ns** | **534.62 ns** |  **1.00** |         **-** |          **NA** |
| SumObjectListWithUnboxing | 100000 | 82,394.1 ns | 651.56 ns | 609.47 ns |  1.31 |         - |          NA |
