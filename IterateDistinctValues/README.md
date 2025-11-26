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
| **ForEachUsingHashSet**                    | **100000**     | **10**                  |   **377.5 μs** |  **3.90 μs** |  **3.65 μs** |  **1.00** |    **0.01** | **499.5117** | **499.5117** | **499.5117** | **1738622 B** |       **1.000** |
| ForEachUsingHashSetWithInitialCapacity | 100000     | 10                  |   251.0 μs |  2.16 μs |  2.02 μs |  0.66 |    0.01 |        - |        - |        - |     496 B |       0.000 |
| ForEachUsingDistinct                   | 100000     | 10                  |   385.3 μs |  1.58 μs |  1.40 μs |  1.02 |    0.01 |        - |        - |        - |     656 B |       0.000 |
|                                        |            |                     |            |          |          |       |         |          |          |          |           |             |
| **ForEachUsingHashSet**                    | **100000**     | **100**                 |   **369.3 μs** |  **5.40 μs** |  **5.05 μs** |  **1.00** |    **0.02** | **499.5117** | **499.5117** | **499.5117** | **1740152 B** |       **1.000** |
| ForEachUsingHashSetWithInitialCapacity | 100000     | 100                 |   253.2 μs |  1.85 μs |  1.73 μs |  0.69 |    0.01 |        - |        - |        - |    5832 B |       0.003 |
| ForEachUsingDistinct                   | 100000     | 100                 |   387.0 μs |  1.68 μs |  1.49 μs |  1.05 |    0.01 |        - |        - |        - |    5992 B |       0.003 |
|                                        |            |                     |            |          |          |       |         |          |          |          |           |             |
| **ForEachUsingHashSet**                    | **100000**     | **100000**              | **2,293.4 μs** | **45.75 μs** | **99.45 μs** |  **1.00** |    **0.07** | **496.0938** | **496.0938** | **496.0938** | **1738383 B** |        **1.00** |
| ForEachUsingHashSetWithInitialCapacity | 100000     | 100000              | 2,231.9 μs | 24.70 μs | 21.90 μs |  0.98 |    0.05 | 511.7188 | 500.0000 | 500.0000 | 2327268 B |        1.34 |
| ForEachUsingDistinct                   | 100000     | 100000              | 2,494.1 μs | 20.95 μs | 18.57 μs |  1.09 |    0.06 | 511.7188 | 500.0000 | 500.0000 | 2327476 B |        1.34 |
