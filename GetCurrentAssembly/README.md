# Getting the current assembly.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Mean       | Error     | StdDev    | Ratio |
|--------------------- |-----------:|----------:|----------:|------:|
| GetExecutingAssembly | 368.855 ns | 1.5691 ns | 1.4678 ns |  1.00 |
| TypeofDotAssembly    |   3.783 ns | 0.0168 ns | 0.0140 ns |  0.01 |
