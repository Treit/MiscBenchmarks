# Set vs. FrozenSet


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27847.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| LookupUsingHashSet         | 1000  | 11.422 ns | 0.2629 ns | 0.3686 ns | 11.433 ns |  1.00 |    0.00 |         - |          NA |
| LookupUsingFrozenSet       | 1000  |  7.916 ns | 0.1980 ns | 0.3670 ns |  7.899 ns |  0.70 |    0.03 |         - |          NA |
| LookupUsingIReadOnlySet    | 1000  | 11.240 ns | 0.2617 ns | 0.5103 ns | 11.140 ns |  0.99 |    0.05 |         - |          NA |
| LookupUsingReadOnlySetType | 1000  | 12.971 ns | 0.3135 ns | 0.8894 ns | 12.709 ns |  1.18 |    0.09 |         - |          NA |
