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
| **ToListFindIndex**                       | **10**    |      **74.22 ns** |     **0.984 ns** |     **0.920 ns** |  **1.00** |    **0.02** |  **0.0081** |      **-** |     **136 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | 10    |     151.85 ns |     3.010 ns |     3.346 ns |  2.05 |    0.05 |  0.0257 |      - |     432 B |        3.18 |
| SuperLinqFindIndex                    | 10    |      42.55 ns |     0.282 ns |     0.264 ns |  0.57 |    0.01 |       - |      - |         - |        0.00 |
|                                       |       |               |              |              |       |         |         |        |           |             |
| **ToListFindIndex**                       | **10000** |  **50,097.62 ns** |   **356.911 ns** |   **333.855 ns** |  **1.00** |    **0.01** |  **4.7607** | **0.7935** |   **80056 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | 10000 | 175,003.81 ns | 3,430.436 ns | 5,340.776 ns |  3.49 |    0.11 | 18.5547 |      - |  313520 B |        3.92 |
| SuperLinqFindIndex                    | 10000 |  34,822.99 ns |   233.693 ns |   218.596 ns |  0.70 |    0.01 |       - |      - |         - |        0.00 |
