# Hand-written simple C# code vs. ChatGPT rewritng Python code that solves https://play.picoctf.org/practice/challenge/104




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Mean        | Error     | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------- |------------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| DecodeString                     |    84.34 ns |  1.151 ns | 1.077 ns |  1.00 |    0.02 | 0.0196 |     328 B |        1.00 |
| DecodeStringChatGPTRecursive     | 1,207.22 ns | 10.124 ns | 8.975 ns | 14.32 |    0.20 | 0.3109 |    5216 B |       15.90 |
| DecodeStringChatGPTLinq          |   832.10 ns |  4.653 ns | 3.885 ns |  9.87 |    0.13 | 0.1297 |    2176 B |        6.63 |
| DecodeStringChatGPTStringBuilder |   380.37 ns |  7.391 ns | 6.913 ns |  4.51 |    0.10 | 0.0901 |    1512 B |        4.61 |
