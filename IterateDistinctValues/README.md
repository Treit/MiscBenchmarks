# Iterating distinct values



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | TotalItems | RandomNumberCeiling | Mean       | Error    | StdDev   | Ratio | RatioSD | Gen0     | Gen1     | Gen2     | Allocated | Alloc Ratio |
|--------------------------------------- |----------- |-------------------- |-----------:|---------:|---------:|------:|--------:|---------:|---------:|---------:|----------:|------------:|
| **ForEachUsingHashSet**                    | **100000**     | **10**                  |   **380.0 μs** |  **1.77 μs** |  **1.57 μs** |  **1.00** |    **0.01** | **499.5117** | **499.5117** | **499.5117** | **1738616 B** |       **1.000** |
| ForEachUsingHashSetWithInitialCapacity | 100000     | 10                  |   251.9 μs |  2.21 μs |  2.07 μs |  0.66 |    0.01 |        - |        - |        - |     496 B |       0.000 |
| ForEachUsingDistinct                   | 100000     | 10                  |   384.3 μs |  1.62 μs |  1.35 μs |  1.01 |    0.01 |        - |        - |        - |     656 B |       0.000 |
|                                        |            |                     |            |          |          |       |         |          |          |          |           |             |
| **ForEachUsingHashSet**                    | **100000**     | **100**                 |   **365.1 μs** |  **5.89 μs** |  **5.51 μs** |  **1.00** |    **0.02** | **499.5117** | **499.5117** | **499.5117** | **1740152 B** |       **1.000** |
| ForEachUsingHashSetWithInitialCapacity | 100000     | 100                 |   258.2 μs |  3.27 μs |  3.06 μs |  0.71 |    0.01 |        - |        - |        - |    5832 B |       0.003 |
| ForEachUsingDistinct                   | 100000     | 100                 |   384.6 μs |  2.55 μs |  2.39 μs |  1.05 |    0.02 |        - |        - |        - |    5992 B |       0.003 |
|                                        |            |                     |            |          |          |       |         |          |          |          |           |             |
| **ForEachUsingHashSet**                    | **100000**     | **100000**              | **2,154.6 μs** | **15.49 μs** | **13.73 μs** |  **1.00** |    **0.01** | **496.0938** | **496.0938** | **496.0938** | **1738383 B** |        **1.00** |
| ForEachUsingHashSetWithInitialCapacity | 100000     | 100000              | 2,210.6 μs | 19.55 μs | 17.33 μs |  1.03 |    0.01 | 511.7188 | 500.0000 | 500.0000 | 2327268 B |        1.34 |
| ForEachUsingDistinct                   | 100000     | 100000              | 2,521.0 μs | 15.12 μs | 13.40 μs |  1.17 |    0.01 | 511.7188 | 500.0000 | 500.0000 | 2327428 B |        1.34 |
