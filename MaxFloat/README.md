# Finding max value of a series of floats


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|      Method | IterationCount |            Mean |         Error |        StdDev | Ratio | Allocated | Alloc Ratio |
|------------ |--------------- |----------------:|--------------:|--------------:|------:|----------:|------------:|
| **OrdinaryMax** |           **1000** |        **951.1 ns** |       **1.71 ns** |       **1.60 ns** |  **1.00** |         **-** |          **NA** |
|       IfMax |           1000 |        398.6 ns |       4.54 ns |       4.25 ns |  0.42 |         - |          NA |
|  TernaryMax |           1000 |        399.5 ns |       5.08 ns |       4.75 ns |  0.42 |         - |          NA |
|   VectorMax |           1000 |        100.1 ns |       1.75 ns |       3.38 ns |  0.11 |         - |          NA |
|             |                |                 |               |               |       |           |             |
| **OrdinaryMax** |         **100000** |     **93,124.4 ns** |      **69.04 ns** |      **57.66 ns** |  **1.00** |         **-** |          **NA** |
|       IfMax |         100000 |     37,459.2 ns |      27.93 ns |      24.76 ns |  0.40 |         - |          NA |
|  TernaryMax |         100000 |     37,452.2 ns |     157.31 ns |     147.15 ns |  0.40 |         - |          NA |
|   VectorMax |         100000 |      7,944.5 ns |      15.22 ns |      13.50 ns |  0.09 |         - |          NA |
|             |                |                 |               |               |       |           |             |
| **OrdinaryMax** |      **100000000** | **94,133,309.0 ns** |  **84,567.61 ns** |  **70,617.79 ns** |  **1.00** |         **-** |          **NA** |
|       IfMax |      100000000 | 38,806,861.1 ns |  93,442.19 ns |  82,834.07 ns |  0.41 |         - |          NA |
|  TernaryMax |      100000000 | 38,820,242.2 ns |  91,702.52 ns |  85,778.59 ns |  0.41 |         - |          NA |
|   VectorMax |      100000000 | 19,883,476.3 ns | 374,319.87 ns | 384,398.95 ns |  0.21 |         - |          NA |
