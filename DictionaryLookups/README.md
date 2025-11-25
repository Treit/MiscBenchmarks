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
| LookupUsingDictionary           | 10000      |   1,394.9 μs |     7.01 μs |     6.55 μs |  1.00 |    0.01 |        - |          - |          NA |
| LookupUsingSortedList           | 10000      |   5,042.3 μs |    99.96 μs |   152.65 μs |  3.61 |    0.11 |        - |          - |          NA |
| LookupUsingSortedDictionary     | 10000      |   5,089.5 μs |    29.66 μs |    26.29 μs |  3.65 |    0.02 |        - |          - |          NA |
| LookupUsingConcurrentDictionary | 10000      | 122,166.8 μs | 2,429.74 μs | 2,700.64 μs | 87.58 |    1.93 |        - |          - |          NA |
| LookupUsingOrderedDictionary    | 10000      |   1,436.6 μs |     7.95 μs |     7.04 μs |  1.03 |    0.01 |        - |          - |          NA |
| LookupUsingHashtable            | 10000      |   4,132.1 μs |    78.90 μs |    77.49 μs |  2.96 |    0.06 | 710.9375 | 12000000 B |          NA |
| LookupUsingFrozenDictionary     | 10000      |     769.3 μs |     4.45 μs |     4.16 μs |  0.55 |    0.00 |        - |          - |          NA |
| LookupUsingImmutableDictionary  | 10000      |   3,370.3 μs |    18.50 μs |    17.30 μs |  2.42 |    0.02 |        - |          - |          NA |
| LookupUsingDictionarySlim       | 10000      |   1,032.2 μs |     7.67 μs |     7.17 μs |  0.74 |    0.01 |        - |          - |          NA |
