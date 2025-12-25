# List.Exists vs LINQ Any

```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6345/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  .NET 8.0  : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3


```
| Method              | Job       | Runtime   | Count   | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |---------- |---------- |-------- |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **ListExists_Found**    | **.NET 10.0** | **.NET 10.0** | **100**     |       **229.52 ns** |      **4.241 ns** |      **4.165 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| LinqAny_Found       | .NET 10.0 | .NET 10.0 | 100     |        46.48 ns |      0.962 ns |      1.250 ns |  0.20 |    0.01 |         - |          NA |
| ListExists_NotFound | .NET 10.0 | .NET 10.0 | 100     |       227.77 ns |      4.473 ns |      4.393 ns |  0.99 |    0.03 |         - |          NA |
| LinqAny_NotFound    | .NET 10.0 | .NET 10.0 | 100     |        42.49 ns |      0.522 ns |      0.489 ns |  0.19 |    0.00 |         - |          NA |
|                     |           |           |         |                 |               |               |       |         |           |             |
| ListExists_Found    | .NET 8.0  | .NET 8.0  | 100     |       228.70 ns |      3.783 ns |      3.716 ns |  1.00 |    0.02 |         - |          NA |
| LinqAny_Found       | .NET 8.0  | .NET 8.0  | 100     |        50.69 ns |      0.920 ns |      1.130 ns |  0.22 |    0.01 |         - |          NA |
| ListExists_NotFound | .NET 8.0  | .NET 8.0  | 100     |       229.17 ns |      4.500 ns |      4.420 ns |  1.00 |    0.02 |         - |          NA |
| LinqAny_NotFound    | .NET 8.0  | .NET 8.0  | 100     |        43.07 ns |      0.895 ns |      0.994 ns |  0.19 |    0.01 |         - |          NA |
|                     |           |           |         |                 |               |               |       |         |           |             |
| **ListExists_Found**    | **.NET 10.0** | **.NET 10.0** | **1000000** | **2,229,135.14 ns** | **37,155.905 ns** | **34,755.657 ns** |  **1.00** |    **0.02** |         **-** |          **NA** |
| LinqAny_Found       | .NET 10.0 | .NET 10.0 | 1000000 |   344,104.34 ns |  6,700.020 ns |  9,608.969 ns |  0.15 |    0.00 |         - |          NA |
| ListExists_NotFound | .NET 10.0 | .NET 10.0 | 1000000 | 2,207,986.48 ns | 20,712.713 ns | 19,374.685 ns |  0.99 |    0.02 |         - |          NA |
| LinqAny_NotFound    | .NET 10.0 | .NET 10.0 | 1000000 |   335,051.18 ns |  3,583.205 ns |  2,797.530 ns |  0.15 |    0.00 |         - |          NA |
|                     |           |           |         |                 |               |               |       |         |           |             |
| ListExists_Found    | .NET 8.0  | .NET 8.0  | 1000000 | 2,216,529.64 ns | 21,164.455 ns | 19,797.245 ns |  1.00 |    0.01 |         - |          NA |
| LinqAny_Found       | .NET 8.0  | .NET 8.0  | 1000000 |   335,744.00 ns |  4,658.865 ns |  3,890.363 ns |  0.15 |    0.00 |         - |          NA |
| ListExists_NotFound | .NET 8.0  | .NET 8.0  | 1000000 | 2,208,210.76 ns | 13,520.434 ns | 12,647.022 ns |  1.00 |    0.01 |         - |          NA |
| LinqAny_NotFound    | .NET 8.0  | .NET 8.0  | 1000000 |   334,092.86 ns |  6,459.492 ns |  5,393.969 ns |  0.15 |    0.00 |         - |          NA |
