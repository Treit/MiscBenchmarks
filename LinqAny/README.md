# Calling Any() multiple times vs just once with a more complex predicate


```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26231.5000)
Intel Xeon W-2123 CPU 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.2.24157.14
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method                        | Count  | Mean           | Error        | StdDev       | Ratio     | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------------ |------- |---------------:|-------------:|-------------:|----------:|--------:|-------:|----------:|------------:|
| **SingleAnyWithMatch**            | **10**     |       **114.3 ns** |      **2.31 ns** |      **2.48 ns** |      **1.00** |    **0.00** | **0.0091** |      **40 B** |        **1.00** |
| SingleAnyWithNoMatch          | 10     |       112.2 ns |      2.06 ns |      1.92 ns |      0.98 |    0.02 | 0.0092 |      40 B |        1.00 |
| MultipleCallsToAnyWithMatch   | 10     |       201.3 ns |      3.82 ns |      5.23 ns |      1.77 |    0.07 | 0.0184 |      80 B |        2.00 |
| MultipleCallsToAnyWithNoMatch | 10     |       196.8 ns |      2.74 ns |      2.29 ns |      1.72 |    0.05 | 0.0184 |      80 B |        2.00 |
|                               |        |                |              |              |           |         |        |           |             |
| **SingleAnyWithMatch**            | **100000** |       **100.6 ns** |      **2.01 ns** |      **2.47 ns** |      **1.00** |    **0.00** | **0.0092** |      **40 B** |        **1.00** |
| SingleAnyWithNoMatch          | 100000 |   786,662.7 ns | 16,641.44 ns | 46,113.36 ns |  7,587.39 |  361.75 |      - |      40 B |        1.00 |
| MultipleCallsToAnyWithMatch   | 100000 |   755,525.2 ns | 13,369.81 ns | 22,702.95 ns |  7,541.68 |  260.65 |      - |      80 B |        2.00 |
| MultipleCallsToAnyWithNoMatch | 100000 | 1,606,118.5 ns | 22,512.65 ns | 18,799.08 ns | 15,831.95 |  422.32 |      - |      81 B |        2.02 |
