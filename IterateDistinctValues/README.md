# Iterating distinct values

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25211
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|                                 Method |  Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------------------------- |------- |-----------:|---------:|---------:|-----------:|------:|--------:|---------:|---------:|---------:|----------:|
|                    ForEachUsingHashSet | 100000 | 1,157.5 μs | 32.76 μs | 93.99 μs | 1,134.6 μs |  1.00 |    0.00 | 498.0469 | 498.0469 | 498.0469 | 1699.4 KB |
| ForEachUsingHashSetWithInitialCapacity | 100000 |   615.3 μs | 16.07 μs | 45.84 μs |   602.2 μs |  0.54 |    0.05 |   0.9766 |        - |        - |   5.76 KB |
|                   ForEachUsingDistinct | 100000 |   980.0 μs | 19.55 μs | 42.50 μs |   972.3 μs |  0.85 |    0.08 |        - |        - |        - |   5.85 KB |
