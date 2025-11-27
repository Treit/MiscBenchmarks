# Dictionary lookups.









```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | Job       | Runtime   | Iterations | Mean         | Error       | StdDev      | Ratio | RatioSD | Gen0     | Allocated  | Alloc Ratio |
|-------------------------------- |---------- |---------- |----------- |-------------:|------------:|------------:|------:|--------:|---------:|-----------:|------------:|
| LookupUsingDictionary           | .NET 10.0 | .NET 10.0 | 10000      |   1,519.5 μs |    18.42 μs |    17.23 μs |  1.00 |    0.02 |        - |          - |          NA |
| LookupUsingSortedList           | .NET 10.0 | .NET 10.0 | 10000      |   5,626.4 μs |   112.08 μs |   261.99 μs |  3.70 |    0.18 |        - |          - |          NA |
| LookupUsingSortedDictionary     | .NET 10.0 | .NET 10.0 | 10000      |   5,283.3 μs |    37.46 μs |    35.04 μs |  3.48 |    0.04 |        - |          - |          NA |
| LookupUsingConcurrentDictionary | .NET 10.0 | .NET 10.0 | 10000      | 124,963.7 μs | 2,406.12 μs | 3,450.78 μs | 82.25 |    2.41 |        - |          - |          NA |
| LookupUsingOrderedDictionary    | .NET 10.0 | .NET 10.0 | 10000      |   1,430.3 μs |    12.91 μs |    11.45 μs |  0.94 |    0.01 |        - |          - |          NA |
| LookupUsingHashtable            | .NET 10.0 | .NET 10.0 | 10000      |   4,205.5 μs |    63.61 μs |    56.39 μs |  2.77 |    0.05 | 710.9375 | 12000000 B |          NA |
| LookupUsingFrozenDictionary     | .NET 10.0 | .NET 10.0 | 10000      |     768.1 μs |     3.40 μs |     3.01 μs |  0.51 |    0.01 |        - |          - |          NA |
| LookupUsingImmutableDictionary  | .NET 10.0 | .NET 10.0 | 10000      |   3,386.7 μs |    27.82 μs |    26.02 μs |  2.23 |    0.03 |        - |          - |          NA |
| LookupUsingDictionarySlim       | .NET 10.0 | .NET 10.0 | 10000      |   1,052.6 μs |    13.80 μs |    12.91 μs |  0.69 |    0.01 |        - |          - |          NA |
|                                 |           |           |            |              |             |             |       |         |          |            |             |
| LookupUsingDictionary           | .NET 9.0  | .NET 9.0  | 10000      |   1,444.5 μs |     6.69 μs |     5.93 μs |  1.00 |    0.01 |        - |          - |          NA |
| LookupUsingSortedList           | .NET 9.0  | .NET 9.0  | 10000      |   5,737.5 μs |   114.19 μs |   286.47 μs |  3.97 |    0.20 |        - |          - |          NA |
| LookupUsingSortedDictionary     | .NET 9.0  | .NET 9.0  | 10000      |   5,387.5 μs |    57.93 μs |    51.35 μs |  3.73 |    0.04 |        - |          - |          NA |
| LookupUsingConcurrentDictionary | .NET 9.0  | .NET 9.0  | 10000      | 125,712.6 μs | 2,357.83 μs | 2,620.72 μs | 87.03 |    1.80 |        - |          - |          NA |
| LookupUsingOrderedDictionary    | .NET 9.0  | .NET 9.0  | 10000      |   1,429.8 μs |     6.82 μs |     5.70 μs |  0.99 |    0.01 |        - |          - |          NA |
| LookupUsingHashtable            | .NET 9.0  | .NET 9.0  | 10000      |   4,203.9 μs |    59.17 μs |    55.35 μs |  2.91 |    0.04 | 710.9375 | 12000000 B |          NA |
| LookupUsingFrozenDictionary     | .NET 9.0  | .NET 9.0  | 10000      |     771.8 μs |     5.70 μs |     5.33 μs |  0.53 |    0.00 |        - |          - |          NA |
| LookupUsingImmutableDictionary  | .NET 9.0  | .NET 9.0  | 10000      |   3,376.0 μs |    17.19 μs |    15.23 μs |  2.34 |    0.01 |        - |          - |          NA |
| LookupUsingDictionarySlim       | .NET 9.0  | .NET 9.0  | 10000      |   1,052.0 μs |    16.82 μs |    15.73 μs |  0.73 |    0.01 |        - |          - |          NA |
