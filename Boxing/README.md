# Illustrating the overhead of boxing


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                    Method |  Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 |  Allocated | Alloc Ratio |
|-------------------------- |------- |-------------:|-----------:|-----------:|-------------:|------:|--------:|---------:|---------:|---------:|-----------:|------------:|
| **BuildIntListWithoutBoxing** |   **1000** |     **1.125 μs** |  **0.0114 μs** |  **0.0106 μs** |     **1.124 μs** |  **1.00** |    **0.00** |   **0.2422** |   **0.0019** |        **-** |    **3.96 KB** |        **1.00** |
|     BuildIntListWitBoxing |   1000 |     7.005 μs |  0.0669 μs |  0.0626 μs |     6.998 μs |  6.23 |    0.09 |   1.9150 |   0.3815 |        - |    31.3 KB |        7.90 |
|                           |        |              |            |            |              |       |         |          |          |          |            |             |
| **BuildIntListWithoutBoxing** | **100000** |   **120.035 μs** |  **0.5416 μs** |  **0.4801 μs** |   **120.028 μs** |  **1.00** |    **0.00** | **124.8779** | **124.8779** | **124.8779** |  **390.72 KB** |        **1.00** |
|     BuildIntListWitBoxing | 100000 | 1,817.119 μs | 35.8911 μs | 44.0775 μs | 1,790.007 μs | 15.20 |    0.39 | 248.0469 | 248.0469 | 248.0469 | 3125.14 KB |        8.00 |
