# Numeric String Comparison Benchmark

This benchmark compares different methods of string comparison when working with strings that consist entirely of digits.

## Results




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Job       | Runtime   | Count | Mean     | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |---------- |---------- |------ |---------:|----------:|----------:|------:|--------:|----------:|------------:|
| EqualityOperator              | .NET 10.0 | .NET 10.0 | 1000  | 1.873 μs | 0.0066 μs | 0.0055 μs |  1.00 |    0.00 |         - |          NA |
| StringEqualsOrdinal           | .NET 10.0 | .NET 10.0 | 1000  | 1.862 μs | 0.0181 μs | 0.0151 μs |  0.99 |    0.01 |         - |          NA |
| StringEqualsOrdinalIgnoreCase | .NET 10.0 | .NET 10.0 | 1000  | 2.330 μs | 0.0064 μs | 0.0057 μs |  1.24 |    0.00 |         - |          NA |
| StringInstanceEquals          | .NET 10.0 | .NET 10.0 | 1000  | 1.994 μs | 0.0220 μs | 0.0206 μs |  1.06 |    0.01 |         - |          NA |
| StringInstanceEqualsOrdinal   | .NET 10.0 | .NET 10.0 | 1000  | 1.969 μs | 0.0157 μs | 0.0139 μs |  1.05 |    0.01 |         - |          NA |
|                               |           |           |       |          |           |           |       |         |           |             |
| EqualityOperator              | .NET 9.0  | .NET 9.0  | 1000  | 1.868 μs | 0.0250 μs | 0.0222 μs |  1.00 |    0.02 |         - |          NA |
| StringEqualsOrdinal           | .NET 9.0  | .NET 9.0  | 1000  | 1.894 μs | 0.0317 μs | 0.0297 μs |  1.01 |    0.02 |         - |          NA |
| StringEqualsOrdinalIgnoreCase | .NET 9.0  | .NET 9.0  | 1000  | 2.334 μs | 0.0179 μs | 0.0159 μs |  1.25 |    0.02 |         - |          NA |
| StringInstanceEquals          | .NET 9.0  | .NET 9.0  | 1000  | 2.012 μs | 0.0088 μs | 0.0078 μs |  1.08 |    0.01 |         - |          NA |
| StringInstanceEqualsOrdinal   | .NET 9.0  | .NET 9.0  | 1000  | 1.954 μs | 0.0062 μs | 0.0048 μs |  1.05 |    0.01 |         - |          NA |
