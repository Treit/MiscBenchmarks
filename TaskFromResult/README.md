# Task.FromResult and Task.CompletedTask


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|              Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
|      TaskFromResult |  5.0635 ns | 0.1629 ns | 0.1600 ns |  5.0410 ns | 1.000 |    0.00 | 0.0043 |      72 B |        1.00 |
| AwaitTaskFromResult | 18.0690 ns | 0.2842 ns | 0.2659 ns | 18.0858 ns | 3.578 |    0.09 | 0.0086 |     144 B |        2.00 |
| ReturnCompletedTask |  0.0001 ns | 0.0003 ns | 0.0003 ns |  0.0000 ns | 0.000 |    0.00 |      - |         - |        0.00 |
|  AwaitCompletedTask |  8.0604 ns | 0.0064 ns | 0.0053 ns |  8.0572 ns | 1.593 |    0.05 |      - |         - |        0.00 |
