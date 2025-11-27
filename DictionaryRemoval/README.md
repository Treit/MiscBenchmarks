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
| **RegularDictionary**                | **100**   |     **2.404 μs** |   **0.2142 μs** |   **0.6316 μs** |     **2.100 μs** |  **1.06** |    **0.37** |         **-** |          **NA** |
| ConcurrentDictionary             | 100   |     6.367 μs |   0.5556 μs |   1.6209 μs |     5.500 μs |  2.81 |    0.96 |         - |          NA |
| ImmutableDictionaryRemove        | 100   |   134.474 μs |   5.7416 μs |  16.8390 μs |   136.000 μs | 59.33 |   15.26 |   45600 B |          NA |
| ImmutableDictionaryRemoveRange   | 100   |   100.521 μs |   3.3164 μs |   9.3539 μs |    99.500 μs | 44.35 |   10.76 |    7704 B |          NA |
| RegularDictionaryWithContainsKey | 100   |     3.374 μs |   0.2266 μs |   0.6464 μs |     3.100 μs |  1.49 |    0.44 |         - |          NA |
| RegularDictionaryBulkRemove      | 100   |    10.173 μs |   0.3297 μs |   0.9354 μs |    10.000 μs |  4.49 |    1.09 |     112 B |          NA |
|                                  |       |              |             |             |              |       |         |           |             |
| **RegularDictionary**                | **10000** |   **151.525 μs** |  **12.0768 μs** |  **34.6507 μs** |   **143.800 μs** |  **1.05** |    **0.33** |         **-** |          **NA** |
| ConcurrentDictionary             | 10000 |   317.388 μs |  22.4778 μs |  64.4930 μs |   281.500 μs |  2.20 |    0.66 |         - |          NA |
| ImmutableDictionaryRemove        | 10000 | 6,752.671 μs | 103.0682 μs | 147.8174 μs | 6,709.650 μs | 46.79 |   10.09 | 8783616 B |          NA |
| ImmutableDictionaryRemoveRange   | 10000 | 5,156.794 μs | 101.6608 μs | 214.4371 μs | 5,196.250 μs | 35.73 |    7.81 |  759896 B |          NA |
| RegularDictionaryWithContainsKey | 10000 |   207.796 μs |  14.1637 μs |  40.4098 μs |   201.850 μs |  1.44 |    0.42 |         - |          NA |
| RegularDictionaryBulkRemove      | 10000 |   286.570 μs |  16.3823 μs |  46.4740 μs |   281.700 μs |  1.99 |    0.54 |     112 B |          NA |
