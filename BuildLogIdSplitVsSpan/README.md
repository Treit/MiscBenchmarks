# Building a "Log ID" consisting of a file name and line number





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                                 | Job       | Runtime   | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |---------- |---------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| GetLogIdWithIndexOfAndSpan             | .NET 10.0 | .NET 10.0 | 39.27 ns | 0.685 ns | 0.607 ns |  1.00 |    0.02 | 0.0043 |      72 B |        1.00 |
| GetLogIdWithIndexOfAndSubstringChatGPT | .NET 10.0 | .NET 10.0 | 45.12 ns | 0.486 ns | 0.379 ns |  1.15 |    0.02 | 0.0086 |     144 B |        2.00 |
| GetLogIdWithSplit                      | .NET 10.0 | .NET 10.0 | 88.39 ns | 1.248 ns | 1.167 ns |  2.25 |    0.04 | 0.0157 |     264 B |        3.67 |
| GetLogIdWithCustomSpanSplit            | .NET 10.0 | .NET 10.0 | 38.87 ns | 0.294 ns | 0.275 ns |  0.99 |    0.02 | 0.0043 |      72 B |        1.00 |
|                                        |           |           |          |          |          |       |         |        |           |             |
| GetLogIdWithIndexOfAndSpan             | .NET 9.0  | .NET 9.0  | 38.74 ns | 0.398 ns | 0.373 ns |  1.00 |    0.01 | 0.0043 |      72 B |        1.00 |
| GetLogIdWithIndexOfAndSubstringChatGPT | .NET 9.0  | .NET 9.0  | 45.11 ns | 0.410 ns | 0.383 ns |  1.16 |    0.01 | 0.0086 |     144 B |        2.00 |
| GetLogIdWithSplit                      | .NET 9.0  | .NET 9.0  | 90.07 ns | 1.133 ns | 1.004 ns |  2.33 |    0.03 | 0.0157 |     264 B |        3.67 |
| GetLogIdWithCustomSpanSplit            | .NET 9.0  | .NET 9.0  | 39.80 ns | 0.351 ns | 0.328 ns |  1.03 |    0.01 | 0.0043 |      72 B |        1.00 |
