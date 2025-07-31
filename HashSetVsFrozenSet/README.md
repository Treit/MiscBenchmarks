# Set vs. FrozenSet



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27913.1000)
Unknown processor
.NET SDK 9.0.302
  [Host]     : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                      | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingHashSet          | 1000  | 12.010 ns | 0.3607 ns | 1.0466 ns | 11.701 ns |  1.00 |    0.00 |         - |          NA |
| LookupUsingFrozenSet        | 1000  |  7.497 ns | 0.1893 ns | 0.4387 ns |  7.386 ns |  0.64 |    0.05 |         - |          NA |
| LookupUsingIReadOnlySet     | 1000  | 11.965 ns | 0.3690 ns | 1.0764 ns | 11.820 ns |  1.00 |    0.12 |         - |          NA |
| LookupUsingReadOnlySetType  | 1000  | 14.220 ns | 0.5246 ns | 1.5136 ns | 13.818 ns |  1.19 |    0.16 |         - |          NA |
| LookupUsingImmutableHashSet | 1000  | 20.200 ns | 0.8019 ns | 2.3519 ns | 19.743 ns |  1.69 |    0.25 |         - |          NA |
