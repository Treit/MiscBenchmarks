## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.









```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                   | Job       | Runtime   | Count | Mean          | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------------- |---------- |---------- |------ |--------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**                    | **.NET 10.0** | **.NET 10.0** | **10**    |      **56.55 ns** |      **0.145 ns** |      **0.121 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | .NET 10.0 | .NET 10.0 | 10    |      55.29 ns |      0.112 ns |      0.099 ns |  0.98 |    0.00 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | .NET 10.0 | .NET 10.0 | 10    |     644.44 ns |      1.776 ns |      1.483 ns | 11.40 |    0.03 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | .NET 10.0 | .NET 10.0 | 10    |      56.32 ns |      0.204 ns |      0.191 ns |  1.00 |    0.00 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | .NET 10.0 | .NET 10.0 | 10    |      86.46 ns |      0.167 ns |      0.139 ns |  1.53 |    0.00 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | .NET 10.0 | .NET 10.0 | 10    |     681.64 ns |      3.496 ns |      2.920 ns | 12.05 |    0.06 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | .NET 10.0 | .NET 10.0 | 10    |     655.60 ns |      7.645 ns |      6.777 ns | 11.59 |    0.12 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | .NET 10.0 | .NET 10.0 | 10    |      60.72 ns |      0.238 ns |      0.223 ns |  1.07 |    0.00 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | .NET 10.0 | .NET 10.0 | 10    |      88.50 ns |      0.131 ns |      0.102 ns |  1.57 |    0.00 |         - |          NA |
|                                                          |           |           |       |               |               |               |       |         |           |             |
| EqualStringsCompareWithEqualsOperator                    | .NET 9.0  | .NET 9.0  | 10    |      57.47 ns |      0.261 ns |      0.244 ns |  1.00 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethod                      | .NET 9.0  | .NET 9.0  | 10    |      55.36 ns |      0.068 ns |      0.060 ns |  0.96 |    0.00 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | .NET 9.0  | .NET 9.0  | 10    |     642.43 ns |      2.208 ns |      1.843 ns | 11.18 |    0.06 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | .NET 9.0  | .NET 9.0  | 10    |      56.98 ns |      0.182 ns |      0.161 ns |  0.99 |    0.00 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | .NET 9.0  | .NET 9.0  | 10    |      88.86 ns |      1.526 ns |      1.353 ns |  1.55 |    0.02 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | .NET 9.0  | .NET 9.0  | 10    |     684.35 ns |     13.273 ns |     13.630 ns | 11.91 |    0.24 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | .NET 9.0  | .NET 9.0  | 10    |     659.96 ns |     13.209 ns |     22.430 ns | 11.48 |    0.39 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | .NET 9.0  | .NET 9.0  | 10    |      60.81 ns |      0.407 ns |      0.340 ns |  1.06 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | .NET 9.0  | .NET 9.0  | 10    |      90.26 ns |      1.770 ns |      2.107 ns |  1.57 |    0.04 |         - |          NA |
|                                                          |           |           |       |               |               |               |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**                    | **.NET 10.0** | **.NET 10.0** | **10000** | **124,573.63 ns** |    **857.764 ns** |    **760.385 ns** |  **1.00** |    **0.01** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | .NET 10.0 | .NET 10.0 | 10000 | 126,457.19 ns |    743.397 ns |    695.374 ns |  1.02 |    0.01 |       3 B |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | .NET 10.0 | .NET 10.0 | 10000 | 565,439.51 ns |  1,542.532 ns |  1,288.084 ns |  4.54 |    0.03 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | .NET 10.0 | .NET 10.0 | 10000 | 127,190.51 ns |    668.058 ns |    624.902 ns |  1.02 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | .NET 10.0 | .NET 10.0 | 10000 | 163,705.54 ns |  1,164.616 ns |  1,089.383 ns |  1.31 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | .NET 10.0 | .NET 10.0 | 10000 | 607,224.01 ns | 11,644.748 ns | 11,958.299 ns |  4.87 |    0.10 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | .NET 10.0 | .NET 10.0 | 10000 | 681,126.07 ns | 10,341.129 ns |  9,673.098 ns |  5.47 |    0.08 |      12 B |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | .NET 10.0 | .NET 10.0 | 10000 | 131,214.25 ns |    454.468 ns |    425.110 ns |  1.05 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | .NET 10.0 | .NET 10.0 | 10000 | 165,795.00 ns |    863.553 ns |    721.106 ns |  1.33 |    0.01 |         - |          NA |
|                                                          |           |           |       |               |               |               |       |         |           |             |
| EqualStringsCompareWithEqualsOperator                    | .NET 9.0  | .NET 9.0  | 10000 | 123,216.07 ns |    792.290 ns |    702.345 ns |  1.00 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethod                      | .NET 9.0  | .NET 9.0  | 10000 | 126,434.42 ns |    964.678 ns |    902.360 ns |  1.03 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | .NET 9.0  | .NET 9.0  | 10000 | 564,856.58 ns |  1,892.062 ns |  1,677.264 ns |  4.58 |    0.03 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | .NET 9.0  | .NET 9.0  | 10000 | 126,888.97 ns |    661.031 ns |    618.329 ns |  1.03 |    0.01 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | .NET 9.0  | .NET 9.0  | 10000 | 164,737.35 ns |    919.512 ns |    860.112 ns |  1.34 |    0.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | .NET 9.0  | .NET 9.0  | 10000 | 602,965.98 ns |  8,356.189 ns |  6,523.963 ns |  4.89 |    0.06 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | .NET 9.0  | .NET 9.0  | 10000 | 698,776.72 ns | 12,296.713 ns | 10,900.716 ns |  5.67 |    0.09 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | .NET 9.0  | .NET 9.0  | 10000 | 130,691.15 ns |    767.272 ns |    680.167 ns |  1.06 |    0.01 |       3 B |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | .NET 9.0  | .NET 9.0  | 10000 | 166,299.04 ns |  1,296.555 ns |  1,212.798 ns |  1.35 |    0.01 |         - |          NA |
