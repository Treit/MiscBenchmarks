# Hand-written simple C# code vs. ChatGPT rewritng Python code that solves https://play.picoctf.org/practice/challenge/104


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25272.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|                       Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|----------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
|                 DecodeString |   115.5 ns |   2.89 ns |   8.18 ns |   112.8 ns |  1.00 |    0.00 | 0.0761 |     328 B |        1.00 |
| DecodeStringChatGPTRecursive | 2,825.5 ns | 104.22 ns | 293.94 ns | 2,746.4 ns | 24.58 |    3.18 | 1.2093 |    5216 B |       15.90 |
|      DecodeStringChatGPTLinq | 2,503.8 ns |  70.03 ns | 204.29 ns | 2,478.9 ns | 21.83 |    2.35 | 0.7133 |    3088 B |        9.41 |
