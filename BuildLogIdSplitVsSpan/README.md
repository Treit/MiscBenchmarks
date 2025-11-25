# Building a "Log ID" consisting of a file name and line number



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| GetLogIdWithIndexOfAndSpan             | 37.87 ns | 0.536 ns | 0.501 ns |  1.00 |    0.02 | 0.0043 |      72 B |        1.00 |
| GetLogIdWithIndexOfAndSubstringChatGPT | 44.24 ns | 0.475 ns | 0.445 ns |  1.17 |    0.02 | 0.0086 |     144 B |        2.00 |
| GetLogIdWithSplit                      | 87.34 ns | 0.830 ns | 0.776 ns |  2.31 |    0.04 | 0.0157 |     264 B |        3.67 |
| GetLogIdWithCustomSpanSplit            | 38.93 ns | 0.281 ns | 0.249 ns |  1.03 |    0.01 | 0.0043 |      72 B |        1.00 |
