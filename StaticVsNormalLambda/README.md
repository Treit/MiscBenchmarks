# Calling static vs. normal lambda.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|       Method |  Count |         Mean |     Error |    StdDev | Allocated |
|------------- |------- |-------------:|----------:|----------:|----------:|
| **StaticLambda** |    **100** |     **68.33 ns** |  **0.047 ns** |  **0.041 ns** |         **-** |
| NormalLambda |    100 |     68.30 ns |  0.044 ns |  0.035 ns |         - |
| **StaticLambda** | **100000** | **62,383.80 ns** | **97.923 ns** | **81.770 ns** |         **-** |
| NormalLambda | 100000 | 62,328.41 ns | 64.926 ns | 57.555 ns |         - |
