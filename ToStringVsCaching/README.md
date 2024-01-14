# Getting the string representations of many items by calling ToString() vs. caching the string value.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                      Method |   Count |        Mean |     Error |    StdDev | Ratio | RatioSD |      Gen0 |  Allocated | Alloc Ratio |
|---------------------------- |-------- |------------:|----------:|----------:|------:|--------:|----------:|-----------:|------------:|
|     **ProcessDataWithToString** |   **10000** |    **264.6 μs** |   **3.45 μs** |   **3.23 μs** |  **1.00** |    **0.00** |   **32.7148** |   **550416 B** |        **1.00** |
| ProcessDataWithCachedString |   10000 |    325.5 μs |   1.88 μs |   1.76 μs |  1.23 |    0.02 |         - |          - |        0.00 |
|                             |         |             |           |           |       |         |           |            |             |
|     **ProcessDataWithToString** | **1000000** | **31,814.1 μs** | **151.34 μs** | **141.57 μs** |  **1.00** |    **0.00** | **3750.0000** | **63192224 B** |        **1.00** |
| ProcessDataWithCachedString | 1000000 | 30,774.1 μs |  32.90 μs |  30.78 μs |  0.97 |    0.00 |         - |          - |        0.00 |
