# Repeating strings





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                       | Job       | Runtime   | Count | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------------- |---------- |---------- |------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **DupeUsingStringBuilderLoop**   | **.NET 10.0** | **.NET 10.0** | **3**     |  **25.76 ns** | **0.191 ns** | **0.178 ns** |  **1.00** |    **0.01** | **0.0081** |     **136 B** |        **1.00** |
| DupeUsingStringCreate        | .NET 10.0 | .NET 10.0 | 3     |  13.09 ns | 0.063 ns | 0.053 ns |  0.51 |    0.00 | 0.0024 |      40 B |        0.29 |
| DupeUsingStackOverflowAnswer | .NET 10.0 | .NET 10.0 | 3     |  43.81 ns | 0.386 ns | 0.361 ns |  1.70 |    0.02 | 0.0114 |     192 B |        1.41 |
| DupeUsingEnumerableRepeat    | .NET 10.0 | .NET 10.0 | 3     |  30.52 ns | 0.328 ns | 0.291 ns |  1.18 |    0.01 | 0.0048 |      80 B |        0.59 |
|                              |           |           |       |           |          |          |       |         |        |           |             |
| DupeUsingStringBuilderLoop   | .NET 9.0  | .NET 9.0  | 3     |  26.03 ns | 0.182 ns | 0.171 ns |  1.00 |    0.01 | 0.0081 |     136 B |        1.00 |
| DupeUsingStringCreate        | .NET 9.0  | .NET 9.0  | 3     |  13.03 ns | 0.162 ns | 0.152 ns |  0.50 |    0.01 | 0.0024 |      40 B |        0.29 |
| DupeUsingStackOverflowAnswer | .NET 9.0  | .NET 9.0  | 3     |  43.72 ns | 0.183 ns | 0.162 ns |  1.68 |    0.01 | 0.0114 |     192 B |        1.41 |
| DupeUsingEnumerableRepeat    | .NET 9.0  | .NET 9.0  | 3     |  30.37 ns | 0.283 ns | 0.251 ns |  1.17 |    0.01 | 0.0048 |      80 B |        0.59 |
|                              |           |           |       |           |          |          |       |         |        |           |             |
| **DupeUsingStringBuilderLoop**   | **.NET 10.0** | **.NET 10.0** | **50**    | **192.50 ns** | **1.448 ns** | **1.355 ns** |  **1.00** |    **0.01** | **0.0420** |     **704 B** |        **1.00** |
| DupeUsingStringCreate        | .NET 10.0 | .NET 10.0 | 50    | 146.84 ns | 2.895 ns | 3.962 ns |  0.76 |    0.02 | 0.0196 |     328 B |        0.47 |
| DupeUsingStackOverflowAnswer | .NET 10.0 | .NET 10.0 | 50    | 474.64 ns | 2.955 ns | 2.620 ns |  2.47 |    0.02 | 0.0849 |    1432 B |        2.03 |
| DupeUsingEnumerableRepeat    | .NET 10.0 | .NET 10.0 | 50    | 217.73 ns | 2.648 ns | 2.477 ns |  1.13 |    0.01 | 0.0219 |     368 B |        0.52 |
|                              |           |           |       |           |          |          |       |         |        |           |             |
| DupeUsingStringBuilderLoop   | .NET 9.0  | .NET 9.0  | 50    | 204.60 ns | 1.145 ns | 1.071 ns |  1.00 |    0.01 | 0.0420 |     704 B |        1.00 |
| DupeUsingStringCreate        | .NET 9.0  | .NET 9.0  | 50    | 149.20 ns | 3.015 ns | 3.096 ns |  0.73 |    0.02 | 0.0196 |     328 B |        0.47 |
| DupeUsingStackOverflowAnswer | .NET 9.0  | .NET 9.0  | 50    | 501.77 ns | 4.212 ns | 3.939 ns |  2.45 |    0.02 | 0.0849 |    1432 B |        2.03 |
| DupeUsingEnumerableRepeat    | .NET 9.0  | .NET 9.0  | 50    | 217.93 ns | 1.853 ns | 1.733 ns |  1.07 |    0.01 | 0.0219 |     368 B |        0.52 |
|                              |           |           |       |           |          |          |       |         |        |           |             |
| **DupeUsingStringBuilderLoop**   | **.NET 10.0** | **.NET 10.0** | **100**   | **367.15 ns** | **3.291 ns** | **3.079 ns** |  **1.00** |    **0.01** | **0.0772** |    **1296 B** |        **1.00** |
| DupeUsingStringCreate        | .NET 10.0 | .NET 10.0 | 100   | 284.11 ns | 4.110 ns | 3.844 ns |  0.77 |    0.01 | 0.0372 |     624 B |        0.48 |
| DupeUsingStackOverflowAnswer | .NET 10.0 | .NET 10.0 | 100   | 853.65 ns | 8.155 ns | 7.628 ns |  2.33 |    0.03 | 0.1497 |    2512 B |        1.94 |
| DupeUsingEnumerableRepeat    | .NET 10.0 | .NET 10.0 | 100   | 429.68 ns | 2.424 ns | 2.267 ns |  1.17 |    0.01 | 0.0396 |     664 B |        0.51 |
|                              |           |           |       |           |          |          |       |         |        |           |             |
| DupeUsingStringBuilderLoop   | .NET 9.0  | .NET 9.0  | 100   | 390.17 ns | 3.205 ns | 2.998 ns |  1.00 |    0.01 | 0.0772 |    1296 B |        1.00 |
| DupeUsingStringCreate        | .NET 9.0  | .NET 9.0  | 100   | 286.52 ns | 1.865 ns | 1.744 ns |  0.73 |    0.01 | 0.0372 |     624 B |        0.48 |
| DupeUsingStackOverflowAnswer | .NET 9.0  | .NET 9.0  | 100   | 897.08 ns | 8.080 ns | 7.558 ns |  2.30 |    0.03 | 0.1497 |    2512 B |        1.94 |
| DupeUsingEnumerableRepeat    | .NET 9.0  | .NET 9.0  | 100   | 431.34 ns | 4.108 ns | 3.208 ns |  1.11 |    0.01 | 0.0396 |     664 B |        0.51 |
