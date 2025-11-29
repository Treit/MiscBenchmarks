# Set vs. FrozenSet






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingHashSet          | .NET 10.0 | .NET 10.0 | 1000  |  6.935 ns | 0.0730 ns | 0.0683 ns |  1.00 |    0.01 |         - |          NA |
| LookupUsingFrozenSet        | .NET 10.0 | .NET 10.0 | 1000  |  6.432 ns | 0.0654 ns | 0.0612 ns |  0.93 |    0.01 |         - |          NA |
| LookupUsingIReadOnlySet     | .NET 10.0 | .NET 10.0 | 1000  |  6.293 ns | 0.0996 ns | 0.0931 ns |  0.91 |    0.02 |         - |          NA |
| LookupUsingReadOnlySetType  | .NET 10.0 | .NET 10.0 | 1000  |  7.914 ns | 0.0740 ns | 0.0692 ns |  1.14 |    0.01 |         - |          NA |
| LookupUsingImmutableHashSet | .NET 10.0 | .NET 10.0 | 1000  | 14.285 ns | 0.1433 ns | 0.1341 ns |  2.06 |    0.03 |         - |          NA |
|                             |           |           |       |           |           |           |       |         |           |             |
| LookupUsingHashSet          | .NET 9.0  | .NET 9.0  | 1000  |  6.970 ns | 0.1171 ns | 0.1096 ns |  1.00 |    0.02 |         - |          NA |
| LookupUsingFrozenSet        | .NET 9.0  | .NET 9.0  | 1000  |  6.438 ns | 0.0795 ns | 0.0743 ns |  0.92 |    0.02 |         - |          NA |
| LookupUsingIReadOnlySet     | .NET 9.0  | .NET 9.0  | 1000  |  6.966 ns | 0.0863 ns | 0.0807 ns |  1.00 |    0.02 |         - |          NA |
| LookupUsingReadOnlySetType  | .NET 9.0  | .NET 9.0  | 1000  |  8.176 ns | 0.0854 ns | 0.0799 ns |  1.17 |    0.02 |         - |          NA |
| LookupUsingImmutableHashSet | .NET 9.0  | .NET 9.0  | 1000  | 15.974 ns | 0.1709 ns | 0.1599 ns |  2.29 |    0.04 |         - |          NA |
