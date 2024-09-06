# Check if a property is one of three string values
Found the array version in some actual production code.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27699.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method            | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------ |------ |----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| CheckWithArray    | 1000  | 33.977 μs | 0.6757 μs | 1.2010 μs |  7.18 |    0.23 | 20.3857 |   88048 B |          NA |
| CheckWithSimpleIf | 1000  |  4.860 μs | 0.0941 μs | 0.0924 μs |  1.00 |    0.00 |       - |         - |          NA |
