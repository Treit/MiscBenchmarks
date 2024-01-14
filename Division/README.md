# Dividing


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|             Method |  Count |          Mean |      Error |     StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |------- |--------------:|-----------:|-----------:|------:|--------:|----------:|------------:|
|   **DivideUsingFloat** |    **100** |      **59.54 ns** |   **0.107 ns** |   **0.095 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|  DivideUsingDouble |    100 |      59.25 ns |   0.066 ns |   0.055 ns |  1.00 |    0.00 |         - |          NA |
| DivideUsingDecimal |    100 |   2,590.34 ns |   4.520 ns |   4.007 ns | 43.50 |    0.11 |         - |          NA |
|     DivideUsingInt |    100 |      80.84 ns |   0.108 ns |   0.090 ns |  1.36 |    0.00 |         - |          NA |
|                    |        |               |            |            |       |         |           |             |
|   **DivideUsingFloat** | **100000** |  **92,833.39 ns** |  **57.645 ns** |  **48.136 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|  DivideUsingDouble | 100000 |  92,893.69 ns | 143.393 ns | 119.740 ns |  1.00 |    0.00 |         - |          NA |
| DivideUsingDecimal | 100000 | 622,062.61 ns | 566.538 ns | 442.316 ns |  6.70 |    0.01 |         - |          NA |
|     DivideUsingInt | 100000 |  92,793.78 ns |  40.701 ns |  36.081 ns |  1.00 |    0.00 |         - |          NA |
