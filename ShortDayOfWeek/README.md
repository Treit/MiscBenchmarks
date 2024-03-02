# Getting a short day of week abbreviaton.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Count | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| GetDayOfWeekSubstring        | 1000  | 39.453 μs | 0.7775 μs | 1.2332 μs | 39.025 μs | 12.20 |    0.35 | 20.3857 |   88013 B |          NA |
| GetDayOfWeekSwitchExpression | 1000  | 12.238 μs | 0.2417 μs | 0.4827 μs | 11.977 μs |  3.81 |    0.20 |       - |         - |          NA |
| GetDayOfWeekLookup           | 1000  |  3.258 μs | 0.0407 μs | 0.0381 μs |  3.264 μs |  1.00 |    0.00 |       - |         - |          NA |
