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
| LastTwoTokensWithSplit               | 269.50 ns | 3.045 ns | 2.543 ns | 15.53 |    0.64 | 0.0634 | 0.0005 |    1064 B |       16.62 |
| LastTwoTokensWithRegex               | 196.97 ns | 1.862 ns | 1.651 ns | 11.35 |    0.47 | 0.0339 |      - |     568 B |        8.88 |
| LastTwoTokensWithReverseAndSubstring | 469.59 ns | 9.046 ns | 8.462 ns | 27.06 |    1.19 | 0.0191 |      - |     328 B |        5.12 |
| LastTwoTokensWalkingBackwards        |  17.38 ns | 0.412 ns | 0.689 ns |  1.00 |    0.06 | 0.0038 |      - |      64 B |        1.00 |
| LastTwoTokensWithSpanAndLastIndexOf  |  25.89 ns | 0.182 ns | 0.170 ns |  1.49 |    0.06 | 0.0038 |      - |      64 B |        1.00 |
