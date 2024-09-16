## String.Concat vs. StringBuilder vs. String interpolation (for small strings.)

.NET 6 was used for the results below.



```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27708.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                  | Count | Mean            | Error        | StdDev       | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------- |------ |----------------:|-------------:|-------------:|------:|--------:|----------:|------------:|
| **EqualStringsCompareWithEqualsOperator**   | **10**    |        **84.70 ns** |     **1.514 ns** |     **1.417 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod     | 10    |        83.43 ns |     1.712 ns |     3.172 ns |  1.02 |    0.05 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod | 10    |     1,386.55 ns |    14.848 ns |    13.889 ns | 16.38 |    0.38 |         - |          NA |
|                                         |       |                 |              |              |       |         |           |             |
| **EqualStringsCompareWithEqualsOperator**   | **10000** |   **156,569.08 ns** | **3,088.748 ns** | **3,793.260 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
| EqualStringsCompareWithEqualsMethod     | 10000 |   151,413.36 ns | 3,008.800 ns | 2,814.433 ns |  0.96 |    0.03 |         - |          NA |
| EqualStringsCompareWithStartsWithMethod | 10000 | 1,169,440.37 ns | 9,434.047 ns | 8,363.037 ns |  7.44 |    0.17 |       1 B |          NA |
