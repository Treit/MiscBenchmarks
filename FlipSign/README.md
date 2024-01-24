# Flipping the sign of integers


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                   Method |  Count |     Mean |    Error |   StdDev | Ratio | Allocated | Alloc Ratio |
|----------------------------------------- |------- |---------:|---------:|---------:|------:|----------:|------------:|
|          FlipSignUsingMultiplyByMinusOne | 100000 | 62.53 μs | 0.194 μs | 0.162 μs |  1.00 |         - |          NA |
| FlipSignUsingPrefixDecrementAndBinaryNot | 100000 | 80.18 μs | 0.238 μs | 0.186 μs |  1.28 |         - |          NA |
|        FlipSignUsingMinusOneAndBinaryNot | 100000 | 80.15 μs | 0.211 μs | 0.197 μs |  1.28 |         - |          NA |
