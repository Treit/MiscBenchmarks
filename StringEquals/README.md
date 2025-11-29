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
| **EqualsObject**                | **10**            |  **31.62 ns** | **0.212 ns** | **0.199 ns** |
| EqualsString                | 10            |  31.67 ns | 0.245 ns | 0.230 ns |
| EqualsStringExplicitOrdinal | 10            |  31.53 ns | 0.297 ns | 0.278 ns |
| EqualsStringOperator        | 10            |  32.40 ns | 0.209 ns | 0.174 ns |
| **EqualsObject**                | **100**           | **311.94 ns** | **2.903 ns** | **2.573 ns** |
| EqualsString                | 100           | 309.89 ns | 0.535 ns | 0.501 ns |
| EqualsStringExplicitOrdinal | 100           | 312.92 ns | 1.595 ns | 1.492 ns |
| EqualsStringOperator        | 100           | 312.21 ns | 1.002 ns | 0.837 ns |
