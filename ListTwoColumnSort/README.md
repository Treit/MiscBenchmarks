# List<T> sort vs. LINQ OrderBy / ThenBy - sorting by two properties.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-OKCFRN : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method                      | Count  | Mean          | Error        | StdDev       | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |------- |--------------:|-------------:|-------------:|--------------:|------:|--------:|----------:|------------:|
| **ListSortByTwoColumns**        | **100**    |      **40.29 μs** |     **2.064 μs** |     **6.085 μs** |      **38.60 μs** |  **3.65** |    **0.83** |         **-** |        **0.00** |
| LinqOrderByThenBy           | 100    |      11.65 μs |     1.520 μs |     4.483 μs |      10.30 μs |  1.06 |    0.45 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | 100    |      36.86 μs |     2.228 μs |     6.568 μs |      34.90 μs |  3.34 |    0.83 |    3736 B |       11.97 |
|                             |        |               |              |              |               |       |         |           |             |
| **ListSortByTwoColumns**        | **100000** | **106,450.99 μs** | **2,433.484 μs** | **7,175.183 μs** | **104,461.35 μs** | **43.97** |   **34.48** |         **-** |        **0.00** |
| LinqOrderByThenBy           | 100000 |   3,718.51 μs |   642.133 μs | 1,893.343 μs |   3,585.45 μs |  1.54 |    1.55 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | 100000 |  98,873.15 μs | 1,972.884 μs | 5,400.739 μs |  98,021.45 μs | 40.84 |   31.97 | 3200536 B |   10,258.13 |
