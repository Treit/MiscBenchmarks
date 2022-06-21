# Squaring integers

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.25140
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=7.0.100-preview.5.22307.18
  [Host]     : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET Core 6.0.6 (CoreCLR 6.0.622.26707, CoreFX 6.0.622.26707), X64 RyuJIT


```
|              Method |  Count |           Mean |        Error |        StdDev | Ratio | RatioSD |
|-------------------- |------- |---------------:|-------------:|--------------:|------:|--------:|
| **SquareUsingMultiply** |   **1000** |       **736.6 ns** |     **21.52 ns** |      **61.04 ns** |  **1.00** |    **0.00** |
|  SquareUsingMathPow |   1000 |    33,241.7 ns |    731.74 ns |   2,027.64 ns | 45.58 |    4.81 |
|                     |        |                |              |               |       |         |
| **SquareUsingMultiply** | **100000** |    **73,892.0 ns** |  **1,890.83 ns** |   **5,515.64 ns** |  **1.00** |    **0.00** |
|  SquareUsingMathPow | 100000 | 3,460,933.2 ns | 74,694.58 ns | 214,312.74 ns | 47.13 |    4.85 |
