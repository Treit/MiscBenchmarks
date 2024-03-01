# List<T> sort vs. LINQ OrderBy

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26063.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-ETYAPC : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method             | Count  | Mean         | Error        | StdDev       | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |------- |-------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **ListSort**           | **100**    |     **12.77 μs** |     **0.902 μs** |     **2.659 μs** |     **12.05 μs** |  **1.00** |    **0.00** |     **400 B** |        **1.00** |
| LinqSort           | 100    |     18.48 μs |     2.620 μs |     7.726 μs |     16.20 μs |  1.47 |    0.60 |    3104 B |        7.76 |
| ListSortDescending | 100    |     13.23 μs |     2.350 μs |     6.928 μs |     11.55 μs |  1.07 |    0.63 |     400 B |        1.00 |
| LinqSortDescending | 100    |     20.18 μs |     2.976 μs |     8.775 μs |     16.50 μs |  1.63 |    0.75 |    3104 B |        7.76 |
|                    |        |              |              |              |              |       |         |           |             |
| **ListSort**           | **100000** | **18,325.85 μs** | **1,021.521 μs** | **3,011.978 μs** | **17,252.45 μs** |  **1.00** |    **0.00** |     **400 B** |        **1.00** |
| LinqSort           | 100000 | 16,330.40 μs |   410.989 μs | 1,211.811 μs | 16,046.75 μs |  0.91 |    0.12 | 2400704 B |    6,001.76 |
| ListSortDescending | 100000 | 16,536.28 μs |   456.959 μs | 1,347.355 μs | 16,075.80 μs |  0.92 |    0.14 |     400 B |        1.00 |
| LinqSortDescending | 100000 | 18,941.58 μs |   768.464 μs | 2,265.834 μs | 18,317.60 μs |  1.05 |    0.16 | 2400704 B |    6,001.76 |
