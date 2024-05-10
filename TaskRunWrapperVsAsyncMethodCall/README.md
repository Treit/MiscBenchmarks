# Calling an async method vs. wrapping it in a Task.Run

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26212.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                    | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| AwaitAsyncMethodCallDirectly              |  2.210 μs | 0.0764 μs | 0.2091 μs |  2.146 μs |  1.00 |    0.00 | 0.0687 |     296 B |        1.00 |
| AwaitAsyncMethodCallWithTaskDotRunWrapper | 11.984 μs | 2.1138 μs | 6.2327 μs | 11.195 μs |  5.75 |    3.02 | 0.1144 |     513 B |        1.73 |
