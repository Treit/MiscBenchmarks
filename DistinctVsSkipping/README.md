# Consider each unique value in a set that has 'runs' of values.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                          Method |   Count |              Mean |            Error |           StdDev | Ratio |     Gen0 |     Gen1 |     Gen2 |  Allocated | Alloc Ratio |
|-------------------------------- |-------- |------------------:|-----------------:|-----------------:|------:|---------:|---------:|---------:|-----------:|------------:|
| **IterateListAfterCallingDistinct** |      **10** |         **849.04 ns** |        **16.006 ns** |        **15.720 ns** |  **1.00** |   **0.0391** |        **-** |        **-** |      **664 B** |        **1.00** |
|   IterateListSkippingDuplicates |      10 |          82.25 ns |         0.707 ns |         0.662 ns |  0.10 |        - |        - |        - |          - |        0.00 |
|                                 |         |                   |                  |                  |       |          |          |          |            |             |
| **IterateListAfterCallingDistinct** | **1000000** | **102,653,195.37 ns** | **1,924,800.171 ns** | **2,059,514.619 ns** |  **1.00** | **333.3333** | **333.3333** | **333.3333** | **43111295 B** |        **1.00** |
|   IterateListSkippingDuplicates | 1000000 |  16,591,849.55 ns |    35,779.919 ns |    31,717.966 ns |  0.16 |        - |        - |        - |          - |        0.00 |
