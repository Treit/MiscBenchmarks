# Getting count of set intersection.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                             | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|----------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **CountUsingLinqIntersect**            | **10**    |     **551.6 ns** |    **10.98 ns** |    **21.42 ns** |  **1.00** |    **0.00** |  **0.1183** |       **-** |       **-** |     **512 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10    |     799.1 ns |    15.82 ns |    34.39 ns |  1.45 |    0.09 |  0.2260 |       - |       - |     976 B |        1.91 |
| CountUsingToHashSetIntersectWith   | 10    |     489.2 ns |     9.03 ns |     8.01 ns |  0.88 |    0.04 |  0.0963 |       - |       - |     416 B |        0.81 |
|                                    |       |              |             |             |       |         |         |         |         |           |             |
| **CountUsingLinqIntersect**            | **10000** | **322,567.4 ns** | **4,888.52 ns** | **4,333.55 ns** |  **1.00** |    **0.00** | **49.8047** | **49.8047** | **49.8047** |  **202641 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10000 | 376,852.7 ns | 7,485.34 ns | 9,992.71 ns |  1.18 |    0.04 | 99.6094 | 99.6094 | 99.6094 |  405474 B |        2.00 |
| CountUsingToHashSetIntersectWith   | 10000 | 433,854.4 ns | 2,846.84 ns | 2,222.62 ns |  1.35 |    0.02 | 49.8047 | 49.8047 | 49.8047 |  202545 B |        1.00 |
