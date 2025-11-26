# Searching List<string>




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | Count   | Mean            | Error         | StdDev        | Median          | Ratio | RatioSD |
|-------------------- |-------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|
| **ForLoopSearch**       | **10**      |        **15.83 ns** |      **0.345 ns** |      **0.460 ns** |        **15.58 ns** |  **1.00** |    **0.04** |
| ForEachLoopSearch   | 10      |        13.76 ns |      0.160 ns |      0.125 ns |        13.77 ns |  0.87 |    0.03 |
| ListFindIndexSearch | 10      |        28.34 ns |      0.301 ns |      0.282 ns |        28.39 ns |  1.79 |    0.05 |
| ListIndexOfSearch   | 10      |        10.53 ns |      0.235 ns |      0.393 ns |        10.32 ns |  0.67 |    0.03 |
| LinqSearch          | 10      |       130.19 ns |      1.546 ns |      1.446 ns |       130.47 ns |  8.23 |    0.25 |
|                     |         |                 |               |               |                 |       |         |
| **ForLoopSearch**       | **1000**    |     **1,512.95 ns** |      **9.447 ns** |      **8.836 ns** |     **1,513.66 ns** |  **1.00** |    **0.01** |
| ForEachLoopSearch   | 1000    |     1,297.69 ns |      8.136 ns |      7.610 ns |     1,299.23 ns |  0.86 |    0.01 |
| ListFindIndexSearch | 1000    |     2,253.61 ns |     44.146 ns |     86.102 ns |     2,210.85 ns |  1.49 |    0.06 |
| ListIndexOfSearch   | 1000    |       959.84 ns |      5.175 ns |      4.840 ns |       957.98 ns |  0.63 |    0.00 |
| LinqSearch          | 1000    |     6,110.86 ns |     92.272 ns |     81.797 ns |     6,098.18 ns |  4.04 |    0.06 |
|                     |         |                 |               |               |                 |       |         |
| **ForLoopSearch**       | **1000000** | **2,304,641.08 ns** | **27,853.033 ns** | **26,053.744 ns** | **2,304,116.60 ns** |  **1.00** |    **0.02** |
| ForEachLoopSearch   | 1000000 | 2,200,554.95 ns | 38,406.019 ns | 35,925.014 ns | 2,194,637.50 ns |  0.95 |    0.02 |
| ListFindIndexSearch | 1000000 | 2,794,444.79 ns | 22,107.155 ns | 20,679.047 ns | 2,803,467.58 ns |  1.21 |    0.02 |
| ListIndexOfSearch   | 1000000 | 1,816,297.72 ns | 25,787.050 ns | 21,533.355 ns | 1,809,170.31 ns |  0.79 |    0.01 |
| LinqSearch          | 1000000 | 6,280,276.74 ns | 47,773.750 ns | 44,687.596 ns | 6,281,602.73 ns |  2.73 |    0.04 |
