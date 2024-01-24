# Enumerating using IEnumerable vs List


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                             Method |  Count |       Mean |      Error |     StdDev | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
|----------------------------------- |------- |-----------:|-----------:|-----------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **EnumerateUsingEnumerableAndForEach** |   **1000** |   **1.272 μs** |  **0.0031 μs** |  **0.0026 μs** |  **1.00** |    **0.00** |   **0.0019** |        **-** |        **-** |      **40 B** |        **1.00** |
|     EnumerateUsingToListAndForEach |   1000 |   3.144 μs |  0.0519 μs |  0.0460 μs |  2.47 |    0.04 |   0.5035 |   0.0038 |        - |    8464 B |      211.60 |
|                                    |        |            |            |            |       |         |          |          |          |           |             |
| **EnumerateUsingEnumerableAndForEach** | **100000** | **126.757 μs** |  **0.1660 μs** |  **0.1386 μs** |  **1.00** |    **0.00** |        **-** |        **-** |        **-** |      **40 B** |        **1.00** |
|     EnumerateUsingToListAndForEach | 100000 | 648.414 μs | 16.3639 μs | 48.2494 μs |  5.21 |    0.38 | 285.1563 | 285.1563 | 285.1563 | 1049112 B |   26,227.80 |
