# Combining hashcodes

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen Threadripper 3960X, 1 CPU, 48 logical and 24 physical cores
.NET Core SDK=6.0.201
  [Host]     : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET Core 5.0.7 (CoreCLR 5.0.721.25508, CoreFX 5.0.721.25508), X64 RyuJIT


```
|                 Method | Count |         Mean |      Error |     StdDev |
|----------------------- |------ |-------------:|-----------:|-----------:|
| **BuiltInHashCodeCombine** |    **10** |    **42.672 ns** |  **0.2382 ns** |  **0.2228 ns** |
|  CustomHashCodeCombine |    10 |     5.186 ns |  0.0322 ns |  0.0301 ns |
| **BuiltInHashCodeCombine** |  **1000** | **5,705.831 ns** | **23.7152 ns** | **22.1832 ns** |
|  CustomHashCodeCombine |  1000 |   685.878 ns |  4.6549 ns |  4.3542 ns |
