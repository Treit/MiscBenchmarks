# ForEach vs. Any



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26074.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method             | Count  | Mean      | Error    | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |------- |----------:|---------:|----------:|------:|--------:|----------:|------------:|
| SearchUsingAny     | 100000 | 253.45 μs | 7.721 μs | 21.006 μs |  2.99 |    0.23 |      40 B |          NA |
| SearchUsingForEach | 100000 |  87.22 μs | 1.737 μs |  2.436 μs |  1.00 |    0.00 |         - |          NA |
