# Using a HashSet vs List to remove tasks as they are completed.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Job       | Runtime   | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |---------- |---------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| TaskWhenAnyRemoveWithHashSet | .NET 10.0 | .NET 10.0 |  7.729 μs | 0.2596 μs | 0.7655 μs |  7.474 μs |  1.01 |    0.14 | 0.3052 |   5.05 KB |        1.00 |
| TaskWhenAnyRemoveWithList    | .NET 10.0 | .NET 10.0 | 10.031 μs | 0.1904 μs | 0.4179 μs | 10.043 μs |  1.31 |    0.14 | 0.2899 |   4.77 KB |        0.95 |
|                              |           |           |           |           |           |           |       |         |        |           |             |
| TaskWhenAnyRemoveWithHashSet | .NET 9.0  | .NET 9.0  |  8.352 μs | 0.2989 μs | 0.8576 μs |  8.350 μs |  1.01 |    0.15 | 0.3052 |   5.02 KB |        1.00 |
| TaskWhenAnyRemoveWithList    | .NET 9.0  | .NET 9.0  | 12.859 μs | 0.2552 μs | 0.4666 μs | 12.829 μs |  1.56 |    0.17 | 0.2747 |   4.83 KB |        0.96 |
