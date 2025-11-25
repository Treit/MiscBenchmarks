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
| LookupUsingDictionary           | 1000  |   5.008 ns | 0.0536 ns | 0.0501 ns |  1.00 |    0.01 |      - |         - |          NA |
| LookupUsingMemoryCache          | 1000  | 105.002 ns | 0.4692 ns | 0.3918 ns | 20.97 |    0.22 | 0.0019 |      32 B |          NA |
| LookupUsingConcurrentDictionary | 1000  |   5.191 ns | 0.0818 ns | 0.0766 ns |  1.04 |    0.02 |      - |         - |          NA |
