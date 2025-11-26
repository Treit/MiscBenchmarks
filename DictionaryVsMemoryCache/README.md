# Dictionary vs MemoryCache



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| LookupUsingDictionary           | 1000  |   5.079 ns | 0.0528 ns | 0.0468 ns |  1.00 |    0.01 |      - |         - |          NA |
| LookupUsingMemoryCache          | 1000  | 103.286 ns | 0.4970 ns | 0.4405 ns | 20.34 |    0.20 | 0.0019 |      32 B |          NA |
| LookupUsingConcurrentDictionary | 1000  |   5.192 ns | 0.0646 ns | 0.0604 ns |  1.02 |    0.01 |      - |         - |          NA |
