# Task.FromResult and Task.CompletedTask





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------- |---------- |---------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| TaskFromResult      | .NET 10.0 | .NET 10.0 |  3.7111 ns | 0.0639 ns | 0.0598 ns |  3.7258 ns | 1.000 |    0.02 | 0.0043 |      72 B |        1.00 |
| AwaitTaskFromResult | .NET 10.0 | .NET 10.0 | 14.6360 ns | 0.1420 ns | 0.1328 ns | 14.6160 ns | 3.945 |    0.07 | 0.0086 |     144 B |        2.00 |
| ReturnCompletedTask | .NET 10.0 | .NET 10.0 |  0.0005 ns | 0.0007 ns | 0.0007 ns |  0.0001 ns | 0.000 |    0.00 |      - |         - |        0.00 |
| AwaitCompletedTask  | .NET 10.0 | .NET 10.0 |  5.5366 ns | 0.0340 ns | 0.0318 ns |  5.5197 ns | 1.492 |    0.02 |      - |         - |        0.00 |
|                     |           |           |            |           |           |            |       |         |        |           |             |
| TaskFromResult      | .NET 9.0  | .NET 9.0  |  3.5940 ns | 0.0578 ns | 0.0540 ns |  3.5832 ns | 1.000 |    0.02 | 0.0043 |      72 B |        1.00 |
| AwaitTaskFromResult | .NET 9.0  | .NET 9.0  | 14.3066 ns | 0.1301 ns | 0.1217 ns | 14.3024 ns | 3.982 |    0.07 | 0.0086 |     144 B |        2.00 |
| ReturnCompletedTask | .NET 9.0  | .NET 9.0  |  0.0009 ns | 0.0013 ns | 0.0011 ns |  0.0009 ns | 0.000 |    0.00 |      - |         - |        0.00 |
| AwaitCompletedTask  | .NET 9.0  | .NET 9.0  |  5.5422 ns | 0.0362 ns | 0.0321 ns |  5.5285 ns | 1.542 |    0.02 |      - |         - |        0.00 |
