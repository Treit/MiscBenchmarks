## Looking up enum values in a bit array vs. a HashSet




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26002.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100-rc.2.23502.2
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                         Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------------------- |----------:|----------:|----------:|------:|--------:|
|             LookupUsingHashSet | 10.269 μs | 0.1217 μs | 0.1078 μs |  1.00 |    0.00 |
|            LookupUsingBitArray |  1.388 μs | 0.0202 μs | 0.0189 μs |  0.14 |    0.00 |
| LookupUsingBitArrayWithConvert | 17.479 μs | 0.3036 μs | 0.2840 μs |  1.70 |    0.02 |
