# List index vs. ElementAt


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                      Method |   Count |        Mean |    Error |   StdDev |
|---------------------------- |-------- |------------:|---------:|---------:|
|  **LookupElementsWithIndexing** |   **10000** |    **13.93 μs** | **0.042 μs** | **0.037 μs** |
| LookupElementsWithElementAt |   10000 |    63.20 μs | 0.634 μs | 0.593 μs |
|  **LookupElementsWithIndexing** | **1000000** | **5,061.04 μs** | **2.137 μs** | **1.895 μs** |
| LookupElementsWithElementAt | 1000000 | 8,670.99 μs | 8.414 μs | 7.026 μs |
