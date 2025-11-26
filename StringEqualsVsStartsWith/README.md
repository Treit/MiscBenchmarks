## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                   | Count | Mean          | Error         | StdDev        | Median        | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |--------------:|--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**                    | **10**    |      **57.98 ns** |      **1.168 ns** |      **1.519 ns** |      **57.52 ns** |  **1.00** |    **0.04** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10    |      55.33 ns |      0.306 ns |      0.255 ns |      55.41 ns |  0.95 |    0.02 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | 10    |     654.76 ns |      8.925 ns |      8.349 ns |     653.88 ns | 11.30 |    0.32 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10    |      56.94 ns |      0.798 ns |      0.747 ns |      57.27 ns |  0.98 |    0.03 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10    |      86.95 ns |      0.329 ns |      0.308 ns |      87.01 ns |  1.50 |    0.04 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10    |     696.22 ns |     13.803 ns |     21.079 ns |     684.14 ns | 12.02 |    0.47 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | 10    |     695.78 ns |     13.413 ns |     12.547 ns |     698.36 ns | 12.01 |    0.37 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10    |      61.32 ns |      0.556 ns |      0.520 ns |      61.24 ns |  1.06 |    0.03 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10    |      89.66 ns |      1.148 ns |      1.018 ns |      89.68 ns |  1.55 |    0.04 |         - |          NA |
|                                                          |       |               |               |               |               |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**                    | **10000** | **125,242.14 ns** |  **1,080.539 ns** |  **1,010.737 ns** | **125,562.26 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10000 | 127,199.32 ns |    951.006 ns |    889.572 ns | 127,243.63 ns |  1.02 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | 10000 | 570,413.02 ns |  5,265.236 ns |  4,925.105 ns | 571,138.57 ns |  4.55 |    0.05 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10000 | 128,476.94 ns |  1,306.985 ns |  1,222.555 ns | 128,411.69 ns |  1.03 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10000 | 165,706.86 ns |  1,320.222 ns |  1,170.342 ns | 165,757.18 ns |  1.32 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10000 | 699,528.80 ns | 12,978.995 ns | 19,024.445 ns | 705,617.48 ns |  5.59 |    0.16 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | 10000 | 692,215.53 ns | 11,047.080 ns | 10,333.446 ns | 697,191.70 ns |  5.53 |    0.09 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10000 | 132,061.94 ns |  1,033.205 ns |    966.461 ns | 132,449.93 ns |  1.05 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10000 | 167,725.55 ns |  1,519.499 ns |  1,421.340 ns | 167,825.10 ns |  1.34 |    0.02 |         - |          NA |
