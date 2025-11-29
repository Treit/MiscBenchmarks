# Getting the last two tokens from a delimited string.





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Job       | Runtime   | Mean      | Error    | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------- |---------- |---------- |----------:|---------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| LastTwoTokensWithSplit               | .NET 10.0 | .NET 10.0 | 274.26 ns | 4.246 ns |  3.971 ns | 16.28 |    0.85 | 0.0634 | 0.0005 |    1064 B |       16.62 |
| LastTwoTokensWithRegex               | .NET 10.0 | .NET 10.0 | 195.26 ns | 2.031 ns |  1.900 ns | 11.59 |    0.59 | 0.0339 |      - |     568 B |        8.88 |
| LastTwoTokensWithReverseAndSubstring | .NET 10.0 | .NET 10.0 | 487.13 ns | 5.875 ns |  5.495 ns | 28.91 |    1.48 | 0.0196 |      - |     328 B |        5.12 |
| LastTwoTokensWalkingBackwards        | .NET 10.0 | .NET 10.0 |  16.89 ns | 0.398 ns |  0.873 ns |  1.00 |    0.07 | 0.0038 |      - |      64 B |        1.00 |
| LastTwoTokensWithSpanAndLastIndexOf  | .NET 10.0 | .NET 10.0 |  26.14 ns | 0.288 ns |  0.256 ns |  1.55 |    0.08 | 0.0038 |      - |      64 B |        1.00 |
|                                      |           |           |           |          |           |       |         |        |        |           |             |
| LastTwoTokensWithSplit               | .NET 9.0  | .NET 9.0  | 272.27 ns | 5.224 ns |  5.364 ns | 16.52 |    0.71 | 0.0634 | 0.0005 |    1064 B |       16.62 |
| LastTwoTokensWithRegex               | .NET 9.0  | .NET 9.0  | 200.08 ns | 3.673 ns |  3.436 ns | 12.14 |    0.51 | 0.0339 |      - |     568 B |        8.88 |
| LastTwoTokensWithReverseAndSubstring | .NET 9.0  | .NET 9.0  | 480.21 ns | 9.591 ns | 17.538 ns | 29.13 |    1.54 | 0.0191 |      - |     328 B |        5.12 |
| LastTwoTokensWalkingBackwards        | .NET 9.0  | .NET 9.0  |  16.51 ns | 0.393 ns |  0.657 ns |  1.00 |    0.06 | 0.0038 |      - |      64 B |        1.00 |
| LastTwoTokensWithSpanAndLastIndexOf  | .NET 9.0  | .NET 9.0  |  26.01 ns | 0.285 ns |  0.266 ns |  1.58 |    0.06 | 0.0038 |      - |      64 B |        1.00 |
