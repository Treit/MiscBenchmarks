## Parse vs TryParse for weeding out bad input.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                    Method |  Count |           Mean |       Error |      StdDev | Ratio |      Gen0 |  Allocated | Alloc Ratio |
|-------------------------- |------- |---------------:|------------:|------------:|------:|----------:|-----------:|------------:|
|    **FindValidIntsWithParse** |    **100** |     **452.358 μs** |   **1.5728 μs** |   **1.4712 μs** | **1.000** |    **1.9531** |    **34840 B** |        **1.00** |
| FindValidIntsWithTryParse |    100 |       1.045 μs |   0.0037 μs |   0.0031 μs | 0.002 |         - |          - |        0.00 |
|                           |        |                |             |             |       |           |            |             |
|    **FindValidIntsWithParse** |   **1000** |   **4,661.299 μs** |   **6.1803 μs** |   **4.8252 μs** | **1.000** |   **15.6250** |   **372475 B** |        **1.00** |
| FindValidIntsWithTryParse |   1000 |      12.732 μs |   0.0935 μs |   0.0874 μs | 0.003 |         - |          - |        0.00 |
|                           |        |                |             |             |       |           |            |             |
|    **FindValidIntsWithParse** |  **10000** |  **46,803.792 μs** |  **67.1272 μs** |  **56.0543 μs** | **1.000** |  **181.8182** |  **3750884 B** |        **1.00** |
| FindValidIntsWithTryParse |  10000 |     150.919 μs |   0.6041 μs |   0.5355 μs | 0.003 |         - |          - |        0.00 |
|                           |        |                |             |             |       |           |            |             |
|    **FindValidIntsWithParse** | **100000** | **467,908.633 μs** | **608.9813 μs** | **569.6415 μs** | **1.000** | **2000.0000** | **37667280 B** |        **1.00** |
| FindValidIntsWithTryParse | 100000 |   1,537.764 μs |   4.1181 μs |   3.6506 μs | 0.003 |         - |          - |        0.00 |
