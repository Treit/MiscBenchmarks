# Finding the first index of an item matching a predicate.


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------- |------ |--------------:|-------------:|-------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **ToListFindIndex**                       | **10**    |      **68.52 ns** |     **0.932 ns** |     **0.826 ns** |  **1.00** |    **0.02** |  **0.0081** |      **-** |     **136 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | 10    |     150.59 ns |     2.124 ns |     1.987 ns |  2.20 |    0.04 |  0.0257 |      - |     432 B |        3.18 |
| SuperLinqFindIndex                    | 10    |      42.91 ns |     0.198 ns |     0.155 ns |  0.63 |    0.01 |       - |      - |         - |        0.00 |
|                                       |       |               |              |              |       |         |         |        |           |             |
| **ToListFindIndex**                       | **10000** |  **50,116.14 ns** |   **791.932 ns** |   **740.774 ns** |  **1.00** |    **0.02** |  **4.7607** | **0.7935** |   **80056 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | 10000 | 177,275.02 ns | 3,516.051 ns | 6,429.299 ns |  3.54 |    0.14 | 18.5547 |      - |  313520 B |        3.92 |
| SuperLinqFindIndex                    | 10000 |  34,829.49 ns |   257.047 ns |   227.866 ns |  0.70 |    0.01 |       - |      - |         - |        0.00 |
