# Getting last element


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                    Method |   Count |       Mean |     Error |    StdDev |     Median |  Ratio | RatioSD |
|-------------------------- |-------- |-----------:|----------:|----------:|-----------:|-------:|--------:|
|  **LastElementViaArrayIndex** |    **1000** |  **0.0511 ns** | **0.0064 ns** | **0.0057 ns** |  **0.0510 ns** |   **1.00** |    **0.00** |
|   LastElementWithLinqLast |    1000 | 15.7992 ns | 0.0559 ns | 0.0495 ns | 15.7837 ns | 312.33 |   33.05 |
| LastElementWithRangeIndex |    1000 |  0.0110 ns | 0.0023 ns | 0.0021 ns |  0.0100 ns |   0.22 |    0.05 |
|                           |         |            |           |           |            |        |         |
|  **LastElementViaArrayIndex** |  **100000** |  **0.0622 ns** | **0.0051 ns** | **0.0048 ns** |  **0.0623 ns** |   **1.00** |    **0.00** |
|   LastElementWithLinqLast |  100000 | 23.4072 ns | 0.0439 ns | 0.0367 ns | 23.3889 ns | 381.48 |   30.35 |
| LastElementWithRangeIndex |  100000 |  0.0113 ns | 0.0027 ns | 0.0023 ns |  0.0109 ns |   0.18 |    0.04 |
|                           |         |            |           |           |            |        |         |
|  **LastElementViaArrayIndex** | **1000000** |  **0.0551 ns** | **0.0058 ns** | **0.0052 ns** |  **0.0543 ns** |   **1.00** |    **0.00** |
|   LastElementWithLinqLast | 1000000 | 16.0102 ns | 0.0292 ns | 0.0244 ns | 16.0069 ns | 292.09 |   27.51 |
| LastElementWithRangeIndex | 1000000 |  0.0194 ns | 0.0139 ns | 0.0130 ns |  0.0111 ns |   0.36 |    0.24 |
