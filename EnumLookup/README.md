## Looking up enum values in a bit array vs. a HashSet







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Mean        | Error     | StdDev    | Ratio | RatioSD |
|-------------------------------------- |------------:|----------:|----------:|------:|--------:|
| LookupUsingHashSet                    |  3,788.9 ns |  11.49 ns |  10.74 ns |  1.00 |    0.00 |
| LookupUsingBitArrayWithUnsafeAs       |  1,690.9 ns |   7.17 ns |   6.70 ns |  0.45 |    0.00 |
| LookupUsingBitArrayWithCast           |    629.3 ns |   3.33 ns |   3.11 ns |  0.17 |    0.00 |
| LookupUsingBitArrayWithConvertToInt32 | 29,443.4 ns | 416.31 ns | 389.42 ns |  7.77 |    0.10 |
