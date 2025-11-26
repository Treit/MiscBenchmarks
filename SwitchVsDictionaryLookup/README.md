# Lookup by type using both dictionary and switch expressions





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| LookupTypeUsingDictionary100Items |  1.686 μs | 0.0056 μs | 0.0047 μs |  1.01 |    0.01 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingDictionary5Items   |  1.663 μs | 0.0099 μs | 0.0093 μs |  1.00 |    0.01 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch5Items       |  1.069 μs | 0.0091 μs | 0.0081 μs |  0.64 |    0.01 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch100Items     | 12.178 μs | 0.1926 μs | 0.2141 μs |  7.32 |    0.13 | 0.0153 |     304 B |        1.00 |
