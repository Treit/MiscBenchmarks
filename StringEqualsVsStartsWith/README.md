## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.







```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                   | Count | Mean          | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**                    | **10**    |      **56.67 ns** |      **0.378 ns** |      **0.316 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10    |      55.30 ns |      0.210 ns |      0.164 ns |  0.98 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | 10    |     648.51 ns |      5.372 ns |      5.025 ns | 11.44 |    0.11 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10    |      57.02 ns |      0.327 ns |      0.290 ns |  1.01 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10    |      87.29 ns |      0.520 ns |      0.461 ns |  1.54 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10    |     713.21 ns |     14.303 ns |     23.897 ns | 12.59 |    0.42 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | 10    |     644.17 ns |     12.400 ns |     11.599 ns | 11.37 |    0.21 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10    |      61.44 ns |      0.725 ns |      0.679 ns |  1.08 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10    |      89.27 ns |      0.603 ns |      0.535 ns |  1.58 |    0.01 |         - |          NA |
|                                                          |       |               |               |               |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**                    | **10000** | **124,963.92 ns** |  **1,455.221 ns** |  **1,361.215 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10000 | 126,945.41 ns |  1,427.723 ns |  1,265.639 ns |  1.02 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | 10000 | 569,136.91 ns |  4,375.518 ns |  3,878.783 ns |  4.55 |    0.06 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10000 | 127,491.91 ns |    786.382 ns |    697.107 ns |  1.02 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10000 | 166,647.81 ns |  1,206.478 ns |    941.939 ns |  1.33 |    0.02 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10000 | 710,261.58 ns |  6,819.849 ns |  6,045.618 ns |  5.68 |    0.08 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | 10000 | 683,837.51 ns | 12,897.907 ns | 14,335.989 ns |  5.47 |    0.13 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10000 | 131,336.48 ns |    970.033 ns |    907.370 ns |  1.05 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10000 | 168,163.62 ns |  1,134.843 ns |  1,061.533 ns |  1.35 |    0.02 |         - |          NA |
