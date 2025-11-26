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
| LookupUsingHashSet          | 1000  |  6.921 ns | 0.0677 ns | 0.0634 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenSet        | 1000  |  6.395 ns | 0.0730 ns | 0.0683 ns |  0.92 |    0.01 |         - |          NA |
| LookupUsingIReadOnlySet     | 1000  |  6.330 ns | 0.0843 ns | 0.0789 ns |  0.91 |    0.01 |         - |          NA |
| LookupUsingReadOnlySetType  | 1000  |  7.927 ns | 0.0653 ns | 0.0611 ns |  1.15 |    0.01 |         - |          NA |
| LookupUsingImmutableHashSet | 1000  | 11.871 ns | 0.0332 ns | 0.0310 ns |  1.72 |    0.02 |         - |          NA |
