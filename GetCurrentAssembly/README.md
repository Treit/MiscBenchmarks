# Getting the current assembly.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Job       | Runtime   | Mean       | Error     | StdDev    | Ratio |
|--------------------- |---------- |---------- |-----------:|----------:|----------:|------:|
| GetExecutingAssembly | .NET 10.0 | .NET 10.0 | 369.993 ns | 1.9929 ns | 1.6642 ns |  1.00 |
| TypeofDotAssembly    | .NET 10.0 | .NET 10.0 |   3.788 ns | 0.0208 ns | 0.0174 ns |  0.01 |
|                      |           |           |            |           |           |       |
| GetExecutingAssembly | .NET 9.0  | .NET 9.0  | 367.795 ns | 1.9139 ns | 1.5982 ns |  1.00 |
| TypeofDotAssembly    | .NET 9.0  | .NET 9.0  |   3.815 ns | 0.0153 ns | 0.0144 ns |  0.01 |
