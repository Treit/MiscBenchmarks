# List<T> sort vs. LINQ OrderBy / ThenBy - sorting by two properties.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

OutlierMode=DontRemove  InvocationCount=1  MemoryRandomization=True  
UnrollFactor=1  

```
| Method                      | Job       | Runtime   | Count  | Mean          | Error        | StdDev       | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------- |--------------:|-------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **ListSortByTwoColumns**        | **.NET 10.0** | **.NET 10.0** | **100**    |      **44.60 μs** |     **2.909 μs** |     **8.578 μs** |     **39.75 μs** |  **3.98** |    **0.91** |         **-** |        **0.00** |
| LinqOrderByThenBy           | .NET 10.0 | .NET 10.0 | 100    |      11.57 μs |     1.193 μs |     3.519 μs |     11.00 μs |  1.03 |    0.34 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | .NET 10.0 | .NET 10.0 | 100    |      39.65 μs |     2.583 μs |     7.616 μs |     36.65 μs |  3.54 |    0.81 |    3736 B |       11.97 |
|                             |           |           |        |               |              |              |              |       |         |           |             |
| ListSortByTwoColumns        | .NET 9.0  | .NET 9.0  | 100    |      39.92 μs |     2.097 μs |     6.182 μs |     38.00 μs |  3.79 |    0.80 |         - |        0.00 |
| LinqOrderByThenBy           | .NET 9.0  | .NET 9.0  | 100    |      11.01 μs |     1.234 μs |     3.639 μs |     10.10 μs |  1.04 |    0.38 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | .NET 9.0  | .NET 9.0  | 100    |      42.30 μs |     2.513 μs |     7.408 μs |     38.80 μs |  4.02 |    0.91 |    3736 B |       11.97 |
|                             |           |           |        |               |              |              |              |       |         |           |             |
| **ListSortByTwoColumns**        | **.NET 10.0** | **.NET 10.0** | **100000** |  **97,805.00 μs** | **2,274.138 μs** | **6,705.347 μs** | **96,428.85 μs** | **41.89** |   **34.32** |         **-** |        **0.00** |
| LinqOrderByThenBy           | .NET 10.0 | .NET 10.0 | 100000 |   3,705.46 μs |   650.038 μs | 1,916.651 μs |  4,085.35 μs |  1.59 |    1.67 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | .NET 10.0 | .NET 10.0 | 100000 |  95,327.49 μs | 1,956.302 μs | 5,768.201 μs | 94,606.80 μs | 40.83 |   33.41 | 3200536 B |   10,258.13 |
|                             |           |           |        |               |              |              |              |       |         |           |             |
| ListSortByTwoColumns        | .NET 9.0  | .NET 9.0  | 100000 | 100,132.32 μs | 1,984.850 μs | 5,821.223 μs | 99,264.25 μs | 39.52 |   30.26 |         - |        0.00 |
| LinqOrderByThenBy           | .NET 9.0  | .NET 9.0  | 100000 |   3,750.39 μs |   610.921 μs | 1,801.313 μs |  3,912.05 μs |  1.48 |    1.44 |     312 B |        1.00 |
| LinqOrderByThenByWithToList | .NET 9.0  | .NET 9.0  | 100000 |  93,259.66 μs | 2,020.037 μs | 5,956.125 μs | 92,205.75 μs | 36.80 |   28.21 | 3200536 B |   10,258.13 |
