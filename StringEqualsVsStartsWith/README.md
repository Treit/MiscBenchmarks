## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.





```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27708.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                   | Count | Mean            | Error         | StdDev        | Median          | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |----------------:|--------------:|--------------:|----------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**                    | **10**    |        **85.49 ns** |      **1.434 ns** |      **1.197 ns** |        **85.62 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10    |        84.58 ns |      1.717 ns |      3.096 ns |        83.99 ns |  0.99 |    0.05 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10    |        82.06 ns |      1.581 ns |      1.320 ns |        81.81 ns |  0.96 |    0.02 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10    |       268.63 ns |     21.711 ns |     64.014 ns |       237.35 ns |  2.77 |    0.55 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10    |     1,643.45 ns |     66.552 ns |    195.184 ns |     1,581.21 ns | 18.08 |    1.07 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10    |       113.18 ns |      5.266 ns |     15.528 ns |       109.61 ns |  1.39 |    0.17 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10    |       231.74 ns |      9.609 ns |     28.181 ns |       217.93 ns |  2.77 |    0.36 |         - |          NA |
|                                                          |       |                 |               |               |                 |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**                    | **10000** |   **165,186.26 ns** |  **3,276.682 ns** |  **8,802.592 ns** |   **161,894.21 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod                      | 10000 |   161,873.61 ns |  2,974.680 ns |  7,352.673 ns |   158,798.82 ns |  0.98 |    0.07 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal               | 10000 |   155,677.63 ns |  3,107.142 ns |  6,485.763 ns |   153,162.05 ns |  0.94 |    0.07 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinalIgnoreCase     | 10000 |   364,660.82 ns |  7,212.821 ns | 19,500.281 ns |   360,589.84 ns |  2.21 |    0.16 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod                  | 10000 | 1,233,097.77 ns | 24,497.704 ns | 51,673.972 ns | 1,226,883.01 ns |  7.45 |    0.52 |       1 B |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal           | 10000 |   180,982.16 ns |  2,173.755 ns |  1,815.184 ns |   180,694.87 ns |  1.10 |    0.07 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinalIgnoreCase | 10000 |   343,166.32 ns |  6,837.011 ns | 10,844.223 ns |   340,719.56 ns |  2.08 |    0.13 |         - |          NA |
