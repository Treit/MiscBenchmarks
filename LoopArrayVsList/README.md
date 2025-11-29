# Looping over an array vs. a list.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method           | Job       | Runtime   | Count  | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------- |---------- |---------- |------- |--------------:|--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **ForLoopArray**     | **.NET 10.0** | **.NET 10.0** | **10**     |      **5.382 ns** |     **0.0130 ns** |     **0.0122 ns** |      **5.383 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| ForEachLoopArray | .NET 10.0 | .NET 10.0 | 10     |      4.199 ns |     0.0094 ns |     0.0084 ns |      4.199 ns |  0.78 |    0.00 |         - |          NA |
| ForLoopList      | .NET 10.0 | .NET 10.0 | 10     |      8.345 ns |     0.1933 ns |     0.1808 ns |      8.434 ns |  1.55 |    0.03 |         - |          NA |
| ForEachLoopList  | .NET 10.0 | .NET 10.0 | 10     |      8.616 ns |     0.0294 ns |     0.0260 ns |      8.619 ns |  1.60 |    0.01 |         - |          NA |
|                  |           |           |        |               |               |               |               |       |         |           |             |
| ForLoopArray     | .NET 9.0  | .NET 9.0  | 10     |      4.198 ns |     0.0152 ns |     0.0135 ns |      4.197 ns |  1.00 |    0.00 |         - |          NA |
| ForEachLoopArray | .NET 9.0  | .NET 9.0  | 10     |      4.217 ns |     0.0215 ns |     0.0201 ns |      4.220 ns |  1.00 |    0.01 |         - |          NA |
| ForLoopList      | .NET 9.0  | .NET 9.0  | 10     |      8.095 ns |     0.0916 ns |     0.0715 ns |      8.079 ns |  1.93 |    0.02 |         - |          NA |
| ForEachLoopList  | .NET 9.0  | .NET 9.0  | 10     |      8.601 ns |     0.0425 ns |     0.0398 ns |      8.595 ns |  2.05 |    0.01 |         - |          NA |
|                  |           |           |        |               |               |               |               |       |         |           |             |
| **ForLoopArray**     | **.NET 10.0** | **.NET 10.0** | **100000** | **67,555.216 ns** |   **325.5988 ns** |   **304.5653 ns** | **67,571.497 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| ForEachLoopArray | .NET 10.0 | .NET 10.0 | 100000 | 63,503.237 ns | 2,074.6323 ns | 6,117.1006 ns | 67,369.809 ns |  0.94 |    0.09 |         - |          NA |
| ForLoopList      | .NET 10.0 | .NET 10.0 | 100000 | 70,406.449 ns |   471.9653 ns |   441.4767 ns | 70,509.485 ns |  1.04 |    0.01 |         - |          NA |
| ForEachLoopList  | .NET 10.0 | .NET 10.0 | 100000 | 75,307.741 ns |   406.7130 ns |   380.4396 ns | 75,396.936 ns |  1.11 |    0.01 |         - |          NA |
|                  |           |           |        |               |               |               |               |       |         |           |             |
| ForLoopArray     | .NET 9.0  | .NET 9.0  | 100000 | 68,388.628 ns |   732.6467 ns |   649.4722 ns | 68,325.043 ns |  1.00 |    0.01 |         - |          NA |
| ForEachLoopArray | .NET 9.0  | .NET 9.0  | 100000 | 60,483.435 ns | 2,606.3767 ns | 7,684.9611 ns | 63,466.547 ns |  0.88 |    0.11 |         - |          NA |
| ForLoopList      | .NET 9.0  | .NET 9.0  | 100000 | 69,579.936 ns |   623.2565 ns |   552.5006 ns | 69,509.998 ns |  1.02 |    0.01 |         - |          NA |
| ForEachLoopList  | .NET 9.0  | .NET 9.0  | 100000 | 75,294.889 ns |   361.4096 ns |   338.0627 ns | 75,243.689 ns |  1.10 |    0.01 |         - |          NA |
