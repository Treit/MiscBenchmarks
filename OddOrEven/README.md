# Counting odd numbers





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | Job       | Runtime   | Count  | Mean           | Error       | StdDev      | Ratio | Allocated | Alloc Ratio |
|------------------------ |---------- |---------- |------- |---------------:|------------:|------------:|------:|----------:|------------:|
| **CountOddUsingMod**        | **.NET 10.0** | **.NET 10.0** | **10**     |       **8.492 ns** |   **0.0271 ns** |   **0.0253 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | .NET 10.0 | .NET 10.0 | 10     |       8.233 ns |   0.0747 ns |   0.0662 ns |  0.97 |         - |          NA |
|                         |           |           |        |                |             |             |       |           |             |
| CountOddUsingMod        | .NET 9.0  | .NET 9.0  | 10     |       8.518 ns |   0.0246 ns |   0.0218 ns |  1.00 |         - |          NA |
| CountOddUsingBranchless | .NET 9.0  | .NET 9.0  | 10     |       8.156 ns |   0.0693 ns |   0.0648 ns |  0.96 |         - |          NA |
|                         |           |           |        |                |             |             |       |           |             |
| **CountOddUsingMod**        | **.NET 10.0** | **.NET 10.0** | **1000**   |   **1,060.598 ns** |   **1.1461 ns** |   **1.0160 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | .NET 10.0 | .NET 10.0 | 1000   |   1,061.645 ns |   2.4978 ns |   2.2143 ns |  1.00 |         - |          NA |
|                         |           |           |        |                |             |             |       |           |             |
| CountOddUsingMod        | .NET 9.0  | .NET 9.0  | 1000   |   1,061.412 ns |   2.5415 ns |   2.2530 ns |  1.00 |         - |          NA |
| CountOddUsingBranchless | .NET 9.0  | .NET 9.0  | 1000   |   1,060.823 ns |   1.9538 ns |   1.5254 ns |  1.00 |         - |          NA |
|                         |           |           |        |                |             |             |       |           |             |
| **CountOddUsingMod**        | **.NET 10.0** | **.NET 10.0** | **100000** | **427,720.833 ns** | **297.9428 ns** | **232.6142 ns** |  **1.00** |         **-** |          **NA** |
| CountOddUsingBranchless | .NET 10.0 | .NET 10.0 | 100000 | 455,489.072 ns | 709.0983 ns | 663.2910 ns |  1.06 |         - |          NA |
|                         |           |           |        |                |             |             |       |           |             |
| CountOddUsingMod        | .NET 9.0  | .NET 9.0  | 100000 | 427,713.445 ns | 472.9448 ns | 419.2533 ns |  1.00 |         - |          NA |
| CountOddUsingBranchless | .NET 9.0  | .NET 9.0  | 100000 | 455,743.389 ns | 736.7957 ns | 689.1991 ns |  1.07 |         - |          NA |
