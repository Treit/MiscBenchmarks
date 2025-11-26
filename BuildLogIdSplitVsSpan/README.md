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
| GetLogIdWithIndexOfAndSpan             | 38.36 ns | 0.363 ns | 0.340 ns |  1.00 |    0.01 | 0.0043 |      72 B |        1.00 |
| GetLogIdWithIndexOfAndSubstringChatGPT | 44.56 ns | 0.443 ns | 0.414 ns |  1.16 |    0.01 | 0.0086 |     144 B |        2.00 |
| GetLogIdWithSplit                      | 90.09 ns | 1.553 ns | 1.452 ns |  2.35 |    0.04 | 0.0157 |     264 B |        3.67 |
| GetLogIdWithCustomSpanSplit            | 38.77 ns | 0.372 ns | 0.348 ns |  1.01 |    0.01 | 0.0043 |      72 B |        1.00 |
