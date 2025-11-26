# Getting the count of tokens in a delimited string






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                                   | Count | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|--------------------------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|--------:|----------:|------------:|
| CountTokensUsingLinqCount                                | 1000  |  30.086 μs | 0.1631 μs | 0.1446 μs |  7.57 |    0.12 |  1.8921 |   32000 B |          NA |
| CountTokensUsingSpanCount                                | 1000  |   3.976 μs | 0.0723 μs | 0.0603 μs |  1.00 |    0.02 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop                   | 1000  |   8.872 μs | 0.0637 μs | 0.0595 μs |  2.23 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop                       | 1000  |   8.943 μs | 0.0720 μs | 0.0673 μs |  2.25 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithShortCircuit   | 1000  |   8.568 μs | 0.0924 μs | 0.0864 μs |  2.16 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOf        | 1000  |   6.498 μs | 0.0339 μs | 0.0317 μs |  1.63 |    0.03 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron   | 1000  |   6.370 μs | 0.0530 μs | 0.0495 μs |  1.60 |    0.03 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithRegex          | 1000  | 101.166 μs | 0.4323 μs | 0.3832 μs | 25.45 |    0.39 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex | 1000  |  33.123 μs | 0.2333 μs | 0.2183 μs |  8.33 |    0.13 |       - |         - |          NA |
| CountTokensUsingSplitAndLength                           | 1000  |  44.030 μs | 0.7285 μs | 0.6815 μs | 11.08 |    0.23 |  7.4463 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount                      | 1000  |  61.400 μs | 0.6665 μs | 0.5908 μs | 15.45 |    0.27 | 11.9629 |  200744 B |          NA |
