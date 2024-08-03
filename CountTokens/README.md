# Getting the count of tokens in a delimited string




```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27673.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                                   | Count | Mean      | Error    | StdDev   | Median    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|--------:|----------:|------------:|
| CountTokensUsingLinqCount                                | 1000  |  34.81 μs | 0.326 μs | 0.255 μs |  34.81 μs |  3.20 |    0.13 |  7.3853 |   32000 B |          NA |
| CountTokensUsingSpanCount                                | 1000  |  11.27 μs | 0.217 μs | 0.537 μs |  11.24 μs |  1.00 |    0.00 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop                   | 1000  |  11.97 μs | 0.236 μs | 0.425 μs |  11.89 μs |  1.07 |    0.07 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop                       | 1000  |  11.30 μs | 0.107 μs | 0.095 μs |  11.28 μs |  1.03 |    0.05 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithShortCircuit   | 1000  |  11.04 μs | 0.213 μs | 0.210 μs |  10.94 μs |  1.00 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOf        | 1000  |  11.76 μs | 0.175 μs | 0.155 μs |  11.73 μs |  1.07 |    0.05 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron   | 1000  |  12.14 μs | 0.216 μs | 0.181 μs |  12.11 μs |  1.11 |    0.05 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithRegex          | 1000  | 129.32 μs | 2.153 μs | 1.797 μs | 129.16 μs | 11.87 |    0.52 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex | 1000  |  53.20 μs | 0.968 μs | 2.357 μs |  52.29 μs |  4.73 |    0.32 |       - |         - |          NA |
| CountTokensUsingSplitAndLength                           | 1000  |  67.99 μs | 1.349 μs | 2.061 μs |  67.28 μs |  6.08 |    0.41 | 28.8086 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount                      | 1000  | 115.30 μs | 2.291 μs | 5.915 μs | 112.62 μs | 10.27 |    0.71 | 46.5088 |  200744 B |          NA |
