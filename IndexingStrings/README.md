# Indexing strings

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22538
Unknown processor
.NET Core SDK=6.0.101
  [Host]     : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET Core 6.0.1 (CoreCLR 6.0.121.56705, CoreFX 6.0.121.56705), X64 RyuJIT


```
|                                    Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------------ |------ |---------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|                       FindIndexesInString |  1000 | 8.330 μs | 0.1857 μs | 0.5358 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|                     FindIndexesInIntArray |  1000 | 8.298 μs | 0.1756 μs | 0.5009 μs |  1.00 |    0.09 |     - |     - |     - |         - |
|                    FindIndexesInCharArray |  1000 | 8.026 μs | 0.1593 μs | 0.2872 μs |  0.98 |    0.08 |     - |     - |     - |         - |
| FindIndexesPointerArithmeticIntoCharArray |  1000 | 7.406 μs | 0.1462 μs | 0.2986 μs |  0.89 |    0.08 |     - |     - |     - |         - |
|                   FindIndexesBytePointers |  1000 | 8.261 μs | 0.2263 μs | 0.6309 μs |  1.00 |    0.10 |     - |     - |     - |         - |
