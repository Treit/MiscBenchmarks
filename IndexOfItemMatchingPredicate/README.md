# Finding the first index of an item matching a predicate.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                | Job       | Runtime   | Count | Mean          | Error        | StdDev       | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------- |---------- |---------- |------ |--------------:|-------------:|-------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **ToListFindIndex**                       | **.NET 10.0** | **.NET 10.0** | **10**    |      **69.90 ns** |     **1.035 ns** |     **0.968 ns** |  **1.00** |    **0.02** |  **0.0081** |      **-** |     **136 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | .NET 10.0 | .NET 10.0 | 10    |     149.29 ns |     2.927 ns |     3.132 ns |  2.14 |    0.05 |  0.0257 |      - |     432 B |        3.18 |
| SuperLinqFindIndex                    | .NET 10.0 | .NET 10.0 | 10    |      41.14 ns |     0.247 ns |     0.219 ns |  0.59 |    0.01 |       - |      - |         - |        0.00 |
|                                       |           |           |       |               |              |              |       |         |         |        |           |             |
| ToListFindIndex                       | .NET 9.0  | .NET 9.0  | 10    |      69.99 ns |     0.761 ns |     0.675 ns |  1.00 |    0.01 |  0.0081 |      - |     136 B |        1.00 |
| SelectFirstOrDefaultWithAnonymousType | .NET 9.0  | .NET 9.0  | 10    |     149.13 ns |     2.718 ns |     2.543 ns |  2.13 |    0.04 |  0.0257 |      - |     432 B |        3.18 |
| SuperLinqFindIndex                    | .NET 9.0  | .NET 9.0  | 10    |      42.32 ns |     0.243 ns |     0.227 ns |  0.60 |    0.01 |       - |      - |         - |        0.00 |
|                                       |           |           |       |               |              |              |       |         |         |        |           |             |
| **ToListFindIndex**                       | **.NET 10.0** | **.NET 10.0** | **10000** |  **49,726.94 ns** |   **517.462 ns** |   **458.717 ns** |  **1.00** |    **0.01** |  **4.7607** | **0.7935** |   **80056 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | .NET 10.0 | .NET 10.0 | 10000 | 165,675.69 ns | 3,239.535 ns | 5,588.039 ns |  3.33 |    0.11 | 18.5547 |      - |  313520 B |        3.92 |
| SuperLinqFindIndex                    | .NET 10.0 | .NET 10.0 | 10000 |  38,991.53 ns |   349.122 ns |   326.568 ns |  0.78 |    0.01 |       - |      - |         - |        0.00 |
|                                       |           |           |       |               |              |              |       |         |         |        |           |             |
| ToListFindIndex                       | .NET 9.0  | .NET 9.0  | 10000 |  49,754.79 ns |   222.562 ns |   208.185 ns |  1.00 |    0.01 |  4.7607 | 0.7935 |   80056 B |        1.00 |
| SelectFirstOrDefaultWithAnonymousType | .NET 9.0  | .NET 9.0  | 10000 | 187,821.52 ns | 3,686.577 ns | 6,924.287 ns |  3.78 |    0.14 | 18.5547 |      - |  313520 B |        3.92 |
| SuperLinqFindIndex                    | .NET 9.0  | .NET 9.0  | 10000 |  34,812.03 ns |   282.592 ns |   264.336 ns |  0.70 |    0.01 |       - |      - |         - |        0.00 |
