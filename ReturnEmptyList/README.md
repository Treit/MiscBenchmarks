# Indicating an empty sequence.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27832.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-FVRDIE : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  MemoryRandomization=True  

```
| Method                     | Mean        | Error      | StdDev     | Median      | Ratio | RatioSD | Gen0     | Allocated | Alloc Ratio |
|--------------------------- |------------:|-----------:|-----------:|------------:|------:|--------:|---------:|----------:|------------:|
| ReturnEnumerableEmpty      |   857.02 μs |  28.645 μs |  84.459 μs |   835.66 μs | 25.01 |    3.55 |        - |         - |          NA |
| ReturnArrayEmpty           | 1,344.63 μs |  48.118 μs | 141.878 μs | 1,302.36 μs | 39.31 |    6.24 |        - |       2 B |          NA |
| ReturnNewArray             | 2,557.60 μs | 130.981 μs | 386.200 μs | 2,400.46 μs | 74.93 |   15.31 | 554.6875 | 2400002 B |          NA |
| ReturnNull                 |    34.73 μs |   1.581 μs |   4.662 μs |    33.70 μs |  1.00 |    0.00 |        - |         - |          NA |
| ReturnCollectionExpression | 1,100.76 μs |  21.866 μs |  45.158 μs | 1,087.21 μs | 32.06 |    4.16 |        - |       1 B |          NA |
