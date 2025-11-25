# Task.FromResult and Task.CompletedTask



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| TaskFromResult      |  4.5163 ns | 0.0817 ns | 0.0724 ns |  4.5178 ns | 1.000 |    0.02 | 0.0043 |      72 B |        1.00 |
| AwaitTaskFromResult | 15.4979 ns | 0.3711 ns | 0.3471 ns | 15.5288 ns | 3.432 |    0.09 | 0.0086 |     144 B |        2.00 |
| ReturnCompletedTask |  0.0001 ns | 0.0005 ns | 0.0005 ns |  0.0000 ns | 0.000 |    0.00 |      - |         - |        0.00 |
| AwaitCompletedTask  |  5.5924 ns | 0.0410 ns | 0.0384 ns |  5.5955 ns | 1.239 |    0.02 |      - |         - |        0.00 |
