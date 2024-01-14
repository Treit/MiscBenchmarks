# Counting odd numbers


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                  Method |  Count |           Mean |         Error |        StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------ |------- |---------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
|        **CountOddUsingMod** |     **10** |      **11.376 ns** |     **0.0155 ns** |     **0.0129 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CountOddUsingBranchless |     10 |       7.870 ns |     0.0736 ns |     0.0688 ns |  0.69 |    0.01 |         - |          NA |
|                         |        |                |               |               |       |         |           |             |
|        **CountOddUsingMod** |   **1000** |   **1,266.198 ns** |    **19.0077 ns** |    **17.7798 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CountOddUsingBranchless |   1000 |     937.629 ns |     6.3267 ns |     5.2831 ns |  0.74 |    0.01 |         - |          NA |
|                         |        |                |               |               |       |         |           |             |
|        **CountOddUsingMod** | **100000** | **459,541.162 ns** |   **411.2786 ns** |   **384.7103 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| CountOddUsingBranchless | 100000 | 453,853.675 ns | 7,718.3245 ns | 7,219.7255 ns |  0.99 |    0.02 |         - |          NA |
