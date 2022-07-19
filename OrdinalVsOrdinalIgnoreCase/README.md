# Ordinal vs OrdinalIgnoreCase

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25163
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                       Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |
|----------------------------- |------ |-----------:|----------:|----------:|------:|--------:|----------:|
|                      Ordinal |  1000 |   9.964 μs | 0.1920 μs | 0.2212 μs |  1.00 |    0.00 |     729 B |
|            OrdinalIgnoreCase |  1000 |   7.948 μs | 0.0955 μs | 0.0847 μs |  0.80 |    0.02 |     729 B |
|           OrdinalLongStrings |  1000 |  20.559 μs | 0.4083 μs | 0.5014 μs |  2.07 |    0.08 |     729 B |
| OrdinalIgnoreCaseLongStrings |  1000 | 318.542 μs | 2.2530 μs | 2.1075 μs | 32.07 |    0.65 |     729 B |
