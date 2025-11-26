# Hand-written simple C# code vs. ChatGPT rewritng Python code that solves https://play.picoctf.org/practice/challenge/104





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| DecodeString                     |    86.35 ns |  1.281 ns |  1.198 ns |  1.00 |    0.02 | 0.0196 |     328 B |        1.00 |
| DecodeStringChatGPTRecursive     | 1,180.39 ns | 23.625 ns | 22.098 ns | 13.67 |    0.31 | 0.3109 |    5216 B |       15.90 |
| DecodeStringChatGPTLinq          |   854.21 ns |  5.628 ns |  4.989 ns |  9.89 |    0.14 | 0.1297 |    2176 B |        6.63 |
| DecodeStringChatGPTStringBuilder |   371.93 ns |  3.983 ns |  3.531 ns |  4.31 |    0.07 | 0.0901 |    1512 B |        4.61 |
