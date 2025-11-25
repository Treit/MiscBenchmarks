# Getting count of set intersection.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|----------------------------------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **CountUsingLinqIntersect**            | **10**    |     **336.7 ns** |     **2.69 ns** |     **2.39 ns** |  **1.00** |    **0.01** |  **0.0305** |       **-** |       **-** |     **512 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10    |     484.2 ns |     7.05 ns |     6.60 ns |  1.44 |    0.02 |  0.0582 |       - |       - |     976 B |        1.91 |
| CountUsingToHashSetIntersectWith   | 10    |     353.3 ns |     2.29 ns |     1.78 ns |  1.05 |    0.01 |  0.0248 |       - |       - |     416 B |        0.81 |
|                                    |       |              |             |             |       |         |         |         |         |           |             |
| **CountUsingLinqIntersect**            | **10000** | **203,572.6 ns** | **2,100.26 ns** | **1,861.83 ns** |  **1.00** |    **0.01** | **49.8047** | **49.8047** | **49.8047** |  **202641 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10000 | 187,775.8 ns | 3,731.51 ns | 3,664.84 ns |  0.92 |    0.02 | 99.8535 | 99.8535 | 99.8535 |  405474 B |        2.00 |
| CountUsingToHashSetIntersectWith   | 10000 | 253,146.8 ns | 2,842.81 ns | 2,659.17 ns |  1.24 |    0.02 | 49.8047 | 49.8047 | 49.8047 |  202545 B |        1.00 |
