# Finding max value of a series of floats

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22621.1265)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


```
|      Method | IterationCount |             Mean |          Error |         StdDev | Ratio | Allocated | Alloc Ratio |
|------------ |--------------- |-----------------:|---------------:|---------------:|------:|----------:|------------:|
| OrdinaryMax |           1000 |        604.61 ns |       9.593 ns |       8.973 ns |  1.00 |         - |          NA |
|       IfMax |           1000 |        375.61 ns |       1.671 ns |       1.481 ns |  0.62 |         - |          NA |
|  TernaryMax |           1000 |        377.29 ns |       2.184 ns |       1.936 ns |  0.63 |         - |          NA |
|   VectorMax |           1000 |         53.45 ns |       0.655 ns |       0.613 ns |  0.09 |         - |          NA |
|             |                |                  |                |                |       |           |             |
| OrdinaryMax |         100000 |     54,960.58 ns |      68.314 ns |      57.045 ns |  1.00 |         - |          NA |
|       IfMax |         100000 |     36,501.63 ns |     109.823 ns |      97.355 ns |  0.66 |         - |          NA |
|  TernaryMax |         100000 |     36,398.19 ns |      67.818 ns |      63.437 ns |  0.66 |         - |          NA |
|   VectorMax |         100000 |      4,711.24 ns |       6.723 ns |       5.960 ns |  0.09 |         - |          NA |
|             |                |                  |                |                |       |           |             |
| OrdinaryMax |      100000000 | 54,918,482.00 ns | 224,055.887 ns | 209,582.016 ns |  1.00 |      50 B |        1.00 |
|       IfMax |      100000000 | 36,736,650.95 ns | 132,677.736 ns | 124,106.837 ns |  0.67 |      36 B |        0.72 |
|  TernaryMax |      100000000 | 36,735,339.29 ns |  16,718.417 ns |  14,820.441 ns |  0.67 |      36 B |        0.72 |
|   VectorMax |      100000000 |  8,238,065.87 ns |  24,249.929 ns |  20,249.789 ns |  0.15 |       8 B |        0.16 |