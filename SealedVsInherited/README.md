# Calling methods on sealed vs non-sealed classes.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                 Method | Count |         Mean |      Error |    StdDev |
|----------------------- |------ |-------------:|-----------:|----------:|
|                 **Sealed** |    **10** |     **3.918 μs** |  **0.0413 μs** | **0.0366 μs** |
|              NonSealed |    10 |     3.927 μs |  0.0414 μs | 0.0387 μs |
| NonSealedVirtualMethod |    10 |     3.928 μs |  0.0236 μs | 0.0221 μs |
|               OneChild |    10 |     3.933 μs |  0.0126 μs | 0.0118 μs |
|                 **Sealed** |  **1000** | **2,619.728 μs** |  **7.9635 μs** | **7.4491 μs** |
|              NonSealed |  1000 | 2,620.897 μs |  7.7089 μs | 6.4372 μs |
| NonSealedVirtualMethod |  1000 | 2,676.591 μs |  4.4089 μs | 3.4422 μs |
|               OneChild |  1000 | 2,674.027 μs | 10.0170 μs | 8.3646 μs |
