# Calling static methods on static and non-static classes.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25956.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-preview.7.23376.3
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|       Method |  Count |         Mean |       Error |      StdDev | Allocated |
|------------- |------- |-------------:|------------:|------------:|----------:|
| **StaticLambda** |    **100** |     **224.4 ns** |     **2.24 ns** |     **2.09 ns** |         **-** |
| NormalLambda |    100 |     223.5 ns |     1.78 ns |     1.49 ns |         - |
| **StaticLambda** | **100000** | **219,485.5 ns** | **1,792.58 ns** | **1,589.07 ns** |         **-** |
| NormalLambda | 100000 | 218,740.3 ns | 1,182.48 ns |   987.43 ns |         - |
