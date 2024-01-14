# Concurrently reading dictionary entries


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                            Method | Count |       Mean |     Error |    StdDev |   Gen0 |   Gen1 | Allocated |
|---------------------------------- |------ |-----------:|----------:|----------:|-------:|-------:|----------:|
|   **ConcurrentReadsUsingParallelFor** |    **10** |   **2.453 μs** | **0.0458 μs** | **0.0406 μs** | **0.1373** |      **-** |    **2.3 KB** |
| ConcurrentReadsUsingExplicitTasks |    10 |   3.618 μs | 0.0281 μs | 0.0263 μs | 0.1144 |      - |   1.88 KB |
|   **ConcurrentReadsUsingParallelFor** |  **1000** | **242.864 μs** | **4.0268 μs** | **3.7667 μs** |      **-** |      **-** |   **4.21 KB** |
| ConcurrentReadsUsingExplicitTasks |  1000 | 308.008 μs | 2.6801 μs | 2.5070 μs | 9.7656 | 1.4648 | 164.37 KB |
