# Repeating strings



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **DupeUsingStringBuilderLoop**   | **3**     |  **26.81 ns** | **0.305 ns** | **0.271 ns** |  **1.00** |    **0.01** | **0.0081** |     **136 B** |        **1.00** |
| DupeUsingStringCreate        | 3     |  13.53 ns | 0.325 ns | 0.304 ns |  0.50 |    0.01 | 0.0024 |      40 B |        0.29 |
| DupeUsingStackOverflowAnswer | 3     |  44.24 ns | 0.344 ns | 0.305 ns |  1.65 |    0.02 | 0.0114 |     192 B |        1.41 |
| DupeUsingEnumerableRepeat    | 3     |  31.39 ns | 0.574 ns | 0.537 ns |  1.17 |    0.02 | 0.0048 |      80 B |        0.59 |
|                              |       |           |          |          |       |         |        |           |             |
| **DupeUsingStringBuilderLoop**   | **50**    | **195.93 ns** | **1.262 ns** | **1.054 ns** |  **1.00** |    **0.01** | **0.0420** |     **704 B** |        **1.00** |
| DupeUsingStringCreate        | 50    | 145.24 ns | 1.804 ns | 1.687 ns |  0.74 |    0.01 | 0.0196 |     328 B |        0.47 |
| DupeUsingStackOverflowAnswer | 50    | 512.52 ns | 7.756 ns | 7.255 ns |  2.62 |    0.04 | 0.0849 |    1432 B |        2.03 |
| DupeUsingEnumerableRepeat    | 50    | 216.73 ns | 1.858 ns | 1.738 ns |  1.11 |    0.01 | 0.0219 |     368 B |        0.52 |
|                              |       |           |          |          |       |         |        |           |             |
| **DupeUsingStringBuilderLoop**   | **100**   | **395.03 ns** | **4.095 ns** | **3.831 ns** |  **1.00** |    **0.01** | **0.0772** |    **1296 B** |        **1.00** |
| DupeUsingStringCreate        | 100   | 288.64 ns | 3.138 ns | 2.935 ns |  0.73 |    0.01 | 0.0372 |     624 B |        0.48 |
| DupeUsingStackOverflowAnswer | 100   | 925.03 ns | 6.385 ns | 5.660 ns |  2.34 |    0.03 | 0.1497 |    2512 B |        1.94 |
| DupeUsingEnumerableRepeat    | 100   | 437.97 ns | 3.391 ns | 3.172 ns |  1.11 |    0.01 | 0.0396 |     664 B |        0.51 |
