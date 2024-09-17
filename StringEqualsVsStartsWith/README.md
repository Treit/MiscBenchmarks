# Comparing strings that are identical with Equals vs. StartsWith


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27708.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                         | Count | Mean            | Error         | StdDev        | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |------ |----------------:|--------------:|--------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**          | **10**    |        **85.53 ns** |      **1.749 ns** |      **2.149 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod            | 10    |        83.02 ns |      1.238 ns |      1.033 ns |  0.98 |    0.03 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal     | 10    |        82.89 ns |      1.543 ns |      1.585 ns |  0.97 |    0.02 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod        | 10    |     1,419.01 ns |     25.420 ns |     34.795 ns | 16.63 |    0.59 |         - |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal | 10    |        97.54 ns |      1.960 ns |      3.220 ns |  1.15 |    0.05 |         - |          NA |
|                                                |       |                 |               |               |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**          | **10000** |   **156,852.44 ns** |  **3,001.269 ns** |  **2,660.547 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod            | 10000 |   157,177.70 ns |  2,994.616 ns |  3,075.250 ns |  1.01 |    0.02 |         - |          NA |
| EqualStringsCompareWithEqualsMethodOrdinal     | 10000 |   165,510.58 ns |  4,535.054 ns | 12,791.201 ns |  1.03 |    0.03 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod        | 10000 | 1,181,338.61 ns | 12,216.081 ns | 11,426.930 ns |  7.53 |    0.14 |       1 B |          NA |
| EqualStringsCompareWithStartsWithMethodOrdinal | 10000 |   179,651.18 ns |  3,583.731 ns |  4,784.178 ns |  1.15 |    0.03 |         - |          NA |
