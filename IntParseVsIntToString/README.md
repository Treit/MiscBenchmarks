## Comparing strings and ints





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | Job       | Runtime   | Count  | Mean            | Error         | StdDev        | Ratio | Gen0     | Allocated | Alloc Ratio |
|--------------------- |---------- |---------- |------- |----------------:|--------------:|--------------:|------:|---------:|----------:|------------:|
| **CompareUsingTryParse** | **.NET 10.0** | **.NET 10.0** | **10**     |        **70.37 ns** |      **0.705 ns** |      **0.660 ns** |  **1.00** |        **-** |         **-** |          **NA** |
| CompareUsingToString | .NET 10.0 | .NET 10.0 | 10     |        63.01 ns |      0.789 ns |      0.738 ns |  0.90 |   0.0191 |     320 B |          NA |
|                      |           |           |        |                 |               |               |       |          |           |             |
| CompareUsingTryParse | .NET 9.0  | .NET 9.0  | 10     |        70.48 ns |      0.745 ns |      0.697 ns |  1.00 |        - |         - |          NA |
| CompareUsingToString | .NET 9.0  | .NET 9.0  | 10     |        66.09 ns |      0.856 ns |      0.801 ns |  0.94 |   0.0191 |     320 B |          NA |
|                      |           |           |        |                 |               |               |       |          |           |             |
| **CompareUsingTryParse** | **.NET 10.0** | **.NET 10.0** | **100000** | **1,007,243.55 ns** | **10,845.354 ns** | **10,144.751 ns** |  **1.00** |        **-** |         **-** |          **NA** |
| CompareUsingToString | .NET 10.0 | .NET 10.0 | 100000 |   718,927.84 ns |  9,955.229 ns |  9,312.128 ns |  0.71 | 190.4297 | 3200000 B |          NA |
|                      |           |           |        |                 |               |               |       |          |           |             |
| CompareUsingTryParse | .NET 9.0  | .NET 9.0  | 100000 | 1,003,007.03 ns |  9,867.087 ns |  9,229.679 ns |  1.00 |        - |         - |          NA |
| CompareUsingToString | .NET 9.0  | .NET 9.0  | 100000 |   701,017.89 ns |  8,210.016 ns |  7,277.965 ns |  0.70 | 190.4297 | 3200000 B |          NA |
