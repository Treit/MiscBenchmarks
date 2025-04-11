# Indicating an empty sequence.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27832.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                     | Mean        | Error     | StdDev     | Median      | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|--------------------------- |------------:|----------:|-----------:|------------:|------:|--------:|---------:|----------:|------------:|
| ReturnEnumerableEmpty      |   863.77 μs | 32.411 μs |  93.512 μs |   834.07 μs | 27.10 |    3.06 |        - |         - |          NA |
| ReturnArrayEmpty           | 1,147.89 μs | 21.546 μs |  46.380 μs | 1,136.06 μs | 36.51 |    2.01 |        - |       1 B |          NA |
| ReturnNewArray             | 1,748.25 μs | 59.005 μs | 171.185 μs | 1,694.93 μs | 55.60 |    5.84 | 554.6875 | 2400002 B |          NA |
| ReturnNull                 |    31.47 μs |  0.625 μs |   1.359 μs |    31.22 μs |  1.00 |    0.00 |        - |         - |          NA |
| ReturnCollectionExpression | 1,266.69 μs | 25.034 μs |  55.992 μs | 1,266.24 μs | 40.24 |    2.14 |        - |       1 B |          NA |
