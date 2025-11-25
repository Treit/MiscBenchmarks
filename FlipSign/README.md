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
| FlipSignUsingMultiplyByMinusOne          | 100000 | 63.24 μs | 0.461 μs | 0.431 μs |  1.00 |         - |          NA |
| FlipSignUsingPrefixDecrementAndBinaryNot | 100000 | 63.44 μs | 0.426 μs | 0.399 μs |  1.00 |         - |          NA |
| FlipSignUsingMinusOneAndBinaryNot        | 100000 | 63.87 μs | 0.558 μs | 0.522 μs |  1.01 |         - |          NA |
