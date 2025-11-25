# Using a HashSet vs List to remove tasks as they are completed.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| TaskWhenAnyRemoveWithHashSet | 5.560 μs | 0.1103 μs | 0.1032 μs |  1.00 |    0.03 | 0.2899 |   4.91 KB |        1.00 |
| TaskWhenAnyRemoveWithList    | 5.590 μs | 0.1099 μs | 0.1576 μs |  1.01 |    0.03 | 0.2747 |   4.59 KB |        0.93 |
