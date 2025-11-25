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
| **ListSortByTwoColumns**        | **100**    |      **41.43 μs** |     **2.150 μs** |     **6.340 μs** |      **39.60 μs** |  **3.50** |    **0.78** |         **-** |        **0.00** |
| LinqOrderByThenBy           | 100    |      12.54 μs |     1.744 μs |     5.142 μs |      11.40 μs |  1.06 |    0.47 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | 100    |      38.78 μs |     1.520 μs |     4.482 μs |      37.90 μs |  3.27 |    0.65 |    3736 B |       11.97 |
|                             |        |               |              |              |               |       |         |           |             |
| **ListSortByTwoColumns**        | **100000** | **109,053.06 μs** | **2,176.300 μs** | **5,846.489 μs** | **107,430.70 μs** | **44.71** |   **35.85** |         **-** |        **0.00** |
| LinqOrderByThenBy           | 100000 |   3,734.53 μs |   661.201 μs | 1,949.567 μs |   3,514.30 μs |  1.53 |    1.59 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | 100000 | 100,869.24 μs | 2,007.110 μs | 5,561.693 μs |  99,857.65 μs | 41.35 |   33.17 | 3200536 B |   10,258.13 |
