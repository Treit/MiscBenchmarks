# Looking up types in a dictionary.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method       | Mean     | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|------------- |---------:|----------:|----------:|------:|----------:|------------:|
| LookupByType | 8.536 μs | 0.0527 μs | 0.0493 μs |  1.00 |         - |          NA |
| LookupByName | 5.107 μs | 0.0271 μs | 0.0241 μs |  0.60 |         - |          NA |
