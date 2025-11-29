# Hand-written simple C# code vs. ChatGPT rewritng Python code that solves https://play.picoctf.org/practice/challenge/104






```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                           | Job       | Runtime   | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------------- |---------- |---------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| DecodeString                     | .NET 10.0 | .NET 10.0 |    84.30 ns |  0.724 ns |  0.642 ns |  1.00 |    0.01 | 0.0196 |     328 B |        1.00 |
| DecodeStringChatGPTRecursive     | .NET 10.0 | .NET 10.0 | 1,162.82 ns | 22.687 ns | 23.298 ns | 13.79 |    0.29 | 0.3109 |    5216 B |       15.90 |
| DecodeStringChatGPTLinq          | .NET 10.0 | .NET 10.0 |   826.99 ns |  4.422 ns |  3.692 ns |  9.81 |    0.08 | 0.1297 |    2176 B |        6.63 |
| DecodeStringChatGPTStringBuilder | .NET 10.0 | .NET 10.0 |   362.16 ns |  2.385 ns |  2.231 ns |  4.30 |    0.04 | 0.0901 |    1512 B |        4.61 |
|                                  |           |           |             |           |           |       |         |        |           |             |
| DecodeString                     | .NET 9.0  | .NET 9.0  |    84.02 ns |  0.509 ns |  0.451 ns |  1.00 |    0.01 | 0.0196 |     328 B |        1.00 |
| DecodeStringChatGPTRecursive     | .NET 9.0  | .NET 9.0  | 1,145.52 ns |  8.348 ns |  7.400 ns | 13.63 |    0.11 | 0.3109 |    5216 B |       15.90 |
| DecodeStringChatGPTLinq          | .NET 9.0  | .NET 9.0  |   852.02 ns | 16.526 ns | 16.231 ns | 10.14 |    0.19 | 0.1297 |    2176 B |        6.63 |
| DecodeStringChatGPTStringBuilder | .NET 9.0  | .NET 9.0  |   370.05 ns |  3.852 ns |  3.603 ns |  4.40 |    0.05 | 0.0901 |    1512 B |        4.61 |
