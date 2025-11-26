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
| **CountUsingLinqIntersect**            | **10**    |     **333.9 ns** |     **2.44 ns** |     **2.16 ns** |  **1.00** |    **0.01** |  **0.0305** |       **-** |       **-** |     **512 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10    |     564.7 ns |     4.60 ns |     4.30 ns |  1.69 |    0.02 |  0.0582 |       - |       - |     976 B |        1.91 |
| CountUsingToHashSetIntersectWith   | 10    |     400.3 ns |     2.32 ns |     2.17 ns |  1.20 |    0.01 |  0.0248 |       - |       - |     416 B |        0.81 |
|                                    |       |              |             |             |       |         |         |         |         |           |             |
| **CountUsingLinqIntersect**            | **10000** | **197,831.4 ns** | **1,093.48 ns** |   **913.11 ns** |  **1.00** |    **0.01** | **49.8047** | **49.8047** | **49.8047** |  **202641 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | 10000 | 185,665.6 ns | 1,106.87 ns | 1,035.37 ns |  0.94 |    0.01 | 99.8535 | 99.8535 | 99.8535 |  405474 B |        2.00 |
| CountUsingToHashSetIntersectWith   | 10000 | 243,748.1 ns |   436.70 ns |   408.49 ns |  1.23 |    0.01 | 49.8047 | 49.8047 | 49.8047 |  202545 B |        1.00 |
