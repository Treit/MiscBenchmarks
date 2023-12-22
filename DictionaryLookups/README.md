# Dictionary lookups.


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.26020.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2


```
|                          Method | Iterations |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------- |----------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|----------:|------------:|
|           **LookupUsingDictionary** |         **10** |        **16.38 μs** |      **0.324 μs** |      **0.541 μs** |        **16.25 μs** |  **1.00** |    **0.00** |         **-** |          **NA** |
|           LookupUsingSortedList |         10 |        22.80 μs |      0.446 μs |      0.496 μs |        22.79 μs |  1.40 |    0.04 |         - |          NA |
|     LookupUsingSortedDictionary |         10 |        31.21 μs |      0.798 μs |      2.199 μs |        30.25 μs |  1.94 |    0.19 |         - |          NA |
| LookupUsingConcurrentDictionary |         10 |       164.51 μs |      2.964 μs |      2.628 μs |       164.51 μs | 10.07 |    0.40 |         - |          NA |
|    LookupUsingOrderedDictionary |         10 |        16.83 μs |      0.336 μs |      0.449 μs |        16.70 μs |  1.03 |    0.04 |         - |          NA |
|                                 |            |                 |               |               |                 |       |         |           |             |
|           **LookupUsingDictionary** |     **100000** |   **168,152.60 μs** |  **3,272.778 μs** |  **5,095.321 μs** |   **166,831.35 μs** |  **1.00** |    **0.00** |     **126 B** |        **1.00** |
|           LookupUsingSortedList |     100000 |   241,938.60 μs |  7,431.405 μs | 20,960.409 μs |   234,489.17 μs |  1.43 |    0.14 |     252 B |        2.00 |
|     LookupUsingSortedDictionary |     100000 |   301,076.18 μs |  5,672.973 μs | 10,929.893 μs |   300,681.47 μs |  1.80 |    0.10 |     252 B |        2.00 |
| LookupUsingConcurrentDictionary |     100000 | 1,678,964.31 μs | 33,297.200 μs | 58,317.359 μs | 1,662,262.50 μs | 10.01 |    0.53 |     504 B |        4.00 |
|    LookupUsingOrderedDictionary |     100000 |   168,957.54 μs |  3,334.889 μs |  6,812.294 μs |   167,999.60 μs |  1.00 |    0.05 |     168 B |        1.33 |
