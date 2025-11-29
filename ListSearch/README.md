# Searching List<string>





```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  .NET 9.0  : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Job       | Runtime   | Count   | Mean            | Error         | StdDev        | Ratio | RatioSD |
|-------------------- |---------- |---------- |-------- |----------------:|--------------:|--------------:|------:|--------:|
| **ForLoopSearch**       | **.NET 10.0** | **.NET 10.0** | **10**      |        **16.34 ns** |      **0.358 ns** |      **0.690 ns** |  **1.00** |    **0.06** |
| ForEachLoopSearch   | .NET 10.0 | .NET 10.0 | 10      |        14.07 ns |      0.313 ns |      0.815 ns |  0.86 |    0.06 |
| ListFindIndexSearch | .NET 10.0 | .NET 10.0 | 10      |        31.80 ns |      0.265 ns |      0.235 ns |  1.95 |    0.08 |
| ListIndexOfSearch   | .NET 10.0 | .NET 10.0 | 10      |        10.13 ns |      0.016 ns |      0.014 ns |  0.62 |    0.03 |
| LinqSearch          | .NET 10.0 | .NET 10.0 | 10      |       128.84 ns |      0.944 ns |      0.883 ns |  7.90 |    0.33 |
|                     |           |           |         |                 |               |               |       |         |
| ForLoopSearch       | .NET 9.0  | .NET 9.0  | 10      |        16.42 ns |      0.361 ns |      0.592 ns |  1.00 |    0.05 |
| ForEachLoopSearch   | .NET 9.0  | .NET 9.0  | 10      |        14.10 ns |      0.311 ns |      0.683 ns |  0.86 |    0.05 |
| ListFindIndexSearch | .NET 9.0  | .NET 9.0  | 10      |        31.64 ns |      0.075 ns |      0.067 ns |  1.93 |    0.07 |
| ListIndexOfSearch   | .NET 9.0  | .NET 9.0  | 10      |        10.12 ns |      0.017 ns |      0.015 ns |  0.62 |    0.02 |
| LinqSearch          | .NET 9.0  | .NET 9.0  | 10      |       130.00 ns |      0.943 ns |      0.882 ns |  7.93 |    0.29 |
|                     |           |           |         |                 |               |               |       |         |
| **ForLoopSearch**       | **.NET 10.0** | **.NET 10.0** | **1000**    |     **1,522.15 ns** |      **4.913 ns** |      **4.356 ns** |  **1.00** |    **0.00** |
| ForEachLoopSearch   | .NET 10.0 | .NET 10.0 | 1000    |     1,219.39 ns |      3.415 ns |      3.027 ns |  0.80 |    0.00 |
| ListFindIndexSearch | .NET 10.0 | .NET 10.0 | 1000    |     2,489.82 ns |      3.888 ns |      3.447 ns |  1.64 |    0.01 |
| ListIndexOfSearch   | .NET 10.0 | .NET 10.0 | 1000    |       802.68 ns |      3.322 ns |      3.107 ns |  0.53 |    0.00 |
| LinqSearch          | .NET 10.0 | .NET 10.0 | 1000    |     6,040.45 ns |    116.242 ns |    114.166 ns |  3.97 |    0.07 |
|                     |           |           |         |                 |               |               |       |         |
| ForLoopSearch       | .NET 9.0  | .NET 9.0  | 1000    |     1,537.89 ns |      8.826 ns |      8.255 ns |  1.00 |    0.01 |
| ForEachLoopSearch   | .NET 9.0  | .NET 9.0  | 1000    |     1,220.86 ns |      2.237 ns |      1.746 ns |  0.79 |    0.00 |
| ListFindIndexSearch | .NET 9.0  | .NET 9.0  | 1000    |     2,494.95 ns |      8.274 ns |      7.739 ns |  1.62 |    0.01 |
| ListIndexOfSearch   | .NET 9.0  | .NET 9.0  | 1000    |       949.38 ns |      0.943 ns |      0.787 ns |  0.62 |    0.00 |
| LinqSearch          | .NET 9.0  | .NET 9.0  | 1000    |     6,178.31 ns |    118.696 ns |    154.338 ns |  4.02 |    0.10 |
|                     |           |           |         |                 |               |               |       |         |
| **ForLoopSearch**       | **.NET 10.0** | **.NET 10.0** | **1000000** | **2,207,850.35 ns** | **12,792.994 ns** | **11,966.574 ns** |  **1.00** |    **0.01** |
| ForEachLoopSearch   | .NET 10.0 | .NET 10.0 | 1000000 | 2,175,924.64 ns | 37,176.864 ns | 34,775.261 ns |  0.99 |    0.02 |
| ListFindIndexSearch | .NET 10.0 | .NET 10.0 | 1000000 | 3,289,086.28 ns |  7,966.795 ns |  6,652.635 ns |  1.49 |    0.01 |
| ListIndexOfSearch   | .NET 10.0 | .NET 10.0 | 1000000 | 1,716,090.51 ns | 19,048.359 ns | 16,885.874 ns |  0.78 |    0.01 |
| LinqSearch          | .NET 10.0 | .NET 10.0 | 1000000 | 6,251,040.18 ns | 76,381.826 ns | 67,710.499 ns |  2.83 |    0.03 |
|                     |           |           |         |                 |               |               |       |         |
| ForLoopSearch       | .NET 9.0  | .NET 9.0  | 1000000 | 2,208,859.34 ns | 10,198.046 ns |  8,515.831 ns |  1.00 |    0.01 |
| ForEachLoopSearch   | .NET 9.0  | .NET 9.0  | 1000000 | 2,164,554.23 ns | 16,670.933 ns | 15,594.001 ns |  0.98 |    0.01 |
| ListFindIndexSearch | .NET 9.0  | .NET 9.0  | 1000000 | 3,291,375.61 ns |  7,616.888 ns |  6,752.173 ns |  1.49 |    0.01 |
| ListIndexOfSearch   | .NET 9.0  | .NET 9.0  | 1000000 | 1,730,193.33 ns | 34,049.433 ns | 46,607.252 ns |  0.78 |    0.02 |
| LinqSearch          | .NET 9.0  | .NET 9.0  | 1000000 | 6,240,551.12 ns | 30,025.324 ns | 26,616.667 ns |  2.83 |    0.02 |
