# Concurrently reading dictionary entries

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25290.1010)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                            Method | Count |       Mean |     Error |    StdDev |    Gen0 |   Gen1 | Allocated |
|---------------------------------- |------ |-----------:|----------:|----------:|--------:|-------:|----------:|
|   **ConcurrentReadsUsingParallelFor** |    **10** |   **8.270 μs** | **0.2619 μs** | **0.7555 μs** |  **0.5035** |      **-** |   **2.11 KB** |
| ConcurrentReadsUsingExplicitTasks |    10 |  19.305 μs | 0.3819 μs | 0.9650 μs |  0.4578 |      - |      2 KB |
|   **ConcurrentReadsUsingParallelFor** |  **1000** | **274.613 μs** | **5.4827 μs** | **9.0082 μs** |  **0.4883** |      **-** |      **3 KB** |
| ConcurrentReadsUsingExplicitTasks |  1000 | 295.102 μs | 4.6961 μs | 4.1630 μs | 40.5273 | 6.3477 | 172.15 KB |
