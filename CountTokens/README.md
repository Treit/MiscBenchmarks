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
| CountTokensUsingLinqCount                                | 1000  |  35.89 μs | 0.658 μs | 1.268 μs |  35.42 μs |  3.34 |    0.14 |  7.3853 |   32000 B |          NA |
| CountTokensUsingSpanCount                                | 1000  |  10.86 μs | 0.209 μs | 0.196 μs |  10.85 μs |  1.00 |    0.00 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop                   | 1000  |  11.45 μs | 0.225 μs | 0.364 μs |  11.39 μs |  1.05 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop                       | 1000  |  11.13 μs | 0.164 μs | 0.214 μs |  11.05 μs |  1.03 |    0.02 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithShortCircuit   | 1000  |  11.29 μs | 0.214 μs | 0.375 μs |  11.12 μs |  1.06 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOf        | 1000  |  11.62 μs | 0.205 μs | 0.499 μs |  11.49 μs |  1.10 |    0.06 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron   | 1000  |  22.29 μs | 0.442 μs | 0.454 μs |  22.19 μs |  2.05 |    0.06 |  8.3313 |   35976 B |          NA |
| CountTokensUsingHandWrittenForEachLoopWithRegex          | 1000  | 131.38 μs | 2.579 μs | 6.703 μs | 129.53 μs | 12.24 |    0.92 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex | 1000  |  51.16 μs | 1.005 μs | 1.706 μs |  50.32 μs |  4.78 |    0.22 |       - |         - |          NA |
| CountTokensUsingSplitAndLength                           | 1000  |  64.99 μs | 0.675 μs | 0.631 μs |  65.01 μs |  5.98 |    0.11 | 28.8086 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount                      | 1000  | 108.61 μs | 1.962 μs | 1.532 μs | 108.96 μs |  9.99 |    0.27 | 46.3867 |  200744 B |          NA |
