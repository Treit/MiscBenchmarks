# SortedList vs. Dictionary lookups by simple integer keys.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | Job       | Runtime   | Iterations | Mean          | Error        | StdDev       | Ratio | Allocated | Alloc Ratio |
|---------------------- |---------- |---------- |----------- |--------------:|-------------:|-------------:|------:|----------:|------------:|
| **LookupUsingDictionary** | **.NET 10.0** | **.NET 10.0** | **10**         |      **18.90 μs** |     **0.154 μs** |     **0.144 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | .NET 10.0 | .NET 10.0 | 10         |      21.16 μs |     0.143 μs |     0.111 μs |  1.12 |         - |          NA |
|                       |           |           |            |               |              |              |       |           |             |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 10         |      18.88 μs |     0.101 μs |     0.095 μs |  1.00 |         - |          NA |
| LookupUsingSortedList | .NET 9.0  | .NET 9.0  | 10         |      21.16 μs |     0.114 μs |     0.107 μs |  1.12 |         - |          NA |
|                       |           |           |            |               |              |              |       |           |             |
| **LookupUsingDictionary** | **.NET 10.0** | **.NET 10.0** | **10000**      |  **18,869.30 μs** |   **108.106 μs** |   **101.122 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | .NET 10.0 | .NET 10.0 | 10000      |  21,166.46 μs |   144.293 μs |   134.971 μs |  1.12 |         - |          NA |
|                       |           |           |            |               |              |              |       |           |             |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 10000      |  19,021.05 μs |   113.716 μs |   106.370 μs |  1.00 |         - |          NA |
| LookupUsingSortedList | .NET 9.0  | .NET 9.0  | 10000      |  21,156.98 μs |   106.582 μs |    99.697 μs |  1.11 |         - |          NA |
|                       |           |           |            |               |              |              |       |           |             |
| **LookupUsingDictionary** | **.NET 10.0** | **.NET 10.0** | **100000**     | **189,772.10 μs** | **1,315.473 μs** | **1,230.494 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | .NET 10.0 | .NET 10.0 | 100000     | 211,754.14 μs | 1,377.827 μs | 1,288.820 μs |  1.12 |         - |          NA |
|                       |           |           |            |               |              |              |       |           |             |
| LookupUsingDictionary | .NET 9.0  | .NET 9.0  | 100000     | 188,975.75 μs | 1,333.952 μs | 1,247.780 μs |  1.00 |         - |          NA |
| LookupUsingSortedList | .NET 9.0  | .NET 9.0  | 100000     | 211,580.71 μs | 1,407.745 μs | 1,316.806 μs |  1.12 |         - |          NA |
