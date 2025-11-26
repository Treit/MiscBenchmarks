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
| **CountOddUsingMod**        | **10**     |       **8.625 ns** |     **0.0654 ns** |     **0.0612 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 10     |       7.922 ns |     0.0852 ns |     0.0797 ns |  0.92 |         - |          NA |
|                         |        |                |               |               |       |           |             |
| **CountOddUsingMod**        | **1000**   |   **1,070.302 ns** |     **9.4565 ns** |     **8.3829 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 1000   |   1,071.098 ns |     8.5455 ns |     7.9935 ns |  1.00 |         - |          NA |
|                         |        |                |               |               |       |           |             |
| **CountOddUsingMod**        | **100000** | **431,351.745 ns** | **1,346.7886 ns** | **1,259.7869 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 100000 | 455,116.761 ns | 2,536.5222 ns | 2,372.6644 ns |  1.06 |         - |          NA |
