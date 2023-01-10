# Hand-written simple C# code vs. ChatGPT rewritng Python code that solves https://play.picoctf.org/practice/challenge/104


``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.25272.1000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|                           Method |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------------------- |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|----------:|------------:|
|                     DecodeString |   120.0 ns |  3.74 ns |  10.97 ns |   116.1 ns |  1.00 |    0.00 | 0.0761 |     328 B |        1.00 |
|     DecodeStringChatGPTRecursive | 2,910.9 ns | 96.14 ns | 278.92 ns | 2,904.9 ns | 24.39 |    3.06 | 1.2093 |    5216 B |       15.90 |
|          DecodeStringChatGPTLinq | 2,501.2 ns | 73.89 ns | 208.41 ns | 2,448.7 ns | 20.84 |    2.47 | 0.7133 |    3088 B |        9.41 |
| DecodeStringChatGPTStringBuilder |   798.1 ns | 20.20 ns |  58.60 ns |   788.3 ns |  6.68 |    0.69 | 0.3500 |    1512 B |        4.61 |
