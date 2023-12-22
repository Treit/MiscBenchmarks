# Dictionary lookups.




``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26020.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
|                          Method | Iterations |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD |       Gen0 |   Allocated | Alloc Ratio |
|-------------------------------- |----------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|-----------:|------------:|------------:|
|           **LookupUsingDictionary** |         **10** |        **16.11 μs** |      **0.321 μs** |      **0.619 μs** |        **16.00 μs** |  **1.00** |    **0.00** |          **-** |           **-** |          **NA** |
|           LookupUsingSortedList |         10 |        20.94 μs |      0.624 μs |      1.800 μs |        20.42 μs |  1.30 |    0.11 |          - |           - |          NA |
|     LookupUsingSortedDictionary |         10 |        30.64 μs |      1.299 μs |      3.788 μs |        29.49 μs |  1.98 |    0.23 |          - |           - |          NA |
| LookupUsingConcurrentDictionary |         10 |       150.03 μs |      2.970 μs |      3.536 μs |       149.73 μs |  9.28 |    0.38 |          - |           - |          NA |
|    LookupUsingOrderedDictionary |         10 |        15.77 μs |      0.466 μs |      1.373 μs |        15.30 μs |  1.02 |    0.10 |          - |           - |          NA |
|            LookupUsingHashtable |         10 |        22.66 μs |      0.746 μs |      2.153 μs |        21.95 μs |  1.43 |    0.16 |     2.7771 |     12000 B |          NA |
|     LookupUsingFrozenDictionary |         10 |        16.10 μs |      0.320 μs |      0.886 μs |        15.90 μs |  1.01 |    0.06 |          - |           - |          NA |
|                                 |            |                 |               |               |                 |       |         |            |             |             |
|           **LookupUsingDictionary** |     **100000** |   **156,994.77 μs** |  **3,125.455 μs** |  **4,957.303 μs** |   **155,782.55 μs** |  **1.00** |    **0.00** |          **-** |           **-** |          **NA** |
|           LookupUsingSortedList |     100000 |   198,710.55 μs |  4,532.363 μs | 12,783.611 μs |   195,809.63 μs |  1.25 |    0.08 |          - |           - |          NA |
|     LookupUsingSortedDictionary |     100000 |   270,938.61 μs |  7,856.901 μs | 22,031.593 μs |   268,510.40 μs |  1.76 |    0.18 |          - |           - |          NA |
| LookupUsingConcurrentDictionary |     100000 | 1,530,218.06 μs | 30,284.663 μs | 70,789.422 μs | 1,498,882.00 μs |  9.82 |    0.53 |          - |           - |          NA |
|    LookupUsingOrderedDictionary |     100000 |   160,466.70 μs |  5,694.025 μs | 16,788.960 μs |   154,646.80 μs |  0.94 |    0.07 |          - |           - |          NA |
|            LookupUsingHashtable |     100000 |   232,084.28 μs |  6,839.540 μs | 19,733.636 μs |   225,975.55 μs |  1.51 |    0.12 | 27500.0000 | 120000368 B |          NA |
|     LookupUsingFrozenDictionary |     100000 |   165,822.00 μs |  5,428.790 μs | 16,006.910 μs |   161,618.56 μs |  1.02 |    0.06 |          - |           - |          NA |
