# Calling Any() multiple times vs just once with a more complex predicate



```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | Count  | Mean           | Error         | StdDev        | Median         | Ratio     | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |------- |---------------:|--------------:|--------------:|---------------:|----------:|--------:|----------:|------------:|
| **SingleAnyWithMatch**            | **10**     |       **7.170 ns** |     **0.0547 ns** |     **0.0512 ns** |       **7.200 ns** |      **1.00** |    **0.01** |         **-** |          **NA** |
| SingleAnyWithNoMatch          | 10     |       7.181 ns |     0.0488 ns |     0.0456 ns |       7.202 ns |      1.00 |    0.01 |         - |          NA |
| MultipleCallsToAnyWithMatch   | 10     |      30.993 ns |     0.2288 ns |     0.2140 ns |      31.101 ns |      4.32 |    0.04 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | 10     |      30.746 ns |     0.2462 ns |     0.2303 ns |      30.873 ns |      4.29 |    0.04 |         - |          NA |
|                               |        |                |               |               |                |           |         |           |             |
| **SingleAnyWithMatch**            | **100000** |       **7.988 ns** |     **0.0621 ns** |     **0.0518 ns** |       **7.992 ns** |      **1.00** |    **0.01** |         **-** |          **NA** |
| SingleAnyWithNoMatch          | 100000 |  66,000.478 ns | 1,670.1257 ns | 4,710.6196 ns |  68,063.196 ns |  8,262.95 |  589.07 |         - |          NA |
| MultipleCallsToAnyWithMatch   | 100000 |  65,058.493 ns | 2,040.3461 ns | 5,919.4146 ns |  67,835.791 ns |  8,145.02 |  739.32 |         - |          NA |
| MultipleCallsToAnyWithNoMatch | 100000 | 381,861.846 ns | 6,353.2559 ns | 5,942.8395 ns | 382,078.857 ns | 47,807.30 |  780.62 |         - |          NA |
