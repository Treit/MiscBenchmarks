# Using a HashSet vs List to remove tasks as they are completed.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| TaskWhenAnyRemoveWithHashSet |  9.166 μs | 0.3621 μs | 1.0677 μs |  1.01 |    0.16 | 0.3052 |   5.09 KB |        1.00 |
| TaskWhenAnyRemoveWithList    | 11.641 μs | 0.2206 μs | 0.6223 μs |  1.29 |    0.16 | 0.2747 |   4.78 KB |        0.94 |
