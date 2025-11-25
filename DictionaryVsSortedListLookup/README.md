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
| **LookupUsingDictionary** | **10**         |      **18.84 μs** |     **0.085 μs** |     **0.080 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | 10         |      21.09 μs |     0.095 μs |     0.089 μs |  1.12 |         - |          NA |
|                       |            |               |              |              |       |           |             |
| **LookupUsingDictionary** | **10000**      |  **18,836.25 μs** |   **109.539 μs** |   **102.463 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | 10000      |  21,086.86 μs |    99.502 μs |    93.074 μs |  1.12 |         - |          NA |
|                       |            |               |              |              |       |           |             |
| **LookupUsingDictionary** | **100000**     | **188,728.77 μs** | **1,065.347 μs** |   **996.526 μs** |  **1.00** |         **-** |          **NA** |
| LookupUsingSortedList | 100000     | 211,059.09 μs | 1,307.161 μs | 1,158.764 μs |  1.12 |         - |          NA |
