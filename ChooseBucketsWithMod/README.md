# Handling negative hash codes when using mod to choose a bucket




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | BucketCount | Mean     | Error   | StdDev  | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |------------ |---------:|--------:|--------:|------:|----------:|------------:|
| IndexViaAdditionAndTwoMods         | 100         | 768.1 ns | 2.76 ns | 2.58 ns |  1.31 |         - |          NA |
| IndexViaMathAbs                    | 100         | 571.3 ns | 3.57 ns | 3.34 ns |  0.98 |         - |          NA |
| IndexViaHandlingNegativeExplicitly | 100         | 569.5 ns | 3.15 ns | 2.95 ns |  0.97 |         - |          NA |
| IndexViaBitwiseAnd                 | 100         | 585.6 ns | 3.09 ns | 2.89 ns |  1.00 |         - |          NA |
