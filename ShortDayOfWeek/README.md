# Getting a short day of week abbreviaton.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Code Size | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|--------:|----------:|------------:|
| GetDayOfWeekSubstring        | 1000  | 41.970 μs | 1.0777 μs | 3.1265 μs | 40.890 μs | 12.62 |    1.01 |   1,765 B | 20.3857 |   88013 B |          NA |
| GetDayOfWeekSwitchExpression | 1000  | 12.525 μs | 0.2503 μs | 0.2571 μs | 12.485 μs |  3.75 |    0.10 |     305 B |       - |         - |          NA |
| GetDayOfWeekLookup           | 1000  |  3.351 μs | 0.0645 μs | 0.0603 μs |  3.346 μs |  1.00 |    0.00 |     154 B |       - |         - |          NA |


