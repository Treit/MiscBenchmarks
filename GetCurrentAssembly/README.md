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
| GetExecutingAssembly | 370.277 ns | 2.4456 ns | 2.1680 ns |  1.00 |
| TypeofDotAssembly    |   3.761 ns | 0.0323 ns | 0.0252 ns |  0.01 |
