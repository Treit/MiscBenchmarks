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
| SquareUsingMultiply      | 100000 |    56.04 μs |  0.153 μs |  0.135 μs |  1.00 |    0.00 |
| SquareUsingMathPow       | 100000 | 2,305.79 μs | 12.966 μs | 12.129 μs | 41.15 |    0.23 |
| SquareUsingBigIntegerPow | 100000 | 4,894.40 μs | 33.719 μs | 31.540 μs | 87.34 |    0.58 |
