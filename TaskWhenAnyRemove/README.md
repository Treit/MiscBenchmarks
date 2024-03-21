# Using a HashSet vs List to remove tasks as they are completed.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-1370P, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method                       | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| TaskWhenAnyRemoveWithHashSet | 8.509 μs | 0.1665 μs | 0.2688 μs | 8.550 μs |  1.00 |    0.00 | 0.4044 |   4.94 KB |        1.00 |
| TaskWhenAnyRemoveWithList    | 7.774 μs | 0.1523 μs | 0.2899 μs | 7.647 μs |  0.92 |    0.06 | 0.3662 |   4.63 KB |        0.94 |
