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
| GetDayOfWeekSubstring               | 1000  | 27.982 μs | 0.2627 μs | 0.2457 μs | 15.00 |    0.13 | 5.2490 |   88003 B |          NA |
| GetDayOfWeekSwitchExpression        | 1000  | 13.972 μs | 0.0399 μs | 0.0333 μs |  7.49 |    0.03 |      - |         - |          NA |
| GetDayOfWeekSwitchExpressionNoThrow | 1000  | 13.865 μs | 0.0312 μs | 0.0276 μs |  7.43 |    0.03 |      - |         - |          NA |
| GetDayOfWeekArrayLookup             | 1000  |  1.865 μs | 0.0057 μs | 0.0053 μs |  1.00 |    0.00 |      - |         - |          NA |
| GetDayOfWeekDictionaryLookup        | 1000  |  4.461 μs | 0.0281 μs | 0.0263 μs |  2.39 |    0.02 |      - |         - |          NA |
