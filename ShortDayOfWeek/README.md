# Getting a short day of week abbreviaton.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                       | Count | Mean      | Error     | StdDev    | Gen0    | Allocated |
|----------------------------- |------ |----------:|----------:|----------:|--------:|----------:|
| GetDayOfWeekSubstring        | 1000  | 38.817 μs | 0.6208 μs | 0.5807 μs | 20.3857 |   88013 B |
| GetDayOfWeekSwitchExpression | 1000  | 12.031 μs | 0.1940 μs | 0.1719 μs |       - |         - |
| GetDayOfWeekLookup           | 1000  |  3.238 μs | 0.0273 μs | 0.0292 μs |       - |         - |
