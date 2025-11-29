# Removing dictionary entries





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  Job-CNUJVU : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method                           | Count | Mean         | Error       | StdDev      | Median       | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------- |------ |-------------:|------------:|------------:|-------------:|------:|--------:|----------:|------------:|
| **RegularDictionary**                | **100**   |     **2.137 μs** |   **0.0469 μs** |   **0.0958 μs** |     **2.100 μs** |  **1.00** |    **0.06** |         **-** |          **NA** |
| ConcurrentDictionary             | 100   |     5.006 μs |   0.1060 μs |   0.1088 μs |     5.000 μs |  2.35 |    0.11 |         - |          NA |
| ImmutableDictionaryRemove        | 100   |   107.519 μs |   2.1388 μs |   2.1005 μs |   107.650 μs | 50.41 |    2.41 |   45600 B |          NA |
| ImmutableDictionaryRemoveRange   | 100   |    86.335 μs |   1.6888 μs |   1.9448 μs |    86.150 μs | 40.47 |    1.99 |    7704 B |          NA |
| RegularDictionaryWithContainsKey | 100   |     2.824 μs |   0.0618 μs |   0.1468 μs |     2.800 μs |  1.32 |    0.09 |         - |          NA |
| RegularDictionaryBulkRemove      | 100   |     9.157 μs |   0.1824 μs |   0.2617 μs |     9.200 μs |  4.29 |    0.22 |     112 B |          NA |
|                                  |       |              |             |             |              |       |         |           |             |
| **RegularDictionary**                | **10000** |   **131.635 μs** |   **8.3360 μs** |  **24.1842 μs** |   **127.250 μs** |  **1.03** |    **0.25** |         **-** |          **NA** |
| ConcurrentDictionary             | 10000 |   381.958 μs |   4.1409 μs |   3.2329 μs |   382.150 μs |  2.99 |    0.49 |         - |          NA |
| ImmutableDictionaryRemove        | 10000 | 6,854.905 μs | 131.5558 μs | 161.5624 μs | 6,851.200 μs | 53.66 |    8.89 | 8783616 B |          NA |
| ImmutableDictionaryRemoveRange   | 10000 | 5,103.519 μs | 100.6655 μs | 210.1264 μs | 5,088.500 μs | 39.95 |    6.76 |  759896 B |          NA |
| RegularDictionaryWithContainsKey | 10000 |   150.593 μs |   1.9666 μs |   1.7433 μs |   150.150 μs |  1.18 |    0.19 |         - |          NA |
| RegularDictionaryBulkRemove      | 10000 |   241.131 μs |  11.6229 μs |  33.7201 μs |   221.400 μs |  1.89 |    0.41 |     112 B |          NA |
