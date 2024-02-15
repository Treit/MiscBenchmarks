# Looking up types in a dictionary.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26058.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method       | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| LookupByType | 24.19 μs | 0.483 μs | 1.221 μs |  1.00 |    0.00 |         - |          NA |
| LookupByName | 13.59 μs | 0.270 μs | 0.647 μs |  0.56 |    0.04 |         - |          NA |
