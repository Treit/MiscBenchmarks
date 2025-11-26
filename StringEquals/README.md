# Different methods of comparing strings


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | numIterations | Mean      | Error    | StdDev   |
|---------------------------- |-------------- |----------:|---------:|---------:|
| **EqualsObject**                | **10**            |  **31.34 ns** | **0.487 ns** | **0.432 ns** |
| EqualsString                | 10            |  31.85 ns | 0.363 ns | 0.339 ns |
| EqualsStringExplicitOrdinal | 10            |  31.90 ns | 0.264 ns | 0.246 ns |
| EqualsStringOperator        | 10            |  32.59 ns | 0.252 ns | 0.236 ns |
| **EqualsObject**                | **100**           | **312.98 ns** | **2.580 ns** | **2.414 ns** |
| EqualsString                | 100           | 311.78 ns | 2.078 ns | 1.944 ns |
| EqualsStringExplicitOrdinal | 100           | 314.65 ns | 1.596 ns | 1.493 ns |
| EqualsStringOperator        | 100           | 312.86 ns | 1.789 ns | 1.674 ns |
