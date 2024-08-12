# Getting the type




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27686.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method              | Count   | Mean     | Error   | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |-------- |---------:|--------:|---------:|------:|--------:|----------:|------------:|
| UsingTypeof         | 1000000 | 292.8 μs | 5.82 μs | 16.02 μs |  1.00 |    0.00 |         - |          NA |
| UsingThisDotGetType | 1000000 | 276.0 μs | 3.65 μs |  2.85 μs |  0.93 |    0.05 |         - |          NA |
| UsingCachedType     | 1000000 | 275.3 μs | 5.46 μs |  5.10 μs |  0.91 |    0.05 |         - |          NA |
