# Finding the first index of an item matching a predicate.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27734.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                | Count | Mean         | Error       | StdDev       | Median       | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------- |------ |-------------:|------------:|-------------:|-------------:|------:|--------:|--------:|-------:|----------:|------------:|
| **ToListFindIndex**                       | **10**    |     **126.6 ns** |     **5.46 ns** |     **15.48 ns** |     **120.8 ns** |  **1.00** |    **0.00** |  **0.0315** |      **-** |     **136 B** |        **1.00** |
| SelectFirstOrDefaultWithAnonymousType | 10    |     264.9 ns |     6.61 ns |     18.43 ns |     257.3 ns |  2.12 |    0.29 |  0.1149 |      - |     496 B |        3.65 |
| SuperLinqFindIndex                    | 10    |     121.7 ns |     1.58 ns |      1.23 ns |     121.3 ns |  1.03 |    0.07 |  0.0074 |      - |      32 B |        0.24 |
|                                       |       |              |             |              |              |       |         |         |        |           |             |
| **ToListFindIndex**                       | **10000** |  **72,052.1 ns** | **1,241.68 ns** |  **1,740.66 ns** |  **71,344.4 ns** |  **1.00** |    **0.00** | **18.4326** | **3.0518** |   **80056 B** |       **1.000** |
| SelectFirstOrDefaultWithAnonymousType | 10000 | 232,337.6 ns | 6,106.11 ns | 17,714.94 ns | 231,042.4 ns |  3.29 |    0.25 | 72.5098 |      - |  313584 B |       3.917 |
| SuperLinqFindIndex                    | 10000 |  75,040.4 ns |   783.37 ns |    611.61 ns |  75,068.4 ns |  1.04 |    0.02 |       - |      - |      32 B |       0.000 |
