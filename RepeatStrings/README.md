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
| **DupeUsingStringBuilderLoop**   | **3**     |  **26.61 ns** | **0.292 ns** | **0.273 ns** |  **1.00** |    **0.01** | **0.0081** |     **136 B** |        **1.00** |
| DupeUsingStringCreate        | 3     |  13.38 ns | 0.155 ns | 0.145 ns |  0.50 |    0.01 | 0.0024 |      40 B |        0.29 |
| DupeUsingStackOverflowAnswer | 3     |  47.34 ns | 0.571 ns | 0.534 ns |  1.78 |    0.03 | 0.0114 |     192 B |        1.41 |
| DupeUsingEnumerableRepeat    | 3     |  35.62 ns | 0.474 ns | 0.443 ns |  1.34 |    0.02 | 0.0048 |      80 B |        0.59 |
|                              |       |           |          |          |       |         |        |           |             |
| **DupeUsingStringBuilderLoop**   | **50**    | **209.65 ns** | **2.216 ns** | **2.073 ns** |  **1.00** |    **0.01** | **0.0420** |     **704 B** |        **1.00** |
| DupeUsingStringCreate        | 50    | 149.10 ns | 3.032 ns | 4.630 ns |  0.71 |    0.02 | 0.0196 |     328 B |        0.47 |
| DupeUsingStackOverflowAnswer | 50    | 477.99 ns | 4.736 ns | 4.430 ns |  2.28 |    0.03 | 0.0849 |    1432 B |        2.03 |
| DupeUsingEnumerableRepeat    | 50    | 223.38 ns | 1.647 ns | 1.541 ns |  1.07 |    0.01 | 0.0219 |     368 B |        0.52 |
|                              |       |           |          |          |       |         |        |           |             |
| **DupeUsingStringBuilderLoop**   | **100**   | **395.21 ns** | **3.605 ns** | **3.372 ns** |  **1.00** |    **0.01** | **0.0772** |    **1296 B** |        **1.00** |
| DupeUsingStringCreate        | 100   | 291.34 ns | 3.782 ns | 3.353 ns |  0.74 |    0.01 | 0.0372 |     624 B |        0.48 |
| DupeUsingStackOverflowAnswer | 100   | 997.74 ns | 7.273 ns | 6.803 ns |  2.52 |    0.03 | 0.1488 |    2512 B |        1.94 |
| DupeUsingEnumerableRepeat    | 100   | 421.51 ns | 5.106 ns | 4.776 ns |  1.07 |    0.01 | 0.0396 |     664 B |        0.51 |
