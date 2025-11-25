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
| LookupTypeUsingDictionary100Items |  1.683 μs | 0.0080 μs | 0.0067 μs |  1.01 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingDictionary5Items   |  1.671 μs | 0.0053 μs | 0.0042 μs |  1.00 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch5Items       |  1.081 μs | 0.0092 μs | 0.0082 μs |  0.65 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch100Items     | 11.993 μs | 0.0934 μs | 0.0828 μs |  7.18 |    0.05 | 0.0153 |     304 B |        1.00 |
