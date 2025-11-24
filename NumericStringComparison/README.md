# Numeric String Comparison Benchmark

This benchmark compares different methods of string comparison when working with strings that consist entirely of digits.

## Results


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27965.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| EqualityOperator              | 1000  | 2.912 μs | 0.0578 μs | 0.1182 μs |  1.00 |    0.06 |         - |          NA |
| StringEqualsOrdinal           | 1000  | 2.774 μs | 0.0526 μs | 0.0754 μs |  0.95 |    0.05 |         - |          NA |
| StringEqualsOrdinalIgnoreCase | 1000  | 4.797 μs | 0.0676 μs | 0.0632 μs |  1.65 |    0.07 |         - |          NA |
| StringInstanceEquals          | 1000  | 3.291 μs | 0.0625 μs | 0.0719 μs |  1.13 |    0.05 |         - |          NA |
| StringInstanceEqualsOrdinal   | 1000  | 2.578 μs | 0.0514 μs | 0.0816 μs |  0.89 |    0.04 |         - |          NA |
