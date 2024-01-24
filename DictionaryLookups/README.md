# Dictionary lookups.





``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                          Method | Iterations |            Mean |      Error |     StdDev | Ratio | RatioSD |      Gen0 |   Allocated | Alloc Ratio |
|-------------------------------- |----------- |----------------:|-----------:|-----------:|------:|--------:|----------:|------------:|------------:|
|           **LookupUsingDictionary** |         **10** |        **19.54 μs** |   **0.040 μs** |   **0.034 μs** |  **1.00** |    **0.00** |         **-** |           **-** |          **NA** |
|           LookupUsingSortedList |         10 |        21.18 μs |   0.134 μs |   0.119 μs |  1.08 |    0.01 |         - |           - |          NA |
|     LookupUsingSortedDictionary |         10 |        27.74 μs |   0.082 μs |   0.072 μs |  1.42 |    0.00 |         - |           - |          NA |
| LookupUsingConcurrentDictionary |         10 |       131.57 μs |   0.810 μs |   0.718 μs |  6.73 |    0.04 |         - |           - |          NA |
|    LookupUsingOrderedDictionary |         10 |        18.77 μs |   0.044 μs |   0.041 μs |  0.96 |    0.00 |         - |           - |          NA |
|            LookupUsingHashtable |         10 |        20.94 μs |   0.059 μs |   0.052 μs |  1.07 |    0.00 |    0.7019 |     12000 B |          NA |
|     LookupUsingFrozenDictionary |         10 |        18.94 μs |   0.036 μs |   0.030 μs |  0.97 |    0.00 |         - |           - |          NA |
|                                 |            |                 |            |            |       |         |           |             |             |
|           **LookupUsingDictionary** |     **100000** |   **195,208.77 μs** | **310.770 μs** | **259.507 μs** |  **1.00** |    **0.00** |         **-** |           **-** |          **NA** |
|           LookupUsingSortedList |     100000 |   210,128.63 μs | 284.415 μs | 266.042 μs |  1.08 |    0.00 |         - |           - |          NA |
|     LookupUsingSortedDictionary |     100000 |   274,705.82 μs | 148.241 μs | 123.788 μs |  1.41 |    0.00 |         - |           - |          NA |
| LookupUsingConcurrentDictionary |     100000 | 1,314,361.63 μs | 702.067 μs | 548.127 μs |  6.73 |    0.01 |         - |           - |          NA |
|    LookupUsingOrderedDictionary |     100000 |   185,826.20 μs |  83.916 μs |  70.074 μs |  0.95 |    0.00 |         - |           - |          NA |
|            LookupUsingHashtable |     100000 |   208,842.84 μs | 643.035 μs | 536.964 μs |  1.07 |    0.00 | 7000.0000 | 120000245 B |          NA |
|     LookupUsingFrozenDictionary |     100000 |   189,302.52 μs | 660.850 μs | 515.948 μs |  0.97 |    0.00 |         - |           - |          NA |
