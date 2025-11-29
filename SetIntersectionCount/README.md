# Getting count of set intersection.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                             | Job       | Runtime   | Count | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|----------------------------------- |---------- |---------- |------ |-------------:|------------:|------------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| **CountUsingLinqIntersect**            | **.NET 10.0** | **.NET 10.0** | **10**    |     **330.7 ns** |     **2.12 ns** |     **1.98 ns** |  **1.00** |    **0.01** |  **0.0305** |       **-** |       **-** |     **512 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | .NET 10.0 | .NET 10.0 | 10    |     525.4 ns |     4.64 ns |     4.34 ns |  1.59 |    0.02 |  0.0582 |       - |       - |     976 B |        1.91 |
| CountUsingToHashSetIntersectWith   | .NET 10.0 | .NET 10.0 | 10    |     375.7 ns |     1.39 ns |     1.16 ns |  1.14 |    0.01 |  0.0248 |       - |       - |     416 B |        0.81 |
|                                    |           |           |       |              |             |             |       |         |         |         |         |           |             |
| CountUsingLinqIntersect            | .NET 9.0  | .NET 9.0  | 10    |     326.2 ns |     1.78 ns |     1.67 ns |  1.00 |    0.01 |  0.0305 |       - |       - |     512 B |        1.00 |
| CountUsingToHashSetIntersectToList | .NET 9.0  | .NET 9.0  | 10    |     514.1 ns |     2.65 ns |     2.48 ns |  1.58 |    0.01 |  0.0582 |       - |       - |     976 B |        1.91 |
| CountUsingToHashSetIntersectWith   | .NET 9.0  | .NET 9.0  | 10    |     364.0 ns |     3.99 ns |     3.74 ns |  1.12 |    0.01 |  0.0248 |       - |       - |     416 B |        0.81 |
|                                    |           |           |       |              |             |             |       |         |         |         |         |           |             |
| **CountUsingLinqIntersect**            | **.NET 10.0** | **.NET 10.0** | **10000** | **185,821.0 ns** |   **648.60 ns** |   **606.70 ns** |  **1.00** |    **0.00** | **49.8047** | **49.8047** | **49.8047** |  **202641 B** |        **1.00** |
| CountUsingToHashSetIntersectToList | .NET 10.0 | .NET 10.0 | 10000 | 185,822.9 ns |   703.95 ns |   658.47 ns |  1.00 |    0.00 | 99.8535 | 99.8535 | 99.8535 |  405474 B |        2.00 |
| CountUsingToHashSetIntersectWith   | .NET 10.0 | .NET 10.0 | 10000 | 246,831.9 ns |   816.30 ns |   763.57 ns |  1.33 |    0.01 | 49.8047 | 49.8047 | 49.8047 |  202545 B |        1.00 |
|                                    |           |           |       |              |             |             |       |         |         |         |         |           |             |
| CountUsingLinqIntersect            | .NET 9.0  | .NET 9.0  | 10000 | 198,587.7 ns |   360.69 ns |   319.74 ns |  1.00 |    0.00 | 49.8047 | 49.8047 | 49.8047 |  202641 B |        1.00 |
| CountUsingToHashSetIntersectToList | .NET 9.0  | .NET 9.0  | 10000 | 181,888.2 ns | 1,368.45 ns | 1,280.05 ns |  0.92 |    0.01 | 99.8535 | 99.8535 | 99.8535 |  405474 B |        2.00 |
| CountUsingToHashSetIntersectWith   | .NET 9.0  | .NET 9.0  | 10000 | 246,395.5 ns | 1,184.85 ns | 1,108.31 ns |  1.24 |    0.01 | 49.8047 | 49.8047 | 49.8047 |  202551 B |        1.00 |
