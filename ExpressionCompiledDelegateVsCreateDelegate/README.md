# ExpressionCompiledDelegateVsCreateDelegate

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.7376/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.302
  [Host]    : .NET 10.0.10 (10.0.1026.32716), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.10 (10.0.1026.32716), X64 RyuJIT AVX2

Job=.NET 10.0  Runtime=.NET 10.0  

```
| Method                     | Size     | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |--------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| **MethodInfoCreateDelegate**   | **100**      | **0.1452 ns** | **0.0415 ns** | **0.0893 ns** |  **1.45** |    **1.38** |         **-** |          **NA** |
| ExpressionCompiledDelegate | 100      | 1.3067 ns | 0.0405 ns | 0.0359 ns | 13.08 |    8.15 |         - |          NA |
|                            |          |           |           |           |       |         |           |             |
| **MethodInfoCreateDelegate**   | **10000000** | **0.3140 ns** | **0.0300 ns** | **0.0280 ns** |  **1.01** |    **0.12** |         **-** |          **NA** |
| ExpressionCompiledDelegate | 10000000 | 1.3203 ns | 0.0199 ns | 0.0186 ns |  4.24 |    0.36 |         - |          NA |
