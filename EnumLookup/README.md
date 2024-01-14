## Looking up enum values in a bit array vs. a HashSet





``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                                Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|-------------------------------------- |----------:|----------:|----------:|------:|--------:|
|                    LookupUsingHashSet |  3.726 μs | 0.0054 μs | 0.0048 μs |  1.00 |    0.00 |
|       LookupUsingBitArrayWithUnsafeAs |  1.554 μs | 0.0023 μs | 0.0018 μs |  0.42 |    0.00 |
|           LookupUsingBitArrayWithCast |  1.095 μs | 0.0038 μs | 0.0033 μs |  0.29 |    0.00 |
| LookupUsingBitArrayWithConvertToInt32 | 24.714 μs | 0.1962 μs | 0.1835 μs |  6.63 |    0.05 |
