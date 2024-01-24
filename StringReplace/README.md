# String replace - does the StringComparison parameter matter?


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                   Method | Count |       Mean |   Error |  StdDev | Ratio |
|----------------------------------------- |------ |-----------:|--------:|--------:|------:|
|                ReplaceNoStringComparison | 10000 |   793.4 μs | 2.20 μs | 1.83 μs |  1.00 |
|           ReplaceStringComparisonOrdinal | 10000 |   799.3 μs | 3.81 μs | 3.38 μs |  1.01 |
| ReplaceStringComparisonOrdinalIgnoreCase | 10000 | 1,168.7 μs | 3.57 μs | 3.16 μs |  1.47 |
