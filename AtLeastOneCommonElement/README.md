# Testing if two sequences have at least one common element




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                      | Job       | Runtime   | Count | Mean          | Error       | StdDev      | Median        | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------- |---------- |---------- |------ |--------------:|------------:|------------:|--------------:|------:|--------:|-------:|-------:|----------:|------------:|
| **ListAnyListContains**         | **.NET 10.0** | **.NET 10.0** | **10**    |     **19.341 ns** |   **0.4196 ns** |   **0.4309 ns** |     **19.306 ns** |  **1.49** |    **0.03** |      **-** |      **-** |         **-** |          **NA** |
| ListAnyHashSetContains      | .NET 10.0 | .NET 10.0 | 10    |     18.982 ns |   0.3378 ns |   0.2995 ns |     18.913 ns |  1.46 |    0.02 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | .NET 10.0 | .NET 10.0 | 10    |      9.882 ns |   0.1791 ns |   0.1496 ns |      9.892 ns |  0.76 |    0.01 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | .NET 10.0 | .NET 10.0 | 10    |    197.697 ns |   2.7952 ns |   2.6146 ns |    198.060 ns | 15.23 |    0.20 | 0.0257 |      - |     432 B |          NA |
| HashSetOverlapsListMethod   | .NET 10.0 | .NET 10.0 | 10    |     24.495 ns |   0.1654 ns |   0.1466 ns |     24.499 ns |  1.89 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | .NET 10.0 | .NET 10.0 | 10    |     12.982 ns |   0.0542 ns |   0.0481 ns |     12.992 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
|                             |           |           |       |               |             |             |               |       |         |        |        |           |             |
| ListAnyListContains         | .NET 9.0  | .NET 9.0  | 10    |     20.735 ns |   0.1850 ns |   0.1730 ns |     20.771 ns |  1.60 |    0.02 |      - |      - |         - |          NA |
| ListAnyHashSetContains      | .NET 9.0  | .NET 9.0  | 10    |     20.468 ns |   0.4578 ns |   1.3497 ns |     20.375 ns |  1.58 |    0.11 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | .NET 9.0  | .NET 9.0  | 10    |     10.769 ns |   0.2872 ns |   0.8332 ns |     10.381 ns |  0.83 |    0.06 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | .NET 9.0  | .NET 9.0  | 10    |    193.235 ns |   1.4341 ns |   1.1975 ns |    193.464 ns | 14.87 |    0.21 | 0.0257 |      - |     432 B |          NA |
| HashSetOverlapsListMethod   | .NET 9.0  | .NET 9.0  | 10    |     24.537 ns |   0.1266 ns |   0.1122 ns |     24.513 ns |  1.89 |    0.03 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | .NET 9.0  | .NET 9.0  | 10    |     12.994 ns |   0.1808 ns |   0.1692 ns |     12.885 ns |  1.00 |    0.02 |      - |      - |         - |          NA |
|                             |           |           |       |               |             |             |               |       |         |        |        |           |             |
| **ListAnyListContains**         | **.NET 10.0** | **.NET 10.0** | **1000**  | **42,756.785 ns** | **231.6619 ns** | **216.6966 ns** | **42,824.994 ns** | **31.03** |    **0.23** |      **-** |      **-** |         **-** |          **NA** |
| ListAnyHashSetContains      | .NET 10.0 | .NET 10.0 | 1000  |  1,469.371 ns |   7.8441 ns |   6.5502 ns |  1,471.491 ns |  1.07 |    0.01 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | .NET 10.0 | .NET 10.0 | 1000  |  1,208.794 ns |  14.0809 ns |  13.1712 ns |  1,208.781 ns |  0.88 |    0.01 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | .NET 10.0 | .NET 10.0 | 1000  | 11,886.004 ns | 113.0047 ns | 105.7047 ns | 11,910.275 ns |  8.63 |    0.09 | 1.0681 | 0.0610 |   17904 B |          NA |
| HashSetOverlapsListMethod   | .NET 10.0 | .NET 10.0 | 1000  |  1,774.195 ns |   4.3506 ns |   3.8567 ns |  1,774.533 ns |  1.29 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | .NET 10.0 | .NET 10.0 | 1000  |  1,377.908 ns |   8.6526 ns |   8.0937 ns |  1,378.547 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
|                             |           |           |       |               |             |             |               |       |         |        |        |           |             |
| ListAnyListContains         | .NET 9.0  | .NET 9.0  | 1000  | 42,998.843 ns | 377.0812 ns | 334.2727 ns | 42,981.973 ns | 31.24 |    0.28 |      - |      - |         - |          NA |
| ListAnyHashSetContains      | .NET 9.0  | .NET 9.0  | 1000  |  1,531.558 ns |   7.1041 ns |   5.9322 ns |  1,532.740 ns |  1.11 |    0.01 |      - |      - |         - |          NA |
| ListAnyFrozenSetContains    | .NET 9.0  | .NET 9.0  | 1000  |  1,203.505 ns |  11.3607 ns |  10.6268 ns |  1,205.710 ns |  0.87 |    0.01 |      - |      - |         - |          NA |
| LinqIntersectListThenAny    | .NET 9.0  | .NET 9.0  | 1000  | 11,786.900 ns |  87.2476 ns |  81.6115 ns | 11,779.468 ns |  8.56 |    0.07 | 1.0681 | 0.0610 |   17904 B |          NA |
| HashSetOverlapsListMethod   | .NET 9.0  | .NET 9.0  | 1000  |  1,778.089 ns |  12.3279 ns |  11.5315 ns |  1,773.433 ns |  1.29 |    0.01 |      - |      - |         - |          NA |
| FrozenSetOverlapsListMethod | .NET 9.0  | .NET 9.0  | 1000  |  1,376.375 ns |   7.6955 ns |   7.1984 ns |  1,380.093 ns |  1.00 |    0.01 |      - |      - |         - |          NA |
