# Squaring integers

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|                   Method |  Count |        Mean |      Error |     StdDev |  Ratio | RatioSD |
|------------------------- |------- |------------:|-----------:|-----------:|-------:|--------:|
|      SquareUsingMultiply | 100000 |    68.08 μs |   1.348 μs |   2.138 μs |   1.00 |    0.00 |
|       SquareUsingMathPow | 100000 | 3,251.28 μs |  73.299 μs | 212.653 μs |  49.79 |    2.68 |
| SquareUsingBigIntegerPow | 100000 | 8,548.82 μs | 148.328 μs | 138.746 μs | 126.77 |    4.76 |
