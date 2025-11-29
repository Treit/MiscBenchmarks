# Getting the count of tokens in a delimited string








```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                   | Count | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| CountTokensUsingLinqCount                                | 1000  | 29.560 μs | 0.2222 μs | 0.2078 μs |  7.81 |    0.09 |  1.8921 |   32000 B |          NA |
| CountTokensUsingSpanCount                                | 1000  |  3.784 μs | 0.0428 μs | 0.0379 μs |  1.00 |    0.01 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop                   | 1000  |  8.797 μs | 0.0376 μs | 0.0352 μs |  2.33 |    0.02 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop                       | 1000  |  8.872 μs | 0.0249 μs | 0.0233 μs |  2.34 |    0.02 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithShortCircuit   | 1000  |  8.632 μs | 0.0504 μs | 0.0471 μs |  2.28 |    0.03 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOf        | 1000  |  6.413 μs | 0.0379 μs | 0.0317 μs |  1.69 |    0.02 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron   | 1000  |  6.249 μs | 0.0994 μs | 0.0930 μs |  1.65 |    0.03 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithRegex          | 1000  | 99.687 μs | 0.1904 μs | 0.1781 μs | 26.35 |    0.26 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex | 1000  | 33.207 μs | 0.2526 μs | 0.2239 μs |  8.78 |    0.10 |       - |         - |          NA |
| CountTokensUsingSplitAndLength                           | 1000  | 43.381 μs | 0.3081 μs | 0.2882 μs | 11.47 |    0.13 |  7.4463 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount                      | 1000  | 61.371 μs | 0.3110 μs | 0.2757 μs | 16.22 |    0.17 | 11.9629 |  200744 B |          NA |
