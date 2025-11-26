# Numeric String Comparison Benchmark

This benchmark compares different methods of string comparison when working with strings that consist entirely of digits.

## Results



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count | Mean     | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|------------------------------ |------ |---------:|----------:|----------:|------:|----------:|------------:|
| EqualityOperator              | 1000  | 1.871 μs | 0.0049 μs | 0.0038 μs |  1.00 |         - |          NA |
| StringEqualsOrdinal           | 1000  | 1.877 μs | 0.0220 μs | 0.0206 μs |  1.00 |         - |          NA |
| StringEqualsOrdinalIgnoreCase | 1000  | 2.357 μs | 0.0189 μs | 0.0177 μs |  1.26 |         - |          NA |
| StringInstanceEquals          | 1000  | 2.027 μs | 0.0131 μs | 0.0122 μs |  1.08 |         - |          NA |
| StringInstanceEqualsOrdinal   | 1000  | 2.014 μs | 0.0192 μs | 0.0180 μs |  1.08 |         - |          NA |
