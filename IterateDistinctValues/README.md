# Iterating distinct values

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25211
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|                                 Method |  Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------------------------- |------- |-----------:|---------:|----------:|-----------:|------:|--------:|---------:|---------:|---------:|----------:|
|                    ForEachUsingHashSet | 100000 | 1,142.5 μs | 38.51 μs | 110.49 μs | 1,108.2 μs |  1.00 |    0.00 | 498.0469 | 498.0469 | 498.0469 | 1699.4 KB |
| ForEachUsingHashSetWithInitialCapacity | 100000 |   613.3 μs | 17.30 μs |  50.73 μs |   598.7 μs |  0.54 |    0.07 |   0.9766 |        - |        - |   5.76 KB |
|                   ForEachUsingDistinct | 100000 | 1,073.2 μs | 38.32 μs | 110.55 μs | 1,032.3 μs |  0.95 |    0.11 |        - |        - |        - |   5.85 KB |
