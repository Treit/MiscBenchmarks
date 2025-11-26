# SortedList vs. Dictionary lookups by simple integer keys.




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Iterations | Mean          | Error        | StdDev       | Ratio | Allocated | Alloc Ratio |
|---------------------- |----------- |--------------:|-------------:|-------------:|------:|----------:|------------:|
| **LookupUsingDictionary** | **10**         |      **18.87 μs** |     **0.107 μs** |     **0.100 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | 10         |      21.13 μs |     0.111 μs |     0.104 μs |  1.12 |         - |          NA |
|                       |            |               |              |              |       |           |             |
| **LookupUsingDictionary** | **10000**      |  **19,010.24 μs** |   **103.378 μs** |    **96.700 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | 10000      |  21,138.08 μs |   115.224 μs |   107.780 μs |  1.11 |         - |          NA |
|                       |            |               |              |              |       |           |             |
| **LookupUsingDictionary** | **100000**     | **189,023.22 μs** | **1,230.910 μs** | **1,151.394 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | 100000     | 211,505.71 μs | 1,255.383 μs | 1,174.286 μs |  1.12 |         - |          NA |
