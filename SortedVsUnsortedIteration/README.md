# ForEach vs. directly using the enumerator.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method |  Count |        Mean |    Error |   StdDev | Ratio |
|----------------------- |------- |------------:|---------:|---------:|------:|
| **SumWithForEachUnsorted** |   **1000** |    **317.7 ns** |  **0.27 ns** |  **0.23 ns** |  **1.00** |
|   SumWithForEachSorted |   1000 |    318.7 ns |  1.64 ns |  1.46 ns |  1.00 |
| MaxWithForEachUnsorted |   1000 |    360.7 ns |  2.37 ns |  2.22 ns |  1.13 |
|   MaxWithForEachSorted |   1000 |    317.7 ns |  0.48 ns |  0.40 ns |  1.00 |
|                KoziMax |   1000 |    296.7 ns |  0.12 ns |  0.11 ns |  0.93 |
|          KoziMaxSorted |   1000 |    297.4 ns |  1.16 ns |  1.09 ns |  0.94 |
|                        |        |             |          |          |       |
| **SumWithForEachUnsorted** | **100000** | **31,205.5 ns** | **53.57 ns** | **47.49 ns** |  **1.00** |
|   SumWithForEachSorted | 100000 | 31,202.4 ns | 30.35 ns | 23.69 ns |  1.00 |
| MaxWithForEachUnsorted | 100000 | 31,353.1 ns | 60.92 ns | 56.98 ns |  1.00 |
|   MaxWithForEachSorted | 100000 | 31,193.5 ns | 90.14 ns | 75.27 ns |  1.00 |
|                KoziMax | 100000 | 31,184.7 ns | 35.30 ns | 31.30 ns |  1.00 |
|          KoziMaxSorted | 100000 | 31,173.8 ns | 22.08 ns | 19.58 ns |  1.00 |
