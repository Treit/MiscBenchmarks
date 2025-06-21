# Returning a collection of things that should not be mutated as an IReadOnlyList<T> vs. an ImmutableArray<T>.

```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.27881.1000)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX-512F+CD+BW+DQ+VL


```
| Method              | Iterations | Mean             | Error          | StdDev           | Median           | Ratio  | RatioSD | Gen0       | Allocated   | Alloc Ratio |
|-------------------- |----------- |-----------------:|---------------:|-----------------:|-----------------:|-------:|--------:|-----------:|------------:|------------:|
| **GetAsImmutableArray** | **10**         |      **4,494.05 ns** |      **89.694 ns** |       **260.218 ns** |      **4,449.66 ns** | **168.40** |   **11.20** |     **9.3231** |     **40240 B** |          **NA** |
| GetAsReadOnlyList   | 10         |         26.72 ns |       0.555 ns |         0.927 ns |         26.52 ns |   1.00 |    0.05 |          - |           - |          NA |
|                     |            |                  |                |                  |                  |        |         |            |             |             |
| **GetAsImmutableArray** | **100000**     | **44,006,381.94 ns** | **874,326.041 ns** | **1,460,802.517 ns** | **44,012,060.00 ns** | **160.73** |   **15.76** | **93200.0000** | **402400000 B** |          **NA** |
| GetAsReadOnlyList   | 100000     |    276,440.81 ns |  10,285.354 ns |    29,010.026 ns |    268,185.52 ns |   1.01 |    0.14 |          - |           - |          NA |
