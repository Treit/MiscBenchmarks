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
| TaskFromResult      |  4.6433 ns | 0.1280 ns | 0.1198 ns |  4.6674 ns | 1.001 |    0.04 | 0.0043 |      72 B |        1.00 |
| AwaitTaskFromResult | 15.5537 ns | 0.3290 ns | 0.3078 ns | 15.5158 ns | 3.352 |    0.11 | 0.0086 |     144 B |        2.00 |
| ReturnCompletedTask |  0.0014 ns | 0.0020 ns | 0.0019 ns |  0.0007 ns | 0.000 |    0.00 |      - |         - |        0.00 |
| AwaitCompletedTask  |  5.6130 ns | 0.0222 ns | 0.0208 ns |  5.6137 ns | 1.210 |    0.03 |      - |         - |        0.00 |
