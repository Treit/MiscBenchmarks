# Lookup by type using both dictionary and switch expressions






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                            | Job       | Runtime   | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------- |---------- |---------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| LookupTypeUsingDictionary100Items | .NET 10.0 | .NET 10.0 |  1.657 μs | 0.0070 μs | 0.0062 μs |  1.00 |    0.01 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingDictionary5Items   | .NET 10.0 | .NET 10.0 |  1.664 μs | 0.0072 μs | 0.0067 μs |  1.00 |    0.01 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch5Items       | .NET 10.0 | .NET 10.0 |  1.058 μs | 0.0069 μs | 0.0065 μs |  0.64 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch100Items     | .NET 10.0 | .NET 10.0 | 13.335 μs | 0.0673 μs | 0.0597 μs |  8.02 |    0.05 | 0.0153 |     304 B |        1.00 |
|                                   |           |           |           |           |           |       |         |        |           |             |
| LookupTypeUsingDictionary100Items | .NET 9.0  | .NET 9.0  |  1.685 μs | 0.0053 μs | 0.0047 μs |  1.02 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingDictionary5Items   | .NET 9.0  | .NET 9.0  |  1.649 μs | 0.0055 μs | 0.0049 μs |  1.00 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch5Items       | .NET 9.0  | .NET 9.0  |  1.069 μs | 0.0050 μs | 0.0047 μs |  0.65 |    0.00 | 0.0172 |     304 B |        1.00 |
| LookupTypeUsingSwitch100Items     | .NET 9.0  | .NET 9.0  | 13.318 μs | 0.0419 μs | 0.0327 μs |  8.08 |    0.03 | 0.0153 |     304 B |        1.00 |
