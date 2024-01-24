# Squaring integers


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                   Method |  Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |
|------------------------- |------- |------------:|----------:|----------:|-------:|--------:|
|      SquareUsingMultiply | 100000 |    46.73 μs |  0.114 μs |  0.107 μs |   1.00 |    0.00 |
|       SquareUsingMathPow | 100000 | 2,294.37 μs |  1.501 μs |  1.172 μs |  49.08 |    0.12 |
| SquareUsingBigIntegerPow | 100000 | 5,473.34 μs | 19.683 μs | 18.411 μs | 117.12 |    0.43 |
