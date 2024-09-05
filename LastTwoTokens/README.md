# Getting the last two tokens from a delimited string.

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27699.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                               | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| LastTwoTokensWithSplit               | 469.29 ns |  8.838 ns | 18.251 ns | 465.56 ns |  1.61 |    0.08 | 0.2465 |    1064 B |        1.87 |
| LastTwoTokensWithRegex               | 293.67 ns |  5.873 ns |  8.422 ns | 294.04 ns |  1.00 |    0.00 | 0.1316 |     568 B |        1.00 |
| LastTwoTokensWithReverseAndSubstring | 508.75 ns | 10.237 ns | 26.242 ns | 501.17 ns |  1.78 |    0.09 | 0.1831 |     792 B |        1.39 |
| LastTwoTokensWalkingBackwards        |  31.11 ns |  1.079 ns |  3.042 ns |  30.24 ns |  0.12 |    0.01 | 0.0148 |      64 B |        0.11 |
