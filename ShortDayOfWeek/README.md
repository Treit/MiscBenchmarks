# Getting a short day of week abbreviaton.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                              | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------ |------ |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| GetDayOfWeekSubstring               | 1000  | 27.402 μs | 0.1912 μs | 0.1788 μs | 14.81 |    0.10 | 5.2490 |   88003 B |          NA |
| GetDayOfWeekSwitchExpression        | 1000  | 13.757 μs | 0.0114 μs | 0.0095 μs |  7.44 |    0.01 |      - |         - |          NA |
| GetDayOfWeekSwitchExpressionNoThrow | 1000  | 13.697 μs | 0.0124 μs | 0.0116 μs |  7.40 |    0.01 |      - |         - |          NA |
| GetDayOfWeekArrayLookup             | 1000  |  1.850 μs | 0.0028 μs | 0.0025 μs |  1.00 |    0.00 |      - |         - |          NA |
| GetDayOfWeekDictionaryLookup        | 1000  |  4.460 μs | 0.0073 μs | 0.0057 μs |  2.41 |    0.00 |      - |         - |          NA |
