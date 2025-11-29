# Dictionary vs MemoryCache




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------- |---------- |---------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| LookupUsingDictionary           | .NET 10.0 | .NET 10.0 | 1000  |   5.050 ns | 0.0808 ns | 0.0756 ns |  1.00 |    0.02 |      - |         - |          NA |
| LookupUsingMemoryCache          | .NET 10.0 | .NET 10.0 | 1000  | 104.775 ns | 0.5233 ns | 0.4085 ns | 20.75 |    0.31 | 0.0019 |      32 B |          NA |
| LookupUsingConcurrentDictionary | .NET 10.0 | .NET 10.0 | 1000  |   5.205 ns | 0.0751 ns | 0.0702 ns |  1.03 |    0.02 |      - |         - |          NA |
|                                 |           |           |       |            |           |           |       |         |        |           |             |
| LookupUsingDictionary           | .NET 9.0  | .NET 9.0  | 1000  |   5.051 ns | 0.0640 ns | 0.0598 ns |  1.00 |    0.02 |      - |         - |          NA |
| LookupUsingMemoryCache          | .NET 9.0  | .NET 9.0  | 1000  | 103.404 ns | 0.5746 ns | 0.5094 ns | 20.47 |    0.25 | 0.0019 |      32 B |          NA |
| LookupUsingConcurrentDictionary | .NET 9.0  | .NET 9.0  | 1000  |   5.216 ns | 0.0907 ns | 0.0849 ns |  1.03 |    0.02 |      - |         - |          NA |
