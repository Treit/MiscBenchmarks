# Flipping the sign of integers

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25201
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.8 (CoreCLR 6.0.822.36306, CoreFX 6.0.822.36306), X64 RyuJIT
  DefaultJob : .NET Core 6.0.8 (CoreCLR 6.0.822.36306, CoreFX 6.0.822.36306), X64 RyuJIT


```
|                                   Method |  Count |     Mean |   Error |  StdDev |   Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |------- |---------:|--------:|--------:|---------:|------:|--------:|------:|------:|------:|----------:|
|          FlipSignUsingMultiplyByMinusOne | 100000 | 209.0 μs | 4.16 μs | 7.07 μs | 208.4 μs |  1.00 |    0.00 |     - |     - |     - |         - |
| FlipSignUsingPrefixDecrementAndBinaryNot | 100000 | 122.0 μs | 2.42 μs | 6.79 μs | 119.4 μs |  0.58 |    0.04 |     - |     - |     - |         - |
|        FlipSignUsingMinusOneAndBinaryNot | 100000 | 120.3 μs | 2.21 μs | 3.50 μs | 120.4 μs |  0.57 |    0.02 |     - |     - |     - |         - |
