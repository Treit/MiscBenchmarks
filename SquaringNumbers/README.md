# Squaring integers



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                   | Count  | Mean        | Error     | StdDev    | Ratio | RatioSD |
|------------------------- |------- |------------:|----------:|----------:|------:|--------:|
| SquareUsingMultiply      | 100000 |    56.15 μs |  0.128 μs |  0.120 μs |  1.00 |    0.00 |
| SquareUsingMathPow       | 100000 | 2,308.38 μs | 14.070 μs | 13.161 μs | 41.11 |    0.24 |
| SquareUsingBigIntegerPow | 100000 | 4,891.11 μs | 31.510 μs | 29.475 μs | 87.10 |    0.54 |
