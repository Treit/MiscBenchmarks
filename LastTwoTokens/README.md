# Getting the last two tokens from a delimited string.


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27699.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | Mean      | Error    | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |----------:|---------:|----------:|------:|--------:|-------:|----------:|------------:|
| LastTwoTokensWithSplit               | 406.34 ns | 8.126 ns | 10.276 ns | 15.47 |    0.42 | 0.2460 |    1064 B |       16.62 |
| LastTwoTokensWithRegex               | 263.35 ns | 5.229 ns |  8.443 ns | 10.17 |    0.47 | 0.1316 |     568 B |        8.88 |
| LastTwoTokensWithReverseAndSubstring | 446.51 ns | 7.525 ns |  7.039 ns | 16.94 |    0.49 | 0.1836 |     792 B |       12.38 |
| LastTwoTokensWalkingBackwards        |  26.31 ns | 0.584 ns |  0.625 ns |  1.00 |    0.00 | 0.0148 |      64 B |        1.00 |
| LastTwoTokensWithSpanAndLastIndexOf  |  38.06 ns | 0.592 ns |  0.554 ns |  1.44 |    0.05 | 0.0148 |      64 B |        1.00 |
