# Looking up types in a dictionary.






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method       | Job       | Runtime   | Mean     | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|------------- |---------- |---------- |---------:|----------:|----------:|------:|----------:|------------:|
| LookupByType | .NET 10.0 | .NET 10.0 | 8.549 μs | 0.0087 μs | 0.0077 μs |  1.00 |         - |          NA |
| LookupByName | .NET 10.0 | .NET 10.0 | 5.032 μs | 0.0157 μs | 0.0131 μs |  0.59 |         - |          NA |
|              |           |           |          |           |           |       |           |             |
| LookupByType | .NET 9.0  | .NET 9.0  | 8.488 μs | 0.0079 μs | 0.0070 μs |  1.00 |         - |          NA |
| LookupByName | .NET 9.0  | .NET 9.0  | 5.020 μs | 0.0095 μs | 0.0075 μs |  0.59 |         - |          NA |
