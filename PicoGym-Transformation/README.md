# Hand-written simple C# code vs. ChatGPT rewritng Python code that solves https://play.picoctf.org/practice/challenge/104



``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22631.3007), VM=Hyper-V
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


```
|                           Method |        Mean |     Error |   StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------------------- |------------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
|                     DecodeString |    89.64 ns |  0.832 ns | 0.779 ns |  1.00 |    0.00 | 0.0196 |     328 B |        1.00 |
|     DecodeStringChatGPTRecursive | 1,429.82 ns | 10.078 ns | 8.934 ns | 15.95 |    0.20 | 0.3109 |    5216 B |       15.90 |
|          DecodeStringChatGPTLinq | 1,151.83 ns |  5.995 ns | 5.006 ns | 12.84 |    0.11 | 0.1297 |    2176 B |        6.63 |
| DecodeStringChatGPTStringBuilder |   501.69 ns |  4.732 ns | 4.426 ns |  5.60 |    0.06 | 0.0896 |    1512 B |        4.61 |
