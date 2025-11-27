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
| CountTokensUsingLinqCount                                | 1000  | 30.256 μs | 0.2527 μs | 0.2364 μs |  7.88 |    0.15 |  1.8921 |   32000 B |          NA |
| CountTokensUsingSpanCount                                | 1000  |  3.839 μs | 0.0765 μs | 0.0678 μs |  1.00 |    0.02 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoop                   | 1000  |  8.862 μs | 0.0569 μs | 0.0532 μs |  2.31 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForLoop                       | 1000  |  8.920 μs | 0.0673 μs | 0.0596 μs |  2.32 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithShortCircuit   | 1000  |  8.496 μs | 0.0811 μs | 0.0758 μs |  2.21 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOf        | 1000  |  6.526 μs | 0.1171 μs | 0.1150 μs |  1.70 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron   | 1000  |  6.276 μs | 0.1214 μs | 0.1192 μs |  1.64 |    0.04 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithRegex          | 1000  | 99.315 μs | 0.8218 μs | 0.7687 μs | 25.88 |    0.48 |       - |         - |          NA |
| CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex | 1000  | 33.265 μs | 0.2893 μs | 0.2706 μs |  8.67 |    0.16 |       - |         - |          NA |
| CountTokensUsingSplitAndLength                           | 1000  | 45.596 μs | 0.3698 μs | 0.3278 μs | 11.88 |    0.22 |  7.4463 |  124584 B |          NA |
| CountTokensUsingSplitToListAndCount                      | 1000  | 63.409 μs | 1.1259 μs | 1.0532 μs | 16.52 |    0.38 | 11.9629 |  200744 B |          NA |
