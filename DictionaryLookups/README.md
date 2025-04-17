# Dictionary lookups.






```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27837.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                          | Iterations | Mean       | Error     | StdDev    | Median     | Ratio | RatioSD | Gen0      | Allocated  | Alloc Ratio  |
|-------------------------------- |----------- |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|-----------:|-------------:|
| LookupUsingDictionary           | 10000      |   3.179 ms | 0.0628 ms | 0.1655 ms |   3.122 ms |  1.00 |    0.00 |         - |        3 B |         1.00 |
| LookupUsingSortedList           | 10000      |   7.387 ms | 0.1460 ms | 0.2358 ms |   7.353 ms |  2.25 |    0.14 |         - |        6 B |         2.00 |
| LookupUsingSortedDictionary     | 10000      |  13.152 ms | 0.2599 ms | 0.6126 ms |  12.957 ms |  4.11 |    0.25 |         - |       12 B |         4.00 |
| LookupUsingConcurrentDictionary | 10000      | 128.955 ms | 1.4159 ms | 1.2552 ms | 128.485 ms | 38.74 |    2.09 |         - |      184 B |        61.33 |
| LookupUsingOrderedDictionary    | 10000      |   1.935 ms | 0.0376 ms | 0.0386 ms |   1.933 ms |  0.58 |    0.04 |         - |        1 B |         0.33 |
| LookupUsingHashtable            | 10000      |   7.084 ms | 0.0924 ms | 0.0772 ms |   7.076 ms |  2.14 |    0.11 | 2781.2500 | 12000006 B | 4,000,002.00 |
| LookupUsingFrozenDictionary     | 10000      |   2.359 ms | 0.0471 ms | 0.0484 ms |   2.342 ms |  0.71 |    0.04 |         - |        3 B |         1.00 |
| LookupUsingImmutableDictionary  | 10000      |   5.620 ms | 0.1109 ms | 0.1791 ms |   5.542 ms |  1.71 |    0.11 |         - |        6 B |         2.00 |
| LookupUsingDictionarySlim       | 10000      |   1.093 ms | 0.0182 ms | 0.0162 ms |   1.089 ms |  0.33 |    0.02 |         - |        1 B |         0.33 |
