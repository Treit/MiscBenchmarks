# Calling static methods on static and non-static classes.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                           Method |  Count |         Mean |       Error |      StdDev |    Gen0 | Allocated |
|--------------------------------- |------- |-------------:|------------:|------------:|--------:|----------:|
|    **CallStaticMethodOnStaticClass** |    **100** |     **888.4 ns** |     **4.74 ns** |     **4.44 ns** |  **0.1011** |   **1.66 KB** |
| CallStaticMethodOnNonStaticClass |    100 |     878.2 ns |     2.89 ns |     2.42 ns |  0.1011 |   1.66 KB |
|    **CallStaticMethodOnStaticClass** | **100000** | **844,231.1 ns** | **5,538.16 ns** | **5,180.40 ns** | **94.7266** | **1562.6 KB** |
| CallStaticMethodOnNonStaticClass | 100000 | 975,529.4 ns | 6,860.84 ns | 6,081.96 ns | 94.7266 | 1562.6 KB |
