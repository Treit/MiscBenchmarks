# Counting odd numbers



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Count  | Mean           | Error         | StdDev        | Ratio | Allocated | Alloc Ratio |
|------------------------ |------- |---------------:|--------------:|--------------:|------:|----------:|------------:|
| **CountOddUsingMod**        | **10**     |       **8.611 ns** |     **0.0486 ns** |     **0.0455 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 10     |       8.267 ns |     0.0590 ns |     0.0523 ns |  0.96 |         - |          NA |
|                         |        |                |               |               |       |           |             |
| **CountOddUsingMod**        | **1000**   |   **1,071.754 ns** |     **7.2078 ns** |     **6.7421 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 1000   |   1,072.882 ns |     7.7682 ns |     7.2664 ns |  1.00 |         - |          NA |
|                         |        |                |               |               |       |           |             |
| **CountOddUsingMod**        | **100000** | **429,869.632 ns** | **1,467.1515 ns** | **1,372.3744 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 100000 | 457,533.929 ns | 1,456.8812 ns | 1,291.4873 ns |  1.06 |         - |          NA |
