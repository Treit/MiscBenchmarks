# SortedList vs. Dictionary lookups by simple integer keys.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                Method | Iterations |          Mean |      Error |     StdDev | Ratio | Allocated | Alloc Ratio |
|---------------------- |----------- |--------------:|-----------:|-----------:|------:|----------:|------------:|
| **LookupUsingDictionary** |         **10** |      **19.51 μs** |   **0.014 μs** |   **0.012 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList |         10 |      21.05 μs |   0.120 μs |   0.106 μs |  1.08 |         - |          NA |
|                       |            |               |            |            |       |           |             |
| **LookupUsingDictionary** |      **10000** |  **19,492.58 μs** |   **5.218 μs** |   **4.357 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList |      10000 |  20,975.93 μs |  20.934 μs |  17.481 μs |  1.08 |         - |          NA |
|                       |            |               |            |            |       |           |             |
| **LookupUsingDictionary** |     **100000** | **195,124.52 μs** | **192.100 μs** | **160.413 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList |     100000 | 210,361.81 μs | 400.640 μs | 355.157 μs |  1.08 |         - |          NA |
