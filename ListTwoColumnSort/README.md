# List<T> sort vs. LINQ OrderBy / ThenBy - sorting by two properties.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26090.1)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-DKXPNA : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method                      | Count  | Mean          | Error        | StdDev       | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------- |--------------:|-------------:|-------------:|--------------:|------:|--------:|----------:|------------:|
| **ListSortByTwoColumns**        | **100**    |      **43.73 μs** |     **3.800 μs** |    **11.205 μs** |      **39.55 μs** |  **3.81** |    **0.35** |     **400 B** |        **0.62** |
| LinqOrderByThenBy           | 100    |      11.19 μs |     0.231 μs |     0.276 μs |      11.10 μs |  1.00 |    0.00 |     648 B |        1.00 |
| LinqOrderByThenByWithToList | 100    |      44.09 μs |     3.099 μs |     9.137 μs |      41.00 μs |  3.95 |    1.34 |    4072 B |        6.28 |
|                             |        |               |              |              |               |       |         |           |             |
| **ListSortByTwoColumns**        | **100000** | **118,017.60 μs** | **2,073.997 μs** | **1,940.018 μs** | **117,959.45 μs** | **22.81** |    **9.29** |     **400 B** |        **0.62** |
| LinqOrderByThenBy           | 100000 |   3,331.55 μs |   596.689 μs | 1,759.350 μs |   2,647.00 μs |  1.00 |    0.00 |     648 B |        1.00 |
| LinqOrderByThenByWithToList | 100000 | 120,723.69 μs | 2,329.076 μs | 2,178.619 μs | 120,792.45 μs | 23.25 |    9.16 | 3200872 B |    4,939.62 |
