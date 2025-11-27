# Handling negative hash codes when using mod to choose a bucket





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | BucketCount | Mean     | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------------ |---------:|--------:|--------:|------:|----------:|------------:|
| IndexViaAdditionAndTwoMods         | .NET 10.0 | .NET 10.0 | 100         | 767.9 ns | 2.62 ns | 2.33 ns |  1.31 |         - |          NA |
| IndexViaMathAbs                    | .NET 10.0 | .NET 10.0 | 100         | 553.3 ns | 4.34 ns | 4.06 ns |  0.94 |         - |          NA |
| IndexViaHandlingNegativeExplicitly | .NET 10.0 | .NET 10.0 | 100         | 570.8 ns | 3.48 ns | 3.26 ns |  0.97 |         - |          NA |
| IndexViaBitwiseAnd                 | .NET 10.0 | .NET 10.0 | 100         | 586.5 ns | 3.85 ns | 3.60 ns |  1.00 |         - |          NA |
|                                    |           |           |             |          |         |         |       |           |             |
| IndexViaAdditionAndTwoMods         | .NET 9.0  | .NET 9.0  | 100         | 768.4 ns | 3.20 ns | 2.99 ns |  1.31 |         - |          NA |
| IndexViaMathAbs                    | .NET 9.0  | .NET 9.0  | 100         | 571.0 ns | 3.45 ns | 3.23 ns |  0.97 |         - |          NA |
| IndexViaHandlingNegativeExplicitly | .NET 9.0  | .NET 9.0  | 100         | 571.8 ns | 4.11 ns | 3.64 ns |  0.98 |         - |          NA |
| IndexViaBitwiseAnd                 | .NET 9.0  | .NET 9.0  | 100         | 586.3 ns | 3.37 ns | 3.15 ns |  1.00 |         - |          NA |
