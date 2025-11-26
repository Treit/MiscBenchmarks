# Calling Any() multiple times vs just once with a more complex predicate




```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count  | Mean           | Error         | StdDev        | Median         | Ratio     | RatioSD  | Allocated | Alloc Ratio |
|------------------------------ |------- |---------------:|--------------:|--------------:|---------------:|----------:|---------:|----------:|------------:|
| **SingleAnyWithMatch**            | **10**     |       **7.191 ns** |     **0.0688 ns** |     **0.0643 ns** |       **7.210 ns** |      **1.00** |     **0.01** |         **-** |          **NA** |
| SingleAnyWithNoMatch          | 10     |       7.203 ns |     0.0601 ns |     0.0563 ns |       7.223 ns |      1.00 |     0.01 |         - |          NA |
| MultipleCallsToAnyWithMatch   | 10     |      31.627 ns |     0.3514 ns |     0.3287 ns |      31.700 ns |      4.40 |     0.06 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | 10     |      31.780 ns |     0.3286 ns |     0.3074 ns |      31.889 ns |      4.42 |     0.06 |         - |          NA |
|                               |        |                |               |               |                |           |          |           |             |
| **SingleAnyWithMatch**            | **100000** |       **8.171 ns** |     **0.2000 ns** |     **0.2804 ns** |       **8.040 ns** |      **1.00** |     **0.05** |         **-** |          **NA** |
| SingleAnyWithNoMatch          | 100000 |  67,465.524 ns | 1,345.3733 ns | 3,637.2952 ns |  68,589.087 ns |  8,266.07 |   517.96 |         - |          NA |
| MultipleCallsToAnyWithMatch   | 100000 |  67,160.862 ns | 1,342.8440 ns | 3,809.4253 ns |  68,421.179 ns |  8,228.74 |   535.62 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | 100000 | 321,720.020 ns | 3,712.8043 ns | 3,472.9594 ns | 322,624.170 ns | 39,418.07 | 1,343.05 |         - |          NA |
