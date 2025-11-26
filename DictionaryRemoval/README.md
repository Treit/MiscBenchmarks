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
| **RegularDictionary**                | **100**   |     **2.212 μs** |   **0.1191 μs** |   **0.3220 μs** |     **2.100 μs** |  **1.02** |    **0.19** |         **-** |          **NA** |
| ConcurrentDictionary             | 100   |     5.824 μs |   0.2068 μs |   0.5968 μs |     5.650 μs |  2.68 |    0.42 |         - |          NA |
| ImmutableDictionaryRemove        | 100   |   136.742 μs |   6.6240 μs |  19.4270 μs |   144.600 μs | 62.90 |   11.69 |   45600 B |          NA |
| ImmutableDictionaryRemoveRange   | 100   |    96.363 μs |   2.4374 μs |   6.7539 μs |    97.250 μs | 44.32 |    6.14 |    7704 B |          NA |
| RegularDictionaryWithContainsKey | 100   |     3.346 μs |   0.1984 μs |   0.5819 μs |     3.100 μs |  1.54 |    0.33 |         - |          NA |
| RegularDictionaryBulkRemove      | 100   |     9.972 μs |   0.2028 μs |   0.5013 μs |    10.000 μs |  4.59 |    0.59 |     112 B |          NA |
|                                  |       |              |             |             |              |       |         |           |             |
| **RegularDictionary**                | **10000** |   **133.964 μs** |   **9.0275 μs** |  **26.6178 μs** |   **124.900 μs** |  **1.04** |    **0.28** |         **-** |          **NA** |
| ConcurrentDictionary             | 10000 |   323.147 μs |  14.2640 μs |  41.8338 μs |   301.400 μs |  2.50 |    0.55 |         - |          NA |
| ImmutableDictionaryRemove        | 10000 | 6,812.129 μs | 123.1681 μs | 198.8935 μs | 6,730.850 μs | 52.65 |    9.38 | 8783616 B |          NA |
| ImmutableDictionaryRemoveRange   | 10000 | 5,339.009 μs | 106.5727 μs | 255.3414 μs | 5,384.750 μs | 41.27 |    7.52 |  759896 B |          NA |
| RegularDictionaryWithContainsKey | 10000 |   175.581 μs |   8.9717 μs |  26.0286 μs |   171.000 μs |  1.36 |    0.31 |         - |          NA |
| RegularDictionaryBulkRemove      | 10000 |   256.764 μs |  12.2820 μs |  34.8419 μs |   254.850 μs |  1.98 |    0.44 |     112 B |          NA |
