# Squaring integers





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Job       | Runtime   | Count  | Mean        | Error     | StdDev    | Ratio | RatioSD |
|------------------------- |---------- |---------- |------- |------------:|----------:|----------:|------:|--------:|
| SquareUsingMultiply      | .NET 10.0 | .NET 10.0 | 100000 |    55.87 μs |  0.049 μs |  0.043 μs |  1.00 |    0.00 |
| SquareUsingMathPow       | .NET 10.0 | .NET 10.0 | 100000 | 2,296.99 μs |  6.263 μs |  5.858 μs | 41.11 |    0.11 |
| SquareUsingBigIntegerPow | .NET 10.0 | .NET 10.0 | 100000 | 4,913.91 μs |  4.454 μs |  3.949 μs | 87.95 |    0.10 |
|                          |           |           |        |             |           |           |       |         |
| SquareUsingMultiply      | .NET 9.0  | .NET 9.0  | 100000 |    55.77 μs |  0.110 μs |  0.102 μs |  1.00 |    0.00 |
| SquareUsingMathPow       | .NET 9.0  | .NET 9.0  | 100000 | 2,293.17 μs |  4.080 μs |  3.817 μs | 41.12 |    0.10 |
| SquareUsingBigIntegerPow | .NET 9.0  | .NET 9.0  | 100000 | 4,895.57 μs | 14.641 μs | 12.226 μs | 87.78 |    0.26 |
