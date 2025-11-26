# Flipping the sign of integers




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                   | Count  | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|----------------------------------------- |------- |---------:|---------:|---------:|------:|----------:|------------:|
| FlipSignUsingMultiplyByMinusOne          | 100000 | 62.86 μs | 0.636 μs | 0.564 μs |  1.00 |         - |          NA |
| FlipSignUsingPrefixDecrementAndBinaryNot | 100000 | 63.75 μs | 0.582 μs | 0.544 μs |  1.01 |         - |          NA |
| FlipSignUsingMinusOneAndBinaryNot        | 100000 | 63.72 μs | 0.503 μs | 0.470 μs |  1.01 |         - |          NA |
