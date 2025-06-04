# Comparing strings that are identical with Equals vs. StartsWith




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27708.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                   | Count | Mean            | Error         | StdDev         | Median          | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |----------------:|--------------:|---------------:|----------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**                    | **10**    |        **96.73 ns** |      **3.305 ns** |       **9.376 ns** |        **94.35 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10    |        86.68 ns |      1.679 ns |       1.489 ns |        86.62 ns |  0.89 |    0.08 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | 10    |     1,112.42 ns |     22.179 ns |      53.139 ns |     1,094.77 ns | 11.52 |    1.21 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10    |        85.38 ns |      1.707 ns |       1.753 ns |        84.95 ns |  0.89 |    0.08 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10    |       234.35 ns |      7.531 ns |      21.730 ns |       225.99 ns |  2.45 |    0.34 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10    |     1,406.76 ns |     20.502 ns |      16.006 ns |     1,403.06 ns | 14.71 |    1.01 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | 10    |     1,202.88 ns |     14.047 ns |      10.967 ns |     1,203.20 ns | 12.59 |    1.03 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10    |       104.49 ns |      3.442 ns |       9.875 ns |       102.10 ns |  1.09 |    0.15 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10    |       220.35 ns |      4.441 ns |       9.172 ns |       218.30 ns |  2.31 |    0.20 |         - |          NA |
|                                                          |       |                 |               |                |                 |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**                    | **10000** |   **159,735.36 ns** |  **3,175.360 ns** |   **4,346.469 ns** |   **159,272.02 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10000 |   154,098.91 ns |  2,883.313 ns |   2,555.982 ns |   153,203.50 ns |  0.96 |    0.03 |         - |          NA |
| EqualStringsCompareWithEqualsMethodIgnoreCase            | 10000 | 1,011,190.63 ns | 23,753.277 ns |  69,664.249 ns | 1,008,774.80 ns |  6.34 |    0.41 |       1 B |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10000 |   166,006.92 ns |  3,943.383 ns |  11,503.034 ns |   163,386.38 ns |  1.06 |    0.08 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10000 |   347,710.92 ns |  6,930.679 ns |   6,482.961 ns |   346,837.55 ns |  2.16 |    0.08 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10000 | 1,322,610.45 ns | 37,503.741 ns | 103,296.193 ns | 1,296,939.26 ns |  8.68 |    0.83 |       1 B |          NA |
| EqualStringsCompareWithStartsWithMethodIgnoreCase        | 10000 | 1,002,822.83 ns | 18,646.811 ns |  17,442.239 ns |   997,993.55 ns |  6.24 |    0.26 |       1 B |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10000 |   180,571.00 ns |  3,458.384 ns |   3,843.985 ns |   180,138.20 ns |  1.13 |    0.04 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10000 |   345,305.36 ns |  5,230.997 ns |   5,371.849 ns |   343,819.24 ns |  2.15 |    0.06 |         - |          NA |
