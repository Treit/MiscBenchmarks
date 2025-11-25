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
| LookupUsingHashSet                    |  1,347.9 ns |   7.97 ns |   7.46 ns |  1.00 |    0.01 |
| LookupUsingBitArrayWithUnsafeAs       |  1,689.8 ns |   8.78 ns |   7.78 ns |  1.25 |    0.01 |
| LookupUsingBitArrayWithCast           |    951.2 ns |   1.95 ns |   1.73 ns |  0.71 |    0.00 |
| LookupUsingBitArrayWithConvertToInt32 | 30,803.4 ns | 148.17 ns | 131.35 ns | 22.85 |    0.15 |
