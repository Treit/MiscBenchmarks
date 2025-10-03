# Removing dictionary entries


```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27959.1)
Unknown processor
.NET SDK 10.0.100-preview.6.25358.103
  [Host]     : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  Job-CNUJVU : .NET 9.0.8 (9.0.825.36511), X64 RyuJIT AVX-512F+CD+BW+DQ+VL

InvocationCount=1  UnrollFactor=1  

```
| Method                           | Count | Mean          | Error       | StdDev       | Median        | Ratio | RatioSD | Gen0      | Allocated | Alloc Ratio |
|--------------------------------- |------ |--------------:|------------:|-------------:|--------------:|------:|--------:|----------:|----------:|------------:|
| **RegularDictionary**                | **100**   |      **5.223 μs** |   **0.5316 μs** |     **1.482 μs** |      **4.900 μs** |  **1.07** |    **0.40** |         **-** |         **-** |          **NA** |
| ConcurrentDictionary             | 100   |     15.240 μs |   1.2073 μs |     3.522 μs |     15.650 μs |  3.12 |    1.05 |         - |         - |          NA |
| ImmutableDictionaryRemove        | 100   |    312.873 μs |  38.9083 μs |   112.259 μs |    350.150 μs | 64.02 |   28.12 |         - |   45600 B |          NA |
| ImmutableDictionaryRemoveRange   | 100   |    199.011 μs |  11.6724 μs |    33.302 μs |    193.850 μs | 40.72 |   12.04 |         - |    7704 B |          NA |
| RegularDictionaryWithContainsKey | 100   |      5.635 μs |   0.5741 μs |     1.675 μs |      5.400 μs |  1.15 |    0.45 |         - |         - |          NA |
| RegularDictionaryBulkRemove      | 100   |     19.879 μs |   2.3862 μs |     6.808 μs |     18.750 μs |  4.07 |    1.73 |         - |     112 B |          NA |
|                                  |       |               |             |              |               |       |         |           |           |             |
| **RegularDictionary**                | **10000** |    **641.130 μs** |  **28.2433 μs** |    **80.580 μs** |    **658.400 μs** |  **1.02** |    **0.22** |         **-** |         **-** |          **NA** |
| ConcurrentDictionary             | 10000 |  1,362.702 μs |  92.0097 μs |   261.016 μs |  1,349.600 μs |  2.17 |    0.56 |         - |         - |          NA |
| ImmutableDictionaryRemove        | 10000 | 19,142.582 μs | 530.5419 μs | 1,522.224 μs | 19,069.300 μs | 30.51 |    5.81 | 1000.0000 | 8783616 B |          NA |
| ImmutableDictionaryRemoveRange   | 10000 | 11,188.071 μs | 395.2292 μs | 1,127.611 μs | 11,105.950 μs | 17.83 |    3.57 |         - |  759896 B |          NA |
| RegularDictionaryWithContainsKey | 10000 |  1,068.387 μs |  97.7542 μs |   286.696 μs |    912.750 μs |  1.70 |    0.55 |         - |         - |          NA |
| RegularDictionaryBulkRemove      | 10000 |  1,247.137 μs |  87.5690 μs |   256.825 μs |  1,150.550 μs |  1.99 |    0.54 |         - |     112 B |          NA |
