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
| GetLogIdWithIndexOfAndSpan             | 151.91 ns | 2.969 ns | 2.916 ns |  1.00 |    0.00 | 0.0167 |      72 B |        1.00 |
| GetLogIdWithIndexOfAndSubstringChatGPT | 138.99 ns | 2.840 ns | 7.125 ns |  0.91 |    0.05 | 0.0334 |     144 B |        2.00 |
| GetLogIdWithSplit                      | 177.46 ns | 3.509 ns | 4.177 ns |  1.17 |    0.03 | 0.0610 |     264 B |        3.67 |
| GetLogIdWithCustomSpanSplit            |  66.93 ns | 1.401 ns | 2.631 ns |  0.44 |    0.02 | 0.0167 |      72 B |        1.00 |
