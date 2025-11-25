# Getting the last two tokens from a delimited string.



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                               | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------------------------------- |----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| LastTwoTokensWithSplit               | 275.96 ns | 2.912 ns | 2.724 ns | 16.35 |    0.45 | 0.0634 | 0.0005 |    1064 B |       16.62 |
| LastTwoTokensWithRegex               | 195.82 ns | 1.871 ns | 1.750 ns | 11.60 |    0.32 | 0.0339 |      - |     568 B |        8.88 |
| LastTwoTokensWithReverseAndSubstring | 449.89 ns | 8.929 ns | 8.353 ns | 26.66 |    0.84 | 0.0196 |      - |     328 B |        5.12 |
| LastTwoTokensWalkingBackwards        |  16.89 ns | 0.383 ns | 0.456 ns |  1.00 |    0.04 | 0.0038 |      - |      64 B |        1.00 |
| LastTwoTokensWithSpanAndLastIndexOf  |  25.61 ns | 0.170 ns | 0.159 ns |  1.52 |    0.04 | 0.0038 |      - |      64 B |        1.00 |
