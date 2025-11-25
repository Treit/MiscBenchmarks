# Set vs. FrozenSet




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingHashSet          | 1000  |  6.885 ns | 0.0525 ns | 0.0491 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenSet        | 1000  |  6.621 ns | 0.0717 ns | 0.0671 ns |  0.96 |    0.01 |         - |          NA |
| LookupUsingIReadOnlySet     | 1000  |  6.228 ns | 0.0604 ns | 0.0536 ns |  0.90 |    0.01 |         - |          NA |
| LookupUsingReadOnlySetType  | 1000  |  7.914 ns | 0.0752 ns | 0.0703 ns |  1.15 |    0.01 |         - |          NA |
| LookupUsingImmutableHashSet | 1000  | 14.559 ns | 0.1318 ns | 0.1233 ns |  2.11 |    0.02 |         - |          NA |
