# Building a "Log ID" consisting of a file name and line number


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.27793.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                                 | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| GetLogIdWithIndexOfAndSpan             |  63.60 ns | 0.693 ns | 0.614 ns |  1.00 |    0.00 | 0.0167 |      72 B |        1.00 |
| GetLogIdWithIndexOfAndSubstringChatGPT |  78.87 ns | 1.643 ns | 2.304 ns |  1.24 |    0.04 | 0.0334 |     144 B |        2.00 |
| GetLogIdWithSplit                      | 166.11 ns | 3.150 ns | 5.262 ns |  2.62 |    0.08 | 0.0610 |     264 B |        3.67 |
| GetLogIdWithCustomSpanSplit            |  65.56 ns | 0.557 ns | 0.494 ns |  1.03 |    0.01 | 0.0167 |      72 B |        1.00 |
