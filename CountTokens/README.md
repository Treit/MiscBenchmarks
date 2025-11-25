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
| CountTokensUsingLinqCount                                | 1000  | 30.471 μs | 0.2036 μs | 0.1904 μs |  7.90 |    0.19 |  1.8921 |   32000 B |          NA |
| CountTokensUsingSpanCount                                | 1000  |  3.861 μs | 0.0743 μs | 0.0940 μs |  1.00 |    0.03 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop                   | 1000  |  8.819 μs | 0.0614 μs | 0.0574 μs |  2.29 |    0.06 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop                       | 1000  |  8.924 μs | 0.0686 μs | 0.0642 μs |  2.31 |    0.06 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithShortCircuit   | 1000  |  8.438 μs | 0.0742 μs | 0.0694 μs |  2.19 |    0.05 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOf        | 1000  |  6.603 μs | 0.1286 μs | 0.1580 μs |  1.71 |    0.06 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron   | 1000  |  6.344 μs | 0.0945 μs | 0.0884 μs |  1.64 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithRegex          | 1000  | 98.904 μs | 0.4712 μs | 0.4408 μs | 25.63 |    0.61 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex | 1000  | 33.517 μs | 0.2614 μs | 0.2445 μs |  8.69 |    0.21 |       - |         - |          NA |
| CountTokensUsingSplitAndLength                           | 1000  | 43.950 μs | 0.3178 μs | 0.2817 μs | 11.39 |    0.28 |  7.4463 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount                      | 1000  | 60.937 μs | 0.4905 μs | 0.4588 μs | 15.79 |    0.39 | 11.9629 |  200744 B |          NA |
