# Dictionary lookups.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Iterations | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0     | Allocated  | Alloc Ratio |
|-------------------------------- |----------- |-------------:|------------:|------------:|------:|--------:|---------:|-----------:|------------:|
| LookupUsingDictionary           | 10000      |   1,403.1 μs |    11.04 μs |     9.79 μs |  1.00 |    0.01 |        - |          - |          NA |
| LookupUsingSortedList           | 10000      |   5,476.3 μs |   109.14 μs |   281.73 μs |  3.90 |    0.20 |        - |          - |          NA |
| LookupUsingSortedDictionary     | 10000      |   5,059.8 μs |    31.58 μs |    29.54 μs |  3.61 |    0.03 |        - |          - |          NA |
| LookupUsingConcurrentDictionary | 10000      | 123,712.4 μs | 2,471.44 μs | 2,537.99 μs | 88.18 |    1.86 |        - |          - |          NA |
| LookupUsingOrderedDictionary    | 10000      |   1,440.8 μs |     8.39 μs |     7.85 μs |  1.03 |    0.01 |        - |          - |          NA |
| LookupUsingHashtable            | 10000      |   4,124.1 μs |    78.38 μs |    73.32 μs |  2.94 |    0.05 | 710.9375 | 12000000 B |          NA |
| LookupUsingFrozenDictionary     | 10000      |     768.1 μs |     4.27 μs |     4.00 μs |  0.55 |    0.00 |        - |          - |          NA |
| LookupUsingImmutableDictionary  | 10000      |   3,367.6 μs |    17.60 μs |    16.47 μs |  2.40 |    0.02 |        - |          - |          NA |
| LookupUsingDictionarySlim       | 10000      |   1,050.6 μs |    12.85 μs |    12.02 μs |  0.75 |    0.01 |        - |          - |          NA |
