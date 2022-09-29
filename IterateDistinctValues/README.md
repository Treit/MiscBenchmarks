# Iterating distinct values

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25211
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT
  DefaultJob : .NET Core 6.0.9 (CoreCLR 6.0.922.41905, CoreFX 6.0.922.41905), X64 RyuJIT


```
|               Method |  Count |     Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------- |------- |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
|  ForEachUsingHashSet | 100000 | 1.080 ms | 0.0311 ms | 0.0892 ms |  1.00 |    0.00 | 498.0469 | 498.0469 | 498.0469 | 1699.4 KB |
| ForEachUsingDistinct | 100000 | 1.024 ms | 0.0203 ms | 0.0450 ms |  0.97 |    0.09 |   0.9766 |        - |        - |   5.85 KB |
