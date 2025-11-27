# Flipping the sign of integers





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Job       | Runtime   | Count  | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------- |---------- |---------- |------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| FlipSignUsingMultiplyByMinusOne          | .NET 10.0 | .NET 10.0 | 100000 | 62.97 μs | 0.729 μs | 0.682 μs |  1.00 |    0.01 |         - |          NA |
| FlipSignUsingPrefixDecrementAndBinaryNot | .NET 10.0 | .NET 10.0 | 100000 | 63.51 μs | 0.482 μs | 0.451 μs |  1.01 |    0.01 |         - |          NA |
| FlipSignUsingMinusOneAndBinaryNot        | .NET 10.0 | .NET 10.0 | 100000 | 63.19 μs | 0.548 μs | 0.512 μs |  1.00 |    0.01 |         - |          NA |
|                                          |           |           |        |          |          |          |       |         |           |             |
| FlipSignUsingMultiplyByMinusOne          | .NET 9.0  | .NET 9.0  | 100000 | 62.98 μs | 0.822 μs | 0.769 μs |  1.00 |    0.02 |         - |          NA |
| FlipSignUsingPrefixDecrementAndBinaryNot | .NET 9.0  | .NET 9.0  | 100000 | 64.17 μs | 0.580 μs | 0.542 μs |  1.02 |    0.01 |         - |          NA |
| FlipSignUsingMinusOneAndBinaryNot        | .NET 9.0  | .NET 9.0  | 100000 | 63.55 μs | 0.671 μs | 0.628 μs |  1.01 |    0.02 |         - |          NA |
