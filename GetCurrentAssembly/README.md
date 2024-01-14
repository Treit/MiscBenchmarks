# Getting the current assembly.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|               Method |       Mean |     Error |    StdDev | Ratio |
|--------------------- |-----------:|----------:|----------:|------:|
| GetExecutingAssembly | 572.528 ns | 1.4878 ns | 1.3917 ns |  1.00 |
|    TypeofDotAssembly |   7.463 ns | 0.0229 ns | 0.0203 ns |  0.01 |
