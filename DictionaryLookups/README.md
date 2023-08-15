# Dictionary lookups.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25931.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.306
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2


```
|                          Method | Iterations |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------- |----------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|----------:|------------:|
|           **LookupUsingDictionary** |         **10** |        **16.60 μs** |      **0.328 μs** |      **0.337 μs** |        **16.62 μs** |  **1.00** |    **0.00** |         **-** |          **NA** |
|           LookupUsingSortedList |         10 |        23.72 μs |      0.750 μs |      2.139 μs |        22.75 μs |  1.51 |    0.16 |         - |          NA |
|     LookupUsingSortedDictionary |         10 |        31.52 μs |      0.597 μs |      1.644 μs |        31.31 μs |  1.92 |    0.09 |         - |          NA |
| LookupUsingConcurrentDictionary |         10 |       161.83 μs |      2.868 μs |      3.069 μs |       161.03 μs |  9.75 |    0.29 |         - |          NA |
|                                 |            |                 |               |               |                 |       |         |           |             |
|           **LookupUsingDictionary** |     **100000** |   **187,350.57 μs** |  **7,108.622 μs** | **20,848.359 μs** |   **178,380.00 μs** |  **1.00** |    **0.00** |     **181 B** |        **1.00** |
|           LookupUsingSortedList |     100000 |   269,675.36 μs | 14,030.306 μs | 40,480.641 μs |   257,912.90 μs |  1.45 |    0.23 |     544 B |        3.01 |
|     LookupUsingSortedDictionary |     100000 |   316,621.19 μs |  7,752.095 μs | 21,991.402 μs |   307,712.85 μs |  1.71 |    0.20 |     272 B |        1.50 |
| LookupUsingConcurrentDictionary |     100000 | 1,602,828.33 μs | 22,916.219 μs | 17,891.476 μs | 1,595,307.10 μs |  8.31 |    0.71 |    5288 B |       29.22 |
